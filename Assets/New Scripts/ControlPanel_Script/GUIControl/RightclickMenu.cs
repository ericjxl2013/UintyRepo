using UnityEngine;
using System.Collections;

public class RightclickMenu : MonoBehaviour {
	ControlPanel Main;
	camera_sm Camera_Script;
	DisplayMode DisplayMode_Script;
	public bool rightclick_menu_on = false;
	Rect rightclick_rect;
	float menu_height = 25f;
	float menu_subsection = 16f;
	
	public const int DISPLAYMODE = 0;
	public const int CAMERA_LEFT = 1;
	public const int CAMERA_RIGHT = 2;
	public const int CAMERA_FACELOOK = 3;
	public const int CAMERA_OVERLOOK = 4;
	public const int PRESET_ONE = 5;
	public const int PRESET_TWO = 6;
	public const int CAMERA_CUSTOM = 7;
	public const int CUSTOM_SETTINGS = 8;
	int current_state = -1;
	// Use this for initialization
	void Start () {
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		Camera_Script = GameObject.Find("Main Camera").GetComponent<camera_sm>();
		DisplayMode_Script = GameObject.Find("MainScript").GetComponent<DisplayMode>();
		rightclick_rect = new Rect(0, 0, 200f, 248f);
		current_state = -1;
	}
	
	void OnGUI ()
	{
		Event mouse_e = Event.current;
		if(Main.panelWindowOnly)
		{
			if(!Main.PanelWindowRect.Contains(mouse_e.mousePosition) && mouse_e.isMouse && 
				mouse_e.type == EventType.MouseDown && mouse_e.button == 1 && !Input.GetMouseButton(2))
			{
				rightclick_menu_on = true;
				rightclick_rect.x = mouse_e.mousePosition.x;
				rightclick_rect.y = mouse_e.mousePosition.y;
			}
		}
		else
		{
			if(!Main.screenRect.Contains(mouse_e.mousePosition) && mouse_e.isMouse && 
				mouse_e.type == EventType.MouseDown && mouse_e.button == 1 && !Input.GetMouseButton(2))
			{
				rightclick_menu_on = true;
				rightclick_rect.x = mouse_e.mousePosition.x;
				rightclick_rect.y = mouse_e.mousePosition.y;
			}
		}
		
		if(mouse_e.isMouse && mouse_e.type == EventType.MouseDown && mouse_e.button != 1)
		{
			rightclick_menu_on = false;
		}
		
		if(rightclick_menu_on)
		{
			rightclick_rect = GUI.Window(4, rightclick_rect, RightClickMenu, "", Main.sty_Rightclick);
			GUI.BringWindowToFront(1);
		}
	}
	
