using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AutoMoveModule : MonoBehaviour {
	MoveControl MoveControlScript;
	ControlPanel Main;
	PathLineDraw PathLineDraw_Script;
	AutoToolChangeModule ToolControl_Script;
	EntranceScript Entrance_Script;
	ProgramModule Program_Script;
	Warnning Warnning_Script;
	Vector3 MachineZeroPoint = new Vector3(-0.4093075f, -0.3187108f, 1.609089f);  //相对坐标起点
	Vector3 MachineMaxPoint = new Vector3(0.3906925f, 0.1812892f, 2.119089f);  //相对坐标终点
	
	float start_time = 0f;      //时间控制：起始时间；
	float end_time = 10f;    //时间控制：终止时间；
	bool x_move = false;
	bool y_move = false;
	bool z_move = false;
	bool pause_flag = false;
	float x_velocity = 0;
	float y_velocity = 0;
	float z_velocity = 0;
	float delta_time = 0;
	float x_start_pos = 0;
	float y_start_pos = 0;
	float z_start_pos = 0;
	float x_end_pos = 0;
	float y_end_pos = 0;
	float z_end_pos = 0;
	float x_current_pos = 0;
	float y_current_pos = 0;
	float z_current_pos = 0;
	float rate = 1;
	public int machine_rate = 1;
	Transform rotate_reference;
	float auto_deltatime;
	float standard_time;
	Vector3 _targetPos = new Vector3(0, 0, 0);  //目标位置点，用虚坐标表示；
	Vector3 _direction = new Vector3(0, 0, 0);
	bool x_target_flag = false;  //用于是否要限制终点距离的判断
	bool y_target_flag = false;  //用于是否要限制终点距离的判断
	bool z_target_flag = false;  //用于是否要限制终点距离的判断
	Vector3 display_to_virtual = new Vector3(0, 0, 0);
	Vector3 centre_point = new Vector3(0, 0, 0);
	Vector3 rotate_asix = new Vector3(0, 0, 0);
	float auto_rotate_speed = 0;
	bool rotate_flag = false;
	public float cycling_time = 0;
	public int runningH = 0;
	public int runningM = 0;
	float distance_rate = 0;
	float distance_time = 0;
	float increased_slice_rate = 0;
	float basic_slice_rate = 0;
	int Slices = 0;
	float slice_rate = 0;
	int current_slice = 0;
	int current_index = -1;
	Vector3 check_position = new Vector3(0, 0, 0);
//	Vector3 original_position = new Vector3(0, 0, 0);
	
	public bool display_menu = false;
	Rect menu_rect = new Rect(0,0,0,0);
	
	// Use this for initialization
	void Start () {
		menu_rect.x = 100f;
		menu_rect.y = 300f;
		menu_rect.width = 300f;
		menu_rect.height = 180f;
		
		MoveControlScript = GameObject.Find("move_control").GetComponent<MoveControl>();
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		ToolControl_Script = GameObject.Find("ToolChange").GetComponent<AutoToolChangeModule>();
		Entrance_Script = GameObject.Find("MainScript").GetComponent<EntranceScript>();
		Program_Script = GameObject.Find("MainScript").GetComponent<ProgramModule>();
		Warnning_Script = GameObject.Find("MainScript").GetComponent<Warnning>();
//		MachineZeroPoint = new Vector3(-0.4093075f, -0.3187108f, 1.609089f);  //相对坐标起点
		MachineMaxPoint = new Vector3(0.3906925f, 0.1812892f, 2.119089f);  //相对坐标终点
		try
		{
			rotate_reference = GameObject.Find("GameObject").transform;
		}
		catch
		{
			Debug.LogError("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		rotate_reference.name = "Rotate_Reference";
		PathLineDraw_Script = GameObject.Find("Main Camera").GetComponent<PathLineDraw>();
	} 
	
	void OnGUI ()
	{
		if(display_menu)
			menu_rect = GUI.Window(55, menu_rect, AutoRate, "Auto Rate Control");
	}
	
	void AutoRate(int WindowID)
	{
		GUI.Label(new Rect(40, 20, 200, 20), "当前系统倍率: ");
		
		GUI.Box(new Rect(140, 21, 80, 20), "");
		GUI.contentColor = Color.green;
		GUI.Label(new Rect(160, 21, 80, 20), machine_rate.ToString());
		GUI.contentColor = Color.white;
		
		if(GUI.Button(new Rect(20, 50, 120, 30), "X1"))
		{
			machine_rate = 1;
			ChangeMoveRatio(1f);
		}
		
		if(GUI.Button(new Rect(170, 50, 120, 30), "X10"))
		{
			machine_rate = 10;
			ChangeMoveRatio(10f);
		}
		
		if(GUI.Button(new Rect(20, 100, 120, 30), "X100"))
		{
			machine_rate = 100;
//			rate = Main.move_rate * machine_rate;
			ChangeMoveRatio(100f);
		}
		
		if(GUI.Button(new Rect(170, 100, 120, 30), "X1000"))
		{
			machine_rate = 1000;
//			rate = Main.move_rate * machine_rate;
			ChangeMoveRatio(1000f);
		}
		
		if(GUI.Button(new Rect(110, 140, 80, 30), "关闭"))
		{
			display_menu = false;
		}
		GUI.DragWindow();
	}
	
	//从当前虚拟坐标转换到相对坐标
	Vector3 VirtualPos_RelativePos(Vector3 pos_vec)
	{
		return pos_vec / 1000 + MachineMaxPoint;
	}
	
	//从当前相对坐标转换到虚拟坐标
	Vector3 RelativePos_VirtualPos(Vector3 pos_vec)
	{
		return (pos_vec - MachineMaxPoint) * 1000;
	}
	
	//获取当前虚拟坐标, 精确到小数点后3位
	public Vector3 CurrentVirtualPos()
	{
		Vector3 CurrentVirtual = (CurrentRealPos() - MachineMaxPoint) * 1000;
		CurrentVirtual.x = (float)Math.Round(CurrentVirtual.x, 3);
		CurrentVirtual.y = (float)Math.Round(CurrentVirtual.y, 3);
		CurrentVirtual.z = (float)Math.Round(CurrentVirtual.z, 3);
		return CurrentVirtual;
	}
	
	//获取当前真实的相对坐标
	public Vector3 CurrentRealPos()
	{
		Vector3 CurrentReal = new Vector3(0, 0, 0);
		CurrentReal.x = MoveControlScript.X_part.localPosition.z; //获取X轴的相对坐标
		CurrentReal.y = MoveControlScript.Y_part.localPosition.x; //获取Y轴的相对坐标
		CurrentReal.z = MoveControlScript.Z_part.localPosition.y; //获取Z轴的相对坐标
		return CurrentReal;
	}
	
	//根据真实的相对坐标，设置各个轴的位置
	void SetPositin(Vector3 relative_pos)
	{
		if(relative_pos.x >= 0.3906925f)
			relative_pos.x = 0.3906925f;
		else if(relative_pos.x <= -0.4093075f)
			relative_pos.x = -0.4093075f;
		
		if(relative_pos.y >= 0.1812892f)
			relative_pos.y = 0.1812892f;
		else if(relative_pos.y <= -0.3187108f)
			relative_pos.y = -0.3187108f;
		
		if(relative_pos.z >= 2.119089f)
			relative_pos.z = 2.119089f;
		else if(relative_pos.z <= 1.609089f)
			relative_pos.z = 1.609089f;
		
		MoveControlScript.X_part.localPosition =  new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, relative_pos.x);
		MoveControlScript.Y_part.localPosition = new  Vector3(relative_pos.y, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
		MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, relative_pos.z, MoveControlScript.Z_part.localPosition.z);
	}
	
	/// <summary>
	/// 时间控制器，控制IEnumerator型函数的运行时间
	/// </summary>
	IEnumerator Timer()
	{
		while(start_time <= end_time)
		{
			yield return new WaitForSeconds(0.01f);
		}
		x_move = false;
		y_move = false;
		z_move = false;
		rotate_flag = false;
	}
	

	
	/// <summary>
	/// 直线插值.
	/// </summary>
	/// <returns>
	/// 转入计时器线程，进行直线插值运动，使主线程暂停.
	/// </returns>
	/// <param name='direction'>
	/// 直线运动的方向和距离
	/// </param>
	/// <param name='time_value'>
	/// 按程序Feedrate计算出来的标准运行时间.
	/// </param>
	/// <param name='target_position'>
	/// 目标位置，虚拟坐标.
	/// </param>
	public IEnumerator LineMovement(Vector3 direction, float time_value, Vector3 target_position, int lineIndex)
	{
		_targetPos = target_position;
		_direction = direction;
		start_time = 0;
		standard_time = time_value / machine_rate;
//		Debug.Log(standard_time);
//		Debug.Log(target_position.x + "," + target_position.y + "," + target_position.z);
//		Debug.Log(CurrentVirtualPos().x + "," + CurrentVirtualPos().y + "," +CurrentVirtualPos().z);
		x_end_pos = VirtualPos_RelativePos(target_position).x;
		y_end_pos = VirtualPos_RelativePos(target_position).y;
		z_end_pos = VirtualPos_RelativePos(target_position).z;
		Main.remaining_x = 0;
		Main.remaining_y = 0;
		Main.remaining_z = 0;
		rate = Main.move_rate;
		end_time = standard_time / rate;
		auto_deltatime = 0;
		distance_rate = 0;
		distance_time = 0;
		current_index = lineIndex;
		if(direction.x !=0)
		{
			Main.remaining_x = Mathf.Abs(direction.x);
			x_start_pos = MoveControlScript.X_part.localPosition.z;
			x_current_pos = x_start_pos;
			if((x_end_pos - x_start_pos) < 0)
				x_target_flag = false;
			else
				x_target_flag = true;
			x_velocity = (direction.x / 1000) / standard_time; 
			x_move = true;
		}
		if(direction.y !=0)
		{
			Main.remaining_y = Mathf.Abs(direction.y);
			y_start_pos = MoveControlScript.Y_part.localPosition.x;
			y_current_pos = y_start_pos;
			if((y_end_pos - y_start_pos) < 0)
				y_target_flag = false;
			else
				y_target_flag = true;
			y_velocity = (direction.y / 1000) / standard_time; 
			y_move = true;
		}
		if(direction.z !=0)
		{
			Main.remaining_z = Mathf.Abs(direction.z);
			z_start_pos = MoveControlScript.Z_part.localPosition.y;
			z_current_pos = z_start_pos;
			if((z_end_pos - z_start_pos) < 0)
				z_target_flag = false;
			else
				z_target_flag = true;
			z_velocity = (direction.z / 1000) / standard_time; 
			z_move = true;
		}
		yield return StartCoroutine(Timer());
		if(lineIndex != -1)
			PathLineDraw_Script.lineDrawer.RemoveCertainIndex(lineIndex, false, -2);
		SetPositin(VirtualPos_RelativePos(target_position));   //最终位置纠正;
		Main.remaining_x = 0;  //剩余移动量清零
		Main.remaining_y = 0;  //剩余移动量清零
		Main.remaining_z = 0;  //剩余移动量清零
	}
	
	/// <summary>
	/// 圆弧插值.
	/// </summary>
	/// <returns>
	/// 转入计时器线程，进行圆弧插值运动，使主线程暂停..
	/// </returns>
	/// <param name='direction'>
	/// 用于计算剩余移动量.
	/// </param>
	/// <param name='target_position'>
	/// 圆弧目标位置，虚拟坐标.
	/// </param>
	/// <param name='target_display'>
	/// 圆弧目标位置，显示坐标.
	/// </param>
	/// <param name='start_display'>
	/// 圆弧起始位置，显示坐标.
	/// </param>
	/// <param name='time_value'>
	/// 按程序Feedrate计算出来的标准运行时间..
	/// </param>
	/// <param name='center_point'>
	/// 圆心坐标，显示坐标.
	/// </param>
	/// <param name='rotate_speed'>
	/// 旋转角度.
	/// </param>
	/// <param name='rotate_direction'>
	/// 旋转方向，顺时针或者逆时针.
	/// </param>
	/// <param name='plane_choose'>
	/// XY、ZX、YZ平面选择.
	/// </param>
	public IEnumerator CircularMovement(Vector3 direction, Vector3 target_position, Vector3 target_display, Vector3 start_display, float time_value, Vector3 center_point, float rotate_speed, bool rotate_direction, int plane_choose, int lineIndex, int slices)
	{
		_direction = direction;
		_targetPos = target_position;
		display_to_virtual = target_position - target_display;
		start_time = 0;
		standard_time = time_value / machine_rate;
//		Debug.Log(standard_time);
		centre_point = center_point;
		auto_rotate_speed = rotate_speed * machine_rate; 
		//判断旋转轴
		if(plane_choose == (int)CheckInformation.XYPlane)
		{
			if(rotate_direction)
				rotate_asix = new Vector3(0, 0, -1);
			else
				rotate_asix = new Vector3(0, 0, 1);
		}
		else if(plane_choose == (int)CheckInformation.ZXPlane)
		{
			if(rotate_direction)
				rotate_asix = new Vector3(0, -1, 0);
			else
				rotate_asix = new Vector3(0, 1, 0);
		}
		else
		{
			if(rotate_direction)
				rotate_asix = new Vector3(-1, 0, 0);
			else
				rotate_asix = new Vector3(1, 0, 0);
		}
		rate = Main.move_rate;
		end_time = standard_time / rate;
		auto_deltatime = 0;
		distance_rate = 0;
		distance_time = 0;
		Slices = slices;
		basic_slice_rate = 1.0f / Slices;
		increased_slice_rate = 0;
		slice_rate = 0;
		current_slice = 0;
		current_index = lineIndex;
		SetReferencePos(start_display);
		rotate_flag = true;
//		Debug.Log(rate + ";" + Slices +";" + basic_slice_rate + ";" + current_index);
		yield return StartCoroutine(Timer());
		PathLineDraw_Script.lineDrawer.RemoveAllIndex(current_index);
		SetPositin(VirtualPos_RelativePos(target_position));   //最终位置纠正;
		Main.remaining_x = 0;  //剩余移动量清零
		Main.remaining_y = 0;  //剩余移动量清零
		Main.remaining_z = 0;  //剩余移动量清零
	}
	
	/// <summary>
	/// Pause the auto moving process.
	/// </summary>
	public void SetPause()
	{
		pause_flag = true;
	}
	
	public void ReleasePause()
	{
		pause_flag = false;
	}
	
	public bool PauseState()
	{
		if(pause_flag)
			return true;
		else
			return false;
	}
	
	public void EmergencyCall()
	{
		x_move = false;
		y_move = false;
		z_move = false;
		rotate_flag = false;
		pause_flag = false;
	}
	
	public void BeyondTrip()
	{
		EmergencyCall();
		StopAllCoroutines();
		Entrance_Script.StopAllCoroutines ();
		Entrance_Script.DisplayEnd ();
		Program_Script.SetModalState (new List<int> (), new List<string> ());  //模态变化的蓝色光标清空
		Main.AutoRunning_flag = false;
		Main.RunningSpeed = 0;
		Main.SpindleStop ();
		Main.SpindleSpeed = 0;
		Main.Compile_flag = false;
	}
	
	/// <summary>
	/// 执行G04暂停功能，使NC程序暂停.
	/// </summary>
	/// <returns>
	/// 暂停流程.
	/// </returns>
	/// <param name='timeValue'>
	/// 暂停时常，单位s.
	/// </param>
	public IEnumerator PauseTimer(float timeValue)
	{
		yield return new WaitForSeconds(timeValue);
		pause_flag = false;
	}
	
	/// <summary>
	/// 运行过程中改变倍率，总的运行时间发生变化，时间纠正.
	/// </summary>
	/// <param name='set_rate'>
	/// 重新设定的倍率.
	/// </param>
	public void ChangeMoveRatio(float set_rate)
	{
		end_time = start_time + (end_time - start_time)*rate / set_rate;  //重新计算终点时间
		rate = set_rate;
		x_start_pos = MoveControlScript.X_part.localPosition.z;
		y_start_pos = MoveControlScript.Y_part.localPosition.x;
		z_start_pos = MoveControlScript.Z_part.localPosition.y;
		auto_deltatime = 0;
	}
	
	/// <summary>
	/// 实时计算剩余移动量
	/// </summary>
	void RemainingDistance()
	{
		if(_direction.x != 0)
			Main.remaining_x = Mathf.Abs((MoveControlScript.X_part.localPosition.z - MachineMaxPoint.x)*1000 - _targetPos.x);
		if(_direction.y != 0)
			Main.remaining_y = Mathf.Abs((MoveControlScript.Y_part.localPosition.x - MachineMaxPoint.y)*1000 - _targetPos.y);
		if(_direction.z != 0)
			Main.remaining_z = Mathf.Abs((MoveControlScript.Z_part.localPosition.y - MachineMaxPoint.z)*1000 - _targetPos.z);	
	} 
	
	/// <summary>
	/// 设置旋转参考体的位置
	/// </summary>
	/// <param name='display_position'>
	/// 显示坐标（绝对坐标）
	/// </param>
	void SetReferencePos(Vector3 display_position)
	{
		rotate_reference.position = new Vector3(display_position.x, display_position.y, display_position.z);
	}
	
	//循环时间转换
	void TimeConvert(float sum_time, ref int hour, ref int minute, ref int second)
	{
		int sum_time_int = (int)sum_time;
		int temp_minute = sum_time_int / 60;
		second = sum_time_int % 60;
		hour = temp_minute / 60;
		minute = temp_minute % 60;
	}
	
	//运行时间积累
	void RunningTimeConvert(ref int hour, ref int minute)
	{
		if(minute > 60)
		{
			hour++;
			minute = minute % 60;
		}
	}
	
	void Update()
	{
		
	}
	
	
	/// <summary>
	/// 把Update换成FixedUpdate，其他都不变
	/// </summary>
	void FixedUpdate() 
	{
		//时间积累
		if(Main.AutoRunning_flag || Main.MDI_RunningFlag || ToolControl_Script.manual_tool_change)
		{
			if(pause_flag == false)
			{
				//有增加，中间如果改变倍率可能改变
				if(ToolControl_Script.manual_tool_change)
					standard_time = 1f;
				delta_time += Time.deltaTime;
				//一直在增加
				start_time += Time.deltaTime;
				//关于三维线条的显示控制
				distance_time += Time.deltaTime * rate;
				//当前时间相对于总时间的比率
				if(standard_time < 0.02f)
					distance_rate = 1f;
				else
				{
					if(distance_time / standard_time >= 1)
						distance_rate = 1;
					else
						distance_rate = distance_time / standard_time;
				}
//				Debug.Log(distance_time + "/" + standard_time + "=" + distance_rate);
				if(x_move || y_move || z_move)
				{
					//直线运行时，起点更新
					if(current_index != -1)
					{
						PathLineDraw_Script.lineDrawer.UpdateStartPoint(current_index, distance_rate);
						x_current_pos = x_start_pos + (x_end_pos - x_start_pos) * distance_rate;
						y_current_pos = y_start_pos + (y_end_pos - y_start_pos) * distance_rate;
						z_current_pos = z_start_pos + (z_end_pos - z_start_pos) * distance_rate;
						check_position = RelativePos_VirtualPos(new Vector3(x_current_pos, y_current_pos, z_current_pos));
					}
				}
				if(rotate_flag)
				{
					if(standard_time < 0.02f)
					{
						PathLineDraw_Script.lineDrawer.RemoveAllIndex(current_index);
					}
					else
					{
//						Debug.Log(distance_rate+"-"+increased_slice_rate+"/"+basic_slice_rate);
						if((distance_rate - increased_slice_rate) / basic_slice_rate >= 1)
						{
							//圆弧线段删除
							increased_slice_rate += basic_slice_rate;
							current_slice++;
//							Debug.Log(current_slice);
							PathLineDraw_Script.lineDrawer.RemoveCertainIndex(current_index, true, current_slice);
							slice_rate = 0;
						}
						else
						{
							//圆弧起点更新
							slice_rate = (distance_rate - increased_slice_rate) / basic_slice_rate;
	//						Debug.Log(slice_rate);
							PathLineDraw_Script.lineDrawer.UpdateStartPoint(current_index, slice_rate);
							
						}
					}
				}
				//自动运行的时间控制
				if(standard_time < 0.02f)
					auto_deltatime = standard_time;
				else
				{
					if(auto_deltatime + Time.deltaTime >= standard_time)
						auto_deltatime = standard_time;
					else
						auto_deltatime += Time.deltaTime;
				}
				//计算剩余移动量
				RemainingDistance();
				//循环时间记录
				cycling_time += Time.deltaTime;
				TimeConvert(cycling_time, ref Main.CycleTimeH, ref Main.CycleTimeM, ref Main.CycleTimeS);
				Main.RunningTimeH = runningH + Main.CycleTimeH;
				Main.RunningTimeM = runningM + Main.CycleTimeM;
				RunningTimeConvert(ref Main.RunningTimeH, ref Main.RunningTimeM);
//				Debug.Log(check_position.x + "; " + check_position.y + ";" + check_position.z);
				
				if(check_position.x > 0)
				{
					MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, MachineMaxPoint.x);
					BeyondTrip();
					Warnning_Script.object_description += "X轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				else if(check_position.x < -800f)
				{
						MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, MachineZeroPoint.x);
					BeyondTrip();
					Warnning_Script.object_description += "X轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				else if(check_position.y > 0)
				{
					MoveControlScript.Y_part.localPosition = new Vector3(MachineMaxPoint.y, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
					BeyondTrip();
					Warnning_Script.object_description += "Y轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				else if(check_position.y < -500f)
				{
					MoveControlScript.Y_part.localPosition = new Vector3(MachineZeroPoint.y, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
					BeyondTrip();
					Warnning_Script.object_description += "Y轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				else if(check_position.z > 0)
				{
					MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, MachineMaxPoint.z, MoveControlScript.Z_part.localPosition.z);
					BeyondTrip();
					Warnning_Script.object_description += "Z轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				else if(check_position.z < -510f)
				{
					MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, MachineZeroPoint.z, MoveControlScript.Z_part.localPosition.z);
					BeyondTrip();
					Warnning_Script.object_description += "Z轴超出最大行程，请检查程序及坐标系设定！\n";
					if(!Warnning_Script.come_forth)
						Warnning_Script.motion_start = true;
				}
				
			}
			
//			if(check_position.x*1000 < -0.8f || check_position.x*1000 > 0)
//			{
//				BeyondTrip();
//				Warnning_Script.object_description += "X轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else if(check_position.y*1000 < -0.5f || check_position.y*1000 > 0)
//			{
//				BeyondTrip();
//				Warnning_Script.object_description += "Y轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else if(check_position.z*1000 < -0.51f || check_position.z*1000 > 0)
//			{
//				BeyondTrip();
//				Warnning_Script.object_description += "Z轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
		}
		
		/*
		if(x_move && pause_flag == false)
		{
			//如果在运行过程中改变了倍率，总的路程不变，时间和速度变
			cube.localPosition = new Vector3(x_start_pos + x_velocity*delta_time*rate, cube.localPosition.y, cube.localPosition.z);
			//增加一个距离位置的判断，以避免在运行中超过设定的位置，根据速度判断正负
			//注意，为考虑到行程不够的情况
			if(cube.localPosition.x >= 0.57825f)
				cube.localPosition = new Vector3(0.57825f, cube.localPosition.y, cube.localPosition.z);
		}
		
		if(y_move && pause_flag == false)
		{
			cube.localPosition = new Vector3(cube.localPosition.x, y_start_pos + y_velocity*delta_time*rate, cube.localPosition.z);
			//增加一个距离位置的判断，以避免在运行中超过设定的位置，根据速度判断正负
			//注意，为考虑到行程不够的情况
			if(cube.localPosition.y >= 8.245f)
				cube.localPosition = new Vector3(cube.localPosition.x, 8.245f, cube.localPosition.z);
		}
		
		if(z_move && pause_flag == false)
		{
			//增加一个距离位置的判断，以避免在运行中超过设定的位置，根据速度判断正负
			//注意，为考虑到行程不够的情况
			cube.localPosition = new Vector3(cube.localPosition.x, cube.localPosition.y, z_start_pos + z_velocity*delta_time*rate);
		}
		*/
		
		
//		Debug.Log(check_position.x + "; " + check_position.y + ";" + check_position.z);
		
		//X轴移动
		if(x_move && pause_flag == false)
		{
			MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, x_start_pos + x_velocity*auto_deltatime*rate);
//			//AUTO运行超出量程报警:X
//			if(MoveControlScript.X_part.localPosition.z - MachineZeroPoint.x > 0.8f)
//			{
//				MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, MachineMaxPoint.x);
//				BeyondTrip();
//				Warnning_Script.object_description += "X轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else if(MoveControlScript.X_part.localPosition.z - MachineZeroPoint.x < 0)
//			{
//				MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, MachineZeroPoint.x);
//				BeyondTrip();
//				Warnning_Script.object_description += "X轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else
//			{
				//X轴运行精度控制，不允许超程
				if(x_target_flag)
				{
					if((x_end_pos - MoveControlScript.X_part.localPosition.z) < 0)
						MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, x_end_pos);
				}
				else
				{
					if((x_end_pos - MoveControlScript.X_part.localPosition.z) > 0)
						MoveControlScript.X_part.localPosition = new Vector3(MoveControlScript.X_part.localPosition.x, MoveControlScript.X_part.localPosition.y, x_end_pos);
				}
//			}	
		}
		
		//Y轴移动
		if(y_move && pause_flag == false)
		{
			MoveControlScript.Y_part.localPosition = new Vector3(y_start_pos + y_velocity*auto_deltatime*rate, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
//			//AUTO运行超出量程报警:Y
//			if(MoveControlScript.Y_part.localPosition.x - MachineZeroPoint.y > 0.5f)
//			{
//				MoveControlScript.Y_part.localPosition = new Vector3(MachineMaxPoint.y, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
//				BeyondTrip();
//				Warnning_Script.object_description += "Y轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else if(MoveControlScript.Y_part.localPosition.x - MachineZeroPoint.y < 0)
//			{
//				MoveControlScript.Y_part.localPosition = new Vector3(MachineZeroPoint.y, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
//				BeyondTrip();
//				Warnning_Script.object_description += "Y轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else
//			{
				//Y轴运行精度控制，不允许超程
				if(y_target_flag)
				{
					if((y_end_pos - MoveControlScript.Y_part.localPosition.x) < 0)
						MoveControlScript.Y_part.localPosition = new Vector3(y_end_pos, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
				}
				else
				{
					if((y_end_pos - MoveControlScript.Y_part.localPosition.x) > 0)
						MoveControlScript.Y_part.localPosition = new Vector3(y_end_pos, MoveControlScript.Y_part.localPosition.y, MoveControlScript.Y_part.localPosition.z);
				}
//			}
		}
		
		//Z轴移动
		if(z_move && pause_flag == false)
		{
			MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, z_start_pos + z_velocity*auto_deltatime*rate, MoveControlScript.Z_part.localPosition.z);
//			//AUTO运行超出量程报警:Z
//			if(MoveControlScript.Z_part.localPosition.y - MachineZeroPoint.z > 0.51f)
//			{
//				MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, MachineMaxPoint.z, MoveControlScript.Z_part.localPosition.z);
//				BeyondTrip();
//				Warnning_Script.object_description += "Z轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else if(MoveControlScript.Z_part.localPosition.y - MachineZeroPoint.z < 0)
//			{
//				MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, MachineZeroPoint.z, MoveControlScript.Z_part.localPosition.z);
//				BeyondTrip();
//				Warnning_Script.object_description += "Z轴超出最大行程，请检查程序及坐标系设定！\n";
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
//			}
//			else
//			{
				//Z轴运行精度控制，不允许超程
				if(z_target_flag)
				{
					if((z_end_pos - MoveControlScript.Z_part.localPosition.y) < 0)
						MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, z_end_pos, MoveControlScript.Z_part.localPosition.z);
				}
				else
				{
					if((z_end_pos - MoveControlScript.Z_part.localPosition.y) > 0)
						MoveControlScript.Z_part.localPosition = new Vector3(MoveControlScript.Z_part.localPosition.x, z_end_pos, MoveControlScript.Z_part.localPosition.z);
				}
//			}
		}
		
		//旋转插值
		if(rotate_flag && pause_flag == false)
		{
			rotate_reference.RotateAround(centre_point, rotate_asix, auto_rotate_speed*Time.deltaTime*rate);  
			check_position = rotate_reference.position + display_to_virtual;
			SetPositin(VirtualPos_RelativePos(rotate_reference.position + display_to_virtual));
		}
	}
	
	// 测试用
//	void Update () {
//		if(Input.GetKeyUp(KeyCode.A))
//		{
//			SetPositin(VirtualPos_RelativePos(Vector3.zero));
//			SetReferencePos(MoveControlScript.MachineCoo);   //设置旋转参考object位置
//		}
//		
//		if(Input.GetKeyUp(KeyCode.S))
//		{
//			SetPositin(VirtualPos_RelativePos(new Vector3(-100, -50, -99)));
//		}
//		
//		if(Input.GetKeyUp(KeyCode.D))
//		{
//			SetPositin(VirtualPos_RelativePos(new Vector3(-555.621f, -300f, -412.325f)));
//		}
//		
//	}
}