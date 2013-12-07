using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class EntranceScript : MonoBehaviour {
	ControlPanel Main;
	NCCodeFormat NCCodeFormat_Script;
	ProgramModule ProgramModule_Script;
	AutoMoveModule Auto_Script;
	MoveControl Move_Script;
	CooSystem CooSystem_Script;
	SpindleControl SpindleControl_script;
	PathLineDraw PathLineDraw_Script;
	AutoToolChangeModule AutoToolChange_Script;
	CuttingWork CuttingWork_Script;
	Warnning Warnning_Script;
	SoftkeyModule Softkey_Script;
	List<List<string>> SourceCode = new List<List<string>>();
	List<MotionInfo> motion_info_list = new List<MotionInfo>();
	List<MotionInfo> original_motion_info_list = new List<MotionInfo>();
	List<ToolChangeInfo> tool_motion_list = new List<ToolChangeInfo>();
	public ModalCode_Fanuc_M CurrentModal = new ModalCode_Fanuc_M();
	public Vector3 CooZeroPoint = new Vector3(0, 0, 0); //用于程序自动执行时，更换坐标系
	//GameObject tryCreate;
	//ModalCode_Fanuc_M 
//	string text_field = "O2";
	public bool Slash_on = false;
	int singleStepEnd = 100;
	public int SpeedNow = 0;
	string test_str = "";
	
	
	// Use this for initialization
	void Start () {
		/*
		tryCreate = (GameObject)Resources.Load("EmptyObject");
		Instantiate(tryCreate);
		tryCreate.transform.name = "tryCreate";
		*/
		NCCodeFormat_Script = GameObject.Find("MainScript").GetComponent<NCCodeFormat>();
		ProgramModule_Script = GameObject.Find("MainScript").GetComponent<ProgramModule>();
		CooSystem_Script = GameObject.Find("MainScript").GetComponent<CooSystem>();
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		Auto_Script = GameObject.Find("AutoMove").GetComponent<AutoMoveModule>();
		Move_Script = GameObject.Find("move_control").GetComponent<MoveControl>();
		SpindleControl_script = GameObject.Find("spindle_control").GetComponent<SpindleControl>();
		
		PathLineDraw_Script = GameObject.Find("Main Camera").GetComponent<PathLineDraw>();
		AutoToolChange_Script = GameObject.Find("ToolChange").GetComponent<AutoToolChangeModule>();
		Warnning_Script = gameObject.GetComponent<Warnning>();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule>();
		CooZeroPoint = new Vector3(0, 0, 0);
		singleStepEnd = 100;
		CurrentModal = new ModalCode_Fanuc_M();
//		CurrentModal.RotateSpeed = 3000;
		GameObject ForCuttingWork = GameObject.Find("GameObject");
		if(ForCuttingWork == null)
		{
			Debug.LogError("请添加空物体GameObject！");
			return;
		}
		ForCuttingWork.name = "CuttingWork";
		ForCuttingWork.AddComponent<CuttingWork>();
		CuttingWork_Script = ForCuttingWork.GetComponent<CuttingWork>();
		
	}

	void Load(string filename)
	{
		bool open_flag = false;
		test_str = "";
		if(SourceCode != null)
		{
			SourceCode.Clear();
			SourceCode = null;
		}
		SourceCode = new List<List<string>>();
		List<string> temp_code_load = NCCodeFormat_Script.AllCode(filename, ref open_flag);
		List<string> temp_code_add = new List<string>();
		string temp_code_str = "";
		for(int i = 0; i < temp_code_load.Count; i++)
		{
			test_str += temp_code_load[i];
			temp_code_str = temp_code_load[i];
			if(temp_code_str == ";")
			{
				test_str += "\n";
				temp_code_add.Add(temp_code_str);
				SourceCode.Add(temp_code_add);		
				temp_code_add = new List<string>();
			}
			else
				temp_code_add.Add(temp_code_str);
		}
		//SourceCode = NCCodeFormat_Script.AllCode(filename);
//		Debug.Log(SourceCode.Count);
		/*
		for(int i = 0; i < SourceCode.Count; i++)
		{
			temp_code_str = "";
			for(int j = 0; j < SourceCode[i].Count; j++)
			{
				temp_code_str += " " + SourceCode[i][j];
			}
			Debug.Log(temp_code_str.TrimStart());
		}
		*/
	}
	
	void SourceCodeFarmat(List<string> original_code)
	{
		if(SourceCode != null)
		{
			SourceCode.Clear();
			SourceCode = null;
		}
		SourceCode = new List<List<string>>();
		List<string> temp_code_add = new List<string>();
		string temp_code_str = "";
		for(int i = 0; i < original_code.Count; i++)
		{
			temp_code_str = original_code[i];
			if(temp_code_str == ";")
			{
				temp_code_add.Add(temp_code_str);
				SourceCode.Add(temp_code_add);		
				temp_code_add = new List<string>();
			}
			else
				temp_code_add.Add(temp_code_str);
		}
	}
	
	public bool AutoCodeCompile(List<string> original_code, ref string errorString)
	{
		int compile_result = -1;
		SourceCodeFarmat(original_code);
		FANUC_OI_M AutoFanuc_OI_M = new FANUC_OI_M();
		CurrentModal.SetCooZero(CooSystem_Script.AbsoluteZero);
		AutoFanuc_OI_M.ModalClone(CurrentModal);
		compile_result = AutoFanuc_OI_M.CompileEntrance(SourceCode, CooSystem_Script.absolute_pos, motion_info_list, Auto_Script.CurrentVirtualPos(), original_motion_info_list, tool_motion_list);
		if(compile_result == (int)ResultType.Success)
		{
			errorString = "";
			PathLineDraw_Script.lineDrawer.Clear();
			PathLineDraw_Script.lineOriginalDrawer.Clear();
			CreatePathLine(ref PathLineDraw_Script.lineDrawer, Color.green, motion_info_list);
			CreatePathLine(ref PathLineDraw_Script.lineOriginalDrawer, Color.red, original_motion_info_list);
//			Debug.Log(original_motion_info_list.Count + "<||>" + motion_info_list.Count);
//			foreach(MotionInfo motion_info in motion_info_list)
//				Debug.Log(motion_info.ToString());
//			for(int i = 0; i < motion_info_list.Count && i < 300; i++)
//			{
//				Debug.Log(motion_info_list[i].ToString());
//				Debug.Log(original_motion_info_list[i].ToString());
//			}
//			for(int i = 0; i < original_motion_info_list.Count && i < 300; i++)
//			{
//				Debug.Log(motion_info_list[i].ToString());
//				Debug.Log(original_motion_info_list[i].ToString());
//			}
			return true;
		}
		else if(compile_result == (int)ResultType.CompileError)
		{
			errorString = "代码编译错误！";
//			Debug.Log(AutoFanuc_OI_M.CompileInfo.Count);
			for(int i = 0; i < AutoFanuc_OI_M.CompileInfo.Count && i < 500; i++)
			{
//				Debug.Log(AutoFanuc_OI_M.CompileInfo[i]);
				Warnning_Script.object_description += AutoFanuc_OI_M.CompileInfo[i]+"\n";
			}
			Warnning_Script.object_description += "代码编译错误！\n";
			if(!Warnning_Script.come_forth)
				Warnning_Script.motion_start = true;
			return false;
		}
		else
		{
			errorString = "程序中含有宏代码，本系统暂不支持宏代码！";
			Warnning_Script.object_description += "程序中含有宏代码，本系统暂不支持宏代码！\n";
			if(!Warnning_Script.come_forth)
				Warnning_Script.motion_start = true;
			return false;
		}
	}
		
	/// <summary>
	/// 生成轨迹线, TobeModified
	/// </summary>
	public void CreatePathLine(ref LineInfo currentLineDrawer, Color lineColor, List<MotionInfo> motion_info_data)
	{
		currentLineDrawer.Clear();
//		PathLineDraw_Script.lineOriginalDrawer.Clear();
		List<ToolChangeInfo> tool_motion_line_list = new List<ToolChangeInfo>();
		ToolChangeInfo tempToolData = new ToolChangeInfo();
		for(int i = 0; i < tool_motion_list.Count; i++)
		{
			tempToolData = new ToolChangeInfo();
			tempToolData.ToolDataCopy(tool_motion_list[i]);
			tool_motion_line_list.Add(tempToolData);
		}
		//将画线参考体移动到主轴指定位置
		PathLineDraw_Script.lineRef.parent = GameObject.Find("main axle_4").transform;
		PathLineDraw_Script.lineRef.localPosition = new Vector3(0, -0.731137f, 0.0003082752f);
		PathLineDraw_Script.lineRef.localEulerAngles = new Vector3(90, 270, 0);
		PathLineDraw_Script.lineRef.parent = GameObject.Find("workbench_1").transform;
		//本次轨迹线的起始点
		Vector3 orinPoint = Auto_Script.CurrentVirtualPos() / 1000;
		for(int i = 0; i < motion_info_data.Count; i++)
		{
			if(motion_info_data[i].Motion_Type != -1 && motion_info_data[i].Motion_Type != (int)MotionType.Pause)
			{
				//圆弧
				if(motion_info_data[i].Motion_Type == (int)MotionType.Circular02 || motion_info_data[i].Motion_Type == (int)MotionType.Circular03)
				{
					Vector3 centre_point = motion_info_data[i].VirtualTarget - motion_info_data[i].DisplayTarget + motion_info_data[i].Center_Point;
					centre_point /= 1000;
					Vector3 start_vector = motion_info_data[i].VirtualStart / 1000 - centre_point;
					Vector3 end_vector = motion_info_data[i].VirtualTarget / 1000 - centre_point;
					Vector3 axis_vector = Vector3.zero;
					//半圆弧或者圆弧时关于旋转轴的处理
					if(motion_info_data[i].Rotate_Degree % 180 == 0)
					{
						//顺时针
						if(motion_info_data[i].Motion_Type == (int)MotionType.Circular02)
						{
							if(motion_info_data[i].Current_Plane == (int)CheckInformation.XYPlane)
								axis_vector = new Vector3(0, 0, -1);
							else if(motion_info_data[i].Current_Plane == (int)CheckInformation.ZXPlane)
								axis_vector = new Vector3(0, -1, 0);
							else
								axis_vector = new Vector3(-1, 0, 0);
						}
						//逆时针
						else
						{
							if(motion_info_data[i].Current_Plane == (int)CheckInformation.XYPlane)
								axis_vector = new Vector3(0, 0, 1);
							else if(motion_info_data[i].Current_Plane == (int)CheckInformation.ZXPlane)
								axis_vector = new Vector3(0, 1, 0);
							else
								axis_vector = new Vector3(1, 0, 0);
						}
					}
					else
					{
						axis_vector = Vector3.Cross(start_vector, end_vector).normalized;
						if(motion_info_data[i].Rotate_Degree > 180f)
							axis_vector = -1 * axis_vector;
					}
//					float radius = (motion_info_list[i].VirtualTarget / 1000 - centre_point).magnitude;
					float angle = motion_info_data[i].Rotate_Degree * Mathf.PI / 180;
					//r旋转theta弧度后的向量
					Vector3 rotate_point = new Vector3(0f, 0f, 0f);
					//圆弧精度计算
					int slices =(int)(SystemArguments.CirclePrecision * angle / (2 * Mathf.PI));
					if(slices <= 2)
						slices = 3;
					motion_info_data[i].Slices = slices;
//					Debug.Log(slices + ":   angle = " + angle + ";  radius = " + radius);
					//每次旋转的弧度数
					float theta = angle / slices;
					float calTheta = 0;
					//运用了旋转矩阵，等价于Rodrigues旋转公式
					Vector3 firstPoint = new Vector3(0, 0, 0);  //折线起始点
					Vector3 secondPoint = new Vector3(0f, 0f, 0f);  //折线终点
					for(int j = 0; j <= slices; ++j)
					{
						if(j != 0)
							calTheta += theta;
						rotate_point = Mathf.Cos(calTheta) * start_vector + Vector3.Cross(axis_vector, start_vector) * Mathf.Sin(calTheta) + Vector3.Dot(axis_vector, start_vector) * axis_vector * (1 - Mathf.Cos(calTheta));
						secondPoint = centre_point + rotate_point;
						if(j != 0)
						{
							currentLineDrawer.Add(i, j, firstPoint - orinPoint, secondPoint - orinPoint, lineColor);
						}
						firstPoint = secondPoint;
					}     
				}
				//从参考点返回，两点，即两条线段
				else if(motion_info_data[i].Motion_Type == (int)MotionType.BackFromRP || motion_info_data[i].Motion_Type == (int)MotionType.AutoReturnRP)
				{
					motion_info_data[i].Slices = 2;
					currentLineDrawer.Add(i, 1, motion_info_data[i].VirtualStart / 1000 - orinPoint, motion_info_data[i].VirtualTarget / 1000 - orinPoint, lineColor);
					currentLineDrawer.Add(i, 2, motion_info_data[i].VirtualTarget / 1000 - orinPoint, motion_info_data[i].VirtualTarget2 / 1000 - orinPoint, lineColor);
				}
				//直线情况
				else
				{
					currentLineDrawer.Add(i, -1, motion_info_data[i].VirtualStart / 1000 - orinPoint, motion_info_data[i].VirtualTarget / 1000 - orinPoint, lineColor);
				}
			}
			string toolchange_str = "" + (char)ImmediateMotionType.M06;
			//有换刀程序
			if(motion_info_data[i].Immediate_Motion.Contains(toolchange_str))
			{
				if(tool_motion_line_list[0].TimeValue > 0)
					currentLineDrawer.Add(motion_info_data.Count + tool_motion_line_list.Count, -1, tool_motion_line_list[0].VirtualStart / 1000 - orinPoint, tool_motion_line_list[0].VirtualTarget / 1000 - orinPoint, lineColor);
				tool_motion_line_list.RemoveAt(0);
			}
		}
//		Debug.Log(PathLineDraw_Script.lineDrawer.Count());
	}
	
	void WriteTXT()
	{
		FileStream testFile = new FileStream(Application.dataPath + "/TestInfo/MotionInfo.txt", FileMode.Create);
		StreamWriter txtWriter = new StreamWriter(testFile);
		string line_str = "";
		for(int i = 0; i < motion_info_list.Count; i++)
		{
			line_str = i + ": " + motion_info_list[i].ToString();
			txtWriter.WriteLine(line_str);
		}
		txtWriter.Close();
		testFile = new FileStream(Application.dataPath + "/TestInfo/PathInfo.txt", FileMode.Create);
		txtWriter = new StreamWriter(testFile);
		for(int i = 0; i < PathLineDraw_Script.lineDrawer.Count(); i++)
		{
			txtWriter.WriteLine(PathLineDraw_Script.lineDrawer.CurrentString(i));
		}
		txtWriter.Close();
	}
	
	
	
//	void OnGUI ()
//	{
//		//To display
////		test_str = GUI.TextArea(new Rect(10, 200, 300, 500), test_str);
//		
//		GUI.Label(new Rect(10, 720, 100, 20), "请输入程序号：");
//		text_field = GUI.TextField(new Rect(115, 720, 195, 20), text_field);
//		//运行时，可重新输入不同的NC程序名字，反复启动
//		if(GUI.Button(new Rect(10, 750, 300, 30), "启动"))
//		{
//			Load(text_field);
////			Debug.Log(CooSystem_Script.absolute_pos.x + ", "+CooSystem_Script.absolute_pos.y + ", "+CooSystem_Script.absolute_pos.z);
////			Debug.Log(Auto_Script.CurrentVirtualPos().x + ", "+Auto_Script.CurrentVirtualPos().y + ", "+Auto_Script.CurrentVirtualPos().z);
//		}
////		
//////		if(GUI.Button(new Rect(460, 110, 100, 30), "Single"))
//////		{
//////			SingleStep = !SingleStep;
//////		}
//////		
//////		if(GUI.Button(new Rect(460, 150, 100, 30), "Next"))
//////		{
//////			SingleStepStop();
//////		}
//////		
//////		if(GUI.Button(new Rect(460, 190, 100, 30), "Next"))
//////		{
//////			Auto_Script.Pause();
//////		}
////		
//		if(GUI.Button(new Rect(10, 800, 300, 30), "检查"))
//		{
//			FANUC_OI_M check = new FANUC_OI_M();
//			CurrentModal.SetCooZero(CooSystem_Script.AbsoluteZero);
//			check.ModalClone(CurrentModal);
////			Debug.Log(Auto_Script.CurrentVirtualPos());
////			Debug.Log(Move_Script.MachineCoo);
////			Debug.Log(CooSystem_Script.absolute_pos);
//			if(check.CompileEntrance(SourceCode, CooSystem_Script.absolute_pos, motion_info_list, Auto_Script.CurrentVirtualPos(), original_motion_info_list, tool_motion_list) == (int)ResultType.Success)
//			{
//				CreatePathLine();
//			}
//			else
//			{
//				Debug.LogError("编译结果错误");
//			}
////			Debug.Log(check.CompileEntrance(SourceCode, CooSystem_Script.absolute_pos, motion_info_list, Auto_Script.CurrentVirtualPos(), original_motion_info_list));
//////			Debug.Log(check.ExecuteFlag);
//////			Debug.Log(check.CompileInfo.Count);
//////			Debug.Log(motion_info_list.Count);
//			if(check.CompileInfo.Count > 0)
//			foreach(string error_str in check.CompileInfo)
//				Debug.Log(error_str);
////			foreach(MotionInfo motion_info in motion_info_list)
////				Debug.Log(motion_info.ToString());
////	
//		}
////		
////	}
//	
////	void CloneTest()
////	{
////		ModalCode_Fanuc_M original_class = new ModalCode_Fanuc_M();
////		Debug.Log( "original1: "+original_class.Modal_Code[10]);
////		original_class.Modal_Code[10] = "G1111";
////		Debug.Log("original2: "+original_class.Modal_Code[10]);
////		ModalCode_Fanuc_M copy1 = new ModalCode_Fanuc_M(original_class);
////		Debug.Log("copy1: "+copy1.Modal_Code[10]);
////		copy1.Modal_Code[10] = "copy";
////		Debug.Log("compare: " + original_class.Modal_Code[10] + copy1.Modal_Code[10]);
////	}
//	
////	void SimulateFunc(List<List<string>> source_code, string prog_name, ref List<DataStore> compile_data, Vector3 current_position, ref List<MotionInfo> motion_data)
////	{
////		FANUC_OI_M SimulatClass = new FANUC_OI_M();
////		SimulatClass.ModalClone(CurrentModal);
////		SimulatClass.CompileEntrance(source_code, prog_name, ref compile_data, current_position, ref motion_data, virtual_position);
////		
////	}
//	
////	void StartSimulate()
////	{
////		for(int i = 0; i < motion_info_list.Count; i++)
////		{
////			//光标换行
////			//Debug.Log("Change to row: " + i);
////			//跳过功能
////			/***
////			 * if（跳过按钮按下）
////			 * {
////			 * 		if（当前行有/）
////			 * 			continue；
////			 * }
////			 * **/
////			//执行需立即实现的功能
////			if(motion_info_list[i].Immediate_Motion != "")
////			{
////				for(int j = 0; j < motion_info_list[i].Immediate_Motion.Length; j++)
////				{
////					Debug.Log("Immediate Function: " + motion_info_list[i].Immediate_Motion[j]);
////					//+++在这里对应的参数要变化
////				}
////			}
////			//常规运动
////			if(motion_info_list[i].Motion_Type != -1)
////			{
////				Debug.Log("判断模态和参数是否要变化");
////				switch(motion_info_list[i].Motion_Type)
////				{
////				case (int)MotionType.DryRunning:
////					Debug.Log("G00");
////					Debug.Log("剩余移动量哦亲，要跟时间连起来哦亲，还要注意当前的倍率哦亲");
////					break;
////				case (int)MotionType.Line:
////					Debug.Log("G01");
////					Debug.Log("剩余移动量哦亲，要跟时间连起来哦亲，还要注意当前的倍率哦亲");
////					break;
////				case (int)MotionType.Circular02:
////					Debug.Log("G02");
////					Debug.Log("剩余移动量哦亲，要跟时间连起来哦亲，还要注意当前的倍率哦亲");
////					break;
////				case (int)MotionType.Circular03:
////					Debug.Log("G03");
////					Debug.Log("剩余移动量哦亲，要跟时间连起来哦亲，还要注意当前的倍率哦亲");
////					break;
////					
////				default:
////					break;
////				}
////			}
////			//switch(compile_info_list[i].immediate_execution)
////		}
//	}
	
	public void DisplayStart()
	{
		Main.Current_F_value = true;
		Main.Current_S_value = true;
		Main.Current_T_value = true;
		Main.Current_H_value = true;
		Main.Current_D_value = true;
		Main.Current_M_value = true;
	}
	
	public void DisplayEnd()
	{
		Main.Current_F_value = false;
		Main.Current_S_value = false;
		Main.Current_T_value = false;
		Main.Current_H_value = false;
		Main.Current_D_value = false;
		Main.Current_M_value = false;
	}
	
	public void MDIStopE()
	{
		Main.MDIDisplayFindRows(0);
		Main.CodeForMDIRuning.Clear();
		Main.CodeForMDIRuning.Add("O0000");
		Main.CodeForMDIRuning.Add(";");
		if(Main.ProgMDI)
		{
			Main.CodeForAll.Clear();
			Main.CodeForAll.Add("O0000");
			Main.CodeForAll.Add(";");
			Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
			Main.ProgEDITCusorV = 0;
			Main.ProgEDITCusorH = 0;
			Main.StartRow = 0;
			Main.EndRow = SystemArguments.EditLineNumber;
			Main.SelectStart = 0;
			Main.SelectEnd = 0;
			Main.MDIpos_flag = true;
		}
		else
		{
			Main.CodeForMDI.Clear();
			Main.CodeForMDI.Add("O0000");
			Main.CodeForMDI.Add(";");
			Main.MDIProgEDITCusorV = 0;
			Main.MDIProgEDITCusorH = 0;
			Main.MDIStartRow = 0;
			Main.MDIEndRow = SystemArguments.EditLineNumber;
			Main.MDISelectStart = 0;
			Main.MDISelectEnd = 0;
			Main.MDIpos_flag = true;
		}
	}
	
//	public void EmergencyCall()
//	{
//		motion_info_list.Clear();
//	}
	
	public IEnumerator MotionStart()
	{
		CooZeroPoint = CooSystem_Script.AbsoluteZero; //获取当前绝对坐标系零点
//		Main.AutoRunning_flag = true;
		if(Main.AutoRunning_flag)
			DisplayStart();
		Main.CycleTimeH = 0;
		Main.CycleTimeM = 0;
		Main.CycleTimeS = 0;
		Auto_Script.cycling_time = 0;
		Auto_Script.runningH = Main.RunningTimeH;
		Auto_Script.runningM = Main.RunningTimeM;
		for(int index = 0; index < motion_info_list.Count; index++)
		{//1level
//			Debug.Log(index + " >>> " + motion_info_list[index].index);
			//黄色光标跳转
//			Main.autoSelecedProgRow = motion_info_list[index].index;
			if(Main.AutoRunning_flag)
				Main.AutoDisplayFindRows(motion_info_list[index].index, Main.autoDisplayNormal);
			if(Main.MDI_RunningFlag)
				Main.MDIDisplayFindRows(motion_info_list[index].index);
			Main.RunningSpeed = 0;
			Main.T_Value = Main.ToolNo;
			Main.D_value = motion_info_list[index].D_Value;
			Main.H_value = motion_info_list[index].H_Value;
			//判断是否内容为空
			if(motion_info_list[index].NotEmpty())
			{//2level
				//画面变化
				if(Main.AutoRunning_flag)
				{
					//G_Display
					ProgramModule_Script.CurrentCodeDisplay(motion_info_list[index].G_Display, motion_info_list[index].G_Address, motion_info_list[index].Address_Value, motion_info_list[index].G_Display2, motion_info_list[index].G_Address2, motion_info_list[index].Address_Value2);
					//ModalIndex, ModalString
					ProgramModule_Script.SetModalState(motion_info_list[index].ModalIndex, motion_info_list[index].ModalString);
					//运动坐标信息
				}
				//如果跳过功能启用，判断是否要跳过当前行
				if(Slash_on) {if(motion_info_list[index].Slash > 0) continue;}
				//立即执行的功能
				if(motion_info_list[index].Immediate_Motion != "")
				{
					for(int i = 0; i < motion_info_list[index].Immediate_Motion.Length; i++)
					{
						switch((char)motion_info_list[index].Immediate_Motion[i])
						{
//						case (char)ImmediateMotionType.ToolChanging:
//							Main.ToolNo = motion_info_list[index].Tool_Number;
//							break;
						case (char)ImmediateMotionType.M00:
							Auto_Script.SetPause();
							Main.AutoPause_flag = true;
							break;
						case (char)ImmediateMotionType.M01:
							if(Main.OSP_On)
							{
								Auto_Script.SetPause();
								Main.AutoPause_flag = true;
							}
							break;
						case (char)ImmediateMotionType.M02:
							Auto_Script.EmergencyCall();
							Auto_Script.StopAllCoroutines();
							Main.SpindleStop();
							Main.AutoRunning_flag = false;
							Main.RunningSpeed = 0;
							break;
						case (char)ImmediateMotionType.M03:
							CurrentModal.RotateSpeed = motion_info_list[index].SpindleSpeed;
							Main.SpindleCW((int)CurrentModal.RotateSpeed);
							Main.SpindleSpeed = (int)CurrentModal.RotateSpeed;
							break;
						case (char)ImmediateMotionType.M04:
							CurrentModal.RotateSpeed = motion_info_list[index].SpindleSpeed;
							Main.SpindleCCW((int)CurrentModal.RotateSpeed);
							Main.SpindleSpeed = (int)CurrentModal.RotateSpeed;
							break;
						case (char)ImmediateMotionType.M05:
							Main.SpindleStop();
							Main.SpindleSpeed = 0;
							break;
//						case (char)ImmediateMotionType.M06:
//							//更换刀具的过程
//							break;
						case (char)ImmediateMotionType.M07:
						case (char)ImmediateMotionType.M08:
						case (char)ImmediateMotionType.M09:
							break;
						case (char)ImmediateMotionType.M30:
							Auto_Script.EmergencyCall();
							Auto_Script.StopAllCoroutines();
							Main.SpindleStop();
							Main.AutoRunning_flag = false;
							Main.RunningSpeed = 0;
							if(Main.AutoRunning_flag)
								Main.AutoDisplayFindRows(0, Main.autoDisplayNormal);
							if(Main.MDI_RunningFlag)
								Main.MDIDisplayFindRows(0);
//							Main.autoSelecedProgRow = 0;
							break;
						case (char)ImmediateMotionType.M98:
						case (char)ImmediateMotionType.M99:
							
							break;
						case (char)ImmediateMotionType.G52:  //局部坐标系变换
							if(motion_info_list[index].CooTransformation.x == 0)
								CooSystem_Script.AbsoluteZero.x = CooZeroPoint.x;
							else
								CooSystem_Script.AbsoluteZero.x = CooZeroPoint.x - motion_info_list[index].CooTransformation.x;
							if(motion_info_list[index].CooTransformation.y == 0)
								CooSystem_Script.AbsoluteZero.y = CooZeroPoint.y;
							else
								CooSystem_Script.AbsoluteZero.y = CooZeroPoint.y - motion_info_list[index].CooTransformation.y;
							if(motion_info_list[index].CooTransformation.z == 0)
								CooSystem_Script.AbsoluteZero.z = CooZeroPoint.z;
							else
								CooSystem_Script.AbsoluteZero.z = CooZeroPoint.z - motion_info_list[index].CooTransformation.z;
							break;
						case (char)ImmediateMotionType.G53:
							//已经作为一种运动方式处理，这里直接跳过，去下面的流程中.
							break;
						case (char)ImmediateMotionType.G54: //工件坐标系设定
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G54;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G54", 13);
							break;
						case (char)ImmediateMotionType.G55:
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G55;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G55", 13);
							break;
						case (char)ImmediateMotionType.G56:
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G56;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G56", 13);
							break;
						case (char)ImmediateMotionType.G57:
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G57;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G57", 13);
							break;
						case (char)ImmediateMotionType.G58:
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G58;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G58", 13);
							break;
						case (char)ImmediateMotionType.G59:
							CooSystem_Script.workpiece_flag = (int)WorkpieceCooSys.G59;
							CooSystem_Script.Workpiece_Change();
							CooZeroPoint = CooSystem_Script.AbsoluteZero;
							CurrentModal.SetModalCode("G59", 13);
							break;
						case (char)ImmediateMotionType.G92:
							if(motion_info_list[index].CooState[0])
							{
								CooSystem_Script.AbsoluteZero.x = motion_info_list[index].CooTransformation.x - Move_Script.MachineCoo.x;
								CooZeroPoint.x = CooSystem_Script.AbsoluteZero.x;
								CooSystem_Script.RelativeZero.x = CooSystem_Script.AbsoluteZero.x;
							}
							if(motion_info_list[index].CooState[1])
							{
								CooSystem_Script.AbsoluteZero.y = motion_info_list[index].CooTransformation.y - Move_Script.MachineCoo.y;
								CooZeroPoint.y = CooSystem_Script.AbsoluteZero.y;
								CooSystem_Script.RelativeZero.y = CooSystem_Script.AbsoluteZero.y;
							}
							if(motion_info_list[index].CooState[2])
							{
								CooSystem_Script.AbsoluteZero.z = motion_info_list[index].CooTransformation.z - Move_Script.MachineCoo.z;
								CooZeroPoint.z = CooSystem_Script.AbsoluteZero.z;
								CooSystem_Script.RelativeZero.z = CooSystem_Script.AbsoluteZero.z;
							}
							break;
						case (char)ImmediateMotionType.Pause:
							//已经作为一种运动方式处理，这里直接跳过，去下面的流程中.
							break;
						case (char)ImmediateMotionType.AutoReturnRP:
							//已经作为一种运动方式处理，这里直接跳过，去下面的流程中.
							break;
						case (char)ImmediateMotionType.BackFromRP:
							//已经作为一种运动方式处理，这里直接跳过，去下面的流程中.
							break;
						case (char)ImmediateMotionType.RadiusCompensationCancel:
						case (char)ImmediateMotionType.RadiusCompensationLeft:
						case (char)ImmediateMotionType.RadiusCompensationRight:
						case (char)ImmediateMotionType.LengthCompensationCancel:
						case (char)ImmediateMotionType.LengthCompensationNegative:
						case (char)ImmediateMotionType.LengthCompensationPositive:
							
							break;
						case (char)ImmediateMotionType.RotateSpeed:
							CurrentModal.RotateSpeed = motion_info_list[index].Rotate_Speed;
							break;
						default:
							break;
						}
					}
				}
				//常规运动
				if(motion_info_list[index].Motion_Type != -1)
				{
					Main.RunningSpeed = (int)(motion_info_list[index].Velocity * Main.move_rate);
					SpeedNow = (int)motion_info_list[index].Velocity;
					Main.M_value = motion_info_list[index].M_Code;
					switch(motion_info_list[index].Motion_Type)
					{
					case (int)MotionType.DryRunning:
//						CurrentModal.SetModalCode("G00", 0);
						yield return StartCoroutine(Auto_Script.LineMovement(motion_info_list[index].Direction, motion_info_list[index].Time_Value, motion_info_list[index].VirtualTarget, index));
						break;
					case (int)MotionType.MachineCooSys:
						yield return StartCoroutine(Auto_Script.LineMovement(motion_info_list[index].Direction, motion_info_list[index].Time_Value, motion_info_list[index].VirtualTarget, index));
						break;
					case (int)MotionType.Line:
//						CurrentModal.SetModalCode("G01", 0);
						yield return StartCoroutine(Auto_Script.LineMovement(motion_info_list[index].Direction, motion_info_list[index].Time_Value, motion_info_list[index].VirtualTarget, index));
						break;
					case (int)MotionType.Circular02:
//						CurrentModal.SetModalCode("G02", 0);
						yield return StartCoroutine(Auto_Script.CircularMovement(motion_info_list[index].Direction, motion_info_list[index].VirtualTarget, motion_info_list[index].DisplayTarget,
							motion_info_list[index].DisplayStart, motion_info_list[index].Time_Value, motion_info_list[index].Center_Point, motion_info_list[index].Rotate_Speed, true, motion_info_list[index].Current_Plane, index, motion_info_list[index].Slices));
						break;
					case (int)MotionType.Circular03:
//						CurrentModal.SetModalCode("G03", 0);
						yield return StartCoroutine(Auto_Script.CircularMovement(motion_info_list[index].Direction, motion_info_list[index].VirtualTarget, motion_info_list[index].DisplayTarget,
							motion_info_list[index].DisplayStart, motion_info_list[index].Time_Value, motion_info_list[index].Center_Point, motion_info_list[index].Rotate_Speed, false, motion_info_list[index].Current_Plane, index, motion_info_list[index].Slices));
						break;
					case (int)MotionType.AutoReturnRP:
					case (int)MotionType.BackFromRP:
						yield return StartCoroutine(Auto_Script.LineMovement(motion_info_list[index].Direction, motion_info_list[index].Time_Value, motion_info_list[index].VirtualTarget, index));
						yield return StartCoroutine(Auto_Script.LineMovement(motion_info_list[index].Direction2, motion_info_list[index].Time_Value2, motion_info_list[index].VirtualTarget2, index));
						break;
					case (int)MotionType.Pause:
						Auto_Script.SetPause();
						yield return StartCoroutine(Auto_Script.PauseTimer(motion_info_list[index].Time_Value));
						break;
					default:
						Debug.Log("未知常规运动!");
						break;
					}
				}
	
			}//2level
			//Todo:解决换刀过程不能被紧急停止的功能
			for(int i = 0; i < motion_info_list[index].ToolChange_Motion.Length; i++)
			{
				switch(motion_info_list[index].ToolChange_Motion[i])
				{
				case (char)ToolChange.T:
					yield return StartCoroutine(AutoToolChange_Script.ChooseTool(motion_info_list[index].Tool_Number));
					break;
				case (char)ToolChange.M:
					if(tool_motion_list[0].TimeValue > 0)
						yield return StartCoroutine(Auto_Script.LineMovement(tool_motion_list[0].Direction, tool_motion_list[0].TimeValue, tool_motion_list[0].VirtualTarget, motion_info_list.Count + tool_motion_list.Count));
					tool_motion_list.RemoveAt(0);
					yield return StartCoroutine(AutoToolChange_Script.ChangeToolProcess());
					break;
				default:
					break;
				}
			}
			
			//单步运行
			Main.RunningSpeed = 0;
			SpeedNow = 0;
			Main.M_value = 0;
			if(Main.SingleStep)
			{
				singleStepEnd = 100;
				yield return StartCoroutine(SingleStepTimer());
			}
		}//1level
		ProgramModule_Script.SetModalState(new List<int>(), new List<string>());  //模态变化的蓝色光标清空
		if(Main.MDI_RunningFlag)
		{
			MDIStopE();
		}
		Main.AutoRunning_flag = false;
		Main.Compile_flag = false;
		Main.MDI_RunningFlag = false;
		Main.MDI_CompileFlag = false;
		Main.PartsNum++; //加工零件数+1
		DisplayEnd();
		Main.SpindleSpeed = 0;
		Main.T_Value = 0;
		Main.D_value = 0;
		Main.H_value = 0;
		ProgramModule_Script.CurrentCodeDisplay(new List<string>(), new List<string>(), new List<float>(), new List<string>(), new List<string>(), new List<float>()); //当前段和下一段显示清空
	}
	
	
	IEnumerator SingleStepTimer()
	{
		while(50 < singleStepEnd)
		{
			yield return new WaitForSeconds(0.02f);
		}
	}
	
	public void SingleStepStop()
	{
		singleStepEnd = 0;
	}
	
	void FixedUpdate()
	{
		
	}
	
}
