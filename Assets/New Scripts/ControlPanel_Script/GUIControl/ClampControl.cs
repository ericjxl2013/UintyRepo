using UnityEngine;
using System.Collections;

public enum ClampType{Tongs = 0, Direct, Plate};

public class ClampControl : MonoBehaviour {
	ControlPanel Main;
	ModelInitialize Model_Script;
	Warnning Warnning_Script;
	public bool menuDisplay = false;
	Rect clampRect = new Rect(0, 0, 434f, 418f);
	public string blankLength;
	public string blankWidth;
	public string blankHeight;
	public float blankLengthValue;
	public float blankWidthValue;
	public float blankHeightValue;
	float lengthTemp = 0;
	float widthTemp = 0;
	float heightTemp = 0;
	
	public bool ClampOn = false;
	public bool BlankOn = false;
	public int ClampTypeFlag;
	
	Vector3 ClampPos = new Vector3(0,0,0);
	Vector3 ClampUpPos = new Vector3(0,0,0);
	Vector3 ClampVirticalPos = new Vector3(0,0,0);
	
	Transform Clamp1;
	Transform Clamp2;
	Transform Clamp3;
	Transform Clamp4;
	
	// Use this for initialization
	void Start () {
		menuDisplay = false;
		clampRect = new Rect(Screen.width/2 - 434f/2, Screen.height/2 - 418f/2, 434f, 418f);
		Main = gameObject.GetComponent<ControlPanel>();
		Model_Script = gameObject.GetComponent<ModelInitialize>();
		Warnning_Script = gameObject.GetComponent<Warnning>();
		blankLength = "200";
		blankWidth = "150";
		blankHeight = "140";
		blankLengthValue = 200;
		blankWidthValue = 150;
		blankHeightValue = 140;
		lengthTemp = 200;
		widthTemp = 150;
		heightTemp = 140;
		ClampOn = false;
		ClampTypeFlag = (int)ClampType.Tongs;
	}
	
	[RPC]
	void ButtonTongs()
	{	
	}
	[RPC]
	void ButtonDirect()
	{
	}
	[RPC]
	void ButtonPlate()
	{
	}
	[RPC]
	public void ClampTypeInitialize(int type)
	{
		ClampTypeFlag = type;
		if(ClampTypeFlag == (int)ClampType.Tongs)
			Main.t2d_clampMode = Main.t2d_clampMode1;
		else if(ClampTypeFlag == (int)ClampType.Direct)
			Main.t2d_clampMode = Main.t2d_clampMode2;
		else
			Main.t2d_clampMode = Main.t2d_clampMode3;
	}
	[RPC]
	void WindowClose()
	{
		menuDisplay = false;
	}
	[RPC]
	void ClampLoadRPC(string info)
	{
	}
	[RPC]
	void ClampUnloadRPC()
	{
	}
	
	void OnGUI()
	{
		if(menuDisplay)
		{
			clampRect = GUI.Window(14, clampRect, ClampWindow, "", Main.sty_clampWindow);
		}
	}
	
	void ClampWindow(int WindowID)
	{
		if(GUI.Button(new Rect(392, 8, 25, 25), "", Main.sty_ExitClose))
		{
			menuDisplay = false;
		}
		
		GUI.DrawTexture(new Rect(65, 90, 305, 56), Main.t2d_clampMode);
		
		if(GUI.Button(new Rect(65, 90, 100, 56), "", Main.sty_ButtonEmpty))
		{
			networkView.RPC("ButtonTongs", RPCMode.Server);
		}
		
		if(GUI.Button(new Rect(165, 90, 102, 56), "", Main.sty_ButtonEmpty))
		{
			networkView.RPC("ButtonDirect", RPCMode.Server);
		}
		
		if(GUI.Button(new Rect(267, 90, 100, 56), "", Main.sty_ButtonEmpty))
		{
			networkView.RPC("ButtonPlate", RPCMode.Server);
		}
		
		GUI.skin.settings.cursorColor = Color.black;
		GUI.SetNextControlName("BlankLength");
		blankLength = GUI.TextField(new Rect(223, 213, 100, 30), blankLength, 8, Main.sty_ClampFont);
		blankLength = blankLength.Replace("\n", "");
		GUI.SetNextControlName("BlankWidth");
		blankWidth = GUI.TextField(new Rect(223, 256, 100, 30), blankWidth, 8, Main.sty_ClampFont);
		blankWidth = blankWidth.Replace("\n", "");
		GUI.SetNextControlName("BlankHeight");
		blankHeight = GUI.TextField(new Rect(223, 299, 100, 30), blankHeight, 8, Main.sty_ClampFont);
		blankHeight = blankHeight.Replace("\n", "");
		
		
		if(GUI.Button(new Rect(65, 350, 120, 35), "", Main.sty_ClampLoad))
		{
			string info = blankLength+","+blankWidth+","+blankHeight;
			networkView.RPC("ClampLoadRPC", RPCMode.Server, info);
		}
		
		if(GUI.Button(new Rect(250, 350, 120, 35), "", Main.sty_ClampUnload))
		{
			networkView.RPC("ClampUnloadRPC", RPCMode.Server);
		}
		GUI.DragWindow();
	}
	
