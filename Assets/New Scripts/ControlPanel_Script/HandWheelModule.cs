using UnityEngine;
using System.Collections;
 
public class HandWheelModule : MonoBehaviour {
	
//	MoveControl MoveControl_script;
	ControlPanel Main;
	ClientCenter Client_Script;
	
	//添加 BY：王广官
	int shang=0;
	float rot_angle = 0;
	public bool move_flag = true;
	public bool wheelshow_flag = false;
	public bool out_ready = false;
	public bool hide_ready = true;
	
	float firstclick_time = 0f;
	float secondclick_time = 0f;
	public bool rotate_flag = false;
	public int axle_state = 1;
	public int scale_state = 6;
	
//	Rect XYZ_Area;
//	Rect speed_Area;
	Vector2 mouse_click = new Vector2 ();
	bool moving = false;
	//添加 BY:WH
	public float win_rect_width;
	public float win_rect_height; 
//	public GUIStyle HandWheel_backgraound;
	private Rect win_rect;
	public float hand_x;
	public float hand_y;
	public float hand_width;
	public float hand_height;
	Rect handWheelPlaneRect;
	public float handWheelOrigin_x;
	public float handWheelOrigin_y;
	Vector2 handWheelOrigin;
	
	public float left_x=10;
	public float left_y=123;
	public float right_x=122;
	public float right_y=123;
	public float num_width=60;
	public float num_height;
//	public Texture2D left_1;
//	public Texture2D left_2;
//	public Texture2D mid;
//	public Texture2D right_1;
//	public Texture2D right_2;
//	public Texture2D left_num;
//	public Texture2D right_num;
	
	public float mode_off_x=50f;
	public float mode_off_y=280f;
	public float mode_off_width=50f;
	public float mode_off_height=50f;
	
	public float mode_x_x=100f;
	public float mode_x_y=250f;
	public float mode_x_width=50f;
	public float mode_x_height=50f;
	
	public float mode_y_x=180f;
	public float mode_y_y=240f;
	public float mode_y_width=50f;
	public float mode_y_height=50f;
	
	public float mode_z_x=260f;
	public float mode_z_y=250f;
	public float mode_z_width=50f;
	public float mode_z_height=50f;
	
	public float mode_4_x=320f;
	public float mode_4_y=280f;
	public float mode_4_width=100f;
	public float mode_4_height=50f;
	
	public float mode_1_x=650f;
	public float mode_1_y=260f;
	public float mode_1_width=100f;
	public float mode_1_height=50f;
	
	public float mode_10_x=750f;
	public float mode_10_y=240f;
	public float mode_10_width=80f;
	public float mode_10_height=50f;
	
	public float mode_100_x=840f;
	public float mode_100_y=260f;
	public float mode_100_width=100f;
	public float mode_100_height=50f;
	// Vector2 handWheelOrigin=new Vector2(355,305);//手轮刻度盘圆心位置
	//Rect handWheelPlaneRect=new Rect(180,130,350,350);//手轮刻度盘贴图的位置
	//private Rect win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
	
	private float left = -550f; 
	private bool come_forth = false;
	public bool motion_start = false;
	private float time_value = 0;
	
	//Rect PanelHandWheel = new Rect(0, 0, 550, 500);
//	public GUIStyle sty_Button;
	public float width = 550F,height = 500F;
	public float X_Offset_HandWheelSet=0;//手轮控制下在X轴方向上的位移
	public float Y_Offset_HandWheelSet=0;//手轮控制下在Y轴方向上的位移
	public float Z_Offset_HandWheelSet=0;//手轮控制下在Z轴方向上的位移
   	bool  HandWheel_OFF=true;//手轮是否处于off状态
    bool  X_HandWheel=false;//手轮进给时X轴选中
	bool  Y_HandWheel=false;//手轮进给时Y轴选中
	bool  Z_HandWheel=false;//手轮进给时Z轴选中
//	bool  Axis4_HandWheel=false;//手轮进给时4轴选中
	float Scale_Offset_HandWheel=0.001f;//手轮进给的单位距离
	public bool handWheelActive=false;//
	Vector3 lastMousePos=new Vector3(0,0,0);
	float currRotateAngle=0;//当前手轮旋转的角度；
 	public float rotatedAngle=0;
//	float sumAngle=0;
	bool initializeLastPos=false;
	
