using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 编译数据存储结构
/// </summary>
public class DataStore
{
	public int slash_value;
	public string immediate_execution;
	public string toolChange;
	public int motion_type;
	public float x_value;
	public float y_value;
	public float z_value;
	public bool[] xyz_state;
	public float s_value;
	public float f_value;
	public float i_value;
	public float j_value;
	public float k_value;
	public bool[] ijk_state;
	public float r_value;
	public int tool_number;
	public float x_remaining_movement;
	public float y_remaining_movement;
	public float z_remaining_movement;
	public int p_value;
	public int d_value;
	public int h_value;
	
	public List<string> G_code;
	public List<int> modal_index;
	public List<string> modal_string;
	
	public DataStore()
	{
		slash_value = 0;
		immediate_execution = "";
		toolChange = "";
		motion_type = -1;
		x_value = 0;
		y_value = 0;
		z_value = 0;
		xyz_state = new bool[3]{false, false, false};
		s_value = 0;
		f_value = 0;
		i_value = 0;
		j_value = 0;
		k_value = 0;
		ijk_state = new bool[4]{false, false, false, false};
		r_value = 0;
		tool_number = 0;
		x_remaining_movement = 0;
		y_remaining_movement = 0;
		z_remaining_movement = 0;
		p_value = 0;
		d_value = 0;
		h_value = 0;
		G_code = new List<string>();
		modal_index = new List<int>();
		modal_string = new List<string>();
	}
	
	public void Clear()
	{
		slash_value = 0;
		immediate_execution = "";
		toolChange = "";
		motion_type = -1;
		x_value = 0;
		y_value = 0;
		z_value = 0;
		xyz_state[0] = false;
		xyz_state[1] = false;
		xyz_state[2] = false;
		s_value = 0;
		f_value = 0;
		i_value = 0;
		j_value = 0;
		k_value = 0;
		ijk_state[0] = false;
		ijk_state[1] = false;
		ijk_state[2] = false;
		//代表R是否有赋值
		ijk_state[3] = false;
		r_value = 0;
		tool_number = 0;
		x_remaining_movement = 0;
		y_remaining_movement = 0;
		z_remaining_movement = 0;
		p_value = 0;
		d_value = 0;
		h_value = 0;
		G_code.Clear();
		modal_index.Clear();
		modal_string.Clear();
	}
	
	public bool IsEmpty()
	{
		if(slash_value != 0 || motion_type != -1 || xyz_state[0] || xyz_state[1] || xyz_state[2])
			return false;
		else if(s_value != 0 || f_value != 0 || ijk_state[0] || ijk_state[1] || ijk_state[2] || ijk_state[3])
			return false;
		else if(tool_number != 0 || x_remaining_movement != 0 || y_remaining_movement != 0 || z_remaining_movement != 0)
			return false;
		else if(immediate_execution != "" || G_code.Count != 0 || modal_index.Count != 0 || modal_string.Count != 0)
			return false;
		else
			return true;
	}
	
	public void ImmediateAdd(char char_str)
	{
		immediate_execution += char_str;
	}
	
	public void ToolChangeAdd(char char_str)
	{
		toolChange += char_str;
	}
	
	public bool HasMotion()
	{
		if(motion_type != -1 || xyz_state[0] || xyz_state[1] || xyz_state[2])
			return true;
		else if(ijk_state[0] || ijk_state[1] || ijk_state[2] || ijk_state[3])
			return true;
		else
			return false;
	}
	
	public int MotionTypeIndex(string motion_str)
	{
		if(G_code.IndexOf("G53") != -1)
			return (int)MotionType.MachineCooSys;
		if(G_code.IndexOf("G28") != -1)
			return (int)MotionType.AutoReturnRP;
		if(G_code.IndexOf("G29") != -1)
			return (int)MotionType.BackFromRP;
		if(G_code.IndexOf("G04") != -1)
			return (int)MotionType.Pause;
		switch(motion_str)
		{
		case "G00":
			return (int)MotionType.DryRunning;
		case "G01":
			return (int)MotionType.Line;
		case "G02":
			return (int)MotionType.Circular02;
		case "G03":
			return (int)MotionType.Circular03;
		default:
			return -1;
		}
	}
	
	public Vector3 AbsolutePosition(Vector3 display_pos)
	{
		if(xyz_state[0])
			display_pos.x = x_value;
		if(xyz_state[1])
			display_pos.y = y_value;
		if(xyz_state[2])
			display_pos.z = z_value;
		return display_pos;
	}
	
