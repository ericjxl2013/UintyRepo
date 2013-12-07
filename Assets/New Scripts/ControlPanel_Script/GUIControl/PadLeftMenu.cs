using UnityEngine;
using System.Collections;

public class PadLeftMenu : MonoBehaviour {
	ControlPanel Main;
	ClientCenter Client_Script;
	camera_sm Camera_Script;
	ClampControl ClampControl_Script;
	HandWheelModule HandWheel_Script;
	
	Rect win_rect;
	Rect btnRect;
	bool menu_on = false;  //Determine whether the menu is on
	float time_value = 0;  //the speed control parameter
	float left = 0;  //the x parameter of the window rect
	bool motion_on = false;  //if the window is moving, the the parameter is true
	bool menu_state = false;  //the state of current menu
	float finger_press_time = 0;  //parameter to determine when to show the menu
	bool finger_on = false;  //if finger is on the screen
	string display_str = "隐藏机床外壳";  //Current machine showing state
	string[] menuName;
	int menuNumber = 11;
	float menuSeparation = 0;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		Client_Script = gameObject.GetComponent<ClientCenter>();
		Camera_Script = GameObject.Find("Main Camera").GetComponent<camera_sm>();
		ClampControl_Script = gameObject.GetComponent<ClampControl>();
		HandWheel_Script = GameObject.Find ("HandleControl").GetComponent<HandWheelModule> ();
		
		win_rect = new Rect(-200f, 0, 200f, 660f);
		btnRect = new Rect(0, 255f, 30f, 130f);
		left = -200f;
		win_rect.y = Screen.height/2 - win_rect.height/2;
		btnRect.y = Screen.height/2 - btnRect.height/2;
		menuName = new string[]{display_str, "左视图", "右视图", "正视图", "俯视图", "预设视角1", "预设视角2", "自定义视角", "自定义视角设定",  "结束当前工步",  "主轴刀具卸载", "毛坯管理"};
		menuNumber = menuName.Length;
		menuSeparation = win_rect.height/menuNumber;
	}
	
	void OnGUI ()
	{
		if(motion_on)
		{
			win_rect.x = left;
			btnRect.x = left + 201f;
		}
		if(!Client_Script.client_window_on)
			GUI.Window(4, win_rect, RightClickMenu, "", Main.sty_Rightclick);
		if(!Client_Script.client_window_on)
			GUI.Window(16, btnRect, ButtonWindow, "", Main.sty_ButtonEmpty);
		
//		Event mouse_e = Event.current;
//		if (mouse_e.isMouse && mouse_e.type == EventType.MouseDown && mouse_e.button == 0 && mouse_e.clickCount == 2) {
//			if(!Client_Script.client_window_on && menu_state && !motion_on)
//				motion_on = true;
//		}
	}
	
	void RightClickMenu(int WindowID)
	{
		for(int i = 0; i < menuNumber; i++)
		{
			if(GUI.Button(new Rect(0, i*menuSeparation, 200, menuSeparation), menuName[i], Main.sty_RightclickFont))
			{
				ButtonClick(i);
			}
			if(i != 0)
				GUI.Label(new Rect(2, i*menuSeparation - 5f, 196, 10), "", Main.sty_RightLine);
		}
	}
	
	void ButtonWindow(int WindowID){
		if(GUI.Button(new Rect(1f, 1f, 28, 128f), "", Main.sty_Arrow)){
			if(menu_on){
				Main.sty_Arrow.normal.background = Main.t2d_ArrowR;
			}else{
				Main.sty_Arrow.normal.background = Main.t2d_ArrowL;
			}
			if(!menu_on)
			{
				win_rect.x = -win_rect.width;
				left = -win_rect.width;
				menu_on = true;
			}
			motion_on = true;
		}
	}
	
	void ButtonClick(int index)
	{
		switch(index)
		{
		case 0:
			networkView.RPC("DisplayModeChange", RPCMode.Server);
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			networkView.RPC("CameraControlRPC", RPCMode.Server, index);
			break;
		case 9:
			networkView.RPC("ProcedureStop", RPCMode.Server);
			break;
		case 10:
			networkView.RPC("ToolUnloadRPC", RPCMode.Server);
			break;
		case 11:
			networkView.RPC("ClampWindowRPC", RPCMode.Server);
			break;
		default:
			break;
		}
//		ClosePadMenu();
	}
	
	[RPC]
	void ClampWindowRPC()
	{
		
	}
	[RPC]
	void ClampWindowOn(string info)
	{
		string[] info_array = info.Split(',');
		ClampControl_Script.blankLengthValue = float.Parse(info_array[0]);
		ClampControl_Script.blankLength = info_array[0];
		ClampControl_Script.blankWidthValue = float.Parse(info_array[1]);
		ClampControl_Script.blankWidth = info_array[1];
		ClampControl_Script.blankHeightValue = float.Parse(info_array[2]);
		ClampControl_Script.blankHeight = info_array[2];
		ClampControl_Script.menuDisplay = true;
		ClampControl_Script.ClampTypeInitialize(int.Parse(info_array[3]));
	}
	
	void ClosePadMenu()
	{
		motion_on = false;
		menu_state = false;
		menu_on = false;
		finger_on = false;
		finger_press_time = 0;
		win_rect.x = -win_rect.width - 1f;
		left = -win_rect.width - 1f;
	}
	
	[RPC]
	void DisplayModeChange()
	{
	}
	[RPC]
	void DisplayString(string name)
	{
		menuName[0] = name;
	}
	
	[RPC]
	void CameraControlRPC(int state)
	{
		
	}
	
	[RPC]
	void ToolUnloadRPC()
	{
		
	}
	
	[RPC]
	void ProcedureStop()
	{
	}
	
	
	/// <summary>
	/// Pad左侧菜单控制
	/// </summary>
