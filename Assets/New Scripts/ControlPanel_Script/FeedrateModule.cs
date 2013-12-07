using UnityEngine;
using System.Collections;

public class FeedrateModule : MonoBehaviour {
	ControlPanel Main;
	PopupMessage PopupMessage_Script;
	
	bool feedrate0_pause = false;
	
	public float Feedrate_x=440f;
	public float Feedrate_y=600f;
	public float Feedrate_width=220f;
	public float Feedrate_height;
	
	public float mode1_x=450f;
	public float mode1_y=700f;
	public float mode1_width=40f;
	public float mode1_height=20f;
	
	public float mode2_x=440f;
	public float mode2_y=682f;
	public float mode2_width=40f;
	public float mode2_height=16f;
	
	public float mode3_x=440f;
	public float mode3_y=665f;
	public float mode3_width=40f;
	public float mode3_height=18f;
	
	public float mode4_x=440f;
	public float mode4_y=650f;
	public float mode4_width=40f;
	public float mode4_height=16f;
	
	public float mode5_x=446f;
	public float mode5_y=635f;
	public float mode5_width=40f;
	public float mode5_height=16f;
	
	public float mode6_x=455f;
	public float mode6_y=620f;
	public float mode6_width=40f;
	public float mode6_height=16f;
	
	public float mode7_x=500f;
	public float mode7_y=600f;
	public float mode7_width=16f;
	public float mode7_height=40f;
	
	public float mode8_x=516f;
	public float mode8_y=600f;
	public float mode8_width=16f;
	public float mode8_height=40f;
	
	public float mode9_x=532f;
	public float mode9_y=600f;
	public float mode9_width=16f;
	public float mode9_height=40f;
	
	public float mode10_x=552f;
	public float mode10_y=600f;
	public float mode10_width=16f;
	public float mode10_height=40f;
	
	public float mode11_x=565f;
	public float mode11_y=620f;
	public float mode11_width=40f;
	public float mode11_height=16f;
	
	public float mode12_x=580f;
	public float mode12_y=635f;
	public float mode12_width=40f;
	public float mode12_height=16f;
	
	public float mode13_x=582f;
	public float mode13_y=650f;
	public float mode13_width=40f;
	public float mode13_height=16f;
	
	public float mode14_x=582f;
	public float mode14_y=665f;
	public float mode14_width=40f;
	public float mode14_height=18f;
	
	public float mode15_x=586f;
	public float mode15_y=680f;
	public float mode15_width=40f;
	public float mode15_height=18f;
	
	public float mode16_x=580f;
	public float mode16_y=699f;
	public float mode16_width=40f;
	public float mode16_height=20f;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		PopupMessage_Script = gameObject.GetComponent<PopupMessage>();
		