	public Vector3 IncrementalPosition(Vector3 display_pos)
	{
		if(xyz_state[0])
			display_pos.x += x_value;
		if(xyz_state[1])
			display_pos.y += y_value;
		if(xyz_state[2])
			display_pos.z += z_value;
		return display_pos;	
	}
	
	public int CircleArguJudge(ref string error_string, ModalCode_Fanuc_M modal_state, ref Vector3 ijk_coo, ref float rValue)
	{
		//终点坐标在原地
		if(xyz_state[0] == false && xyz_state[1] == false && xyz_state[2] == false)
		{
			//若R有赋值，返回0停在原地
			if(ijk_state[3])
				return 0;
			//若R和IJK都没有赋值，返回0停在原地
			else if(ijk_state[0] == false && ijk_state[1] == false && ijk_state[2] == false)
				return 0;
			else
			{
				//三种平面下的判断及圆心增量坐标获取，如果返回1则为整圆情况
				switch(modal_state.PlaneCheck())
				{
				case (int)CheckInformation.XYPlane:
					if(ijk_state[2])
					{
						error_string = "平面选择与输入坐标不符";
						return -1;
					}
					else
					{
						ijk_coo = new Vector3(i_value, j_value, 0);
						return 1;
					}
				case (int)CheckInformation.ZXPlane:
					if(ijk_state[1])
					{
						error_string = "平面选择与输入坐标不符";
						return -1;
					}
					else
					{
						ijk_coo = new Vector3(i_value, 0, k_value);
						return 1;
					}
				case (int)CheckInformation.YZPlane:
					if(ijk_state[0])
					{
						error_string = "平面选择与输入坐标不符";
						return -1;
					}
					else
					{
						ijk_coo = new Vector3(0, j_value, k_value);
						return 1;
					}
				default:
					error_string = "平面选择错误，不存在这样的平面";
					return -1;
				}
			}
		}
		//有终点坐标
		else
		{
			//三种平面下的判断及圆心增量坐标和Display坐标（增量或最终值），如果返回2则为IJK，返回3则为R
			switch(modal_state.PlaneCheck())
			{
				case (int)CheckInformation.XYPlane:
				if(xyz_state[2])
				{
					error_string = "平面选择与输入坐标不符";
					return -1;
				}
				else
				{
					//有R在
					if(ijk_state[3])
					{
						rValue = r_value;
						return 3;
					}
					//没有R
					else
					{
						if(ijk_state[2])
						{
							error_string = "平面选择与输入坐标不符";
							return -1;
						}
						else
						{
							ijk_coo = new Vector3(i_value, j_value, 0);
							return 2;
						}
					}
				}
			case (int)CheckInformation.ZXPlane:
				if(xyz_state[1])
				{
					error_string = "平面选择与输入坐标不符";
					return -1;
				}
				else
				{
					//有R在
					if(ijk_state[3])
					{
						rValue = r_value;
						return 3;
					}
					//没有R
					else
					{
						if(ijk_state[1])
						{
							error_string = "平面选择与输入坐标不符";
							return -1;
						}
						else
						{
							ijk_coo = new Vector3(i_value, 0, k_value);
							return 2;
						}
					}
				}
			case (int)CheckInformation.YZPlane:
				if(xyz_state[0])
				{
					error_string = "平面选择与输入坐标不符";
					return -1;
				}
				else
				{
					//有R在
					if(ijk_state[3])
					{
						rValue = r_value;
						return 3;
					}
					//没有R
					else
					{
						if(ijk_state[0])
						{
							error_string = "平面选择与输入坐标不符";
							return -1;
						}
						else
						{
							ijk_coo = new Vector3(0, j_value, k_value);
							return 2;
						}
					}
				}
			default:
				error_string = "平面选择错误，不存在这样的平面";
				return -1;
			}
		}
	}
	
