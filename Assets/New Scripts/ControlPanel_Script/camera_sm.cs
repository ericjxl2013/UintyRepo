using UnityEngine;
using System.Collections;

public class camera_sm : MonoBehaviour {

	// Use this for initialization
	Vector3 p,p1,axe;
	Vector3 old_p;
	public Vector3 center;
	Quaternion old_r;
//	float old_field;
	Vector3 new1,old1;
	public GameObject cen,empty;
	public bool locked;
	public float s1=60.0F;
	public float s2=1.0F;
	Vector3 PreSetPos = new Vector3(0,0,0);
	Vector3 PreSetRot = new Vector3(0,0,0);
	float PreSetDis = 0;
	Vector3 PreSetPos2, PreSetRot2;
	float PreSetDis2 = 0;
	
	public bool display_menu = false;
	Rect menu_rect = new Rect(0,0,0,0);
	ControlPanel Main;
	string btn_showoff = "关闭按钮放大功能";
	
	// Use this for initialization
	void Start () {
		PreSetPos = new Vector3(9.862386f, 5.140882f, -3.500794f);
		PreSetRot = new Vector3(13.10562f, 284.1978f, 1.082746f);
		PreSetDis = 1.6f;
		PreSetDis2 = 1.6f;
		PreSetPos2 = new Vector3(9.304063f, 4.151895f, 3.506118f);
		PreSetRot2 = new Vector3(7.682166f, 244.1652f, 0.04614182f);
		cen=GameObject.Find("CentrePoint");
		old_p=this.transform.position;
		old_r=this.transform.rotation;
//		old_field=camera.fieldOfView;
		menu_rect.x = 100f;
		menu_rect.y = 300f;
		menu_rect.width = 300f;
		menu_rect.height = 240f;
		Main = GameObject.Find("MainScript") .GetComponent<ControlPanel>();
//		if(!PlayerPrefs.HasKey("UserDefinedPosX"))
//		{
//			PlayerPrefs.SetFloat("UserDefinedPosX", 9.862386f);
//			PlayerPrefs.SetFloat("UserDefinedPosY", 5.140882f);
//			PlayerPrefs.SetFloat("UserDefinedPosZ", -3.500794f);
//			PlayerPrefs.SetFloat("UserDefinedRotX", 13.10562f);
//			PlayerPrefs.SetFloat("UserDefinedRotY", 284.1978f);
//			PlayerPrefs.SetFloat("UserDefinedRotZ", 1.082746f);
//			PlayerPrefs.SetFloat("UserDefinedDis", 1.6f);
//		}
	}
	
