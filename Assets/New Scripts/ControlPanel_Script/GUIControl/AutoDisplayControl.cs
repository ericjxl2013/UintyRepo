using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoDisplayControl : MonoBehaviour {
	ControlPanel Main;
	SoftkeyModule Softkey_Script;
	ProgramModule Program_Script;
	ClientCenter ClientCenter_Script;
	HandWheelModule HandWheel_Script;
	List<string> G_Display = new List<string>();
	List<string> G_Address = new List<string>();
	List<float> Address_Value = new List<float>();
	List<string> G_Display2 = new List<string>();
	List<string> G_Address2 = new List<string>();
	List<float> Address_Value2 = new List<float>();
	List<int> ModalIndex = new List<int>();
	List<string> ModalString = new List<string>();
	Resolution current_resolutin;
	//记录上一次手机触摸位置判断用户是在左放大还是缩小手势  
	private Vector2 oldPosition1 = new Vector2(0, 0);  
	private Vector2 oldPosition2 = new Vector2(0, 0);    
	float distance = 1f;
	bool enlarge_flag = false;  //seems no use here
	bool enlarge_on = false;  //control enlarge process
	bool old_p1_get = false;  //get the 1st point position
	bool old_p2_get = false;  //get the 2nd point position
	
	
	int pattern = 0;  //当前是何种操作
	float x = 0;
	float y = 0;
	float distance2V = 0;
	
	float pressTime = 0;
	const float TIMELIMIT = 0.3f;
	bool motionAllow = false;
	float oldDistance = 0;
	float newDistance = 0;
	bool moveZoomOn = false;
	bool move_zoom = false;  //false缩放；true平移
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule>();
		Program_Script = gameObject.GetComponent<ProgramModule>();
		ClientCenter_Script = gameObject.GetComponent<ClientCenter>();
		HandWheel_Script = GameObject.Find ("HandleControl").GetComponent<HandWheelModule> ();
		current_resolutin = Screen.currentResolution;
//		if(current_resolutin.width > 1680)
//		{
//			float enlarge_rate = 1024.0f/current_resolutin.width;
//			Screen.SetResolution((int)(current_resolutin.width * enlarge_rate), (int)(current_resolutin.height * enlarge_rate), true);
//			current_resolutin.width = (int)(current_resolutin.width * enlarge_rate);
//			current_resolutin.height = (int)(current_resolutin.height * enlarge_rate);
//			Main.PanelWindowRect.x = 30f;
//			Main.PanelWindowRect.y = 0f;
//			ClientCenter_Script.wirelessRect.x = Screen.width/2 - ClientCenter_Script.wirelessRect.width/2;
//			ClientCenter_Script.wirelessRect.y = Screen.height/2 - ClientCenter_Script.wirelessRect.height/2;
//		}
	}
	
	void OnGUI ()
	{
		
	}
	
