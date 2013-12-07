using UnityEngine;
using System.Collections;

public class ToolTipsPick : MonoBehaviour {
	InformationTips ToolInfo_Script;
	AutoToolChangeModule ToolControl_Script;
	
	// Use this for initialization
	void Start () {
		ToolInfo_Script = GameObject.Find("MainScript").GetComponent<InformationTips>();
		ToolControl_Script = GameObject.Find("ToolChange").GetComponent<AutoToolChangeModule>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter()
	{
		if(this.transform.name.StartsWith("main axle"))
		{
			ToolInfo_Script.apronNum = "主轴";
			if(ToolControl_Script.cutterName[20] != "null")
			{
				ToolInfo_Script.toolName = ToolControl_Script.cutterName[20];
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[20].ToString();
			}
			else
			{
				ToolInfo_Script.toolName = "无";
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[20].ToString();
			}	
		}
		else if(this.transform.name.StartsWith("tools box_30"))
		{
			int index = -1;
			for(int i = 0; i < ToolControl_Script.apron.Length; i++)
			{
				if(ToolControl_Script.apron[i] == this.transform)
				{
					index = i;
					break;
				}	
			}
			ToolInfo_Script.apronNum = (index + 1).ToString();
			if(ToolControl_Script.cutterName[index] != "null")
			{
				ToolInfo_Script.toolName = ToolControl_Script.cutterName[index];
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
			else
			{
				ToolInfo_Script.toolName = "无";
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
		}
		else if(this.transform.name.StartsWith("tools box_29"))
		{
			int index = -1;
			for(int i = 0; i < 21; i++)
			{
				if(ToolControl_Script.cutterApron[i] == this.transform)
				{
					index = i;
					break;
				}	
			}
			if(index == 20)
				ToolInfo_Script.apronNum = "主轴";
			else
				ToolInfo_Script.apronNum = (index + 1).ToString();
			if(ToolControl_Script.cutterName[index] != "null")
			{
				ToolInfo_Script.toolName = ToolControl_Script.cutterName[index];
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
			else
			{
				ToolInfo_Script.toolName = "无";
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
		}
		else
		{
			int index = -1;
			for(int i = 0; i < 21; i++)
			{
				if(ToolControl_Script.cutter[i] == this.transform)
				{
					index = i;
					break;
				}	
			}
			if(index == 20)
				ToolInfo_Script.apronNum = "主轴";
			else
				ToolInfo_Script.apronNum = (index + 1).ToString();
			if(ToolControl_Script.cutterName[index] != "null")
			{
				ToolInfo_Script.toolName = ToolControl_Script.cutterName[index];
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
			else
			{
				ToolInfo_Script.toolName = "无";
				ToolInfo_Script.toolNum = ToolControl_Script.cutterIndex[index].ToString();
			}
		}
		ToolInfo_Script.tool_information_tips_on = true;
	}
	
	void OnMouseExit()
	{
		ToolInfo_Script.tool_information_tips_on = false;
	}
}