	public override string ToString ()
	{
		string G_str = "";
		if(G_code.Count > 0)
		{
			for(int i = 0; i < G_code.Count; i++)
				G_str += G_code[i] + "; ";
		}
		else
			G_str = "null";
		string Modal_str = "";
		if(modal_string.Count > 0)
		{
			for(int i = 0; i < modal_string.Count; i++)
				Modal_str += modal_string[i] + "; ";
		}
		else
			Modal_str = "null";
		return "Slash: " + slash_value + "; Immediate execution: " + immediate_execution + "; Motion: " + motion_type + "; X: " + x_value.ToString() +
			"; Y: " + y_value.ToString() + "; Z: " + z_value.ToString() + "; S: " + s_value.ToString() + "; F: " + f_value.ToString() + "; I: " + 
				i_value.ToString() + "; J: " + j_value.ToString() + "; K: " + k_value.ToString() + "; R: " + r_value.ToString() + "; T: " + tool_number.ToString() + 
				"; X_remain: " + x_remaining_movement.ToString() + "; Y_remain: " + y_remaining_movement.ToString() + "; Z_remain: " + 
				z_remaining_movement.ToString() + "; Modal_str: " + Modal_str + "; G_str: " + G_str;
	} 
	
	
}

/*
public interface IModal
{
	string[] Modal_Code{get;}
	int ModalIndex(string aim_code);
	bool SetModalCode(string aim_code, int index);
}
 */
/// <summary>
/// 模态代码数据结构，待修改，改进扩展机制
/// </summary>
public class ModalCode_Fanuc_M
{
	private string[] _modal_code;
	public string[] Modal_Code //当前模态代码
	{
		get{return _modal_code;}
	}
	public bool Slash; //跳过标志位
	public float Feedrate; //当前进给率
	public float RotateSpeed; //当前主轴转速
	public int D_Value; //当前半径补偿号
	public int H_Value; //当前长度补偿号
	private Dictionary<string, int> code_location;
	public Vector3 CooZero; //当前坐标系零点
	public Vector3 ReferencePoint;
	public bool[] referenceFlag;
	/// <summary>
	/// 普通初始化 <see cref="ModalCode_Fanuc_M"/> class.
	/// </summary>
	public ModalCode_Fanuc_M()
	{
		_modal_code = new string[]{"G00", "G94", "G80", "G17", "G21", "G98", "G90", "G40", "G50", "G22", 
			"G49", "G67", "G97", "G54", "G64", "G69", "G15", "G40.1", "G25", "G160", "G13.1", "G50.1", 
			"G54.2", "G80.5"};	
		Slash = false;
		Feedrate = 0;
		RotateSpeed = 0;
		code_location = new Dictionary<string, int>();
		LocationInitialize();
		D_Value = 0;
		H_Value = 0;
		CooZero = new Vector3(0, 0, 0);
		ReferencePoint = new Vector3(0, 0, 0);
		referenceFlag = new bool[]{false, false, false};
	}
	/// <summary>
	/// 实现复制的初始化 <see cref="ModalCode_Fanuc_M"/> class.
	/// </summary>
	/// <param name='aim_class'>
	/// 复制的目标对象
	/// </param>
	public ModalCode_Fanuc_M (ModalCode_Fanuc_M aim_class)
	{
		_modal_code = new string[]{"G00", "G94", "G80", "G17", "G21", "G98", "G90", "G40", "G50", "G22", 
			"G49", "G67", "G97", "G54", "G64", "G69", "G15", "G40.1", "G25", "G160", "G13.1", "G50.1", 
			"G54.2", "G80.5"};	
		Slash = aim_class.Slash;
		Feedrate = aim_class.Feedrate;
		RotateSpeed = aim_class.RotateSpeed;
		code_location = new Dictionary<string, int>();
		LocationInitialize();
		D_Value = aim_class.D_Value;
		H_Value = aim_class.H_Value;
		CooZero = aim_class.CooZero;
		ReferencePoint = aim_class.ReferencePoint;
		referenceFlag[0] = aim_class.referenceFlag[0];
		referenceFlag[1] = aim_class.referenceFlag[1];
		referenceFlag[2] = aim_class.referenceFlag[2];
		for(int i = 0; i < aim_class.Modal_Code.Length; i++)
		{
			_modal_code[i] = aim_class.Modal_Code[i];
		}
	}
	
