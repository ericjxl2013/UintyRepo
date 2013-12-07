using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffsetSettingModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	
	public float tool_corner_x = 0;
	public float tool_corner_y = 0;
	float tool_cell_width = 0;
	float tool_cell_height = 0;
		
	void Awake () 
	{
		
	}
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		
		tool_corner_x = Main.corner_px + 54.5f;
		tool_corner_y = Main.corner_py + 45f;
		tool_cell_width = 110f;
		tool_cell_height = 22f;
	}
	
	public void Offset ()
	{
		//刀偏设置
		if(Main.OffSetTool)
		{
			ToolOffSet();
		}
		//系统相关参数设置
		if(Main.OffSetSetting)
		{
			ArguSettings();
		}
		//坐标系设置
		if(Main.OffSetCoo)
		{
			CooOffSetting();
		}
	}
	
	[RPC]
	void OffsetSettingRPC(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			Main.OffSetTool = true;
		else
			Main.OffSetTool = false;
		if(info_array[1] == "True")
			Main.OffSetSetting = true;
		else
			Main.OffSetSetting = false;
		if(info_array[2] == "True")
			Main.OffSetCoo = true;
		else
			Main.OffSetCoo = false;
		Main.ToolOffSetPage_num = int.Parse(info_array[3]);
		Main.tool_setting_cursor_w = float.Parse(info_array[4]);
		Main.tool_setting_cursor_y = float.Parse(info_array[5]);
		if(info_array[6] == "True")
			Main.OffSetOne = true;
		else
		    Main.OffSetOne = false;
		if(info_array[7] == "True")
			Main.OffSetTwo = true;
		else
			Main.OffSetTwo = false;
		Main.argu_setting = int.Parse(info_array[8]);
		Main.argu_setting_cursor_w = float.Parse(info_array[9]);
		Main.argu_setting_cursor_y = float.Parse(info_array[10]);
		if(info_array[11] == "True")
			Main.OffCooFirstPage = true;
		else
			Main.OffCooFirstPage = false;
		Main.coo_setting_1 = int.Parse(info_array[12]);
		Main.coo_setting_2 = int.Parse(info_array[13]);
		Main.coo_setting_cursor_x = float.Parse(info_array[14]);
		Main.coo_setting_cursor_y = float.Parse(info_array[15]);
	}
	
	//刀偏设定界面
	void ToolOffSet () {
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width, (Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"刀偏", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 30f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,40f/1000f*Main.width,20f/1000f*Main.height),"号.", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect((Main.corner_px + 76.5f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"形状（H）", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"磨损（H）", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect((Main.corner_px + 296.5f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"形状（D）", Main.sty_MostWords_ToolOffSet);
		GUI.Label(new Rect((Main.corner_px + 406.5f)/1000f*Main.width,(Main.corner_py + 23f)/1000f*Main.height,100f/1000f*Main.width,20f/1000f*Main.height),"磨损（D）", Main.sty_MostWords_ToolOffSet);
		Main.number = 8 * Main.ToolOffSetPage_num;
		
		//编号
		for(int i = 0; i < 8; i++)
		{
			GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(tool_corner_y + i*tool_cell_height)/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),Main.Tool_numberGet(Main.number+1 + i), Main.sty_MostWords_ToolOffSet);
		}
	
		//背景框
		for(int i= 0; i < 8; i++)
		{
			for(int j = 0; j < 4; j++)
			{
				GUI.Label(new Rect((tool_corner_x + j*tool_cell_width)/1000f*Main.width,(tool_corner_y + i*tool_cell_height)/1000f*Main.height,tool_cell_width/1000f*Main.width,tool_cell_height/1000f*Main.height),"", Main.sty_OffSet_Coo);
			}
		}
			
		GUI.Label(new Rect(Main.tool_setting_cursor_w/1000f*Main.width, Main.tool_setting_cursor_y/1000f*Main.height,107f/1000f*Main.width, 19f/1000f*Main.height), "", Main.sty_EDITCursor);
			
		//显示数字
		for(int i = 0; i < 8; i++)
		{
			GUI.Label(new Rect((tool_corner_x + 0*tool_cell_width)/1000f*Main.width, (tool_corner_y + i*tool_cell_height)/1000f*Main.height, 110f/1000f*Main.width, 25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_H[Main.number+i]), Main.sty_SmallNum);
			GUI.Label(new Rect((tool_corner_x + 1*tool_cell_width)/1000f*Main.width, (tool_corner_y + i*tool_cell_height)/1000f*Main.height, 110f/1000f*Main.width, 25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_H[Main.number+i]), Main.sty_SmallNum);
			GUI.Label(new Rect((tool_corner_x + 2*tool_cell_width)/1000f*Main.width, (tool_corner_y + i*tool_cell_height)/1000f*Main.height, 110f/1000f*Main.width, 25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.shape_D[Main.number+i]), Main.sty_SmallNum);
			GUI.Label(new Rect((tool_corner_x + 3*tool_cell_width)/1000f*Main.width, (tool_corner_y + i*tool_cell_height)/1000f*Main.height, 110f/1000f*Main.width, 25f/1000f*Main.height),Main.ToolStringGet(CooSystem_script.wear_D[Main.number+i]), Main.sty_SmallNum);
		}
		
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 220f)/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"相 对 坐 标   X", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px + 170f)/1000f*Main.width,(Main.corner_py + 220f)/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.CooStringFormat(Main.relative_pos.x),Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 330f)/1000f*Main.width,(Main.corner_py + 220f)/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"Y", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px + 365f)/1000f*Main.width,(Main.corner_py + 220f)/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.CooStringFormat(Main.relative_pos.y),Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 130f)/1000f*Main.width,(Main.corner_py + 245f)/1000f*Main.height,150f/1000f*Main.width,25f/1000f*Main.height),"Z", Main.sty_PosSmallWord);
		GUI.Label(new Rect((Main.corner_px + 170f)/1000f*Main.width,(Main.corner_py + 245f)/1000f*Main.height,110f/1000f*Main.width,25f/1000f*Main.height),Main.CooStringFormat(Main.relative_pos.z),Main.sty_SmallNum);
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 216f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);	
		}		
		else if(Main.OffSetTwo)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 34f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"No检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 222f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"C输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 308f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 408f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"输 入", Main.sty_BottomChooseMenu);
		}
	}
	//参数设置界面
	void ArguSettings () {
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width, (Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设定（手持盒）", Main.sty_Title);
//		GUI.Label(new Rect(40f/1000f*Main.width, 55f/1000f*Main.height , 500f/1000f*Main.width,300f/1000f*Main.height), "", Main.sty_SettingsBG);
		
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"写参数", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：不可以   1：可以）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 53f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"TV  检查", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 53f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 53f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 53f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：关断   1：接通）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 78f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"穿孔代码", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 78f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 78f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 78f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：EIA  1：ISO）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"输入单位", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 103f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：毫米   1：英寸）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"I/O  通道", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,40f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mid);
		GUI.Label(new Rect((Main.corner_px + 251.5f)/1000f*Main.width,(Main.corner_py + 128f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0-35： 通道号   ）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 153f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 153f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 153f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 153f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：关断   1：接通）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 178f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"纸带格式", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 178f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 178f)/1000f*Main.height,21f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo_mini);
		GUI.Label(new Rect((Main.corner_px + 231.5f)/1000f*Main.width,(Main.corner_py + 178f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（0：无变换 1：F10/11）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 203f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号停止", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 203f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 203f)/1000f*Main.height,120f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		GUI.Label(new Rect((Main.corner_px + 331.5f)/1000f*Main.width,(Main.corner_py + 203f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（ 程 序 号 ）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 228f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"顺序号停止", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 186.5f)/1000f*Main.width,(Main.corner_py + 228f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"=", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 206.5f)/1000f*Main.width,(Main.corner_py + 228f)/1000f*Main.height,120f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		GUI.Label(new Rect((Main.corner_px + 331.5f)/1000f*Main.width,(Main.corner_py + 228f)/1000f*Main.height,500f/1000f*Main.width,25f/1000f*Main.height),"（ 顺 序 号 ）", Main.sty_MostWords);
		
		GUI.Label(new Rect((Main.corner_px + 208.5f)/1000f*Main.width, Main.argu_setting_cursor_y/1000f*Main.height,Main.argu_setting_cursor_w/1000f*Main.width,22f/1000f*Main.height),"", Main.sty_EDITCursor);
		
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 30f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.parameter_writabel, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 55f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.TV_check, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 80f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.hole_code, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 105f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.input_unit, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 130f)/1000f*Main.height,40f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet_IO(CooSystem_script.IO), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 155f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.sequence_number, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 210f)/1000f*Main.width,(Main.corner_py + 180f)/1000f*Main.height,20f/1000f*Main.width,29f/1000f*Main.height),CooSystem_script.paper_tape, Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 205f)/1000f*Main.height,120f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet(CooSystem_script.SN_stop1), Main.sty_SmallNum);
		GUI.Label(new Rect((Main.corner_px + 227f)/1000f*Main.width,(Main.corner_py + 230f)/1000f*Main.height,120f/1000f*Main.width,29f/1000f*Main.height),Main.ArguStringGet(CooSystem_script.SN_stop2), Main.sty_SmallNum);
		
		
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 216f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}		
		else if(Main.OffSetTwo)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 36f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"宏变量", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"模 式", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 226f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"操 作", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
		}
	}
	//工件坐标系设定界面
	void CooOffSetting () {
		GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width, (Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"工件坐标系设定", Main.sty_Title);
		GUI.Label(new Rect((Main.corner_px + 0f)/1000f*Main.width,(Main.corner_py + 22f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（G54）", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 16.5f)/1000f*Main.width,(Main.corner_py + 45f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"号.", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 146.5f)/1000f*Main.width,(Main.corner_py + 45f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"数据", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 256.5f)/1000f*Main.width,(Main.corner_py + 45f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"号.", Main.sty_MostWords);
		GUI.Label(new Rect((Main.corner_px + 401.5f)/1000f*Main.width,(Main.corner_py + 45f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"数据", Main.sty_MostWords);
		
		if(Main.OffCooFirstPage)
		{
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 71f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 97f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"EXT", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 99f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 125f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 72f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 98f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 124f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 185f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"01", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 212f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G54", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 214f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 213f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 239f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 71f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"02", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 97f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G55", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 99f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 125f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 72f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 98f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 124f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 185f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"03", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 212f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G56", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 214f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 213f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 239f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);	
		}
		else
		{
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 71f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"04", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 97f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G57", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 99f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 125f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 72f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 98f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 124f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 185f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"05", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 12f)/1000f*Main.width,(Main.corner_py + 212f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G58", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 188f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 214f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 67.5f)/1000f*Main.width,(Main.corner_py + 240f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 187f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 213f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 97.5f)/1000f*Main.width,(Main.corner_py + 239f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 71f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"06", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 250f)/1000f*Main.width,(Main.corner_py + 97f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"G59", Main.sty_MostWords);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"X", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 99f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Y", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 312.5f)/1000f*Main.width,(Main.corner_py + 125f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"Z", Main.sty_Cursor);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 72f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 98f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
			GUI.Label(new Rect((Main.corner_px + 342.5f)/1000f*Main.width,(Main.corner_py + 124f)/1000f*Main.height,140f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
		}
		
		GUI.Label(new Rect(Main.coo_setting_cursor_x/1000f*Main.width, Main.coo_setting_cursor_y/1000f*Main.height,136f/1000f*Main.width,22f/1000f*Main.height),"", Main.sty_EDITCursor);
		//GUI.Label(new Rect(131f/1000f*width,150f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		//GUI.Label(new Rect(131f/1000f*width,180f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		//GUI.Label(new Rect(131f/1000f*width,120f/1000f*height,138f/1000f*width,26f/1000f*height),"", sty_EDITCursor);
		if(Main.OffCooFirstPage)
		{
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G00_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 100f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G00_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 127f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G00_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 189f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G54_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 216f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G54_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G54_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G55_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 100f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G55_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 127f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G55_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 189f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G56_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 216f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G56_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G56_pos.z), Main.sty_SmallNum);
		}
		else
		{
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G57_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 100f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G57_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 127f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G57_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 189f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G58_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 216f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G58_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 103f)/1000f*Main.width,(Main.corner_py + 242f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G58_pos.z), Main.sty_SmallNum);
			
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 73f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G59_pos.x), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 100f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G59_pos.y), Main.sty_SmallNum);
			GUI.Label(new Rect((Main.corner_px + 348f)/1000f*Main.width,(Main.corner_py + 127f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height), Main.CooStringFormat(CooSystem_script.G59_pos.z), Main.sty_SmallNum);
		}
		
		if(Main.OffSetOne)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 40f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"刀 偏", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设 定", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 216f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"坐标系", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 385f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"（操 作）", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}		
		else if(Main.OffSetTwo)
		{
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 34f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"No检索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 133f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"测 量", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 309f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 410f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"输入", Main.sty_BottomChooseMenu);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
