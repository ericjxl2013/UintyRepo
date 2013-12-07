using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModeSelectModule : MonoBehaviour {
	ControlPanel Main;
//	CooSystem CooSystem_script;
//	MoveControl MoveControl_script;
	HandWheelModule HandWheel_script;
//	EntranceScript AutoRunning_Script;
	SoftkeyModule Softkey_Script;
	PopupMessage PopupMessage_Script;
//	MDIEditModule MDIEdit_Script;
	
	float mode_x=208;
	float mode_y=606f;
	float mode_width=200f;
	float mode_height=116.45f;
	
	float mode1_x=208f;
	float mode1_y=690f;
	float mode1_width=60f;
	float mode1_height=25f;
	
	float mode2_x=208f;
	float mode2_y=665f;
	float mode2_width=55f;
	float mode2_height=25f;
	
	float mode3_x=215f;
	float mode3_y=638f;
	float mode3_width=58f;
	float mode3_height=25f;
	
	float mode4_x=250f;
	float mode4_y=600f;
	float mode4_width=40f;
	float mode4_height=40f;
	
	float mode5_x=295f;
	float mode5_y=600f;
	float mode5_width=35f;
	float mode5_height=43f;
	
//	public float mode5_2_x=317f;
//	public float mode5_2_y=650f;
//	public float mode5_2_width=50f;
//	public float mode5_2_height=25f;
	
	float mode6_x=330f;
	float mode6_y=620f;
	float mode6_width=58f;
	float mode6_height=30f;
	
	float mode7_x=340f;
	float mode7_y=650f;
	float mode7_width=70f;
	float mode7_height=30f;
	string error_string = "";
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
//		CooSystem_script = gameObject.GetComponent<CooSystem>();
//		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
//		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		HandWheel_script=GameObject.Find("HandleControl").GetComponent<HandWheelModule>();
//		AutoRunning_Script = gameObject.GetComponent<EntranceScript>();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule>();
		PopupMessage_Script = gameObject.GetComponent<PopupMessage>();
	}
	
	[RPC]
	void ModeSelectSetRPC(int info)
	{
		switch(info)
		{
		case 1:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "编辑";
			if(!Main.editDisplay)
				Main.ExchangeVar();
			Main.t2d_ModeSelect = Main.t2d_ModeSelectEDIT;
			Main.ProgEDIT = true;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
			Main.editDisplay=true;
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		case 2:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "DNC";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectDNC;
			Main.ProgEDIT = false;
			Main.ProgDNC = true;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
			Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);	
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		case 3:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "MEM";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectAUTO;
			//NC代码编译
			if(!Main.ProgAUTO &&  Main.beModifed)
			{
				if(!Main.ProgMDI && Main.editDisplay)
				{
					Main.AutoProgName = Main.ProgramNum;
					Main.beModifed = false;
					Main.CodeForAUTO = Main.CodeForAll;
					Main.autoSelecedProgRow = 0;
					if(Main.ProgAUTOFlip == 2 || Main.ProgAUTOFlip == 4)
						Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
					else
						Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
			}
			Main.ProgEDIT =false;
			Main.ProgDNC = false;
			Main.ProgAUTO = true;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
			if(Main.ProgAUTOFlip == 2 || Main.ProgAUTOFlip == 4)
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
			else
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		case 4:
			Main.Progname_Backup = Main.ProgramNum;
			Main.ProgramNum = 0;
			Main.MenuDisplay = "MDI";
			if(Main.editDisplay)
				Main.ExchangeVar();
			if(Main.CodeForAll.Count == 0)
			{
				Main.CodeForAll.Add("O0000");
				Main.CodeForAll.Add(";");
				Main.MDIpos_flag = true;
			}
			Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
			Main.t2d_ModeSelect = Main.t2d_ModeSelectMDI;
			Main.ProgEDIT = false;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = true;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = false;
			Main.editDisplay=false;
			Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		case 5:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "HAN";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectHANDLE;
			Main.ProgEDIT = false;
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = true;
			Main.ProgJOG = false;
			Main.ProgREF = false;
			Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			StartCoroutine (HandWheel_script.showWheel());
			break;
		case 6:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "JOG";	
			Main.t2d_ModeSelect = Main.t2d_ModeSelectJOG;
			Main.ProgEDIT = false;	
			Main.ProgDNC = false;
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = true;
			Main.ProgREF = false;
			Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		case 7:
			Main.ProgramNum = Main.Progname_Backup;
			Main.MenuDisplay = "REF";
			Main.t2d_ModeSelect = Main.t2d_ModeSelectREF;
			Main.ProgEDIT = false;
			Main.ProgDNC = false;	
			Main.ProgAUTO = false;
			Main.ProgMDI = false;
			Main.ProgHAN = false;
			Main.ProgJOG = false;
			Main.ProgREF = true;
			Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			StartCoroutine (HandWheel_script.closeWheel());
			break;
		}
	}
	
	public void ModeSelectButton () 
	{
		GUI.DrawTexture(new Rect((mode_x+1)/1000f*Main.width,(mode_y+1)/1000f*Main.height,mode_width/1000f*Main.width,mode_height/1000f*Main.height), Main.t2d_ModeSelect, ScaleMode.ScaleAndCrop, true, 893/513f);
		if (GUI.Button(new Rect((mode1_x+10f)/1000f*Main.width, mode1_y/1000f*Main.height, mode1_width/1000f*Main.width, mode1_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "编辑";
				if(!Main.editDisplay)
					Main.ExchangeVar();
				Main.t2d_ModeSelect = Main.t2d_ModeSelectEDIT;
	//			PlayerPrefs.SetInt("ModeSelect", 1);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 1);
				Main.ProgEDIT = true;
				Main.ProgDNC = false;
				Main.ProgAUTO = false;
				Main.ProgMDI = false;
				Main.ProgHAN = false;
				Main.ProgJOG = false;
				Main.ProgREF = false;
				Main.editDisplay=true;
				StartCoroutine (HandWheel_script.closeWheel());
	//			HandWheel_script.closeWheel();
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		if (GUI.Button(new Rect((mode2_x+10f)/1000f*Main.width, mode2_y/1000f*Main.height, mode2_width/1000f*Main.width, mode2_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "DNC";
				Main.t2d_ModeSelect = Main.t2d_ModeSelectDNC;
	//			PlayerPrefs.SetInt("ModeSelect", 2);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 2);
				Main.ProgEDIT = false;
				Main.ProgDNC = true;
				Main.ProgAUTO = false;
				Main.ProgMDI = false;
				Main.ProgHAN = false;
				Main.ProgJOG = false;
				Main.ProgREF = false;
	//			HandWheel_script.closeWheel();
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);	
				StartCoroutine (HandWheel_script.closeWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		if (GUI.Button(new Rect((mode3_x+10f)/1000f*Main.width, mode3_y/1000f*Main.height, mode3_width/1000f*Main.width, mode3_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "MEM";
				Main.t2d_ModeSelect = Main.t2d_ModeSelectAUTO;
	//			PlayerPrefs.SetInt("ModeSelect", 3);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 3);
				//NC代码编译
				if(!Main.ProgAUTO &&  Main.beModifed)
				{
					if(!Main.ProgMDI && Main.editDisplay)
					{
						Main.AutoProgName = Main.ProgramNum;
						Main.beModifed = false;
						Main.CodeForAUTO = Main.CodeForAll;
						Main.autoSelecedProgRow = 0;
						if(Main.ProgAUTOFlip == 2 || Main.ProgAUTOFlip == 4)
							Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
						else
							Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
	//					Main.Compile_flag = AutoRunning_Script.AutoCodeCompile(Main.CodeForAUTO, ref error_string);
	//					if(!Main.Compile_flag)
	//						Debug.LogError(error_string);
					}
				}
				Main.ProgEDIT =false;
				Main.ProgDNC = false;
				Main.ProgAUTO = true;
				Main.ProgMDI = false;
				Main.ProgHAN = false;
				Main.ProgJOG = false;
				Main.ProgREF = false;
	//			HandWheel_script.closeWheel();
				if(Main.ProgAUTOFlip == 2 || Main.ProgAUTOFlip == 4)
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				else
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				StartCoroutine (HandWheel_script.closeWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		if (GUI.Button(new Rect((mode4_x + 10f)/1000f*Main.width, mode4_y/1000f*Main.height, mode4_width/1000f*Main.width, mode4_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.Progname_Backup = Main.ProgramNum;
				Main.ProgramNum = 0;
				Main.MenuDisplay = "MDI";
				if(Main.editDisplay)
					Main.ExchangeVar();
				if(Main.CodeForAll.Count == 0)
				{
					Main.CodeForAll.Add("O0000");
					Main.CodeForAll.Add(";");
					Main.MDIpos_flag = true;
				}
				Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
				Main.t2d_ModeSelect = Main.t2d_ModeSelectMDI;
	//			PlayerPrefs.SetInt("ModeSelect", 4);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 4);
				Main.ProgEDIT = false;
				Main.ProgDNC = false;
				Main.ProgAUTO = false;
				Main.ProgMDI = true;
				Main.ProgHAN = false;
				Main.ProgJOG = false;
				Main.ProgREF = false;
				Main.editDisplay=false;
	//			HandWheel_script.closeWheel();
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				StartCoroutine (HandWheel_script.closeWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		if (GUI.Button(new Rect((mode5_x+10f)/1000f*Main.width, mode5_y/1000f*Main.height, mode5_width/1000f*Main.width, mode5_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "HAN";
				Main.t2d_ModeSelect = Main.t2d_ModeSelectHANDLE;
	//			PlayerPrefs.SetInt("ModeSelect", 5);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 5);
				Main.ProgEDIT = false;
				Main.ProgDNC = false;
				Main.ProgAUTO = false;
				Main.ProgMDI = false;
				Main.ProgHAN = true;
				Main.ProgJOG = false;
				Main.ProgREF = false;
	//			HandWheel_script.showWheel();
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				StartCoroutine (HandWheel_script.showWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(317f/1000f*Main.width, 650f/1000f*Main.height, 50f/1000f*Main.width, 25f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.ProgramNum = Main.Progname_Backup;
//			Main.MenuDisplay = "HAN";
//			Main.t2d_ModeSelect = Main.t2d_ModeSelectHANDLE;
//			PlayerPrefs.SetInt("ModeSelect", 5);
//			Main.ProgEDIT = false;
//			Main.ProgDNC = false;
//			Main.ProgAUTO = false;
//			Main.ProgMDI = false;
//			Main.ProgHAN =true;
//			Main.ProgJOG = false;
//			Main.ProgREF = false;
//			HandWheel_script.showWheel();
//			
//		}
		
		if (GUI.Button(new Rect((mode6_x + 10f)/1000f*Main.width, (mode6_y+7)/1000f*Main.height, mode6_width/1000f*Main.width, (mode6_height-7)/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "JOG";	
				Main.t2d_ModeSelect = Main.t2d_ModeSelectJOG;
	//			PlayerPrefs.SetInt("ModeSelect", 6);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 6);
	//			MoveControl_script.speed_to_move = 0.08333F;
	//			MoveControl_script.move_rate = Main.move_rate;
				Main.ProgEDIT = false;	
				Main.ProgDNC = false;
				Main.ProgAUTO = false;
				Main.ProgMDI = false;
				Main.ProgHAN = false;
				Main.ProgJOG = true;
				Main.ProgREF = false;
	//			HandWheel_script.closeWheel();
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				StartCoroutine (HandWheel_script.closeWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		if (GUI.Button(new Rect(mode7_x/1000f*Main.width, mode7_y/1000f*Main.height, mode7_width/1000f*Main.width, mode7_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.ProgramNum = Main.Progname_Backup;
				Main.MenuDisplay = "REF";
				Main.t2d_ModeSelect = Main.t2d_ModeSelectREF;
	//			PlayerPrefs.SetInt("ModeSelect", 7);
				networkView.RPC("ModeSelectSetRPC", RPCMode.Others, 7);
	//			MoveControl_script.speed_to_move = 0.16667F;
	//			MoveControl_script.move_rate = 1.0f;
				Main.ProgEDIT = false;
				Main.ProgDNC = false;	
				Main.ProgAUTO = false;
				Main.ProgMDI = false;
				Main.ProgHAN = false;
				Main.ProgJOG = false;
				Main.ProgREF = true;
	//			HandWheel_script.closeWheel();
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				StartCoroutine (HandWheel_script.closeWheel());
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