	private void LocationInitialize()
	{
		string[] group01_01 = new string[]{"G0", "G00", "G1", "G01", "G2", "G02", "G3", "G03", "G33", "G75", 
			"G77", "G78", "G79"};
		string[] group05_02 = new string[]{"G93", "G94", "G95"};
		string[] group09_03 = new string[]{"G73", "G74", "G76", "G80", "G81", "G82", "G83", "G84", "G84.2", 
			"G84.3", "G85", "G86", "G87", "G88", "G89"};
		string[] group02_04 = new string[]{"G17", "G18", "G19"};
		string[] group06_05 = new string[]{"G20", "G21"};
		string[] group10_06 = new string[]{"G98", "G99"};
		string[] group03_07 = new string[]{"G90", "G91"};
		string[] group07_08 = new string[]{"G40", "G41", "G42"};
		string[] group11_09 = new string[]{"G50", "G51"};
		string[] group04_10 = new string[]{"G22", "G23"};
		string[] group08_11 = new string[]{"G43", "G44", "G49"};
		string[] group12_12 = new string[]{"G66", "G67"};
		string[] group13_13 = new string[]{"G96", "G97"};
		string[] group14_14 = new string[]{"G54", "G54.1", "G55", "G56", "G57", "G58", "G59"};
		string[] group15_15 = new string[]{"G61", "G62", "G63", "G64"};
		string[] group16_16 = new string[]{"G68", "G69"};
		string[] group17_17 = new string[]{"G15", "G16"};
		string[] group18_18 = new string[]{"G40.1", "G41.1", "G42.1"};
		string[] group25_19 = new string[]{"G25"};
		string[] group20_20 = new string[]{"G160", "G161"};
		string[] group131_21 = new string[]{"G13.1"};
		string[] group22_22 = new string[]{"G50.1", "G51.1"};
		string[] group542_23 = new string[]{"G54.2"};
		string[] group805_24 = new string[]{"G80.5"};
		List<string[]> location_group = new List<string[]>();
		location_group.Add(group01_01);
		location_group.Add(group05_02);
		location_group.Add(group09_03);
		location_group.Add(group02_04);
		location_group.Add(group06_05);
		location_group.Add(group10_06);
		location_group.Add(group03_07);
		location_group.Add(group07_08);
		location_group.Add(group11_09);
		location_group.Add(group04_10);
		location_group.Add(group08_11);
		location_group.Add(group12_12);
		location_group.Add(group13_13);
		location_group.Add(group14_14);
		location_group.Add(group15_15);
		location_group.Add(group16_16);
		location_group.Add(group17_17);
		location_group.Add(group18_18);
		location_group.Add(group25_19);
		location_group.Add(group20_20);
		location_group.Add(group131_21);
		location_group.Add(group22_22);
		location_group.Add(group542_23);
		location_group.Add(group805_24);
		for(int i = 0; i < location_group.Count; i++)
		{
			for(int j = 0; j < location_group[i].Length; j++)
			{
				code_location.Add(location_group[i][j], i);
			}
		}
	}
	
	//计算指定模态代码属于哪一类，返回int值
	public int ModalIndex(string aim_code)
	{
		if(code_location.ContainsKey(aim_code))
			return code_location[aim_code];
		else
			return -1;
	}
	
	//设定指定类型的模态代码
	public bool SetModalCode(string aim_code, int index)
	{
		if(index > 23 || index < 0)
			return false;
		else
		{
			_modal_code[index] = aim_code;
			return true;
		}
	}	
	
	//检查当前单位系统
	public int UnitCheck()
	{
		if(Modal_Code[4] == "G21")
			return (int)CheckInformation.MetricSystem;
		else
			return (int)CheckInformation.BritishSystem;
	}
	
	//检查当前平面系统
	public int PlaneCheck()
	{
		if(Modal_Code[3] == "G17")
			return (int)CheckInformation.XYPlane;
		else if(Modal_Code[3] == "G18")
			return (int)CheckInformation.ZXPlane;
		else
			return (int)CheckInformation.YZPlane;
	}
	
	//检查当前半径补偿状态
	public int RadiusCheck()
	{
		if(Modal_Code[7] == "G40")
			return (int)RadiusCompensationEnum.G40;
		else if(Modal_Code[7] == "G41")
			return (int)RadiusCompensationEnum.G41;
		else
			return (int)RadiusCompensationEnum.G42;
	}
	
	//检查当前长度补偿状态
	public int LengthCheck()
	{
		if(Modal_Code[10] == "G49")
			return (int)LengthCompensationEnum.G49;
		else if(Modal_Code[10] == "G43")
			return (int)LengthCompensationEnum.G43;
		else
			return (int)LengthCompensationEnum.G44;
	}
	
	//检查当前比例状态
	public int ScalingCheck()
	{
		if(Modal_Code[8] == "G50")
			return (int)CheckInformation.ScalingCancel;
		else
			return (int)CheckInformation.Scaling;
	}
	
