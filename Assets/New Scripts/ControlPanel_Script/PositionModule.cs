using UnityEngine;
using System.Collections;

public class PositionModule : MonoBehaviour {
	ControlPanel Main;
//	CooSystem CooSystem_script;
//	MoveControl MoveControl_script;
	//位置界面功能完善---宋荣 ---03.09
	MDIInputModule MDIInput_script;
	float lastTime=0;//闪烁时记录上次时间
	float xyzLastTime=0;
	bool displayFlag=true;
	bool xDisplayFlag=true;
	bool yDisplayFlag=true;
	bool zDisplayFlag=true;
	public bool xBlink=false;
	public bool yBlink=false;
	public bool zBlink=false;
	//位置界面功能完善---宋荣 ---03.09
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
//		CooSystem_script = gameObject.GetComponent<CooSystem>();
//		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		//位置界面功能完善---宋荣 ---03.09
		MDIInput_script = gameObject.GetComponent<MDIInputModule>();
		//位置界面功能完善---宋荣 ---03.09
	}
	
	[RPC]
	void PositionRPC(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			Main.AbsoluteCoo = true;
		else
			Main.AbsoluteCoo = false;
		if(info_array[1] == "True")
			Main.RelativeCoo = true;
		else
			Main.RelativeCoo = false;
		if(info_array[2] == "True")
			Main.GeneralCoo = true;
		else
			Main.GeneralCoo  = false;
		if(info_array[3] == "True")
			MDIInput_script.isXSelected = true;
		else
			MDIInput_script.isXSelected = false;
		if(info_array[4] == "True")
			MDIInput_script.isYSelected = true;
		else
			MDIInput_script.isYSelected = false;
		if(info_array[5] == "True")
			MDIInput_script.isZSelected = true;
		else
			MDIInput_script.isZSelected = false;
		if(info_array[6] == "True")
			Main.operationBottomScrInitial = true;
		else
			Main.operationBottomScrInitial = false;
		if(info_array[7] == "True")
			Main.operationBottomScrExecute = true;
		else
			Main.operationBottomScrExecute = false;
		if(info_array[8] == "True")
			Main.runtimeIsBlink = true;
		else
			Main.runtimeIsBlink = false;
		if(info_array[9] == "True")
			Main.partsNumBlink = true;
		else
			Main.partsNumBlink = false;
		if(info_array[10] == "True")
			Main.posTimeAndNumber = true;
		else
			Main.posTimeAndNumber = false;
		Main.statusBeforeOperation = int.Parse(info_array[11]);	
		if(info_array[12] == "True")
			Main.posOperationMode = true;
		else
			Main.posOperationMode = false;
	}
	
	public void Position () {
		//绝对坐标界面
		if(Main.AbsoluteCoo)	
		{
			PosAbsoluteCoo();
		 }
		//相对坐标界面
		if(Main.RelativeCoo)
		{
			PosRelativeCoo();
		}
		//综合界面
		if(Main.GeneralCoo)
		{
			PosGeneralCoo();
		}
		//宋荣
		if(MDIInput_script.isXSelected)
		{
			xBlink=true;
			yBlink=false;
			zBlink=false;
			if(Time.time-xyzLastTime>0.5)
			{
				xDisplayFlag=!xDisplayFlag;
				xyzLastTime=Time.time;
			}
		}
		if(MDIInput_script.isYSelected)
		{
			yBlink=true;
			xBlink=false;
			zBlink=false;
			if(Time.time-xyzLastTime>0.5)
			{
				yDisplayFlag=!yDisplayFlag;
				xyzLastTime=Time.time;
			}
		}
		if(MDIInput_script.isZSelected)
		{
			zBlink=true;
			xBlink=false;
			yBlink=false;
			if(Time.time-xyzLastTime>0.5)
			{
				zDisplayFlag=!zDisplayFlag;
				xyzLastTime=Time.time;
			}
		}
		if(Main.operationBottomScrInitial)
		{
			ShowOperationScreen();	
		}
		if(Main.operationBottomScrExecute)
		{
			ShowOperationScreen();
			if(Main.runtimeIsBlink||Main.partsNumBlink)
			{
				if(Time.time-lastTime>0.5)
				{
					displayFlag=!displayFlag;
				    lastTime=Time.time;
				}
			}
		}
		
		//位置界面下方公共区域显示控制
		PosBottomScreen();
		//宋荣
		//显示相对坐标或综合坐标下打印区域x或y或z
		//PrintAreaXYZ();
		//宋荣
	}
	
	void PrintAreaXYZ()
	{
		if(Main.operationBottomScrInitial&&xBlink&&xDisplayFlag)
		{
		     GUI.Label(new Rect(100f/1000f*Main.width,345f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X",Main.sty_BottomAST);
			// Debug.Log("打印X");
		}
		if(Main.operationBottomScrInitial&&yBlink&&yDisplayFlag)
		{
			GUI.Label(new Rect(100,346f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y",Main.sty_BottomAST);
			//Debug.Log("打印Y");
		}
		if(Main.operationBottomScrInitial&&zBlink&&zDisplayFlag)
		{
			GUI.Label(new Rect(100,346f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z",Main.sty_BottomAST);
			//Debug.Log("打印Z");
		}
	}
	//宋荣
	
	//宋荣
	
	void ShowOperationScreen()
	{
		if(Main.operationBottomScrInitial)
		{
			if(Main.statusBeforeOperation==2||Main.statusBeforeOperation==3)
			{
				GUI.Label(new Rect((Main.corner_px + 42f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"预 置", Main.sty_BottomChooseMenu);
				GUI.Label(new Rect((Main.corner_px + 135f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"归 零", Main.sty_BottomChooseMenu);
			}
			else
	    			GUI.Label(new Rect((Main.corner_px + 34f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"W预 置", Main.sty_BottomChooseMenu);
	    	GUI.Label(new Rect((Main.corner_px + 309f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"件数:0", Main.sty_BottomChooseMenu);
         	GUI.Label(new Rect((Main.corner_px + 400f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"时间:0", Main.sty_BottomChooseMenu);
	    	GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
		}
		else if(Main.operationBottomScrExecute)
		{
			if(Main.posTimeAndNumber == false)
				GUI.Label(new Rect((Main.corner_px + 127f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"所有轴", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 408f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"执 行", Main.sty_BottomChooseMenu);
		}
		//GUI.Label(new Rect(40f/1000f*Main.width,422f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_BottomButtonSmallest);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
	    	Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
        	Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
	    	Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
	   	Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		if(Main.statusBeforeOperation==1)
		{
			GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"绝对坐标", Main.sty_Title);
			if((xBlink&&xDisplayFlag)||!MDIInput_script.isXSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.x), Main.sty_BigXYZ);
			if((yBlink&&yDisplayFlag)||!MDIInput_script.isYSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.y), Main.sty_BigXYZ);
			if((zBlink&&zDisplayFlag)||!MDIInput_script.isZSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.CooStringFormat(Main.absolute_pos.z), Main.sty_BigXYZ);
		}
		if(Main.statusBeforeOperation==2)
		{
			GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"相对坐标", Main.sty_Title);
			if((xBlink&&xDisplayFlag)||!MDIInput_script.isXSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.x), Main.sty_BigXYZ);
			if((yBlink&&yDisplayFlag)||!MDIInput_script.isYSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.y), Main.sty_BigXYZ);
			if((zBlink&&zDisplayFlag)||!MDIInput_script.isZSelected)
				GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
			GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.CooStringFormat(Main.relative_pos.z), Main.sty_BigXYZ);
		}
		if(Main.statusBeforeOperation==3)
		{
			GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"综合显示", Main.sty_Title);
			GUI.Label(new Rect((Main.corner_px+65f)/1000f*Main.width,(Main.corner_py+20f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"相对坐标", Main.sty_PosSmallWord);
			if((xBlink&&xDisplayFlag)||!MDIInput_script.isXSelected)
				GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,500f/1000f*Main.width,100f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.x), Main.sty_SmallNum);
			if((yBlink&&yDisplayFlag)||!MDIInput_script.isYSelected)
				GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.y), Main.sty_SmallNum);
			if((zBlink&&zDisplayFlag)||!MDIInput_script.isZSelected)
				GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.z), Main.sty_SmallNum);
	
			GUI.Label(new Rect((Main.corner_px+310f)/1000f*Main.width,(Main.corner_py+20f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"绝对坐标", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,500f/1000f*Main.width,100f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.z), Main.sty_SmallNum);
				
			GUI.Label(new Rect((Main.corner_px+65f)/1000f*Main.width,(Main.corner_py + 115f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"机械坐标", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.z), Main.sty_SmallNum);
					
					
			GUI.Label(new Rect((Main.corner_px+310f)/1000f*Main.width,(Main.corner_py + 115f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "剩余移动量", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_z), Main.sty_SmallNum);
		}
	}
	//宋荣
	
	//绝对坐标界面显示控制
	void PosAbsoluteCoo() 
	{
		GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"绝对坐标", Main.sty_Title);
//		GUI.Label(new Rect(40f/1000f*Main.width,422f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_BottomButtonSmallest);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 226f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 314f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);		
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.x), Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.y), Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.CooStringFormat(Main.absolute_pos.z), Main.sty_BigXYZ);
	}
	
	//相对坐标界面显示控制
	void PosRelativeCoo () 
	{
		GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"相对坐标", Main.sty_Title);
//		GUI.Label(new Rect(40f/1000f*Main.width,422f/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_BottomButtonSmallest);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 226f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 314f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 33f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.x), Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.y), Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_BigXYZ);
		GUI.Label(new Rect((Main.corner_px + 72f)/1000f*Main.width,(Main.corner_py + 133f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.CooStringFormat(Main.relative_pos.z), Main.sty_BigXYZ);
	}
	
	//综合界面显示控制
	void PosGeneralCoo() 
	{
		GUI.Label(new Rect((Main.corner_px + 6f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"综合显示", Main.sty_Title);
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		
		GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 226f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"综 合", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 314f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"手 轮", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		
		GUI.Label(new Rect((Main.corner_px+65f)/1000f*Main.width,(Main.corner_py+20f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"相对坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,500f/1000f*Main.width,100f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.x), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.y), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.z), Main.sty_SmallNum);

		GUI.Label(new Rect((Main.corner_px+310f)/1000f*Main.width,(Main.corner_py+20f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"绝对坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+42f)/1000f*Main.height,500f/1000f*Main.width,100f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.x), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+66f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.y), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py+90f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.z), Main.sty_SmallNum);
			
		GUI.Label(new Rect((Main.corner_px+65f)/1000f*Main.width,(Main.corner_py + 115f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"机械坐标", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.x), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.y), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+25f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+55f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.MachineCoo.z), Main.sty_SmallNum);
				
				
		GUI.Label(new Rect((Main.corner_px+310f)/1000f*Main.width,(Main.corner_py + 115f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "剩余移动量", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "X", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 138f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_x), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "Y", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 163f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_y), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px+268f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "Z", Main.sty_SmallXYZ);
		GUI.Label(new Rect((Main.corner_px+298f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_z), Main.sty_SmallNum);
	}
	
	//位置界面下方公共区域显示控制
	void PosBottomScreen()
	{
		//宋荣
		//if(Main.partsNumBlink)
			//Debug.Log("parttimeblink is true");
	    if((Main.partsNumBlink&&displayFlag)||!Main.partsNumBlink)
			GUI.Label(new Rect((Main.corner_px + 258f)/1000f*Main.width,(Main.corner_py +222f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"加工零件数", Main.sty_MostWords);
		//宋荣
		GUI.Label(new Rect((Main.corner_px + 420f)/1000f*Main.width,(Main.corner_py +223f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.PartsNum), Main.sty_SmallNum);
		//宋荣
		//if(Main.runtimeIsBlink)
		//	Debug.Log("runtimeIsBlink is true");
		if((Main.runtimeIsBlink&&displayFlag)||!Main.runtimeIsBlink)
		   GUI.Label(new Rect((Main.corner_px + 1f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"运行时间", Main.sty_MostWords);
	    //宋荣
		GUI.Label(new Rect((Main.corner_px + 162f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 209f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"M", Main.sty_MostWords);
		
		GUI.Label(new Rect((Main.corner_px + 85f)/1000f*Main.width,(Main.corner_py +242f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.RunningTimeH), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 135f)/1000f*Main.width,(Main.corner_py +242f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.RunningTimeM), Main.sty_SmallNum);
		
		GUI.Label(new Rect((Main.corner_px + 258f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"循环时间", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 394f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"H", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 434f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"M", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 480f)/1000f*Main.width,(Main.corner_py +241f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"S", Main.sty_MostWords);
		
		GUI.Label(new Rect((Main.corner_px + 323f)/1000f*Main.width,(Main.corner_py +242f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeH), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 363f)/1000f*Main.width,(Main.corner_py +242f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeM), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 408f)/1000f*Main.width,(Main.corner_py +242f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.CycleTimeS), Main.sty_SmallNum);
		
		GUI.Label(new Rect((Main.corner_px + 1f)/1000f*Main.width,(Main.corner_py +260f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"实速度            MM/MIN", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 65f)/1000f*Main.width,(Main.corner_py +262f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 268f)/1000f*Main.width,(Main.corner_py +260f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height),"SACT                /分", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py +262f)/1000f*Main.height,200f/1000f*Main.width,100f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