//	
//	void OnGUI()
//	{
//		GUILayout.Label(Screen.width + ", " + Screen.height);
//	}

	[RPC]
	public void DisplayStart()
	{
		Main.Current_F_value = true;
		Main.Current_S_value = true;
		Main.Current_T_value = true;
		Main.Current_H_value = true;
		Main.Current_D_value = true;
		Main.Current_M_value = true;
	}
	
	[RPC]
	public void DisplayEnd()
	{
		Main.Current_F_value = false;
		Main.Current_S_value = false;
		Main.Current_T_value = false;
		Main.Current_H_value = false;
		Main.Current_D_value = false;
		Main.Current_M_value = false;
	}
	
	[RPC]
	public void MDIStop()
	{
		Main.MDIDisplayFindRows(0);
		Main.CodeForMDIRuning.Clear();
		Main.CodeForMDIRuning.Add("O0000");
		Main.CodeForMDIRuning.Add(";");
		if(Main.ProgMDI)
		{
			Main.CodeForAll.Clear();
			Main.CodeForAll.Add("O0000");
			Main.CodeForAll.Add(";");
			Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
			Main.ProgEDITCusorV = 0;
			Main.ProgEDITCusorH = 0;
			Main.StartRow = 0;
			Main.EndRow = SystemArguments.EditLineNumber;
			Main.SelectStart = 0;
			Main.SelectEnd = 0;
			Main.MDIpos_flag = true;
		}
		else
		{
			Main.CodeForMDI.Clear();
			Main.CodeForMDI.Add("O0000");
			Main.CodeForMDI.Add(";");
			Main.MDIProgEDITCusorV = 0;
			Main.MDIProgEDITCusorH = 0;
			Main.MDIStartRow = 0;
			Main.MDIEndRow = SystemArguments.EditLineNumber;
			Main.MDISelectStart = 0;
			Main.MDISelectEnd = 0;
			Main.MDIpos_flag = true;
		}
	}
	
	[RPC]
	void AutoCursor(int index)
	{
		Main.AutoDisplayFindRows(index, Main.autoDisplayNormal);
	}
	
	[RPC]
	void MDICursor(int index)
	{
		Main.MDIDisplayFindRows(index);
	}
	
	[RPC]
	void NumberDisplay(string info)
	{
		string[] info_array = info.Split(',');
		Main.H_value = int.Parse(info_array[0]);
		Main.M_value = int.Parse(info_array[1]);
		Main.T_Value = int.Parse(info_array[2]);
		Main.D_value = int.Parse(info_array[3]);
		Main.RunningSpeed = int.Parse(info_array[4]);
		Main.SpindleSpeed = int.Parse(info_array[5]);
	}
	
	[RPC]
	void CurrentCodeG_Display(string info)
	{
		string[] info_array = info.Split(',');
		G_Display.Clear();
		for(int i = 0; i < info_array.Length; i++)
		{
			G_Display.Add(info_array[i]);
		}
	}
	[RPC]
	void CurrentCodeG_Display2(string info)
	{
		string[] info_array = info.Split(',');
		G_Display2.Clear();
		for(int i = 0; i < info_array.Length; i++)
		{
			G_Display2.Add(info_array[i]);
		}
	}
	[RPC]
	void CurrentCodeG_Address(string info)
	{
		string[] info_array = info.Split(',');
		G_Address.Clear();
		for(int i = 0; i < info_array.Length; i++)
		{
			G_Address.Add(info_array[i]);
		}
	}
	[RPC]
	void CurrentCodeG_Address2(string info)
	{
		string[] info_array = info.Split(',');
		G_Address2.Clear();
		for(int i = 0; i < info_array.Length; i++)
		{
			G_Address2.Add(info_array[i]);
		}
	}
	[RPC]
	void CurrentCodeAddress_Value(string info)
	{
		Address_Value.Clear();
		if(info == "")
			return;
		string[] info_array = info.Split(',');
		for(int i = 0; i < info_array.Length; i++)
		{
			Address_Value.Add(float.Parse(info_array[i]));
		}
	}
	[RPC]
	void CurrentCodeAddress_Value2(string info)
	{
		Address_Value2.Clear();
		if(info == "")
			return;
		string[] info_array = info.Split(',');
		for(int i = 0; i < info_array.Length; i++)
		{
			Address_Value2.Add(float.Parse(info_array[i]));
		}
	}
	[RPC]
	void CurrentCode()
	{
		Program_Script.CurrentCodeDisplay(G_Display, G_Address, Address_Value, G_Display2, G_Address2, Address_Value2);
	}
	
	[RPC]
	void SetModalIndex(string info)
	{
		ModalIndex.Clear();
		if(info == "")
			return;
		string[] info_array = info.Split(',');
		for(int i = 0; i < info_array.Length; i++)
		{
			ModalIndex.Add(int.Parse(info_array[i]));
		}
	}
	[RPC]
	void SetModalString(string info)
	{
		ModalString.Clear();
		if(info == "")
			return;
		string[] info_array = info.Split(',');
		for(int i = 0; i < info_array.Length; i++)
		{
			ModalString.Add(info_array[i]);
		}
	}
	[RPC]
	void SetModal()
	{
		Program_Script.SetModalState(ModalIndex, ModalString);
	}
	
	
	[RPC]
	void MobileMotion(bool state)
	{	
	}
	
	[RPC]
	void RotateMotion (string xy)
	{
	}
	
    [RPC]
	void ZoomMotion(float dis)
	{
	}
	
	[RPC]
	void MoveMotion(string xy)
	{	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!ClientCenter_Script.client_window_on && !HandWheel_Script.touchMotion){
			if(Input.touchCount > 0){
				//一定时间后才启动Motion控制
				if(!motionAllow){
					pressTime += Time.deltaTime;
					if(pressTime > TIMELIMIT){
						motionAllow = true;
						networkView.RPC("MobileMotion", RPCMode.Server, true);
						pressTime = 0;
					}
				}else{  //启动Motion
					//一个手指旋转
					if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
					{
						pattern = 1;
						x = Input.GetTouch(0).deltaPosition.x;
						y = Input.GetTouch(0).deltaPosition.y;
						if(x > 10f)
							x = x / 10f;
						else
							x = x / 5f;
						if(y > 10f)
							y = y / 10f;
						else
							y = y / 5f;
						networkView.RPC("RotateMotion", RPCMode.Server, x+","+y);
					}
					//一个手指时没有移动，则旋转数据为0
					if(Input.touchCount == 1 && Input.GetTouch(0).phase != TouchPhase.Moved){
						x = 0; y = 0;
						networkView.RPC("RotateMotion", RPCMode.Server, "0,0");
					}
					
					//缩放或者平移
					if(Input.touchCount >= 2){
						//两个或以上手指移动
						if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved){
							//判断是平移还是缩放
							if(!moveZoomOn){
								if(oldPosition1 == Vector2.zero && oldPosition2 == Vector2.zero){
									oldPosition1 = Input.GetTouch(0).position;
									oldPosition2 = Input.GetTouch(1).position;
									return;
								}
								if(MoveZoom(oldPosition1, oldPosition2, Input.GetTouch(0).position, Input.GetTouch(1).position)){  
									move_zoom = true; //平移
								}else{
									move_zoom = false;  //缩放
								}
								moveZoomOn = true;
								oldPosition1 = Input.GetTouch(0).position;
								oldPosition2 = Input.GetTouch(1).position;
							}else{
								if(move_zoom){//平移
									x = Input.GetTouch(0).deltaPosition.x;
									y = Input.GetTouch(0).deltaPosition.y;
									if(x > 10f)
										x = x / 10f;
									else
										x = x / 5f;
									if(y > 10f)
										y = y / 10f;
									else
										y = y / 5f;
									networkView.RPC("MoveMotion", RPCMode.Server, x+","+y);
								}else{//缩放
									newDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
									if(newDistance < oldDistance){
										networkView.RPC("ZoomMotion", RPCMode.Server, 0.2f);
										distance2V = 1;
									}else if(newDistance > oldDistance){
										networkView.RPC("ZoomMotion", RPCMode.Server, -0.2f);
										distance2V = -1;
									}else{
										networkView.RPC("ZoomMotion", RPCMode.Server, 0f);
										distance2V = 0;
									}
									oldDistance = newDistance;
								}
								oldPosition1 = Input.GetTouch(0).position;
								oldPosition2 = Input.GetTouch(1).position;
							}
						}
						
						//最初两个手指静止
						if(Input.GetTouch(0).phase != TouchPhase.Moved && Input.GetTouch(1).phase != TouchPhase.Moved){
							oldDistance = 0;
							newDistance = 0;
							distance2V = 2;
							networkView.RPC("ZoomMotion", RPCMode.Server, 0f);
							x = 0; y = 0;
							networkView.RPC("MoveMotion", RPCMode.Server, "0,0");
						}
					}
				}
			}else{
				if(motionAllow){
					networkView.RPC("MobileMotion", RPCMode.Server, false);
					x = 0;
					y = 0;
					oldPosition1 = Vector2.zero;
					oldPosition2 = Vector2.zero;
					distance2V = 0;
					oldDistance = 0;
					newDistance = 0;
					pattern = 0;
					moveZoomOn = false;
					pressTime = 0;
					motionAllow = false;
				}
			}
		}
			
		