	Vector3 center_vect = new Vector3(0,0,0);
	Vector3 vect_1 = new Vector3 (0,0,0);
	Vector3 vect_2 = new Vector3 (0,0,0);
	Vector3 vect_3 = new Vector3 (0,0,0);
	
	// Rect handWheelRect=new Rect(320,310,125,125);//整个手轮贴图的位置		
    Rect handWheelAreaRect;//手轮激活贴图的位置
//	int size=100;//手轮受力范围
    Vector2 handWheelPoint=new Vector2(410,250);//手轮受力点
	float handWheelRadius=0;
//	float minDistance=0;
//	float maxDistance=0;
	//public float angle=0f;//累计旋转的角度
    float deltaAngle=3.6f;//+1格或-1格的临界角度
//	float rotateMinAngle=2f;//旋转手轮贴图的最小角度
	int handWheelDirection=0;//手轮旋转方向
//	public Texture2D hand;//手轮贴图
//	public Texture2D plane;//刻度盘贴图
//	
//	public Texture2D activeArea;
    bool initializeAngleOffset=false;
    float angleOffset=0;
	public bool isShow;
	//public int Add_Interval_Num=0;
	//public int Sub_Interval_Num=0; 
	//GUI.Button(new Rect(750f/1000f*width, 850f/1000f*height, 50f/1000f*width, 50f/1000f*height), "DOWN"	
	// Use this for initialization
	Vector3 mousePos;
	
	float angleStore = 0;
	
	public bool touchMotion = false;
	
	void Awake()
	{
			
		motion_start=false;
		isShow=false;
		Scale_Offset_HandWheel = 0.000001f;
		
		//添加 BY:WH
		Main=GameObject.Find("MainScript").GetComponent<ControlPanel>();
		Client_Script = GameObject.Find("MainScript").GetComponent<ClientCenter>();
//		HandWheel_backgraound.normal.background=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/0");
//		left_1=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/2");
//		left_2=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/3");
//		mid=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/1");
//		right_1=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/4");
//		right_2=(Texture2D)Resources.Load("DigitalControlPanel/HandWheel/5");
//		plane = (Texture2D)Resources.Load("DigitalControlPanel/HandWheel/6");
//		left_num=left_2;
//		right_num=left_1;
		win_rect_width=188f;
		win_rect_height=win_rect_width/314*785f;
		win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
		hand_x=24;
		hand_y=257;
		hand_width=140;
		hand_height=140;
		handWheelPlaneRect=new Rect(hand_x,hand_y,hand_width,hand_height);
		handWheelOrigin_x=94f;
		handWheelOrigin_y=326.5f;
		handWheelOrigin=new Vector2(handWheelOrigin_x,handWheelOrigin_y);
		center_vect = new Vector3 (handWheelOrigin_x,handWheelOrigin_y ,0);
//		XYZ_Area = new Rect(11,112,67,47);
//		speed_Area = new Rect(122,118,56,33);
		mode_off_x=40f;
		mode_off_y=280f;
		mode_off_width=60f;
		mode_off_height=60f;
	
		mode_x_x=100f;
		mode_x_y=250f;
		mode_x_width=58f;
		mode_x_height=60f;
	
		mode_y_x=172f;
		mode_y_y=240f;
		mode_y_width=60f;
		mode_y_height=62f;
	
		mode_z_x=260f;
		mode_z_y=250f;
		mode_z_width=60f;
		mode_z_height=60f;
	
		mode_4_x=320f;
		mode_4_y=280f;
		mode_4_width=100f;
		mode_4_height=50f;
	
		mode_1_x=650f;
		mode_1_y=260f;
		mode_1_width=100f;
		mode_1_height=50f;
	
		mode_10_x=750f;
		mode_10_y=240f;
		mode_10_width=100f;
		mode_10_height=50f;
	
		mode_100_x=840f;
		mode_100_y=260f;
		mode_100_width=100f;
		mode_100_height=50f;
		
		left_x=10;
		left_y=123;
		right_x=122;
		right_y=123;
		num_width=60;
		num_height=num_width/416*502;
		LoadScriptOfAudio();
	}
	
	
	void LoadScriptOfAudio()
	{
		gameObject.AddComponent<AudioSource>();
		gameObject.audio.playOnAwake = false;
		gameObject.audio.clip = (AudioClip)Resources.Load("Audio/move");
		gameObject.audio.minDistance = 30f;
		
	}
	void Start (){
		if(Main.ProgHAN && !Main.SetupGuide_on && !Client_Script.client_window_on)
		{
			StartCoroutine(showWheel());
		}
		// print(Mathf.Asin(0.5F));
	    handWheelAreaRect=new Rect(handWheelPlaneRect);
		//Debug.Log(handWheelPoint);
	   //Debug.Log(handWheelAreaRect);
		handWheelRadius=(handWheelPoint.x-handWheelOrigin.x)*(handWheelPoint.x-handWheelOrigin.x)+(handWheelPoint.y-handWheelOrigin.y)*(handWheelPoint.y-handWheelOrigin.y);
		handWheelRadius=Mathf.Pow (handWheelRadius,0.5f);
		//Debug.Log(handWheelRadius);
//		minDistance=Mathf.Pow( handWheelRadius,0.5f)-15;
//		maxDistance=Mathf.Pow( handWheelRadius,0.5f)+15;
//		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		
		//MoveControl_script = Main.MoveControl_script;
	}
	
