using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ProgramModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	SoftkeyModule Softkey_Script;
	MDIEditModule MDIEdit_Script;
	public string[] ModeState=new string[24];//内容--定义string数组ModeState，用于存放模态代码，姓名--刘旋，时间2013-4-23
	public string[] temp_ModeState=new string[24];//内容--定义string数组temp-ModeState，用于存放新的模态代码，姓名--刘旋，时间2013-4-23
	public float ModeCursorH=0;//内容--模态的水平坐标，用于模态代码的显示位置和蓝色光标的显示位置，姓名--刘旋，时间2013-4-23
	public float ModeCursorV=0;//内容--模态的垂直坐标，用于模态代码的显示位置和蓝色光标的显示位置，姓名--刘旋，时间2013-4-23
	public bool[] light_flag=new bool[24];//内容--模态的状态，ModeState与temp-ModeState进行比较，模态代码有变动时，相应的模态的状态为真，姓名--刘旋，时间2013-4-23
	public List<int> lightup_list=new List<int>();//内容--用于存放有变动的模态的编号，姓名--刘旋，时间2013-4-23
	public int para_det;//内容--1表示当前段，0表示检测（包括绝对和相对），姓名--刘旋，时间2013-4-23
	public List<string> G_code=new List<string>(); // 当前段G代码显示
    public List<string> G_address=new List<string>(); //当前段地址值显示
	public List<float> G_instructValue=new List<float>(); //当前段值大小显示
	public List<string> G_code2=new List<string>(); //下一段G代码显示
    public List<string> G_address2=new List<string>(); //下一段地址值显示
	public List<float> G_instructValue2=new List<float>(); //下一段值大小显示
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		for(int i=0;i<24;i++)
			light_flag[i]=false;//内容--模态的状态，初始化为假，姓名--刘旋，时间2013-4-23
		//内容--模态代码的初始化，当前段中，第一列编号为0-11，第二列编号为12-23，姓名--刘旋，时间2013-4-23
		ModeState[0]="G00";ModeState[1]="G17";ModeState[2]="G90";ModeState[3]="G22";
		ModeState[4]="G94";ModeState[5]="G21";ModeState[6]="G40";ModeState[7]="G49";
		ModeState[8]="G80";ModeState[9]="G98";ModeState[10]="G50";ModeState[11]="G67";
		ModeState[12]="G97";ModeState[13]="G54";ModeState[14]="G64";ModeState[15]="G69";
		ModeState[16]="G15";ModeState[17]="G40.1";ModeState[18]="G25";ModeState[19]="G160";
		ModeState[20]="G13.1";ModeState[21]="G50.1";ModeState[22]="G54.2";ModeState[23]="G80.5";
		//内容--新模态代码的初始化，初始化为当前模态代码，姓名--刘旋，时间2013-4-23
		for(int i=0;i<24;i++)
			temp_ModeState[i]=ModeState[i];
		//陈晓威 董帅
		Softkey_Script=gameObject.GetComponent<SoftkeyModule>();
		Main.SeparatePosStart = new List<int>();
		Main.SeparatePosEnd = new List<int>();
		Main.SeparateAutoStart = new List<int>();
		Main.SeparateAutoEnd = new List<int>();
		Main.SeparateMDIStart = new List<int>();
		Main.SeparateMDIEnd = new List<int>();
////	Main.CodeForAll.Add(";");
//		Main.CodeForMDI.Add("O0000");
//		Main.CodeForMDI.Add(";");
		Main.ProgEDITCusorH=0;
		Main.ProgEDITCusorV=0;
		Main.SelectStart = 0;
		Main.SelectEnd = 0;
		Main.StartRow = 0;
		Main.EndRow = SystemArguments.EditLineNumber;