	void RightClickMenu(int WindowID)
	{
		Event rightclick_e = Event.current;
//		GUI.contentColor = Color.black;
//		GUI.Box(new Rect(2, 2, 146, 25), "");
		if(new Rect(0, 0, 200, 27).Contains(rightclick_e.mousePosition))
			current_state = DISPLAYMODE;
		else if(new Rect(0, 2+(CAMERA_LEFT-1)*menu_height+2*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_LEFT;
		else if(new Rect(0, 2+(CAMERA_RIGHT-1)*menu_height+2*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_RIGHT;
		else if(new Rect(0, 2+(CAMERA_FACELOOK-1)*menu_height+2*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_FACELOOK;
		else if(new Rect(0, 2+(CAMERA_OVERLOOK-1)*menu_height+2*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_OVERLOOK;
		else if(new Rect(0, 2+(PRESET_ONE-2)*menu_height+4*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = PRESET_ONE;
		else if(new Rect(0, 2+(PRESET_TWO-2)*menu_height+4*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = PRESET_TWO;
		else if(new Rect(0, 2+(CAMERA_CUSTOM-2)*menu_height+4*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CAMERA_CUSTOM;
		else if(new Rect(0, 2+(CUSTOM_SETTINGS-2)*menu_height+4*menu_subsection, 200, 25).Contains(rightclick_e.mousePosition))
			current_state = CUSTOM_SETTINGS;
		else
			current_state = -1;
		
		switch(current_state)
		{
		case DISPLAYMODE:
			GUI.Label(new Rect(0, 0, 194, 27), "", Main.sty_RightCursor);
			break;
		case CAMERA_LEFT:
			GUI.Label(new Rect(0, 2+(CAMERA_LEFT-1)*menu_height+2*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case CAMERA_RIGHT:
			GUI.Label(new Rect(0, 2+(CAMERA_RIGHT-1)*menu_height+2*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case CAMERA_FACELOOK:
			GUI.Label(new Rect(0, 2+(CAMERA_FACELOOK-1)*menu_height+2*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case CAMERA_OVERLOOK:
			GUI.Label(new Rect(0, 2+(CAMERA_OVERLOOK-1)*menu_height+2*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case PRESET_ONE:
			GUI.Label(new Rect(0, 2+(PRESET_ONE-2)*menu_height+4*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case PRESET_TWO:
			GUI.Label(new Rect(0, 2+(PRESET_TWO-2)*menu_height+4*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case CAMERA_CUSTOM:
			GUI.Label(new Rect(0, 2+(CAMERA_CUSTOM-2)*menu_height+4*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		case CUSTOM_SETTINGS:
			GUI.Label(new Rect(0, 2+(CUSTOM_SETTINGS-2)*menu_height+4*menu_subsection, 194, 25), "", Main.sty_RightCursor);
			break;
		default:
			break;
		}
		
		GUI.Label(new Rect(4, 4, 146, 25), DisplayMode_Script.display_str, Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4, 50, 25), "Ctrl + H", Main.sty_RightclickFont);
		
		GUI.Label(new Rect(2, 9+menu_subsection, 190, 10), "", Main.sty_RightLine);
		
		GUI.Label(new Rect(4, 4+(CAMERA_LEFT-1)*menu_height+2*menu_subsection, 146, 25), "左视图", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CAMERA_LEFT-1)*menu_height+2*menu_subsection, 146, 25), "Ctrl + ←", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(CAMERA_RIGHT-1)*menu_height+2*menu_subsection, 146, 25), "右视图", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CAMERA_RIGHT-1)*menu_height+2*menu_subsection, 146, 25), "Ctrl + →", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(CAMERA_FACELOOK-1)*menu_height+2*menu_subsection, 146, 25), "正视图", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CAMERA_FACELOOK-1)*menu_height+2*menu_subsection, 146, 25), "Ctrl +  ↑", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(CAMERA_OVERLOOK-1)*menu_height+2*menu_subsection, 146, 25), "俯视图", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CAMERA_OVERLOOK-1)*menu_height+2*menu_subsection, 146, 25), "Ctrl +  ↓", Main.sty_RightclickFont);
		
		GUI.Label(new Rect(2, 9+(CAMERA_OVERLOOK-1)*menu_height+3*menu_subsection, 190, 10), "", Main.sty_RightLine);

		GUI.Label(new Rect(4, 4+(PRESET_ONE-2)*menu_height+4*menu_subsection, 146, 25), "预设视角1", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(PRESET_ONE-2)*menu_height+4*menu_subsection, 146, 25), "Ctrl + F1", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(PRESET_TWO-2)*menu_height+4*menu_subsection, 146, 25), "预设视角2", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(PRESET_TWO-2)*menu_height+4*menu_subsection, 146, 25), "Ctrl + F2", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(CAMERA_CUSTOM-2)*menu_height+4*menu_subsection, 146, 25), "自定义视角", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CAMERA_CUSTOM-2)*menu_height+4*menu_subsection, 146, 25), "Ctrl + F3", Main.sty_RightclickFont);

		GUI.Label(new Rect(4, 4+(CUSTOM_SETTINGS-2)*menu_height+4*menu_subsection, 146, 25), "当前视角设定", Main.sty_RightclickFont);
		GUI.Label(new Rect(137, 4+(CUSTOM_SETTINGS-2)*menu_height+4*menu_subsection, 146, 25), "Ctrl + F4", Main.sty_RightclickFont);
		
		if(rightclick_e.isMouse && rightclick_e.type == EventType.MouseDown && rightclick_e.button == 0 && current_state != -1)
		{
			if(current_state == DISPLAYMODE)
			{
				DisplayMode_Script.DisplayModeChange();
			}
			else
				Camera_Script.CameraMode(current_state);
			rightclick_menu_on = false;
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