	void HideRecursion(Transform motherTrans, bool display_flag)
	{
		if(motherTrans.renderer != null && motherTrans.name != SystemArguments.BlankName)
			motherTrans.renderer.enabled = display_flag;
		foreach(Transform childClass in motherTrans)
		{
			if(childClass.childCount > 0)
			{
				HideRecursion(childClass, display_flag);
				if(childClass.renderer != null && childClass.name != SystemArguments.BlankName)
					childClass.renderer.enabled = display_flag;
			}
			else
			{
				if(childClass.renderer != null && childClass.name != SystemArguments.BlankName)
					childClass.renderer.enabled = display_flag;
			}
		}
	}
	
	void BlankSizeControl(float length, float width, float height, string blankName)
	{
		blankLengthValue = length;
		blankWidthValue = width;
		blankHeightValue = height;
	}
	
	void FlatTongsPosition(float length, float width, float height, string blankName)
	{

	}
	
	void DirectPosition(float length, float width, float height, string blankName)
	{

	}
	
	void PlatePosition(float length, float width, float height, string blankName)
	{

	}
	
	void ClampSizeControl(float length, float width, float height)
	{

	}
	
	void ClampHide()
	{

	}
	
	void ClampLoad(string blankName)
	{

	}
	
	void ClampUnload(string blankName)
	{

	}
	
	bool SizeCheck(string length, string width, string height)
	{
		//长
		try
		{
			lengthTemp = float.Parse(length);
		}
		catch
		{
//			Warnning_Script.AddInfo("毛坯长度输入格式错误！\n");
			GUI.FocusControl("BlankLength");
			if(!Warnning_Script.come_forth)
				Warnning_Script.motion_start = true;
			return false;
		}
		if(lengthTemp < 50f || lengthTemp > 700f)
		{
//			Warnning_Script.AddInfo("毛坯长度超过规定范围！\n");
			GUI.FocusControl("BlankLength");
			if(!Warnning_Script.come_forth)
				Warnning_Script.motion_start = true;
			return false;
		}
		//宽
		try
		{
			widthTemp = float.Parse(width);
		}
		catch
		{
//			Warnning_Script.AddInfo("毛坯宽度输入格式错误！\n");
			GUI.FocusControl("BlankWidth");
//			if(!Warnning_Script.come_forth)
//				Warnning_Script.motion_start = true;
			return false;
		}
		if(widthTemp < 50f || widthTemp > 400f)
		{
//			Warnning_Script.AddInfo("毛坯宽度超过规定范围！\n");
			GUI.FocusControl("BlankWidth");
//			if(!Warnning_Script.come_forth)
//				Warnning_Script.motion_start = true;
			return false;
		}
		if(ClampTypeFlag == (int)ClampType.Tongs)
		{
			if(widthTemp > 150f)
			{
//				Warnning_Script.AddInfo("平口钳装夹时毛坯宽度不得超过150mm！\n");
				GUI.FocusControl("BlankWidth");
//				if(!Warnning_Script.come_forth)
//					Warnning_Script.motion_start = true;
				return false;
			}
		}
		//高
		try
		{
			heightTemp = float.Parse(height);
		}
		catch
		{
//			Warnning_Script.AddInfo("毛坯高度输入格式错误！\n");
			GUI.FocusControl("BlankHeight");
//			if(!Warnning_Script.come_forth)
//				Warnning_Script.motion_start = true;
			return false;
		}
		if(heightTemp < 50f || heightTemp > 400f)
		{
//			Warnning_Script.AddInfo("毛坯高度超过规定范围！\n");
			GUI.FocusControl("BlankHeight");
//			if(!Warnning_Script.come_forth)
//				Warnning_Script.motion_start = true;
			return false;
		}
		return true;
	}
 
	// Update is called once per frame
	void Update () {
		if(GUI.GetNameOfFocusedControl() == "BlankLength" && Event.current.Equals(Event.KeyboardEvent("Tab")))
		{
			GUI.FocusControl("BlankWidth");
		}
		else if(GUI.GetNameOfFocusedControl() == "BlankWidth" && Event.current.Equals(Event.KeyboardEvent("Tab")))
		{
			GUI.FocusControl("BlankHeight");
		}
		else if(GUI.GetNameOfFocusedControl() == "BlankHeight" && Event.current.Equals(Event.KeyboardEvent("Tab")))
		{
			GUI.FocusControl("BlankLength");
		}
	}
}