	/*
	// Update is called once per frame
	void Update () {
		//添加 BY:WH
//		win_rect_height=win_rect_width/314*785f;
//		//win_rect = new Rect(-550f, Screen.height - 550f, win_rect_width, win_rect_height);
		handWheelPlaneRect=new Rect(hand_x,hand_y,hand_width,hand_height);
		handWheelOrigin=new Vector2(handWheelOrigin_x,handWheelOrigin_y);
		num_height=num_width/416*502;
		
		//Debug.Log("ccc");
		Vector3 mousePos=Input.mousePosition;
		//Debug.Log(Screen.height-mousePos.y);
		//mousePos.y=Screen.height-mousePos.y;
		//Debug.Log(handWheelAreaRect);
		//Debug.Log(handWheelRect);
		//Debug.Log(mousePos);
		
		//Debug.Log(mousePos.x+"mpppp"+win_rect.x);
		//Debug.Log(win_rect.x+"we");
		mousePos.x-=win_rect.x;
		mousePos.y=Screen.height-mousePos.y;
		mousePos.y-=win_rect.y;
		//Debug.Log("Ok~~"+mousePos.x+" "+mousePos.y);
		//float distance=(mousePos.x-handWheelOrigin.x)*(mousePos.x-handWheelOrigin.x)+(mousePos.y-handWheelOrigin.y)*(mousePos.y-handWheelOrigin.y);
		if(handWheelAreaRect.Contains(mousePos))
		//distance=Mathf.Pow (distance,0.5f);
		//if(distance>minDistance&&distance<maxDistance)
		{   
			//Debug.Log("Ok~~"+mousePos.x+" "+mousePos.y);
			if(Input.GetMouseButtonDown(0))
			{
				//Debug.Log(mousePos);
				if(!initializeAngleOffset)
		       	{
					angleOffset=180 - Mathf.Atan2(mousePos.x- handWheelOrigin.x, mousePos.y - handWheelOrigin.y) * Mathf.Rad2Deg;
					currRotateAngle=angleOffset;
				   
					//currRotateAngle=angleOffset;
					initializeAngleOffset=true;
		       	}
		     	
		   	 	//mousePos.y=Screen.height-mousePos.y;
		    		//Debug.Log(mousePos);
			
				
			 	if(!initializeLastPos)
				{
					lastMousePos=mousePos;
					initializeLastPos=true;
					 // Debug.Log("shubiao click");
				}
			    
				handWheelActive=true;
				move_flag = false;
			}
		 
	      		
		}
//		else
//		{
//			//if(Input.GetMouseButtonUp(0))
//	    		if(handWheelActive)
//			{
//				rotatedAngle+=currRotateAngle-angleOffset;
//			}
			// rotatedAngle+=currRotateAngle-angleOffset;
			//rotatedAngle+=currRotateAngle-angleOffset;
//			handWheelActive=false;
//			initializeLastPos=false;
//			initializeAngleOffset=false;
			//rotatedAngle+=sumAngle;
		 	////  sumAngle=0;
			//Debug.Log(handWheelAreaRect);
//			move_flag = true;
//		}
		if(handWheelActive)
		{
			if(Input.GetMouseButtonUp(0))
	    	{
				rotatedAngle+=currRotateAngle-angleOffset;
				handWheelActive=false;
				initializeLastPos=false;
				initializeAngleOffset=false;

				//sumAngle=0;
				move_flag = true;
	    	}
		}	
	}
	*/
	