//		//初始化G代码、地址和指令值，刘旋，2013-5-21
//		G_code.Add("G90");G_code.Add("G30");G_code.Add("G00");G_code.Add("G54");
//		G_address.Add("X");G_address.Add("I");G_address.Add("K");G_address.Add("R");
//		G_instructValue.Add(-555538f);G_instructValue.Add(5962f);G_instructValue.Add(405f);//数值要求-9999-9999
//		
//		G_code2.Add("G90");G_code2.Add("G30");G_code2.Add("G00");G_code2.Add("G54");
//		G_address2.Add("X");G_address2.Add("I");G_address2.Add("K");G_address2.Add("R");
//		G_instructValue2.Add(-555538f);G_instructValue2.Add(5962f);G_instructValue2.Add(405f);//数值要求-9999-9999
	}
	
	void OnGUI()
	{
//		if(GUI.Button(new Rect(200f,100f,100f,60f),"模态改变"))
//		{
//			/*
//			//内容--新模态代码中，设定几个与当前模态代码不同，用于验证程序的正确性，姓名--刘旋，时间2013-4-23
//		    temp_ModeState[0]="G80";temp_ModeState[8]="G30";temp_ModeState[16]="G90";temp_ModeState[10]="G70";temp_ModeState[18]="G60";
//			SetBlueCursorState();
//			*/
//			List<int> index = new List<int>();
//			List<string> string_list = new List<string>();
//			index.Add(0); index.Add(12); index.Add(1);index.Add(5);index.Add(9);index.Add(20);
//			string_list.Add("G11");string_list.Add("G05");string_list.Add("G12");string_list.Add("G14");string_list.Add("G16");string_list.Add("G18");
//			SetModalState(index, string_list);
//		}
	}
	
	public void Program () 
	{
		//编辑窗口
		if(Main.ProgEDIT)
		{
			//程序
			if(Main.ProgEDITProg)
			{
				ProgEDITWindow();
			}
			//列表
			if(Main.ProgEDITList)
			{
				ProgEDITListWindow();
			}	
		}
		//自动运行
		if(Main.ProgAUTO)
		{
			ProgAUTOWindow();
		}
		//JOG或者REF
		if(Main.ProgJOG || Main.ProgREF)
		{
			ProgShared();
		}
		//内容--MDI模式，姓名--刘旋，时间--2013-4-22
		if(Main.ProgMDI)
		{
			ProgMDIWindow();
		}
		//内容--DNC模式，姓名--刘旋，时间--2013-4-22
		if(Main.ProgDNC)
		{
			ProgDNCWindow();
		}
		//内容--Handle模式，姓名--刘旋，时间--2013-4-22
		if(Main.ProgHAN)
		{
			ProgHANWindow();
		}
	}
	
	[RPC]
	void ProgramRPC(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			Main.ProgEDIT = true;
		else
			Main.ProgEDIT = false;
		if(info_array[1] == "True")
			Main.ProgEDITProg = true;
		else
			Main.ProgEDITProg = false;
		if(info_array[2] == "True")
			Main.ProgEDITList = true;
		else
			Main.ProgEDITList = false;
		if(info_array[3] == "True")
			Main.ProgAUTO = true;
		else
			Main.ProgAUTO = false;
		if(info_array[4] == "True")
			Main.ProgMDI = true;
		else
			Main.ProgMDI = false;
		if(info_array[5] == "True")
			Main.ProgJOG = true;
		else
			Main.ProgJOG = false;
		if(info_array[6] == "True")
			Main.ProgREF = true;
		else
			Main.ProgREF = false;
		if(info_array[7] == "True")
			Main.ProgDNC = true;
		else
			Main.ProgDNC = false;
		if(info_array[8] == "True")
			Main.ProgHAN = true;
		else
			Main.ProgHAN = false;
		Main.ProgHANFlip = int.Parse(info_array[9]);
		Main.ProgDNCFlip = int.Parse(info_array[10]);
		Main.ProgSharedFlip = int.Parse(info_array[11]);
		Main.ProgEDITFlip = int.Parse(info_array[12]);
		Main.ProgAUTOFlip = int.Parse(info_array[13]);
		Main.ProgMDIFlip = int.Parse(info_array[14]);
	}
	[RPC]
	void ProgramEDITRPC(string info)
	{
		string[] info_array = info.Split(',');
		Main.ProgramNum = int.Parse(info_array[0]);
		Main.ProgEDITCusor = float.Parse(info_array[1]);
		Main.ProgEDITCusorH = int.Parse(info_array[2]);
		Main.ProgEDITCusorV = int.Parse(info_array[3]);
		Main.SelectStart = int.Parse(info_array[4]);
		Main.SelectEnd = int.Parse(info_array[5]);
		if(info_array[6] == "True")
			Main.IsSelect = true;
		else
			Main.IsSelect = false;
		if(info_array[7] == "True")
			Main.editDisplay = true;
		else
			Main.editDisplay = false;
		Main.total_row = int.Parse(info_array[8]);
		if(info_array[9] == "True")
			Main.isSelecFirst = true;
		else
			Main.isSelecFirst = false;
		Main.ProgEDITCusorPos = float.Parse(info_array[10]);
		Main.InputTextPos = float.Parse(info_array[11]);
		Main.StartRow = int.Parse(info_array[12]);
		Main.EndRow = int.Parse(info_array[13]);
		if(info_array[14] == "True")
			Main.NotFoundWarn = true;
		else
			Main.NotFoundWarn = false;
		Main.TotalCodeNum = int.Parse(info_array[15]);
		Main.RealCodeNum = int.Parse(info_array[16]);
		Main.HorizontalNum = int.Parse(info_array[17]);
		Main.VerticalNum = int.Parse(info_array[18]);
		if(info_array[19] == "True")
			Main.ShiftFlag = true;
		else
			Main.ShiftFlag = false;
		Main.at_position = int.Parse(info_array[20]);
		Main.at_page_number = int.Parse(info_array[21]);
	}
	[RPC]
	void ProgramMDIRPC(string info)
	{
		string[] info_array = info.Split(',');
		Main.MDIProgEDITCusorH = int.Parse(info_array[0]);
		Main.MDIProgEDITCusorV = int.Parse(info_array[1]);
		Main.MDISelectStart = int.Parse(info_array[2]);
		Main.MDISelectEnd = int.Parse(info_array[3]);
		Main.mdi_total_row = int.Parse(info_array[4]);
		Main.MDIBeginRow = int.Parse(info_array[5]);
		Main.MDIStopRow = int.Parse(info_array[6]);
		Main.MDIStartRow = int.Parse(info_array[7]);
		Main.MDIEndRow = int.Parse(info_array[8]);
		Main.MDIStartRowC = int.Parse(info_array[9]);
		Main.MDIEndRowC = int.Parse(info_array[10]);
		Main.MDISelectedRow = int.Parse(info_array[11]);
		if(info_array[12] == "True")
			Main.MDI_RunningFlag = true;
		else
			Main.MDI_RunningFlag = false;
		if(info_array[13] == "True")
			Main.MDI_PauseFlag = true;
		else
			Main.MDI_PauseFlag = false;
	}
	[RPC]
	void ProgramAUTORPC(string info)
	{
		string[] info_array = info.Split(',');
		Main.auto_total_row = int.Parse(info_array[0]);
		Main.AutoBeginRow = int.Parse(info_array[1]);
		Main.AutoStopRow = int.Parse(info_array[2]);
		Main.AUTOStartRow = int.Parse(info_array[3]);
		Main.AUTOEndRow = int.Parse(info_array[4]);
		if(info_array[5] == "True")
			Main.autoDisplayNormal = true;
		else
			Main.autoDisplayNormal = false;
		Main.autoSelecedProgRow = int.Parse(info_array[6]); 
		if(info_array[7] == "True")
			Main.AutoRunning_flag = true;
		else
			Main.AutoRunning_flag = false;
		if(info_array[8] == "True")
			Main.AutoPause_flag = true;
		else
			Main.AutoPause_flag = false;
		if(info_array[9] == "True")
			Main.Current_F_value = true;
		else
			Main.Current_F_value = false;
		if(info_array[10] == "True")
			Main.Current_S_value = true;
		else
			Main.Current_S_value = false;
		if(info_array[11] == "True")
			Main.Current_T_value = true;
		else
			Main.Current_T_value = false;
		if(info_array[12] == "True")
			Main.Current_H_value = true;
		else
			Main.Current_H_value = false;
		if(info_array[13] == "True")
			Main.Current_D_value = true;
		else
			Main.Current_D_value = false;
		if(info_array[14] == "True")
			Main.Current_M_value = true;
		else
			Main.Current_M_value = false;
		Main.RunningSpeed = int.Parse(info_array[15]);
		Main.InputText = info_array[16];
	}
	
	//编辑窗口
	void ProgEDITWindow () 
	{
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 30f)/1000f*Main.height,465f/1000f*Main.width,22f/1000f*Main.height),"", Main.sty_EDITLabel);
		GUI.Label(new Rect((Main.corner_px + 5.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O", Main.sty_ProgEDITWindowFG);
		GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 29f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.ToolNumFormat(Main.ProgramNum), Main.sty_ProgEditProgNum);
		GUI.Label(new Rect((Main.corner_px + 341.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（FG:编辑）", Main.sty_ProgEDITWindowFG);	
		GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 53f)/1000f*Main.height,468f/1000f*Main.width,227f/1000f*Main.height),"", Main.sty_EDITLabelWindow);
		GUI.Label(new Rect((Main.corner_px + 472f)/1000f*Main.width,(Main.corner_py + 54f)/1000f*Main.height,23f/1000f*Main.width,23f/1000f*Main.height),"", Main.sty_EDITLabelBar_1);
		GUI.Label(new Rect((Main.corner_px + 472f)/1000f*Main.width,(Main.corner_py + 77f)/1000f*Main.height,23f/1000f*Main.width,181f/1000f*Main.height),"", Main.sty_EDITLabelBar_2);
		GUI.Label(new Rect((Main.corner_px + 472f)/1000f*Main.width,(Main.corner_py + 258f)/1000f*Main.height,23f/1000f*Main.width,23f/1000f*Main.height),"", Main.sty_EDITLabelBar_3);
		//董帅
		float pos_y = Main.corner_py + 55f;
		float pos_x = Main.corner_px + 7f; 
//		string test_word = "?";
//		Debug.Log(Main.sty_EDITTextField.CalcSize(new GUIContent(test_word)).x);
//		GUI.Label(new Rect((Main.corner_px + 7f)/1000f*Main.width, (Main.corner_py + 55f)/1000f*Main.height, 345f, 25f/1000f*Main.height+0.8f), test_word, Main.sty_EDITCursor);
//		GUI.Label(new Rect((Main.corner_px + 7f )/1000f*Main.width + 12f, (Main.corner_py + 55f)/1000f*Main.height, 12f, 25f/1000f*Main.height+0.8f), "", Main.sty_EDITCursor);
//		GUI.Label(new Rect((Main.corner_px + 7f )/1000f*Main.width, (Main.corner_py + 55f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "AB", Main.sty_Code);
		
		DisplayProgram(pos_x, pos_y);
		if(Main.ProgEDITFlip == 0)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程 序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"列 表", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 1)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"BG编辑", Main.sty_BottomChooseMenu);//内容--将“后台”改为“BG”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 128f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 221f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↓", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 310f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"返回", Main.sty_BottomChooseMenu);//内容--将“REWIND”改为“返回”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 2)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 44f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"选 择", Main.sty_BottomChooseMenu);//内容--将“F检索”改为“选择”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 127f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"全选择", Main.sty_BottomChooseMenu);//内容--将“READ”改为“全选择”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 407f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"粘 贴", Main.sty_BottomChooseMenu);//内容--将“EX-EDT”改为“粘贴”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 3)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"取消", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 129f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"~最后", Main.sty_BottomChooseMenu);//内容--将“C-EXT”改为“~最后”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"复制", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 316f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"切取", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"粘贴", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		
		else if(Main.ProgEDITFlip == 4)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"替换", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 5)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"取消", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"复制", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 316f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"切取", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"粘贴", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
			
		}else if(Main.ProgEDITFlip == 50)//到~后显示的画面
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"取消", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"复制", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 316f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"切取", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"粘贴", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
			
		}
		
		else if(Main.ProgEDITFlip == 6)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"替换", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 7)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 25f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"BUF执行", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 113f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"指定PRG", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}//增加内容到此
		else if(Main.ProgEDITFlip==8)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 47f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"之前", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 136f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"之后", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"跳跃", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 305f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"1-执行", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 400f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"全执行", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}	
	}
	
	//编辑界面程序列表
	void ProgEDITListWindow () 
	{
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序列表", Main.sty_Title);
		
		GUI.Label(new Rect((Main.corner_px + 60f)/1000f*Main.width,(Main.corner_py + 26f)/1000f*Main.height,420f/1000f*Main.width,57f/1000f*Main.height),"", Main.sty_ListContent);
		GUI.Label(new Rect((Main.corner_px + 200f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"程序数", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 340f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"内存(KBYTE)", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 80f)/1000f*Main.width,(Main.corner_py + 38f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"已用：", Main.sty_MostWords);	
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 43f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUsedNum), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect((Main.corner_px + 400f)/1000f*Main.width,(Main.corner_py + 43f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUsedSpace), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect((Main.corner_px + 80f)/1000f*Main.width,(Main.corner_py + 58f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"空区：", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 61f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUnusedNum), Main.sty_ProgEDITListWindowNum);
		GUI.Label(new Rect((Main.corner_px + 400f)/1000f*Main.width,(Main.corner_py + 61f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.ProgUnusedSpace), Main.sty_ProgEDITListWindowNum);
		
		GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 83f)/1000f*Main.height,490f/1000f*Main.width,201f/1000f*Main.height),"", Main.sty_ListWindow);
		GUI.Label(new Rect((Main.corner_px + 5.5f)/1000f*Main.width,(Main.corner_py + 86f)/1000f*Main.height,485f/1000f*Main.width,20f/1000f*Main.height),"", Main.sty_EDITLabel);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 82f)/1000f*Main.height,484f/1000f*Main.width,25f/1000f*Main.height),"设备：CNC_MEM", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"O号码", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 136.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"容量(KBYTE)", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 350.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height),"更新时间", Main.sty_MostWords);
		
		if(Main.ProgEDITAt)
			GUI.Label(new Rect((Main.corner_px + 14.5f)/1000f*Main.width, Main.ProgEDITCusor/1000f*Main.height,484f/1000f*Main.width,30f/1000f*Main.height),"@", Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 123f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[0], Main.sty_ClockStyle);
		if(Main.CodeName[0] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 123f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[0]), Main.sty_ClockStyle);			
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 123f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[0], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 142f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[1], Main.sty_ClockStyle);
		if(Main.CodeName[1] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 142f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[1]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 142f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[1], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 162f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[2], Main.sty_ClockStyle);
		if(Main.CodeName[2] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 162f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[2]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 162f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[2], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 182f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[3], Main.sty_ClockStyle);
		if(Main.CodeName[3] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 182f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[3]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 182f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[3], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 202f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[4], Main.sty_ClockStyle);
		if(Main.CodeName[4] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 202f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[4]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 202f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[4], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[5], Main.sty_ClockStyle);
		if(Main.CodeName[5] != "")	
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[5]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[5], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[6], Main.sty_ClockStyle);
		if(Main.CodeName[6] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[6]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[6], Main.sty_ClockStyle);
		
		GUI.Label(new Rect((Main.corner_px + 34.5f)/1000f*Main.width,(Main.corner_py + 262f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.CodeName[7], Main.sty_ClockStyle);
		if(Main.CodeName[7] != "")
			GUI.Label(new Rect((Main.corner_px + 166.5f)/1000f*Main.width,(Main.corner_py + 262f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.NumberFormat(Main.CodeSize[7]), Main.sty_ClockStyle);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 262f)/1000f*Main.height,490f/1000f*Main.width,65f/1000f*Main.height), Main.UpdateDate[7], Main.sty_ClockStyle);
		
		if(Main.ProgEDITFlip == 0)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程 序", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"列 表", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 1)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"BG编辑", Main.sty_BottomChooseMenu);//内容--将“后台”改为“BG”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 128f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 221f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↓", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 310f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检索↑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"返回", Main.sty_BottomChooseMenu);//内容--将“REWIND”改为“返回”，姓名--刘旋，日期--2013-3-14
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);	
		}
		else if(Main.ProgEDITFlip == 2)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"F检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 128f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"READ", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 221f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"PUNCH", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 310f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"DELETE", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"EX-EDT", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgEDITFlip == 3)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"C-EXT", Main.sty_BottomChooseMenu);
		}
	} 

	//AUTO模式下的程序界面
	void ProgAUTOWindow () 
	{
		if (Main.ProgAUTOFlip==0)
		{
			ProgramInterface();
			GUI.Label(new Rect((Main.corner_px + 137f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检测", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect((Main.corner_px + 4f)/1000f*Main.width, (Main.corner_py + 47f)/1000f*Main.height, 370f, 25f/1000f*Main.height), "", Main.TestGUIStyle);
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		else if (Main.ProgAUTOFlip==1)
		{
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
			GUI.Label(new Rect((Main.corner_px + 3f)/1000f*Main.width,(Main.corner_py + 46f)/1000f*Main.height,490f/1000f*Main.width,230f/1000f*Main.height),"", Main.sty_ProgSharedWindow);
			
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"BG编辑", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 128f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"O检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 221f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"N检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"返回", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
			
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		else if (Main.ProgAUTOFlip==2)
		{
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序（检查）", Main.sty_Title);
		    GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,499f/1000f*Main.width,105f/1000f*Main.height),"", Main.sty_AUTOCheck);
			GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,160f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
			GUI.Label(new Rect((Main.corner_px + 160f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,144f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 126f)/1000f*Main.height,100f/1000f*Main.width,300f/1000f*Main.height),"绝对坐标", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.absolute_pos.z), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 183f)/1000f*Main.width,(Main.corner_py + 126f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"剩余移动量", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_z), Main.sty_SmallNum);
			para_det=2;
			BlueCursorState();//内容--蓝色光标显示，模态改变的位置上显示蓝色光标，姓名--刘旋，时间2013-4-23
			//内容--“检测”界面下，模态代码的显示，12个模态代码显示为4行3列，用ModeCursorH和ModeCursorV决定具体显示的坐标，姓名--刘旋，时间2013-4-23
			for(int i=0;i<12;i++)
			{
				ModeCursorH=(Main.corner_px + 306.5f+(i/4)*62f)/1000f*Main.width;
				ModeCursorV=((Main.corner_py + 128f)+(i%4)*24f)/1000f*Main.height;
				GUI.Label(new Rect(ModeCursorH,ModeCursorV,500f/1000f*Main.width,300f/1000f*Main.height),ModeState[i], Main.sty_ModeCode);   
			}			
		    GUI.Label(new Rect((Main.corner_px + 306.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_Mode);
			if(Main.Current_H_value)
				GUI.Label(new Rect((Main.corner_px + 286.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.H_value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 371f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"M", Main.sty_Mode);
		   	if(Main.Current_M_value)
				GUI.Label(new Rect((Main.corner_px + 351f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.M_value), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"T", Main.sty_Mode);
			if(Main.Current_T_value)
				GUI.Label(new Rect((Main.corner_px + 68.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.ToolNumFormat(Main.T_Value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 306.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"D", Main.sty_Mode);
			if(Main.Current_D_value)
				GUI.Label(new Rect((Main.corner_px + 286.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.D_value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"F", Main.sty_Mode);
			if(Main.Current_F_value)
				GUI.Label(new Rect((Main.corner_px + 41.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 176.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"S", Main.sty_Mode);
			if(Main.Current_S_value)
				GUI.Label(new Rect((Main.corner_px + 211.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
//		    GUI.Label(new Rect(40f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"实速度         MM/MIN", Main.sty_MostWords);
//		    GUI.Label(new Rect(133f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
//		    GUI.Label(new Rect(310f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SACT         /分", Main.sty_MostWords);
//		    GUI.Label(new Rect(380f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
		    Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
		    Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		    Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		    Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		    Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		    GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = false;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,false);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 28f);
			}
		}
		else if (Main.ProgAUTOFlip==3)
		{
			CurrentParagraph();
			GUI.Label(new Rect((Main.corner_px + 137f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检测", Main.sty_BottomChooseMenu);
		}
		else if(Main.ProgAUTOFlip==4)
		{
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序（检查）", Main.sty_Title);
		    GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,500f/1000f*Main.width,105f/1000f*Main.height),"", Main.sty_AUTOCheck);
			GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,160f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
			GUI.Label(new Rect((Main.corner_px + 160f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,144f/1000f*Main.width,113f/1000f*Main.height),"", Main.sty_EDITList);
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 126f)/1000f*Main.height,100f/1000f*Main.width,300f/1000f*Main.height),"相对坐标", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 2.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_SmallXYZ);
			GUI.Label(new Rect((Main.corner_px + 26.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.relative_pos.z), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 183f)/1000f*Main.width,(Main.corner_py + 126f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"剩余移动量", Main.sty_PosSmallWord);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 147f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 167f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 171f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(Main.remaining_z), Main.sty_SmallNum);
			para_det=2;
			BlueCursorState();//内容--蓝色光标的显示，在模态改变的位置上显示蓝色光标，姓名--刘旋，时间--2013-4-23
			//内容--“检测”界面下，模态代码的显示，12个模态代码显示为4行3列，用ModeCursorH和ModeCursorV决定具体显示的坐标，姓名--刘旋，时间2013-4-23
			for(int i=0;i<12;i++)
			{
				ModeCursorH=(Main.corner_px + 306.5f+(i/4)*62f)/1000f*Main.width;
				ModeCursorV=((Main.corner_py + 128f)+(i%4)*24f)/1000f*Main.height;
				GUI.Label(new Rect(ModeCursorH,ModeCursorV,500f/1000f*Main.width,300f/1000f*Main.height),ModeState[i], Main.sty_ModeCode);   
			}			
		    GUI.Label(new Rect((Main.corner_px + 306.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"H", Main.sty_Mode);
			if(Main.Current_H_value)
				GUI.Label(new Rect((Main.corner_px + 286.5f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.H_value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 371f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"M", Main.sty_Mode);
		   	if(Main.Current_M_value)
				GUI.Label(new Rect((Main.corner_px + 351f)/1000f*Main.width,(Main.corner_py + 222f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.M_value), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"T", Main.sty_Mode);
			if(Main.Current_T_value)
				GUI.Label(new Rect((Main.corner_px + 68.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.ToolNumFormat(Main.T_Value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 306.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"D", Main.sty_Mode);
			if(Main.Current_D_value)
				GUI.Label(new Rect((Main.corner_px + 286.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.D_value), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"F", Main.sty_Mode);
			if(Main.Current_F_value)
				GUI.Label(new Rect((Main.corner_px + 41.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		    GUI.Label(new Rect((Main.corner_px + 176.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"S", Main.sty_Mode);
			if(Main.Current_S_value)
				GUI.Label(new Rect((Main.corner_px + 211.5f)/1000f*Main.width,(Main.corner_py + 261f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
//		    GUI.Label(new Rect(40f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"实速度         MM/MIN", Main.sty_MostWords);
//		    GUI.Label(new Rect(133f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
//		    GUI.Label(new Rect(310f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SACT         /分", Main.sty_MostWords);
//		    GUI.Label(new Rect(380f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
		    Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		    Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;	
		    Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		    Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		    Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"绝 对", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"相 对", Main.sty_BottomChooseMenu);
		    GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = false;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,false);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 28f);
			}
		}
		else if(Main.ProgAUTOFlip==5)
		{
			NextParagraph();
			GUI.Label(new Rect((Main.corner_px + 137f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"检测", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
	}
	
	//显示Handle、Jog、Ref模式下的程序界面
	void ProgShared () 
	{
		if(Main.ProgSharedFlip==0)
		{
			ProgramInterface();
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		if(Main.ProgSharedFlip==1)
		{
			CurrentParagraph();
		}
		if(Main.ProgSharedFlip==2)
		{
			NextParagraph();
		}
	}
	
	void ProgMDIWindow()
	{
		if(Main.ProgMDIFlip==0)
		{
			ModeEditInterface();
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序（MDI）", Main.sty_Title);
			GUI.Label(new Rect((Main.corner_px + 134f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"MDI", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect((Main.corner_px + 7f)/1000f*Main.width, (Main.corner_py + 55f)/1000f*Main.height, 345f, 25f/1000f*Main.height+0.8f), "", Main.TestGUIStyle);
			if(Main.MDI_RunningFlag)  //MDI运行界面
			{
				float pos_y = Main.corner_py + 40f;
				float pos_x = Main.corner_px + 10f; 
				Main.MDIDisplayFindRows(Main.MDISelectedRow);
				MDIDisplyProgram(pos_x, pos_y);
			}
			else  //MDI编辑界面
			{
				float pos_y = Main.corner_py + 40f;
				float pos_x = Main.corner_px + 10f; 
	//			Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
				DisplayProgram(pos_x, pos_y);
	//			Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
	//			AutoDisplyProgram(Main.corner_py + 47f);
				if(Main.MDIpos_flag)
				{
					Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
					Main.MDIpos_flag = false;
					MDIEdit_Script.EditProgRight();	
				}
			}
		}
		if(Main.ProgMDIFlip==1)
		{
			ProgramInterface();
			GUI.Label(new Rect((Main.corner_px + 134f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"MDI", Main.sty_BottomChooseMenu);
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		if(Main.ProgMDIFlip==2)
		{
			CurrentParagraph();
			GUI.Label(new Rect((Main.corner_px + 134f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"MDI", Main.sty_BottomChooseMenu);
		}
		if(Main.ProgMDIFlip==3)
		{
			NextParagraph();
			GUI.Label(new Rect((Main.corner_px + 134f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"MDI", Main.sty_BottomChooseMenu);
		}
	}
	
	void ProgDNCWindow()
	{
		if(Main.ProgDNCFlip==0)
		{
			ProgramInterface();
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		if(Main.ProgDNCFlip==1)
		{
			CurrentParagraph();
		}
		if(Main.ProgDNCFlip==2)
		{
			NextParagraph();
		}
	}
	
	void ProgHANWindow()
	{
		if(Main.ProgHANFlip==0)
		{
			ProgramInterface();
			if(Main.CodeForAUTO.Count > 0)
			{
				Main.autoDisplayNormal = true;
//				Main.AutoDisplayFindRows(Main.autoSelecedProgRow,true);
				AutoDisplyProgram(Main.corner_px + 7f, Main.corner_py + 47f);
			}
		}
		if(Main.ProgHANFlip==1)
		{
			CurrentParagraph();
		}
		if(Main.ProgHANFlip==2)
		{
			NextParagraph();
		}
	}
	
	void ModeEditInterface()
	{
		GUI.Label(new Rect((Main.corner_px + 4f)/1000f*Main.width, (Main.corner_py + 35f)/1000f*Main.height, 467f/1000f*Main.width, 235f/1000f*Main.height),"", Main.sty_EDITLabelWindow);
		GUI.Label(new Rect((Main.corner_px + 473f)/1000f*Main.width, (Main.corner_py + 35f)/1000f*Main.height, 23f/1000f*Main.width, 23f/1000f*Main.height),"", Main.sty_EDITLabelBar_1);
		GUI.Label(new Rect((Main.corner_px + 473f)/1000f*Main.width, (Main.corner_py + 59f)/1000f*Main.height, 23f/1000f*Main.width, 188f/1000f*Main.height),"", Main.sty_EDITLabelBar_2);
		GUI.Label(new Rect((Main.corner_px + 473f)/1000f*Main.width, (Main.corner_py + 248f)/1000f*Main.height, 23f/1000f*Main.width, 23f/1000f*Main.height),"", Main.sty_EDITLabelBar_3);
//		GUI.Label(new Rect(40f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"实速度         MM/MIN", Main.sty_MostWords);
//		GUI.Label(new Rect(133f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
//		GUI.Label(new Rect(310f/1000f*Main.width,322f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SACT         /分", Main.sty_MostWords);
//		GUI.Label(new Rect(380f/1000f*Main.width,321f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
		
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;	
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		
		GUI.Label(new Rect((Main.corner_px + 45f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 308f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);		
	}
	
	void ProgramInterface()
	{
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 3f)/1000f*Main.width,(Main.corner_py + 46f)/1000f*Main.height,490f/1000f*Main.width,230f/1000f*Main.height),"", Main.sty_ProgSharedWindow);
		
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		//GUI.Label(new Rect(44f/1000f*Main.width,423f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 45f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
//		GUI.Label(new Rect(175f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 308f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);		
	}
	
	void CurrentParagraph()
	{
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,249f/1000f*Main.width,260f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect((Main.corner_px + 251f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,248f/1000f*Main.width,260f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 25f)/1000f*Main.height,249f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_TopLabel);
		GUI.Label(new Rect((Main.corner_px + 251f)/1000f*Main.width,(Main.corner_py + 25f)/1000f*Main.height,247f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_TopLabel);
		GUI.Label(new Rect((Main.corner_px + 91f)/1000f*Main.width,(Main.corner_px + 21f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 351f)/1000f*Main.width,(Main.corner_px + 21f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"模态", Main.sty_Title);
		G_codeDisplay();
		para_det=1;
		BlueCursorState();//内容--蓝色光标的显示，在模态发生改变的位置上显示蓝色光标，姓名--刘旋，时间--2013-4-23
		//内容--“当前段”界面下，模态代码的显示，24个模态代码显示为12行2列，用ModeCursorH和ModeCursorV决定具体显示的坐标，姓名--刘旋，时间2013-4-23
		for(int i=0;i<24;i++)
		{
			ModeCursorH=(Main.corner_px + 252f +i/12*70f)/1000f*Main.width;
			ModeCursorV=(Main.corner_py + 48f +i%12*19.4f)/1000f*Main.height;
			GUI.Label(new Rect(ModeCursorH,ModeCursorV,500f/1000f*Main.width,300f/1000f*Main.height),ModeState[i], Main.sty_ModeCode);
		}
		GUI.Label(new Rect((Main.corner_px + 412.5f)/1000f*Main.width,(Main.corner_py + 48f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "F", Main.sty_Mode);
		if(Main.Current_F_value)
			GUI.Label(new Rect((Main.corner_px + 421.5f)/1000f*Main.width,(Main.corner_py + 48f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.RunningSpeed), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 412.5f)/1000f*Main.width,(Main.corner_py + 67.4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "M", Main.sty_Mode);
		if(Main.Current_M_value)
			GUI.Label(new Rect((Main.corner_px + 421.5f)/1000f*Main.width,(Main.corner_py + 67.4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.M_value), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 412.5f)/1000f*Main.width,(Main.corner_py + 125.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "H", Main.sty_Mode);
		if(Main.Current_H_value)
			GUI.Label(new Rect((Main.corner_px + 382f)/1000f*Main.width,(Main.corner_py + 125.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.H_value), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 412.5f)/1000f*Main.width,(Main.corner_py + 164.4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "T", Main.sty_Mode);
		if(Main.Current_T_value)
				GUI.Label(new Rect((Main.corner_px + 446f)/1000f*Main.width,(Main.corner_py + 164.4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),Main.ToolNumFormat(Main.T_Value), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 412.5f)/1000f*Main.width,(Main.corner_py + 222.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "S", Main.sty_Mode);
		if(Main.Current_S_value)
				GUI.Label(new Rect((Main.corner_px + 421.5f)/1000f*Main.width,(Main.corner_py + 222.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.SpindleSpeed), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 456f)/1000f*Main.width,(Main.corner_py + 125.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), "D", Main.sty_Mode);
		if(Main.Current_D_value)
			GUI.Label(new Rect((Main.corner_px + 421.5f)/1000f*Main.width,(Main.corner_py + 125.6f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.NumberFormat(Main.D_value), Main.sty_SmallNum);
		
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect((Main.corner_px + 45f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 308f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);		
	}
	
	void NextParagraph()
	{
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"程序", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,249f/1000f*Main.width,260f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect((Main.corner_px + 251f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,248f/1000f*Main.width,260f/1000f*Main.height),"", Main.sty_EDITList);
		GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 25f)/1000f*Main.height,249f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_TopLabel);
		GUI.Label(new Rect((Main.corner_px + 251f)/1000f*Main.width,(Main.corner_py + 25f)/1000f*Main.height,247f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_TopLabel);
		GUI.Label(new Rect((Main.corner_px + 91f)/1000f*Main.width,(Main.corner_px + 21f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 351f)/1000f*Main.width,(Main.corner_px + 21f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_Title);
		
		G_codeDisplay();
		G_codeDisplayNext();
		Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_d;
		Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
		GUI.Label(new Rect((Main.corner_px + 45f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"程序", Main.sty_BottomChooseMenu);
//		GUI.Label(new Rect(175f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"当前段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 308f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"下一段", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);		
	}
	
	//定义函数G-codeDisplay，用于当前段和下一段界面下“当前段”页面中G代码、地址和指令值的显示，刘旋，2013-5-21
	public void G_codeDisplay()
	{
		for(int i=0;i<G_code.Count;i++)
			GUI.Label(new Rect((Main.corner_px + 4f)/1000f*Main.width,(Main.corner_py + 52f +25f*i)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), G_code[i], Main.sty_ModeCode);
		for(int j=0;j<G_address.Count;j++)
			GUI.Label(new Rect((Main.corner_px + 75f)/1000f*Main.width,(Main.corner_py + 52f+25f*j)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),G_address[j], Main.sty_SmallXYZ);
		for(int m=0;m<G_instructValue.Count;m++)
			GUI.Label(new Rect((Main.corner_px + 107f)/1000f*Main.width,(Main.corner_py + 52f +25f*m)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(G_instructValue[m]), Main.sty_SmallNum);
	}
	
	public void G_codeDisplayNext()
	{
		for(int i=0;i<G_code2.Count;i++)
			GUI.Label(new Rect((Main.corner_px + 255f)/1000f*Main.width,(Main.corner_py + 52f +25f*i)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), G_code2[i], Main.sty_ModeCode);
		for(int j=0;j<G_address2.Count;j++)
			GUI.Label(new Rect((Main.corner_px + 326f)/1000f*Main.width,(Main.corner_py + 52f +25f*j)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),G_address2[j], Main.sty_SmallXYZ);
		for(int m=0;m<G_instructValue2.Count;m++)
			GUI.Label(new Rect((Main.corner_px + 358f)/1000f*Main.width,(Main.corner_py + 52f +25f*m)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(G_instructValue2[m]), Main.sty_SmallNum);
	}
	
	public void CurrentCodeDisplay(List<string> g_code, List<string> g_address, List<float> address_value, List<string> g_code2, List<string> g_address2, List<float> address_value2)
	{
		G_code = g_code;
		G_address = g_address;
		G_instructValue = address_value;
		G_code2 = g_code2;
		G_address2 = g_address2;
		G_instructValue2 = address_value2;
	}
	
	//内容--定义函数，设定模态的状态，当前模态代码与新的模态代码进行比较，如果不同，相应的代码编号存放在lightup-list里，并将新的模态代码赋给当前模态代码
	//利用lightup-list将light-flag里相应的模态状态为设为真
	//姓名--刘旋，时间2013-4-23
	public void SetBlueCursorState()
	{
		for(int i=0;i<24;i++)
		{
			if(ModeState[i]!=temp_ModeState[i])//内容--新模态代码与当前模态代码进行比较，姓名--刘旋，时间2013-4-23
			{
				lightup_list.Add(i);
			    ModeState[i]=temp_ModeState[i];
			}
			light_flag[i]=false;//内容--light-flag设定前，初始化为假，姓名--刘旋，时间2013-4-23
		}
		for(int i=0;i<lightup_list.Count;i++)
			light_flag[lightup_list[i]]=true;
		lightup_list.Clear();//内容--lightup-list清空，姓名--刘旋，时间2013-4-23
	}
	
	public void SetModalState(List<int> index_list, List<string> string_list)
	{
		for(int i = 0; i < 24; i++)
			light_flag[i] = false;
		for(int i = 0; i < index_list.Count; i++)
		{
			light_flag[index_list[i]] = true;
			ModeState[index_list[i]] = string_list[i];
		}
	}
	
	//内容--定义函数，显示蓝色光标，1-表示当前段，2-表示检测，姓名--刘旋，时间--2013-4-23
	public void BlueCursorState()
	{
		switch (para_det)
		{
		case 1:
		    for(int i=0; i<24; i++)
		    {
			    ModeCursorH=(Main.corner_px + 251f +i/12*70f)/1000f*Main.width;
			    ModeCursorV=(Main.corner_py + 50f +i%12*19.5f)/1000f*Main.height;
				if(light_flag[i])
				    GUI.Label(new Rect(ModeCursorH,ModeCursorV, 60f/1000f*Main.width,18f/1000f*Main.height),"", Main.sty_BlueCursor);
		    }
			break;
		case 2:
			for(int i=0;i<12;i++)
		    {
			    ModeCursorH=(Main.corner_px + 306.5f +i/4*60f)/1000f*Main.width;
				ModeCursorV=(Main.corner_py + 128f +i%4*24f)/1000f*Main.height;
				if(light_flag[i])
				    GUI.Label(new Rect(ModeCursorH,ModeCursorV, 58f/1000f*Main.width,21f/1000f*Main.height),"", Main.sty_BlueCursor);   
		    }
			break;
		}
	}
	
//   //原始备份	
//	//Todo: 将代码编辑显示相关的程序都整理出来，尽量脱离全局变量，变成一个独立的
//    //输入为（显示代码块左上角的X和Y值，显示几行，单行长度）
//	void DisplayProgram(float pos_y)
//    { 
//		const float blank_length = 10f;  //计算两个代码之间的空格长度
//		//程序最后如果不是;则自动补;
//		if(Main.CodeForAll.Count != 0 && Main.CodeForAll[Main.CodeForAll.Count-1] != ";")
//			Main.CodeForAll.Add(";");
//		Main.TotalCodeNum = Main.CodeForAll.Count;
//		float pos_x = Main.corner_px + 7f;  //代码最左侧的初始位置
//		
// 		float row_length = 340f;  //一行最大的长度
//		float cur_length = 0;	//当前代码长度
//		//float row_length = 325f, cur_length = 0;
//		int index_str = 0;  //或者代码序号
//		
//		//获取起始行的序号
//		if(Main.StartRow == 0)
//			index_str = 0;
//		else
//		    index_str = Main.SeparatePos[Main.StartRow - 1] ;
//		    
//		Vector2 start_word_size = new Vector2(0,0);  //一个NC程序起始处程序字段尺寸
//		Vector2 first_word_size = new Vector2(0,0);
//		Vector2 word_size = new Vector2(0,0);
//		if(Main.TotalCodeNum > 0)     
//			start_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.CodeForAll[0]));	
//		int select_begin , select_end;  //光标选择起始位置控制
//		select_begin = Main.SelectStart > Main.SelectEnd ? Main.SelectEnd:Main.SelectStart;
//		select_end = Main.SelectStart > Main.SelectEnd ? Main.SelectStart:Main.SelectEnd;
//
//		int irow ;
//		//所有行
//	    for(irow = Main.StartRow; irow <= Main.EndRow  && (index_str < Main.TotalCodeNum); ++irow) 
//		{//行开始
//			int icol = 0;
//			pos_x = Main.corner_px + 7f;  //重新将该参数设置到代码最左侧的初始位置
//			if(irow > 0) //如果起始行不是第一行，则当前第一个代码长度为
//			{   
//			    first_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.CodeForAll[Main.SeparatePos[irow - 1]]));
//				cur_length = first_word_size.x;
//			}
//			else
//				cur_length = start_word_size.x;
//			//一行所在的列
//		    for(icol = 0; cur_length < row_length && icol < 10 && (index_str < Main.TotalCodeNum); ++icol)
//		    {//列开始
//				string each_word = Main.CodeForAll[index_str];   
//			    word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(each_word));
//
//				if(index_str >= select_begin && index_str <= select_end && irow != Main.EndRow) //该单词被选中，则底色置为黄色(为什么irow不能等于EndRow)
//				{
//					GUI.Label(new Rect(pos_x/1000f*Main.width, pos_y/1000f*Main.height, word_size.x+1.2f, 25f/1000f*Main.height+0.8f), Main.CodeForAll[index_str], Main.sty_EDITCursor);
//					//如果下一个单词也在选中范围内，则将中间的空格也置为黄色
//					//Debug.Log("X:"+pos_x);
//					pos_x += word_size.x/440f*Main.width;  //这里为什么要用440
//					//Debug.Log("B:"+pos_x);
//					if((index_str + 1) >= select_begin && (index_str + 1) <= select_end && Main.CodeForAll[index_str] != ";")  //10f TobeModified
//						GUI.Label(new Rect((pos_x)/1000f*Main.width, pos_y/1000f*Main.height,10f, 25f/1000f*Main.height+0.8f), "", Main.sty_EDITCursor);  //代表空格
//					else
//						GUI.Label(new Rect(pos_x/1000f*Main.width, pos_y/1000f*Main.height,10f, 25f/1000f*Main.height+0.8f), "", Main.sty_Code);		  //代表空格，？这句有什么用 
//				}
//				else if(irow != Main.EndRow)
//				{
//					GUI.Label(new Rect(pos_x/1000f*Main.width,pos_y/1000f*Main.height,word_size.x+1, 25f/1000f*Main.height), Main.CodeForAll[index_str], Main.sty_Code);	
//				    pos_x += word_size.x/440f*Main.width;		
//				    GUI.Label(new Rect(pos_x/1000f*Main.width,pos_y/1000f*Main.height,10f, 25f/1000f*Main.height), "", Main.sty_Code);	  //代表空格，？这句有什么用   
//				}
//				
//				pos_x += 30f/Main.width;  //空格所占的水平宽度值
//				
//				if(index_str + 1 < Main.TotalCodeNum)
//				{
//				    if(Main.CodeForAll[index_str+1] != ";")
//					{
//						string next_word = Main.CodeForAll[index_str+1];
//					    Vector2 next_word_size = new Vector2(0,0);
//					    next_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(next_word));
//					    cur_length += (next_word_size.x) + blank_length;
//					}
//				}
//				++index_str;
//				if(each_word.Equals(";") || index_str >= Main.TotalCodeNum) 
//				{
//					Main.SeparatePos[irow] = index_str;
//					break;
//				}
//				
//			}//列结束
//			
//			//TobeModified  为什么这里要用空白
//			if(cur_length >= row_length)
//			{
//			    Main.SeparatePos[irow] = index_str;
//				for(;icol < 10;++icol)
//				{
//				    //每隔一个长度画一个空白标签用于存放单词
//					GUI.Label(new Rect(pos_x++/1000f*Main.width,pos_y/1000f*Main.height,1/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_Code);
//					//每隔一个长度画一个空白标签用于存放空格
//					GUI.Label(new Rect(pos_x++/1000f*Main.width,pos_y/1000f*Main.height,1/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_Code);
//				}			 	
//			}		
//			pos_y += 24.5f;
//			
//		}//行结束
//		//for(int j = irow; Main.SeparatePos[j]!=0;++j)
//			//Main.SeparatePos[j] = 0;
//   
//    }
	
//	//修改备份1
//	//Todo: 将代码编辑显示相关的程序都整理出来，尽量脱离全局变量，变成一个独立的
//    //输入为（显示代码块左上角的X和Y值，显示几行，单行长度）
//	void DisplayProgram(float pos_y)
//    { 
//		const float blank_length = 10f;  //计算两个代码之间的空格长度
//		//程序最后如果不是;则自动补;
//		if(Main.CodeForAll.Count != 0 && Main.CodeForAll[Main.CodeForAll.Count-1] != ";")
//			Main.CodeForAll.Add(";");
//		Main.TotalCodeNum = Main.CodeForAll.Count;
//		float pos_x = Main.corner_px + 7f;  //代码最左侧的初始位置
//		
// 		float row_length = 340f;  //一行最大的长度
//		float cur_length = 0;	//当前代码长度
//		int index_str = 0;  //或者代码序号
//		
//		//获取起始行的序号
//		if(Main.StartRow == 0)
//			index_str = 0;
//		else
//		    index_str = Main.SeparatePos[Main.StartRow - 1] ;
//		    
//		Vector2 start_word_size = new Vector2(0,0);  //一个NC程序起始处程序字段尺寸
//		Vector2 first_word_size = new Vector2(0,0);
//		Vector2 word_size = new Vector2(0,0);
//		if(Main.TotalCodeNum > 0)     
//			start_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.CodeForAll[0]));	
//		int select_begin , select_end;  //光标选择起始位置控制
////		Debug.Log("1-" + Main.SelectStart + "; 2-" + Main.SelectEnd);
//		select_begin = Main.SelectStart > Main.SelectEnd ? Main.SelectEnd:Main.SelectStart;
//		select_end = Main.SelectStart > Main.SelectEnd ? Main.SelectStart:Main.SelectEnd;
//
//		int irow ;
//		//所有行
//	    for(irow = Main.StartRow; irow <= Main.EndRow  && (index_str < Main.TotalCodeNum); ++irow) 
//		{//行开始
//			Debug.Log(Main.CodeForAll[Main.SeparatePos[Main.StartRow]]);
//			int icol = 0;
//			pos_x = Main.corner_px + 7f;  //重新将该参数设置到代码最左侧的初始位置
//			if(irow > 0) //如果起始行不是第一行，则当前第一个代码长度为
//			{   
//			    first_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.CodeForAll[Main.SeparatePos[irow - 1]]));
//				cur_length = first_word_size.x;
//			}
//			else
//				cur_length = start_word_size.x;
//			//一行所在的列
//		    for(icol = 0; cur_length < row_length && icol < 10 && (index_str < Main.TotalCodeNum); ++icol)
//		    {//列开始
//				string each_word = Main.CodeForAll[index_str];   
//			    word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(each_word));
//
//				if(index_str >= select_begin && index_str <= select_end && irow != Main.EndRow) //当前光标所在处或者选中的区域
//				{
//					GUI.Label(new Rect(pos_x / 1000f*Main.width, pos_y / 1000f*Main.height, word_size.x + 1.2f, 25f / 1000f*Main.height +1f/Main.height*1000f), Main.CodeForAll[index_str], Main.sty_EDITCursor);
//					pos_x += (word_size.x + 13f)/Main.width*1000f;	  //13代表代码字符与字符之间的距离
//					//如果下一个单词也在选中范围内，则将中间的空格也置为黄色
//					if((index_str + 1) >= select_begin && (index_str + 1) <= select_end && Main.CodeForAll[index_str] != ";")  //10f TobeModified
//					{
//						GUI.Label(new Rect(pos_x/1000f*Main.width - 15f/1000f*Main.width, pos_y/1000f*Main.height, 16f/1000f*Main.width, 25f/1000f*Main.height +1f/Main.height*1000f), "", Main.sty_EDITCursor);
//					}
//				}
//				else if(irow != Main.EndRow)
//				{
//					GUI.Label(new Rect(pos_x/1000f*Main.width,pos_y/1000f*Main.height,word_size.x+1.2f, 25f/1000f*Main.height), Main.CodeForAll[index_str], Main.sty_Code);	
//					pos_x += (word_size.x + 13f)/Main.width*1000f;	//13代表代码字符与字符之间的距离
//				}
//
//				if(index_str + 1 < Main.TotalCodeNum)
//				{
//				    if(Main.CodeForAll[index_str + 1] != ";")
//					{
//						string next_word = Main.CodeForAll[index_str+1];
//					    Vector2 next_word_size = new Vector2(0, 0);
//					    next_word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(next_word));
//					    cur_length += (next_word_size.x) + blank_length;
//					}
//				}
//				++index_str;
//				if(each_word.Equals(";") || index_str >= Main.TotalCodeNum) 
//				{
//					Main.SeparatePos[irow] = index_str;
//					break;
//				}
//			}//列结束
//			
//			//TobeModified  为什么这里要用空白
//			if(cur_length >= row_length)
//			{
//			    Main.SeparatePos[irow] = index_str;
////				for(;icol < 10;++icol)
////				{
////				    //每隔一个长度画一个空白标签用于存放单词
////					GUI.Label(new Rect(pos_x++/1000f*Main.width,pos_y/1000f*Main.height,1/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_Code);
////					//每隔一个长度画一个空白标签用于存放空格
////					GUI.Label(new Rect(pos_x++/1000f*Main.width,pos_y/1000f*Main.height,1/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_Code);
////				}			 	
//			}		
//			pos_y += 24.5f;
//			
//		}//行结束
//		//for(int j = irow; Main.SeparatePos[j]!=0;++j)
//			//Main.SeparatePos[j] = 0;
//   
//    }
	
	//Todo: 将代码编辑显示相关的程序都整理出来，尽量脱离全局变量，变成一个独立的
    //输入为（显示代码块左上角的X和Y值，显示几行，单行长度）
	void DisplayProgram(float position_x, float pos_y)
    { 
		//程序最后如果不是;则自动补;
		if(Main.CodeForAll.Count != 0 && Main.CodeForAll[Main.CodeForAll.Count-1] != ";")
			Main.CodeForAll.Add(";");
		Main.TotalCodeNum = Main.CodeForAll.Count;
		float pos_x = position_x;  //代码最左侧的初始位置
		int index_str = 0;  //或者代码序号
		Vector2 word_size = new Vector2(0,0);  //计算NC代码字符在显示中的宽度值
		int select_begin , select_end;  //光标选择起始位置控制
		select_begin = Main.SelectStart > Main.SelectEnd ? Main.SelectEnd:Main.SelectStart;
		select_end = Main.SelectStart > Main.SelectEnd ? Main.SelectStart:Main.SelectEnd;
		int irow = 0;
		//所有行
	    for(irow = Main.StartRow; index_str < Main.TotalCodeNum && irow <= Main.EndRow; ++irow) 
		{//行开始
			pos_x = position_x;  //重新将该参数设置到代码最左侧的初始位置
			if(irow >= Main.total_row)
				break;
			//一行所在的列
			for(index_str = Main.SeparatePosStart[irow]; index_str < Main.TotalCodeNum && index_str < Main.SeparatePosEnd[irow]; index_str++)
			{//列开始
				string each_word = Main.CodeForAll[index_str];   
			    word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(each_word));
				if(index_str >= select_begin && index_str <= select_end && irow != Main.EndRow) //当前光标所在处或者选中的区域
				{
					GUI.Label(new Rect(pos_x / 1000f*Main.width, pos_y / 1000f*Main.height, word_size.x + 1.2f, 25f/1000f*Main.height +1f/Main.height*1000f), Main.CodeForAll[index_str], Main.sty_EDITCursor);
					pos_x += (word_size.x + 13f)/Main.width*1000f;	  //13代表代码字符与字符之间的距离
					//如果下一个单词也在选中范围内，且最后不为";"，则将中间的空格也置为黄色
					if((index_str + 1) >= select_begin && (index_str + 1) <= select_end && Main.CodeForAll[index_str] != ";") 
					{
						GUI.Label(new Rect(pos_x/1000f*Main.width - 16f/1000f*Main.width, pos_y/1000f*Main.height, 16f/1000f*Main.width, 25f/1000f*Main.height +1f/Main.height*1000f), "", Main.sty_EDITCursor);
					}
				}
				else if(irow != Main.EndRow)
				{
					GUI.Label(new Rect(pos_x/1000f*Main.width,pos_y/1000f*Main.height,word_size.x+1.2f, 25f/1000f*Main.height), Main.CodeForAll[index_str], Main.sty_Code);	
					pos_x += (word_size.x + 13f)/Main.width*1000f;	//13代表代码字符与字符之间的距离
				}
			}//列结束	
			pos_y += 24.5f;
		}//行结束
    }
	
	//Todo: 将自动运行代码显示相关的程序都整理出来，尽量脱离全局变量，变成一个独立的小模块
	public void AutoDisplyProgram(float position_x, float pos_y)
	{
		int selectedBeginRow = Main.AutoBeginRow;
		int selectedEndRow = Main.AutoStopRow;
		//程序最后如果不是;则自动补;
		if(Main.CodeForAUTO.Count == 0)
			Main.CodeForAUTO.Add(";");
		else if(Main.CodeForAUTO[Main.CodeForAUTO.Count-1] != ";")
			Main.CodeForAUTO.Add(";");

		float pos_x = position_x;
		int index_str = 0;
		index_str = Main.SeparateAutoStart[Main.AUTOStartRow] ;
		Vector2 word_size = new Vector2(0,0);
		int irow = 0;
	    for(irow = Main.AUTOStartRow; index_str < Main.CodeForAUTO.Count && irow <= Main.AUTOEndRow; ++irow) 
		{//行开始
			if(irow >= Main.auto_total_row)
				break;
			pos_x = position_x;
			if(irow >= selectedBeginRow && irow <= selectedEndRow)
			{
				if(!Main.autoDisplayNormal)
					GUI.Label(new Rect((Main.corner_px + 3.5f)/1000f*Main.width, (pos_y)/1000f*Main.height,487f/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_EDITCursor);
				else
					GUI.Label(new Rect((Main.corner_px + 3.5f)/1000f*Main.width,  (pos_y)/1000f*Main.height,487f/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_EDITCursor);
			}
			for(index_str = Main.SeparateAutoStart[irow]; index_str < Main.CodeForAUTO.Count && index_str < Main.SeparateAutoEnd[irow]; index_str++)
			{//列结束
				string each_word = Main.CodeForAUTO[index_str];   
			    word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(each_word));
				if(irow != Main.AUTOEndRow)
				{
					GUI.Label(new Rect(pos_x/1000f*Main.width, pos_y/1000f*Main.height, word_size.x+1, 25f/1000f*Main.height), Main.CodeForAUTO[index_str], Main.sty_Code);	
					pos_x += (word_size.x + 13f)/Main.width*1000f;	  //13代表代码字符与字符之间的距离	    
				}
			}//列结束
			pos_y += 24.5f;
		}//行结束
	}
	
	//Todo: 将自动运行代码显示相关的程序都整理出来，尽量脱离全局变量，变成一个独立的小模块
	public void MDIDisplyProgram(float position_x, float pos_y)
	{
		int selectedBeginRow = Main.MDIBeginRow;
		int selectedEndRow = Main.MDIStopRow;
		//程序最后如果不是;则自动补;
		if(Main.CodeForMDIRuning.Count == 0)
			Main.CodeForMDIRuning.Add(";");
		else if(Main.CodeForMDIRuning[Main.CodeForMDIRuning.Count-1] != ";")
			Main.CodeForMDIRuning.Add(";");

		float pos_x = position_x;
		int index_str = 0;
		index_str = Main.SeparateMDIStart[Main.MDIStartRowC] ;
		Vector2 word_size = new Vector2(0,0);
		int irow = 0;
	    for(irow = Main.MDIStartRowC; index_str < Main.CodeForMDIRuning.Count && irow <= Main.MDIEndRowC; ++irow) 
		{//行开始
			if(irow >= Main.mdi_total_row)
				break;
			pos_x = position_x;
			if(irow >= selectedBeginRow && irow <= selectedEndRow)
			{
				GUI.Label(new Rect((Main.corner_px + 7f)/1000f*Main.width, (pos_y)/1000f*Main.height,460f/1000f*Main.width,25f/1000f*Main.height), "", Main.sty_EDITCursor);
			}
			for(index_str = Main.SeparateMDIStart[irow]; index_str < Main.CodeForMDIRuning.Count && index_str < Main.SeparateMDIEnd[irow]; index_str++)
			{//列结束
				string each_word = Main.CodeForMDIRuning[index_str];   
			    word_size = Main.sty_EDITTextField.CalcSize(new GUIContent(each_word));
				if(irow != Main.MDIEndRowC)
				{
					GUI.Label(new Rect(pos_x/1000f*Main.width, pos_y/1000f*Main.height, word_size.x+1, 25f/1000f*Main.height), Main.CodeForMDIRuning[index_str], Main.sty_Code);	
					pos_x += (word_size.x + 13f)/Main.width*1000f;	  //13代表代码字符与字符之间的距离	    
				}
			}//列结束
			pos_y += 24.5f;
		}//行结束
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
