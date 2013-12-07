using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class ClientCenter : MonoBehaviour {
	
	ControlPanel Main;
	HandWheelModule HandWheel_Script;
	LightNumber Light_Script;

	public Rect wirelessRect = new Rect(0, 0, 323, 274); //模式选择窗口Rect变量
	public bool client_window_on = true;  //告诉ControlPanel还处在无线连接状态
	bool wireless_window = true; //无线连接窗口
	public GUIStyle sty_ConnectWindow;
	public GUIStyle sty_ConnectBtn;
	Texture2D ConnectInfo1;
	Texture2D ConnectInfo2;
	public GUIStyle ConnectInfo;
	public GUIStyle sty_ConnectFont;
	
	string connectIP = "192.168.0.1";
	string MachineName = "";
	NetworkConnectionError connectError;
	
	void Awake ()
	{
		Main = gameObject.GetComponent<ControlPanel>();
		client_window_on = true;
		wireless_window = true;
		wirelessRect.x = Screen.width/2 - wirelessRect.width/2;
		wirelessRect.y = Screen.height/2 - wirelessRect.height/2;
		MachineName = Dns.GetHostName();
		if(PlayerPrefs.HasKey("ConnectIP"))
		{
			connectIP = PlayerPrefs.GetString("ConnectIP");
		}
		else
		{
			connectIP = "192.168.0.1";
			PlayerPrefs.SetString("ConnectIP", "192.168.0.1");
		}
		
		sty_ConnectWindow.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/WirelessWindowPad");
		sty_ConnectBtn.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/ConnectBtn1");
		sty_ConnectBtn.active.background = (Texture2D)Resources.Load("Texture_Panel/Label/ConnectBtn2");
		ConnectInfo1 = (Texture2D)Resources.Load("Texture_Panel/Label/ConnectInfo1"); 
		ConnectInfo2 = (Texture2D)Resources.Load("Texture_Panel/Label/ConnectInfo2"); 
		ConnectInfo.normal.background = ConnectInfo1;
		sty_ConnectFont.font = (Font)Resources.Load("font/msyh");
		sty_ConnectFont.fontSize = 20;
		sty_ConnectFont.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
		sty_ConnectFont.alignment = TextAnchor.MiddleLeft;
//		sty_ConnectFont.alignment = TextAnchor.MiddleLeft;
	}
	
	// Use this for initialization
	void Start () {
		HandWheel_Script = GameObject.Find("HandleControl").GetComponent<HandWheelModule>();
		Light_Script = gameObject.GetComponent<LightNumber>();
	}
	
	void OnGUI ()
	{
		if(wireless_window)
			wirelessRect = GUI.Window(12, wirelessRect, ConnectWindow, "", sty_ConnectWindow);
	}
	
	void ConnectWindow(int WindowID)
	{
		if(GUI.GetNameOfFocusedControl() == "ConnectField" && Event.current.Equals(Event.KeyboardEvent("return")))
		{
			connectError = Network.Connect(connectIP, SystemArguments.ConnectPort);
		}
		GUI.skin.settings.cursorColor = Color.black;
		GUI.SetNextControlName("ConnectField");
		connectIP = GUI.TextField(new Rect(68, 87, 240, 43), connectIP, 15, sty_ConnectFont);
		connectIP = connectIP.Replace("\n", "");
		if(GUI.Button(new Rect(39.5f, 150, 244, 48), "", sty_ConnectBtn))
		{
			connectError = Network.Connect(connectIP, SystemArguments.ConnectPort);
		}
		
		GUI.Label(new Rect(30f, 223, 266, 38), "", ConnectInfo);
		GUI.DragWindow();
	}
	
	void OnFailedToConnect(NetworkConnectionError error) {
		ConnectInfo.normal.background = ConnectInfo2;
    }
	
	void OnConnectedToServer() {
		PlayerPrefs.SetString("ConnectIP", connectIP);
		client_window_on = false;
		wireless_window = false;
		ConnectInfo.normal.background = ConnectInfo1;
		if(Main.ProgHAN && !Main.SetupGuide_on)
		{
			StartCoroutine(HandWheel_Script.showWheel());
		}
    }
	
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		client_window_on = true;
		wireless_window = true;
		ConnectInfo.normal.background = ConnectInfo1;
		if(Main.ProgHAN && !Main.SetupGuide_on)
		{
			StartCoroutine(HandWheel_Script.closeWheel());
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//设置向导开关控制
	public void SetupGuide(int info)
	{
		networkView.RPC("SetupGuideRPC", RPCMode.Server, info);
	}
	[RPC]
	void SetupGuideRPC(int info)
	{
		Main.CheckBoxControl(info);
	}
	
	//RunningTimeH、RunningTimeM、PartsNum数值传递
	public void RunningMemory(string info)
	{
		networkView.RPC("RunningMemoryRPC", RPCMode.Server, info);
	}
	[RPC]
	void RunningMemoryRPC(string info)
	{
	}
	
	//ShowOffButton开关控制
	public void ShowOffButton(int info)
	{
		networkView.RPC("ShowOffButtonRPC", RPCMode.Server, info);
	}
	[RPC]
	void ShowOffButtonRPC(int info)
	{
		if(info == 1)
			Main.show_off_button_on = true;
		else
			Main.show_off_button_on = false;
		Main.ShowOffButtonFromPad(Main.show_off_button_on);
	}
	
	//OriginalPath开关控制
	public void OriginalPathButton(int info)
	{
		networkView.RPC("OriginalPathButtonRPC", RPCMode.Server, info);
	}
	[RPC]
	void OriginalPathButtonRPC(int info)
	{
		if(info == 1)
			Main.OriginalPathDisplay(true);
		else
			Main.OriginalPathDisplay(false);
	}
	
	//PracticalPath开关控制
	public void PracticalPathButton(int info)
	{
		networkView.RPC("PracticalPathButtonRPC", RPCMode.Server, info);
	}
	[RPC]
	void PracticalPathButtonRPC(int info)
	{
		if(info == 1)
			Main.PathLineDisplay(true);
		else
			Main.PathLineDisplay(false);
	}
	
	//F_operationButton开关控制
	public void F_operationButtonClient(int info)
	{
		networkView.RPC("F_operationButtonRPC", RPCMode.Server, info);
	}
	[RPC]
	void F_operationButtonRPC(int info)
	{
		Main.SpindleControlFromPC(info);
	}
	
	[RPC]
	void SetLightNumRPC(int number)
	{
		Main.ToolNo = number;
		Light_Script.SetNumber(Main.ToolNo);
	}
}
