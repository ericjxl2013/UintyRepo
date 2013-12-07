using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AutoToolChangeModule : MonoBehaviour {
	
	#region Modified Paramater By Eric
	ControlPanel Main;
	LightNumber LightControl_Script;
	DisplayMode DisplayMode_Script;
	AutoMoveModule AutoMove_Script;
	string[] toolApronName; //刀座名称
	public Transform[] apron = new Transform[20];  //存放刀座
	Transform[] apronCube = new Transform[20];  //存放刀座上的小方块
	Transform[] apronAxis = new Transform[20];  //存放刀座上的旋转轴
	Transform[] apronSpacer = new Transform[20];  //存放刀座上的垫片
	Transform[] apronBolt = new Transform[20];  //存放刀座上的螺钉
	Transform wheel;  //带有刀位号的转盘
	public Transform[] cutter = new Transform[23];  //存放刀具
	public Transform[] cutterApron = new Transform[23];  //存放刀具座
	public string[] cutterName = new string[23];  //存放刀具名称
	public int[] cutterIndex = new int[23];  //存放刀具号
	public float[] cutterLength = new float[23];  //存放刀具长度值
	public float[] cutterDiamater = new float[23];  //存放刀具直径值
	List<Transform> toolChanger = new List<Transform>();  //存放所有旋转的部件
	List<Transform> selfRotateTrans = new List<Transform>();  //刀座旋转90°至换刀位置
	Transform toolRef;  //位置修正参考物体
	Transform twistGrip;  //旋转换刀手臂
	Transform twistAxis;  //换刀手臂轴
	Transform MainAxis;  //主轴
	Transform Tool_Changer;  //刀库父亲
	bool revolution_on = false;  //公转标志位
	bool selfRotation_on = false;  //自转标志位
	bool move_on = false;  //移动标志位
	public bool manual_tool_change = false; //手动换刀启动标志位
	bool pause_on = false;  //暂停标志位
	int cw = 1;  //顺时针
	Vector3 centre_point = new Vector3(0, 0, 0); //公转中心
	Vector3 rotate_direction = new Vector3(0, 0, 0); //公转方向
	public int currentToolNo = 0;  //当前主轴上的刀具号
	public int buttomToolNo = 0;  //当前刀库底部的刀具号
	public int buttomApronNo = 0; //当前刀库底部的刀座号
	float startTime = 0;  //起始时间
	float endTime = 0;  //终止时间
	bool toolChange_on = false;
	float rotate_speed = 90f;
	float move_speed = 0.5f;
	float move_distance = 0.137f;
	List<Vector3> reviseInfo_Revolution = new List<Vector3>();
	
	string text_num = "1";
	Transform toolTest;
	Transform toolTest2;
	Transform apronTest;
	//-0.4721795,2.806226,-1.360485
	
	public bool display_menu = false;
	Rect menu_rect = new Rect(0,0,0,0);
	
	#endregion
	
	void ModelInitialize()
	{
		rotate_speed = 180f;
		move_speed = 0.5f;
		move_distance = 0.137f;
		toolApronName = new string[] {"tools box_30_", "tools box_31_", "tools box_32_", "tools box_33_", "tools box_34_"};
		try
		{
			toolRef = GameObject.Find("GameObject").transform;
		}
		catch
		{
			Debug.LogError("请添加空的GameObject.");
			return;
		}
		toolRef.name = "tool_reference";
		for(int i = 0; i < 20; i++)
		{
			apron[i] = GameObject.Find(toolApronName[0] + (i+1).ToString()).transform;
			apronAxis[i] = GameObject.Find(toolApronName[4] + (i+1).ToString()).transform;
			apronBolt[i] = GameObject.Find(toolApronName[1] + (i+1).ToString()).transform;
			apronCube[i] = GameObject.Find(toolApronName[3] + (i+1).ToString()).transform; 
			apronSpacer[i] = GameObject.Find(toolApronName[2] + (i+1).ToString()).transform;
		}
		wheel = GameObject.Find("tools box_9").transform;
		for(int i = 0; i < 23; i++)
		{
			cutter[i] = null;
			cutterApron[i] = null;
			cutterIndex[i] = 0;
			cutterName[i] = "null";
			cutterLength[i] = 0;
			cutterDiamater[i] = 0;
		}
		cutterIndex[21] = -1;
		cutterIndex[22] = -1;
		//加载刀具信息配置文件
		string toolsConfigFilePath = Application.dataPath + SystemArguments.ToolsConfigFilePath;
		if(File.Exists(toolsConfigFilePath))
		{
			string[] toolsStringArray;
			int tool_index = 0;
			int apron_index = 0;
			FileStream toolsInfoStream = new FileStream(toolsConfigFilePath, FileMode.Open, FileAccess.Read); 
			StreamReader toolsInfoReader = new StreamReader(toolsInfoStream);
			string strLine = toolsInfoReader.ReadLine();
			while(strLine != null)
			{
				toolsStringArray = strLine.Split(',');
				apron_index = (int)Convert.ToInt32(toolsStringArray[0]);
				tool_index = (int)Convert.ToInt32(toolsStringArray[1]);
				//apron_index = 0代表当前主轴的位置
				if(apron_index == 0)
				{
					//主轴上没有刀具
					if(tool_index == 0)
					{
						cutter[20] = null;
						cutterApron[20] = null;
						cutterIndex[20] = 0;
						cutterName[20] = "null";
						cutterLength[20] = 0;
						cutterDiamater[20] = 0;
					}
					//主轴上有刀具
					else
					{
						cutter[20] = GameObject.Find(toolsStringArray[2]).transform;
						cutterApron[20] = GameObject.Find(toolsStringArray[3]).transform;
						cutter[20].parent = cutterApron[20];
						cutterIndex[20] = tool_index;
						cutterName[20] = toolsStringArray[4];
						cutterLength[20] = (float)Convert.ToDouble(toolsStringArray[5]);
						cutterDiamater[20] = (float)Convert.ToDouble(toolsStringArray[6]);
					}
					Main.toolLength = cutterLength[20];
					Main.toolDiameter = cutterDiamater[20];
				}
				//1-20号刀位号
				else
				{
					//刀座上没有刀具
					if(toolsStringArray[2] == "null")
					{
						cutter[apron_index - 1] = null;
						cutterApron[apron_index - 1] = null;
						cutterIndex[apron_index - 1] = tool_index;
						cutterName[apron_index - 1] = "null";
						cutterLength[apron_index - 1] = 0;
						cutterDiamater[apron_index - 1] = 0;
					}
					//刀座上有刀具
					else
					{
						cutter[apron_index - 1] = GameObject.Find(toolsStringArray[2]).transform;
						cutterApron[apron_index - 1] = GameObject.Find(toolsStringArray[3]).transform;
						cutter[apron_index - 1].parent = cutterApron[apron_index - 1];
						cutterIndex[apron_index - 1] = tool_index;
						cutterName[apron_index - 1] = toolsStringArray[4];
						cutterLength[apron_index - 1] = (float)Convert.ToDouble(toolsStringArray[5]);
						cutterDiamater[apron_index - 1] = (float)Convert.ToDouble(toolsStringArray[6]);
					}
				}
				strLine = toolsInfoReader.ReadLine();  //读取下一行
			}
			toolsInfoReader.Close();
		}
		else
		{
			Debug.LogError(toolsConfigFilePath + "配置文件不存在, 请添加刀具信息配置文件！");
			return;
		}
		currentToolNo = cutterIndex[20];  //当前主轴上的刀具号
		buttomApronNo = 19;  //当前刀库底部的刀位号
		buttomToolNo = cutterIndex[buttomApronNo - 1];  //当前刀库底部的刀具号
		FillRotateTransform();  
		twistGrip = GameObject.Find("tools box_5").transform;
		twistGrip.localPosition = new Vector3(0.07182244f, -0.2987458f, 0.285107f);
		twistGrip.localEulerAngles = new Vector3(0, 194f, 0);
		twistAxis = GameObject.Find("tools box_34").transform;
		twistAxis.localPosition = new Vector3(0.07332871f, -0.1629964f, 0.2931806f);
		GameObject.Find("tools box_3").transform.localPosition = new Vector3(0.2142152f, 0.2192014f, 0.3278214f);
//		ModelInitialize_Script = GameObject.Find("MainScript").GetComponent<ModelInitialize>();
		MainAxis = GameObject.Find("main axle_3").transform;
		Tool_Changer =  GameObject.Find("Tool_Changer").transform;
		
		for(int i = 0; i < 21; i++)
		{
			if(cutter[i] != null)
			{
				cutter[i].gameObject.AddComponent<ToolTipsPick>();
			}
		}
		for(int i = 0; i < apron.Length; i++)
		{
			apron[i].gameObject.AddComponent<BoxCollider>();
			apron[i].gameObject.AddComponent<ToolTipsPick>();
		}
		for(int i = 0; i < 21; i++)
		{
			if(cutterApron[i] != null)
			{
				cutterApron[i].gameObject.AddComponent<BoxCollider>();
				cutterApron[i].gameObject.AddComponent<ToolTipsPick>();
			}
		}
		GameObject.Find("main axle_3").AddComponent<BoxCollider>();
		GameObject.Find("main axle_3").AddComponent<ToolTipsPick>();
		/*
		apronTest = GameObject.Find("tools box_29_4test").transform;
		toolTest = GameObject.Find("7.8 end milltest").transform;
		toolRef.parent = GameObject.Find("main axle_3").transform;
		toolRef.localPosition = new Vector3(0, -0.1903517f, 0);
		toolRef.localEulerAngles = new Vector3(270f, 110.0978f, 0);
		apronTest.position = GameObject.Find("main axle_3").transform.TransformPoint(new Vector3(0, -0.1903517f, 0));
		apronTest.eulerAngles = toolRef.eulerAngles;
		toolRef.localPosition = new Vector3(0, -0.2888265f, 0);
		toolRef.localEulerAngles = new Vector3(270f, 180f, 0);
		toolTest.position = toolRef.position;
		toolTest.eulerAngles = toolRef.eulerAngles; 
		toolTest.parent = GameObject.Find("main axle_3").transform;
		apronTest.parent = GameObject.Find("main axle_3").transform;
		toolTest2 = GameObject.Find("9.8 end mill").transform;
		*/
	}
	
	//将所有的刀库旋转部件加入统一的list结构中
	void FillRotateTransform()
	{
		toolChanger.Clear();
		toolChanger.Add(wheel);
		for(int i = 0; i < 20; i++)
		{
			if(apron[i] != null)
				toolChanger.Add(apron[i]);
			if(apronAxis[i] != null)
				toolChanger.Add(apronAxis[i]);
			if(apronBolt[i] != null)
				toolChanger.Add(apronBolt[i]);
			if(apronCube[i] != null)
				toolChanger.Add(apronCube[i]);
			if(apronSpacer[i] != null)
				toolChanger.Add(apronSpacer[i]);
//			if(cutter[i] != null)
//				toolChanger.Add(cutter[i]);
			if(cutterApron[i] != null)
				toolChanger.Add(cutterApron[i]);
		}
	}
	
	void Start ()
	{
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		LightControl_Script = GameObject.Find("MainScript").GetComponent<LightNumber>();
		DisplayMode_Script = GameObject.Find("MainScript").GetComponent<DisplayMode>();
		AutoMove_Script = GameObject.Find("AutoMove").GetComponent<AutoMoveModule>();
		menu_rect.x = 100f;
		menu_rect.y = 300f;
		menu_rect.width = 300f;
		menu_rect.height = 180f;
		ModelInitialize();
	}
	
	/// <summary>
	/// 时间控制器，控制IEnumerator型函数的运行时间
	/// </summary>
	IEnumerator Timer()
	{
		while(startTime <= endTime)
		{
			yield return new WaitForSeconds(0.01f);
		}
		revolution_on = false;
		selfRotation_on = false;
		move_on = false;
	}
	
	//停顿控制
	IEnumerator PauseTimer(float timeValue)
	{
		yield return new WaitForSeconds(timeValue);
	}
	
	IEnumerator ToolChangeProcess(int tool_no)
	{
		yield return StartCoroutine(ChooseTool(tool_no));  //选刀
		if(toolChange_on)
		{
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(SelfRotate(true));  //刀具运转到换刀位置
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(ChangeTool());  //换刀
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(SelfRotate(false));  //刀具运转回刀库
		}
	}
	
	//M06对应的过程
	public IEnumerator ChangeToolProcess()
	{
		yield return StartCoroutine(SelfRotate(true));  //刀具运转到换刀位置
		yield return StartCoroutine(PauseTimer(0.3f));  //停顿
		yield return StartCoroutine(ChangeTool());  //换刀
		yield return StartCoroutine(PauseTimer(0.3f));  //停顿
		yield return StartCoroutine(SelfRotate(false));  //刀具运转回刀库
		yield return StartCoroutine(PauseTimer(0.3f));  //停顿
	}
	
	
	
	//将指定刀号的刀具转到换刀处，即T指令（T指令对应的过程）
	public IEnumerator ChooseTool(int toolNo)
	{
		if(toolNo > 20 || toolNo < 0)
		{
			Debug.LogError("刀具号" + toolNo + "超出本刀库的刀具号范围, 请重新指定!");
			toolChange_on = false;
			yield break;
		}
		if(currentToolNo == toolNo)  //当前刀具即为指定的刀具，无需换刀
		{
			toolChange_on = false;
			yield break;
		}
		else  //换刀
		{
			toolChange_on = true;
			float rotate_degree = 0;
			if(buttomToolNo == toolNo)  //最底部的刀具即为所需刀具，无需旋转刀位
				yield break;
			else  //将指定刀具旋转到最底部
			{
				int apronPosition = 0;
				for(int i = 0; i < 20; i++)
				{
					if(cutterIndex[i] == toolNo)
					{
						apronPosition = i + 1;
						break;
					}
				}
				if(apronPosition == 0)  //不存在指定的刀具，报警
				{
					Debug.LogError("刀库中不存在" + toolNo + "号刀具，请先将该序号的刀具添加到刀库中.");
					toolChange_on = false;
					yield break;
				}
				else  //旋转角度，顺逆时针计算
				{
					if((apronPosition - buttomApronNo) == 10 || (apronPosition - buttomApronNo) == -10)
					{
						rotate_degree = 180f;
						cw = 1;  //顺时针
					}
					else if((apronPosition - buttomApronNo) > -20 && (apronPosition - buttomApronNo) < -10)
					{
						rotate_degree = (apronPosition - buttomApronNo + 20) * 18f;
						cw = -1;  //逆时针
					}
					else if((apronPosition - buttomApronNo) > -10 && (apronPosition - buttomApronNo) < 0)
					{
						rotate_degree = -(apronPosition - buttomApronNo) * 18f;
						cw = 1;  //顺时针
					}
					else if((apronPosition - buttomApronNo) > 0 && (apronPosition - buttomApronNo) < 10)
					{
						rotate_degree = (apronPosition - buttomApronNo) * 18f;
						cw = -1;  //逆时针
					}
					else
					{
						rotate_degree = (20 - apronPosition + buttomApronNo) * 18f;
						cw = 1;  //顺时针
					}
					startTime = 0;
					rotate_speed = 180f;
					endTime = rotate_degree / rotate_speed;
					centre_point = wheel.position;
					rotate_direction = wheel.TransformDirection(Vector3.forward);
					FillRotateTransform();
					reviseInfo_Revolution.Clear();
					for(int i = 0; i < toolChanger.Count; i++)
					{
						toolRef.position = toolChanger[i].position;
						toolRef.eulerAngles = toolChanger[i].eulerAngles;
						toolRef.RotateAround(centre_point, -cw * rotate_direction, rotate_degree);
						reviseInfo_Revolution.Add(toolRef.position);
						reviseInfo_Revolution.Add(toolRef.eulerAngles);
					}
					revolution_on = true;
					yield return StartCoroutine(Timer());
					for(int i = 0; i < toolChanger.Count; i++)
					{
						toolChanger[i].position = reviseInfo_Revolution[i*2];
						toolChanger[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
					}
					buttomToolNo = toolNo;
					buttomApronNo = apronPosition;
				}
			}
		}
		yield return StartCoroutine(PauseTimer(0.3f));
	}
	
	
	IEnumerator SelfRotate(bool down)
	{
		selfRotateTrans.Clear();
		if(cutter[buttomApronNo - 1] != null)
		{
//			selfRotateTrans.Add(cutter[buttomApronNo - 1]);
			selfRotateTrans.Add(cutterApron[buttomApronNo - 1]);
		}
		selfRotateTrans.Add(apron[buttomApronNo - 1]);
		selfRotateTrans.Add(apronBolt[buttomApronNo - 1]);
		selfRotateTrans.Add(apronSpacer[buttomApronNo - 1]);
		startTime = 0;
		rotate_speed = 180f;
		endTime = 90f / rotate_speed;
		centre_point = apronAxis[buttomApronNo - 1].position;
		rotate_direction = apronAxis[buttomApronNo - 1].TransformDirection(Vector3.right);
		if(down)
			cw = 1;
		else
			cw = -1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.RotateAround(centre_point, -cw * rotate_direction, 90f);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		selfRotation_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		
		
	}
	
	IEnumerator ChangeTool()
	{
		//换刀器旋转90度抓住所需刀具
		selfRotateTrans.Clear();
		selfRotateTrans.Add(twistGrip);
		selfRotateTrans.Add(twistAxis);
		startTime = 0;
		rotate_speed = 270f;
		endTime = 90 / rotate_speed;
		centre_point = twistAxis.position;
		rotate_direction = twistAxis.TransformDirection(Vector3.up);
		cw = 1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.RotateAround(centre_point, -cw * rotate_direction, 90f);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		selfRotation_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		yield return StartCoroutine(PauseTimer(0.3f));
//		pause_on = true;
		//换刀器和刀具向下移动，准备换刀
		selfRotateTrans.Clear();
		if(cutter[20] != null)
		{
//			selfRotateTrans.Add(cutter[20]);
			selfRotateTrans.Add(cutterApron[20]);
			cutter[21] = cutter[20];
			cutterApron[21] = cutterApron[20];
			cutterIndex[21] = cutterIndex[20];
			cutterName[21] = cutterName[20];
			cutterLength[21] = cutterLength[20];
			cutterDiamater[21] = cutterDiamater[20];
		}
		else
		{
			cutter[21] = null;
			cutterApron[21] = null;
			cutterIndex[21] = 0;
			cutterName[21] = "null";
			cutterLength[21] = 0;
			cutterDiamater[21] = 0;
		}
		if(cutter[buttomApronNo - 1] != null)
		{
//			selfRotateTrans.Add(cutter[buttomApronNo - 1]);
			selfRotateTrans.Add(cutterApron[buttomApronNo - 1]);
			cutter[22] = cutter[buttomApronNo - 1];
			cutterApron[22] = cutterApron[buttomApronNo - 1];
			cutterName[22] = cutterName[buttomApronNo - 1];
			cutterLength[22] = cutterLength[buttomApronNo - 1];
			cutterDiamater[22] = cutterDiamater[buttomApronNo - 1];
		}
		else
		{
			cutter[22] = null;
			cutterApron[22] = null;
			cutterName[22] = "null";
			cutterLength[22] = 0;
			cutterDiamater[22] = 0;
		}
		cutterIndex[22] = cutterIndex[buttomApronNo - 1];
		selfRotateTrans.Add(twistGrip);
		selfRotateTrans.Add(twistAxis);
		startTime = 0;
		endTime = move_distance / move_speed;
		cw = -1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.Translate(new Vector3(0, -move_distance, 0), Space.World);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		move_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		yield return StartCoroutine(PauseTimer(0.3f));
		//刀具显示控制
		if(DisplayMode_Script.AllPartsHide())
		{
			if(cutter[20] != null)
			{
				cutter[20].renderer.enabled = false;
				cutterApron[20].renderer.enabled = false;
				cutter[20].gameObject.GetComponent<BoxCollider>().enabled = false;
				cutterApron[20].gameObject.GetComponent<BoxCollider>().enabled = false;
			}
		}
		//旋转180度换刀
		startTime = 0;
		rotate_speed = 270f;
		endTime = 180 / rotate_speed;
		centre_point = twistAxis.position;
		rotate_direction = twistAxis.TransformDirection(Vector3.up);
		cw = 1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.RotateAround(centre_point, -cw * rotate_direction, 180f);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		selfRotation_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		//刀具显示控制
		if(DisplayMode_Script.AllPartsHide())
		{
			if(cutter[buttomApronNo - 1] != null)
			{
				cutter[buttomApronNo - 1].renderer.enabled = true;
				cutterApron[buttomApronNo - 1].renderer.enabled = true;
				cutter[buttomApronNo - 1].gameObject.GetComponent<BoxCollider>().enabled = true;
				cutterApron[buttomApronNo - 1].gameObject.GetComponent<BoxCollider>().enabled = true;
			}
		}
		yield return StartCoroutine(PauseTimer(0.3f));
		//安装刀具入刀位
		startTime = 0;
		endTime = move_distance / move_speed;
		cw = 1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.Translate(new Vector3(0, move_distance, 0), Space.World);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		move_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		currentToolNo = buttomToolNo;
		buttomToolNo = cutterIndex[21];
		cutter[buttomApronNo - 1] = cutter[21];
		cutterApron[buttomApronNo - 1] = cutterApron[21];
		cutterIndex[buttomApronNo - 1] = cutterIndex[21];
		cutterName[buttomApronNo - 1] = cutterName[21];
		cutterLength[buttomApronNo - 1] = cutterLength[21];
		cutterDiamater[buttomApronNo - 1] = cutterDiamater[21];
		cutter[20] = cutter[22];
		cutterApron[20] = cutterApron[22];
		cutterIndex[20] = cutterIndex[22];
		cutterName[20] = cutterName[22];
		cutterLength[20] = cutterLength[22];
		cutterDiamater[20] = cutterDiamater[22];
		Main.toolLength = cutterLength[20];
		Main.toolDiameter = cutterDiamater[20];
		Main.ToolNo = currentToolNo;
		LightControl_Script.SetNumber(Main.ToolNo);
		
		cutterIndex[21] = -1;
		cutterIndex[22] = -1;
		cutterLength[21] = 0;
		cutterLength[22] = 0;
		cutterDiamater[21] = 0;
		cutterDiamater[22] = 0;
		if(cutter[20] != null)
		{
//			cutter[20].parent = MainAxis;
			cutterApron[20].parent = MainAxis;
			cutterApron[20].localPosition = new Vector3(0, -0.1908453f, 0);
			cutterApron[20].localEulerAngles = new Vector3(270f, 109.2f, 0);
//			cutter[20].localPosition = new Vector3(0, cutter[20].localPosition.y, 0);
		}
		if(cutter[buttomApronNo - 1] != null)
		{
//			cutter[buttomApronNo - 1].parent = Tool_Changer;
			cutterApron[buttomApronNo - 1].parent = apron[buttomApronNo - 1];
			cutterApron[buttomApronNo - 1].localPosition = new Vector3(0, 0, -0.04730511f);
			cutterApron[buttomApronNo - 1].localEulerAngles = new Vector3(0, 0, 0);
			cutterApron[buttomApronNo - 1].parent = Tool_Changer;
		}
		
		yield return StartCoroutine(PauseTimer(0.3f));
		//换刀器旋转90度回到原位
		selfRotateTrans.Clear();
		selfRotateTrans.Add(twistGrip);
		selfRotateTrans.Add(twistAxis);
		startTime = 0;
		rotate_speed = 270f;
		endTime = 90 / rotate_speed;
		centre_point = twistAxis.position;
		rotate_direction = twistAxis.TransformDirection(Vector3.up);
		cw = -1;
		reviseInfo_Revolution.Clear();
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			toolRef.position = selfRotateTrans[i].position;
			toolRef.eulerAngles = selfRotateTrans[i].eulerAngles;
			toolRef.RotateAround(centre_point, -cw * rotate_direction, 90f);
			reviseInfo_Revolution.Add(toolRef.position);
			reviseInfo_Revolution.Add(toolRef.eulerAngles);
		}
		selfRotation_on = true;
		yield return StartCoroutine(Timer());
		for(int i = 0; i < selfRotateTrans.Count; i++)
		{
			selfRotateTrans[i].position = reviseInfo_Revolution[i*2];
			selfRotateTrans[i].eulerAngles = reviseInfo_Revolution[i*2 + 1];
		}
		yield return StartCoroutine(PauseTimer(0.3f));
	}
	
	//手动换刀功能
	public IEnumerator ManualToolChange(string tool_num)
	{
		manual_tool_change = true;
		if(AutoMove_Script.CurrentVirtualPos().z != 0)
		{
			Vector3 virtual_target = new Vector3(AutoMove_Script.CurrentVirtualPos().x, AutoMove_Script.CurrentVirtualPos().y, 0);
			Vector3 direction = virtual_target - AutoMove_Script.CurrentVirtualPos();
			float line_time = direction.magnitude / SystemArguments.RapidMoveSpeed * 60;
			yield return StartCoroutine(AutoMove_Script.LineMovement(direction, line_time, virtual_target, -1));
		}
		yield return StartCoroutine(ChooseTool(Convert.ToInt32(tool_num)));  //选刀
		if(toolChange_on)
		{
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(SelfRotate(true));  //刀具运转到换刀位置
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(ChangeTool());  //换刀
			yield return StartCoroutine(PauseTimer(0.3f));  //停顿
			yield return StartCoroutine(SelfRotate(false));  //刀具运转回刀库
		}
		manual_tool_change = false;
	}
	
	//是否允许手动换刀
	public bool ConditionPermits()
	{
		if(manual_tool_change || Main.AutoRunning_flag || Main.MDI_RunningFlag)
			return false;
		else
			return true;
	}
	
	void OnGUI ()
	{
		if(display_menu)
		{
			menu_rect = GUI.Window(54, menu_rect, ToolControl, "Tool Control");
		}
	}
	
	void ToolControl(int WindowID)
	{
		GUI.Label(new Rect(10, 30, 70, 30), "请输入刀号: ");
		
		text_num = GUI.TextField(new Rect(100, 29, 100, 25), text_num);
		
		if(GUI.Button(new Rect(10, 70, 180, 25), "换刀"))
		{
			if(!selfRotation_on && !revolution_on && !move_on)
				StartCoroutine(ToolChangeProcess(Convert.ToInt32(text_num)));
		}
		
		if(GUI.Button(new Rect(110, 130, 80, 30), "关闭"))
		{
			display_menu = false;
		}
		
		GUI.DragWindow();
	}
	
	void FixedUpdate()
	{
		if(!pause_on)
		{
			startTime +=  Time.deltaTime;
			
		}
		
		if(revolution_on && !pause_on)
		{
			for(int i = 0; i < toolChanger.Count; i++)
			{
				toolChanger[i].RotateAround(centre_point, -cw * rotate_direction, rotate_speed * Time.deltaTime);
				
			}
		}
		
		if(selfRotation_on && !pause_on)
		{
			for(int i = 0; i < selfRotateTrans.Count; i++)
			{
				selfRotateTrans[i].RotateAround(centre_point, -cw * rotate_direction, rotate_speed * Time.deltaTime);
				
			}
		}
		
		if(move_on && !pause_on)
		{
			for(int i = 0; i < selfRotateTrans.Count; i++)
			{
				selfRotateTrans[i].Translate(new Vector3(0, cw * move_speed * Time.deltaTime, 0), Space.World);
			}
		}
	}
	
	
}