	//检查当前固定循环状态
	public int FixedCycleCheck()
	{
		if(Modal_Code[2] == "G80")
			return (int)CheckInformation.FixedCycelCancel;
		else
			 return -1;
	}
	
	//检查当前是绝对坐标系统还是增量坐标系统
	public int AbsoluteCooCheck()
	{
		if(Modal_Code[6] == "G90")
			return (int)CheckInformation.AbsouteCoo;
		else
			return (int)CheckInformation.IncrementalCoo;
	}
	
	//返回当前工件坐标系
	public Vector3 LocalCoordinate()
	{
		if(Modal_Code[13] == "G54.1")
			return Vector3.zero;
		else if(Modal_Code[13] == "G54")
			return LoadCoordinate.System("G54");
		else if(Modal_Code[13] == "G55")
			return LoadCoordinate.System("G55");
		else if(Modal_Code[13] == "G56")
			return LoadCoordinate.System("G56");
		else if(Modal_Code[13] == "G57")
			return LoadCoordinate.System("G57");
		else if(Modal_Code[13] == "G58")
			return LoadCoordinate.System("G58");
		else
			return LoadCoordinate.System("G59");
	}
	
	//返回当前整体偏移坐标系
	public Vector3 EXTCoo()
	{
		Vector3 ext_coo = new Vector3(0, 0, 0);
		string coostr;
		string[]templist;
		if(PlayerPrefs.HasKey("G00"))
		{
			coostr=PlayerPrefs.GetString("G00");
			templist=coostr.Split(',');
			ext_coo.Set(float.Parse(templist[0]),float.Parse(templist[1]),float.Parse(templist[2]));
		}
		else
		{
			PlayerPrefs.SetString("G00","0,0,0");
			ext_coo.Set(0,0,0);
		}
		return ext_coo;
	}
	
	//设置当前坐标系零点
	public void SetCooZero(Vector3 zero)
	{
		CooZero.x = zero.x;
		CooZero.y = zero.y;
		CooZero.z = zero.z;
	}
}

/// <summary>
/// 静态加载工件坐标系
/// </summary>
public class LoadCoordinate
{
	public static Vector3  System(string coo_name)
	{
		Vector3 aim_vec = new Vector3(0, 0, 0);
		string coostr;
		string[]templist;
		if(PlayerPrefs.HasKey(coo_name))
		{
			coostr=PlayerPrefs.GetString(coo_name);
			templist=coostr.Split(',');
			aim_vec.Set(float.Parse(templist[0]),float.Parse(templist[1]),float.Parse(templist[2]));
		}
		else
		{
			PlayerPrefs.SetString(coo_name,"0,0,0");
			aim_vec.Set(0,0,0);
		}
		return aim_vec;
	}
}

public class MotionInfo
{
	public int index;
	public Vector3 DisplayStart;
	public Vector3 VirtualStart;
	public Vector3 DisplayTarget;
	public Vector3 VirtualTarget;
	public Vector3 VirtualTarget2;
	public Vector3 Direction;
	public Vector3 Direction2;
	public float Velocity;
	public float Rotate_Speed;
	public float Time_Value;
	public float Time_Value2;
	public Vector3 Center_Point; //暂定为Display Vector3
	public float Rotate_Degree;
	public int SpindleSpeed;
	public int Motion_Type;
	public int Current_Plane;
	public string Immediate_Motion;
	public string ToolChange_Motion;
	public int Slash;
	public int Tool_Number;
	public int D_Value;
	public int H_Value;
	public List<string> G_Display;
	public List<string> G_Display2;
	public List<string> G_Address;
	public List<string> G_Address2;
	public List<float> Address_Value;
	public List<float> Address_Value2;
	public float[]  Remaining_Movement;
	public List<int> ModalIndex;
	public List<string> ModalString;
	public Vector3 CooTransformation;
	public bool[] CooState;
	public int M_Code;
	public int RadiusCompensationInfo;
	public int LengthCompensationInfo;
	public int RadiusState;
	public int Slices;
	