	//摄像机控制快捷键
	void Update () {
		if((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.transform.position = new Vector3(-0.5766667f, 2.635261f, -11.02586f);
			this.transform.eulerAngles = Vector3.zero;
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.transform.position = new Vector3(-0.6497813f, 2.575102f, 8.894264f);
			this.transform.eulerAngles = new Vector3(0, 180, 0);
		}
	
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.transform.position = new Vector3(10.56248f, 2.598429f, -0.981446f);
			this.transform.eulerAngles = new Vector3(0, 270, 0);
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.transform.position = new Vector3(-0.456807f, 12.30959f, -0.9959471f);
			this.transform.eulerAngles = new Vector3(90, 270, 0);
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.F1))
		{
			this.transform.position = PreSetPos;
			this.transform.eulerAngles = PreSetRot;
			camera.orthographicSize = PreSetDis;
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.F2))
		{
			this.transform.position = PreSetPos2;
			this.transform.eulerAngles = PreSetRot2;
			camera.orthographicSize = PreSetDis2;
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.F3))
		{
			this.transform.position = new Vector3(PlayerPrefs.GetFloat("UserDefinedPosX"), PlayerPrefs.GetFloat("UserDefinedPosY"), PlayerPrefs.GetFloat("UserDefinedPosZ"));
			this.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("UserDefinedRotX"), PlayerPrefs.GetFloat("UserDefinedRotY"), PlayerPrefs.GetFloat("UserDefinedRotZ"));
			camera.orthographicSize = PlayerPrefs.GetFloat("UserDefinedDis");
		}
		
		if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.F4))
		{
			PlayerPrefs.SetFloat("UserDefinedPosX", this.transform.position.x);
			PlayerPrefs.SetFloat("UserDefinedPosY", this.transform.position.y);
			PlayerPrefs.SetFloat("UserDefinedPosZ", this.transform.position.z);
			PlayerPrefs.SetFloat("UserDefinedRotX", this.transform.eulerAngles.x);
			PlayerPrefs.SetFloat("UserDefinedRotY", this.transform.eulerAngles.y);
			PlayerPrefs.SetFloat("UserDefinedRotZ", this.transform.eulerAngles.z);
			PlayerPrefs.SetFloat("UserDefinedDis", camera.orthographicSize);
		}
	}
	void OnGUI() {
		
		if(display_menu)
		{
			menu_rect = GUI.Window(52, menu_rect, CameraControl, "Camera Control");
		}
		
//		Event e = Event.current;			
		if(Input.GetMouseButton(2)&&Input.GetMouseButton(1)==false)					
		{
			axe.x=-Input.GetAxis("Mouse Y");
			axe.y=Input.GetAxis("Mouse X");
			new1=Input.mousePosition;										
			axe.z=0;
			p=camera.transform.TransformDirection(axe);	
			if(new1==old1)
			{
			}				
			else
			{
				camera.transform.RotateAround(center, p, axe.magnitude*2.0F*s1*Time.deltaTime);					
			}
			old1=new1;
		}				
		if(Input.GetMouseButton(2)&&Input.GetMouseButton(1))					
		{
			float delta_x,delta_y;
			float MovingSpeed=0.5F;
			delta_x = Input.GetAxis("Mouse X") * MovingSpeed;
        		delta_y = Input.GetAxis("Mouse Y") * MovingSpeed;
			transform.Translate( new Vector3(-delta_x,-delta_y,0)*0.06F*1.0F*Time.deltaTime*s2,Space.Self);
		}					
		if (Input.GetAxis("Mouse ScrollWheel") != 0) 					
		{
			float delta_z;
			delta_z = (-Input.GetAxis("Mouse ScrollWheel") * 0.2F);
			if(camera.orthographicSize>0.02f ||delta_z>0)
				camera.orthographicSize+=delta_z;
			else
				camera.orthographicSize=0.02F;
			if(camera.orthographicSize<0.02f)
			{
				camera.orthographicSize=0.02F;
			}						
		}			
	}
	
	void CameraControl(int WindowID)
	{
		if(GUI.Button(new Rect(10, 50, 100, 40), "预设角度1"))
		{
			this.transform.position = PreSetPos;
			this.transform.eulerAngles = PreSetRot;
			camera.orthographicSize = PreSetDis;
		}
		
		if(GUI.Button(new Rect(10, 100, 100, 40), "预设角度2"))
		{
			this.transform.position = PreSetPos2;
			this.transform.eulerAngles = PreSetRot2;
			camera.orthographicSize = PreSetDis2;
		}
		
		if(GUI.Button(new Rect(130, 60, 70, 30), "左视图"))
		{
			this.transform.position = new Vector3(-0.5766667f, 2.635261f, -11.02586f);
			this.transform.eulerAngles = Vector3.zero;
//			camera.orthographicSize = 1.56f; 
		}
		
		if(GUI.Button(new Rect(210, 60, 70, 30), "右视图"))
		{
			this.transform.position = new Vector3(-0.6497813f, 2.575102f, 8.894264f);
			this.transform.eulerAngles = new Vector3(0, 180, 0);
//			camera.orthographicSize = 1.56f; 
		}
		
		if(GUI.Button(new Rect(130, 100, 70, 30), "俯视图"))
		{
			this.transform.position = new Vector3(-0.456807f, 12.30959f, -0.9959471f);
			this.transform.eulerAngles = new Vector3(90, 270, 0);
//			camera.orthographicSize = 1.56f; 
		}
		
		if(GUI.Button(new Rect(210, 100, 70, 30), "正视图"))
		{
			this.transform.position = new Vector3(10.56248f, 2.598429f, -0.981446f);
			this.transform.eulerAngles = new Vector3(0, 270, 0);
//			camera.orthographicSize = 1.56f; 
		}
		
		if(GUI.Button(new Rect(90, 150, 120, 30), btn_showoff))
		{
			if(Main.show_off_button_on)
			{
				btn_showoff = "开启按钮放大功能";
				Main.show_off_button_on = false;
			}
			else
			{
				btn_showoff = "关闭按钮放大功能";
				Main.show_off_button_on = true;
			}
		}
		
		if(GUI.Button(new Rect(110, 190, 80, 30), "关闭"))
		{
			display_menu = false;
		}
		
		GUI.DragWindow();
	}
	
	public void CameraMode(int current_state)
	{
		switch(current_state)
		{
		case RightclickMenu.CAMERA_LEFT:
			this.transform.position = new Vector3(-0.5766667f, 2.635261f, -11.02586f);
			this.transform.eulerAngles = Vector3.zero;
			break;
		case RightclickMenu.CAMERA_RIGHT:
			this.transform.position = new Vector3(-0.6497813f, 2.575102f, 8.894264f);
			this.transform.eulerAngles = new Vector3(0, 180, 0);
			break;
		case RightclickMenu.CAMERA_FACELOOK:
			this.transform.position = new Vector3(10.56248f, 2.598429f, -0.981446f);
			this.transform.eulerAngles = new Vector3(0, 270, 0);
			break;
		case RightclickMenu.CAMERA_OVERLOOK:
			this.transform.position = new Vector3(-0.456807f, 12.30959f, -0.9959471f);
			this.transform.eulerAngles = new Vector3(90, 270, 0);
			break;
		case RightclickMenu.PRESET_ONE:
			this.transform.position = PreSetPos;
			this.transform.eulerAngles = PreSetRot;
			camera.orthographicSize = PreSetDis;
			break;
		case RightclickMenu.PRESET_TWO:
			this.transform.position = PreSetPos2;
			this.transform.eulerAngles = PreSetRot2;
			camera.orthographicSize = PreSetDis2;
			break;
		case RightclickMenu.CAMERA_CUSTOM:
			this.transform.position = new Vector3(PlayerPrefs.GetFloat("UserDefinedPosX"), PlayerPrefs.GetFloat("UserDefinedPosY"), PlayerPrefs.GetFloat("UserDefinedPosZ"));
			this.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("UserDefinedRotX"), PlayerPrefs.GetFloat("UserDefinedRotY"), PlayerPrefs.GetFloat("UserDefinedRotZ"));
			camera.orthographicSize = PlayerPrefs.GetFloat("UserDefinedDis");
			break;
		case RightclickMenu.CUSTOM_SETTINGS:
			PlayerPrefs.SetFloat("UserDefinedPosX", this.transform.position.x);
			PlayerPrefs.SetFloat("UserDefinedPosY", this.transform.position.y);
			PlayerPrefs.SetFloat("UserDefinedPosZ", this.transform.position.z);
			PlayerPrefs.SetFloat("UserDefinedRotX", this.transform.eulerAngles.x);
			PlayerPrefs.SetFloat("UserDefinedRotY", this.transform.eulerAngles.y);
			PlayerPrefs.SetFloat("UserDefinedRotZ", this.transform.eulerAngles.z);
			PlayerPrefs.SetFloat("UserDefinedDis", camera.orthographicSize);
			break;
		default:
			break;
		}
	}	
	
	void recover()
	{
		this.transform.position=old_p;
		this.transform.rotation=old_r;
		camera.orthographicSize=10F;	
	}
}