	void OnGUI()
	{ 
		mousePos=Input.mousePosition;
		mousePos.y=Screen.height-mousePos.y;
		mousePos.x-=win_rect.x;
		mousePos.y-=win_rect.y;
		
		if(motion_start)
			win_rect.x = left;

		if(wheelshow_flag){
			win_rect =GUI.Window(11, win_rect, Warnning, "",Main.HandWheel_backgraound);
			GUI.BringWindowToFront(11);
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					if(win_rect.Contains(Input.GetTouch(0).position)){	
						touchMotion = true;
					}
				}
			}
		}
		
		if(Input.touchCount == 0){
				if(touchMotion){
					touchMotion = false;
				}
		}
		
		if(firstclick_time !=0f && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
		{
			secondclick_time = Time.time;
			if(secondclick_time - firstclick_time <= 0.2f)
			{
				rotate_flag = true;
				if(!initializeAngleOffset)
		       	{
					angleOffset=180 - Mathf.Atan2(mousePos.x- handWheelOrigin.x, mousePos.y - handWheelOrigin.y) * Mathf.Rad2Deg;
					
					shang = Mathf.FloorToInt (angleOffset/3.6f);
					if(angleOffset-shang*3.6f>1f)
						shang+=1;
					
					angleOffset = shang*3.6f;
					currRotateAngle=angleOffset;   
					initializeAngleOffset=true;
		       	}

			 	if(!initializeLastPos)
				{
					lastMousePos=mousePos;
					initializeLastPos=true;
				}
			    
				handWheelActive=true;
				move_flag = false;	
			}
			
			firstclick_time = 0f;
		}
		
		if(handWheelAreaRect.Contains(mousePos))
		{   
			if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
			{
				if(!initializeAngleOffset)
		       	{
					angleOffset=180 - Mathf.Atan2(mousePos.x- handWheelOrigin.x, mousePos.y - handWheelOrigin.y) * Mathf.Rad2Deg;
					
					shang = Mathf.FloorToInt (angleOffset/3.6f);
					if(angleOffset-shang*3.6f>1f)
						shang+=1;
					
					angleOffset = shang*3.6f;
					currRotateAngle=angleOffset;   
					initializeAngleOffset=true;
		       	}

			 	if(!initializeLastPos)
				{
					lastMousePos=mousePos;
					initializeLastPos=true;
				}
			    
				handWheelActive=true;
				move_flag = false;
			}		
		}
		
		if(handWheelActive)
		{
			if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
	    	{
				firstclick_time = Time.time;
				rotatedAngle+=currRotateAngle-angleOffset;
				handWheelActive=false;
				initializeLastPos=false;
				initializeAngleOffset=false;
				//sumAngle=0;
				move_flag = true;
				rotate_flag = false;
	    	}
		}	
		
		if(move_flag)
			Moving_Window();
		
	}
	
	void Warnning(int WindowID)
	{
		GUI.DrawTexture(new Rect(left_x,left_y,num_width,num_height), Main.left_num);
		GUI.DrawTexture(new Rect(right_x,right_y,num_width,num_height), Main.right_num);
		
		if(GUI.Button(new Rect(left_x+12f, left_y+24f, num_width/2f+3f, num_height/2f-5f),"", Main.sty_ButtonEmpty))
		{
			axle_state += 1;
			
			if(axle_state > 5)
				axle_state = 1;
				
			HandleButtonControl(axle_state);
			Main.HandleButton(axle_state);
		}
		
		if(GUI.Button(new Rect(right_x+12f, right_y+24f ,num_width/2f+3f, num_height/2f-5f),"", Main.sty_ButtonEmpty))
		{
			scale_state += 1;
			
			if(scale_state > 8)
				scale_state = 6;
			
			HandleButtonControl(scale_state);
			Main.HandleButton(scale_state);
		}
		
		if (GUI.Button(new Rect(mode_off_x/1000f*win_rect.width - 5f, mode_off_y/1000f*win_rect.height - 10f, mode_off_width/1000f*win_rect.width + 5f, mode_off_height/1000f*win_rect.height + 10f), "", Main.sty_ButtonEmpty)) //, Main.sty_ButtonEmpty          
		{
			HandWheel_OFF=true;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=false;
//		    Axis4_HandWheel=false;			
			Main.left_num = Main.left_2;
			axle_state = 1;
			Main.HandleButton(1);
		}
		if (GUI.Button(new Rect(mode_x_x/1000f*win_rect.width, mode_x_y/1000f*win_rect.height - 20f, mode_x_width/1000f*win_rect.width + 2f, mode_x_height/1000f*win_rect.height + 20f), "", Main.sty_ButtonEmpty))            
		{
			HandWheel_OFF=false;
			X_HandWheel=true;
			Y_HandWheel=false;
			Z_HandWheel=false;
//		    Axis4_HandWheel=false;
			//MoveControl_script.x_n=true;
			Main.left_num = Main.left_1;
			axle_state = 2;
			Main.HandleButton(2);
		}
		if (GUI.RepeatButton(new Rect(mode_y_x/1000f*win_rect.width, mode_y_y/1000f*win_rect.height - 20f, mode_y_width/1000f*win_rect.width, mode_y_height/1000f*win_rect.height + 23f), "", Main.sty_ButtonEmpty))            
		{
			HandWheel_OFF=false;
			X_HandWheel=false;
	        Y_HandWheel=true;
	        Z_HandWheel=false;
//		    Axis4_HandWheel=false;
			Main.left_num = Main.mid;
			axle_state = 3;
			Main.HandleButton(3);
			//Main.MoveControl_script.speed_to_move = 0.16667F;//内容--JOG模式下，慢常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8				
			//Main.MoveControl_script.move_rate = 1f;
			//Main.MoveControl_script.y_n=true;
			//MoveControl_script.audio.Play();
				
			//MoveControl_script.audio.Stop();
		
		}
		if (GUI.Button(new Rect(mode_z_x/1000f*win_rect.width - 4f, mode_z_y/1000f*win_rect.height - 20f, mode_z_width/1000f*win_rect.width + 4f, mode_z_height/1000f*win_rect.height + 20f), "", Main.sty_ButtonEmpty))            
		{
			HandWheel_OFF=false;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=true;
//		    Axis4_HandWheel=false;
			Main.left_num = Main.right_1;
			axle_state = 4;
			Main.HandleButton(4);
		}
		if (GUI.Button(new Rect(mode_4_x/1000f*win_rect.width, mode_4_y/1000f*win_rect.height - 5f, mode_4_width/1000f*win_rect.width + 3f, mode_4_height/1000f*win_rect.height + 5f), "", Main.sty_ButtonEmpty))            
		{
			HandWheel_OFF=false;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=false;
//		    Axis4_HandWheel=true;
			Main.left_num = Main.right_2;
			axle_state = 5;
			Main.HandleButton(5);
		}
			
		if (GUI.Button(new Rect(mode_1_x/1000f*win_rect.width - 13f, mode_1_y/1000f*win_rect.height - 10f, mode_1_width/1000f*win_rect.width + 13f, mode_1_height/1000f*win_rect.height + 10f), "", Main.sty_ButtonEmpty))            
		{
			Scale_Offset_HandWheel=0.000001f;
			Main.right_num = Main.left_1;
			scale_state = 6;
			Main.HandleButton(6);
		}
		if (GUI.Button(new Rect(mode_10_x/1000f*win_rect.width, mode_10_y/1000f*win_rect.height -20f, mode_10_width/1000f*win_rect.width, mode_10_height/1000f*win_rect.height + 28f), "", Main.sty_ButtonEmpty))            
		{
			Scale_Offset_HandWheel=0.00001f;
			Main.right_num = Main.mid;
			scale_state = 7;
			Main.HandleButton(7);
		}
		if (GUI.Button(new Rect(mode_100_x/1000f*win_rect.width, mode_100_y/1000f*win_rect.height - 10f, mode_100_width/1000f*win_rect.width + 6f, mode_100_height/1000f*win_rect.height + 10f), "", Main.sty_ButtonEmpty))            
		{
			Scale_Offset_HandWheel=0.0001f;
			Main.right_num = Main.right_1;
			scale_state = 8;
			Main.HandleButton(8);
		}
		
		if(GUI.Button(new Rect(44, 214, 50, 40), "", Main.sty_ButtonEmpty)){
			handWheelDirection = 2;
			string info = "";
			info = HandWheel_OFF.ToString() + "," + handWheelDirection.ToString() + "," + Scale_Offset_HandWheel.ToString() + "," + 
				X_HandWheel.ToString() + "," + Y_HandWheel.ToString() + "," + Z_HandWheel.ToString();
			Main.HandWheelControl(info);
			rotatedAngle -= 3.6f;
		}
		
		if(GUI.Button(new Rect(94, 214, 50, 40), "", Main.sty_ButtonEmpty)){
			handWheelDirection = 1;
			string info = "";
			info = HandWheel_OFF.ToString() + "," + handWheelDirection.ToString() + "," + Scale_Offset_HandWheel.ToString() + "," + 
				X_HandWheel.ToString() + "," + Y_HandWheel.ToString() + "," + Z_HandWheel.ToString();
			Main.HandWheelControl(info);
			rotatedAngle += 3.6f;
		}

		if(!handWheelActive)
		{
			shang = Mathf.FloorToInt (rotatedAngle/3.6f);
			if(rotatedAngle-shang*3.6f>=0.1f)
				shang +=1;
			rot_angle = shang*3.6f;
			
			GUIUtility.RotateAroundPivot(rot_angle,handWheelOrigin);
		    GUI.DrawTexture( handWheelPlaneRect, Main.plane);
		}
	    			
		if(handWheelActive)
		{
			//获取当前鼠标坐标
			Vector3 currentMousePos=Input.mousePosition;
			
			//计算在手轮圆心的哪一侧
			currentMousePos.y=Screen.height-currentMousePos.y;
			//根据相对手轮圆心的位置和鼠标y值的变化趋势确定是+1格还是-1格
			currentMousePos.x-=win_rect.x;
			currentMousePos.y-=win_rect.y;
			//用向量叉积判断旋转方向；之前判断方法会出现误判
			center_vect.z = currentMousePos.z;
			vect_1 = center_vect - lastMousePos;
			vect_2 = currentMousePos - lastMousePos;
			vect_3 = Vector3.Cross (vect_1,vect_2);
			if(vect_3.z>0)
			{
				handWheelDirection=2;//-1格；	
				if(X_HandWheel){
					if(MillingData.cxn){
						handWheelActive = false;
						initializeLastPos = false;
						initializeAngleOffset = false;
						move_flag = true;
						rotatedAngle = angleStore;
					}
				}else if(Y_HandWheel){
					if(MillingData.cyn){
						handWheelActive = false;
						initializeLastPos = false;
						initializeAngleOffset = false;
						move_flag = true;
						rotatedAngle = angleStore;
					}
				}else if(Z_HandWheel){
					if(MillingData.czn){
						handWheelActive = false;
						initializeLastPos = false;
						initializeAngleOffset = false;
						move_flag = true;
						rotatedAngle = angleStore;
					}
				}
			}
			if(vect_3.z<0)
			{
				handWheelDirection=1;//-1格；
				if(X_HandWheel){
					if(MillingData.cxp){
						handWheelActive = false;
						initializeLastPos = false;
						initializeAngleOffset = false;
						move_flag = true;
						rotatedAngle = angleStore;
					}
				}else if(Y_HandWheel){
					if(MillingData.cyp){
						handWheelActive = false;
						initializeLastPos = false;
						initializeAngleOffset = false;
						move_flag = true;
						rotatedAngle = angleStore;
					}
				}
			}
			
			float rotateAngle=180 - Mathf.Atan2(currentMousePos.x- handWheelOrigin.x, currentMousePos.y -handWheelOrigin.y) * Mathf.Rad2Deg;
			shang = Mathf.FloorToInt (rotateAngle/3.6f);
			if(rotateAngle-shang*3.6f>0.1f)
				shang+=1;
			rotateAngle = shang*3.6f;
			
			float r=Mathf.Abs((Mathf.Abs(rotateAngle)-Mathf.Abs(currRotateAngle)));
			float thedeltAngle=rotateAngle-angleOffset;
			shang = Mathf.FloorToInt ((thedeltAngle+rotatedAngle)/3.6f);
			if(thedeltAngle+rotatedAngle-shang*3.6f>0.1f)
				shang+=1;
			rot_angle = shang*3.6f;
			angleStore = rot_angle;
			GUIUtility.RotateAroundPivot(rot_angle,handWheelOrigin);
			GUI.DrawTexture( handWheelPlaneRect, Main.plane);
			
			if(r>=2.85f)
			{	
				if(r>200f)
					r=360-r;
				
				if(r<3.15)
					r=3.15f;

				for(int k=0;k< Mathf.FloorToInt(r/3.15f);k++)	
				{
					audio.Play ();
					string info = "";
					info = HandWheel_OFF.ToString() + "," + handWheelDirection.ToString() + "," + Scale_Offset_HandWheel.ToString() + "," + 
						X_HandWheel.ToString() + "," + Y_HandWheel.ToString() + "," + Z_HandWheel.ToString();
					Main.HandWheelControl(info);
				}	
				
				lastMousePos=currentMousePos;
				currRotateAngle=rotateAngle;
			}
			
		}

	}
	
	private void Moving_Window()
	{
		Event e = Event.current;
		
		if (win_rect.Contains(e.mousePosition) && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))&& !handWheelActive)
		{
			mouse_click = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        	moving = true;	
		}
		
		if (moving)
		{
			Vector2 clickDif = new Vector2((Input.mousePosition.x - mouse_click.x), (Screen.height - Input.mousePosition.y - mouse_click.y));
			win_rect.center = new Vector2(win_rect.center.x + clickDif.x, win_rect.center.y + clickDif.y);
			if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
         		 moving = false;
			mouse_click = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		}
	}

	void FixedUpdate ()
	{
		if(motion_start)
		{
			//进去
			if(come_forth)
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(win_rect.x, -550f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = false;
					out_ready = false;
					hide_ready = true;
					wheelshow_flag = false;
					motion_start = false;
					win_rect.y = Screen.height/2 - win_rect.height/2;
				}
				//Debug.Log("out~~");
//				wheelshow_flag = false;
			}
			//出来
			else
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(-550f, 100f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					hide_ready = false;
					out_ready = true;
					come_forth = true;
					motion_start = false;
				}
			}	
		}
	}
	