	public MotionInfo()
	{
		index = 0;
		DisplayStart = new Vector3(0, 0, 0);
		VirtualStart = new Vector3(0, 0, 0);
		DisplayTarget = new Vector3(0, 0, 0);
		VirtualTarget = new Vector3(0, 0, 0);
		VirtualTarget2 = new Vector3(0, 0, 0);
		Direction = new Vector3(0, 0, 0);
		Direction2 = new Vector3(0, 0, 0);
		Velocity = 0;
		Rotate_Speed = 0;
		SpindleSpeed = 0;
		Time_Value = 0;
		Time_Value2 = 0;
		Center_Point = new Vector3(0, 0, 0);
		Rotate_Degree = 0;
		Motion_Type = -1;
		Current_Plane = (int)CheckInformation.XYPlane;
		Immediate_Motion = "";
		ToolChange_Motion = "";
		Slash = 0;
		Tool_Number = 0;
		D_Value = 0;
		H_Value = 0;
		G_Display = new List<string>();
		G_Display2 = new List<string>();
		G_Address = new List<string>();
		G_Address2 = new List<string>();
		Address_Value = new List<float>();
		Address_Value2 = new List<float>();
		ModalIndex = new List<int>();
		ModalString = new List<string>();
		Remaining_Movement = new float[3]{0, 0, 0};
		CooTransformation = new Vector3(0, 0, 0);
		CooState = new bool[]{false, false, false};
		M_Code = 0;
		RadiusCompensationInfo = (int)RadiusCompensationEnum.G40;
		LengthCompensationInfo = (int)LengthCompensationEnum.G49;
		RadiusState = (int)RadiusType.No;
		Slices = 0;
	}
	
	public void SetStartPosition(Vector3 display_pos, Vector3 virtual_pos)
	{
		DisplayStart = display_pos;
		VirtualStart = virtual_pos;
	}
	
	public void SetTargetPosition(Vector3 display_pos, Vector3 virtual_pos)
	{
		DisplayTarget = display_pos;
		VirtualTarget = virtual_pos;
	}
	
	public void SetCenterPoint(Vector3 vec)
	{
		Center_Point.x = vec.x;
		Center_Point.y = vec.y;
		Center_Point.z = vec.z;
	}
	
	public void List_Copy(List<string> g_list, List<int> modal_index_list, List<string> modal_string_list)
	{
		G_Display.Clear();
		ModalIndex.Clear();
		ModalString.Clear();
		string str_each = "";
		for(int i = 0; i < g_list.Count; i++)
		{
			str_each = g_list[i];
			G_Display.Add(str_each);
		}
		str_each = "";
		for(int i = 0; i < modal_string_list.Count; i++)
		{
			str_each = modal_string_list[i];
			ModalString.Add(str_each);
		}
//		str_each = "";
//		for(int i = 0; i < g_address.Count ; i++)
//		{
//			str_each = g_address[i];
//			G_Address.Add(str_each);
//		}
		int int_each = -1;
		for(int i = 0; i < modal_index_list.Count; i++)
		{
			int_each = modal_index_list[i];
			ModalIndex.Add(int_each);
		}
//		float float_each = 0;
//		for(int i = 0; i < address_value.Count; i++)
//		{
//			float_each = address_value[i];
//			Address_Value.Add(float_each);
//		}
	}
	
	public bool NotEmpty()
	{
		if(DisplayStart != Vector3.zero || DisplayTarget != Vector3.zero || VirtualStart != Vector3.zero || VirtualTarget != Vector3.zero || Direction != Vector3.zero)
			return true;
		else if(Velocity != 0 || Rotate_Speed != 0 || Time_Value != 0 || Rotate_Degree != 0 || Motion_Type != -1)
			return true;
		else if(Immediate_Motion != "" || Slash != 0 || Tool_Number != 0 || G_Display.Count != 0)
			return true;
		else
			return false;
	}
	
	public void SetRemainingMovement()
	{
		Remaining_Movement[0] = Mathf.Abs(Direction.x);
		Remaining_Movement[1] = Mathf.Abs(Direction.y);
		Remaining_Movement[2] = Mathf.Abs(Direction.z);
	}
	
	public bool ReasonableCoo()
	{
		if(VirtualTarget.x > 0 || VirtualTarget.x < -800f)
			return false;
		else if(VirtualTarget.y > 0 || VirtualTarget.y < -500f)
			return false;
		else if(VirtualTarget.z > 0 || VirtualTarget.z < -510f)
			return false;
		else if(VirtualTarget2.x > 0 || VirtualTarget2.x < -800f)
			return false;
		else if(VirtualTarget2.y > 0 || VirtualTarget2.y < -500f)
			return false;
		else if(VirtualTarget2.z > 0 || VirtualTarget2.z < -510f)
			return false;
		else
			return true;
	}
	