//	void Update()
//	{
//		//手指触摸
//		if(Input.touchCount > 0)
//		{
//			//第一根手指触摸
//			if(Input.GetTouch(0).phase == TouchPhase.Began)
//			{
//				finger_press_time = 0;
//				finger_on = true;
//			}
//			
//			//一根手指连续触摸，开始计时，0.8秒后出现
//			if(Input.GetTouch(0).phase == TouchPhase.Stationary && finger_on)
//			{
//				finger_press_time += Time.deltaTime;
//				if(finger_press_time > 0.8f && !Client_Script.client_window_on)
//				{
//					if(!menu_on && !motion_on && !Main.rect_contain && HandWheel_Script.move_flag)
//					{
////						win_rect.y = Screen.height/2 - win_rect.height/2;
//						win_rect.x = -win_rect.width;
//						left = -win_rect.width;
//						menu_on = true;
//						motion_on = true;
//					}
//					finger_on = false;
//					finger_press_time = 0;
//				}
//			}
//		}
//		
//		if(Input.GetKeyDown(KeyCode.A))
//		{
//			if(!menu_on)
//			{
//				win_rect.x = -win_rect.width;
//				left = -win_rect.width;
//				menu_on = true;
//			}
//			motion_on = true;
//		}
//	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(motion_on)
		{
			if(menu_state)  //菜单进去
			{
				time_value += Time.deltaTime;
				left = Mathf.Lerp(win_rect.x, -200f, 1.5f*time_value);
				if(1.5f*time_value > 1f)
				{
					time_value = 0; 
					btnRect.x = 1f;
//					win_rect.y = Screen.height/2 - win_rect.height/2;
					motion_on = false;
					menu_state = false;
					menu_on = false;
//					Main.sty_Arrow.normal.background = Main.t2d_ArrowR;
				}
			}
			else  //菜单出来
			{
				time_value += Time.deltaTime;
				left = Mathf.Lerp(-200f, 0, 3*time_value);
				if(3*time_value > 1f)
				{
					win_rect.x = 0;
					btnRect.x = 201f;
					time_value = 0; 
					motion_on = false;
					menu_state = true;
//					Main.sty_Arrow.normal.background = Main.t2d_ArrowL;
				}
			}
		}
	}
}
