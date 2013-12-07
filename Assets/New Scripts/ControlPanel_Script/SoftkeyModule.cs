using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SoftkeyModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
//	MoveControl MoveControl_Script;
	MDIEditModule MDIEdit_Script;
	//使用新编写的NC代码格式化文件 董帅 2013-3-30
	NCCodeFormat NCCodeFormat_Script;
	//位置界面功能完善---宋荣 ---03.09
	PositionModule Pos_Script;
	MDIInputModule MDIInput_Script;
	bool presetAndZero=false; //
	//位置界面功能完善---宋荣 ---03.09
	//Improvement for the RPOG part by Eric---03.28
	public string document_path = "";
	public bool EditList_display_switcher = false;
	Dictionary<char,float> strlenmap;
	
	public float btn_width = 43f;
	public float btn_height = 40f;
	public float l_x=25f;
	public float l_y=425f;
	public float left_x=79;
	public float left_y=53;
	public string code_info = "";
	bool code_on = false;
	string code_string = "";
	//Improvement for the RPOG part by Eric---03.28
	
	void Awake ()
	{
		document_path = Application.dataPath + SystemArguments.NCCodePath;
	}
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		//位置界面功能完善---宋荣 ---03.09
		Pos_Script=gameObject.GetComponent<PositionModule>();
	    MDIInput_Script=gameObject.GetComponent<MDIInputModule>();
		//使用新编写的NC代码格式化文件 董帅 2013-3-30
		NCCodeFormat_Script = gameObject.GetComponent<NCCodeFormat>();
//		MoveControl_Script = GameObject.Find("move_control").GetComponent<MoveControl>();
		//位置界面功能完善---宋荣 ---03.09
