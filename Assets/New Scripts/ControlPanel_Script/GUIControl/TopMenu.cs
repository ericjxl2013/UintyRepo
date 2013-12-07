using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TopMenu : MonoBehaviour
{
	const int MenuNumber = 8; //增加恢复出厂设置
	float btn_width = 100f;
	float btn_height = 45f;
	float btn_start_pos = 250f;  //300f改成250f    更改 BY王广官
	string[] btn_name = new string[] {"隐藏机床外壳", "视图控制", "轨迹线控制", "刀具控制", "机床速率控制", "毛坯控制", "恢复出厂设置","退出程序"};
	private float dynamic_height = 0;
	private float min_height = 0;
	private float max_height = 0;
	private int name_index = 0;
	private bool menu_show = false;
	private bool menu_hide = true;
	private float menu_speed = 16f;
	private float display_speed = 0;
	private Rect menu_rent = new Rect (0, 0, 0, 0);
	DisplayMode DisplayMode_Script;
	camera_sm Camera_Script;
	PathLineDraw PathLineDraw_Script;
	AutoToolChangeModule ToolChange_Script;
	ControlPanel Main;
	AutoMoveModule AutoMove_Script;
	RightclickMenu RightclickMenu_Script;
	ProgramReset Reset_Script;

	// Use this for initialization
	void Start ()
	{
		DisplayMode_Script = gameObject.GetComponent<DisplayMode> ();
		Camera_Script = GameObject.Find ("Main Camera").GetComponent<camera_sm> ();
		PathLineDraw_Script = GameObject.Find ("Main Camera").GetComponent<PathLineDraw> ();
		ToolChange_Script = GameObject.Find ("ToolChange").GetComponent<AutoToolChangeModule> ();
		AutoMove_Script = GameObject.Find ("AutoMove").GetComponent<AutoMoveModule> ();
		RightclickMenu_Script = GameObject.Find("MainScript").GetComponent<RightclickMenu>();
		Main = gameObject.GetComponent<ControlPanel> ();
		Reset_Script = gameObject.GetComponent <ProgramReset>();
		dynamic_height = -btn_height;
		min_height = -btn_height;
		max_height = 0;
	}
	
	void OnGUI ()
	{
		for (int i =0; i < MenuNumber; i++) {
			if (i >= btn_name.Length) {
				name_index = i % btn_name.Length;
			} else
				name_index = i;
			if (GUI.Button (new Rect (btn_start_pos + i * btn_width, dynamic_height, btn_width, btn_height), btn_name [name_index])) {
				if (i == 0) {
					DisplayMode_Script.DisplayModeChange();
					btn_name[0] = DisplayMode_Script.display_str;
				}
				if (i == 1)
					Camera_Script.display_menu = true;
				
				if (i == 2)
					PathLineDraw_Script.display_menu = true;
				
				if (i == 3)
					ToolChange_Script.display_menu = true;
				
				if (i == 4)
					AutoMove_Script.display_menu = true;
				
				if(i == 6)
					Reset_Script.display_menu = true;
				
				if (i == 7) {
					PlayerPrefs.SetInt ("RunningTimeH", Main.RunningTimeH);
					PlayerPrefs.SetInt ("RunningTimeM", Main.RunningTimeM);
					PlayerPrefs.SetInt ("PartsNum", Main.PartsNum);
					Application.Quit ();
				}
//				Debug.Log(btn_name[name_index]);
				if(RightclickMenu_Script.rightclick_menu_on)
					RightclickMenu_Script.rightclick_menu_on = false;
			}
		}
		
		Event e = Event.current;
		if (menu_rent.Contains (e.mousePosition)) {
			menu_hide = false;
		} else
			menu_hide = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		menu_rent.x = btn_start_pos;
		menu_rent.y = dynamic_height;
		menu_rent.width = btn_start_pos + MenuNumber * btn_width;
		menu_rent.height = btn_height;
		
		//top_show
		if (Input.mousePosition.y >= Screen.height - 1) {	
			if (Mathf.Approximately (dynamic_height, -btn_height))
				menu_show = true;
		}
		
		//top_show	
		if (menu_show) {
			display_speed += 0.003F * menu_speed;
			dynamic_height = Mathf.Lerp (min_height, max_height, display_speed);
			if (Mathf.Approximately (dynamic_height, max_height)) {
				menu_show = false;
				max_height = min_height;
				min_height = dynamic_height;
				display_speed = 0;
			}
		}

		if (menu_hide && Input.GetMouseButtonDown (0)) {
			if (Mathf.Approximately (dynamic_height, 0)) {										
				menu_show = true;						
			}
		}
	}
}