//		//Record the 1st point 
//		if(Input.touchCount > 0 && !old_p1_get)
//		{
//			if(Input.GetTouch(0).phase == TouchPhase.Began)
//			{
//				old_p1_get = true;
//				oldPosition1 = Input.GetTouch(0).position;
//			}
//		}
//		//Record the 2nd point
//		if(Input.touchCount > 1 && !old_p2_get)
//		{
//			if(Input.GetTouch(1).phase == TouchPhase.Began)
//			{
//				old_p2_get = true;
//				oldPosition2 = Input.GetTouch(1).position;
//			}
//		}
//		
//		//multiple point touches
//		if(Input.touchCount > 1 && !enlarge_on)
//		{
//			 //前两只手指触摸类型都为移动触摸  
//	        if(Input.GetTouch(0).phase==TouchPhase.Moved || Input.GetTouch(1).phase==TouchPhase.Moved)  
//	        {  
//                //计算出当前两点触摸点的位置  
//                Vector2 tempPosition1 = Input.GetTouch(0).position;  
//                Vector2 tempPosition2 = Input.GetTouch(1).position;  
//                //函数返回真为放大，返回假为缩小  
//                if(Vector2.Distance(tempPosition1, tempPosition2) > Vector2.Distance(oldPosition1, oldPosition2))  
//                {  
//					//放大
//					if(!enlarge_flag)
//					{
//						distance = 0.5f;      
//						Screen.SetResolution((int)(current_resolutin.width * distance), (int)(current_resolutin.height * distance), true);
//						enlarge_flag = true;
//						enlarge_on = true;
//					}
//	            }else  
//	            {  
//	                //缩小
//					if(enlarge_flag)
//					{
//						distance = 1f;      
//						Screen.SetResolution((int)(current_resolutin.width * distance), (int)(current_resolutin.height * distance), true);
//						enlarge_flag = false;
//						enlarge_on = true;
//					}
//	            }  
//	            //备份上一次触摸点的位置，用于对比  
//	            oldPosition1=tempPosition1;  
//	            oldPosition2=tempPosition2;  
//	        }
//		}
//		
//		//Finger is out of the screen
//		if(old_p1_get)
//		{
//			if(Input.GetTouch(0).phase == TouchPhase.Ended)
//			{
//				old_p1_get = false;
//				old_p2_get = false;
//				enlarge_on = false;
//			}
//		}
	}
	
	/// <summary>
	/// 判断是平移还是缩放
	/// </summary>
	/// <returns>
	/// true:平移; flase:缩放
	/// </returns>
	/// <param name='oldP1'>
	/// If set to <c>true</c> old p1.
	/// </param>
	/// <param name='oldP2'>
	/// If set to <c>true</c> old p2.
	/// </param>
	/// <param name='newP1'>
	/// If set to <c>true</c> new p1.
	/// </param>
	/// <param name='newP2'>
	/// If set to <c>true</c> new p2.
	/// </param>
	bool MoveZoom(Vector2 oldP1,Vector2 oldP2,Vector2 newP1,Vector2 newP2)
	{
		Vector2 p1=newP1-oldP1;
		Vector2 p2=newP2-oldP2;
		float angle= Vector2.Angle(p1,p2);
		if((angle < 60 && angle > -60 ) || (angle < 360 && angle > 300)){
			return true;
		}else{
			return false;
		}
	}

	 
}