	public void MotionDataCopy(MotionInfo current_data)
	{
		index = current_data.index;
		DisplayStart = current_data.DisplayStart;
		VirtualStart = current_data.VirtualStart;
		DisplayTarget = current_data.DisplayTarget;
		VirtualTarget = current_data.VirtualTarget;
		VirtualTarget2 = current_data.VirtualTarget2;
		Direction = current_data.Direction;
		Direction2 = current_data.Direction2;
		Velocity = current_data.Velocity;
		Rotate_Speed = current_data.Rotate_Speed;
		SpindleSpeed = current_data.SpindleSpeed;
		Time_Value = current_data.Time_Value;
		Time_Value2 = current_data.Time_Value2;
		Center_Point = current_data.Center_Point;
		Rotate_Degree = current_data.Rotate_Degree;
		Motion_Type = current_data.Motion_Type;
		Current_Plane = current_data.Current_Plane;
		Immediate_Motion = current_data.Immediate_Motion;
		ToolChange_Motion = current_data.ToolChange_Motion;
		Slash = current_data.Slash;
		Tool_Number = current_data.Tool_Number;
		D_Value = current_data.D_Value;
		H_Value = current_data.H_Value;
		ListCopy_MotionData(current_data.G_Display, current_data.G_Display2, current_data.G_Address, current_data.G_Address2, current_data.ModalString, current_data.Address_Value, current_data.Address_Value2, current_data.ModalIndex);
		Remaining_Movement = new float[3]{current_data.Remaining_Movement[0], current_data.Remaining_Movement[1], current_data.Remaining_Movement[2]};
		CooTransformation = current_data.CooTransformation;
		CooState = new bool[]{current_data.CooState[0], current_data.CooState[1], current_data.CooState[2]};
		M_Code = current_data.M_Code;
		RadiusCompensationInfo = current_data.RadiusCompensationInfo;
		LengthCompensationInfo = current_data.LengthCompensationInfo;
		RadiusState = current_data.RadiusState;
	}
	
	void ListCopy_MotionData(List<string> g_display, List<string> g_display2, List<string> g_address, List<string> g_address2, List<string> modal_string, List<float> address_value, List<float> address_value2, List<int> modal_index)
	{
		G_Display.Clear();
		G_Display2.Clear();
		G_Address.Clear();
		G_Address2.Clear();
		Address_Value.Clear();
		Address_Value2.Clear();
		ModalIndex.Clear();
		ModalString.Clear();
		string str_each = "";
		for(int i = 0; i < g_display.Count; i++)
		{
			str_each = g_display[i];
			G_Display.Add(str_each);
		}
		str_each = "";
		for(int i = 0; i < g_display2.Count; i++)
		{
			str_each = g_display2[i];
			G_Display2.Add(str_each);
		}
		str_each = "";
		for(int i = 0; i < g_address.Count; i++)
		{
			str_each = g_address[i];
			G_Address.Add(str_each);
		}
		str_each = "";
		for(int i = 0; i < g_address2.Count; i++)
		{
			str_each = g_address2[i];
			G_Address2.Add(str_each);
		}
		str_each = "";
		for(int i = 0; i < modal_string.Count; i++)
		{
			str_each = modal_string[i];
			ModalString.Add(str_each);
		}
		float fla_each = 0;
		for(int i = 0; i < address_value.Count; i++)
		{
			fla_each = address_value[i];
			Address_Value.Add(fla_each);
		}
		fla_each = 0;
		for(int i = 0; i < address_value2.Count; i++)
		{
			fla_each = address_value2[i];
			Address_Value2.Add(fla_each);
		}
		int int_each = 0;
		for(int i = 0; i < modal_index.Count; i++)
		{
			int_each = modal_index[i];
			ModalIndex.Add(int_each);
		}
	}
	