//	/// <summary>
//	/// 移动手轮及按键让轴XYZ移动-陈晓威 03-5-16
//	/// </summary>
//	void axlePostionChange()
//	{
//		if(!HandWheel_OFF)
//		{	
//			audio.Play();	
//			//Debug.Log(handWheelDirection+"juuu");
//			float distance=0;
//			if(handWheelDirection==1)
//				distance=Scale_Offset_HandWheel;
//			else if(handWheelDirection==2)
//				distance=-Scale_Offset_HandWheel;
//			
//			if(X_HandWheel==true)
//			{
//				//Debug.Log(MoveControl_script.X_part.localPosition.z+"zz");
//				if(MoveControl_script.X_part.localPosition.z+distance<-0.4093075f)
//					distance=-0.4093075f;
//				else if(MoveControl_script.X_part.localPosition.z+distance>0.3906925f)
//					distance=0.3906925f;
//			    else
//					distance+=MoveControl_script.X_part.localPosition.z;
//				
//				MoveControl_script.X_part.localPosition=new Vector3(MoveControl_script.X_part.localPosition.x,MoveControl_script.X_part.localPosition.y,distance);
//			
//			}else if(Y_HandWheel==true)
//			{
//				if(MoveControl_script.Y_part.localPosition.x+distance<-0.3187108f)
//					distance=-0.3187108f;
//				else if(MoveControl_script.Y_part.localPosition.x+distance>0.1812892f)
//					distance=0.1812892f;
//			    else
//					distance+=MoveControl_script.Y_part.localPosition.x;
//				
//				MoveControl_script.Y_part.localPosition=new Vector3(distance,MoveControl_script.Y_part.localPosition.y,MoveControl_script.Y_part.localPosition.z);
//			
//			}else if(Z_HandWheel==true)
//			{
//				if(MoveControl_script.Z_part.localPosition.y+distance<1.609089f)
//					distance=1.609089f;
//				else if(MoveControl_script.Z_part.localPosition.y+distance>2.119089f)
//					distance=2.119089f;
//			    else
//					distance+=MoveControl_script.Z_part.localPosition.y;
//				
//				MoveControl_script.Z_part.localPosition=new Vector3(MoveControl_script.Z_part.localPosition.x,distance,MoveControl_script.Z_part.localPosition.z);
//			
//			}
//			
//		}
//	}
	
	public IEnumerator showWheel()
	{
		if(isShow==false)
		{
			if (!hide_ready)
				yield return StartCoroutine("WaitTime");
			motion_start=true;
			isShow=true;
			wheelshow_flag = true;
		}
	}
	
	public IEnumerator closeWheel()
	{
		if(isShow==true)
		{
			if(!out_ready)
				yield return StartCoroutine("WaitTime");
			motion_start=true;
			isShow=false;
		}
	}
	
	public IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(1f-2*time_value);
	}
	
	public void HandleButtonControl(int type)
	{
		switch(type)
		{
		case 1:
			HandWheel_OFF=true;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=false;		
			Main.left_num = Main.left_2;
			break;
		case 2:
			HandWheel_OFF=false;
			X_HandWheel=true;
			Y_HandWheel=false;
			Z_HandWheel=false;
			Main.left_num = Main.left_1;
			break;
		case 3:
			HandWheel_OFF=false;
			X_HandWheel=false;
	        Y_HandWheel=true;
	        Z_HandWheel=false;
			Main.left_num = Main.mid;
			break;
		case 4:
			HandWheel_OFF=false;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=true;
			Main.left_num = Main.right_1;
			break;
		case 5:
			HandWheel_OFF=false;
			X_HandWheel=false;
			Y_HandWheel=false;
			Z_HandWheel=false;
			Main.left_num = Main.right_2;
			break;
		case 6:
			Scale_Offset_HandWheel=0.000001f;
			Main.right_num = Main.left_1;
			break;
		case 7:
			Scale_Offset_HandWheel=0.00001f;
			Main.right_num = Main.mid;
			break;
		case 8:
			Scale_Offset_HandWheel=0.0001f;
			Main.right_num = Main.right_1;
			break;
		default:
			break;
		}
	}
}