//		FileInfoInitialize();
		//calsize字典初始化 陈晓威
		StrLenMapInitializeNewTimes();
	}
	
	public void Softkey () 
	{
		//屏幕下方功能软键++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++	
		if (GUI.Button(new Rect(l_x/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_LEFT))           
		{
			if(Main.ScreenPower)
			{ 
				networkView.RPC("PreviousPage", RPCMode.All);
//				PreviousPage();
			}
		}

		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))        	
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("FirstButton", RPCMode.All);
//				FirstButton();	
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))          	
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("SecondButton", RPCMode.All);
//				SecondButton();
			}
		}
		
		if(Main.panelWindowOnly)
		{
			if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))            
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("ThirdButton", RPCMode.All);
//					ThirdButton();
				}
			}
		}
		else
		{
			if (GUI.Button(new Rect((l_x+3*left_x - 2f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))            
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("ThirdButton", RPCMode.All);
//					ThirdButton();
				}
			}
		}
		
		
		if(Main.panelWindowOnly)
		{
			if (GUI.Button(new Rect((l_x+4*left_x - 1f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))           
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("FourthButton", RPCMode.All);
//					FourthButton();
				}
			}
		}
		else
		{
			if (GUI.Button(new Rect((l_x+4*left_x - 3f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))           
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("FourthButton", RPCMode.All);
//					FourthButton();
				}
			}
		}
		
		if(Main.panelWindowOnly)
		{
			if (GUI.Button(new Rect((l_x+5*left_x - 2f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))           
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("FifthButton", RPCMode.All);
//					FifthButton();
				}
			}
		}
		else
		{
			if (GUI.Button(new Rect((l_x+5*left_x - 4f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_EMPTY))           
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("FifthButton", RPCMode.All);
//					FifthButton();
				}
			}
		}
			
		if(Main.panelWindowOnly)
		{
			if (GUI.Button(new Rect((l_x+6*left_x - 2f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_RIGHT))            
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("NextPage", RPCMode.All);
//					NextPage();
				}
			}
		}
		else
		{
			if (GUI.Button(new Rect((l_x+6*left_x - 4f)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "", Main.Soft_RIGHT))            
			{
				if(Main.ScreenPower)
				{
					networkView.RPC("NextPage", RPCMode.All);
//					NextPage();
				}
			}
		}
		
		
//		if(Main.screenOnly)
//		{
//			if (GUI.Button(new Rect(Main.corner_px/1000f * Main.width,(Main.corner_py + 349f)/1000f * Main.height,20f/1000f * Main.width,25f/1000f * Main.height),"",Main.sty_ButtonEmpty))           
//			{
//				if(Main.ScreenPower)
//					PreviousPage();
//			}
//	
//			if (GUI.Button(new Rect((Main.corner_px + 25f) / 1000f * Main.width, (Main.corner_py + 349f) / 1000f * Main.height, 86f / 1000f * Main.width, 25f / 1000f * Main.height),"",Main.sty_ButtonEmpty))        	
//			{
//				if(Main.ScreenPower)
//					FirstButton();	
//			}
//			
//			if (GUI.Button(new Rect((Main.corner_px + 115f) / 1000f * Main.width, (Main.corner_py + 349f) / 1000f * Main.height, 86f / 1000f * Main.width, 25f / 1000f * Main.height),"",Main.sty_ButtonEmpty))          	
//			{
//				if(Main.ScreenPower)
//					SecondButton();
//			}
//			
//			if (GUI.Button(new Rect((Main.corner_px + 206f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,86f/1000f*Main.width, 25f/1000f*Main.height),"",Main.sty_ButtonEmpty))            
//			{
//				if(Main.ScreenPower)
//					ThirdButton();
//			}
//			
//			if (GUI.Button(new Rect((Main.corner_px + 296f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,86f/1000f*Main.width, 25f/1000f*Main.height),"",Main.sty_ButtonEmpty))           
//			{
//				if(Main.ScreenPower)
//					FourthButton();
//			}
//			
//			if (GUI.Button(new Rect((Main.corner_px + 387f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,86f/1000f*Main.width,25f/1000f*Main.height),"",Main.sty_ButtonEmpty))           
//			{
//				if(Main.ScreenPower)
//					FifthButton();
//			}
//			
//			if (GUI.Button(new Rect((Main.corner_px + 477f)/1000f*Main.width,(Main.corner_py + 349f)/1000f*Main.height,20f/1000f*Main.width,25f/1000f*Main.height),"",Main.sty_ButtonEmpty))            
//			{
//				if(Main.ScreenPower)
//					NextPage();
//			}
//		}
	}
	
	[RPC]
	void RelativePosSet(string info)
	{
	}
	
	[RPC]
	void AbsolutePosSet(int info)
	{
	}
	
	//向前翻页软键
	[RPC]
	void PreviousPage () {
		//程序界面时按下
		//宋荣
		if(Main.PosMenu)
		{
			if(Main.operationBottomScrInitial)
			{
				if(Main.statusBeforeOperation==1)
				{
					Main.RelativeCoo=false;
				    Main.AbsoluteCoo=true;
				    Main.GeneralCoo=false;
				}
				if(Main.statusBeforeOperation==2)
				{
					Main.RelativeCoo=true;
				    Main.AbsoluteCoo=false;
				    Main.GeneralCoo=false;
				}
				if(Main.statusBeforeOperation==3)
				{
					Main.RelativeCoo=false;
				    Main.AbsoluteCoo=false;
				    Main.GeneralCoo=true;
				}
				Main.operationBottomScrInitial=false;
				Main.posOperationMode=false;
				Pos_Script.xBlink=false;
				Pos_Script.yBlink=false;
				Pos_Script.zBlink=false;
				MDIInput_Script.isXSelected=false;
			    MDIInput_Script.isYSelected=false;
				MDIInput_Script.isZSelected=false;
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				//Debug.Log("operationeInitial is true");
			}
			
			else if(Main.operationBottomScrExecute)
			{
				//Debug.Log("operationexec");
				Main.operationBottomScrInitial=true;
				Main.operationBottomScrExecute=false;
				Main.posTimeAndNumber = false;
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=false;
				Main.posTimeAndNumber = false;
			}
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
					}
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 1;
					else if(Main.ProgEDITFlip == 3)
						Main.ProgEDITFlip = 2;
					//内容--程序编辑界面下，程序底部按钮有8种显示方式，因此ProgEDITFlip的值由0到7，在向前翻页按钮命令下，ProgEDITFlip的变化如下
					//姓名--刘旋
					//日期2013-3-14
					else if (Main.ProgEDITFlip==4)
				        Main.ProgEDITFlip=3;
			        else if (Main.ProgEDITFlip==5)
				        Main.ProgEDITFlip=2;
			        else if (Main.ProgEDITFlip==6)
				        Main.ProgEDITFlip=5;
			        else if (Main.ProgEDITFlip==7)
				        Main.ProgEDITFlip=2;//变化内容到此
					else if(Main.ProgEDITFlip==8)
						Main.ProgEDITFlip=4;
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
						Main.ProgEDITProg = true;
						Main.ProgEDITList = false;
					}
				}
			}
			//内容--AUTO模式下，程序界面向前翻页的功能
			//姓名--刘旋，时间--2013-3-25
			if(Main.ProgAUTO)
			{
				if(Main.ProgAUTOFlip==1)//“操作”页返回“程序”页
					Main.ProgAUTOFlip=0;
				//内容--AUTO模式下，程序界面向前翻页按钮功能的修改，姓名--刘旋，时间--2013-4-9
				if(Main.ProgAUTOFlip==2)//“绝对”页返回“程序”页
					Main.ProgAUTOFlip=0;
				if(Main.ProgAUTOFlip==3)//“当前段”页返回“程序”页
					Main.ProgAUTOFlip=0;
				if(Main.ProgAUTOFlip==4)//“相对”页返回“程序”页
					Main.ProgAUTOFlip=0;
				if(Main.ProgAUTOFlip==5)//“下一段”页返回“程序”页
					Main.ProgAUTOFlip=0;
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
			}//增加内容到此
		}
		
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
			if(Main.OffSetSetting)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
		}
	}
	
	//软键 Button1
	[RPC]
	void FirstButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//绝对坐标
			//宋荣
			if(Main.posOperationMode)
			{
				if(Main.operationBottomScrInitial)
			    {
					Main.posTimeAndNumber = false;
				   if(Main.statusBeforeOperation==1)
					{
						Main.operationBottomScrInitial=false;
				        Main.operationBottomScrExecute=true;
				        presetAndZero=true;
					}
					else
					{
						if(Main.InputText != "")
						{
							float float_value = 0;
							string float_str = "";
							if(MDIInput_Script.isXSelected)
							{
								if(Main.InputText.Length == 1)
								{
//									CooSystem_script.RelativeZero.x = -MoveControl_Script.MachineCoo.x;
									string info = "1,0"; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
								}
								else
								{
									float_str = Main.InputText.Remove(0, 1);
//									Debug.Log(float_str);
									float_value = float.Parse(float_str);
									string info = "1," + float_str; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
//									CooSystem_script.RelativeZero.x = float_value - MoveControl_Script.MachineCoo.x;
								}
							}
							if(MDIInput_Script.isYSelected)
							{
								if(Main.InputText.Length == 1)
								{
//									CooSystem_script.RelativeZero.y = -MoveControl_Script.MachineCoo.y;
									string info = "2,0"; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
								}
								else
								{
									float_str = Main.InputText.Remove(0, 1);
									float_value = float.Parse(float_str);
									string info = "2," + float_str; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
//									CooSystem_script.RelativeZero.y = float_value - MoveControl_Script.MachineCoo.y;
								}
							}
							if(MDIInput_Script.isZSelected)
							{
								if(Main.InputText.Length == 1)
								{
//									CooSystem_script.RelativeZero.z = -MoveControl_Script.MachineCoo.z;
									string info = "3,0"; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
								}
								else
								{
									float_str = Main.InputText.Remove(0, 1);
									float_value = float.Parse(float_str);
									string info = "3," + float_str; 
									networkView.RPC("RelativePosSet", RPCMode.Server, info);
//									CooSystem_script.RelativeZero.z = float_value - MoveControl_Script.MachineCoo.z;
								}
							}
							Main.InputText = "";
							Main.CursorText.text = Main.InputText;
							Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
						}
						MDIInput_Script.isXSelected=false;
						MDIInput_Script.isYSelected=false;
						MDIInput_Script.isZSelected=false;
					}
			     }
				return;
			}
			//宋荣
			Main.AbsoluteCoo = true;
			Main.RelativeCoo = false;
			Main.GeneralCoo = false;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					//选择
					if(Main.ProgEDITFlip==2)
					{
						if(Main.CodeForAll.Count == 0)
							return;
				       	Main.IsSelect = true;
					    Main.ProgEDITFlip=3;
					}
			       else if ((Main.ProgEDITFlip==3) || (Main.ProgEDITFlip==50))
				   { //取消选择
					   Main.IsSelect = false;	
					   Main.SelectStart = Main.SelectEnd;
				       Main.ProgEDITFlip = 2;
					}
		           else if (Main.ProgEDITFlip==5)
				   {
				      //取消全选择 
						Main.IsSelect = false;
						Main.ProgEDITFlip=2;
						Main.SelectStart = 0;
						Main.SelectStart = Main.SeparatePosStart[Main.ProgEDITCusorV] + Main.ProgEDITCusorH;
						Main.SelectEnd = Main.SelectStart;	
				   }
					else if (Main.ProgEDITFlip==7)
					{
				      //粘贴buffer
						if(Main.CodeForAll.Count == 1 && Main.CodeForAll[0] == ";")
						{
							Main.CodeForAll.RemoveAt(0);
							Main.TotalCodeNum--;
						}
						if(Main.ProgProtect)
						{
							Main.ProgProtectWarn = true;
							Main.WarnningMessageCreate("WRITE PROTECT");
							calcSepo(Main.CodeForAll, SystemArguments.EditLength1);  //重新格式化代码字符
						}
						else
						{
							int pos = Main.SelectStart + 1;
							int buffer_index = 0;
							while(buffer_index < Main.CodeBuffer.Count)  //插入缓存区中的代码字符
							{
								if(pos > Main.TotalCodeNum - 1)
									Main.CodeForAll.Add(Main.CodeBuffer[buffer_index]);
								else
									Main.CodeForAll.Insert(pos++, Main.CodeBuffer[buffer_index]);
								buffer_index++;
							}
							Main.TotalCodeNum = Main.CodeForAll.Count;
							calcSepo(Main.CodeForAll, SystemArguments.EditLength1);  //重新格式化代码字符
							Main.ProgEDITFlip = 2;
						}
					}
					else if ((Main.ProgEDITFlip==6)||(Main.ProgEDITFlip==4))//内容--增加程序底部按钮显示“8”，用于实现“替换”功能，姓名--刘旋，时间--2013-3-20
						Main.ProgEDITFlip=8;
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
				     {
					 	Main.ProgEDITProg = true;
					 	Main.ProgEDITList = false;
				     }
				}	
			}
			if(Main.ProgAUTO)//内容--AUTO模式下，程序界面，第一个按钮的功能，姓名--刘旋，时间--2013-4-9
			{
				if(Main.ProgAUTOFlip==3)//“当前段”页，按下“程序”按钮，转到“程序”页
				{
					Main.ProgAUTOFlip=0;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				if(Main.ProgAUTOFlip==5)//“下一段”页，按下“程序”按钮，转到“程序”页
				{
					Main.ProgAUTOFlip=0;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				if(Main.ProgAUTOFlip==4)//“相对”页，按下“绝对”按钮，转到“绝对”页
				{
					Main.ProgAUTOFlip=2;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				}
			}
			if(Main.ProgMDI)//内容--MDI模式下，程序界面，第一个按钮的功能，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgMDIFlip=1;
			}
			if(Main.ProgDNC)//内容--DNC模式下，程序界面，第一个按钮的功能，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgDNCFlip=0;
			}
			if(Main.ProgHAN)//内容--HAN模式下，程序界面，第一个按钮的功能，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgHANFlip=0;
			}
			if(Main.ProgJOG || Main.ProgREF)//内容--JOG和REF模式下，程序界面，向后翻页按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgSharedFlip=0;
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = true;
				Main.OffSetSetting = false;
				Main.OffSetCoo = false;
			}
			//刀偏界面号搜索
			if(Main.OffSetTool && Main.OffSetTwo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.SearchToolNo(Main.InputText);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
			else if(Main.OffSetCoo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.SearchNo(Main.InputText);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}	
		}
		
		if(Main.MessageMenu)
		{
			Main.MessageFlip=0;
		}
	}
	
	//软键 Button2
	[RPC]
	void SecondButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//相对坐标
			//宋荣
			if(Main.posOperationMode)
			{
				if(Main.operationBottomScrInitial)
			    {
					Main.posTimeAndNumber = false;
					if(Main.statusBeforeOperation==2 || Main.statusBeforeOperation==3)
					{
						Main.operationBottomScrInitial=false;
				        Main.operationBottomScrExecute=true;
						Main.posTimeAndNumber = false;
						presetAndZero = true;
					}
			     }
				else if(Main.operationBottomScrExecute && (Main.statusBeforeOperation==2 || Main.statusBeforeOperation==3))
				{
					//界面跳回前一页
//					CooSystem_script.RelativeZero = -MoveControl_Script.MachineCoo;
					string info = "1,0"; 
					networkView.RPC("RelativePosSet", RPCMode.Server, info);
					info = "2,0"; 
					networkView.RPC("RelativePosSet", RPCMode.Server, info);
					info = "3,0"; 
					networkView.RPC("RelativePosSet", RPCMode.Server, info);
					Main.operationBottomScrInitial=true;
					Main.operationBottomScrExecute=false;
					Pos_Script.xBlink=false;
					Pos_Script.yBlink=false;
					Pos_Script.zBlink=false;
					MDIInput_Script.isXSelected=false;
					MDIInput_Script.isYSelected=false;
					MDIInput_Script.isZSelected=false;
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}else if(Main.operationBottomScrExecute && Main.statusBeforeOperation==1)
				{
//					CooSystem_script.AbsoluteZero = -CooSystem_script.G00_pos - CooSystem_script.workpiece_coo;
					networkView.RPC("AbsolutePosSet", RPCMode.Server, 1);
					networkView.RPC("AbsolutePosSet", RPCMode.Server, 2);
					networkView.RPC("AbsolutePosSet", RPCMode.Server, 3);
					//CooSystem_script.absolute_pos = MoveControl_Script.MachineCoo - CooSystem_script.G00_pos - CooSystem_script.workpiece_coo;
					Main.operationBottomScrInitial=true;
					Main.operationBottomScrExecute=false;
					Pos_Script.xBlink=false;
					Pos_Script.yBlink=false;
					Pos_Script.zBlink=false;
					MDIInput_Script.isXSelected=false;
					MDIInput_Script.isYSelected=false;
					MDIInput_Script.isZSelected=false;
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
				return;
			}
			//宋荣
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = true;
			Main.GeneralCoo = false;
		}
		
		//程序界面时按下
		if(Main.ProgMenu)
		{//1 level
			if(Main.ProgEDIT)
			{//2 level
				if(Main.ProgEDITProg)
				{
					//到最后
					if (Main.ProgEDITFlip==3)
					{
						if(Main.CodeForAll.Count == 0)
							return;
					    Main.ProgEDITFlip = 50;
						Main.SelectEnd = Main.CodeForAll.Count - 1;
						Main.StartRow = (Main.SeparatePosEnd.Count - 1) / SystemArguments.EditLineNumber * SystemArguments.EditLineNumber;
						Main.EndRow=Main.StartRow + SystemArguments.EditLineNumber;
						Main.ProgEDITCusorV = Main.SeparatePosEnd.Count - 1;
						Main.ProgEDITCusorH = Main.CodeForAll.Count - 1 - Main.SeparatePosStart[Main.ProgEDITCusorV];
					}
					
					//全选择 
					else if (Main.ProgEDITFlip==2)
					{
						if(Main.CodeForAll.Count == 0)
							return;
					     Main.ProgEDITFlip = 5;
						 Main.SelectStart = 0;
						 Main.SelectEnd = Main.CodeForAll.Count - 1;
					}
					else if (Main.ProgEDITFlip==0)
					{
						Main.ProgEDITList = true;
						Main.ProgEDITProg = false ;
					}	
					//O检索
					else if(Main.ProgEDITFlip==1)
					{
//						O_Search();
						if(!Main.AutoRunning_flag && !Main.MDI_RunningFlag)
						{
							code_info = "";
//							O_Search_PadRPC();
//							Locate_At_Position(Main.RealListNum);
//							LocationAtPRC();
						}
						else
						{
							Main.InputText="";
							Main .ProgEDITCusorPos = Main.corner_px + 23.5f;
							Main.EDITText.text="";
						}
					}
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
					{
						if(Main.at_position >= 0)
						{
							Locate_At_Position(Main.RealListNum);
//							LocationAtPRC();
						}
					}
					if(Main.ProgEDITFlip == 1)
					{
						//O检索
//						O_Search();	
						if(!Main.AutoRunning_flag && !Main.MDI_RunningFlag)
						{
							code_info = "";
//							O_Search_PadRPC();
//							Locate_At_Position(Main.RealListNum);
//							LocationAtPRC();
						}
						else
						{
							Main.InputText="";
							Main .ProgEDITCusorPos = Main.corner_px + 23.5f;
							Main.EDITText.text="";
						}
					}
				}
			}//2 level
			
			//内容--AUTO模式下，程序界面，第二个按钮的功能
			//姓名--刘旋，时间--2013-3-25
			if (Main.ProgAUTO)
			{
				//Debug.Log(Main.ProgAUTOFlip);
				if(Main.ProgAUTOFlip==0)//“程序”页，按下“检测”按钮，转到“绝对”页
				{
					Main.ProgAUTOFlip=2;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				}
				//内容--AUTO模式下，程序界面，第二个按钮功能的修改，姓名--刘旋，时间--2013-4-9
				else if(Main.ProgAUTOFlip==2)//“绝对”页，按下“相对”按钮，转到“相对”页
				{
					Main.ProgAUTOFlip=4;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				}
				else if(Main.ProgAUTOFlip==3)//内容--“当前段”页，按下“检索”按钮，转到“绝对”页，姓名--刘旋，时间--2013-4-11
				{
					Main.ProgAUTOFlip=2;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				}
				else if(Main.ProgAUTOFlip==5)//内容--“下一段”页，按下“检索”按钮，转到“绝对”页，姓名--刘旋，时间--2013-4-11
				{
					Main.ProgAUTOFlip=2;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, false);
				}
			}//增加内容到此
			
			if(Main.ProgMDI)
			{
				Main.ProgMDIFlip=0;
			}	
		}//1 level
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = true;
				Main.OffSetCoo = false;
			}
			else if(Main.OffSetCoo)
			{
				CooSystem_script.Measure(Main.InputText);
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
			}
		}
		
		if(Main.MessageMenu)
		{
			Main.MessageFlip=1;
		}
	}
	
	//软键 Button3
	[RPC]
	void ThirdButton () 
	{
		//位置界面时按下
		if(Main.PosMenu)
		{
			//综合显示
			//宋荣
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = false;
			Main.GeneralCoo = true;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//向下检索 ---陈晓威 董帅
				if(Main.ProgEDITFlip == 1)
				{
				    Main.NotFoundWarn = false;
					Main.WarnningClear();
					string SearchWord = Main.InputText.Trim();
					if(SearchWord.Equals("")) //匹配的字符串为空
					{
						Main.NotFoundWarn = false;
						Main.WarnningClear();
					}
					else  // 不为空
					{
						bool search_type = false;  //false为地址搜索
						Regex name_Reg = new Regex(@"^[A-Z]+$");
						if(name_Reg.IsMatch(SearchWord))  //地址搜索
						{
							search_type = false; 
						}
						else if(SearchWord == "=")  //地址搜索
						{
							search_type = false; 
						}
						else if(SearchWord == ";")  //地址搜索
						{
							search_type = false; 
						}
						else  //字搜索
						{
							search_type = true; 
						}
						
						int CurIndex = 0; //搜索开始位置
						if(Main.SelectStart == Main.CodeForAll.Count - 1)
						{
							CurIndex = 0;
							Main.SelectStart = 0;
							Main.SelectEnd = 0;
							Main.StartRow = 0;
							Main.EndRow = SystemArguments.EditLineNumber;
							Main.ProgEDITCusorH = 0;
							Main.ProgEDITCusorV = 0;
						}
						else
							CurIndex = Main.SelectStart + 1;
//						calcSepo(Main.CodeForAll, Main.SeparatePos, SystemArguments.EditLength1);
						int irow = Main.ProgEDITCusorV;
						for(; CurIndex < Main.CodeForAll.Count; CurIndex++)
						{
							if(CurIndex >= Main.SeparatePosEnd[irow])
								irow++;
							if(search_type)
							{
								if(Main.CodeForAll[CurIndex] == SearchWord)
									break;
							}
							else
							{
								if(Main.CodeForAll[CurIndex].StartsWith(SearchWord))
									break;
							}
						}
						//如果已经找到
						if(CurIndex < Main.CodeForAll.Count)
						{
							Main.NotFoundWarn = false;
							Main.WarnningClear();
							Main.StartRow=irow / SystemArguments.EditLineNumber * SystemArguments.EditLineNumber;
							Main.EndRow=Main.StartRow + SystemArguments.EditLineNumber;
							Main.SelectStart = CurIndex;
							Main.SelectEnd=Main.SelectStart;
							Main.ProgEDITCusorV = irow;
							Main.ProgEDITCusorH = Main.SelectStart - Main.SeparatePosStart[irow];	
						}
						else
						{//找不到的情况
							Main.StartRow = irow / SystemArguments.EditLineNumber * SystemArguments.EditLineNumber;
							Main.EndRow = Main.StartRow + SystemArguments.EditLineNumber;
							Main.NotFoundWarn = true;
							Main.WarnningMessageCreate("未找到字符!");
							Main.SelectStart = Main.CodeForAll.Count - 1;
							Main.SelectEnd = Main.SelectStart;
							Main.ProgEDITCusorV = irow;
							Main.ProgEDITCusorH = Main.SelectStart - Main.SeparatePosStart[irow];			
						}
					}
				}
				
				//选择 复制
				if(Main.ProgEDITFlip == 3 || Main.ProgEDITFlip == 5 || Main.ProgEDITFlip == 50)
				{
				    Debug.Log("Main.ProgEDITFlip:"+Main.ProgEDITFlip);
					Main.CodeBuffer.Clear();
					int SelStart = Main.SelectStart > Main.SelectEnd? Main.SelectEnd:Main.SelectStart;
					int SelEnd = Main.SelectStart > Main.SelectEnd? Main.SelectStart:Main.SelectEnd;
					for(int i = SelStart; i <= SelEnd; ++i)
						Main.CodeBuffer.Add(Main.CodeForAll[i]);
					Main.ProgEDITFlip = 2;
				    Main.IsSelect = false;
					Main.SelectStart = Main.SelectEnd;
				}
				if(Main.ProgEDITProg)
				{
					
				}
				if(Main.ProgEDITList)
				{
	
				}
			}//变化内容到此
			
			//内容--AUTO模式下，程序界面，第三个按钮的功能
			//姓名--刘旋，时间--2013-3-25
			if (Main.ProgAUTO)
			{
				if(Main.ProgAUTOFlip==0)//“程序”页，按下“当前段”按钮，转到“当前段”页
					Main.ProgAUTOFlip=3;
				//内容--AOTO模式下，程序界面，第三个按钮功能的修改，姓名--刘旋，时间--2013-4-9
				if(Main.ProgAUTOFlip==5)//“下一度”页，按下“当前段”按钮，转到“当前段”页
					Main.ProgAUTOFlip=3;
			}//增加能容到此
			if(Main.ProgMDI)//内容--MDI模式下，程序界面，第三个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
			     if(Main.ProgMDIFlip==0)
					Main.ProgMDIFlip=2;
				else if(Main.ProgMDIFlip==1)
					Main.ProgMDIFlip=2;
				else if(Main.ProgMDIFlip==3)
					Main.ProgMDIFlip=2;
			}
			if(Main.ProgDNC)//内容--DNC模式下，程序界面，第三个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
			    Main.ProgDNCFlip=1;;
			}
			if(Main.ProgHAN)//内容--HAN模式下，程序界面，第三个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
			    Main.ProgHANFlip=1;
			}
			if(Main.ProgJOG || Main.ProgREF)//内容--JOG和REF模式下，程序界面，向后翻页按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
			    Main.ProgSharedFlip=1;
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = false;
				Main.OffSetCoo = true;
			}
			//刀偏界面的C输入
			else if(Main.OffSetTool && Main.OffSetTwo)
			{
				 if(Main.InputText != "")
				{	
					CooSystem_script.C_Input(Main.InputText);		
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
		}
		
		if(Main.MessageMenu)
		{
			Main.MessageFlip=2;
		}
	}
	
	//软键 Button4
	[RPC]
	void FourthButton () 
	{	
		//宋荣
		if(Main.PosMenu)
		{
			if(Main.operationBottomScrInitial)
			{
				Main.operationBottomScrInitial=false;
				Main.operationBottomScrExecute=true;
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=true;
				Main.posTimeAndNumber = true;
				Pos_Script.xBlink=false;
				Pos_Script.yBlink=false;
				Pos_Script.zBlink=false;
				MDIInput_Script.isXSelected=false;
				MDIInput_Script.isYSelected=false;
				MDIInput_Script.isZSelected=false;
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
			}
		}
		//宋荣
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITFlip == 0)
				{
					
				}//向上检索
				else if(Main.ProgEDITFlip == 1)
				{
					Main.NotFoundWarn = false;
					Main.WarnningClear();
					string SearchWord = Main.InputText.Trim();	
					if(SearchWord != "")
					{
						bool search_type = false;  //false为地址搜索
						Regex name_Reg = new Regex(@"^[A-Z]+$");
						if(name_Reg.IsMatch(SearchWord))  //地址搜索
						{
							search_type = false; 
						}
						else if(SearchWord == "=")  //地址搜索
						{
							search_type = false; 
						}
						else if(SearchWord == ";")  //地址搜索
						{
							search_type = false; 
						}
						else  //字搜索
						{
							search_type = true; 
						}
						
						int CurIndex = 0;
						if(Main.SelectEnd == 0)
						{
							CurIndex = Main.CodeForAll.Count - 1;
							Main.SelectEnd = Main.CodeForAll.Count - 1;
							Main.StartRow = (Main.SeparatePosEnd.Count - 1) / SystemArguments.EditLineNumber * SystemArguments.EditLineNumber;
							Main.EndRow=Main.StartRow + SystemArguments.EditLineNumber;
							Main.ProgEDITCusorV = Main.SeparatePosEnd.Count - 1;
							Main.ProgEDITCusorH = Main.CodeForAll.Count - 1 - Main.SeparatePosStart[Main.ProgEDITCusorV];
						}
						else
							CurIndex = Main.SelectEnd - 1;
						int irow = Main.ProgEDITCusorV;
						for(; CurIndex >= 0; CurIndex--)
						{
							if(CurIndex < Main.SeparatePosStart[irow])
								irow--;
							if(search_type)
							{
								if(Main.CodeForAll[CurIndex] == SearchWord)
									break;
							}
							else
							{
								if(Main.CodeForAll[CurIndex].StartsWith(SearchWord))
									break;
							}
						}
						//如果已经找到
						if(CurIndex >= 0)
						{
							Main.NotFoundWarn = false;
							Main.WarnningClear();
							Main.StartRow = irow / SystemArguments.EditLineNumber * SystemArguments.EditLineNumber;
							Main.EndRow = Main.StartRow + SystemArguments.EditLineNumber;
							Main.SelectStart = CurIndex;
							Main.SelectEnd=Main.SelectStart;
							Main.ProgEDITCusorV = irow;
							Main.ProgEDITCusorH = Main.SelectStart - Main.SeparatePosStart[irow];	
						}
						else
						{//找不到的情况
							Main.StartRow = 0;
							Main.EndRow = SystemArguments.EditLineNumber;
							Main.NotFoundWarn = true;
							Main.WarnningMessageCreate("未找到字符!");
							Main.SelectStart = 0;
							Main.SelectEnd = 0;
							Main.ProgEDITCusorV = 0;
							Main.ProgEDITCusorH = 0;			
						}
					}
					else
					{
						Main.NotFoundWarn = false;
						Main.WarnningClear();
					}
				}
				else if(Main.ProgEDITFlip == 2)
				{
					
				}
				else if(Main.ProgEDITFlip == 3||Main.ProgEDITFlip == 5||Main.ProgEDITFlip == 50)
				{
					//剪切				
					Main.CodeBuffer.Clear();
					int SelStart = Main.SelectStart > Main.SelectEnd? Main.SelectEnd:Main.SelectStart;
					int SelEnd = Main.SelectStart > Main.SelectEnd? Main.SelectStart:Main.SelectEnd;
					for(int i = SelStart; i <= SelEnd; ++i)
					    Main.CodeBuffer.Add(Main.CodeForAll[i]);
					if(Main.ProgProtect)
					{
						Main.ProgProtectWarn = true;
						Main.WarnningMessageCreate("WRITE PROTECT");
					}
					else
						MDIEdit_Script.DeleteCode();
				}
				else 
				{
					
				}
			}
			if(Main.ProgAUTO)//内容--AUTO模式下，程序界面，第四个按钮的功能，姓名--刘旋，时间--2013-4-9
			{
				if(Main.ProgAUTOFlip==0)//“程序”页，按下“下一段”按钮，转到“下一段”页
					Main.ProgAUTOFlip=5;
				else if(Main.ProgAUTOFlip==3)//“当前段”页，按下“下一段”按钮，转到“下一段”页
					Main.ProgAUTOFlip=5;
			}
			if(Main.ProgMDI)//内容--MDI模式下，程序界面，第四个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
				if(Main.ProgMDIFlip==0)
					Main.ProgMDIFlip=3;
				else if(Main.ProgMDIFlip==1)
					Main.ProgMDIFlip=3;
				else if(Main.ProgMDIFlip==2)
					Main.ProgMDIFlip=3;
			}
			if(Main.ProgDNC)//内容--DNC模式下，程序界面，第四个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgDNCFlip=2;
			}
			if(Main.ProgHAN)//内容--HAN模式下，程序界面，第四个按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgHANFlip=2;
			}
			if(Main.ProgJOG || Main.ProgREF)//内容--JOG和REF模式下，程序界面，向后翻页按钮功能的实现，姓名--刘旋，时间--2013-4-22
			{
				Main.ProgSharedFlip=2;
			}
		}
		
		if(Main.SettingMenu)
		{
			//刀片界面+输入
			if(Main.OffSetTool && Main.OffSetTwo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.Plus_Tool_Input(Main.InputText, true);  //第二页+输入后面的输入
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
			if(Main.OffSetCoo && Main.OffSetTwo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.PlusInput(Main.InputText, true);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				}
			}
		}
	}
	
	//软键 Button5
	[RPC]
	void FifthButton () {
		//宋荣 position模式下响应函数
		if(Main.PosMenu)
		{
			if(!Main.operationBottomScrInitial&&(Main.RelativeCoo||Main.AbsoluteCoo||Main.GeneralCoo))
			{
				Main.operationBottomScrInitial=true;
				Main.posOperationMode=true;
				if(Main.RelativeCoo)
					Main.statusBeforeOperation=2;
				if(Main.AbsoluteCoo)
					Main.statusBeforeOperation=1;
				if(Main.GeneralCoo)
					Main.statusBeforeOperation=3;
				Main.RelativeCoo=false;
				Main.AbsoluteCoo=false;
				Main.GeneralCoo=false;
				Main.posTimeAndNumber = false;
			}
			else if(Main.operationBottomScrInitial)
			{
				Main.operationBottomScrInitial=false;
				Main.operationBottomScrExecute=true;
				Main.runtimeIsBlink=true;
				Pos_Script.xBlink=false;
				Pos_Script.yBlink=false;
				Pos_Script.zBlink=false;
				MDIInput_Script.isXSelected=false;
				MDIInput_Script.isYSelected=false;
				MDIInput_Script.isZSelected=false;
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
				Main.partsNumBlink=false;
				Main.posTimeAndNumber = true;
			}
		    else if(Main.operationBottomScrExecute)
			{
				Main.operationBottomScrInitial=true;
				Main.operationBottomScrExecute=false;
				Main.posTimeAndNumber = false;
				if(Main.runtimeIsBlink)
				{
					Main.RunningTimeH=0;
					Main.RunningTimeM=0;
				}
				if(Main.partsNumBlink)
				{
					Main.PartsNum=0;
				}
				if(presetAndZero)
				{
					if(Main.statusBeforeOperation==1)
					{
						if(MDIInput_Script.isXSelected)
						{
//							CooSystem_script.AbsoluteZero.x = -CooSystem_script.G00_pos.x - CooSystem_script.workpiece_coo.x;
							networkView.RPC("AbsolutePosSet", RPCMode.Server, 1);
						}
						if(MDIInput_Script.isYSelected)
						{
//							CooSystem_script.AbsoluteZero.y = -CooSystem_script.G00_pos.y - CooSystem_script.workpiece_coo.y;
							networkView.RPC("AbsolutePosSet", RPCMode.Server, 2);
						}
						if(MDIInput_Script.isZSelected)
						{
//							CooSystem_script.AbsoluteZero.z = -CooSystem_script.G00_pos.z - CooSystem_script.workpiece_coo.z;
							networkView.RPC("AbsolutePosSet", RPCMode.Server, 3);
						}
					}
					else
					{
						if(MDIInput_Script.isXSelected)
						{
//							CooSystem_script.RelativeZero.x = -MoveControl_Script.MachineCoo.x;
							string info = "1,0"; 
							networkView.RPC("RelativePosSet", RPCMode.Server, info);
						}
						if(MDIInput_Script.isYSelected)
						{
//							CooSystem_script.RelativeZero.y = -MoveControl_Script.MachineCoo.y;
							string info = "2,0"; 
							networkView.RPC("RelativePosSet", RPCMode.Server, info);
						}
						if(MDIInput_Script.isZSelected)
						{
//							CooSystem_script.RelativeZero.z = -MoveControl_Script.MachineCoo.z;
							string info = "3,0"; 
							networkView.RPC("RelativePosSet", RPCMode.Server, info);
						}
					}
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
					MDIInput_Script.isXSelected=false;
					MDIInput_Script.isYSelected=false;
					MDIInput_Script.isZSelected=false;
					presetAndZero=false;
				}
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=false;
			}
		}
		//宋荣
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
					else if (Main.ProgEDITFlip==2)
				    	Main.ProgEDITFlip=7;
					
					//按了返回-陈晓威
					else if(Main.ProgEDITFlip==1)
					{
						Main.NotFoundWarn = false;
						Main.WarnningClear();
						Main.ProgEDITCusorV = 0;
						Main.ProgEDITCusorH = 0;
						Main.StartRow = 0;
						Main.EndRow = SystemArguments.EditLineNumber;
						Main.SelectStart = 0;
						Main.SelectEnd = 0;
					}
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
				}
			}
			//内容--AUTO模式下，程序界面第五个按钮的功能
			//姓名--刘旋，时间--2013-3-25
			if(Main.ProgAUTO)
			{
				if (Main.ProgAUTOFlip==0)//“程序”页，按下“操作”按钮，转到“操作”页
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if(Main.ProgAUTOFlip==2)//“绝对”页，按下“操作”按钮，转到“操作”页
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if (Main.ProgAUTOFlip==3)//“当前段”页，按下“操作”按钮，转到“操作”页
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				//内容--AUTO模式下，程序界面，第五个按钮功能的修改，姓名--刘旋，时间--2013-4-9
				else if(Main.ProgAUTOFlip==4)//“相对”页，按下“操作”按钮，转到“操作”页
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if(Main.ProgAUTOFlip==5)//“下一段”页，按下“操作”按钮，转到“操作”页
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if(Main.ProgAUTOFlip == 1)
				{
					Main.autoSelecedProgRow = 0;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				
			}//增加内容到此
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
				//刀偏界面输入功能
				else if(Main.OffSetTool)
				{
					if(Main.InputText != "")
					{
						CooSystem_script.Plus_Tool_Input(Main.InputText, false);
						Main.InputText = "";
						Main.CursorText.text = Main.InputText;
						Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
					}
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
				else if(Main.OffSetCoo)
				{
					if(Main.InputText != "")
					{
						CooSystem_script.PlusInput(Main.InputText, false);
						Main.beModifed = true;
						Main.InputText = "";
						Main.CursorText.text = Main.InputText;
						Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
					}
				}
			}
		}
	}
	
	//向后翻页软键
	[RPC]
	void NextPage () {
		//宋荣
		if(Main.PosMenu)
		{
			if(!Main.operationBottomScrInitial&&(Main.RelativeCoo||Main.AbsoluteCoo||Main.GeneralCoo))
			{
				Main.operationBottomScrInitial=true;
				Main.posOperationMode=true;
				Main.posTimeAndNumber = false;
				if(Main.RelativeCoo)
					Main.statusBeforeOperation=2;
				if(Main.AbsoluteCoo)
					Main.statusBeforeOperation=1;
				if(Main.GeneralCoo)
					Main.statusBeforeOperation=3;
				Main.RelativeCoo=false;
				Main.AbsoluteCoo=false;
				Main.GeneralCoo=false;
			}	
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)	
						Main.ProgEDITFlip = 2;
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 0; 
					else if (Main.ProgEDITFlip==3)
				         Main.ProgEDITFlip=4;
			        else if (Main.ProgEDITFlip==4)
				         Main.ProgEDITFlip=2;
			        else if (Main.ProgEDITFlip==5)
				         Main.ProgEDITFlip=6;
		            else if (Main.ProgEDITFlip==6)
				         Main.ProgEDITFlip=2;//变化内容到此
					else if (Main.ProgEDITFlip==8)
				         Main.ProgEDITFlip=0;
				}
				
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 2;
						Main.ProgEDITProg = true;
						Main.ProgEDITList = false;
					}
				}
			}
			if(Main.ProgAUTO)//内容--AUTO模式下，程序界面，向后翻页按钮功能的修改，姓名--刘旋，时间--2013-4-9
			{
				if(Main.ProgAUTOFlip==1)//“操作”页，按“+”按钮，返回“程序”页
				{
					Main.ProgAUTOFlip=0;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if(Main.ProgAUTOFlip==0)//内容--“程序”页，按“+”按钮，返回“操作”页，姓名--刘旋，时间--2013-4-11
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);
				}
				else if(Main.ProgAUTOFlip==3)//内容--“当前段”页，按“+”按钮，返回“操作”页，姓名--刘旋，时间--2013-4-11
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);	
				}
				else if(Main.ProgAUTOFlip==5)//内容--“下一段”页，按“+”按钮，返回“操作”页，姓名--刘旋，时间--2013-4-11
				{
					Main.ProgAUTOFlip=1;
					Main.AutoDisplayFindRows(Main.autoSelecedProgRow, true);	
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetSetting)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
		}
		
		if(Main.MessageMenu)
		{
			if(Main.MessageFlip==0)
				Main.MessageFlip=1;
			else if(Main.MessageFlip==1)
				Main.MessageFlip=1;
			else if(Main.MessageFlip==2)
				Main.MessageFlip=2;
		}
	}
	
	[RPC] 
	void FileInfoInitializeRPC(string file_info)
	{
		string[] file_info_array = file_info.Split(',');
		Main.FileNameList.Clear();
		Main.FileSizeList.Clear();
		Main.FileDateList.Clear();
		int temp_int = 0;
		int total_int = 0;
		for(int i = 0; i < file_info_array.Length/3; i++)
		{
			Main.FileNameList.Add(file_info_array[3*i]);
			temp_int = int.Parse(file_info_array[3*i+1]);
			total_int += temp_int;
			Main.FileSizeList.Add(temp_int);
			Main.FileDateList.Add(file_info_array[3*i+2]);
		}
		Main.ProgUsedNum = Main.FileNameList.Count;
		Main.ProgUsedSpace = total_int;
		Main.ProgUnusedNum = 400 - Main.ProgUsedNum;
		Main.ProgUnusedSpace = 512 - Main.ProgUsedSpace;
		Main.TotalListNum = Main.FileNameList.Count;
		if(Main.TotalListNum > 0)
		{
			string temp_name = "";
			if(Main.ProgramNum > 0)
				temp_name = "O" + Main.ToolNumFormat(Main.ProgramNum);
			if(temp_name != "")
			{
				if(Main.FileNameList.IndexOf(temp_name) != -1)
					Main.RealListNum = Main.FileNameList.IndexOf(temp_name) + 1;
				else
				{
					Main.RealListNum = 1;
					Main.at_position = -1;
					Main.at_page_number = -1;
				}
			}
			string[] TempNameArray = new string[8];
			int[] TempSizeArray = new int[8];
			string[] TempDateArray = new string[8];
			for(int i = 0; i < 8; i++)
			{
				TempNameArray[i] = "";
				TempSizeArray[i] = 0;
				TempDateArray[i] = "";
			}
			int currentpage=(Main.RealListNum-1)/8;	
			int startnum=currentpage*8+1;	
			int finalnum=currentpage*8+8;
			if(finalnum > Main.TotalListNum)				
				finalnum = Main.TotalListNum;	
			int initial_index = -1;
			for(int i = startnum - 1; i < finalnum; i++)
			{
				initial_index++;
				TempNameArray[initial_index] = Main.FileNameList[i];
				TempSizeArray[initial_index] = Main.FileSizeList[i];
				TempDateArray[initial_index] = Main.FileDateList[i];
			}
			for(int i = 0; i < 8; i++)
			{
				Main.CodeName[i] = TempNameArray[i];
				Main.CodeSize[i] = TempSizeArray[i];
				Main.UpdateDate[i] = TempDateArray[i];
			}
		}
		else
		{
			for(int j=0; j<8; j++)                 //添加代码（原先存在问题：最后一个代码文件Delete后列表刷新不了）       添加BY王广官
			{
				Main.CodeName[j] = "";
			}
			Array.Clear(Main.CodeSize, 0, Main.CodeSize.Length);
			Array.Clear(Main.UpdateDate, 0, Main.UpdateDate.Length); 
		}	
	}
	[RPC]
	void EditListRPC(int page)
	{
		string[] TempNameArray = new string[8];
		int[] TempSizeArray = new int[8];
		string[] TempDateArray = new string[8];
		for(int i = 0; i < 8; i++)
		{
			TempNameArray[i] = "";
			TempSizeArray[i] = 0;
			TempDateArray[i] = "";
		}
		int currentpage=page;	
		int startnum=currentpage*8+1;	
		int finalnum=currentpage*8+8;
		if(finalnum > Main.TotalListNum)				
			finalnum = Main.TotalListNum;	
		int initial_index = -1;
		for(int i = startnum - 1; i < finalnum; i++)
		{
			initial_index++;
			TempNameArray[initial_index] = Main.FileNameList[i];
			TempSizeArray[initial_index] = Main.FileSizeList[i];
			TempDateArray[initial_index] = Main.FileDateList[i];
		}
		for(int i = 0; i < 8; i++)
		{
			Main.CodeName[i] = TempNameArray[i];
			Main.CodeSize[i] = TempSizeArray[i];
			Main.UpdateDate[i] = TempDateArray[i];
		}
	}
	
	/// <summary>
	/// 获取当前目录下符合要求的文件的文件名
	/// </summary>
	public void FileInfoInitialize ( )
	{
		//Judge whether the file directory is right or not
		if(Directory.Exists(document_path))
		{
			string temp_name = "";
//			Debug.Log(Main.ProgramNum);
//			if(Main.current_filenum > 0)
//				Main.RealListNum = Main.current_filenum;
//			else
//				Main.RealListNum = 1;
			
			//Main.ProgEDITCusor = 175f;
			//考虑到可能增减程序的情况，如果当前有打开程序，先记录下当前的程序号
//			if(Main.FileNameList.Count > 0)
			if(Main.ProgramNum > 0)
				temp_name = "O" + Main.ToolNumFormat(Main.ProgramNum);
			Main.FileNameList.Clear();
			Main.FileSizeList.Clear();
			Main.FileDateList.Clear();
			Main.ProgUnusedNum = 400;
			Main.ProgUnusedSpace = 512;//内容--内存总容量为512K，姓名--刘旋，时间--2013-3-180;
			Main.ProgUsedNum = 0;
			Main.ProgUsedSpace = 0;
			//Acquire all of the files's name under current directory.
			string[] tempFileList = Directory.GetFiles(document_path);
			if(tempFileList.Length > 0)
			{// 10 level
				FileInfo get_fileinfo;
				int fileSize = 0;
				foreach(string fullname in tempFileList)
				{
					//Regular Expression: 判断文件路径中是否包含指定格式的字符串："O"+"4个数字"+"."+"2或3个字符结尾"
					Regex fullname_Reg = new Regex(@"O\d{4}.\w{2,3}$");
					//Get files's information
					if(fullname_Reg.IsMatch(fullname))
					{
						Main.FileNameList.Add(fullname_Reg.Match(fullname).Value.Substring(0,5));
						get_fileinfo = new FileInfo(fullname);
						Main.FileDateList.Add(get_fileinfo.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
						fileSize = (int)(get_fileinfo.Length / 1024);
						if(fileSize * 1204 < get_fileinfo.Length)
							fileSize++;
						Main.FileSizeList.Add(fileSize);
						Main.ProgUsedSpace += fileSize;
					}
				}
				//Initialize some arquments for display
				Main.TotalListNum = Main.FileNameList.Count;
				Main.ProgUsedNum = Main.TotalListNum;
				Main.ProgUnusedNum -= Main.ProgUsedNum;
				Main.ProgUnusedSpace -= Main.ProgUsedSpace;
				//考虑到程序有增减的可能性，重新定义位置参数 Main.RealListNum
				if(temp_name != "")
				{
					if(Main.FileNameList.IndexOf(temp_name) != -1)
						Main.RealListNum = Main.FileNameList.IndexOf(temp_name) + 1;
					else
					{
						Main.RealListNum = 1;
						Main.at_position = -1;
						Main.at_page_number = -1;
					}
				}
				string[] TempNameArray = new string[8];
				int[] TempSizeArray = new int[8];
				string[] TempDateArray = new string[8];
				for(int i = 0; i < 8; i++)
				{
					TempNameArray[i] = "";
					TempSizeArray[i] = 0;
					TempDateArray[i] = "";
				}
				int currentpage=(Main.RealListNum-1)/8;	
				int startnum=currentpage*8+1;	
				int finalnum=currentpage*8+8;
				if(finalnum >Main.TotalListNum)				
					finalnum=Main.TotalListNum;	
				int initial_index = -1;
				for(int i = startnum - 1; i < finalnum; i++)
				{
					initial_index++;
					TempNameArray[initial_index] = Main.FileNameList[i];
					TempSizeArray[initial_index] = Main.FileSizeList[i];
					TempDateArray[initial_index] = Main.FileDateList[i];
				}
				for(int i = 0; i < 8; i++)
				{
					Main.CodeName[i] = TempNameArray[i];
					Main.CodeSize[i] = TempSizeArray[i];
					Main.UpdateDate[i] = TempDateArray[i];
				}
			}// 10 level
			else
			{
				for(int j=0;j<8;j++)                 //添加代码（原先存在问题：最后一个代码文件Delete后列表刷新不了）       添加BY王广官
				{
					Main.CodeName[j] = "";
				}
				Array.Clear(Main.CodeSize, 0, Main.CodeSize.Length);
				Array.Clear(Main.UpdateDate,0,Main.UpdateDate.Length); 
				Debug.LogWarning("Can't find any file in current working directory. 	Warning caused by Eric.");
			}
		}
		else
			Debug.LogError("The file directory doesn't exist. 	Error caused by Eric.");
	}
	
	/// <summary>
	/// 加载相应路径下的NC文件，并以List<string>类型返回该文件中的所有NC代码
	/// --1--调用了NCFileList函数，获得当前目录下所有符合要求的文件的文件名
	/// --2--上一步操作在这里显得有点多余，其实是因为数控面板中的程序列表可以显示存储器中的文件信息，这是为改善那一步准备的
	/// </summary>
	/// <returns>
	/// 该NC程序文件中的所有NC代码，返回类型：List<string>
	/// </returns>
	/// <param name='filename'>
	/// NC程序的程序名
	/// </param>
	public List<string> CodeLoad (string filename)
	{
		List<string> original_code = new List<string>();
		bool success_open = true;
		List<string> file_name_list = Main.FileNameList; 
		if(file_name_list.Count > 0)
		{//1 level
			//Judge whether the input string is right or not.
			if(filename.StartsWith("O"))
			{//2 level
				string temp_name = filename.Trim('O');
				//Regular Expression: 判断输入的是否为数字字符，且大小在(0,10000)之间
				Regex name_Reg = new Regex(@"^\d{1,4}$");
				if(name_Reg.IsMatch(temp_name))
				{//3 level
					int name_num = Convert.ToInt32(temp_name);
					if(name_num > 0 && name_num < 10)
						temp_name = "O000" + name_num.ToString();
					else if(name_num >= 10 && name_num < 100 )
						temp_name = "O00" + name_num.ToString();
					else if(name_num >= 100 && name_num < 1000)
						temp_name = "O0" + name_num.ToString();
					else
						temp_name = "O" + name_num.ToString();
					if(file_name_list.IndexOf(temp_name) >= 0)
					{//4 level
						string file_path = "";
						FileInfo exist_check = new FileInfo(document_path + temp_name + ".txt");
						if(exist_check.Exists)
							file_path = document_path + temp_name + ".txt";
						else
						{
							exist_check = new FileInfo(document_path + temp_name + ".cnc");
							if(exist_check.Exists)
								file_path = document_path + temp_name + ".cnc";
							else
							{
								exist_check = new FileInfo(document_path + temp_name + ".nc");
								if(exist_check.Exists)
									file_path = document_path + temp_name + ".nc";
								else
									success_open = false;
							}
						}
						//Acquire original code.
						if(success_open)
						{
							//全局变量
							Main.RealListNum = file_name_list.IndexOf(temp_name) + 1;
							Main.ProgramNum = Convert.ToInt32(temp_name.Trim('O'));
							Main.Progname_Backup = Main.ProgramNum;
							FileStream code_file_stream = new FileStream(file_path, FileMode.Open, FileAccess.Read); 
							StreamReader code_SR = new StreamReader(code_file_stream);
							string s_Line = code_SR.ReadLine();
							while(s_Line != null)
							{
								original_code.Add(s_Line);
								s_Line = code_SR.ReadLine();
							}
							code_SR.Close();
						}
						else
							Debug.LogError("Unexpected error! Program: " + temp_name + " disappears.  Error caused by Eric.");
					}//4 level
					else
						Debug.LogWarning("Can't find Program: " + temp_name + " in current working directory!  Warning caused by Eric.");
				}//3 level
				else
					Debug.LogError("格式错误! Error caused by Eric.");
			}//2 level
			else
				Debug.LogError("格式错误! Error caused by Eric.");
		}//1 level
		else
			Debug.LogWarning("Can't find any file in current working directory. 	Warning caused by Eric.");
		return original_code;
	}
	
	public void O_Search_PadRPC()
	{
		code_info = "";
		networkView.RPC("OSearchPad", RPCMode.Server);
	}
	[RPC]
	void OSearchPad()
	{
	}
	
	[RPC]
	void O_Search_RealListNum(int index)
	{
		Main.RealListNum = index;
		Locate_At_Position(index);
	}
	
	[RPC]
	void ProgName(int name)
	{
		Main.Progname_Backup = name;
		Main.ProgramNum = name;
	}
	
	[RPC]
	void CodeOn(int flag)
	{
		if(flag == 1)
		{
			code_on = true;
		}
		else
		{
			code_on = false;
		}
	}
	[RPC]
	void O_Search_PC(string code)
	{
		if(code_on)
		{
			code_info += code;
		}
		else
		{
			code_info += code;
			Main.CodeForAll.Clear();
			string[] code_array = code_info.Split(',');
			for(int i = 0; i < code_array.Length; i++)
			{
				Main.CodeForAll.Add(code_array[i]);
			}
			Main.RealCodeNum=1;
			Main.HorizontalNum=1;
			Main.VerticalNum=1;
			Main.TotalCodeNum=Main.CodeForAll.Count;
			Main.StartRow = 0;
			Main.EndRow = SystemArguments.EditLineNumber;
			Main.ProgEDITCusorH=0;
			Main.ProgEDITCusorV=0;
			Main.SelectStart = 0;
			Main.SelectEnd = 0;
			Main.TextSize=Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITList = false;
			Main.ProgEDITProg = true;
			Main.ProgEDITAt = true;
			Main.at_position = Main.RealListNum%8;	
			Main.at_page_number = (Main.RealListNum - 1)/8;
			Main.beModifed = true;
			calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
			Main.InputText="";
			Main .ProgEDITCusorPos = Main.corner_px + 23.5f;
			Main.EDITText.text="";
			Main.WarnningClear();
		    code_info = "";
			Locate_At_Position(Main.RealListNum);
		}
	}
	
	[RPC]
	void CodeInitialize(string code)
	{
		if(code_on)
		{
			code_string += code;
		}
		else
		{
			code_string += code;
			string choose = code_string.Substring(code_string.Length - 1, 1);
			code_string = code_string.Remove(code_string.Length - 1, 1);
			string[] code_array;
			switch(choose)
			{
			case "1":
				Main.CodeBuffer.Clear();
				code_array = code_string.Split(',');
				for(int i = 0; i < code_array.Length; i++)
				{
					Main.CodeBuffer.Add(code_array[i]);
				}
				break;
			case "2":
				Main.CodeForMDI.Clear();
				string auto_choose = code_string.Substring(code_string.Length - 1, 1);
				code_string = code_string.Remove(code_string.Length - 1, 1);
				code_array = code_string.Split(',');
				for(int i = 0; i < code_array.Length; i++)
				{
					if(code_array[i] != "")
						Main.CodeForMDI.Add(code_array[i]);
				}
				if(auto_choose == "0")  //CodeForMDI第一个程序段是"O0000"
					Main.CodeForAUTO = Main.CodeForAll;
				else
					Main.CodeForAUTO = Main.CodeForMDI;
				Main.AutoDisplayFindRows(Main.autoSelecedProgRow, Main.autoDisplayNormal);
				break;
			case "3":
				Main.CodeForMDIRuning.Clear();
				code_array = code_string.Split(',');
				for(int i = 0; i < code_array.Length; i++)
				{
					Main.CodeForMDIRuning.Add(code_array[i]);
				}
				Main.MDIDisplayFindRows(Main.MDISelectedRow);
				break;
			default:
				break;
			}
			calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
		    code_string = "";
		}
	}
	
	/// <summary>
	/// O检索，加载代码，此处需要初步格式化
	/// </summary>
	public void O_Search() 
	{
		bool open_success = false;
		string file_name = "";
		int temp_reallistnum = Main.RealListNum;
		//无输入或者输入为"O"时
		if(Main.InputText == "" || Main.InputText == "O")
		{
			if(Main.RealListNum < Main.TotalListNum)
			{	
				Main.RealListNum++;
			}
			else
			{	
				Main.RealListNum=1;
			}
			
			if(Main.at_position < 0)
			{
				Main.RealListNum=1;
			}
			file_name = Main.FileNameList[Main.RealListNum - 1];
		}
		//有合适的输入时
		else
		{
			file_name = Main.InputText;
		}
		
		//从文件加载NC代码
		List<string> temp_code_list =new List<string>();
		temp_code_list = NCCodeFormat_Script.AllCode(file_name, ref open_success);
		if(open_success)
		{
			if(temp_code_list.Count > 0)
			{
				if(temp_code_list[temp_code_list.Count-1] == "")
					temp_code_list.RemoveAt(temp_code_list.Count - 1);
			}
			Main.CodeForAll.Clear();
			Main.CodeForAll = new List<string>();
			Main.CodeForAll = temp_code_list;
			Main.RealCodeNum=1;
			Main.HorizontalNum=1;
			Main.VerticalNum=1;
			Main.TotalCodeNum=Main.CodeForAll.Count;
			Main.StartRow = 0;
			Main.EndRow = SystemArguments.EditLineNumber;
			Main.ProgEDITCusorH=0;
			Main.ProgEDITCusorV=0;
			Main.SelectStart = 0;
			Main.SelectEnd = 0;
			Main.TextSize=Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
			Main.ProgEDITList = false;
			Main.ProgEDITProg = true;
			Main.ProgEDITAt = true;
			Main.at_position = Main.RealListNum%8;	
			Main.at_page_number = (Main.RealListNum - 1)/8;
			Main.beModifed = true;
			calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
		}
		else
		{
			Main.RealListNum = temp_reallistnum;
		}
		Main.InputText="";
		Main .ProgEDITCusorPos = Main.corner_px + 23.5f;
		Main.EDITText.text="";
		Main.WarnningClear();
	}
	
	public void LocationAtPRC()
	{
		networkView.RPC("LocationAt", RPCMode.Server, Main.RealListNum);
	}
	[RPC]
	void LocationAt(int index)
	{		
		Locate_At_Position(index);
	}
	
	/// <summary>
	/// 确定"@"的位置
	/// </summary>
	/// <param name='name_index'>
	/// 当前所打开的程序在列表中的index
	/// </param>
	public void Locate_At_Position (int name_index)
	{
		if(Main.at_position >= 0)
		{
			Main.at_position = name_index%8;
			switch(Main.at_position)
			{
				case 1:
					Main.ProgEDITCusor = Main.corner_py + 120f;
					break;
				case 2:
					Main.ProgEDITCusor = Main.corner_py + 140f;
					break;
				case 3:
					Main.ProgEDITCusor = Main.corner_py + 160f;
					break;
				case 4:
					Main.ProgEDITCusor = Main.corner_py + 180f;
					break;
				case 5:
					Main.ProgEDITCusor = Main.corner_py + 200f;
					break;
				case 6:
					Main.ProgEDITCusor = Main.corner_py + 220f;
					break;
				case 7:
					Main.ProgEDITCusor = Main.corner_py + 240f;
					break;
				case 0:
					Main.ProgEDITCusor = Main.corner_py + 260f;
					break;	
			}
			if(Main.CodeName[0] != "")
			{
				int current_page = Main.FileNameList.IndexOf(Main.CodeName[0]);
				if(current_page >= 0)
				{
					current_page = current_page / 8; 
					if(Main.at_page_number != current_page)
						Main.ProgEDITAt = false;
					else
						Main.ProgEDITAt = true;
				}
				else
					Main.ProgEDITAt = false;
			}
			else
				Main.ProgEDITAt = false;
		}
	}
	
//	//  修改备份1
//	/// <summary>
//	/// 分行，找出每一行的结尾所对应的CodeForAll的序号，将这些信息添加到codeSeparatePos数组中，这个数组结构不好，ToModified
//	/// </summary>
//	/// <param name='codelist'>
//	/// CodeForAll, NC代码List<string>
//	/// </param>
//	/// <param name='codeSeparatePos'>
//	/// 记录分行分隔点信息的数组
//	/// </param>
//	/// <param name='row_length'>
//	/// 一行的最大长度，这个参数待修改TobeModified
//	/// </param>
//	public void calcSepo(List<string> codelist, int[] codeSeparatePos, float row_length)
//	{
//		if(codelist.Count == 0)
//			return;
//		float blank_length = 13f/Main.width*1000f;	  //检验一下这个参数是否合理TobeModified
//		int index_str = 0;
//	    float cur_length = 0;
//		string each_word=null;
//		int irow;
//		cur_length = getStrLen(codelist[0]);
//		Main.SeparatePosStart.Clear();
////		Main.SeparatePosStart = new List<int>();
//		Main.SeparatePosEnd.Clear();
////		Main.SeparatePosEnd = new List<int>();
//		Main.SeparatePosStart.Add(0);
//		for(irow = 0; index_str < codelist.Count;)   
//	    {
//			each_word = codelist[index_str];   
//			if((index_str+1 < codelist.Count) && codelist[index_str+1] != ";")  //对于普通的代码计算他所占有的长度
//			{
//				float next_wordsize = getStrLen(codelist[index_str+1]);
//				cur_length = cur_length + next_wordsize + blank_length;
//			}
//			++index_str;  //相当于For循环括号里的第三个参数
//			if(each_word.Equals(";") && index_str <= codelist.Count) //遇到";"，说明要换行
//			{
//				codeSeparatePos[irow] = index_str;  //每一行对应的下一行的第一个代码字符序号
//				Main.SeparatePosStart.Add(index_str);
//				Main.SeparatePosEnd.Add(index_str);
//				if(index_str < codelist.Count)
//					cur_length = getStrLen(codelist[index_str]);
//				++irow;
//			}									
//			else if((cur_length > row_length)&&(index_str <= codelist.Count))  //当当前行代码超过指定长度时，也要换行
//			{
//				codeSeparatePos[irow] = index_str;  //每一行对应的下一行的第一个代码字符序号n
//				Main.SeparatePosStart.Add(index_str);
//				Main.SeparatePosEnd.Add(index_str);
//				if(index_str < codelist.Count)
//					cur_length = getStrLen(codelist[index_str]);
//				++irow;
//			}		
//		}
//		Main.total_row = irow;
//		Main.AUTOMaxRow = irow - 1;  //最大的行数
//	}
	
	
	/// <summary>
	/// 分行，找出每一行的结尾所对应的CodeForAll的序号，将这些信息添加到codeSeparatePos数组中，这个数组结构不好，ToModified
	/// </summary>
	/// <param name='codelist'>
	/// CodeForAll, NC代码List<string>
	/// </param>
	/// <param name='row_length'>
	/// 一行的最大长度，这个参数待修改TobeModified
	/// </param>
	public void calcSepo(List<string> codelist, float row_length)
	{
		if(codelist.Count == 0)
			return;
		float blank_length = 13f/SystemArguments.PanelWindow_Width*1000f;	  //检验一下这个参数是否合理TobeModified
		int index_str = 0;
	    float cur_length = 0;
		string each_word=null;
		int irow;
		cur_length = getStrLen(codelist[0]);
//		cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[0])).x;
		Main.SeparatePosStart.Clear();
		Main.SeparatePosEnd.Clear();
		Main.SeparatePosStart.Add(0);
		for(irow = 0; index_str < codelist.Count;)   
	    {
			each_word = codelist[index_str];   
			if((index_str+1 < codelist.Count) && codelist[index_str+1] != ";")  //对于普通的代码计算他所占有的长度
			{
				float next_wordsize = getStrLen(codelist[index_str + 1]);
//				float next_wordsize = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str + 1])).x;
				cur_length = cur_length + next_wordsize + blank_length;
			}
			++index_str;  //相当于For循环括号里的第三个参数
			if(each_word.Equals(";") && index_str <= codelist.Count) //遇到";"，说明要换行
			{
				Main.SeparatePosStart.Add(index_str); //该行开始位置
				Main.SeparatePosEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}									
			else if((cur_length > row_length)&&(index_str <= codelist.Count))  //当当前行代码超过指定长度时，也要换行
			{
				Main.SeparatePosStart.Add(index_str); //该行开始位置
				Main.SeparatePosEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}		
		}
		Main.total_row = irow;
	}
	
	/// <summary>
	/// Calculates the sepo auto.
	/// </summary>
	/// <param name='codelist'>
	/// CodeForAuto
	/// </param>
	/// <param name='row_length'>
	/// Row_length.
	/// </param>
	public void calcSepoAuto(List<string> codelist, float row_length)
	{
		if(codelist.Count == 0)
			return;
		float blank_length = 13f/SystemArguments.PanelWindow_Width*1000f;	  //检验一下这个参数是否合理TobeModified
		int index_str = 0;
	    float cur_length = 0;
		string each_word=null;
		int irow;
		cur_length = getStrLen(codelist[0]);
//		cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[0])).x;
		Main.SeparateAutoStart.Clear();
		Main.SeparateAutoEnd.Clear();
		Main.SeparateAutoStart.Add(0);
		for(irow = 0; index_str < codelist.Count;)   
	    {
			each_word = codelist[index_str];   
			if((index_str+1 < codelist.Count) && codelist[index_str+1] != ";")  //对于普通的代码计算他所占有的长度
			{
//				float next_wordsize = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str + 1])).x;
				float next_wordsize = getStrLen(codelist[index_str + 1]);
				cur_length = cur_length + next_wordsize + blank_length;
			}
			++index_str;  //相当于For循环括号里的第三个参数
			if(each_word.Equals(";") && index_str <= codelist.Count) //遇到";"，说明要换行
			{
				Main.SeparateAutoStart.Add(index_str); //该行开始位置
				Main.SeparateAutoEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}									
			else if((cur_length > row_length)&&(index_str <= codelist.Count))  //当当前行代码超过指定长度时，也要换行
			{
				Main.SeparateAutoStart.Add(index_str); //该行开始位置
				Main.SeparateAutoEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}		
		}
		Main.auto_total_row = irow;
	}
	
	/// <summary>
	/// Calculates the sepo MDI.
	/// </summary>
	/// <param name='codelist'>
	/// CodeForAuto
	/// </param>
	/// <param name='row_length'>
	/// Row_length.
	/// </param>
	public void calcSepoMDI(List<string> codelist, float row_length)
	{
		if(codelist.Count == 0)
			return;
		float blank_length = 13f/SystemArguments.PanelWindow_Width*1000f;	  //检验一下这个参数是否合理TobeModified
		int index_str = 0;
	    float cur_length = 0;
		string each_word=null;
		int irow;
		cur_length = getStrLen(codelist[0]);
//		cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[0])).x;
		Main.SeparateMDIStart.Clear();
		Main.SeparateMDIEnd.Clear();
		Main.SeparateMDIStart.Add(0);
		for(irow = 0; index_str < codelist.Count;)   
	    {
			each_word = codelist[index_str];   
			if((index_str+1 < codelist.Count) && codelist[index_str+1] != ";")  //对于普通的代码计算他所占有的长度
			{
//				float next_wordsize = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str + 1])).x;
				float next_wordsize = getStrLen(codelist[index_str + 1]);
				cur_length = cur_length + next_wordsize + blank_length;
			}
			++index_str;  //相当于For循环括号里的第三个参数
			if(each_word.Equals(";") && index_str <= codelist.Count) //遇到";"，说明要换行
			{
				Main.SeparateMDIStart.Add(index_str); //该行开始位置
				Main.SeparateMDIEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}									
			else if((cur_length > row_length)&&(index_str <= codelist.Count))  //当当前行代码超过指定长度时，也要换行
			{
				Main.SeparateMDIStart.Add(index_str); //该行开始位置
				Main.SeparateMDIEnd.Add(index_str);  //该行结束位置
				if(index_str < codelist.Count)
//					cur_length = Main.sty_EDITTextField.CalcSize(new GUIContent(codelist[index_str])).x;
					cur_length = getStrLen(codelist[index_str]);
				++irow;
			}		
		}
		Main.mdi_total_row = irow;
	}
	
	public float getStrLen(string str)
	{
		float conlen=0;
		char[] temp=str.ToCharArray();
		for(int i=0; i < temp.Length; i++)
		{
			try
			{
				conlen += strlenmap[temp[i]];
			}
			catch
			{
//				Debug.Log(temp[i]+"not found");
			}
		}
		return conlen;	
	}
	
	public void StrLenMapInitialize()
	{
		strlenmap = new Dictionary<char, float>();
		//数字
		for(int i = 0; i <= 9; i++)
			strlenmap.Add((char)('0'+i), 9f);
		//字母
		strlenmap.Add('A',12f);
		strlenmap.Add('B',12f);
		strlenmap.Add('C',12f);
		strlenmap.Add('D',12f);
		strlenmap.Add('E',11f);
		strlenmap.Add('F',10f);
		strlenmap.Add('G',13f);
		strlenmap.Add('H',12f);
		strlenmap.Add('I',5f);
		strlenmap.Add('J',9f);
		strlenmap.Add('K',12f);
		strlenmap.Add('L',10f);
		strlenmap.Add('M',14f);
		strlenmap.Add('N',12f);
		strlenmap.Add('O',13f);
		strlenmap.Add('P',11f);
		strlenmap.Add('Q',13f);
		strlenmap.Add('R',12f);
		strlenmap.Add('S',11f);
		strlenmap.Add('T',10f);
		strlenmap.Add('U',12f);
		strlenmap.Add('V',11f);
		strlenmap.Add('W',16f);
		strlenmap.Add('X',11f);
		strlenmap.Add('Y',11f);
		strlenmap.Add('Z',10f);
		//符号
		strlenmap.Add('*',7f);
		strlenmap.Add('\'',4f);
		strlenmap.Add('-',6f);
		strlenmap.Add('/',5f);
		strlenmap.Add('+',10f);
		strlenmap.Add(';',6f);
		strlenmap.Add('.',5f);
		strlenmap.Add('#',9f);
		strlenmap.Add('[',6f);
		strlenmap.Add(']',6f);
		strlenmap.Add('=',9f);
		strlenmap.Add(',',5f);
		strlenmap.Add('!',6f);
		strlenmap.Add('(',6f);
		strlenmap.Add(')',6f);
		strlenmap.Add('@',17f);
		strlenmap.Add('%',15f);
		strlenmap.Add('$',9f);
		strlenmap.Add('^',10f);
		strlenmap.Add('&',12f);
		strlenmap.Add('<',10f);
		strlenmap.Add('>',10f);
		strlenmap.Add('?',10f);
	}
	
	public void StrLenMapInitializeNewTimes()
	{
		strlenmap = new Dictionary<char, float>();
		//数字
		for(int i = 0; i <= 9; i++)
			strlenmap.Add((char)('0'+i), 9f);
		//字母
		strlenmap.Add('A',12f);
		strlenmap.Add('B',11f);
		strlenmap.Add('C',12f);
		strlenmap.Add('D',12f);
		strlenmap.Add('E',11f);
		strlenmap.Add('F',10f);
		strlenmap.Add('G',13f);
		strlenmap.Add('H',13f);
		strlenmap.Add('I',7f);
		strlenmap.Add('J',9f);
		strlenmap.Add('K',13f);
		strlenmap.Add('L',11f);
		strlenmap.Add('M',16f);
		strlenmap.Add('N',12f);
		strlenmap.Add('O',13f);
		strlenmap.Add('P',10f);
		strlenmap.Add('Q',13f);
		strlenmap.Add('R',12f);
		strlenmap.Add('S',9f);
		strlenmap.Add('T',11f);
		strlenmap.Add('U',12f);
		strlenmap.Add('V',12f);
		strlenmap.Add('W',17f);
		strlenmap.Add('X',12f);
		strlenmap.Add('Y',12f);
		strlenmap.Add('Z',11f);
		//符号
		strlenmap.Add('*',9f);
		strlenmap.Add('\'',5f);
		strlenmap.Add('-',6f);
		strlenmap.Add('/',5f);
		strlenmap.Add('+',10f);
		strlenmap.Add(';',6f);
		strlenmap.Add('.',4f);
		strlenmap.Add('#',9f);
		strlenmap.Add('[',6f);
		strlenmap.Add(']',6f);
		strlenmap.Add('=',10f);
		strlenmap.Add(',',4f);
		strlenmap.Add('!',6f);
		strlenmap.Add('(',6f);
		strlenmap.Add(')',6f);
		strlenmap.Add('@',16f);
		strlenmap.Add('%',17f);
		strlenmap.Add('$',9f);
		strlenmap.Add('^',10f);
		strlenmap.Add('&',14f);
		strlenmap.Add('<',10f);
		strlenmap.Add('>',10f);
		strlenmap.Add('?',9f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