		Feedrate_height=Feedrate_width*511/893;
	}
	
	[RPC]
	void FeedrateSetRPC(int info)
	{
		switch(info)
		{
		case 1:
			Main.t2d_feedrate = Main.t2d_FeedRate_0;
			Main.move_rate = 0f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 2:
			Main.t2d_feedrate = Main.t2d_FeedRate_10;
			Main.move_rate = 0.1f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 3:
			Main.t2d_feedrate = Main.t2d_FeedRate_20;
			Main.move_rate = 0.2f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 4:
			Main.t2d_feedrate = Main.t2d_FeedRate_30;
			Main.move_rate = 0.3f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 5:
			Main.t2d_feedrate = Main.t2d_FeedRate_40;
			Main.move_rate = 0.4f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 6:
			Main.t2d_feedrate = Main.t2d_FeedRate_50;
			Main.move_rate = 0.5f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 7:
			Main.t2d_feedrate = Main.t2d_FeedRate_60;
			Main.move_rate = 0.6f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 8:
			Main.t2d_feedrate = Main.t2d_FeedRate_70;
			Main.move_rate = 0.7f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 9:
			Main.t2d_feedrate = Main.t2d_FeedRate_80;
			Main.move_rate = 0.8f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 10:
			Main.t2d_feedrate = Main.t2d_FeedRate_90;
			Main.move_rate = 0.9f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 11:
			Main.t2d_feedrate = Main.t2d_FeedRate_100;
			Main.move_rate = 1.0f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 12:
			Main.t2d_feedrate = Main.t2d_FeedRate_110;
			Main.move_rate = 1.1f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 13:
			Main.t2d_feedrate = Main.t2d_FeedRate_120;
			Main.move_rate = 1.2f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 14:
			Main.t2d_feedrate = Main.t2d_FeedRate_130;
			Main.move_rate = 1.3f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 15:
			Main.t2d_feedrate = Main.t2d_FeedRate_140;
			Main.move_rate = 1.4f;
			Main.move_rate_pad = Main.move_rate;
			break;
		case 16:
			Main.t2d_feedrate = Main.t2d_FeedRate_150;
			Main.move_rate = 1.5f;
			Main.move_rate_pad = Main.move_rate;
			break;
		default:
			break;
		}
	}
	
	public void FeedrateSelect()
	{
		GUI.DrawTexture(new Rect(Feedrate_x/1000f*Main.width,Feedrate_y/1000f*Main.height,Feedrate_width/1000f*Main.width,Feedrate_height/1000f*Main.height), Main.t2d_feedrate, ScaleMode.ScaleAndCrop, true, 893/511f);
		if (GUI.Button(new Rect(mode1_x/1000f*Main.width, mode1_y/1000f*Main.height, mode1_width/1000f*Main.width, mode1_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_0;
	//			PlayerPrefs.SetInt("FeedrateSelect", 1);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 1);
				Main.move_rate = 0f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag && !AutoMove_Script.PauseState())
	//			{
	//				AutoMove_Script.SetPause();
	//				Main.RunningSpeed = 0;
	//				feedrate0_pause = true;
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode2_x/1000f*Main.width, mode2_y/1000f*Main.height, mode2_width/1000f*Main.width, mode2_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_10;
	//			PlayerPrefs.SetInt("FeedrateSelect", 2);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 2);
				Main.move_rate = 0.1f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode3_x/1000f*Main.width, mode3_y/1000f*Main.height, mode3_width/1000f*Main.width, mode3_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_20;
	//			PlayerPrefs.SetInt("FeedrateSelect", 3);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 3);
				Main.move_rate = 0.2f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode4_x/1000f*Main.width, mode4_y/1000f*Main.height, mode4_width/1000f*Main.width, mode4_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_30;
	//			PlayerPrefs.SetInt("FeedrateSelect", 4);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 4);
				Main.move_rate = 0.3f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode5_x/1000f*Main.width, mode5_y/1000f*Main.height, mode5_width/1000f*Main.width, mode5_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_40;
	//			PlayerPrefs.SetInt("FeedrateSelect", 5);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 5);
				Main.move_rate = 0.4f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(463f/1000f*Main.width, 647/1000f*Main.height, 40f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_40;
//			PlayerPrefs.SetInt("FeedrateSelect", 5);
//			Main.move_rate = 0.4f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode6_x/1000f*Main.width, mode6_y/1000f*Main.height, mode6_width/1000f*Main.width, mode6_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_50;
	//			PlayerPrefs.SetInt("FeedrateSelect", 6);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 6);
				Main.move_rate = 0.5f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(490f/1000f*Main.width, 627/1000f*Main.height, 30f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_50;
//			PlayerPrefs.SetInt("FeedrateSelect", 6);
//			Main.move_rate = 0.5f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode7_x/1000f*Main.width, mode7_y/1000f*Main.height, mode7_width/1000f*Main.width, mode7_height/1000f*Main.height), "", Main.sty_ButtonEmpty))              
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_60;
	//			PlayerPrefs.SetInt("FeedrateSelect", 7);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 7);
				Main.move_rate = 0.6f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(528f/1000f*Main.width, 647/1000f*Main.height, 17f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_60;
//			PlayerPrefs.SetInt("FeedrateSelect", 7);
//			Main.move_rate = 0.6f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode8_x/1000f*Main.width, mode8_y/1000f*Main.height, mode8_width/1000f*Main.width, mode8_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_70;
	//			PlayerPrefs.SetInt("FeedrateSelect", 8);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 8);
				Main.move_rate = 0.7f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(540f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_70;
//			PlayerPrefs.SetInt("FeedrateSelect", 8);
//			Main.move_rate = 0.7f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode9_x/1000f*Main.width, mode9_y/1000f*Main.height, mode9_width/1000f*Main.width, mode9_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_80;
	//			PlayerPrefs.SetInt("FeedrateSelect", 9);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 9);
				Main.move_rate = 0.8f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(560f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_80;
//			PlayerPrefs.SetInt("FeedrateSelect", 9);
//			Main.move_rate = 0.8f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode10_x/1000f*Main.width, mode10_y/1000f*Main.height, mode10_width/1000f*Main.width, mode10_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_90;
	//			PlayerPrefs.SetInt("FeedrateSelect", 10);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 10);
				Main.move_rate = 0.9f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(575f/1000f*Main.width, 647/1000f*Main.height, 15f/1000f*Main.width, 20f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_90;
//			PlayerPrefs.SetInt("FeedrateSelect", 10);
//			Main.move_rate = 0.9f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode11_x/1000f*Main.width, mode11_y/1000f*Main.height, mode11_width/1000f*Main.width, mode11_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_100;
	//			PlayerPrefs.SetInt("FeedrateSelect", 11);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 11);
				Main.move_rate = 1.0f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(600f/1000f*Main.width, 627/1000f*Main.height, 20f/1000f*Main.width, 30f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_100;
//			PlayerPrefs.SetInt("FeedrateSelect", 11);
//			Main.move_rate = 1.0f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode12_x/1000f*Main.width, mode12_y/1000f*Main.height, mode12_width/1000f*Main.width, mode12_height/1000f*Main.height), "", Main.sty_ButtonEmpty))             
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_110;
	//			PlayerPrefs.SetInt("FeedrateSelect", 12);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 12);
				Main.move_rate = 1.1f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
//		if (GUI.Button(new Rect(614f/1000f*Main.width, 657/1000f*Main.height, 25f/1000f*Main.width, 18f/1000f*Main.height), "", Main.sty_ButtonEmpty))            
//		{
//			Main.t2d_feedrate = Main.t2d_FeedRate_110;
//			PlayerPrefs.SetInt("FeedrateSelect", 12);
//			Main.move_rate = 1.1f;
//			Main.move_rate_pad = Main.move_rate;
//			if(Main.AutoRunning_flag)
//			{
//				if(feedrate0_pause && !Main.AutoPause_flag)
//				{
//					AutoMove_Script.ReleasePause();
//					feedrate0_pause = false;
//				}
//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
//			}
//		}
		if (GUI.Button(new Rect(mode13_x/1000f*Main.width, mode13_y/1000f*Main.height, mode13_width/1000f*Main.width, mode13_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_120;
	//			PlayerPrefs.SetInt("FeedrateSelect", 13);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 13);
				Main.move_rate = 1.2f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode14_x/1000f*Main.width, mode14_y/1000f*Main.height, mode14_width/1000f*Main.width, mode14_height/1000f*Main.height), "", Main.sty_ButtonEmpty))           
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_130;
	//			PlayerPrefs.SetInt("FeedrateSelect", 14);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 14);
				Main.move_rate = 1.3f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode15_x/1000f*Main.width, mode15_y/1000f*Main.height, mode15_width/1000f*Main.width, mode15_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_140;
	//			PlayerPrefs.SetInt("FeedrateSelect", 15);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 15);
				Main.move_rate = 1.4f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		if (GUI.Button(new Rect(mode16_x/1000f*Main.width, mode16_y/1000f*Main.height, mode16_width/1000f*Main.width, mode16_height/1000f*Main.height), "", Main.sty_ButtonEmpty))            
		{
			if(!Main.EmergencyCtrl)
			{
				Main.t2d_feedrate = Main.t2d_FeedRate_150;
	//			PlayerPrefs.SetInt("FeedrateSelect", 16);
				networkView.RPC("FeedrateSetRPC", RPCMode.Others, 16);
				Main.move_rate = 1.5f;
				Main.move_rate_pad = Main.move_rate;
	//			if(Main.AutoRunning_flag)
	//			{
	//				if(feedrate0_pause && !Main.AutoPause_flag)
	//				{
	//					AutoMove_Script.ReleasePause();
	//					feedrate0_pause = false;
	//				}
	//				Main.RunningSpeed = (int)(AutoRunning_Script.SpeedNow * Main.move_rate);
	//				AutoMove_Script.ChangeMoveRatio(Main.move_rate);
	//			}
			}else{
				if(Main.ScreenPower)
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
			}
		}
		//GUIUtility
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
