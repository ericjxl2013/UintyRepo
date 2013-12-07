using UnityEngine;
using System.Collections;

public class DisplayMode : MonoBehaviour {
	
	AutoToolChangeModule AutoToolChange_Script;
	ModelInitialize ModelInitial_Script;
	Transform machine_parent;
	Transform outer_skin;
	public string display_str = "隐藏机床外壳";
	
	const int SHOW_ALL_PARTS =1;
	const int HIDE_OUTER_SKIN = 2;
	const int HIDE_ALL_PARTS = 3;
	public int current_state;
	// Use this for initialization
	void Start () {
		AutoToolChange_Script = GameObject.Find("ToolChange").GetComponent<AutoToolChangeModule>();
		ModelInitial_Script = GameObject.Find("MainScript").GetComponent<ModelInitialize>();
		machine_parent = GameObject.Find("KD").transform;
		outer_skin = GameObject.Find("OuterSkin1").transform;
		current_state = SHOW_ALL_PARTS;
		display_str = "隐藏机床外壳";
	}
	
	void OnGUI () {
		
	}
	
	/// <summary>
	/// 显示模式控制函数
	/// </summary>
	public void DisplayModeChange()
	{
		switch(current_state)
		{
		case SHOW_ALL_PARTS:
			current_state = HIDE_OUTER_SKIN;
			display_str = "隐藏机床";
			HideRecursion(outer_skin, false);
			GameObject.Find("main protecting crust_11").GetComponent<BoxCollider>().enabled = false;
			GameObject.Find("main protecting crust_12").GetComponent<BoxCollider>().enabled = false;
			break;
		case HIDE_OUTER_SKIN:
			current_state = HIDE_ALL_PARTS;
			display_str = "显示机床";
			HideRecursion(machine_parent, false);
			ModelInitial_Script.blankObj01.renderer.enabled = true;
			if(AutoToolChange_Script.cutter[20] != null)
			{
				AutoToolChange_Script.cutter[20].renderer.enabled = true;
				AutoToolChange_Script.cutterApron[20].renderer.enabled = true;
			}
			ColliderControl(false);
			break;
		case HIDE_ALL_PARTS:
			current_state = SHOW_ALL_PARTS;
			display_str = "隐藏机床外壳";
			HideRecursion(machine_parent, true);
			ColliderControl(true);
			GameObject.Find("main protecting crust_11").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("main protecting crust_12").GetComponent<BoxCollider>().enabled = true;
			break;
		}
	}
	
	/// <summary>
	/// 机床部件显示控制函数
	/// </summary>
	/// <param name='motherTrans'>
	/// 父类Transform
	/// </param>
	/// <param name='display_flag'>
	/// 显示为true，隐藏为false
	/// </param>
	void HideRecursion(Transform motherTrans, bool display_flag)
	{
		foreach(Transform childClass in motherTrans)
		{
			if(childClass.childCount > 0)
			{
				HideRecursion(childClass, display_flag);
				if(childClass.renderer != null)
					childClass.renderer.enabled = display_flag;
			}
			else
			{
				if(childClass.renderer != null)
					childClass.renderer.enabled = display_flag;
			}
		}
	}
	
	void ColliderControl(bool switch_on)
	{
		if(switch_on)
		{
			GameObject.Find("main axle_3").GetComponent<BoxCollider>().enabled = true;
			for(int i = 0; i < 21; i++)
			{
				if(AutoToolChange_Script.cutter[i] != null)
					AutoToolChange_Script.cutter[i].gameObject.GetComponent<BoxCollider>().enabled = true;
			}
			for(int i = 0; i < 20; i++)
			{
				AutoToolChange_Script.apron[i].gameObject.GetComponent<BoxCollider>().enabled = true;
			}
			for(int i = 0; i < 21; i++)
			{
				if(AutoToolChange_Script.cutterApron[i] != null)
					AutoToolChange_Script.cutterApron[i].gameObject.GetComponent<BoxCollider>().enabled = true;
			}
		}
		else
		{
			GameObject.Find("main axle_3").GetComponent<BoxCollider>().enabled = false;
			for(int i = 0; i < 20; i++)
			{
				if(AutoToolChange_Script.cutter[i] != null)
					AutoToolChange_Script.cutter[i].gameObject.GetComponent<BoxCollider>().enabled = false;
			}
			for(int i = 0; i < 20; i++)
			{
				AutoToolChange_Script.apron[i].gameObject.GetComponent<BoxCollider>().enabled = false;
			}
			for(int i = 0; i < 20; i++)
			{
				if(AutoToolChange_Script.cutterApron[i] != null)
					AutoToolChange_Script.cutterApron[i].gameObject.GetComponent<BoxCollider>().enabled = false;
			}
		}
	}
	
	/// <summary>
	/// 判断是否为全部隐藏状态
	/// </summary>
	/// <returns>
	/// 是则返回真，否则为假
	/// </returns>
	public bool AllPartsHide()
	{
		if(current_state == HIDE_ALL_PARTS)
			return true;
		else
			return false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H))
		{
			DisplayModeChange();
		}
	}
}
