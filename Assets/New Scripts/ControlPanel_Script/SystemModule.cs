//内容--添加脚本，用于System模式的显示，姓名--刘旋，时间--2013-4-24
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class SystemModule : MonoBehaviour {
	ControlPanel Main;
	float CursorH=0;
	float CursorV=0;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
	
	}
	public void System()
	{
		if(Main.SystemMenu)
			SystemWindow();
	}
	void SystemWindow()
	{
		if(Main.SystemFlip==0)
		{
			GUI.Label(new Rect((Main.corner_px + 6.5f)/1000f*Main.width,(Main.corner_py - 4f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"参 数", Main.sty_Title);
			GUI.Label(new Rect(Main.corner_px/1000f*Main.width,(Main.corner_py + 24f)/1000f*Main.height,Main.screen_sizex/1000f*Main.width,258f/1000f*Main.height),"", Main.sty_ProgSharedWindow);
			GUI.Label(new Rect((Main.corner_px + 16.5f)/1000f*Main.width,(Main.corner_py + 28f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"设定", Main.sty_Title);
			GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 58f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00000", Main.sty_SysID);
			GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 108f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00001", Main.sty_SysID);
			GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 158f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00002", Main.sty_SysID);
			GUI.Label(new Rect((Main.corner_px + 11.5f)/1000f*Main.width,(Main.corner_py + 208f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"00010", Main.sty_SysID);
			
			for(int i=0; i<32; i++)
			{
				CursorH=(Main.corner_px + 95f +i%8*45f)/1000f*Main.width;
				CursorV=(Main.corner_py + 79f +i/8*50f)/1000f*Main.height;
				GUI.Label(new Rect(CursorH,CursorV,19f/1000f*Main.width,25f/1000f*Main.height),"", Main.sty_OffSet_Coo);
				if(i!=6)
					GUI.Label(new Rect(CursorH+4f/1000f*Main.width,CursorV+2f/1000f*Main.width,19f/1000f*Main.width,25f/1000f*Main.height),"0", Main.sty_SysID);
			}
			GUI.Label(new Rect((Main.corner_px + 98f)/1000f*Main.width,(Main.corner_py + 81f)/1000f*Main.height,14f/1000f*Main.width,20f/1000f*Main.height),"", Main.sty_EDITCursor);
			GUI.Label(new Rect((Main.corner_px + 371f)/1000f*Main.width,(Main.corner_py + 79f)/1000f*Main.height,19f/1000f*Main.width,25f/1000f*Main.height),"1", Main.sty_SysID);
			GUI.Label(new Rect((Main.corner_px + 100f)/1000f*Main.width,(Main.corner_py + 79f)/1000f*Main.height,19f/1000f*Main.width,25f/1000f*Main.height),"0", Main.sty_SysID);	
			GUI.Label(new Rect((Main.corner_px + 180f)/1000f*Main.width,(Main.corner_py + 58f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SEQ", Main.sty_SysInfo);	
			GUI.Label(new Rect((Main.corner_px + 317f)/1000f*Main.width,(Main.corner_py + 58f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"INI ISO TVC", Main.sty_SysInfo);
			GUI.Label(new Rect((Main.corner_px + 360f)/1000f*Main.width,(Main.corner_py + 108f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"FCV", Main.sty_SysInfo);
			GUI.Label(new Rect((Main.corner_px + 92f)/1000f*Main.width,(Main.corner_py + 158f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"SJZ", Main.sty_SysInfo);
			GUI.Label(new Rect((Main.corner_px + 317f)/1000f*Main.width,(Main.corner_py + 208f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"PEC PRM PZS", Main.sty_SysInfo);
			
			
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
		    	Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
		    	Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
		    	Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
		    	Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label(new Rect((Main.corner_px + 2f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"<", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 35f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,70f/1000f*Main.width,25f/1000f*Main.height),"号搜索", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 132f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"ON:1", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 218f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"OFF:0", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 311f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 411f)/1000f*Main.width,(Main.corner_py + 348f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"输入", Main.sty_BottomChooseMenu);
			GUI.Label(new Rect((Main.corner_px + 481f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"+", Main.sty_BottomChooseMenu);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
