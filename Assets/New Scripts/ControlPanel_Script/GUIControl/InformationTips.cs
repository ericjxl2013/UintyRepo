using UnityEngine;
using System.Collections;

public class InformationTips : MonoBehaviour
{
	ControlPanel Main;
	AutoToolChangeModule ToolControl_Script;
	public bool tool_information_tips_on = false;
	public bool omg = false;
	public Rect information_tips_rect;
	public string toolNum = "";
	public string apronNum = "";
	public string toolName = "";
//	private float three = 0;
	// Use this for initialization
	void Start ()
	{
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		ToolControl_Script = GameObject.Find("ToolChange").GetComponent<AutoToolChangeModule>();
		information_tips_rect = new Rect(20, 20, 240, 70);
		tool_information_tips_on = false;
	}
	
	void OnGUI ()
	{
		if(tool_information_tips_on)
		{
			Event e = Event.current;
			if(e.isMouse && e.type == EventType.MouseDown && e.clickCount == 1 && e.button == 0)
			{
				//判断当前条件是否允许手动换刀
				if(ToolControl_Script.ConditionPermits() && apronNum != "主轴")
				{
					StartCoroutine(ToolControl_Script.ManualToolChange(toolNum));
				}
			}
			information_tips_rect.x = Input.mousePosition.x + 12f;
			information_tips_rect.y = Screen.height - Input.mousePosition.y + 4f;
			GUI.Window(6, information_tips_rect, InformationTipsControl, "", Main.sty_ToolTip);
			GUI.BringWindowToFront(1);
		}
	}
	
	void InformationTipsControl(int WindowID)
	{
		GUI.Label(new Rect(28, 7, 50, 30), "刀  具  号: ", Main.sty_InformationTipsColorFont2);
		GUI.Label(new Rect(28, 28, 50, 30), "刀  位  号: ", Main.sty_InformationTipsColorFont2);
		GUI.Label(new Rect(29, 46, 50, 30), "刀具名称", Main.sty_InformationTipsColorFont2);
		GUI.Label(new Rect(83, 46, 50, 30), ": ", Main.sty_InformationTipsColorFont2);
		
		GUI.Label(new Rect(115, 7, 50, 30), toolNum, Main.sty_InformationTipsColorFont);
		GUI.Label(new Rect(115, 28, 50, 30), apronNum, Main.sty_InformationTipsColorFont);
		GUI.Label(new Rect(115, 46, 100, 30), toolName, Main.sty_InformationTipsColorFont);
	}
	
}