	public override string ToString ()
	{
		if(Motion_Type != -2)
			return "Type: " + Motion_Type + "; Index: " +index+ "---;DisplayStart: "+DisplayStart.x+","+DisplayStart.y+","+DisplayStart.z+"; DisplayTarget: "+DisplayTarget.x+","+DisplayTarget.y+","+DisplayTarget.z+
				";---VirtualStart: "+VirtualStart.x+","+VirtualStart.y+","+VirtualStart.z+"; VirtualTarget: "+VirtualTarget.x+","+VirtualTarget.y+","+VirtualTarget.z + "; CentrePoint: " + Center_Point.x + ", " + Center_Point.y + ", "+ Center_Point.z + "; Degree: " + Rotate_Degree + "; FeedRate: " + Velocity + "; Time: " + Time_Value + "; Direction: " + Direction.x + "," + Direction.y + "," + Direction.z + "; Slices: " + Slices; 
		else
			return "";
	}
}

public class ToolChangeInfo
{
	public Vector3 Direction;
	public float TimeValue;
	public Vector3 VirtualStart;
	public Vector3 VirtualTarget;
	
	public ToolChangeInfo()
	{
		Direction = new Vector3(0, 0, 0);
		TimeValue = 0;
		VirtualStart = new Vector3(0, 0, 0);
		VirtualTarget = new Vector3(0, 0, 0);
	}
	
	public void ToolDataCopy(ToolChangeInfo targetToolInfo)
	{
		Direction = targetToolInfo.Direction;
		TimeValue = targetToolInfo.TimeValue;
		VirtualStart = targetToolInfo.VirtualStart;
		VirtualTarget = targetToolInfo.VirtualTarget;
	}
}

//加载半径补偿值
public class LoadRadiusValue
{
	public static float D_Value(int index)
	{
		index--;
		if(index == -1)
			return 0;
		else
		{
			float return_value = 0;
			if(PlayerPrefs.HasKey("shape_D"+index))
				return_value += PlayerPrefs.GetFloat("shape_D"+index);
			else
				PlayerPrefs.SetFloat("shape_D"+index,0);
			if(PlayerPrefs.HasKey("wear_D"+index))
				return_value += PlayerPrefs.GetFloat("wear_D"+index);
			else
				PlayerPrefs.SetFloat("wear_D"+index,0);
			return return_value;
		}
	}
}

//加载长度补偿值
public class LoadLengthValue
{
	public static float H_Value(int index)
	{
		index--;
		if(index == -1)
			return 0;
		else
		{
			float return_value = 0;
			if(PlayerPrefs.HasKey("shape_H"+index))
				return_value += PlayerPrefs.GetFloat("shape_H"+index);
			else
				PlayerPrefs.SetFloat("shape_H"+index,0);
			if(PlayerPrefs.HasKey("wear_H"+index))
				return_value += PlayerPrefs.GetFloat("wear_D"+index);
			else
				PlayerPrefs.SetFloat("wear_H"+index,0);
			return return_value;
		}
	}
}

//计算角度值
public class ArcCalculateDegree
{
	public static float CalculateDegree(Vector3 centre_point, Vector3 start_position, Vector3 end_position, bool cw, int plane_state)
	{
		Vector3 start_direction = start_position - centre_point;
		Vector3 end_direction = end_position - centre_point;
		float degree_value = 0;
		Vector3 standard_vec = new Vector3(0,0,0);
		//起止向量差乘
		Vector3 cross_vec = Vector3.Cross(start_direction, end_direction);
		if(plane_state == (int)CheckInformation.XYPlane)
		{
			standard_vec.x = 0;
			standard_vec.y = 0;
			standard_vec.z = 1f;
		}
		else if(plane_state == (int)CheckInformation.ZXPlane)
		{
			standard_vec.x = 0;
			standard_vec.y = 1f;
			standard_vec.z = 0;
		}
		else
		{
			standard_vec.x = 1f;
			standard_vec.y = 0;
			standard_vec.z = 0;
		}
		if(Vector3.Dot(cross_vec, standard_vec) > 0)
		{
			//大于180°CW---小于180°:CCW 	
			degree_value = Mathf.Acos(Vector3.Dot(start_direction, end_direction) / (start_direction.magnitude*end_direction.magnitude)) * 180 / Mathf.PI;
			if(cw)
				return 360f - degree_value;
			else
				return degree_value;
		}
		else if(Vector3.Dot(cross_vec, standard_vec) < 0)
		{
			//小于180°:CW ---大于180°:CCW
			degree_value = Mathf.Acos(Vector3.Dot(start_direction, end_direction) / (start_direction.magnitude*end_direction.magnitude)) * 180 / Mathf.PI;
			if(cw)
				return degree_value;
			else
				return 360f - degree_value;
		}
		else
			//等于180°
			return 180f;
	}
}