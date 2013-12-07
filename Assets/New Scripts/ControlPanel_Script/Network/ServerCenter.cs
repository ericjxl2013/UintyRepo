using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class ServerCenter : MonoBehaviour {
	ControlPanel Main;
	HandWheelModule HandWheel_Script;
	
	public bool wireless_or_standalone = true; //无线或单击运行模式选择窗口控制
	Rect chooseRect = new Rect(0, 0, 300, 200); //模式选择窗口Rect变量
	Rect wirelessRect = new Rect(0, 0, 300, 200); //模式选择窗口Rect变量
	public bool server_window_on = true;  //告诉ControlPanel还处在无线连接状态
	bool wireless_window = false; //无线连接窗口
	
	string DisplayIP1 = "";
	List<string> IPList = new List<string>();
	string MachineName = "";
	
	void Awake()
	{
		Main = gameObject.GetComponent<ControlPanel>();
		wireless_or_standalone = true;
		chooseRect.x = Screen.width/2 - chooseRect.width/2;
		chooseRect.y = Screen.height/2 - chooseRect.height/2;
		server_window_on = true;
		wireless_window = false;
		wirelessRect.x = Screen.width/2 - wirelessRect.width/2;
		wirelessRect.y = Screen.height/2 - wirelessRect.height/2;
		
		MachineName = Dns.GetHostName();
		IPHostEntry   ipHost = Dns.GetHostEntry(Dns.GetHostName()); 
		if(ipHost.AddressList.Length > 1)
		{
			DisplayIP1 = ipHost.AddressList[1].ToString();
			IPList.Add(DisplayIP1);
			if(ipHost.AddressList.Length > 2)
			{
				for(int i = 2; i < ipHost.AddressList.Length; i++)
				{
					IPList.Add(ipHost.AddressList[i].ToString());
				}
			}
			IPList.Add(ipHost.AddressList[0].ToString());
		}
		else
		{
			if(ipHost.AddressList.Length > 0)
			{
				DisplayIP1 = ipHost.AddressList[0].ToString();
				IPList.Add(DisplayIP1);
			}
		}
		foreach(string ip_string in IPList)
			Debug.Log(ip_string);
	}
	// Use this for initialization
	void Start () {
		HandWheel_Script = GameObject.Find("HandleControl").GetComponent<HandWheelModule>();
	}
	
	void OnGUI (){
		if(wireless_or_standalone)
		{
			chooseRect = GUI.Window(9, chooseRect, ModeChoose, "运行模式选择");
		}
		
		if(wireless_window)
		{
			wirelessRect = GUI.Window(10, wirelessRect, WirelessWindow, "无线连接窗口");
		}
	}
	
	void WirelessWindow(int WindowID) {
		GUI.Label(new Rect(10, 15, 100, 20), "本机IP地址: ");
		GUI.Label(new Rect(13, 30, 100, 20), "（优先连接）: ");
		GUI.Box(new Rect(98, 28, 170, 102), "");
		if(IPList.Count == 0)
		{
			DisplayIP1 = "无法获得本机IP, 请检查网络连接是否正常！";
		}
		else if(Network.peerType != NetworkPeerType.Server)
		{
			DisplayIP1 = "无法从本机创建服务器, 请检查网络连接是否正常！";
		}
		else
		{
			DisplayIP1 = "";
			for(int i = 0; i < IPList.Count; i++)
			{
				DisplayIP1 += IPList[i] + "\n";
			}
		}
		GUI.Label(new Rect(100, 30, 160, 100), DisplayIP1);
		if(Network.peerType == NetworkPeerType.Server)
		{
			GUI.Label(new Rect(10, 140, 250, 50), "服务器创建成功，等待无线设备连接！");
		}
		
		if(GUI.Button(new Rect(160, 165, 120, 30), "切换到单击模式"))
		{
			server_window_on = false;
			if(Main.ProgHAN && !Main.SetupGuide_on)
			{
				StartCoroutine(HandWheel_Script.showWheel());
			}
			wireless_window = false;
		}
		GUI.DragWindow();
	}
	
	void ModeChoose(int WindowID) {
		
		if(GUI.Button(new Rect(50, 50, 200, 40), "无线模式"))
		{
			wireless_window = true;
			Network.InitializeServer(100, SystemArguments.ConnectPort, false);
			wireless_or_standalone = false;
		}
		
		if(GUI.Button(new Rect(50, 110, 200, 40), "单机模式"))
		{
			server_window_on = false;
			if(Main.ProgHAN && !Main.SetupGuide_on)
			{
				StartCoroutine(HandWheel_Script.showWheel());
			}
			wireless_or_standalone = false;
		}
		
		GUI.DragWindow();
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
		wireless_window = false;
//		server_window_on = false;
//		if(Main.ProgHAN && !Main.SetupGuide_on)
//		{
//			StartCoroutine(HandWheel_Script.showWheel());
//		}
    }
	
	void OnPlayerDisconnected(NetworkPlayer player) {
		wireless_window = true;
		server_window_on = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			server_window_on = false;
		}
	
	}
}
