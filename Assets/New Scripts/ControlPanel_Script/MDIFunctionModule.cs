using UnityEngine;
using System.Collections;

public class MDIFunctionModule : MonoBehaviour
{
	ControlPanel Main;
	CooSystem CooSystem_script;
	MDIInputModule MDIInput_script;
	MDIEditModule MDIEdit_Script;
	public float btn_width = 48;
	public float btn_height = 48;
	public float l_x = 603;
	public float l_y = 34;
	public float left_x = 57;
	public float left_y = 53;

	// Use this for initialization
	void Start ()
	{
		Main = gameObject.GetComponent<ControlPanel> ();
		CooSystem_script = gameObject.GetComponent<CooSystem> ();
		MDIInput_script = gameObject.GetComponent<MDIInputModule> ();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule> ();
	}
	
	public void Function ()
	{
//		GUI.color = Color.cyan;
		//POS---------------------------------------------------------------------------------------------------
		if (GUI.Button (new Rect ((l_x) / 1000f * Main.width, (l_y + 4 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.POS)) {
			if (Main.ScreenPower)
			{
				networkView.RPC("PosButton", RPCMode.All);
//				PosButton ();
			}
		}
		
		//PROG---------------------------------------------------------------------------------------------------
		if (GUI.Button (new Rect ((l_x + left_x) / 1000f * Main.width, (l_y + 4 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.PROG)) {
			if (Main.ScreenPower)
			{
				networkView.RPC("ProgButton", RPCMode.All);
//				ProgButton ();
			}
		}
		
		if (GUI.Button (new Rect ((l_x + 2 * left_x) / 1000f * Main.width, (l_y + 4 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.SET)) {
			if (Main.ScreenPower)
			{
				networkView.RPC("OffSettingsButton", RPCMode.All);
//				OffSettingsButton ();
			}
		}
		
		if (GUI.Button (new Rect ((l_x + 5 * left_x) / 1000f * Main.width, (l_y + 4 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.INPUT)) {
			if (Main.ScreenPower) {
				networkView.RPC("InputButton", RPCMode.All);
//				InputButton();
			}
		}
		
		if (GUI.Button (new Rect ((l_x) / 1000f * Main.width, (l_y + 5 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.SYSTEM)) {
			if (Main.ScreenPower) {
				networkView.RPC("SystemButton", RPCMode.All);
//				SystemButton ();
			}
		}
		
		if (GUI.Button (new Rect ((l_x + left_x) / 1000f * Main.width, (l_y + 5 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.MESSAGE)) {
			if (Main.ScreenPower) {
				networkView.RPC("MessageButton", RPCMode.All);
//				MessageButton ();
			}
		}
		
		if (GUI.Button (new Rect ((l_x + 2 * left_x) / 1000f * Main.width, (l_y + 5 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.ORPH)) {
			if (Main.ScreenPower) {
				
			}
		}
//		Event e = Event.current;
//		TestRect = new Rect((l_x + 2*left_x + btn_width/4)/1000f*Main.width, (l_y+5*left_y + btn_height/4)/1000f*Main.height,(btn_width/2)/1000f*Main.width, (btn_height/2)/1000f*Main.height);
//		GUI.Button(TestRect, "");
//		if(TestRect.Contains(e.mousePosition))
//		{
//			GUI.Box(new Rect((l_x + 1*left_x + btn_width/4)/1000f*Main.width, (l_y+4*left_y + btn_height/4)/1000f*Main.height, 2*left_x/1000f*Main.width, 2*left_y/1000f*Main.height), "");
//		}
		if (GUI.Button (new Rect ((l_x + 5 * left_x) / 1000f * Main.width, (l_y + 6 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.HELP)) {
			if (Main.ScreenPower) {
				
			}
		}
		
//		GUI.color = Color.white;
		if (GUI.Button (new Rect ((l_x + 5 * left_x) / 1000f * Main.width, (l_y + 7 * left_y) / 1000f * Main.height, btn_width / 1000f * Main.width, btn_height / 1000f * Main.height), "", Main.RESET)) {
			if (Main.ScreenPower) {
				networkView.RPC("ResetButton", RPCMode.All);
//				ResetButton();
			}
		}
	}
	
	[RPC]
	void PosButton ()
	{
		if (Main.ProgMenu) {
			Main.TempInputText = Main.InputText;
			Main.InputText = "";
			Main.CursorText.text = Main.InputText;
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
		}
		
		if (Main.SettingMenu) {
			Main.OffSetTemp = Main.InputText;
			Main.InputText = "";
			Main.CursorText.text = Main.InputText;
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
		}
		
		if (Main.PosMenu) {
			if (Main.AbsoluteCoo) {
				Main.AbsoluteCoo = false;
				Main.RelativeCoo = true;
				Main.GeneralCoo = false;
			} else if (Main.RelativeCoo) {
				Main.AbsoluteCoo = false;
				Main.RelativeCoo = false;
				Main.GeneralCoo = true;
			} else {
				Main.AbsoluteCoo = true;
				Main.RelativeCoo = false;
				Main.GeneralCoo = false;
			}
			if (Main.operationBottomScrInitial || Main.operationBottomScrExecute) {
				if (Main.statusBeforeOperation == 1) {
					Main.AbsoluteCoo = false;
					Main.RelativeCoo = true;
					Main.GeneralCoo = false;
				} else if (Main.statusBeforeOperation == 2) {
					Main.AbsoluteCoo = false;
					Main.RelativeCoo = false;
					Main.GeneralCoo = true;
				} else if (Main.statusBeforeOperation == 3) {
					Main.AbsoluteCoo = true;
					Main.RelativeCoo = false;
					Main.GeneralCoo = false;
				}
				Main.posOperationMode = false;
				Main.operationBottomScrExecute = false;
				Main.operationBottomScrInitial = false;
			}
		} else {
			Main.PosMenu = true;
			Main.ProgMenu = false;
			Main.SettingMenu = false;
			Main.SystemMenu = false;//内容--位置显示时，System和Message为假，姓名--刘旋，时间--2013-4-24
			Main.MessageMenu = false;
		}
	}
	
	[RPC]
	void ProgButton ()
	{
		if (Main.PosMenu) {
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
			MDIInput_script.isXSelected = false;
			MDIInput_script.isYSelected = false;
			MDIInput_script.isZSelected = false;
		}

		if (Main.SettingMenu) {
			Main.OffSetTemp = Main.InputText;
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		Main.PosMenu = false;
		Main.SettingMenu = false;
		Main.ProgMenu = true;
		Main.SystemMenu = false;//内容--位置显示时，System和Message为假，姓名--刘旋，时间--2013-4-24
		Main.MessageMenu = false;
	}
	
	[RPC]
	void OffSettingsButton ()
	{
		if (Main.PosMenu) {
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
			MDIInput_script.isXSelected = false;
			MDIInput_script.isYSelected = false;
			MDIInput_script.isZSelected = false;
		}
		if (Main.ProgMenu) {
			Main.TempInputText = Main.InputText;
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		if (Main.SettingMenu == false) {
			Main.PosMenu = false;
			Main.SettingMenu = true;
			Main.ProgMenu = false;
			Main.SystemMenu = false;//内容--设置显示时，System和Message为假，姓名--刘旋，时间--2013-4-24
			Main.MessageMenu = false;
		} else {
			if (Main.OffSetTool) {
				Main.OffSetTool = false;
				Main.OffSetSetting = true;
				Main.OffSetCoo = false;
				Main.OffSetOne = true;
				Main.OffSetTwo = false;
			} else if (Main.OffSetSetting) {
				Main.OffSetTool = false;
				Main.OffSetSetting = false;
				Main.OffSetCoo = true;
				Main.OffSetOne = true;
				Main.OffSetTwo = false;
			} else {
				Main.OffSetTool = true;
				Main.OffSetSetting = false;
				Main.OffSetCoo = false;
				Main.OffSetOne = true;
				Main.OffSetTwo = false;
			}
		}	
	}
	
	[RPC]
	void InputButton()
	{
		if (Main.SettingMenu) {
			if (Main.OffSetSetting) {	
				if (Main.InputText != "") {	
					CooSystem_script.set_parameter (Main.InputText);		
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
			//刀偏界面的输入功能
			if (Main.OffSetTool && Main.OffSetTwo) {	
				if (Main.InputText != "") {	
					CooSystem_script.Plus_Tool_Input (Main.InputText, false);		
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
			if (Main.OffSetCoo && Main.OffSetTwo) {
				if (Main.InputText != "") {
					CooSystem_script.PlusInput (Main.InputText, false);
					Main.beModifed = true;
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
		}
	}
	
	[RPC]
	void SystemButton ()
	{
		if (Main.PosMenu) {
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
			MDIInput_script.isXSelected = false;
			MDIInput_script.isYSelected = false;
			MDIInput_script.isZSelected = false;
		}
		if (Main.ProgMenu) {
			Main.TempInputText = Main.InputText;
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		if (Main.SettingMenu) {
			Main.OffSetTemp = Main.InputText;
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		Main.PosMenu = false;
		Main.SettingMenu = false;
		Main.ProgMenu = false;
		Main.SystemMenu = true;//内容--System显示时，System为真，姓名--刘旋，时间--2013-4-24
		Main.MessageMenu = false;
	}
	
	[RPC]
	void MessageButton ()
	{
		if (Main.PosMenu) {
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
			MDIInput_script.isXSelected = false;
			MDIInput_script.isYSelected = false;
			MDIInput_script.isZSelected = false;
		}
		if (Main.ProgMenu) {
			Main.TempInputText = Main.InputText;
			Main.InputText = Main.OffSetTemp;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		if (Main.SettingMenu) {
			Main.OffSetTemp = Main.InputText;
			Main.InputText = Main.TempInputText;
			Main.CursorText.text = Main.InputText;
			Main.InputTextSize = Main.sty_InputTextField.CalcSize (new GUIContent (Main.CursorText.text));
			Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
		}
		Main.PosMenu = false;
		Main.SettingMenu = false;
		Main.ProgMenu = false;
		Main.SystemMenu = false;
		Main.MessageMenu = true;//内容--Message显示时，Message为真，姓名--刘旋，时间--2013-4-24
	}
	
	[RPC]
	void ResetButton()
	{
		if (Main.ProgMenu) {
			Main.ProgEDITCusorV = 0;
			Main.ProgEDITCusorH = 0;
			Main.StartRow = 0;
			Main.EndRow = SystemArguments.EditLineNumber;
			Main.SelectStart = 0;
			Main.SelectEnd = 0;
			if (Main.ProgMDI) {
				MDIEdit_Script.EditProgRight ();
			}
		}
		Main.ALM_Control = false;
		Main.ALMBlink = false;
		Main.WarnningClear ();
		Main.OrientControl(false);
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
