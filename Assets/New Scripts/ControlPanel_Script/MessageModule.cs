//内容--添加脚本，用于Message模式的显示，姓名--刘旋，时间--2013-4-24
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class MessageModule : MonoBehaviour
{
	ControlPanel Main;
	// Use this for initialization
	void Start ()
	{
		Main = gameObject.GetComponent<ControlPanel> ();
	}
	
	public void Message ()
	{
		if (Main.MessageMenu)
			MessageWindow ();
	}
	
	[RPC]
	void MessageRPC(int info)
	{
		Main.MessageFlip = info;
	}
	
	void MessageWindow ()
	{
		if (Main.MessageFlip == 0) {
			GUI.Label (new Rect ((Main.corner_px + 6.5f) / 1000f * Main.width, (Main.corner_py - 4f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "报 警 信 息", Main.sty_Title);
			GUI.Label (new Rect (Main.corner_px / 1000f * Main.width, (Main.corner_py + 24f) / 1000f * Main.height, Main.screen_sizex / 1000f * Main.width, 258f / 1000f * Main.height), "", Main.sty_ProgSharedWindow);
			GUI.Label (new Rect ((Main.corner_px + 8.5f) / 1000f * Main.width, (Main.corner_py + 30f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "EX1016   MOTORS   OVERLOAD", Main.sty_MessAlarm);
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;   
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label (new Rect ((Main.corner_px + 40f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 70f / 1000f * Main.width, 25f / 1000f * Main.height), "报 警", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 133f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "信 息", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 226f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "履 历", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(347f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(429f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 481f) / 1000f * Main.width, (Main.corner_py + 349f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "+", Main.sty_BottomChooseMenu);
		}
		if (Main.MessageFlip == 1) {
			GUI.Label (new Rect ((Main.corner_px + 6.5f) / 1000f * Main.width, (Main.corner_py - 4f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "操 作 信 息", Main.sty_Title);
			GUI.Label (new Rect (Main.corner_px / 1000f * Main.width, (Main.corner_py + 24f) / 1000f * Main.height, Main.screen_sizex / 1000f * Main.width, 260f / 1000f * Main.height), "", Main.sty_ProgSharedWindow);
			GUI.Label (new Rect ((Main.corner_px + 474f) / 1000f * Main.width, (Main.corner_py + 26f) / 1000f * Main.height, 23f / 1000f * Main.width, 23f / 1000f * Main.height), "", Main.sty_EDITLabelBar_1);
			GUI.Label (new Rect ((Main.corner_px + 474f) / 1000f * Main.width, (Main.corner_py + 49f) / 1000f * Main.height, 23f / 1000f * Main.width, 210f / 1000f * Main.height), "", Main.sty_EDITLabelBar_2);
			GUI.Label (new Rect ((Main.corner_px + 474f) / 1000f * Main.width, (Main.corner_py + 259f) / 1000f * Main.height, 23f / 1000f * Main.width, 23f / 1000f * Main.height), "", Main.sty_EDITLabelBar_3);
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_d;	
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label (new Rect ((Main.corner_px + 40f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 70f / 1000f * Main.width, 25f / 1000f * Main.height), "报 警", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 133f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "信 息", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 226f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "履 历", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(347f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(429f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 481f) / 1000f * Main.width, (Main.corner_py + 349f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "+", Main.sty_BottomChooseMenu);
		}
		if (Main.MessageFlip == 2) {
			GUI.Label (new Rect ((Main.corner_px + 6.5f) / 1000f * Main.width, (Main.corner_py - 4f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "报 警 履 历", Main.sty_Title);
			GUI.Label (new Rect (Main.corner_px / 1000f * Main.width, (Main.corner_py + 24f) / 1000f * Main.height, Main.screen_sizex / 1000f * Main.width, 260f / 1000f * Main.height), "", Main.sty_ProgSharedWindow);
			GUI.Label (new Rect ((Main.corner_px + 286.5f) / 1000f * Main.width, (Main.corner_py + 28f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "警 告 件 数：", Main.sty_MessRecordInfo);
			GUI.Label (new Rect ((Main.corner_px + 466.5f) / 1000f * Main.width, (Main.corner_py + 28f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "50", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 49f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "0001", Main.sty_MessRecordID);
			GUI.Label (new Rect ((Main.corner_px + 66.5f) / 1000f * Main.width, (Main.corner_py + 49f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "2005/02/25 13:05:15", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 75f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "EX1016", Main.sty_MessRecordTime);
			
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 101f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "0002", Main.sty_MessRecordID);
			GUI.Label (new Rect ((Main.corner_px + 66.5f) / 1000f * Main.width, (Main.corner_py + 101f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "2005/02/25 12:57:57", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 127f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "OT0500", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 86.5f) / 1000f * Main.width, (Main.corner_py + 127f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "(Z)正向超程(软限位1)", Main.sty_MessRecordInfo);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 153f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "0003", Main.sty_MessRecordID);
			GUI.Label (new Rect ((Main.corner_px + 66.5f) / 1000f * Main.width, (Main.corner_py + 153f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "2005/02/25 12:57:53", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 179f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "OT0500", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 86.5f) / 1000f * Main.width, (Main.corner_py + 179f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "(Z)正向超程(软限位1)", Main.sty_MessRecordInfo);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 205f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "0004", Main.sty_MessRecordID);
			GUI.Label (new Rect ((Main.corner_px + 66.5f) / 1000f * Main.width, (Main.corner_py + 205f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "2005/02/25 12:44:11", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 231f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "SW0100", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 86.5f) / 1000f * Main.width, (Main.corner_py + 231f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "参数写入开关处于打开", Main.sty_MessRecordInfo);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 257f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "0005", Main.sty_MessRecordID);
			GUI.Label (new Rect ((Main.corner_px + 66.5f) / 1000f * Main.width, (Main.corner_py + 257f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "2005/02/24 09:08:43", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 11.5f) / 1000f * Main.width, (Main.corner_py + 283f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "SW0100", Main.sty_MessRecordTime);
			GUI.Label (new Rect ((Main.corner_px + 86.5f) / 1000f * Main.width, (Main.corner_py + 283f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "参数写入开关处于打开", Main.sty_MessRecordInfo);
			Main.sty_BottomButton_1.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_2.normal.background = Main.t2d_BottomButton_u;	
			Main.sty_BottomButton_3.normal.background = Main.t2d_BottomButton_d;
			Main.sty_BottomButton_4.normal.background = Main.t2d_BottomButton_u;
			Main.sty_BottomButton_5.normal.background = Main.t2d_BottomButton_u;
			GUI.Label (new Rect ((Main.corner_px + 40f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 70f / 1000f * Main.width, 25f / 1000f * Main.height), "报 警", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 133f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "信 息", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 226f) / 1000f * Main.width, (Main.corner_py + 348f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "履 历", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(347f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
//			GUI.Label(new Rect(429f/1000f*Main.width,420f/1000f*Main.height,500f/1000f*Main.width,300f/1000f*Main.height),"", Main.sty_BottomChooseMenu);
			GUI.Label (new Rect ((Main.corner_px + 481f) / 1000f * Main.width, (Main.corner_py + 349f) / 1000f * Main.height, 500f / 1000f * Main.width, 300f / 1000f * Main.height), "+", Main.sty_BottomChooseMenu);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
