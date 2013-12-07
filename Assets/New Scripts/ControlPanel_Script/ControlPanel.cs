using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ControlPanel : MonoBehaviour
{ 
	
	#region Defined script variable
	ClientCenter Client_Script;
	PositionModule Position_Script;
	//添加 BY:WH
	LightNumber LightNumber_Script;
//	TopMenu TopMenu_Script;
	SoftkeyModule Softkey_Script;
	ProgramModule Program_Script;
	OffsetSettingModule Offset_Script;
	MDIInputModule MDIInput_Script;
	MDIFunctionModule MDIFunction_Script;
	MDIEditModule MDIEdit_Script;
	ModeSelectModule ModeSelect_Script;
	FeedrateModule Feedrate_Script;
	MachineFunctionModule MachineFunction_Script;
	AuxiliaryFunctionModule AuxiliaryFunction_Script;
//	MoveControl MoveControl_script;
//	AuxiliaryMoveModule AuxiliaryMoveModule_Script;
//	SpindleControl SpindleControl_script;
	CooSystem CooSystem_script;
	SystemModule System_Script;//添加脚本SystemModule和MessageModule，姓名--刘旋，时间--2013-4-24
	MessageModule Message_Script;
	NCCodeFormat NCCodeFormat_Script;//代码格式化
//	EntranceScript AutoRunning_Script;
//	AutoMoveModule AutoMove_Script;
	ButtonShowOff ButtonShowOff_Script;
	Warnning Warnning_Script;
//	PathLineDraw PathLineDraw_Script;
//	RightclickMenu RightclickMenu_Script;
	ProgramReset ProgramReset_Script;
	HandWheelModule HandWheel_Script;
	AutoDisplayControl AutoDisplay_Script;
	PopupMessage PopupMessage_Script;
	#endregion
	
	public bool MLK_flag = false;//机床机械锁住
	public bool Zlock_flag = false;//Z轴锁住
	public bool DRN_flag = false;//空运行
	
	#region Variable For New Panel
	//添加 BY:WH
	public float width_x = 10;
	public float height_y = 10;
	public int num;
	//电源键
	public float NCPower_x = 60f;
	public float NCPower_y = 564f;
	public float NCPower_width = 60f;
	public float NCPower_height = 40f;
	public float NCPower_left_x;
	public float NCPower_left_y = 85f;
	
	//锁定
	public float t2d_x;
	public float t2d_y;
	public float t2d_width;
	public float t2d_height;
	public GUIStyle background;
	public float t2d_Emergency_x;
	public float t2d_Emergency_y;
	public float t2d_Emergency_width;
	public float t2d_Emergency_height;
	public float IO_width;
	public float IO_height;
	public float IO_x;
	public float IO_y;
	public float IO_left_x;
	public float btn_width = 49;
	public float btn_height = 45;
	public float Axis_x = 478;
	public float Axis_y = 778;
	public float Rapid_x = 695;
	public float Rapid_y = 778;
	public float left_x = 64.5f;
	public float left_y = 52;
	public Texture2D EMPTY_off_u;
	public Texture2D EMPTY_off_d;
	public Texture2D EMPTY_on_u;
	public Texture2D EMPTY_on_d;
	public GUIStyle EMPTY;
	public Texture2D DOWN_off_u;
	public Texture2D DOWN_off_d;
	public Texture2D DOWN_on_u;
	public Texture2D DOWN_on_d;
	public GUIStyle Axis_DOWN;
	public Texture2D HUNDRED_off_u;
	public Texture2D HUNDRED_off_d;
	public Texture2D HUNDRED_on_u;
	public Texture2D HUNDRED_on_d;
	public GUIStyle HUNDRED;
	public Texture2D UP_off_u;
	public Texture2D UP_off_d;
	public Texture2D UP_on_u;
	public Texture2D UP_on_d;
	public GUIStyle Axis_UP;
	public Texture2D ORIENT_off_u;
	public Texture2D ORIENT_off_d;
	public Texture2D ORIENT_on_u;
	public Texture2D ORIENT_on_d;
	public GUIStyle ORIENT;
	public Texture2D I_u;
	public Texture2D I_d;
	public GUIStyle I;
	public Texture2D O_u;
	public Texture2D O_d;
	public GUIStyle O;
	
	//MDI Input parameter define start
	public Texture2D pO_u;
	public Texture2D pO_d;
	public GUIStyle pO;
	public Texture2D qN_u;
	public Texture2D qN_d;
	public GUIStyle qN;
	public Texture2D rG_u;
	public Texture2D rG_d;
	public GUIStyle rG;
	public Texture2D a7_u;
	public Texture2D a7_d;
	public GUIStyle a7;
	public Texture2D b8_u;
	public Texture2D b8_d;
	public GUIStyle b8;
	public Texture2D c9_u;
	public Texture2D c9_d;
	public GUIStyle c9;
	public Texture2D uX_u;
	public Texture2D uX_d;
	public GUIStyle uX;
	public Texture2D vY_u;
	public Texture2D vY_d;
	public GUIStyle vY;
	public Texture2D wZ_u;
	public Texture2D wZ_d;
	public GUIStyle wZ;
	public Texture2D four_u;
	public Texture2D four_d;
	public GUIStyle four;
	public Texture2D five_u;
	public Texture2D five_d;
	public GUIStyle five;
	public Texture2D six_u;
	public Texture2D six_d;
	public GUIStyle six;
	public Texture2D iM_u;
	public Texture2D iM_d;
	public GUIStyle iM;
	public Texture2D jS_u;
	public Texture2D jS_d;
	public GUIStyle jS;
	public Texture2D kT_u;
	public Texture2D kT_d;
	public GUIStyle kT;
	public Texture2D one_u;
	public Texture2D one_d;
	public GUIStyle one;
	public Texture2D two_u;
	public Texture2D two_d;
	public GUIStyle two;
	public Texture2D three_u;
	public Texture2D three_d;
	public GUIStyle three;
	public Texture2D lF_u;
	public Texture2D lF_d;
	public GUIStyle lF;
	public Texture2D dH_u;
	public Texture2D dH_d;
	public GUIStyle dH;
	public Texture2D eEOB_u;
	public Texture2D eEOB_d;
	public GUIStyle eEOB;
	public Texture2D ap_u;
	public Texture2D ap_d;
	public GUIStyle ap;
	public Texture2D zero_u;
	public Texture2D zero_d;
	public GUIStyle zero;
	public Texture2D po_u;
	public Texture2D po_d;
	public GUIStyle po;
	public Texture2D sh_u;
	public Texture2D sh_d;
	public GUIStyle sh;

	//MDI Input parameter define end
	
	//MDI Function parameter define start
	public Texture2D POS_u;
	public Texture2D POS_d;
	public GUIStyle POS;
	public Texture2D PROG_u;
	public Texture2D PROG_d;
	public GUIStyle PROG;
	public Texture2D SET_u;
	public Texture2D SET_d;
	public GUIStyle SET;
	public Texture2D INPUT_u;
	public Texture2D INPUT_d;
	public GUIStyle INPUT;
	public Texture2D SYSTEM_u;
	public Texture2D SYSTEM_d;
	public GUIStyle SYSTEM;
	public Texture2D MESSAGE_u;
	public Texture2D MESSAGE_d;
	public GUIStyle MESSAGE;
	public Texture2D ORPH_u;
	public Texture2D ORPH_d;
	public GUIStyle ORPH;
	public Texture2D HELP_u;
	public Texture2D HELP_d;
	public GUIStyle HELP;
	public Texture2D RESET_u;
	public Texture2D RESET_d;
	public GUIStyle RESET;
	//MDI Function parameter define end
	
	//MDI Edit parameter define start
	public Texture2D CAN_u;
	public Texture2D CAN_d;
	public GUIStyle CAN;
	public Texture2D ALTER_u;
	public Texture2D ALTER_d;
	public GUIStyle ALTER;
	public Texture2D INSERT_u;
	public Texture2D INSERT_d;
	public GUIStyle INSERT;
	public Texture2D DELETE_u;
	public Texture2D DELETE_d;
	public GUIStyle DELETE;
	public Texture2D PAGEu_u;
	public Texture2D PAGEu_d;
	public GUIStyle PAGEu;
	public Texture2D PAGEd_u;
	public Texture2D PAGEd_d;
	public GUIStyle PAGEd;
	public Texture2D LEFT_u;
	public Texture2D LEFT_d;
	public GUIStyle LEFT;
	public Texture2D UP_u;
	public Texture2D UP_d;
	public GUIStyle UP;
	public Texture2D DOWN_u;
	public Texture2D DOWN_d;
	public GUIStyle DOWN;
	public Texture2D RIGHT_u;
	public Texture2D RIGHT_d;
	public GUIStyle RIGHT;
	//MDI Edit parameter define end
	
	//Softkey parameter define end
	public Texture2D Soft_LEFT_u;
	public Texture2D Soft_LEFT_d;
	public GUIStyle Soft_LEFT;
	public Texture2D Soft_EMPTY_u;
	public Texture2D Soft_EMPTY_d;
	public GUIStyle Soft_EMPTY;
	public Texture2D Soft_RIGHT_u;
	public Texture2D Soft_RIGHT_d;
	public GUIStyle Soft_RIGHT;
	//Softkey parameter define end
	
	//Auxiliary Function parameter define start
	public Texture2D COOL_off_u;
	public Texture2D COOL_off_d;
	public Texture2D COOL_on_u;
	public Texture2D COOL_on_d;
	public GUIStyle COOL;
	public Texture2D Empty1_off_u;
	public Texture2D Empty1_off_d;
	public Texture2D Empty1_on_u;
	public Texture2D Empty1_on_d;
	public GUIStyle Empty1;
	public Texture2D MHS_off_u;
	public Texture2D MHS_off_d;
	public Texture2D MHS_on_u;
	public Texture2D MHS_on_d;
	public GUIStyle MHS;
	public Texture2D ATCW_off_u;
	public Texture2D ATCW_off_d;
	public Texture2D ATCW_on_u;
	public Texture2D ATCW_on_d;
	public GUIStyle ATCW;
	public Texture2D ATCCW_off_u;
	public Texture2D ATCCW_off_d;
	public Texture2D ATCCW_on_u;
	public Texture2D ATCCW_on_d;
	public GUIStyle ATCCW;
	public Texture2D MHRN_off_u;
	public Texture2D MHRN_off_d;
	public Texture2D MHRN_on_u;
	public Texture2D MHRN_on_d;
	public GUIStyle MHRN;
	public Texture2D FOR_off_u;
	public Texture2D FOR_off_d;
	public Texture2D FOR_on_u;
	public Texture2D FOR_on_d;
	public GUIStyle FOR;
	public Texture2D BACK_off_u;
	public Texture2D BACK_off_d;
	public Texture2D BACK_on_u;
	public Texture2D BACK_on_d;
	public GUIStyle BACK;
	public Texture2D Empty2_off_u;
	public Texture2D Empty2_off_d;
	public Texture2D Empty2_on_u;
	public Texture2D Empty2_on_d;
	public GUIStyle Empty2;
	//Auxiliary Function parameter define end
	
	//Machine Function parameter define start
	public Texture2D MLK_u;
	public Texture2D MLK_d;
	public Texture2D MLK_on_u;
	public Texture2D MLK_on_d;
	public GUIStyle MLK;
	public Texture2D DRN_u;
	public Texture2D DRN_d;
	public Texture2D DRN_on_u;
	public Texture2D DRN_on_d;
	public GUIStyle DRN;
	public Texture2D BDT_u;
	public Texture2D BDT_d;
	public Texture2D BDT_on_u;
	public Texture2D BDT_on_d;
	public GUIStyle BDT;
	public Texture2D SBK_u;
	public Texture2D SBK_d;
	public Texture2D SBK_on_u;
	public Texture2D SBK_on_d;
	public GUIStyle SBK;
	public Texture2D OSP_u;
	public Texture2D OSP_d;
	public Texture2D OSP_on_u;
	public Texture2D OSP_on_d;
	public GUIStyle OSP;
	public Texture2D ZLOCK_u;
	public Texture2D ZLOCK_d;
	public Texture2D ZLOCK_on_u;
	public Texture2D ZLOCK_on_d;
	public GUIStyle ZLOCK;
	public Texture2D MachineEMPTY_u;
	public Texture2D MachineEMPTY_d;
	public Texture2D MachineEMPTY_on_u;
	public Texture2D MachineEMPTY_on_d;
	public GUIStyle MachineEMPTY;
	public GUIStyle MachineEMPTY2;
	//Machine Function parameter define end
	
	//Hand Wheel parameter define start
	public GUIStyle HandWheel_backgraound;
	public Texture2D left_1;
	public Texture2D left_2;
	public Texture2D mid;
	public Texture2D right_1;
	public Texture2D right_2;
	public Texture2D left_num;
	public Texture2D right_num;
	public GUIStyle sty_Button;
	public Texture2D hand;//手轮贴图
	public Texture2D plane;//刻度盘贴图
	
	public Texture2D activeArea;
	
	#endregion
	
	#region Defined variable
	public float width = 670;
	public float height = 650;
	public bool RapidMoveFlag = false;
	//内容--定义布尔变量，用于指示JOG模式下F0，25%，50%，100%四个按钮的功能
	//姓名--刘旋，时间--2013-4-8
	public bool F0_flag = false;
	public bool F25_flag = false;
	public bool F50_flag = false;//默认50%按钮时按下状态
	public bool F100_flag = false;//增加内容到此 2013-4-8
	//内容--定义整形变量SlowSpeedMode，用于指示慢常速下的按键状态，SlowSpeedMode=0，表示F0按下，SlowSpeedMode=1，表示25%按下
	//SlowSpeedMode=2，表示50%按下，SlowSpeedMode=3，表示100%按下，姓名--刘旋，时间--2013-4-8
	public int RapidSpeedMode = 2;//增加内容到此  2013-4-8
	public Rect PanelWindowRect = new Rect (-300, 20, 670, 650);
	public float timeV = 0;
	public Texture2D t2d_alarm;
	public Texture2D t2d_zero;
	public Texture2D t2d_toolnum;
	
	
//	public Texture2D t2d_Emergency;
	public GUIStyle t2d_Emergency;
	public Texture2D t2d_em_u;
	public Texture2D t2d_em_d;
	public Texture2D t2d_Protect;
	public Texture2D t2d_lock;
	public Texture2D t2d_unlock;
	public Texture2D t2d_ModeSelect;
	public Texture2D t2d_ModeSelectEDIT;
	public Texture2D t2d_ModeSelectDNC;
	public Texture2D t2d_ModeSelectAUTO;
	public Texture2D t2d_ModeSelectMDI;
	public Texture2D t2d_ModeSelectHANDLE;
	public Texture2D t2d_ModeSelectJOG;
	public Texture2D t2d_ModeSelectREF;
	public int mode_type = 0;
	public Texture2D t2d_NCPower_on_u;
	public Texture2D t2d_NCPower_on_d;
	public Texture2D t2d_NCPower_off_u;
	public Texture2D t2d_NCPower_off_d;
	public Texture2D t2d_feedrate;
	public Texture2D t2d_FeedRate_0;
	public Texture2D t2d_FeedRate_10;
	public Texture2D t2d_FeedRate_20;
	public Texture2D t2d_FeedRate_30;
	public Texture2D t2d_FeedRate_40;
	public Texture2D t2d_FeedRate_50;
	public Texture2D t2d_FeedRate_60;
	public Texture2D t2d_FeedRate_70;
	public Texture2D t2d_FeedRate_80;
	public Texture2D t2d_FeedRate_90;
	public Texture2D t2d_FeedRate_100;
	public Texture2D t2d_FeedRate_110;
	public Texture2D t2d_FeedRate_120;
	public Texture2D t2d_FeedRate_130;
	public Texture2D t2d_FeedRate_140;
	public Texture2D t2d_FeedRate_150;
	public int feedrate_type = 0;
	public Texture2D t2d_spCW_off_d;
	public Texture2D t2d_spCW_off_u;
	public Texture2D t2d_spCW_on_d;
	public Texture2D t2d_spCW_on_u;
	public Texture2D t2d_spCCW_on_u;
	public Texture2D t2d_spCCW_on_d;
	public Texture2D t2d_spCCW_off_u;
	public Texture2D t2d_spCCW_off_d;
	public Texture2D t2d_spStop_on_u;
	public Texture2D t2d_spStop_on_d;
	public Texture2D t2d_spStop_off_u;
	public Texture2D t2d_spStop_off_d;
	public Texture2D t2d_rapid_on_u;
	public Texture2D t2d_rapid_on_d;
	public Texture2D t2d_rapid_off_u;
	public Texture2D t2d_rapid_off_d;
	public Texture2D t2d_BottomButton_u;
	public Texture2D t2d_BottomButton_d;
	
	//内容--定义变量，用于实现JOG模式下F0、25%、50%、100%四个按钮的显示
	//姓名--刘旋，时间--2013-4-8
	public Texture2D t2d_f0_on_u;
	public Texture2D t2d_f0_on_d;
	public Texture2D t2d_f0_off_u;
	public Texture2D t2d_f0_off_d;
	public Texture2D t2d_f25_on_u;
	public Texture2D t2d_f25_on_d;
	public Texture2D t2d_f25_off_u;
	public Texture2D t2d_f25_off_d;
	public Texture2D t2d_f50_on_u;
	public Texture2D t2d_f50_on_d;
	public Texture2D t2d_f50_off_u;
	public Texture2D t2d_f50_off_d;
	public Texture2D t2d_f100_on_u;
	public Texture2D t2d_f100_on_d;
	public Texture2D t2d_f100_off_u;
	public Texture2D t2d_f100_off_d;//增加内容到此 2013-4-8
	
	//label字体style
	public GUIStyle sty_ProgEDITWindowO;
	public GUIStyle sty_Title;
	public GUIStyle sty_TitleLetter;
	public GUIStyle sty_BigXYZ;
	public GUIStyle sty_SmallNum;
	public GUIStyle sty_ProgramName;
	public GUIStyle sty_ProgModeName;
	public GUIStyle sty_Star;
	public GUIStyle sty_Alarm;
	public GUIStyle sty_AlarmLetter;
	public GUIStyle sty_BottomChooseMenu;
	public GUIStyle sty_ProgEditProgNum;
	public GUIStyle sty_PosSmallWord;
	public GUIStyle sty_SmallXYZ;
	public GUIStyle sty_ScreenCover;
	public GUIStyle sty_ProgEDITWindowFG;
	public GUIStyle sty_BottomAST;
	public GUIStyle sty_MostWords;
	public GUIStyle sty_Code;
	public GUIStyle sty_ProgEDITListWindowNum;
	public GUIStyle sty_Cursor;
	public GUIStyle sty_Warning;
	//内容--定义sty-Mode，用于显示模态
	//姓名--刘旋，时间--2013-3-29
	public GUIStyle sty_Mode;
	public GUIStyle sty_ModeCode;
	
	//button按钮style
	public GUIStyle sty_NCPowerOn;
	public GUIStyle sty_NCPowerOff;
	public GUIStyle sty_ButtonCW;
	public GUIStyle sty_ButtonCCW;
	public GUIStyle sty_ButtonSTOP;
	public GUIStyle sty_ButtonRapid;
	public GUIStyle sty_ButtonYP;
	public GUIStyle sty_ButtonYN;
	public GUIStyle sty_ButtonZP;
	public GUIStyle sty_ButtonZN;
	public GUIStyle sty_ButtonXP;
	public GUIStyle sty_ButtonXN;
	public GUIStyle sty_Button4P;
	public GUIStyle sty_Button4N;
	public Texture2D t2d_ButtonYP;
	public Texture2D t2d_ButtonYP_u;
	public Texture2D t2d_ButtonYN;
	public Texture2D t2d_ButtonYN_u;
	public Texture2D t2d_ButtonZP;
	public Texture2D t2d_ButtonZP_u;
	public Texture2D t2d_ButtonZN;
	public Texture2D t2d_ButtonZN_u;
	public Texture2D t2d_ButtonXP;
	public Texture2D t2d_ButtonXP_u;
	public Texture2D t2d_ButtonXN;
	public Texture2D t2d_ButtonXN_u;
	
	//内容--定义sty_ButtonF0、sty_Button25、sty_Button50、sty_Button100，用于实现JOG模式下F0、25%、50%、100%四个按钮的显示
	//姓名--刘旋，时间--2013-4-8
	public GUIStyle sty_ButtonF0;
	public GUIStyle sty_ButtonF25;
	public GUIStyle sty_ButtonF50;
	public GUIStyle sty_ButtonF100;//增加内容到此 2013-4-8
	
	public GUIStyle sty_ButtonEmpty;
	public GUIStyle sty_ScreenBackGround;
	public GUIStyle sty_TopLabel;
	public GUIStyle sty_BottomButtonSmallest;
	public GUIStyle sty_BottomButton_1;
	public GUIStyle sty_BottomButton_2;
	public GUIStyle sty_BottomButton_3;
	public GUIStyle sty_BottomButton_4;
	public GUIStyle sty_BottomButton_5;
	public GUIStyle sty_BottomLabel_1;
	public GUIStyle sty_BottomLabel_2;
	public GUIStyle sty_BottomLabel_3;
	public GUIStyle sty_BottomLabel_4;
	public GUIStyle sty_ClockStyle;
	public GUIStyle sty_EDITLabel;
	public GUIStyle sty_EDITLabelWindow;
	public GUIStyle sty_ProgSharedWindow;
	public GUIStyle sty_EDITLabelBar_1;
	public GUIStyle sty_EDITLabelBar_2;
	public GUIStyle sty_EDITLabelBar_3;
	public GUIStyle sty_EDITCursor;
	public GUIStyle sty_EDITTextField;
	public GUIStyle sty_EDITList;
	public GUIStyle sty_ListContent;
	public GUIStyle sty_ListWindow;
	public GUIStyle sty_AUTOCheck;
	public GUIStyle sty_InputTextField;
	public GUIStyle sty_OffSet_Coo;
	public GUIStyle sty_SettingsBG;
	public GUIStyle sty_EditListTop;
	
	//内容--定义Message界面字体
	public GUIStyle sty_MessAlarm;
	public GUIStyle sty_MessRecordID;
	public GUIStyle sty_MessRecordTime;
	public GUIStyle sty_MessRecordInfo;
	//内容--定义System界面字体
	public GUIStyle sty_SysID;
	public GUIStyle sty_SysInfo;
	//蓝色光标
	public GUIStyle sty_BlueCursor;
	
	//定义恢复出厂设置窗口字体  添加 BY王广官
	public GUIStyle sty_ResetWindow; 
	
	//内容--定义布尔变量，控制System、Message的显示，姓名--刘旋，时间--2013-4-24
	public bool SystemMenu = false;
	public bool MessageMenu = false;
	public bool PosMenu = true;
	public bool RelativeCoo = false;
	public bool AbsoluteCoo = true;
	public bool GeneralCoo = false;
	public bool ScreenPower = false;
	public bool ScreenCover = false;
	public string MenuDisplay = "编辑";
	public int ProgramNum = 0;
	public int AutoProgName = -1;
	public int LineNum = 0;
	public int SpindleSpeed = 0; //S主轴转速
	public float spindleRate = 1f;  //主轴转速倍率
	public int spindleState = 0;  //主轴状态：0为停止，1为CW，2为CCW
	public int ToolNo = 0; //T刀具号
	public bool manual_tool_change = false;
	public int PartsNum = 0;  //加工零件数
	public int RunningTimeH = 57; //运行时
	public int RunningTimeM = 60; //运行分
	public int CycleTimeH = 24; //循环时间时
	public int CycleTimeM = 60; //循环时间分
	public int CycleTimeS = 60; //循环时间秒
	public int RunningSpeed = 0; //实速度
	public int SACT = 20; //相当于转速
	public bool ALMBlink = false;
	public bool ALM_Control = true;
	public bool CursorBlink = false;
	public float BlinkTime = 0;
	public bool ProgMenu = false;
	public bool ProgEDIT = true;
	public bool ProgEDITProg = true;
	public bool ProgEDITList = false;
	public int ProgEDITFlip = 0;
	//内容--定义变量ProgAUTOFlip，用于控制AUTO模式下屏幕的显示
	//姓名--刘旋，时间--2013-3-25
	public int ProgAUTOFlip = 0;
	public int ProgSharedFlip = 0;
	public int ProgSharedView = 0;
	public int ProgUsedNum = 0;
	public int ProgUnusedNum = 400;
	public int ProgUsedSpace = 0;
	//内容--内存总容量为512K，姓名--刘旋，时间--2013-3-18
	public int ProgUnusedSpace = 512;//将419430400修改为512
	//内容--定义变量ProgMDIFlip，用于控制MDI模式下，程序菜单屏幕的显示，姓名--刘旋，时间--2013-4-22
	public int ProgMDIFlip = 0;
	//内容--定义变量ProgDNCFlip，用于控制DNC模式下，程序菜单屏幕的显示，姓名--刘旋，时间--2013-4-22
	public int ProgDNCFlip = 0;
	//内容--定义变量ProgHANFlip，用于控制Handle模式下，程序菜单屏幕的显示，姓名--刘旋，时间--2013-4-22
	public int ProgHANFlip = 0;
	//内容--定义变量MessageFlip，用于Message模式的显示，姓名--刘旋，时间--2013-4-24
	public int MessageFlip = 0;
	//内容--定义变量SystemFlip，用于System模式的显示，姓名--刘旋，时间--2013-4-24
	public int SystemFlip = 0;
	public float ProgEDITCusor = 0;
	
	/// 记录当前光标的索引, 董帅 陈晓威， 2013-4-2
	//EDIT模式下
	//光标当前行
	public int ProgEDITCusorV = 0;
	//光标当前列
	public int ProgEDITCusorH = 0;
	//MDI模式下
	public int MDIProgEDITCusorV = 0;
	public int MDIProgEDITCusorH = 0;
	/// 记录选中的代码的起点索引和终点索引  董帅  2013-4-2
	public int SelectStart = 0;
	public int SelectEnd = 0;
	public int MDISelectStart = 0;
	public int MDISelectEnd = 0;
	//记录是否选择 陈晓威 
	public bool IsSelect = false;
	public bool editDisplay = true;  //判断之前是显示EDIT画面还是MDI画面
	/// 记录程序分行的位置，董帅，2013-4-2
	public List<int> SeparatePosStart;
	public List<int> SeparatePosEnd;
	public int total_row = 0;
	public List<int> SeparateAutoStart;
	public List<int> SeparateAutoEnd;
	public int auto_total_row = 0;
	public List<int> SeparateMDIStart;
	public List<int> SeparateMDIEnd;
	public int mdi_total_row = 0;
	//public int ProgTotalRow = 0;
	
	//复制缓冲区 董帅 2013-4-10
	public List<string> CodeBuffer = new List<string> ();
	
	//是否选择代码首个 陈晓威
	public bool isSelecFirst = false;
	//用CodeForMDI来存放MDI中的代码  
	public List<string> CodeForMDI = new List<string> ();
	public List<string> CodeForMDIRuning = new List<string> ();
	//auto模式下code 陈晓威
	public List<string> CodeForAUTO = new List<string> ();
	public int AutoBeginRow = 0;
	public int AutoStopRow = 0;
	public int AUTOStartRow = 0;
	public int AUTOEndRow = 0;
	public int MDIBeginRow = 0;
	public int MDIStopRow = 0;
	public int MDIStartRowC = 0;
	public int MDIEndRowC = 0;
	public bool autoDisplayNormal = true;
	public int autoSelecedProgRow = 0;
	public int MDISelectedRow = 0;
	public float ProgEDITCusorPos = 0;
	public float InputTextPos = 0;
	public bool ProgDNC = false;
	public bool ProgAUTO = false;
	public bool ProgMDI = false;
	public bool ProgHAN = false;
	public bool ProgJOG = false;
	public bool ProgREF = false;
	public bool EmergencyCtrl = false;
	public bool EmergencyBlink = false;
	public bool ProgProtect = true;
	public bool ProgProtectWarn = false;
	public Vector2 TextSize = new Vector2 (0, 0);
	public bool SettingMenu = false;
	public bool OffSetTool = true;
	public bool OffSetSetting = false;
	public bool OffSetCoo = false;
	public bool OffSetOne = true;
	public bool OffSetTwo = false;
	public bool OffCooFirstPage = true;
	public List<string> FileNameList = new List<string> ();
	public List<int> FileSizeList = new List<int> ();
	public List<string> FileDateList = new List<string> ();
	//用CodeForAll来存放将ＮＣ代码分词后的结果 董帅 2013-4-3
	public List<string> CodeForAll = new List<string> ();
	public List<List<string>> TempCodeList = new List<List<string>> ();
	public bool[] MoreThanOneArray = new bool[9];
	public int[] RealNumArray = new int[9];
	public string[] TempCodeArray = new string[9];
	
	// 当前显示的开始行索引和结束行索引 董帅 2013-4-2
	public int StartRow = 0;  //EDIT部分的起始行
	public int EndRow = 9;  //EDIT部分的终止行
	public int MDIStartRow = 0;
	public int MDIEndRow = 9;
	//检索结果标识
	public bool NotFoundWarn = false;
	public int TotalCodeNum = 0;
	public int RealCodeNum = 1;
	public int HorizontalNum = 1;
	public int VerticalNum = 1;
	//The total amount of satisfatory NC files in the Gcode directory.
	public int TotalListNum = 0;
	//The location of current file in the NC file list.
	public int RealListNum = 1;
	public string[] CodeName = new string[8];
	public int[] CodeSize = new int[8];
	public string[] UpdateDate = new string[8];
	public string current_filename = "";
	//The location of current file in the NC file list. Co-operate with arqument RealFileList.
	public int current_filenum = 0;
	public GUIText EDITText;
	public GUIText CursorText;
	public bool ShiftFlag = false;
	public string InputText = "";
	public string TempInputText = "";
	public Vector2 InputTextSize = new Vector2 (0, 0);
	public string OffSetTemp = "";
	public float coo_setting_cursor_x = 131f;
	public float coo_setting_cursor_y = 120f;
	public int coo_setting_1 = 1;
	public int coo_setting_2 = 1;
	public bool power_notification = false;
	Rect power_notifi_window = new Rect (0, 0, 300f, 151f);
	public GUIStyle sty_PowerNotifi;
	public GUIStyle sty_PowerNotifi_confirm;
	public GUIStyle sty_PowerNotifi_cancel;
	public GUIStyle sty_ScreenBlack;
	public float move_rate = 1f;
	
	//设定界面修改---张振华---03.11
	public GUIStyle sty_OffSet_Coo_mini;
	public GUIStyle sty_OffSet_Coo_mid;
	public float argu_setting_cursor_y = 61.5f;
	public float argu_setting_cursor_w = 16f;
	public int argu_setting = 1;
	//设定界面修改---张振华---03.11
	
	//位置界面功能完善---宋荣 ---03.09
	public bool operationBottomScrInitial = false;//position模式下按下操作键的初始界面显示标志
	public bool operationBottomScrExecute = false;//position模式下按下执行界面显示标志
	public bool posTimeAndNumber = false;
	public bool partsNumBlink = false;//零件数闪烁标志
	public bool runtimeIsBlink = false;//运行时间闪烁标志
	public bool posOperationMode = false;//position下按下操作键,用来屏蔽第一、二、三个按钮的操作。
	public int statusBeforeOperation = -1;
	//位置界面功能完善---宋荣 ---03.09

	//内容--定义布尔变量ProgEDITAt，用于选择程序时，前加@
	public bool ProgEDITAt = false;
	public int at_position = -1;
	public int at_page_number = -1;
	
	//刀偏界面完善---张振华---03.30
	public GUIStyle sty_MostWords_ToolOffSet;        //刀偏界面字体
	public GUIStyle sty_SerialNum;
	public int ToolOffSetPage_num = 0;
	public int number = 0;
	public int tool_setting = 1 ; //值为1-32，代表刀偏界面的每一个空格
	public float tool_setting_cursor_y = 81.5f; //刀偏界面光标水平方向的值
	public float tool_setting_cursor_w = 91.5f; //刀偏界面光标垂直方向的值
	//刀偏界面完善---张振华---03.30
	
	//窗口动画控制
	float show_off_speed = 3f;  //窗口切换的速度
	float left = -300f;  //控制窗口界面左右移动
	float top = 0;  //控制窗口界面上下移动
	bool panelWindow_show_off = false; //主界面splash动画控制
	bool screen_show_off = false;  //小窗口splash动画控制
	bool show_off_times = false;  //单独动作还是连续动作判断
	bool appear_dispear = true;  //出现或者消失
	float show_off_centre_x = 0;
	float show_off_centre_y = 0;
	float show_off_big_corner_x = 0;
	float show_off_big_corner_y = 0;
	float show_off_small_corner_x = 0;
	float show_off_small_corner_y = 0;
	bool screen_move_on = false;
	float hide_start_x = 0;
	float screen_move_speed = 20f;
	float display_speed = 0;
	bool screen_hide = false;
	public float remaining_x = 0; //剩余移动量X
	public float remaining_y = 0; //剩余移动量Y
	public float remaining_z = 0; //剩余移动量Z
	public bool x_return_zero = false; //X轴回零
	public bool y_return_zero = false; //Y轴回零
	public bool z_return_zero = false; //Z轴回零
	public string warnning_string = ""; //警告信息
	public int Progname_Backup = 0; //用于不同的运动模式切换
	public bool beModifed = false; //EDIT中的程序是否被
	public bool MDIpos_flag = false; //MDI界面相关
	public bool Compile_flag = false; //如果通过编译，该标志位为true
	public bool AutoRunning_flag = false; //如果AUTO程序正在运行，该标志位为true
	public bool AutoPause_flag = false; //如果AUTO程序在运行时处于暂停状态，改标志位为true;
	public bool MDI_CompileFlag = false;  //MDI程序编译状态
	public bool MDI_RunningFlag = false;  //MDI程序正在运行标志位
	public bool MDI_PauseFlag = false;  //MDI程序暂停标志位
	public bool SingleStep = false;  //单步运行
	public bool Current_F_value = false; //当前段F值显示标志位
	public bool Current_S_value = false; //当前段S值显示标志位
	public bool Current_T_value = false; //当前段T值显示标志位
	public bool Current_H_value = false; //当前段H值显示标志位
	public bool Current_D_value = false; //当前段D值显示标志位
	public bool Current_M_value = false; //当前段M值显示标志位
	public int H_value = 0; //H值显示
	public int D_value = 0; //H值显示
	public int M_value = 0; //H值显示
	public int T_Value = 0; //R值显示
	public bool OSP_On = false;
	public float toolLength = 0;
	public float toolDiameter = 0;
	public bool main_axis_on = false;
	#endregion
	
	#region Variable For Button Enlarge
	public bool show_off_button_on = true;
	public GUIStyle sty_pO;
	public GUIStyle sty_qN;
	public GUIStyle sty_rG;
	public GUIStyle sty_a7;
	public GUIStyle sty_b8;
	public GUIStyle sty_c9;
	public GUIStyle sty_uX;
	public GUIStyle sty_vY;
	public GUIStyle sty_wZ;
	public GUIStyle sty_four;
	public GUIStyle sty_five;
	public GUIStyle sty_six;
	public GUIStyle sty_iM;
	public GUIStyle sty_jS;
	public GUIStyle sty_kT;
	public GUIStyle sty_one;
	public GUIStyle sty_two;
	public GUIStyle sty_three;
	public GUIStyle sty_lF;
	public GUIStyle sty_dH;
	public GUIStyle sty_eEOB;
	public GUIStyle sty_ap;
	public GUIStyle sty_zero;
	public GUIStyle sty_po;
	public GUIStyle sty_sh;
	public GUIStyle sty_Pos;
	public GUIStyle sty_PROG;
	public GUIStyle sty_SET;
	public GUIStyle sty_INPUT;
	public GUIStyle sty_SYSTEM;
	public GUIStyle sty_MESSAGE;
	public GUIStyle sty_GRPH;
	public GUIStyle sty_HELP;
	public GUIStyle sty_RESET;
	public GUIStyle sty_CAN;
	public GUIStyle sty_ALTER;
	public GUIStyle sty_INSERT;
	public GUIStyle sty_DELETE;
	public GUIStyle sty_PAGEu;
	public GUIStyle sty_PAGEd;
	public GUIStyle sty_COOL;
	public Texture2D sty_COOL_u;
	public Texture2D sty_COOL_d;
	public GUIStyle sty_MHS;
	public Texture2D sty_MHS_u;
	public Texture2D sty_MHS_d;
	public GUIStyle sty_ATCW;
	public Texture2D sty_ATCW_u;
	public Texture2D sty_ATCW_d;
	public GUIStyle sty_ATCCW;
	public Texture2D sty_ATCCW_u;
	public Texture2D sty_ATCCW_d;
	public GUIStyle sty_MHRN;
	public Texture2D sty_MHRN_u;
	public Texture2D sty_MHRN_d;
	public GUIStyle sty_FOR;
	public Texture2D sty_FOR_u;
	public Texture2D sty_FOR_d;
	public GUIStyle sty_BACK;
	public Texture2D sty_BACK_u;
	public Texture2D sty_BACK_d;
	public GUIStyle sty_MLK;
	public Texture2D sty_MLK_u;
	public Texture2D sty_MLK_d;
	public GUIStyle sty_DRN;
	public Texture2D sty_DRN_u;
	public Texture2D sty_DRN_d;
	public GUIStyle sty_BDT;
	public Texture2D sty_BDT_u;
	public Texture2D sty_BDT_d;
	public GUIStyle sty_SBK;
	public Texture2D sty_SBK_u;
	public Texture2D sty_SBK_d;
	public GUIStyle sty_OSP;
	public Texture2D sty_OSP_u;
	public Texture2D sty_OSP_d;
	public GUIStyle sty_ZLOCK;
	public Texture2D sty_ZLOCK_u;
	public Texture2D sty_ZLOCK_d;
	public GUIStyle sty_S4P;
	public Texture2D sty_S4P_u;
	public Texture2D sty_S4P_d;
	public GUIStyle sty_SYN;
	public Texture2D sty_SYN_u;
	public Texture2D sty_SYN_d;
	public GUIStyle sty_SZP;
	public Texture2D sty_SZP_u;
	public Texture2D sty_SZP_d;
	public GUIStyle sty_SXP;
	public Texture2D sty_SXP_u;
	public Texture2D sty_SXP_d;
	public GUIStyle sty_SRAPID;
	public Texture2D sty_SRAPID_u;
	public Texture2D sty_SRAPID_d;
	public GUIStyle sty_SXN;
	public Texture2D sty_SXN_u;
	public Texture2D sty_SXN_d;
	public GUIStyle sty_S4N;
	public Texture2D sty_S4N_u;
	public Texture2D sty_S4N_d;
	public GUIStyle sty_SYP;
	public Texture2D sty_SYP_u;
	public Texture2D sty_SYP_d;
	public GUIStyle sty_SZN;
	public Texture2D sty_SZN_u;
	public Texture2D sty_SZN_d;
	public GUIStyle sty_SF0;
	public Texture2D sty_SF0_u;
	public Texture2D sty_SF0_d;
	public GUIStyle sty_SF25;
	public Texture2D sty_SF25_u;
	public Texture2D sty_SF25_d;
	public GUIStyle sty_SF50;
	public Texture2D sty_SF50_u;
	public Texture2D sty_SF50_d;
	public GUIStyle sty_SF100;
	public Texture2D sty_SF100_u;
	public Texture2D sty_SF100_d;
	public GUIStyle sty_SDOWN;
	public Texture2D sty_SDOWN_u;
	public Texture2D sty_SDOWN_d;
	public GUIStyle sty_SHUNDRED;
	public Texture2D sty_SHUNDRED_u;
	public Texture2D sty_SHUNDRED_d;
	public GUIStyle sty_SUP;
	public Texture2D sty_SUP_u;
	public Texture2D sty_SUP_d;
	public GUIStyle sty_SORIENT;
	public Texture2D sty_SORIENT_u;
	public Texture2D sty_SORIENT_d;
	public GUIStyle sty_SCW;
	public Texture2D sty_SCW_u;
	public Texture2D sty_SCW_d;
	public GUIStyle sty_SSTOP;
	public Texture2D sty_SSTOP_u;
	public Texture2D sty_SSTOP_d;
	public GUIStyle sty_SCCW;
	public Texture2D sty_SCCW_u;
	public Texture2D sty_SCCW_d;
	#endregion
	
	#region Variable For Knob Enlarge
	public GUIStyle sty_enlargeknob;
	public Texture2D t2d_EDIT;
	public Texture2D t2d_DNC;
	public Texture2D t2d_AUTO;
	public Texture2D t2d_MDI;
	public Texture2D t2d_MPG;
	public Texture2D t2d_JOG;
	public Texture2D t2d_ZERO;
	public Texture2D t2d_Feedrate0;
	public Texture2D t2d_Feedrate10;
	public Texture2D t2d_Feedrate20;
	public Texture2D t2d_Feedrate30;
	public Texture2D t2d_Feedrate40;
	public Texture2D t2d_Feedrate50;
	public Texture2D t2d_Feedrate60;
	public Texture2D t2d_Feedrate70;
	public Texture2D t2d_Feedrate80;
	public Texture2D t2d_Feedrate90;
	public Texture2D t2d_Feedrate100;
	public Texture2D t2d_Feedrate110;
	public Texture2D t2d_Feedrate120;
	public Texture2D t2d_Feedrate130;
	public Texture2D t2d_Feedrate140;
	public Texture2D t2d_Feedrate150;
	#endregion 
	
	#region Variable For Screen Modify
	public float corner_px = 15f;
	public float corner_py = 15f;
	public float screen_sizex = 400f;
	public float screen_sizey = 400f;
	#endregion
	
	#region GUI Variable
	public Rect screenRect = new Rect (300, 100, 30, 40);
	public GUIStyle sty_screenOnlyBackground;
	public bool screenOnly = false;
	public bool panelWindowOnly = true;
	float small_corner_px = 11f;
	float small_corner_py = 9f;
	float big_corner_px = 33.5f;
	float big_corner_py = 32f;
	public GUIStyle sty_Rightclick;
	public GUIStyle sty_RightCursor;
	public GUIStyle sty_RightLine;
	public GUIStyle sty_RightclickFont;
	public GUIStyle sty_InformationTipsColorFont;
	public GUIStyle sty_InformationTipsColorFont2;
	public GUIStyle sty_ToolTip;
	public GUIStyle sty_SetupGuide;
	public GUIStyle sty_Arrow;
	public Texture2D t2d_ArrowL;
	public Texture2D t2d_ArrowR;
	int SetupFlip = 1;
	bool pathLineDisplay = true;
	bool originalPathDisplay = true;
	Texture2D SetupGuide1;
	Texture2D SetupGuide2;
	Texture2D SetupGuide3;
	Texture2D SetupGuide4;
	Texture2D SetupGuide5;
	Rect SetupGuide_Rect = new Rect (0, 0, 508, 408);
	public bool SetupGuide_on = true;
	public GUIStyle sty_SetupClose;
	public GUIStyle sty_SetupCheckBox;
	bool CheckBox_On = false;
	Texture2D CheckBox_checked;
	Texture2D CheckBox_unchecked;
	public GUIStyle sty_LeftArrow;
	public GUIStyle sty_RightArrow;
	Rect ExitWindow_Rect = new Rect (0, 0, 305, 225);
	bool ExitWindow_On = false;
	public GUIStyle sty_ExitBackground;
	public GUIStyle sty_ExitClose;
	public GUIStyle sty_ExitSettings;
	public GUIStyle sty_ExitProg;
	public GUIStyle sty_SystemSettings_Background;
	bool SystemSettings_On = false;
	Rect SystemSettings_Rect = new Rect (0, 0, 505, 580);
	Texture2D t2d_SystemSettings1;
	Texture2D t2d_SystemSettings2;
	Texture2D t2d_SystemSettings3;
	int SystemSettingsFlip = 1;
	public GUIStyle sty_SystemSettings_Prev;
	public GUIStyle sty_SystemSettings_Next;
	public GUIStyle sty_SystemSettings_On1;
	public GUIStyle sty_SystemSettings_On2;
	public GUIStyle sty_SystemSettings_On3;
	public GUIStyle sty_SystemSettings_On4;
	public GUIStyle sty_SystemSettings_OpenFile;
	public GUIStyle sty_SystemSettings_DefaultSettings;
	Texture2D t2d_SystemSettings_On;
	Texture2D t2d_SystemSettings_Off;
	public GUIStyle sty_SystemSettings_VSlider;
	Texture2D t2d_SystemSettings_VSlider1;
	Texture2D t2d_SystemSettings_VSlider10;
	Texture2D t2d_SystemSettings_VSlider100;
	Texture2D t2d_SystemSettings_VSlider1000;
	public GUIStyle sty_SystemSettings_VSliderLeft;
	public GUIStyle sty_SystemSettings_VSliderRight;
	int SystemSettings_VSlider_State = 1;
	public GUIStyle sty_PopupWindow;
#endregion
	
	#region Pad Parameter
	public float move_rate_pad = 1f;  //JOG移动倍率控制
	public float speed_to_move = 0.10201F;  //JOG移动速率控制
	bool held_flag = false;  //手指是否按下状态
	bool button_status = false;  //按钮是否处于按下状态
	
	public Vector3 absolute_pos = new Vector3(0,0,0);  //绝对坐标
	public Vector3 relative_pos = new Vector3(0,0,0);  //相对坐标
	public Vector3 MachineCoo = new Vector3(800f,500f,510f);  //机械坐标
	float RotateSpeed = 1000;  //机床存储器中暂存的速度值
	public bool rect_contain = false;  //pad menu control flag 
	bool x_p = false;  //控制速度显示
	bool x_n = false;  //控制速度显示
	bool y_p = false;  //控制速度显示
	bool y_n = false;  //控制速度显示
	bool z_p = false;  //控制速度显示
	bool z_n = false;  //控制速度显示
	public GUIStyle sty_clampWindow;
	public Texture2D t2d_clampMode;
	public Texture2D t2d_clampMode1;
	public Texture2D t2d_clampMode2;
	public Texture2D t2d_clampMode3;
	public GUIStyle sty_ClampLoad;
	public GUIStyle sty_ClampUnload;
	public GUIStyle sty_ClampFont;
	bool manualMilling = false;
	public bool mainWindowDrag = true;
	float dragTime = 0;
	#endregion
	
	void Awake ()
	{
		Client_Script = gameObject.GetComponent<ClientCenter> ();
		
//		small_corner_px = 11.5f;
//		small_corner_py = 8.5f;
		small_corner_px = 31.5f;
		small_corner_py = 32f;
		big_corner_px = 33.5f;
		big_corner_py = 32f;
		corner_px = 33.5f;
		corner_py = 32f;
		screen_sizex = 498f;
		screen_sizey = 375f;
		transform.name = "MainScript";
		InputTextPos = corner_px + 23.5f;
		screenRect.width = SystemArguments.SmallScreen_Width;
		screenRect.height = SystemArguments.SmallScreen_Heght; 
//		width = 0.1f;
//		height = 0.1f;
		width = SystemArguments.PanelWindow_Width;
		height = SystemArguments.PanelWindow_Height;
		left = 0f;
		top = 0f;
		show_off_speed = 8.5f;
		show_off_big_corner_x = Screen.width - 30f - SystemArguments.PanelWindow_Width;
		show_off_big_corner_y = 30f;
		show_off_centre_x = show_off_big_corner_x + SystemArguments.PanelWindow_Width / 2;
		show_off_centre_y = show_off_big_corner_y + SystemArguments.PanelWindow_Height / 2;
		show_off_small_corner_x = show_off_centre_x - SystemArguments.SmallScreen_Width / 2;
		show_off_small_corner_y = show_off_centre_y - SystemArguments.SmallScreen_Heght / 2;
//		PanelWindowRect = new Rect (width, 30f, width, height);		
//		PanelWindowRect = new Rect (Screen.width - SystemArguments.PanelWindow_Width, (Screen.height - SystemArguments.PanelWindow_Height)/2, 
//			SystemArguments.PanelWindow_Width, SystemArguments.PanelWindow_Height);	
		PanelWindowRect = new Rect (Screen.width - SystemArguments.PanelWindow_Width + 20f, (Screen.height - SystemArguments.PanelWindow_Height)/2 + 5f, width, height);	
		screen_move_on = true;
		
		//添加 BY:WH
		gameObject.AddComponent <LightNumber> ();
		LightNumber_Script = gameObject.GetComponent<LightNumber> ();
//		GameObject.Find ("Main Camera").AddComponent <PathLineDraw> ();
//		PathLineDraw_Script = GameObject.Find ("Main Camera").GetComponent<PathLineDraw> ();
//		gameObject.AddComponent<ModelInitialize> ();
		gameObject.AddComponent<NCCodeFormat> ();
//		gameObject.AddComponent<DisplayMode> ();
		NCCodeFormat_Script = gameObject.GetComponent<NCCodeFormat> ();
		gameObject.AddComponent <PositionModule> ();
		Position_Script = gameObject.GetComponent<PositionModule> ();
		gameObject.AddComponent<SystemModule> ();//添加脚本，姓名--刘旋，时间--2013-4-24
		System_Script = gameObject.GetComponent<SystemModule> ();
		gameObject.AddComponent<MessageModule> ();
		Message_Script = gameObject.GetComponent<MessageModule> ();
		gameObject.AddComponent <SoftkeyModule> ();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule> ();
		gameObject.AddComponent<ProgramModule> ();
		Program_Script = gameObject.GetComponent<ProgramModule> ();
		gameObject.AddComponent<OffsetSettingModule> ();
		Offset_Script = gameObject.GetComponent<OffsetSettingModule> ();
		gameObject.AddComponent <MDIInputModule> ();
		MDIInput_Script = gameObject.GetComponent<MDIInputModule> ();
		gameObject.AddComponent<MDIFunctionModule> ();
		MDIFunction_Script = gameObject.GetComponent<MDIFunctionModule> ();
		gameObject.AddComponent<MDIEditModule> ();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule> ();
		gameObject.AddComponent<ModeSelectModule> ();
		ModeSelect_Script = gameObject.GetComponent<ModeSelectModule> ();
		gameObject.AddComponent<FeedrateModule> ();
		Feedrate_Script = gameObject.GetComponent<FeedrateModule> ();
		gameObject.AddComponent <MachineFunctionModule> ();
		MachineFunction_Script = gameObject.GetComponent<MachineFunctionModule> ();
		gameObject.AddComponent <AuxiliaryFunctionModule> ();
		AuxiliaryFunction_Script = gameObject.GetComponent<AuxiliaryFunctionModule> ();
		gameObject.AddComponent<PopupMessage>();
		PopupMessage_Script = gameObject.GetComponent<PopupMessage>();
		//GameObject move_obj = GameObject.Find("GameObjcet")
		//GameObject.Find("move_control").AddComponent("MoveControl");
		LoadScriptOfAudio ();
//		MoveControl_script = GameObject.Find ("move_control").GetComponent<MoveControl> ();
//		AuxiliaryMoveModule_Script = GameObject.Find ("move_control").GetComponent<AuxiliaryMoveModule> ();
		//GameObject.Find("spindle_control").AddComponent("SpindleControl");
//		SpindleControl_script = GameObject.Find ("spindle_control").GetComponent<SpindleControl> ();
		gameObject.AddComponent <CooSystem> ();
//		gameObject.AddComponent("AutoMove");
//		gameObject.AddComponent("CompileNC");
		CooSystem_script = gameObject.GetComponent<CooSystem> ();
//		CompileNC_script = gameObject.GetComponent<CompileNC>();
//		gameObject.AddComponent<EntranceScript> ();
//		AutoRunning_Script = gameObject.GetComponent<EntranceScript> ();
		gameObject.AddComponent<ButtonShowOff> ();
		ButtonShowOff_Script = gameObject.GetComponent<ButtonShowOff> ();
//		gameObject.AddComponent<TopMenu> ();
//		TopMenu_Script = gameObject.GetComponent<TopMenu> ();
		Warnning_Script = gameObject.GetComponent<Warnning> ();
//		gameObject.AddComponent<RightclickMenu> ();
//		RightclickMenu_Script = gameObject.GetComponent<RightclickMenu> ();
		gameObject.AddComponent<ProgramReset> ();
		ProgramReset_Script = gameObject.GetComponent<ProgramReset> ();
//		gameObject.AddComponent<InformationTips> ();
//		gameObject.AddComponent<Warnning>();
		HandWheel_Script = GameObject.Find ("HandleControl").GetComponent<HandWheelModule> ();
		gameObject.AddComponent<AutoDisplayControl>();
		AutoDisplay_Script = gameObject.GetComponent<AutoDisplayControl>();
		gameObject.AddComponent<PadLeftMenu>();
		gameObject.AddComponent<ClampControl>();
		
		background.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/11");
		sty_Rightclick.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/StartScreen");
		sty_RightCursor.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/RightCursor");
		sty_RightLine.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/Line");
		sty_RightclickFont.font = (Font)Resources.Load ("font/msyh");
		sty_RightclickFont.fontSize = 18;
		sty_RightclickFont.normal.textColor = new Color (0.0f, 0.0f, 0.0f, 0.85f);
		sty_RightclickFont.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/RightCursor");
		sty_RightclickFont.alignment = TextAnchor.MiddleCenter;
		sty_InformationTipsColorFont.font = (Font)Resources.Load ("font/msyh");
		sty_InformationTipsColorFont.fontSize = 13;
//		sty_InformationTipsColorFont.fontStyle = FontStyle.Bold;
		sty_InformationTipsColorFont.normal.textColor = new Color (0.0f, 0.0f, 0.0f, 0.85f);
//		sty_InformationTipsColorFont.normal.textColor = new Color (0.27f, 0.71f, 0.875f, 1.0f);
//		sty_InformationTipsColorFont.normal.textColor = new Color (0.35f, 0.6f, 0.66f, 1.0f);
		sty_InformationTipsColorFont2.font = (Font)Resources.Load ("font/msyh");
		sty_InformationTipsColorFont2.fontSize = 13;
		sty_InformationTipsColorFont2.normal.textColor = new Color (1.0f, 1.0f, 1.0f, 0.9f);
		sty_ToolTip.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ToolTips");
		t2d_ArrowR = (Texture2D)Resources.Load ("Texture_Panel/Label/ArrowR");
		t2d_ArrowL = (Texture2D)Resources.Load ("Texture_Panel/Label/ArrowL");
		sty_Arrow.normal.background = t2d_ArrowR;
//		sty_ToolTip.border.left = 20;
//		sty_ToolTip.border.right = 8;
		power_notifi_window.x = Screen.width / 2 - power_notifi_window.width / 2;
		power_notifi_window.y = Screen.height / 2 - power_notifi_window.height / 2;
		sty_PowerNotifi.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/PowerWindow");
		sty_PowerNotifi_confirm.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/PowerWindowButton");
		sty_PowerNotifi_confirm.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/PowerWindowButton_d");
		sty_PowerNotifi_cancel.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/PowerWindowCancel");
		sty_ScreenBlack.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ScreenBlack");
		sty_screenOnlyBackground.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/12");
		sty_SetupGuide.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide");
		SetupGuide1 = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide");
		SetupGuide2 = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide2");
		SetupGuide3 = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide3");
		SetupGuide4 = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide4");
		SetupGuide5 = (Texture2D)Resources.Load ("Texture_Panel/Label/SetupGuide5");
		SetupGuide_Rect.x = Screen.width / 2 - SetupGuide_Rect.width / 2;
		SetupGuide_Rect.y = Screen.height / 2 - SetupGuide_Rect.height / 2;
		sty_SetupClose.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/Close");
		sty_SetupCheckBox.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/UncheckedBox");
		CheckBox_checked = (Texture2D)Resources.Load ("Texture_Panel/Label/CheckedBox");
		CheckBox_unchecked = (Texture2D)Resources.Load ("Texture_Panel/Label/UncheckedBox");
		sty_LeftArrow.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/LeftArrow");
		sty_RightArrow.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/RightArrow");
		ExitWindow_Rect.x = Screen.width / 2 - ExitWindow_Rect.width / 2;
		ExitWindow_Rect.y = Screen.height / 2 - ExitWindow_Rect.height / 2;
		sty_ExitBackground.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/Exit");
		sty_ExitClose.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ExitClose");
		sty_ExitSettings.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ExitSetting1");
		sty_ExitSettings.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ExitSetting2");
		sty_ExitProg.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ExitProg1");
		sty_ExitProg.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ExitProg2");
		
		sty_SystemSettings_Background.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings1");
		t2d_SystemSettings1 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings1"); 
		t2d_SystemSettings2 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings2"); 
		SystemSettings_Rect.x = Screen.width / 2 - SystemSettings_Rect.width / 2;
		SystemSettings_Rect.y = Screen.height / 2 - SystemSettings_Rect.height / 2;
		sty_SystemSettings_Prev.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_PrevN");
		sty_SystemSettings_Prev.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_PrevH");
		sty_SystemSettings_Prev.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_PrevP");
		sty_SystemSettings_Next.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NextN");
		sty_SystemSettings_Next.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NextH");
		sty_SystemSettings_Next.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NextP");
		t2d_SystemSettings_On = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_On");
		t2d_SystemSettings_Off = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Off");
		panelWindowOnly = false;
		
		sty_clampWindow.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlBg");
		t2d_clampMode1 = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlClamp1");
		t2d_clampMode2 = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlClamp2");
		t2d_clampMode3 = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlClamp3");
		t2d_clampMode = t2d_clampMode1;
		sty_ClampLoad.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlLoad1");
		sty_ClampLoad.active.background = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlLoad2");
		sty_ClampUnload.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlUnload1");
		sty_ClampUnload.active.background = (Texture2D)Resources.Load("Texture_Panel/Label/BlankControlUnload1");
		sty_ClampFont.font = (Font)Resources.Load ("font/msyh");
		sty_ClampFont.fontSize = 16;
		sty_ClampFont.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);

//		if(PlayerPrefs.HasKey("ShowOffButton"))
//		{
//			if(PlayerPrefs.GetInt("ShowOffButton") == 1)
//				show_off_button_on = true;
//			else
//				show_off_button_on = false;
//		}
//		else
//		{
//			PlayerPrefs.SetInt("ShowOffButton", 1);
//			show_off_button_on = true;
//		}
//		if(show_off_button_on)
//			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_On;
//		else
//			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_Off;
//		
//		if(PlayerPrefs.HasKey("OriginalPath"))
//		{
//			if(PlayerPrefs.GetInt("OriginalPath") == 1)
//				PathLineDraw_Script.originalPathDisplay = true;
//			else
//				PathLineDraw_Script.originalPathDisplay = false;
//		}
//		else
//		{
//			PlayerPrefs.SetInt("OriginalPath", 1);
//			PathLineDraw_Script.originalPathDisplay = true;
//		}
//		if(PathLineDraw_Script.originalPathDisplay)
//			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_On;
//		else
//			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_Off;
//		
//		if(PlayerPrefs.HasKey("PracticalPath"))
//		{
//			if(PlayerPrefs.GetInt("PracticalPath") == 1)
//				PathLineDraw_Script.pathLineDisplay = true;
//			else
//				PathLineDraw_Script.pathLineDisplay = false;
//		}
//		else
//		{
//			PlayerPrefs.SetInt("PracticalPath", 1);
//			PathLineDraw_Script.pathLineDisplay = true;
//		}
//		if(PathLineDraw_Script.pathLineDisplay)
//			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_On;
//		else
//			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_Off;
//		
//		if(PlayerPrefs.HasKey("SetupGuide"))
//		{
//			if(PlayerPrefs.GetInt("SetupGuide") == 1)
//				SetupGuide_on = true;
//			else
//				SetupGuide_on = false;
//		}
//		else
//		{
//			PlayerPrefs.SetInt("SetupGuide", 1);
//			SetupGuide_on = true;
//		}
//		if(SetupGuide_on)
//		{
//			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_On;
//			panelWindowOnly = false;
//		}
//		else
//		{
//			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_Off;
//			panelWindowOnly = true;
//		}
		sty_SystemSettings_OpenFile.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_File");
		sty_SystemSettings_OpenFile.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_FileH");
		sty_SystemSettings_OpenFile.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_FileH");
		sty_SystemSettings_DefaultSettings.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NC");
		sty_SystemSettings_DefaultSettings.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NCH");
		sty_SystemSettings_DefaultSettings.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_NCH");
		sty_SystemSettings_VSlider.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Slider1");
		t2d_SystemSettings_VSlider1 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Slider1");
		t2d_SystemSettings_VSlider10 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Slider10");
		t2d_SystemSettings_VSlider100 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Slider100");
		t2d_SystemSettings_VSlider1000 = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_Slider1000");
		sty_SystemSettings_VSliderLeft.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderLeft");
		sty_SystemSettings_VSliderLeft.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderLeft");
		sty_SystemSettings_VSliderLeft.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderLeftH");
		sty_SystemSettings_VSliderRight.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderRight");
		sty_SystemSettings_VSliderRight.active.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderRight");
		sty_SystemSettings_VSliderRight.hover.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SystemSettings_SliderRightH");
		
		sty_PopupWindow.normal.background = (Texture2D)Resources.Load("Texture_Panel/Label/PopupWindow");
		
		NCPower_x = 60f;
		NCPower_y = 564f;
		NCPower_width = 60f;
		NCPower_height = 40f;
		NCPower_left_x = 0f;
		NCPower_left_y = 85f;
		
		t2d_x = 180f;
		t2d_y = 534f;
		t2d_width = 55f;
		t2d_height = 29f;
		
		t2d_Emergency_x = 91;
		t2d_Emergency_y = 759;
		t2d_Emergency_width = 115;
		t2d_Emergency_height = 115;
		
		IO_width = 65f;
		IO_height = 50f;
		IO_x = 78f;
		IO_y = 900f;
		IO_left_x = 80f;
		
		left_x = 65f;
		
		Rapid_x = 693;

//		t2d_lock = (Texture2D)Resources.Load("Texture_Panel/Button/lock");
//		t2d_unlock = (Texture2D)Resources.Load("Texture_Panel/Button/unlock");
		t2d_lock = (Texture2D)Resources.Load ("DigitalControlPanel/66_2");
		t2d_unlock = (Texture2D)Resources.Load ("DigitalControlPanel/66");
//		t2d_alarm = (Texture2D)Resources.Load("Texture_Panel/Button/alarm");
//		t2d_zero = (Texture2D)Resources.Load("Texture_Panel/Button/zero");
//		t2d_toolnum = (Texture2D)Resources.Load("Texture_Panel/Button/toolnum");	
//		t2d_em_u = (Texture2D)Resources.Load("Texture_Panel/Button/em_u");
//		t2d_em_d = (Texture2D)Resources.Load("Texture_Panel/Button/em_d");
		t2d_em_u = (Texture2D)Resources.Load ("DigitalControlPanel/RedButton-1");
		t2d_em_d = (Texture2D)Resources.Load ("DigitalControlPanel/RedButton");
		t2d_Protect = t2d_lock;
//		t2d_Emergency = t2d_em_u;
		t2d_Emergency.normal.background = t2d_em_u;
		
		I_u = (Texture2D)Resources.Load ("DigitalControlPanel/green-1");
		I_d = (Texture2D)Resources.Load ("DigitalControlPanel/green");
		I.normal.background = I_u;
		I.active.background = I_d;
		
		O_u = (Texture2D)Resources.Load ("DigitalControlPanel/yellow-1");
		O_d = (Texture2D)Resources.Load ("DigitalControlPanel/yellow");
		O.normal.background = O_u;
		O.active.background = O_d;
		
//		t2d_ModeSelectEDIT = (Texture2D)Resources.Load("Texture_Panel/Button/mode_edit");
//		t2d_ModeSelectDNC = (Texture2D)Resources.Load("Texture_Panel/Button/mode_dnc");
//		t2d_ModeSelectAUTO = (Texture2D)Resources.Load("Texture_Panel/Button/mode_auto");
//		t2d_ModeSelectMDI = (Texture2D)Resources.Load("Texture_Panel/Button/mode_mdi");
//		t2d_ModeSelectHANDLE = (Texture2D)Resources.Load("Texture_Panel/Button/mode_handle");
//		t2d_ModeSelectJOG = (Texture2D)Resources.Load("Texture_Panel/Button/mode_jog");
//		t2d_ModeSelectREF = (Texture2D)Resources.Load("Texture_Panel/Button/mode_ref");
		t2d_ModeSelectEDIT = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/1");
		t2d_ModeSelectDNC = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/2");
		t2d_ModeSelectAUTO = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/3");
		t2d_ModeSelectMDI = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/4");
		t2d_ModeSelectHANDLE = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/5");
		t2d_ModeSelectJOG = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/6");
		t2d_ModeSelectREF = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/7");
		
		//MDI Input value
		pO_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/4");
		pO_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/4");
		pO.normal.background = pO_u;
		pO.active.background = pO_d;
		sty_pO.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/4");
		
		qN_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/5");
		qN_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/5");
		qN.normal.background = qN_u;
		qN.active.background = qN_d;
		sty_qN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/5");
		
		rG_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/6");
		rG_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/6");
		rG.normal.background = rG_u;
		rG.active.background = rG_d;
		sty_rG.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/6");
		
		a7_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/7");
		a7_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/7");
		a7.normal.background = a7_u;
		a7.active.background = a7_d;
		sty_a7.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/7");
		
		b8_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/8");
		b8_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/8");
		b8.normal.background = b8_u;
		b8.active.background = b8_d;
		sty_b8.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/8");
		
		c9_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/9");
		c9_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/9");
		c9.normal.background = c9_u;
		c9.active.background = c9_d;
		sty_c9.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/9");
		
		uX_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/10");
		uX_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/10");
		uX.normal.background = uX_u;
		uX.active.background = uX_d;
		sty_uX.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/10");
		
		vY_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/11");
		vY_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/11");
		vY.normal.background = vY_u;
		vY.active.background = vY_d;
		sty_vY.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/11");
		
		wZ_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/12");
		wZ_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/12");
		wZ.normal.background = wZ_u;
		wZ.active.background = wZ_d;
		sty_wZ.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/12");
		
		four_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/13");
		four_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/13");
		four.normal.background = four_u;
		four.active.background = four_d;
		sty_four.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/13");
		
		five_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/14");
		five_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/14");
		five.normal.background = five_u;
		five.active.background = five_d;
		sty_five.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/14");
		
		six_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/15");
		six_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/15");
		six.normal.background = six_u;
		six.active.background = six_d;
		sty_six.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/15");
		
		iM_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/16");
		iM_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/16");
		iM.normal.background = iM_u;
		iM.active.background = iM_d;
		sty_iM.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/16");
		
		jS_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/17");
		jS_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/17");
		jS.normal.background = jS_u;
		jS.active.background = jS_d;
		sty_jS.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/17");
		
		kT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/18");
		kT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/18");
		kT.normal.background = kT_u;
		kT.active.background = kT_d;
		sty_kT.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/18");
		
		one_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/19");
		one_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/19");
		one.normal.background = one_u;
		one.active.background = one_d;
		sty_one.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/19");
		
		two_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/20");
		two_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/20");
		two.normal.background = two_u;
		two.active.background = two_d;
		sty_two.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/20");
		
		three_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/21");
		three_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/21");
		three.normal.background = three_u;
		three.active.background = three_d;
		sty_three.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/21");
		
		lF_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/22");
		lF_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/22");
		lF.normal.background = lF_u;
		lF.active.background = lF_d;
		sty_lF.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/22");
		
		dH_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/23");
		dH_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/23");
		dH.normal.background = dH_u;
		dH.active.background = dH_d;
		sty_dH.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/23");
		
		eEOB_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/24");
		eEOB_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/24");
		eEOB.normal.background = eEOB_u;
		eEOB.active.background = eEOB_d;
		sty_eEOB.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/24");
		
		ap_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/25");
		ap_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/25");
		ap.normal.background = ap_u;
		ap.active.background = ap_d;
		sty_ap.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/25");
		
		zero_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/26");
		zero_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/26");
		zero.normal.background = zero_u;
		zero.active.background = zero_d;
		sty_zero.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/26");
		
		po_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/27");
		po_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/27");
		po.normal.background = po_u;
		po.active.background = po_d;
		sty_po.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/27");
		
		sh_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/31");
		sh_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/31");
		sh.normal.background = sh_u;
		sh.active.background = sh_d;
		sty_sh.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/31");
		
		//MDI Input  value end
		
		//MDI Function value start
		POS_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/28");
		POS_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/28");
		POS.normal.background = POS_u;
		POS.active.background = POS_d;
		sty_Pos.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/28");
		
		PROG_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/29");
		PROG_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/29");
		PROG.normal.background = PROG_u;
		PROG.active.background = PROG_d;
		sty_PROG.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/29");
		
		SET_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/30");
		SET_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/30");
		SET.normal.background = SET_u;
		SET.active.background = SET_d;
		sty_SET.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/30");
		
		INPUT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/33");
		INPUT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/33");
		INPUT.normal.background = INPUT_u;
		INPUT.active.background = INPUT_d;
		sty_INPUT.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/33");
		
		SYSTEM_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/34");
		SYSTEM_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/34");
		SYSTEM.normal.background = SYSTEM_u;
		SYSTEM.active.background = SYSTEM_d;
		sty_SYSTEM.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/34");
		
		MESSAGE_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/35");
		MESSAGE_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/35");
		MESSAGE.normal.background = MESSAGE_u;
		MESSAGE.active.background = MESSAGE_d;
		sty_MESSAGE.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/35");
		
		ORPH_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/36");
		ORPH_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/36");
		ORPH.normal.background = ORPH_u;
		ORPH.active.background = ORPH_d;
		sty_GRPH.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/36");
		
		HELP_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/46");
		HELP_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/46");
		HELP.normal.background = HELP_u;
		HELP.active.background = HELP_d;
		sty_HELP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/46");
		
		RESET_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/47");
		RESET_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/47");
		RESET.normal.background = RESET_u;
		RESET.active.background = RESET_d;
		sty_RESET.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/47");
		//MDI Function value end
		
		//MDI Edit value start
		CAN_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/32");
		CAN_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/32");
		CAN.normal.background = CAN_u;
		CAN.active.background = CAN_d;
		sty_CAN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/32");
		
		ALTER_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/37");
		ALTER_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/37");
		ALTER.normal.background = ALTER_u;
		ALTER.active.background = ALTER_d;
		sty_ALTER.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/37");
		
		INSERT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/38");
		INSERT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/38");
		INSERT.normal.background = INSERT_u;
		INSERT.active.background = INSERT_d;
		sty_INSERT.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/38");
		
		DELETE_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/39");
		DELETE_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/39");
		DELETE.normal.background = DELETE_u;
		DELETE.active.background = DELETE_d;
		sty_DELETE.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/39");
		
		PAGEu_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/40");
		PAGEu_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/40");
		PAGEu.normal.background = PAGEu_u;
		PAGEu.active.background = PAGEu_d;
		sty_PAGEu.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/40");
		
		PAGEd_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/41");
		PAGEd_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/41");
		PAGEd.normal.background = PAGEd_u;
		PAGEd.active.background = PAGEd_d;
		sty_PAGEd.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/3/41");
		
		LEFT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/42");
		LEFT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/42");
		LEFT.normal.background = LEFT_u;
		LEFT.active.background = LEFT_d;
		
		UP_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/43");
		UP_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/43");
		UP.normal.background = UP_u;
		UP.active.background = UP_d;
		
		DOWN_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/44");
		DOWN_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/44");
		DOWN.normal.background = DOWN_u;
		DOWN.active.background = DOWN_d;
		
		RIGHT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/45");
		RIGHT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/45");
		RIGHT.normal.background = RIGHT_u;
		RIGHT.active.background = RIGHT_d;
		//MDI Edit value end
		
		//Softkey value start
		Soft_LEFT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/2");
		Soft_LEFT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/2");
		Soft_LEFT.normal.background = LEFT_u;
		Soft_LEFT.active.background = LEFT_d;
		
		Soft_EMPTY_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/1");
		Soft_EMPTY_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/1");
		Soft_EMPTY.normal.background = Soft_EMPTY_u;
		Soft_EMPTY.active.background = Soft_EMPTY_d;
		
		Soft_RIGHT_u = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/1/3");
		Soft_RIGHT_d = (Texture2D)Resources.Load ("DigitalControlPanel/UpPanel/2/3");
		Soft_RIGHT.normal.background = RIGHT_u;
		Soft_RIGHT.active.background = RIGHT_d;
		//Softkey value end
		
		//Auxiliary Function value start
		COOL_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/8");
		COOL_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/8");
		COOL_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/8");
		COOL_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/8");
		COOL.normal.background = COOL_off_u;
		COOL.active.background = COOL_off_d;
		sty_COOL.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/8");
		sty_COOL_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/8");
		sty_COOL_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/8");
		
		Empty1_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/7");
		Empty1_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/7");
		Empty1_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/7");
		Empty1_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/7");
		Empty1.normal.background = Empty1_off_u;
		Empty1.active.background = Empty1_on_d;
		
		MHS_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/11");
		MHS_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/11");
		MHS_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/11");
		MHS_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/11");
		MHS.normal.background = MHS_off_u;
		MHS.active.background = MHS_off_d;
		sty_MHS.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/11");
		sty_MHS_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/11");
		sty_MHS_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/11");
		
		ATCW_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/9");
		ATCW_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/9");
		ATCW_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/9");
		ATCW_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/9");
		ATCW.normal.background = ATCW_off_u;
		ATCW.active.background = ATCW_on_d;
		sty_ATCW.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/9");
		sty_ATCW_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/9");
		sty_ATCW_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/9");
		
		ATCCW_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/10");
		ATCCW_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/10");
		ATCCW_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/10");
		ATCCW_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/10");
		ATCCW.normal.background = ATCCW_off_u;
		ATCCW.active.background = ATCCW_on_d;
		sty_ATCCW.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/10");
		sty_ATCCW_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/10");
		sty_ATCCW_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/10");
		
		MHRN_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/12");
		MHRN_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/12");
		MHRN_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/12");
		MHRN_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/12");
		MHRN.normal.background = MHRN_off_u;
		MHRN.active.background = MHRN_on_d;
		sty_MHRN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/12");
		sty_MHRN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/12");
		sty_MHRN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/12");
		
		FOR_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/13");
		FOR_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/13");
		FOR_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/13");
		FOR_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/13");
		FOR.normal.background = FOR_off_u;
		FOR.active.background = FOR_on_d;
		sty_FOR.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/13");
		sty_FOR_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/13");
		sty_FOR_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/13");
		
		BACK_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/14");
		BACK_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/14");
		BACK_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/14");
		BACK_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/14");
		BACK.normal.background = BACK_off_u;
		BACK.active.background = BACK_on_d;
		sty_BACK.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/14");
		sty_BACK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/14");
		sty_BACK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/14");
		
		Empty2_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/7");
		Empty2_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/7");
		Empty2_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/7");
		Empty2_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/7");
		Empty2.normal.background = Empty2_off_u;
		Empty2.active.background = Empty2_on_d;
		//Auxiliary Function value end
		
		//Machine Function value start
		MLK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/1");
		MLK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/1");
		MLK_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/1");
		MLK_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/1");
		MLK.normal.background = MLK_u;
		MLK.active.background = MLK_d;
		sty_MLK.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/1");
		sty_MLK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/1");
		sty_MLK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/1");
		
		DRN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/2");
		DRN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/2");
		DRN_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/2");
		DRN_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/2");
		DRN.normal.background = DRN_u;
		DRN.active.background = DRN_d;
		sty_DRN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/2");
		sty_DRN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/2");
		sty_DRN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/2");
		
		BDT_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/3");
		BDT_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/3");
		BDT_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/3");
		BDT_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/3");
		BDT.normal.background = BDT_u;
		BDT.active.background = BDT_d;
		sty_BDT.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/3");
		sty_BDT_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/3");
		sty_BDT_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/3");
		
		SBK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/4");
		SBK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/4");
		SBK_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/4");
		SBK_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/4");
		SBK.normal.background = SBK_u;
		SBK.active.background = SBK_d;
		sty_SBK.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/4");
		sty_SBK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/4");
		sty_SBK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/4");
		
		OSP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/5");
		OSP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/5");
		OSP_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/5");
		OSP_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/5");
		OSP.normal.background = OSP_u;
		OSP.active.background = OSP_d;
		sty_OSP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/5");
		sty_OSP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/5");
		sty_OSP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/5");
		
		ZLOCK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/6");
		ZLOCK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/6");
		ZLOCK_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/6");
		ZLOCK_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/6");
		ZLOCK.normal.background = ZLOCK_u;
		ZLOCK.active.background = ZLOCK_d;
		sty_ZLOCK.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/6");
		sty_ZLOCK_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/6");
		sty_ZLOCK_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/6");
		
		MachineEMPTY_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/7");
		MachineEMPTY_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/7");
		MachineEMPTY_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/7");
		MachineEMPTY_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/7");
		MachineEMPTY.normal.background = MachineEMPTY_u;
		MachineEMPTY.active.background = MachineEMPTY_d;
		
		MachineEMPTY2.normal.background = MachineEMPTY_u;
		MachineEMPTY2.active.background = MachineEMPTY_d;
		//Machine Function value end
		
		//knob enlarge value
		t2d_EDIT = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/11");
		t2d_DNC = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/22");
		t2d_AUTO = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/33");
		t2d_MDI = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/44");
		t2d_MPG = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/55");
		t2d_JOG = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/66");
		t2d_ZERO = (Texture2D)Resources.Load ("DigitalControlPanel/konb/1/77");
		t2d_Feedrate0 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_0");
		t2d_Feedrate10 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_10");
		t2d_Feedrate20 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_20");
		t2d_Feedrate30 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_30");
		t2d_Feedrate40 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_40");
		t2d_Feedrate50 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_50");
		t2d_Feedrate60 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_60");
		t2d_Feedrate70 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_70");
		t2d_Feedrate80 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_80");
		t2d_Feedrate90 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_90");
		t2d_Feedrate100 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_100");
		t2d_Feedrate110 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_110");
		t2d_Feedrate120 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_120");
		t2d_Feedrate130 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_130");
		t2d_Feedrate140 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_140");
		t2d_Feedrate150 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/s_150");
		sty_enlargeknob.normal.background = t2d_EDIT;
		//end
		
		//Hand Wheel start
		HandWheel_backgraound.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/0");
		left_1 = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/2");
		left_2 = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/3");
		mid = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/1");
		right_1 = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/4");
		right_2 = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/5");
		plane = (Texture2D)Resources.Load ("DigitalControlPanel/HandWheel/6");
		left_num = left_2;
		right_num = left_1;
		
		//end
		
//		if (PlayerPrefs.HasKey ("ModeSelect"))
//			mode_type = PlayerPrefs.GetInt ("ModeSelect");
//		else {
//			PlayerPrefs.SetInt ("ModeSelect", 1);
//			mode_type = 1;
//		}
//		switch (mode_type) {
//		case 1:
//			t2d_ModeSelect = t2d_ModeSelectEDIT;
//			MenuDisplay = "编辑";
//			ProgEDIT = true;
//			ProgDNC = false;
//			ProgAUTO = false;
//			ProgMDI = false;
//			ProgHAN = false;
//			ProgJOG = false;
//			ProgREF = false;
//			editDisplay = true;
//			break;
//		case 2:
//			t2d_ModeSelect = t2d_ModeSelectDNC;
//			MenuDisplay = "DNC";
//			ProgEDIT = false;
//			ProgDNC = true;
//			ProgAUTO = false;
//			ProgMDI = false;
//			ProgHAN = false;
//			ProgJOG = false;
//			ProgREF = false;
//			break;
//		case 3:
//			t2d_ModeSelect = t2d_ModeSelectAUTO;
//			MenuDisplay = "MEM";
//			ProgEDIT = false;
//			ProgDNC = false;
//			ProgAUTO = true;
//			ProgMDI = false;
//			ProgHAN = false;
//			ProgJOG = false;
//			ProgREF = false;
//			break;
//		case 4:
//			t2d_ModeSelect = t2d_ModeSelectMDI;
//			MenuDisplay = "MDI";
//			ProgEDIT = false;
//			ProgDNC = false;
//			ProgAUTO = false;
//			ProgMDI = true;
//			ProgHAN = false;
//			ProgJOG = false;
//			ProgREF = false;
//			editDisplay = false;
//			CodeForAll.Add ("O0000");
//			CodeForAll.Add (";");
//			MDIpos_flag = true;
//			break;
//		case 5:
//			t2d_ModeSelect = t2d_ModeSelectHANDLE;
//			MenuDisplay = "HAN";
//			ProgEDIT = false;
//			ProgDNC = false;
//			ProgAUTO = false;
//			ProgMDI = false;
//			ProgHAN = true;
//			ProgJOG = false;
//			ProgREF = false;
//			break;
//		case 6:
//			t2d_ModeSelect = t2d_ModeSelectJOG;
//			MenuDisplay = "JOG";
//			speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
//			ProgEDIT = false;
//			ProgDNC = false;
//			ProgAUTO = false;
//			ProgMDI = false;
//			ProgHAN = false;
//			ProgJOG = true;
//			ProgREF = false;
//			break;
//		case 7:
//			t2d_ModeSelect = t2d_ModeSelectREF;
//			MenuDisplay = "REF";
//			speed_to_move = 0.16667F;//内容--归零操作的实际速度为10m/min=(10/60)m/s，而实际速度RunningSpeed=speed—to-move*move-rate，因此speed-to-move应设为5/60,姓名--刘旋，时间--2013-4-8
//			ProgEDIT = false;
//			ProgDNC = false;
//			ProgAUTO = false;
//			ProgMDI = false;
//			ProgHAN = false;
//			ProgJOG = false;
//			ProgREF = true;
//			break;	
//		}

		t2d_FeedRate_0 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/1");
		t2d_FeedRate_10 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/2");
		t2d_FeedRate_20 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/3");
		t2d_FeedRate_30 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/4");
		t2d_FeedRate_40 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/5");
		t2d_FeedRate_50 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/6");
		t2d_FeedRate_60 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/7");
		t2d_FeedRate_70 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/8");
		t2d_FeedRate_80 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/9");
		t2d_FeedRate_90 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/10");
		t2d_FeedRate_100 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/11");
		t2d_FeedRate_110 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/12");
		t2d_FeedRate_120 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/13");
		t2d_FeedRate_130 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/14");
		t2d_FeedRate_140 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/15");
		t2d_FeedRate_150 = (Texture2D)Resources.Load ("DigitalControlPanel/konb/2/16");
//		if (PlayerPrefs.HasKey ("FeedrateSelect"))
//			feedrate_type = PlayerPrefs.GetInt ("FeedrateSelect");
//		else {
//			PlayerPrefs.SetInt ("FeedrateSelect", 11);
//			feedrate_type = 11;
//		}
//		switch (feedrate_type) {
//		case 1:
//			t2d_feedrate = t2d_FeedRate_0;
//			move_rate = 0f;
//			break;
//		case 2:
//			t2d_feedrate = t2d_FeedRate_10;
//			move_rate = 0.1f;
//			break;
//		case 3:
//			t2d_feedrate = t2d_FeedRate_20;
//			move_rate = 0.2f;
//			break;
//		case 4:
//			t2d_feedrate = t2d_FeedRate_30;
//			move_rate = 0.3f;
//			break;
//		case 5:
//			t2d_feedrate = t2d_FeedRate_40;
//			move_rate = 0.4f;
//			break;
//		case 6:
//			t2d_feedrate = t2d_FeedRate_50;
//			move_rate = 0.5f;
//			break;
//		case 7:
//			t2d_feedrate = t2d_FeedRate_60;
//			move_rate = 0.6f;
//			break;
//		case 8:
//			t2d_feedrate = t2d_FeedRate_70;
//			move_rate = 0.7f;
//			break;
//		case 9:
//			t2d_feedrate = t2d_FeedRate_80;
//			move_rate = 0.8f;
//			break;
//		case 10:
//			t2d_feedrate = t2d_FeedRate_90;
//			move_rate = 0.9f;
//			break;
//		case 11:
//			t2d_feedrate = t2d_FeedRate_100;
//			move_rate = 1.0f;
//			break;
//		case 12:
//			t2d_feedrate = t2d_FeedRate_110;
//			move_rate = 1.1f;
//			break;
//		case 13:
//			t2d_feedrate = t2d_FeedRate_120;
//			move_rate = 1.2f;
//			break;
//		case 14:
//			t2d_feedrate = t2d_FeedRate_130;
//			move_rate = 1.3f;
//			break;
//		case 15:
//			t2d_feedrate = t2d_FeedRate_140;
//			move_rate = 1.4f;
//			break;
//		case 16:
//			t2d_feedrate = t2d_FeedRate_150;
//			move_rate = 1.5f;
//			break;
//		}
//		move_rate_pad = move_rate;
		
		t2d_NCPower_on_u = (Texture2D)Resources.Load ("Texture_Panel/Button/NCPower_on_u");
		t2d_NCPower_on_d = (Texture2D)Resources.Load ("Texture_Panel/Button/NCPower_on_d");
		t2d_NCPower_off_u = (Texture2D)Resources.Load ("Texture_Panel/Button/NCPower_off_u");
		t2d_NCPower_off_d = (Texture2D)Resources.Load ("Texture_Panel/Button/NCPower_off_d");
		sty_NCPowerOn.normal.background = t2d_NCPower_on_u;
		sty_NCPowerOn.active.background = t2d_NCPower_on_d;
		sty_NCPowerOff.normal.background = t2d_NCPower_off_u;
		sty_NCPowerOff.active.background = t2d_NCPower_off_d;

		t2d_spCW_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/32");
		t2d_spCW_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/32");
		t2d_spCW_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/32");
		t2d_spCW_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/32");
		sty_ButtonCW.normal.background = t2d_spCW_off_u;
		sty_ButtonCW.active.background = t2d_spCW_off_d;
		sty_SCW.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/32");
		sty_SCW_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/32");
		sty_SCW_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/32");

		t2d_spCCW_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/34");
		t2d_spCCW_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/34");
		t2d_spCCW_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/34");
		t2d_spCCW_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/34");
		sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
		sty_ButtonCCW.active.background = t2d_spCCW_off_d;
		sty_SCCW.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/34");
		sty_SCCW_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/34");
		sty_SCCW_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/34");

		t2d_spStop_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/33");
		t2d_spStop_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/33");
		t2d_spStop_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/33");
		t2d_spStop_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/33");
		sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
		sty_ButtonSTOP.active.background = t2d_spStop_off_d;
		sty_SSTOP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/33"); 
		sty_SSTOP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/33"); 
		sty_SSTOP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/33"); 

		t2d_rapid_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/19");
		t2d_rapid_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/19");
		t2d_rapid_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/19");
		t2d_rapid_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/19");
		sty_ButtonRapid.normal.background = t2d_rapid_off_u;
		sty_ButtonRapid.active.background = t2d_rapid_off_d;
		sty_SRAPID.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/19");
		sty_SRAPID_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/19");
		sty_SRAPID_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/19");
		
		//内容--为变量赋值，用于实现JOG模式下F0，25%、50%、100%四个按钮的显示
		t2d_f0_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/24");
		t2d_f0_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/24");
		t2d_f0_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/24");
		t2d_f0_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/24");
		sty_ButtonF0.normal.background = t2d_f0_off_u;
		sty_ButtonF0.active.background = t2d_f0_off_d;
		sty_SF0.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/24");
		sty_SF0_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/24");
		sty_SF0_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/24");
		
		t2d_f25_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/25");
		t2d_f25_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/25");
		t2d_f25_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/25");
		t2d_f25_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/25");
		sty_ButtonF25.normal.background = t2d_f25_off_u;
		sty_ButtonF25.active.background = t2d_f25_off_d;
		sty_SF25.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/25");
		sty_SF25_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/25");
		sty_SF25_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/25");

		t2d_f50_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/26");
		t2d_f50_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/26");
		t2d_f50_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/26");
		t2d_f50_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/26");
		sty_ButtonF50.normal.background = t2d_f50_off_u;
		sty_ButtonF50.active.background = t2d_f50_off_d;
		sty_SF50.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/26");
		sty_SF50_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/26");
		sty_SF50_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/26");

		t2d_f100_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/27");
		t2d_f100_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/27");
		t2d_f100_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/27");
		t2d_f100_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/27");
		sty_ButtonF100.normal.background = t2d_f100_off_u;
		sty_ButtonF100.active.background = t2d_f100_off_d;//增加内容到此  2013-4-8
		sty_SF100.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/27");
		sty_SF100_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/27");
		sty_SF100_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/27");
		
		EMPTY_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/7");
		EMPTY_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/7");
		EMPTY_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/7");
		EMPTY_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/7");
		EMPTY.normal.background = EMPTY_off_u;
		EMPTY.active.background = EMPTY_off_d;
		
		DOWN_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/28");
		DOWN_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/28");
		DOWN_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/28");
		DOWN_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/28");
		Axis_DOWN.normal.background = DOWN_off_u;
		Axis_DOWN.active.background = DOWN_on_d;
		sty_SDOWN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/28");
		sty_SDOWN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/28");
		sty_SDOWN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/28");
		
		HUNDRED_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/29");
		HUNDRED_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/29");
		HUNDRED_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/29");
		HUNDRED_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/29");
		HUNDRED.normal.background = HUNDRED_off_u;
		HUNDRED.active.background = HUNDRED_off_d;
		sty_SHUNDRED.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/29");
		sty_SHUNDRED_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/29");
		sty_SHUNDRED_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/29");
		
		UP_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/30");
		UP_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/30");
		UP_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/30");
		UP_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/30");
		Axis_UP.normal.background = UP_off_u;
		Axis_UP.active.background = UP_on_d;
		sty_SUP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/30");
		sty_SUP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/30");
		sty_SUP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/30");
		
		ORIENT_on_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/1/31");
		ORIENT_on_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/31");
		ORIENT_off_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/31");
		ORIENT_off_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/4/31");
		ORIENT.normal.background = ORIENT_off_u;
		ORIENT.active.background = ORIENT_off_d;
		sty_SORIENT.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/31");
		sty_SORIENT_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/31");
		sty_SORIENT_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/6/31");
		
		//修改 BY:WH
		sty_ButtonYN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/16");
		sty_ButtonYN.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/16");
		t2d_ButtonYN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/16");
		t2d_ButtonYN = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/16");
		sty_SYN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/16");
		sty_SYN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/16");
		sty_SYN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/16");
		
		sty_ButtonYP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/22");
		sty_ButtonYP.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/22");
		t2d_ButtonYP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/22");
		t2d_ButtonYP = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/22");
		sty_SYP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/22");
		sty_SYP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/22");
		sty_SYP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/22");

		sty_ButtonZP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/17");
		sty_ButtonZP.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/17");
		t2d_ButtonZP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/17");
		t2d_ButtonZP = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/17");
		sty_SZP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/17");
		sty_SZP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/17");
		sty_SZP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/17");

		sty_ButtonZN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/23");
		sty_ButtonZN.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/23");
		t2d_ButtonZN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/23");
		t2d_ButtonZN = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/23");
		sty_SZN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/23");
		sty_SZN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/23");
		sty_SZN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/23");

		sty_ButtonXP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/18");
		sty_ButtonXP.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/18");
		t2d_ButtonXP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/18");
		t2d_ButtonXP = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/18");
		sty_SXP.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/18");
		sty_SXP_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/18");
		sty_SXP_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/18");

		sty_ButtonXN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/20");
		sty_ButtonXN.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/20");
		t2d_ButtonXN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/20");
		t2d_ButtonXN = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/20");
		sty_SXN.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/20");
		sty_SXN_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/20");
		sty_SXN_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/20");

		sty_Button4P.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/15");
		sty_Button4P.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/15");
		sty_S4P.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/15");
		sty_S4P_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/15");
		sty_S4P_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/15");

		sty_Button4N.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/2/21");
		sty_Button4N.active.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/3/21");
		sty_S4N.normal.background = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/21");
		sty_S4N_u = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/5/21");
		sty_S4N_d = (Texture2D)Resources.Load ("DigitalControlPanel/DownPanel/7/21");
		
		sty_ProgEDITWindowO.font = (Font)Resources.Load ("font/STZHONGS");
		sty_ProgEDITWindowO.fontSize = 16;
		sty_ProgEDITWindowO.normal.textColor = Color.white;
		
		sty_Title.font = (Font)Resources.Load ("font/STZHONGS");
		sty_Title.fontSize = 18;
//		sty_Title.fontStyle = FontStyle.Bold;
		
		sty_TitleLetter.font = (Font)Resources.Load ("font/STSONG");
		sty_TitleLetter.fontSize = 17;
		
		sty_BigXYZ.font = (Font)Resources.Load ("font/LCD");
		sty_BigXYZ.fontSize = 45;
		
		sty_SmallNum.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_SmallNum.fontSize = 14;
		
		sty_ProgramName.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_ProgramName.fontSize = 15;
		
		sty_ProgModeName.font = (Font)Resources.Load ("font/STZHONGS");
		sty_ProgModeName.fontSize = 14;
		
		sty_Star.fontSize = 22;
		
		sty_AlarmLetter.font = (Font)Resources.Load ("font/STZHONGS");
		sty_AlarmLetter.fontSize = 14;
		sty_AlarmLetter.normal.textColor = Color.white;
		
//		sty_Alarm.font = (Font)Resources.Load ("font/times");
//		sty_Alarm.fontSize = 12;
		sty_Alarm.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/red");
		sty_Alarm.normal.textColor = Color.white;
		
//		sty_BottomChooseMenu.font = (Font)Resources.Load("font/monoMMM_5");
		sty_BottomChooseMenu.font = (Font)Resources.Load ("font/STZHONGS");
		sty_BottomChooseMenu.fontSize = 16;
//		sty_BottomChooseMenu.fontStyle = FontStyle.Bold;
		
		sty_ProgEditProgNum.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_ProgEditProgNum.fontSize = 15;
		sty_ProgEditProgNum.normal.textColor = Color.white;
		
//		sty_PosSmallWord.font = (Font)Resources.Load("font/simfang");
		sty_PosSmallWord.font = (Font)Resources.Load ("font/STZHONGS");
		sty_PosSmallWord.fontSize = 15;
		
		sty_SmallXYZ.font = (Font)Resources.Load ("font/times");
		sty_SmallXYZ.fontSize = 17;
		
		sty_ScreenCover.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/StartScreen");
		
		sty_ProgEDITWindowFG.font = (Font)Resources.Load ("font/STZHONGS");
		sty_ProgEDITWindowFG.fontSize = 15;
		sty_ProgEDITWindowFG.normal.textColor = Color.white;
		
		sty_BottomAST.font = (Font)Resources.Load ("font/times");
		sty_BottomAST.fontSize = 15;
		//sty_BottomAST.normal.textColor = Color.cyan;
		
//		sty_MostWords.font = (Font)Resources.Load("font/simfang");
		sty_MostWords.font = (Font)Resources.Load ("font/STZHONGS");
		sty_MostWords.fontSize = 15;
		sty_MostWords.normal.textColor = new Color (0f, 0.31f, 0.321f, 1.0f);
		//sty_MostWords.normal.textColor = Color.cyan;
		
		sty_Code.font = (Font)Resources.Load("font/times");
		sty_Code.fontSize = 17;
		sty_Code.fontStyle = FontStyle.Bold;
		
		sty_ModeCode.fontSize = 15;
		sty_ModeCode.fontStyle = FontStyle.Bold;
		
		//内容--sty-Mode赋值为蓝色
		//姓名--刘旋，时间--2013-3-29
		sty_Mode.fontSize = 15;
		sty_Mode.fontStyle = FontStyle.Bold;
//		sty_Mode.normal.textColor=Color.blue;
//		Color mode1 = new Color(37.0f, 125.0f, 146.0f, 255.0f);
		sty_Mode.normal.textColor = new Color (0.145f, 0.49f, 0.573f, 1.0f);
//		sty_Mode.normal.textColor = Color(37, 125, 0, 100);
		
		sty_ProgEDITListWindowNum.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_ProgEDITListWindowNum.fontSize = 13;
		
		sty_Cursor.font = (Font)Resources.Load ("font/times");
		sty_Cursor.fontSize = 15;
		
		sty_Warning.font = (Font)Resources.Load ("font/STZHONGS");
		sty_Warning.fontSize = 13;
		sty_Warning.normal.textColor = Color.red;
		
		sty_ScreenBackGround.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ScreenBackground");
		
		sty_TopLabel.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/toplabel");
		
		sty_MessAlarm.font = (Font)Resources.Load ("font/STZHONGS");
		sty_MessAlarm.normal.textColor = Color.red;
		sty_MessAlarm.fontSize = 13;
		
		sty_MessRecordID.font = (Font)Resources.Load ("font/simfang");
		sty_MessRecordID.normal.textColor = Color.blue;
		sty_MessRecordID.fontSize = 13;
		
		sty_MessRecordTime.font = (Font)Resources.Load ("font/simfang");
		sty_MessRecordTime.fontSize = 14;
		
		sty_MessRecordInfo.font = (Font)Resources.Load ("font/simfang");
		sty_MessRecordInfo.fontSize = 15;
		
		sty_SysID.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_SysID.fontSize = 13;
		
		sty_SysInfo.font = (Font)Resources.Load ("font/simfang");
		sty_SysInfo.fontSize = 15;
		sty_SysInfo.normal.textColor = Color.blue;
		
		t2d_BottomButton_u = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_u");
		t2d_BottomButton_d = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_d");
		
		sty_BottomButtonSmallest.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_smallest");
		sty_BottomButton_1.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_d");
		sty_BottomButton_2.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_u");
		sty_BottomButton_3.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_u");
		sty_BottomButton_4.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_u");
		sty_BottomButton_5.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Button/bottombutton_u");
		
		sty_BottomLabel_1.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/bottomLabel01");
		sty_BottomLabel_2.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/bottomLabel02");
		sty_BottomLabel_3.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/bottomLabel03");
		sty_BottomLabel_4.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/bottomLabel04");
		
		sty_ClockStyle.fontSize = 14;
		
		sty_BlueCursor.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/Blue");
		
		sty_EDITLabel.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EDITLabel");
		sty_EDITLabelWindow.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditWindow");
		sty_EDITLabelBar_1.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditBar01");
		sty_EDITLabelBar_2.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditBar02");
		sty_EDITLabelBar_3.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditBar03");
		sty_ProgSharedWindow.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ProgSharedWindow");
		
		sty_EDITCursor.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditCursor");
		sty_EDITCursor.font = (Font)Resources.Load("font/times");
		sty_EDITCursor.fontSize = 17;
		sty_EDITCursor.fontStyle = FontStyle.Bold;
		sty_EDITTextField.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditCursor");
		sty_EDITTextField.normal.textColor = Color.yellow;
		sty_EDITTextField.font = (Font)Resources.Load("font/times");
		sty_EDITTextField.fontSize = 17;
		sty_EDITTextField.fontStyle = FontStyle.Bold;
		
		sty_EDITList.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditList");
		sty_ListContent.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ListContent");
		sty_ListWindow.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/ListWindow");
		sty_AUTOCheck.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/AUTOCheck");
		
		sty_InputTextField.font = (Font)Resources.Load ("font/times");
		sty_InputTextField.fontSize = 15;
		
		sty_OffSet_Coo.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/offset_coo");
		
		EDITText.enabled = false;
		EDITText.font = sty_Code.font;
		EDITText.fontSize = sty_Code.fontSize;
		//EDITText.fontStyle=FontStyle.Bold;
		EDITText.text = "";
		ProgEDITCusorPos = corner_px + 23.5f;
		CursorText.enabled = false;
		CursorText.font = sty_Cursor.font;
		CursorText.fontSize = sty_Cursor.fontSize;
		
		coo_setting_cursor_x = corner_px + 100f;
		coo_setting_cursor_y = corner_py + 73f;
		coo_setting_1 = 1;
		coo_setting_2 = 1;
		
		sty_SettingsBG.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/SettingsBG");
		
		//设定界面修改---陈振华---03.11
		sty_OffSet_Coo_mini.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/offset_coo_mini");
		sty_OffSet_Coo_mid.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/offset_coo_mid");
		//设定界面修改---陈振华---03.11
		
		sty_EditListTop.normal.background = (Texture2D)Resources.Load ("Texture_Panel/Label/EditListTop");
		OffSetTool = true;
		OffSetSetting = false;
		OffSetCoo = false;
		
		//刀偏界面完善---张振华---03.30
		sty_MostWords_ToolOffSet.font = (Font)Resources.Load ("font/STZHONGS");
		sty_MostWords_ToolOffSet.fontSize = 14;
		sty_MostWords_ToolOffSet.normal.textColor = new Color (0f, 0.31f, 0.321f, 1.0f);
		
		sty_SerialNum.font = (Font)Resources.Load ("font/monoMMM_5");
		sty_SerialNum.fontSize = 14;
		sty_SerialNum.normal.textColor = new Color (0f, 0.31f, 0.321f, 1.0f);
		
		ToolOffSetPage_num = 0;    //页面数
		number = 0;                            //序号
		tool_setting = 1;                     //黄色背景序号
		tool_setting_cursor_y = corner_py + 46.5f;
		tool_setting_cursor_w = corner_px + 56f;
		argu_setting_cursor_y = corner_py + 29.5f;
		//刀偏界面完善---张振华---03.30
		
		//界面参数初始化
//		PartsNum = 0; //加工零件数
		SpindleSpeed = 0; //S主轴转速
		ToolNo = 0; //T刀具号
//		RunningTimeH = 0; //运行时
//		RunningTimeM = 0; //运行分
		CycleTimeH = 0; //循环时间时
		CycleTimeM = 0; //循环时间分
		CycleTimeS = 0; //循环时间秒
		RunningSpeed = 0; //实速度
		SACT = 0; //相当于转速
		ALMBlink = false;
		ALM_Control = false;
//		if (PlayerPrefs.HasKey ("RunningTimeH"))
//			RunningTimeH = PlayerPrefs.GetInt ("RunningTimeH");
//		else {
//			PlayerPrefs.SetInt ("RunningTimeH", 0);
//			RunningTimeH = 0;
//		}
//		if (PlayerPrefs.HasKey ("RunningTimeM"))
//			RunningTimeM = PlayerPrefs.GetInt ("RunningTimeM");
//		else {
//			PlayerPrefs.SetInt ("RunningTimeM", 0);
//			RunningTimeM = 0;
//		}
//		if (PlayerPrefs.HasKey ("PartsNum"))
//			PartsNum = PlayerPrefs.GetInt ("PartsNum");
//		else {
//			PlayerPrefs.SetInt ("PartsNum", 0);
//			PartsNum = 0;
//		}
		
	}
	
	[RPC]
	void AwakeArgumentsInitializeRPC (string argument_string)
	{
		string[] argument_str_array = argument_string.Split (',');
		//ShowOffButton 0
		if (argument_str_array [0] == "true")
			show_off_button_on = true;
		else
			show_off_button_on = false;	
		if (show_off_button_on)
			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_On;
		else
			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_Off;
		//OriginalPathButton 1
		if (argument_str_array [1] == "true")
			originalPathDisplay = true;
		else
			originalPathDisplay = false;
		if (originalPathDisplay)
			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_On;
		else
			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_Off;
		//PracticalPathButton 2
		if (argument_str_array [2] == "true")
			pathLineDisplay = true;
		else
			pathLineDisplay = false;
		if (pathLineDisplay)
			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_On;
		else
			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_Off;
		//SetupGuideButton 3
		if (argument_str_array [3] == "true")
			SetupGuide_on = true;
		else
			SetupGuide_on = false;
		if (SetupGuide_on) {
			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_On;
			panelWindowOnly = false;
		} else {
			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_Off;
			panelWindowOnly = true;
		}
		//ModeSelect 4
		mode_type = int.Parse (argument_str_array [4]);
		switch (mode_type) {
		case 1:
			t2d_ModeSelect = t2d_ModeSelectEDIT;
			MenuDisplay = "编辑";
			ProgEDIT = true;
			ProgDNC = false;
			ProgAUTO = false;
			ProgMDI = false;
			ProgHAN = false;
			ProgJOG = false;
			ProgREF = false;
			editDisplay = true;
			break;
		case 2:
			t2d_ModeSelect = t2d_ModeSelectDNC;
			MenuDisplay = "DNC";
			ProgEDIT = false;
			ProgDNC = true;
			ProgAUTO = false;
			ProgMDI = false;
			ProgHAN = false;
			ProgJOG = false;
			ProgREF = false;
			break;
		case 3:
			t2d_ModeSelect = t2d_ModeSelectAUTO;
			MenuDisplay = "MEM";
			ProgEDIT = false;
			ProgDNC = false;
			ProgAUTO = true;
			ProgMDI = false;
			ProgHAN = false;
			ProgJOG = false;
			ProgREF = false;
			break;
		case 4:
			t2d_ModeSelect = t2d_ModeSelectMDI;
			MenuDisplay = "MDI";
			ProgEDIT = false;
			ProgDNC = false;
			ProgAUTO = false;
			ProgMDI = true;
			ProgHAN = false;
			ProgJOG = false;
			ProgREF = false;
			editDisplay = false;
			CodeForAll.Add ("O0000");
			CodeForAll.Add (";");
			MDIpos_flag = true;
			break;
		case 5:
			t2d_ModeSelect = t2d_ModeSelectHANDLE;
			MenuDisplay = "HAN";
			ProgEDIT = false;
			ProgDNC = false;
			ProgAUTO = false;
			ProgMDI = false;
			ProgHAN = true;
			ProgJOG = false;
			ProgREF = false;
			if(!SetupGuide_on)
			{
				StartCoroutine(HandWheel_Script.showWheel());
			}
			break;
		case 6:
			t2d_ModeSelect = t2d_ModeSelectJOG;
			MenuDisplay = "JOG";
			speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
			ProgEDIT = false;
			ProgDNC = false;
			ProgAUTO = false;
			ProgMDI = false;
			ProgHAN = false;
			ProgJOG = true;
			ProgREF = false;
			break;
		case 7:
			t2d_ModeSelect = t2d_ModeSelectREF;
			MenuDisplay = "REF";
			speed_to_move = 0.16667F;//内容--归零操作的实际速度为10m/min=(10/60)m/s，而实际速度RunningSpeed=speed—to-move*move-rate，因此speed-to-move应设为5/60,姓名--刘旋，时间--2013-4-8
			ProgEDIT = false;
			ProgDNC = false;
			ProgAUTO = false;
			ProgMDI = false;
			ProgHAN = false;
			ProgJOG = false;
			ProgREF = true;
			break;	
		}
		//FeedrateSelect 5
		feedrate_type = int.Parse (argument_str_array [5]);
		switch (feedrate_type) {
		case 1:
			t2d_feedrate = t2d_FeedRate_0;
			move_rate = 0f;
			break;
		case 2:
			t2d_feedrate = t2d_FeedRate_10;
			move_rate = 0.1f;
			break;
		case 3:
			t2d_feedrate = t2d_FeedRate_20;
			move_rate = 0.2f;
			break;
		case 4:
			t2d_feedrate = t2d_FeedRate_30;
			move_rate = 0.3f;
			break;
		case 5:
			t2d_feedrate = t2d_FeedRate_40;
			move_rate = 0.4f;
			break;
		case 6:
			t2d_feedrate = t2d_FeedRate_50;
			move_rate = 0.5f;
			break;
		case 7:
			t2d_feedrate = t2d_FeedRate_60;
			move_rate = 0.6f;
			break;
		case 8:
			t2d_feedrate = t2d_FeedRate_70;
			move_rate = 0.7f;
			break;
		case 9:
			t2d_feedrate = t2d_FeedRate_80;
			move_rate = 0.8f;
			break;
		case 10:
			t2d_feedrate = t2d_FeedRate_90;
			move_rate = 0.9f;
			break;
		case 11:
			t2d_feedrate = t2d_FeedRate_100;
			move_rate = 1.0f;
			break;
		case 12:
			t2d_feedrate = t2d_FeedRate_110;
			move_rate = 1.1f;
			break;
		case 13:
			t2d_feedrate = t2d_FeedRate_120;
			move_rate = 1.2f;
			break;
		case 14:
			t2d_feedrate = t2d_FeedRate_130;
			move_rate = 1.3f;
			break;
		case 15:
			t2d_feedrate = t2d_FeedRate_140;
			move_rate = 1.4f;
			break;
		case 16:
			t2d_feedrate = t2d_FeedRate_150;
			move_rate = 1.5f;
			break;
		}
		move_rate_pad = move_rate;
		
		//RunningTimeH 6
		RunningTimeH = int.Parse (argument_str_array [6]);
		//RunningTimeM 7
		RunningTimeM = int.Parse (argument_str_array [7]);
		//PartsNum 8
		PartsNum = int.Parse (argument_str_array [8]);
		//F0、F25、F50、F100选择 9
		RapidSpeedMode = int.Parse(argument_str_array [9]);
		//刀具号  10
		ToolNo = int.Parse(argument_str_array [10]);
		LightNumber_Script.SetNumber(ToolNo);
		if(argument_str_array[11] == "True")
			ScreenPower = true;
		else
			ScreenPower = false;
	}
	
	[RPC]
	void ScreenStateRPC(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			PosMenu = true;
		else
			PosMenu = false;
		if(info_array[1] == "True")
			ProgMenu = true;
		else
			ProgMenu = false;
		if(info_array[2] == "True")
			SettingMenu = true;
		else
			SettingMenu = false;
		if(info_array[3] == "True")
			MessageMenu = true;
		else
			MessageMenu = false;
		if(info_array[4] == "True")
			SystemMenu = true;
		else
			SystemMenu = false;
		InputText = info_array[5];
		CursorText.text = InputText;
		InputTextSize = sty_InputTextField.CalcSize(new GUIContent(CursorText.text));
		ProgEDITCusorPos = corner_px + 23.5f + InputTextSize.x;
		TempInputText = info_array[6];
		OffSetTemp = info_array[7];
		SystemSettings_VSlider_State = int.Parse(info_array[8]);
		switch(SystemSettings_VSlider_State)
		{
		case 1:
			sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider1;
			break;
		case 2:
			sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider10;
			break;
		case 3:
			sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider100;
			break;
		case 4:
			sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider1000;
			break;
		default:
			Debug.LogWarning("Sth wrong in the machine velocity control module");
			break;
		}	
		spindleRate = float.Parse(info_array[9]);
		spindleState = int.Parse(info_array[10]);
		SpindlePower();
		if(info_array[11] == "True")
			manual_tool_change = true;
		else
			manual_tool_change = false;
		if(info_array[12] == "True"){
			ORIENT.normal.background = ORIENT_on_u;
			ORIENT.active.background = ORIENT_on_d;
			sty_SORIENT.normal.background = sty_SORIENT_d;
		}else{
			ORIENT.normal.background = ORIENT_off_u;
			ORIENT.active.background = ORIENT_off_d;
			sty_SORIENT.normal.background = sty_SORIENT_u;
		}
	}
	
	[RPC]
	void XP_Button (string speed) {
		MoveButton(speed);
	}
	
	[RPC]
	void XN_Button (string speed) {
		MoveButton(speed);
	}
	
	[RPC]
	void YP_Button (string speed) {
		MoveButton(speed);
	}
	
	[RPC]
	void YN_Button (string speed) {
		MoveButton(speed);
	}
	
	[RPC]
	void ZP_Button (string speed) {
		MoveButton(speed);
	}
	
	[RPC]
	void ZN_Button (string speed) {
		MoveButton(speed);
	}
	
	void MoveButton(string speed)
	{
		string[] speed_array = speed.Split(',');
		held_flag = true;
		speed_to_move = float.Parse(speed_array[0]);
		move_rate_pad = float.Parse(speed_array[1]);
	}

	[RPC]
	void MoveStop () {
		held_flag = false;
		button_status = false;
	}
	
	[RPC]
	void X_Zero_State(int info)
	{
		if(info == 1)
		{
			x_return_zero = true;
		}
		else
			x_return_zero = false;
	}
	
	[RPC]
	void Y_Zero_State(int info)
	{
		if(info == 1)
		{
			y_return_zero = true;
		}
		else
			y_return_zero = false;
	}
	
	[RPC]
	void Z_Zero_State(int info)
	{
		if(info == 1)
		{
			z_return_zero = true;
		}
		else
			z_return_zero = false;
	}
	
	[RPC]
	void SetAbsolutePos(Vector3 pos)
	{
		absolute_pos = pos;
	}
	
	[RPC]
	void SetRelativePos(Vector3 pos)
	{	
		relative_pos = pos;
	}
	
	[RPC]
	void SetGeneralPos(Vector3 pos)
	{	
		MachineCoo = pos;
	}
	
	[RPC]
	void MoveState(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			x_p = true;
		else
			x_p = false;
		if(info_array[1] == "True")
			x_n = true;
		else
			x_n = false;
		if(info_array[2] == "True")
			y_p = true;
		else
			y_p = false;
		if(info_array[3] == "True")
			y_n = true;
		else
			y_n = false;
		if(info_array[4] == "True")
			z_p = true;
		else
			z_p = false;
		if(info_array[5] == "True")
			z_n = true;
		else
			z_n = false;
		if(info_array[6] == "True")
			manualMilling = true;
		else
			manualMilling = false;
	}
	
	[RPC]
	void RapidMoveSet(string info)
	{
		if (info == "true") {
			RapidMoveFlag = false;
			speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
			move_rate_pad = move_rate;
			sty_ButtonRapid.normal.background = t2d_rapid_off_u;
			sty_ButtonRapid.active.background = t2d_rapid_off_d;
			sty_SRAPID.normal.background = sty_SRAPID_u;
		} else {
			RapidMoveFlag = true;
			speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
			move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，不恒为1，与进给面板数值保持一致，姓名--刘旋，时间--2013-4-8
			sty_ButtonRapid.normal.background = t2d_rapid_on_u;
			sty_ButtonRapid.active.background = t2d_rapid_on_d;
			sty_SRAPID.normal.background = sty_SRAPID_d;
		}
	}
	
	//切削时Pad按钮控制
	[RPC]
	void MoveBtnT2D(string typeStr)
	{
		switch(typeStr){
		case "XN":
			sty_ButtonXN.normal.background = t2d_ButtonXN;
			break;
		case "XP":
			sty_ButtonXP.normal.background = t2d_ButtonXP;
			break;
		case "YN":
			sty_ButtonYN.normal.background = t2d_ButtonYN;
			break;
		case "YP":
			sty_ButtonYP.normal.background = t2d_ButtonYP;
			break;
		case "ZN":
			sty_ButtonZN.normal.background = t2d_ButtonZN;
			break;
		case "STOP":
			sty_ButtonYN.normal.background = t2d_ButtonYN_u;
			sty_ButtonYP.normal.background = t2d_ButtonYP_u;
			sty_ButtonZN.normal.background = t2d_ButtonZN_u;
			sty_ButtonXN.normal.background = t2d_ButtonXN_u;
			sty_ButtonXP.normal.background = t2d_ButtonXP_u;
			break;
		default:
			break;
		}
	}
	
	public void HandWheelControl(string info)
	{
		networkView.RPC("HandControlFromPad", RPCMode.Server, info);
	}
	[RPC]
	void HandControlFromPad(string info)
	{
	}
	
	public void HandleButton(int type)
	{
			networkView.RPC("HandleButtonRPC", RPCMode.Others, type);
	}
	[RPC]
	void HandleButtonRPC(int type)
	{
		HandWheel_Script.HandleButtonControl(type);
	}
	
	[RPC]
	void RemainingRPC(Vector3 distance)
	{
		remaining_x = distance.x;
		remaining_y = distance.y;
		remaining_z = distance.z;
	}
	
	[RPC]
	void TimeRPC(string info)
	{
		string[] info_array = info.Split(',');
		RunningTimeH = int.Parse(info_array[0]);
		RunningTimeM = int.Parse(info_array[1]);
		CycleTimeH = int.Parse(info_array[2]);
		CycleTimeM = int.Parse(info_array[3]);
		CycleTimeS = int.Parse(info_array[4]);
	}
	
	void LoadScriptOfAudio ()
	{
		gameObject.AddComponent <AudioSource> ();
		gameObject.audio.loop = true;
		gameObject.audio.playOnAwake = false;
		gameObject.audio.clip = (AudioClip)Resources.Load ("Audio/move");
		gameObject.audio.minDistance = 30f;
		GameObject move_obj;
		try {
			move_obj = GameObject.Find ("GameObject");
		} catch {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		if (move_obj == null) {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		move_obj.transform.name = "move_control";
//		move_obj.AddComponent <MoveControl> ();
		move_obj.AddComponent<AudioSource> ();
		move_obj.audio.loop = true;
		move_obj.audio.playOnAwake = false;
		move_obj.audio.clip = (AudioClip)Resources.Load ("Audio/move");
		move_obj.audio.minDistance = 30f;
//		move_obj.AddComponent <AuxiliaryMoveModule> ();
		GameObject spindle_obj;
		try {
			spindle_obj = GameObject.Find ("GameObject");
		} catch {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		if (spindle_obj == null) {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		spindle_obj.transform.name = "spindle_control";
//		spindle_obj.AddComponent<SpindleControl> ();
		spindle_obj.AddComponent <AudioSource> ();
		spindle_obj.audio.loop = true;
		spindle_obj.audio.playOnAwake = false;
		spindle_obj.audio.clip = (AudioClip)Resources.Load ("Audio/spn");
		spindle_obj.audio.minDistance = 30f;
		GameObject auto_obj;
		try {
			auto_obj = GameObject.Find ("GameObject");
		} catch {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		if (auto_obj == null) {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		auto_obj.transform.name = "AutoMove";
//		auto_obj.AddComponent<AutoMoveModule> ();
//		AutoMove_Script = GameObject.Find ("AutoMove").GetComponent<AutoMoveModule> ();
		GameObject handle_obj;
		try {
			handle_obj = GameObject.Find ("GameObject");
		} catch {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		if (handle_obj == null) {
			Debug.LogError ("Need to add more Empty GameObject by manually: Error caused by Eric Jiang.");
			return;
		}
		handle_obj.transform.name = "HandleControl";
		handle_obj.AddComponent<HandWheelModule> ();
	}
	
	void ExchangeInt (ref int a, ref int b)
	{
		int temp;
		temp = a;
		a = b;
		b = temp;
	}
	
	public void ExchangeVar ()
	{
		List<string> CodeForExchage = null;
		CodeForExchage = CodeForAll;
		CodeForAll = CodeForMDI;
		CodeForMDI = CodeForExchage;
		ExchangeInt (ref SelectEnd, ref MDISelectEnd);
		ExchangeInt (ref SelectStart, ref MDISelectStart);
		ExchangeInt (ref ProgEDITCusorH, ref MDIProgEDITCusorH);
		ExchangeInt (ref ProgEDITCusorV, ref MDIProgEDITCusorV);
		ExchangeInt (ref StartRow, ref MDIStartRow);
		ExchangeInt (ref EndRow, ref MDIEndRow);
		Softkey_Script.calcSepo (CodeForAll, SystemArguments.EditLength1);
	}
	
//  原始备份	
//	public void AutoDisplayFindRows(int showRow,bool displayNormal)
//	{
//		if(CodeForAUTO.Count == 0)
//			return;
//		Softkey_Script.calcSepo(CodeForAUTO, AUTOSeparatePos,320f);
//		this.autoDisplayNormal=displayNormal;
//		int index=0;
//		int irow=-1;
//		while(AUTOSeparatePos[index] != 0)
//		{
////			try
////			{
//				if((AUTOSeparatePos[index]-1) < CodeForAUTO.Count && CodeForAUTO[AUTOSeparatePos[index]-1]==";" ) irow++;
////			}
////			catch
////			{
////				Debug.Log("codeforAuto: "+CodeForAUTO.Count);
////				Debug.Log("index: " + index);
////				Debug.Log("Sep: "+(AUTOSeparatePos[index]-1));
////			}
//			
//			if(irow==showRow) break;
//			index++;
//		}
//		
//		if(irow!=showRow)
//		{
//			
//			
//		}
//		
//		int irowfrom=index;
//		while((irowfrom>0)&&(CodeForAUTO[AUTOSeparatePos[irowfrom-1]-1]!=";"))irowfrom--;
//		AutoRunItemRows.Clear();
//		//程序开始行
//		AutoRunItemRows.Add(irowfrom);
//		//程序结束行
//		AutoRunItemRows.Add(index);
//		
//		//Debug.Log("Ss"+irowfrom+"Ee"+index);
//		
//		int range=0;
//		if(displayNormal)
//			range=9;
//		else
//			range=4;
//		
//		AUTOStartRow=irowfrom/range*range;
//		AUTOEndRow=AUTOStartRow+range;
//		if(index>AUTOEndRow)
//		{
//			AUTOStartRow=irowfrom;
//			AUTOEndRow=irowfrom+range;
//		}
//
//	}
	
	//Auto运行显示时光标的控制
	public void AutoDisplayFindRows (int showRow, bool displayNormal)
	{
		Softkey_Script.calcSepoAuto (CodeForAUTO, SystemArguments.AutoLength1);
		if (showRow >= auto_total_row)
			return;
		autoDisplayNormal = displayNormal;
		int index = 0;  //代表光标终止行（一行代码可能占据多行）
		int irow = -1;  //代表代码行号
		for (int i = 0; i < SeparateAutoEnd.Count; i++) {
			index = i;
			if (CodeForAUTO [SeparateAutoEnd [i] - 1] == ";")  //如果结束处为";"，则行号+1
				irow++;
			if (irow == showRow)
				break;
		}
		
		if (irow != showRow) {  //如果showRow数值超过最大行，则光标位于最后一行
			autoSelecedProgRow = irow;
		} else
			autoSelecedProgRow = showRow;
		
		int irowStart = index;  //代表光标起始行（一行代码可能占据多行）
		while ((irowStart > 0) && (CodeForAUTO[SeparateAutoEnd[irowStart - 1] -1] != ";"))
			irowStart--;
		//光标开始行
		AutoBeginRow = irowStart;
		//光标结束行
		AutoStopRow = index;

		int range = 0;
		if (displayNormal)
			range = SystemArguments.AutoLongLineNumber;
		else
			range = SystemArguments.AutoPartLineNumber;
		
		AUTOStartRow = irowStart / range * range;
		AUTOEndRow = AUTOStartRow + range;
		if (index > AUTOEndRow) {
			AUTOStartRow = irowStart;
			AUTOEndRow = irowStart + range;
		}
	}
	
	//MDI运行显示时光标的控制
	public void MDIDisplayFindRows (int showRow)
	{
		Softkey_Script.calcSepoMDI (CodeForMDIRuning, SystemArguments.EditLength1);
		if (showRow >= mdi_total_row)
			return;
		int index = 0;  //代表光标终止行（一行代码可能占据多行）
		int irow = -1;  //代表代码行号
		for (int i = 0; i < SeparateMDIEnd.Count; i++) {
			index = i;
			if (CodeForMDIRuning [SeparateMDIEnd [i] - 1] == ";")  //如果结束处为";"，则行号+1
				irow++;
			if (irow == showRow)
				break;
		}
		
		if (irow != showRow) {  //如果showRow数值超过最大行，则光标位于最后一行
			MDISelectedRow = irow;
		} else
			MDISelectedRow = showRow;
		
		int irowStart = index;  //代表光标起始行（一行代码可能占据多行）
		while ((irowStart > 0) && (CodeForMDIRuning[SeparateMDIEnd[irowStart - 1] -1] != ";"))
			irowStart--;
		//光标开始行
		MDIBeginRow = irowStart;
		//光标结束行
		MDIStopRow = index;

		int range = 0;
		range = SystemArguments.AutoLongLineNumber;
		
		MDIStartRowC = irowStart / range * range;
		MDIEndRowC = MDIStartRowC + range;
		if (index > MDIEndRowC) {
			MDIStartRowC = irowStart;
			MDIEndRowC = irowStart + range;
		}
	}
	
	void OnGUI ()
	{ 
		//完整面板切换动画
		if (panelWindow_show_off) {
			PanelWindowRect.x = left;
			PanelWindowRect.y = top;
			PanelWindowRect.width = width;
			PanelWindowRect.height = height;
		}
		if (!Client_Script.client_window_on) {
			if (panelWindowOnly)
			{
				PanelWindowRect = GUI.Window (0, PanelWindowRect, PanelWindow, "", background); 
				GUI.BringWindowToBack(0);
				if(Input.touchCount > 0)
				{
					if(Input.GetTouch(0).phase == TouchPhase.Began && PanelWindowRect.Contains(Input.GetTouch(0).position))
						rect_contain = true;
				}
				if(rect_contain)
				{
					if(Input.GetTouch(0).phase == TouchPhase.Ended)
						rect_contain = false;
				}
			}
		}
		
		if (power_notification) {
			power_notifi_window = GUI.Window (1, power_notifi_window, PowerState, "", sty_PowerNotifi);
			GUI.BringWindowToFront (1);
		}
		
		//局部面板切换动画
		if (screen_show_off) {
			screenRect.x = left;
			screenRect.y = top;
			screenRect.width = width / SystemArguments.PanelWindow_Width * SystemArguments.SmallScreen_Width;
			screenRect.height = height / SystemArguments.PanelWindow_Height * SystemArguments.SmallScreen_Heght;
		}
		
		if (screenOnly)
			screenRect = GUI.Window (2, screenRect, ScreenWindow, "", sty_screenOnlyBackground); 
		
		/*
		//窗口隐藏控制
		Event mouse_e = Event.current;
		if (panelWindowOnly) {
			if (!panelWindow_show_off && !screen_hide && !screen_move_on) {
				if (!PanelWindowRect.Contains (mouse_e.mousePosition) && mouse_e.isMouse && 
					mouse_e.type == EventType.MouseDown && mouse_e.button == 0 && mouse_e.clickCount == 2) {
					hide_start_x = PanelWindowRect.x;
					display_speed = 0;
					screen_move_on = true;
				}
			}
		} else {
			if (!screen_show_off && !screen_hide && !screen_move_on) {
				if (!screenRect.Contains (mouse_e.mousePosition) && mouse_e.isMouse && 
					mouse_e.type == EventType.MouseDown && mouse_e.button == 0 && mouse_e.clickCount == 2) {
					hide_start_x = screenRect.x;
					display_speed = 0;
					screen_move_on = true;
				}
			}
		}
		*/
		
		//右键菜单显示后消失的控制
//		if (RightclickMenu_Script.rightclick_menu_on) {
//			if (panelWindowOnly) {
//				if (PanelWindowRect.Contains (mouse_e.mousePosition) && (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2))) {
//					RightclickMenu_Script.rightclick_menu_on = false;
//				}
//			} else {
//				if (screenRect.Contains (mouse_e.mousePosition) && (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2))) {
//					RightclickMenu_Script.rightclick_menu_on = false;
//				}
//			}
//		}
		
		if (!Client_Script.client_window_on) {
			if (SetupGuide_on) {
				SetupGuide_Rect = GUI.Window (3, SetupGuide_Rect, SetupGuideWindow, "", sty_SetupGuide);
				GUI.BringWindowToFront (1);
			}
		}
		
		if (ExitWindow_On) {
			ExitWindow_Rect = GUI.Window (7, ExitWindow_Rect, ExitWindow, "", sty_ExitBackground);
			GUI.FocusWindow(7);
			GUI.BringWindowToFront (7);
		}
		
		if (SystemSettings_On) {
			SystemSettings_Rect = GUI.Window (8, SystemSettings_Rect, SystemSettingsWindow, "", sty_SystemSettings_Background);
			GUI.BringWindowToFront (1);	
		}
		
//		if(GUILayout.Button("hello"))
//		{
//			System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo();
//			processStartInfo.FileName = "explorer.exe";  //资源管理器
//			string hahaha = Application.dataPath;
//			hahaha = hahaha.Replace("/", "\\");
//			processStartInfo.Arguments =hahaha + "\\Resources\\Gcode\\";
//			System.Diagnostics.Process.Start(processStartInfo);
//		}
		
//		if(GUI.Button(new Rect(10, 90, 120, 30), "退出程序"))
//		{
//			PlayerPrefs.SetInt("RunningTimeH", RunningTimeH);
//			PlayerPrefs.SetInt("RunningTimeM", RunningTimeM);
//			PlayerPrefs.SetInt("PartsNum", PartsNum);
//			Application.Quit();
//		}
		
//		if(GUI.Button(new Rect(150, 120, 120, 30), "Show Off Switch"))
//		{
//			show_off_button_on = !show_off_button_on;
//		}
	}
	
	void FixedUpdate ()
	{
		//完整面板切换
		if (panelWindow_show_off && panelWindowOnly && !screen_move_on) {
			PanelWindowShowOff (appear_dispear);
		}
		
		//局部面板切换
		if (screen_show_off && screenOnly && !screen_move_on) {
			SmallScreenShowOff (appear_dispear);
		}
		
		//面板显示和消失控制
		if (screen_move_on) {
//			WindowHideControl ();
		}
		
		//面板显示触发
		if (screen_hide && !screen_move_on) {
			if (Input.mousePosition.x >= Screen.width - 1f) {
				if (panelWindowOnly) {
					hide_start_x = Screen.width - SystemArguments.PanelWindow_Width;
					display_speed = 0;
					screen_move_on = true;
				} else {
					hide_start_x = Screen.width - SystemArguments.SmallScreen_Width;
					display_speed = 0;
					screen_move_on = true;
				}
			}
		}
		
		LightNumber_Script.setLight((int)Lights.X, x_return_zero);
		LightNumber_Script.setLight((int)Lights.Y, y_return_zero);
		LightNumber_Script.setLight((int)Lights.Z, z_return_zero);
	}
	
	void Update ()
	{
//		if (Input.GetKeyDown (KeyCode.A)) {
//			ShowOffSwitch ();
//		}
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (ExitWindow_On)
				ExitWindow_On = false;
			else
				ExitWindow_On = true;
		}
	}
	
	//完整面板动画切换控制
	void PanelWindowShowOff (bool appear_on)
	{
		Debug.Log("1");
		if (appear_on) {
			width = Mathf.Lerp (0.1f, SystemArguments.PanelWindow_Width, show_off_speed * timeV);
			height = Mathf.Lerp (0.1f, SystemArguments.PanelWindow_Height, show_off_speed * timeV);
			left = Mathf.Lerp (show_off_centre_x, show_off_big_corner_x, show_off_speed * timeV);
			top = Mathf.Lerp (show_off_centre_y, show_off_big_corner_y, show_off_speed * timeV);
			timeV += Time.deltaTime;	
			if (timeV > 0.5f) {
				panelWindow_show_off = false;
				timeV = 0;
			}
		} else {
			width = Mathf.Lerp (SystemArguments.PanelWindow_Width, 0.1f, show_off_speed * timeV);
			height = Mathf.Lerp (SystemArguments.PanelWindow_Height, 0.1f, show_off_speed * timeV);
			left = Mathf.Lerp (show_off_big_corner_x, show_off_centre_x, show_off_speed * timeV);
			top = Mathf.Lerp (show_off_big_corner_y, show_off_centre_y, show_off_speed * timeV);
			timeV += Time.deltaTime;	
			if (timeV > 0.5f) {
				panelWindow_show_off = false;
				if (show_off_times) {
					appear_dispear = true;
					show_off_times = false;
					panelWindowOnly = false;
					screenOnly = true;
					screen_show_off = true;
				}
				timeV = 0;
			}
		}
	}
	
	//局部面板动画切换控制
	void SmallScreenShowOff (bool appear_on)
	{
		if (appear_on) {
			width = Mathf.Lerp (0.1f, SystemArguments.PanelWindow_Width, show_off_speed * timeV);
			height = Mathf.Lerp (0.1f, SystemArguments.PanelWindow_Height, show_off_speed * timeV);
			left = Mathf.Lerp (show_off_centre_x, show_off_small_corner_x, show_off_speed * timeV);
			top = Mathf.Lerp (show_off_centre_y, show_off_small_corner_y, show_off_speed * timeV);
			timeV += Time.deltaTime;	
			if (timeV > 0.5f) {
				screen_show_off = false;
				timeV = 0;
			}
		} else {
			width = Mathf.Lerp (SystemArguments.PanelWindow_Width, 0.1f, show_off_speed * timeV);
			height = Mathf.Lerp (SystemArguments.PanelWindow_Height, 0.1f, show_off_speed * timeV);
			left = Mathf.Lerp (show_off_small_corner_x, show_off_centre_x, show_off_speed * timeV);
			top = Mathf.Lerp (show_off_small_corner_y, show_off_centre_y, show_off_speed * timeV);
			timeV += Time.deltaTime;	
			if (timeV > 0.5f) {
				screen_show_off = false;
				if (show_off_times) {
					appear_dispear = true;
					show_off_times = false;
					screenOnly = false;
					panelWindowOnly = true;
					panelWindow_show_off = true;
				}
				timeV = 0;
			}
		}
	}
	
	//面板切换触发开关
	void ShowOffSwitch ()
	{
		if (screenOnly) {
			ProgEDITCusorPos = ProgEDITCusorPos - corner_px + big_corner_px - 4f;
			InputTextPos = InputTextPos - corner_px + big_corner_px - 4f;
			tool_setting_cursor_y = tool_setting_cursor_y - corner_py + big_corner_py;
			tool_setting_cursor_w = tool_setting_cursor_w - corner_px + big_corner_px;
			argu_setting_cursor_y = argu_setting_cursor_y - corner_py + big_corner_py;
			Offset_Script.tool_corner_x = Offset_Script.tool_corner_x - corner_px + big_corner_px;
			Offset_Script.tool_corner_y = Offset_Script.tool_corner_y - corner_py + big_corner_py;
			coo_setting_cursor_x = coo_setting_cursor_x - corner_px + big_corner_px;
			coo_setting_cursor_y = coo_setting_cursor_y - corner_py + big_corner_py;
			corner_px = big_corner_px;
			corner_py = big_corner_py;
			show_off_small_corner_x = screenRect.x;
			show_off_small_corner_y = screenRect.y;
			left = show_off_small_corner_x;
			top = show_off_small_corner_y;
			show_off_centre_x = show_off_small_corner_x + SystemArguments.SmallScreen_Width / 2;
			show_off_centre_y = show_off_small_corner_y + SystemArguments.SmallScreen_Heght / 2;
			show_off_big_corner_x = show_off_centre_x - SystemArguments.PanelWindow_Width / 2;
			show_off_big_corner_y = show_off_centre_y - SystemArguments.PanelWindow_Height / 2;
			show_off_times = true;
			appear_dispear = false;
			screen_show_off = true;
		} else {
			ProgEDITCusorPos = ProgEDITCusorPos - corner_px + small_corner_px + 4f;
			InputTextPos = InputTextPos - corner_px + small_corner_px + 4f;
			tool_setting_cursor_y = tool_setting_cursor_y - corner_py + small_corner_py;
			tool_setting_cursor_w = tool_setting_cursor_w - corner_px + small_corner_px;
			argu_setting_cursor_y = argu_setting_cursor_y - corner_py + small_corner_py;
			Offset_Script.tool_corner_x = Offset_Script.tool_corner_x - corner_px + small_corner_px;
			Offset_Script.tool_corner_y = Offset_Script.tool_corner_y - corner_py + small_corner_py;
			coo_setting_cursor_x = coo_setting_cursor_x - corner_px + small_corner_px;
			coo_setting_cursor_y = coo_setting_cursor_y - corner_py + small_corner_py;
			corner_px = small_corner_px;
			corner_py = small_corner_py;
			show_off_big_corner_x = PanelWindowRect.x;
			show_off_big_corner_y = PanelWindowRect.y;
			left = show_off_big_corner_x;
			top = show_off_big_corner_y;
			show_off_centre_x = show_off_big_corner_x + SystemArguments.PanelWindow_Width / 2;
			show_off_centre_y = show_off_big_corner_y + SystemArguments.PanelWindow_Height / 2;
			show_off_small_corner_x = show_off_centre_x - SystemArguments.SmallScreen_Width / 2;
			show_off_small_corner_y = show_off_centre_y - SystemArguments.SmallScreen_Heght / 2;
			show_off_times = true;
			appear_dispear = false;
			panelWindow_show_off = true;
		}
	}
	
	//面板显示与隐藏控制函数
	void WindowHideControl ()
	{
		display_speed += 0.003f * screen_move_speed;
		if (!screen_hide) { //消失
			if (panelWindowOnly) {  //完整面板的消失
				PanelWindowRect.x = Mathf.Lerp (hide_start_x, Screen.width + 1f, display_speed);
				if (PanelWindowRect.x >= Screen.width + 1f) {
					PanelWindowRect.y = Screen.height / 2 - SystemArguments.PanelWindow_Height / 2;
					screen_move_on = false;
					screen_hide = true;
					display_speed = 0;
				}
			} else {  //局部面板的消失
				screenRect.x = Mathf.Lerp (hide_start_x, Screen.width + 1f, display_speed);
				if (screenRect.x >= Screen.width + 1f) {
					screenRect.y = Screen.height / 2 - SystemArguments.SmallScreen_Heght / 2;
					screen_move_on = false;
					screen_hide = true;
					display_speed = 0;
				}
			}
		} else {  //出现
			if (panelWindowOnly) {  //完整面板的出现
				PanelWindowRect.x = Mathf.Lerp (Screen.width + 1f, hide_start_x, display_speed);
				if (PanelWindowRect.x <= hide_start_x) {
					screen_move_on = false;
					screen_hide = false;
					display_speed = 0;
				}
			} else {  //局部面板的出现
				screenRect.x = Mathf.Lerp (Screen.width + 1f, hide_start_x, display_speed);
				if (screenRect.x <= hide_start_x) {
					screen_move_on = false;
					screen_hide = false;
					display_speed = 0;
				}
			}
		}
	}
	
	//NC系统电源控制
	void PowerState (int windowID)
	{
//		GUI.color = Color.black;
//		GUI.Label (new Rect (40f, 25f, 400f, 40f), "请打开NC系统电源！");
//		GUI.color = Color.white;
		if (GUI.Button (new Rect (123f, 106f, 107f, 31f), "", sty_PowerNotifi_confirm))
			power_notification = false;
		if (GUI.Button (new Rect (270f, 13f, 15f, 15f), "", sty_PowerNotifi_cancel))
			power_notification = false;
		GUI.DragWindow ();  
	}
	
	//设置向导界面
	void SetupGuideWindow (int WindowID)
	{
		if (GUI.Button (new Rect (450, 10, 30, 31), "", sty_SetupClose)) {
			networkView.RPC("SetupClose", RPCMode.All);
		}
		
		if (GUI.Button (new Rect (165, 363, 25, 25), "", sty_SetupCheckBox)) {
			if (CheckBox_On) {
				sty_SetupCheckBox.normal.background = CheckBox_unchecked;
				CheckBox_On = false;
				Client_Script.SetupGuide (1);
				sty_SystemSettings_On4.normal.background = t2d_SystemSettings_On;
			} else {
				sty_SetupCheckBox.normal.background = CheckBox_checked;
				CheckBox_On = true;
				Client_Script.SetupGuide (0);
				sty_SystemSettings_On4.normal.background = t2d_SystemSettings_Off;
			}
		}
		
		if (GUI.Button (new Rect (420, 363, 25, 25), "", sty_LeftArrow)) {
//			SetupArrow (true);
			networkView.RPC("SetupArrow", RPCMode.All, true);
		}
		
		if (GUI.Button (new Rect (450, 363, 25, 25), "", sty_RightArrow)) {
//			SetupArrow (false);
			networkView.RPC("SetupArrow", RPCMode.All, false);
		}
		
		GUI.DragWindow ();
	}
	
	[RPC]
	void SetupClose()
	{
		panelWindowOnly = true;
		SetupGuide_on = false;
		if (ProgHAN) {
			StartCoroutine (HandWheel_Script.showWheel ());
		}
	}
	
	//设置向导前进和后退控制
	[RPC]
	void SetupArrow (bool left_on)
	{
		if (left_on) {
			switch (SetupFlip) {
			case 2:
				sty_SetupGuide.normal.background = SetupGuide1;
				SetupFlip--;
				break;
			case 3:
				sty_SetupGuide.normal.background = SetupGuide2;
				SetupFlip--;
				break;
			case 4:
				sty_SetupGuide.normal.background = SetupGuide3;
				SetupFlip--;
				break;
			case 5:
				sty_SetupGuide.normal.background = SetupGuide4;
				SetupFlip--;
				break;
			default:
				break;
			}
		} else {
			switch (SetupFlip) {
			case 1:
				sty_SetupGuide.normal.background = SetupGuide2;
				SetupFlip++;
				break;
			case 2:
				sty_SetupGuide.normal.background = SetupGuide3;
				SetupFlip++;
				break;
			case 3:
				sty_SetupGuide.normal.background = SetupGuide4;
				SetupFlip++;
				break;
			case 4:
				sty_SetupGuide.normal.background = SetupGuide5;
				SetupFlip++;
				break;
			default:
				break;
			}
		}
	}
	
	//退出窗口界面
	void ExitWindow (int WindowID)
	{
		if (GUI.Button (new Rect (263, 8, 25, 25), "", sty_ExitClose)) {
			ExitWindow_On = false;
		}
		
		if (GUI.Button (new Rect (66, 73, 173, 47), "", sty_ExitSettings)) {
			SystemSettings_On = true;
			ExitWindow_On = false;
		}
		
		if (GUI.Button (new Rect (66, 141, 173, 47), "", sty_ExitProg)) {
			string memory_info = "";
			memory_info = RunningTimeH.ToString () + "," + RunningTimeM.ToString () + "," + PartsNum.ToString ();
			Client_Script.RunningMemory (memory_info);
			Application.Quit ();
		}
		
		GUI.DragWindow ();
	}
	
	public void ShowOffButtonFromPad(bool flag)
	{
		if(flag)
		{
			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_On;
		}
		else
		{
			sty_SystemSettings_On1.normal.background = t2d_SystemSettings_Off;
		}
	}
	
	public void OriginalPathDisplay(bool flag)
	{
		if(flag)
		{
			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_On;
		}
		else
		{
			sty_SystemSettings_On2.normal.background = t2d_SystemSettings_Off;
		}
	}
	
	public void PathLineDisplay(bool flag)
	{
		if(flag)
		{
			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_On;
		}
		else
		{
			sty_SystemSettings_On3.normal.background = t2d_SystemSettings_Off;
		}
	}
	
	public void CheckBoxControl(int flag)
	{
		if(flag == 1)
		{
			sty_SetupCheckBox.normal.background = CheckBox_unchecked;
			CheckBox_On = false;
			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_On;
		}
		else
		{
			sty_SetupCheckBox.normal.background = CheckBox_checked;
			CheckBox_On = true;
			sty_SystemSettings_On4.normal.background = t2d_SystemSettings_Off;
		}
	}
	
	//系统设置界面
	void SystemSettingsWindow (int WindowID)
	{
		if (GUI.Button (new Rect (445, 10, 30, 31), "", sty_SetupClose)) {
			SystemSettings_On = false;
		}
		
		if (SystemSettingsFlip == 1) {
			if (GUI.Button (new Rect (370, 162, 97, 37), "", sty_SystemSettings_On1)) {
				if (show_off_button_on) {
					sty_SystemSettings_On1.normal.background = t2d_SystemSettings_Off;
					Client_Script.ShowOffButton (0);
					show_off_button_on = false;
				} else {
					sty_SystemSettings_On1.normal.background = t2d_SystemSettings_On;
					Client_Script.ShowOffButton (1);
					show_off_button_on = true;
				}
			}
			
			if (GUI.Button (new Rect (370, 228, 97, 37), "", sty_SystemSettings_On2)) {
				if (originalPathDisplay) {
					sty_SystemSettings_On2.normal.background = t2d_SystemSettings_Off;
					Client_Script.OriginalPathButton (0);
					originalPathDisplay = false;
				} else {
					sty_SystemSettings_On2.normal.background = t2d_SystemSettings_On;
					Client_Script.OriginalPathButton (1);
					originalPathDisplay = true;
				}
			}
			
			if (GUI.Button (new Rect (370, 296, 97, 37), "", sty_SystemSettings_On3)) {
				if (pathLineDisplay) {
					sty_SystemSettings_On3.normal.background = t2d_SystemSettings_Off;
					Client_Script.PracticalPathButton (0);
					pathLineDisplay = false;
				} else {
					sty_SystemSettings_On3.normal.background = t2d_SystemSettings_On;
					Client_Script.PracticalPathButton (1);
					pathLineDisplay = true;
				}
			}
			
			if (GUI.Button (new Rect (370, 362, 97, 37), "", sty_SystemSettings_On4)) {
				if (sty_SystemSettings_On4.normal.background == t2d_SystemSettings_On) {
					sty_SystemSettings_On4.normal.background = t2d_SystemSettings_Off;
					Client_Script.SetupGuide (0);
					sty_SetupCheckBox.normal.background = CheckBox_checked;
				} else {
					sty_SystemSettings_On4.normal.background = t2d_SystemSettings_On;
					Client_Script.SetupGuide (1);
					sty_SetupCheckBox.normal.background = CheckBox_unchecked;
				}
			}
		}
		
		if (SystemSettingsFlip == 2) {
			if (GUI.Button (new Rect (85, 155, 331, 47), "", sty_SystemSettings_OpenFile)) {
				networkView.RPC("OpenFileRPC", RPCMode.Server);
			}
			
			if (GUI.Button (new Rect (85, 224, 331, 46), "", sty_SystemSettings_DefaultSettings)) {
				ProgramReset_Script.display_menu = true;
			}
			
			GUI.Label (new Rect (60, 350, 371, 49), "", sty_SystemSettings_VSlider);
			if (GUI.Button (new Rect (60, 375, 18, 18), "", sty_SystemSettings_VSliderLeft)) {
				networkView.RPC("MachineVelocity", RPCMode.All, false);
			}
			
			if (GUI.Button (new Rect (413, 375, 18, 18), "", sty_SystemSettings_VSliderRight)) {
				networkView.RPC("MachineVelocity", RPCMode.All, true);
			}
		}
		
		if (GUI.Button (new Rect (28, 460, 113, 55), "", sty_SystemSettings_Prev)) {
			switch (SystemSettingsFlip) {
			case 2:
				sty_SystemSettings_Background.normal.background = t2d_SystemSettings1;
				SystemSettingsFlip--;
				break;
			default:
				break;
			}
		}
		
		if (GUI.Button (new Rect (350, 460, 113, 55), "", sty_SystemSettings_Next)) {
			switch (SystemSettingsFlip) {
			case 1:
				sty_SystemSettings_Background.normal.background = t2d_SystemSettings2;
				SystemSettingsFlip++;
				break;
			default:
				break;
			}
		}
		
		GUI.DragWindow ();
	}
	
	[RPC]
	void OpenFileRPC()
	{
		
	}
	[RPC]
	void MachineVelocity(bool type)
	{
		if(type)  //增速
		{
			switch (SystemSettings_VSlider_State) {
			case 1:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider10;
				SystemSettings_VSlider_State++;
				break;
			case 2:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider100;
				SystemSettings_VSlider_State++;
				break;
			case 3:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider1000;
				SystemSettings_VSlider_State++;
				break;
			default:
				break;
			}
		}
		else   //减速
		{
			switch (SystemSettings_VSlider_State) {
			case 2:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider1;
				SystemSettings_VSlider_State--;
				break;
			case 3:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider10;
				SystemSettings_VSlider_State--;
				break;
			case 4:
				sty_SystemSettings_VSlider.normal.background = t2d_SystemSettings_VSlider100;
				SystemSettings_VSlider_State--;
				break;
			default:
				break;
			}
		}
	}
	
	//局部数控面板界面
	void ScreenWindow (int WindowID)
	{
		//屏幕
//		Event mouse_e = Event.current;
		GUI.Box (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height), "", sty_ScreenBlack);
		
//		//双击切换至完整画面
//		if (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height).Contains (mouse_e.mousePosition) && 
//			mouse_e.isMouse && mouse_e.type == EventType.MouseDown && mouse_e.button == 0 && mouse_e.clickCount == 2) {
//			ShowOffSwitch ();
//		}
		//NC系统电源，屏幕是否显示
		if (ScreenPower) {
			ScreenNormallyOn ();
			//位置界面
			if (PosMenu) {
				//Position模块显示
				Position_Script.Position ();
			}
			
			//程序界面
			if (ProgMenu) {
				//Program模块显示
				Program_Script.Program ();
			}
			
			//设置界面
			if (SettingMenu) {
				//Offset模块显示
				Offset_Script.Offset ();
			}
			
			//System界面，姓名--刘旋，时间--2013-4-24
			if (SystemMenu) {
				//System模块显示
				System_Script.System ();
			}
			
			//Message界面，姓名--刘旋，时间--2013-4-24
			if (MessageMenu) {
				//Message模块显示
				Message_Script.Message ();
			}
			
			//屏幕 基本固定区域
			ScreenBottom ();
			
			//打印编辑区域
			ScreenPrintArea ();	
			SpeedModule ();//内容--增加行数SpeedModule用于控制时速度，姓名--刘旋，时间--2013-4-16
		}
		Softkey_Script.Softkey ();   //增加屏幕下方按钮触屏功能， BY王广官
		//以上部分为屏幕显示区域，所有有关屏幕GUI效果的变化都通过上述函数增添和编辑
		
		//*********************************************************************************************************************
		//屏幕启动和关闭界面
		if (ScreenCover)
			GUI.Box (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height), "", sty_ScreenCover);
		
		GUI.DragWindow ();
	}
	
	//完整数控面板界面
	void PanelWindow (int windowID)
	{  
		//屏幕
//		Event mouse_e = Event.current;
		GUI.Box (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height), "", sty_ScreenBlack);
		
//		//双击切换至局部画面
//		if (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height).Contains (mouse_e.mousePosition) && 
//			mouse_e.isMouse && mouse_e.type == EventType.MouseDown && mouse_e.button == 0 && mouse_e.clickCount == 2) {
//			ShowOffSwitch ();
//		}
		
		//NC系统电源，屏幕是否显示
		if (ScreenPower) {
			ScreenNormallyOn ();
			//位置界面
			if (PosMenu) {
				//Position模块显示
				Position_Script.Position ();
			}
			
			//程序界面
			if (ProgMenu) {
				//Program模块显示
				Program_Script.Program ();
			}
			
			//设置界面
			if (SettingMenu) {
				//Offset模块显示
				Offset_Script.Offset ();
			}
			
			//System界面，姓名--刘旋，时间--2013-4-24
			if (SystemMenu) {
				//System模块显示
				System_Script.System ();
			}
			
			//Message界面，姓名--刘旋，时间--2013-4-24
			if (MessageMenu) {
				//Message模块显示
				Message_Script.Message ();
			}
			
			//屏幕 基本固定区域
			ScreenBottom ();
			
			//打印编辑区域
			ScreenPrintArea ();	
			SpeedModule ();//内容--增加行数SpeedModule用于控制时速度，姓名--刘旋，时间--2013-4-16
		}
		
		//以上部分为屏幕显示区域，所有有关屏幕GUI效果的变化都通过上述函数增添和编辑
		
		//*********************************************************************************************************************
		
		
		//屏幕启动和关闭界面
		if (ScreenCover)
			GUI.Box (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height), "", sty_ScreenCover);
		
		//MDI面板输入区	
		MDIInput_Script.MDIInput ();
		
		//MDI功能按键区
		//MDI功能选择按键
		MDIFunction_Script.Function ();
		//MDI文字编辑按键
		MDIEdit_Script.Edit ();
		
		//屏幕下方功能软键-------------------------------------------------------------------------------------------------------------
		Softkey_Script.Softkey ();

		//NC系统电源按钮
		//(1)
//		GUI.Box(new Rect(40f/1000f*width,520f/1000f*height,150f/1000f*width,250f/1000f*height),"");
		
		NCPowerButton ();
		
		//添加 BY:WH
		if(ScreenPower){
			LightNumber_Script.LightControl ();
			LightNumber_Script.showNumber ();
		}
		
		//(2)
//		GUI.Box(new Rect(195f/1000f*width,520f/1000f*height,770f/1000f*width,100f/1000f*height),"");
		
		GUI.DrawTexture (new Rect (t2d_x / 1000f * width, t2d_y / 1000f * height, t2d_width / 1000f * width, t2d_height / 1000f * height), t2d_Protect, ScaleMode.ScaleAndCrop, true, 201 / 162f);

		//程序保护锁---------------------------------------------------------------------------------------------------------------------------------------------------------
		if (GUI.Button (new Rect (t2d_x / 1000f * width, t2d_y / 1000f * height, t2d_width / 1000f * width, t2d_height / 1000f * height), "", sty_ButtonEmpty)) {
//			ProgProtectRPC();
			networkView.RPC("ProgProtectRPC", RPCMode.All);
		}
		
//		GUI.DrawTexture(new Rect(360f/1000f*width,535f/1000f*height,150f/1000f*width,75f/1000f*height), t2d_alarm, ScaleMode.ScaleAndCrop, true, 2.0f);
//		
//		GUI.DrawTexture(new Rect(580f/1000f*width,535f/1000f*height,195f/1000f*width,75f/1000f*height), t2d_zero, ScaleMode.ScaleAndCrop, true, 2.6f);
//		
//		GUI.DrawTexture(new Rect(850f/1000f*width,535f/1000f*height,75f/1000f*width,75f/1000f*height), t2d_toolnum, ScaleMode.ScaleAndCrop, true, 1.0f);
		
		
		//(3)
//		GUI.Box(new Rect(195f/1000f*width,625f/1000f*height,770f/1000f*width,145f/1000f*height),"");
		
		//模式选择旋钮
		ModeSelect_Script.ModeSelectButton ();
		
		//手动进给速率旋钮
		Feedrate_Script.FeedrateSelect ();
	
		//机床功能按键
		MachineFunction_Script.MachineFunction ();

		
		//(4)
//		GUI.Box(new Rect(40f/1000f*width,775f/1000f*height,925f/1000f*width,200f/1000f*height),"");
		
//		GUI.color = Color.white;
		
//		GUI.DrawTexture(new Rect(100f/1000f*width,790f/1000f*height,110f/1000f*width,110f/1000f*height), t2d_Emergency, ScaleMode.ScaleAndCrop, true, 1f);
		
		//紧急停止按钮   待完善
		if (GUI.Button (new Rect (t2d_Emergency_x / 1000f * width, t2d_Emergency_y / 1000f * height, t2d_Emergency_width / 1000f * width, t2d_Emergency_height / 1000f * height), "", t2d_Emergency)) {
//			if (ScreenPower) {
				networkView.RPC("EmergencyRPC", RPCMode.All);
//			}
		}
		
		//循环启动 待完善
//		GUI.color = Color.green;
//		GUI.contentColor = Color.green;
		if (GUI.Button (new Rect (IO_x / 1000f * width, IO_y / 1000f * height, IO_width / 1000f * width, IO_height / 1000f * height), "", I)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					networkView.RPC("AutoRunningButton", RPCMode.Server);
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		}
		
		if (AutoRunning_flag || MDI_RunningFlag) {
			I.normal.background = I_d;
		} else {
			I.normal.background = I_u;
		}
		//进给保持按钮  待完善
//		GUI.color = Color.yellow;
//		GUI.contentColor = Color.yellow;
		if (GUI.Button (new Rect ((IO_x + IO_left_x) / 1000f * width, IO_y / 1000f * height, IO_width / 1000f * width, IO_height / 1000f * height), "", O)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					networkView.RPC("AutoRunningPause", RPCMode.Server);
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		}
		
		if (AutoPause_flag || MDI_PauseFlag) {
			O.normal.background = O_d;
		} else {
			O.normal.background = O_u;
		}
//		GUI.color = Color.white;
//		GUI.contentColor = Color.white;
		
		// 机床辅助功能按键
		AuxiliaryFunction_Script.AuxiliaryFunction ();
		
		// 手动进给按钮 待完善
		ManualOperationButton ();
		
		// 主轴旋转控制按钮  待完善
		SpindleControl ();
		
		if (show_off_button_on) {
			ButtonShowOff_Script.ButtonEnlarge ();
			ButtonShowOff_Script.KnobEnlarge ();
		}
		
		if(Input.touchCount == 1){
			if(Input.GetTouch(0).phase == TouchPhase.Stationary && !mainWindowDrag)
				dragTime = 0;
		}
		
		if(Input.touchCount != 1){
			if(dragTime < 3f){
				dragTime += Time.deltaTime;
				if(dragTime > 0.5f)
					mainWindowDrag = true;
			}
		}
		
//		if(!HandWheel_Script.rotate_flag && mainWindowDrag)
//			GUI.DragWindow ();    
	}
	
	[RPC]
	void AutoRunningButton()
	{
	}
	
	[RPC]
	void AutoRunningPause()
	{
		
	}
	
	[RPC]
	void AutoMDIRunningFlag(string info)
	{
		string[] info_array = info.Split(',');
		if(info_array[0] == "True")
			AutoRunning_flag = true;
		else
			AutoRunning_flag = false;
		if(info_array[1] == "True")
		{
			MDI_RunningFlag = true;
			CodeForMDIRuning.Clear ();
			for (int i = 0; i < CodeForAll.Count; i++) {
				CodeForMDIRuning.Add (CodeForAll [i]);
			}
		}
		else
			MDI_RunningFlag = false;
		if(info_array[2] == "True")
			AutoPause_flag = true;
		else
			AutoPause_flag = false;
		if(info_array[3] == " True")
			MDI_PauseFlag = true;
		else
			MDI_PauseFlag = false;
	}
	
	[RPC]
	void ProgProtectRPC()
	{
		if (ProgProtect) {
				t2d_Protect = t2d_unlock;
				ProgProtect = false;
				ProgProtectWarn = false;
				WarnningClear ();
			} else {
				t2d_Protect = t2d_lock;
				ProgProtect = true;
			}	
	}
	
	[RPC]
	void EmergencyRPC()
	{
		if (EmergencyCtrl) {
			t2d_Emergency.normal.background = t2d_em_u;
			EmergencyCtrl = false;
		} else {
			t2d_Emergency.normal.background = t2d_em_d;
			AutoDisplay_Script.DisplayEnd();
			Program_Script.SetModalState (new List<int> (), new List<string> ());  //模态变化的蓝色光标清空
			AutoRunning_flag = false;
			RunningSpeed = 0;
			SpindleStop ();
			SpindleSpeed = 0;
			Compile_flag = false;
			EmergencyCtrl = true;
		}
	}
	
	[RPC]
	void EmergencyConditionRPC()
	{
		AutoDisplay_Script.DisplayEnd();
		Program_Script.SetModalState (new List<int> (), new List<string> ());  //模态变化的蓝色光标清空
		AutoRunning_flag = false;
		RunningSpeed = 0;
		Compile_flag = false;
	}
	
	void SpeedModule ()//内容--增加行数SpeedModule用于控制时速度，姓名--刘旋，时间--2013-4-16
	{
//		if (held_flag || (ref_move_x || ref_move_y || ref_move_z)) 
		if(x_p || x_n || y_p || y_n || z_p || z_n)
			RunningSpeed = Convert.ToInt32 (speed_to_move * move_rate_pad * 1000 * 60);
		else {
			if (manualMilling && (ProgJOG || ProgREF) && !AutoRunning_flag && !MDI_RunningFlag)
				RunningSpeed =400;	
			else if ((ProgJOG || ProgREF) && !AutoRunning_flag && !MDI_RunningFlag)
				RunningSpeed = 0;	
		}
	}
	
	void ScreenNormallyOn ()
	{
		GUI.Box (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, screen_sizey / 1000f * height), "", sty_ScreenBackGround);
		GUI.Label (new Rect (corner_px / 1000f * width, corner_py / 1000f * height, screen_sizex / 1000f * width, 23f / 1000f * height), "", sty_TopLabel);
		GUI.Label (new Rect (corner_px / 1000f * width, (corner_py + 349f) / 1000f * height, 20f / 1000f * width, 25f / 1000f * height), "", sty_BottomButtonSmallest);
		GUI.Label (new Rect ((corner_px + 25f) / 1000f * width, (corner_py + 349f) / 1000f * height, 86f / 1000f * width, 25f / 1000f * height), "", sty_BottomButton_1);
		GUI.Label (new Rect ((corner_px + 115f) / 1000f * width, (corner_py + 349f) / 1000f * height, 86f / 1000f * width, 25f / 1000f * height), "", sty_BottomButton_2);
		GUI.Label (new Rect ((corner_px + 206f) / 1000f * width, (corner_py + 349f) / 1000f * height, 86f / 1000f * width, 25f / 1000f * height), "", sty_BottomButton_3);
		GUI.Label (new Rect ((corner_px + 296f) / 1000f * width, (corner_py + 349f) / 1000f * height, 86f / 1000f * width, 25f / 1000f * height), "", sty_BottomButton_4);
		GUI.Label (new Rect ((corner_px + 387f) / 1000f * width, (corner_py + 349f) / 1000f * height, 86f / 1000f * width, 25f / 1000f * height), "", sty_BottomButton_5);
		GUI.Label (new Rect ((corner_px + 477f) / 1000f * width, (corner_py + 349f) / 1000f * height, 20f / 1000f * width, 25f / 1000f * height), "", sty_BottomButtonSmallest);
	}
	
	void ScreenBottom ()
	{
		GUI.Label (new Rect ((corner_px + 305f) / 1000f * width, (corner_py - 3f) / 1000f * height, 200f / 1000f * width, 100f / 1000f * height), "O         N", sty_Title);	
		GUI.Label (new Rect ((corner_px + 327f) / 1000f * width, corner_py / 1000f * height, 200f / 1000f * width, 100f / 1000f * height), ToolNumFormat (ProgramNum), sty_ProgramName);	
		GUI.Label (new Rect ((corner_px + 416f) / 1000f * width, corner_py / 1000f * height, 200f / 1000f * width, 100f / 1000f * height), LineNumFormat (LineNum), sty_ProgramName);
		GUI.Label (new Rect (corner_px / 1000f * width, (corner_py + 283f) / 1000f * height, screen_sizex / 1000f * width, 22f / 1000f * height), "", sty_TopLabel);
		GUI.Label (new Rect ((corner_px + 3f) / 1000f * width, (corner_py + 283f) / 1000f * height, 200f / 1000f * width, 100f / 1000f * height), "A", sty_BottomAST);
		GUI.Label (new Rect ((corner_px + 20f) / 1000f * width, (corner_py + 283f) / 1000f * height, 200f / 1000f * width, 100f / 1000f * height), "> ", sty_Cursor);
		GUI.Label (new Rect ((corner_px + 330f) / 1000f * width, (corner_py + 303f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), "S              T        ", sty_BottomAST);
		GUI.Label (new Rect ((corner_px + 335f) / 1000f * width, (corner_py + 303f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), NumberFormat (SpindleSpeed), sty_SmallNum);
		GUI.Label (new Rect ((corner_px + 430f) / 1000f * width, (corner_py + 303f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), ToolNumFormat (ToolNo), sty_SmallNum);
		GUI.Label (new Rect (corner_px / 1000f * width, (corner_py + 323f) / 1000f * height, 230f / 1000f * width, 25f / 1000f * height), "", sty_BottomLabel_1);
		GUI.Label (new Rect ((corner_px + 231f) / 1000f * width, (corner_py + 323f) / 1000f * height, 45f / 1000f * width, 25f / 1000f * height), "", sty_BottomLabel_2);
		GUI.Label (new Rect ((corner_px + 277f) / 1000f * width, (corner_py + 323f) / 1000f * height, 94f / 1000f * width, 25f / 1000f * height), "", sty_BottomLabel_3);
		GUI.Label (new Rect ((corner_px + 372f) / 1000f * width, (corner_py + 323f) / 1000f * height, 125f / 1000f * width, 25f / 1000f * height), "", sty_BottomLabel_4);
		GUI.Label (new Rect ((corner_px + 8f) / 1000f * width, (corner_py + 323f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), MenuDisplay, sty_ProgModeName); 
		GUI.Label (new Rect ((corner_px + 58f) / 1000f * width, (corner_py + 326f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), "****", sty_Star);
	}
	
	void ScreenPrintArea ()
	{
		if (CursorBlink)
			GUI.Label (new Rect (ProgEDITCusorPos, (corner_py + 283f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), "_", sty_Cursor);
		
		if (InputText != "")
			GUI.Label (new Rect (InputTextPos, (corner_py + 283f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), InputText, sty_Cursor);
		
		GUI.Label (new Rect (corner_px, (corner_py + 304f) / 1000f * height, 450f / 1000f * width, 300f / 1000f * height), warnning_string, sty_Warning);
//		if(ProgProtectWarn)
//			GUI.Label(new Rect(33f,372f/1000f*height,450f/1000f*width,300f/1000f*height),"WRITE PROTECT", sty_Warning);
//			//GUI.Label(new Rect(33f,372f/1000f*height,450f/1000f*width,300f/1000f*height),"WRITE PROTECT", sty_Warning);
//		if(!ProgProtectWarn && NotFoundWarn)
//		{
//			GUI.Label(new Rect(33f,372f/1000f*height,450f/1000f*width,300f/1000f*height),"未找到字符!", sty_Warning);	
//			//NotFoundWarn = false;
//		}
		if (!EmergencyCtrl)
			GUI.Label (new Rect ((corner_px + 140f) / 1000f * width, (corner_py + 326f) / 1000f * height, 500f / 1000f * width, 300f / 1000f * height), "*** ***", sty_Star);
		 
		GUI.Label (new Rect ((corner_px + 287f) / 1000f * width, (corner_py + 325f) / 1000f * height, 300f / 1000f * width, 300f / 1000f * height), "" + System.DateTime.Now.ToString ("HH:mm:ss"), sty_ClockStyle);
		//ALM  blink
		if (Time.time - BlinkTime > 0.5f) {
			CursorBlink = !CursorBlink;
			EmergencyBlink = !EmergencyBlink;
			if (ALM_Control) {
				ALMBlink = !ALMBlink;
			}
			BlinkTime = Time.time;
		}

		if (ALMBlink) {
			GUI.Label (new Rect ((corner_px + 233f) / 1000f * width, (corner_py + 324f) / 1000f * height, 42f / 1000f * width, 22f / 1000f * height), "", sty_Alarm);
			GUI.Label (new Rect ((corner_px + 233f) / 1000f * width, (corner_py + 323f) / 1000f * height, 42f / 1000f * width, 22f / 1000f * height), "ALM", sty_AlarmLetter);
		}
			
		if (EmergencyCtrl) {
			if (EmergencyBlink) {
				GUI.Label (new Rect ((corner_px + 132f) / 1000f * width, (corner_py + 324f) / 1000f * height, 95f / 1000f * width, 22f / 1000f * height), "", sty_Alarm);
				GUI.Label (new Rect ((corner_px + 132f) / 1000f * width, (corner_py + 323f) / 1000f * height, 95f / 1000f * width, 22f / 1000f * height), " -- EMG --", sty_AlarmLetter);
			}
		}
	}
	
	[RPC]
	void NCPowerRPC(int flag)
	{
		if(flag == 1)
		{
			if (!ScreenPower) {
				sty_NCPowerOn.normal.background = t2d_NCPower_on_d;
//				ScreenCover = true;
//				power_notification = false;
				StartCoroutine (ScreenCoverSet ());
				F_operationButton (false);
				PowerDisplay();
			}
			ScreenPower = true;
		}
		else
		{
			if (ScreenPower) {
				sty_NCPowerOn.normal.background = t2d_NCPower_on_u;
//				ScreenCover = true;
				StartCoroutine (ScreenCoverSet ());
				F_operationButton (false);
				PowerDisplay();
			}
			ScreenPower = false;
		}
	}
	
	void NCPowerButton ()
	{
		//NC系统开
		if (GUI.Button (new Rect (NCPower_x / 1000f * width, NCPower_y / 1000f * height, NCPower_width / 1000f * width, NCPower_height / 1000f * height), "", sty_NCPowerOn)) {
//			NCPowerRPC(1);
			networkView.RPC("NCPowerRPC", RPCMode.All, 1); 
		}
		
		//NC系统关
		if (GUI.Button (new Rect (NCPower_x / 1000f * width, (NCPower_y + NCPower_left_y) / 1000f * height, NCPower_width / 1000f * width, NCPower_height / 1000f * height), "", sty_NCPowerOff)) {
//			NCPowerRPC(0);
			networkView.RPC("NCPowerRPC", RPCMode.All, 0); 
		}
	}
	
	[RPC]
	void F_operationButton (bool network)//内容--控制电源关闭和开启时F0，F25,F50,F100按钮的状态，姓名--刘旋，时间--2013-4-12
	{
		bool judgeFlag = ScreenPower;
		if(network)
			judgeFlag = !ScreenPower;
		if (!judgeFlag) {
			switch (RapidSpeedMode) {
			case 0:
				F0_flag = true;
				F25_flag = false;
				F50_flag = false;
				F100_flag = false;
				sty_ButtonF0.active.background = t2d_f0_on_d;
				sty_ButtonF0.normal.background = t2d_f0_on_u; 
				sty_ButtonF25.active.background = t2d_f25_off_d;
				sty_ButtonF25.normal.background = t2d_f25_off_u;
				sty_ButtonF50.active.background = t2d_f50_off_d;
				sty_ButtonF50.normal.background = t2d_f50_off_u;
				sty_ButtonF100.active.background = t2d_f100_off_d;
				sty_ButtonF100.normal.background = t2d_f100_off_u;
				
				sty_SF0.normal.background = sty_SF0_d;
				sty_SF25.normal.background = sty_SF25_u;
				sty_SF50.normal.background = sty_SF50_u;
				sty_SF100.normal.background = sty_SF100_u;
				break;
			case 1:
				F0_flag = false;
				F25_flag = true;
				F50_flag = false;
				F100_flag = false;
				sty_ButtonF25.active.background = t2d_f25_on_d;
				sty_ButtonF25.normal.background = t2d_f25_on_u;						    
				sty_ButtonF0.active.background = t2d_f0_off_d;
				sty_ButtonF0.normal.background = t2d_f0_off_u;
				sty_ButtonF50.active.background = t2d_f50_off_d;
				sty_ButtonF50.normal.background = t2d_f50_off_u;
				sty_ButtonF100.active.background = t2d_f100_off_d;
				sty_ButtonF100.normal.background = t2d_f100_off_u;
				
				sty_SF0.normal.background = sty_SF0_u;
				sty_SF25.normal.background = sty_SF25_d;
				sty_SF50.normal.background = sty_SF50_u;
				sty_SF100.normal.background = sty_SF100_u;
				break;
			case 2:
				F0_flag = false;
				F25_flag = false;
				F50_flag = true;
				F100_flag = false;
				sty_ButtonF50.active.background = t2d_f50_on_d;
				sty_ButtonF50.normal.background = t2d_f50_on_u;
				sty_ButtonF0.active.background = t2d_f0_off_d;
				sty_ButtonF0.normal.background = t2d_f0_off_u;
				sty_ButtonF25.active.background = t2d_f25_off_d;
				sty_ButtonF25.normal.background = t2d_f25_off_u;
				sty_ButtonF100.active.background = t2d_f100_off_d;
				sty_ButtonF100.normal.background = t2d_f100_off_u;
				
				sty_SF0.normal.background = sty_SF0_u;
				sty_SF25.normal.background = sty_SF25_u;
				sty_SF50.normal.background = sty_SF50_d;
				sty_SF100.normal.background = sty_SF100_u;
				break;
			case 3:
				F0_flag = false;
				F25_flag = false;
				F50_flag = false;
				F100_flag = true;
				sty_ButtonF100.active.background = t2d_f100_on_d;
				sty_ButtonF100.normal.background = t2d_f100_on_u;						    
				sty_ButtonF0.active.background = t2d_f0_off_d;
				sty_ButtonF0.normal.background = t2d_f0_off_u;
				sty_ButtonF25.active.background = t2d_f25_off_d;
				sty_ButtonF25.normal.background = t2d_f25_off_u;
				sty_ButtonF50.active.background = t2d_f50_off_d;
				sty_ButtonF50.normal.background = t2d_f50_off_u;
				
				sty_SF0.normal.background = sty_SF0_u;
				sty_SF25.normal.background = sty_SF25_u;
				sty_SF50.normal.background = sty_SF50_u;
				sty_SF100.normal.background = sty_SF100_d;
				break;
			}
		
		} else {
			sty_ButtonF0.active.background = t2d_f0_off_d;
			sty_ButtonF0.normal.background = t2d_f0_off_u; 
			sty_ButtonF25.active.background = t2d_f25_off_d;
			sty_ButtonF25.normal.background = t2d_f25_off_u;
			sty_ButtonF50.active.background = t2d_f50_off_d;
			sty_ButtonF50.normal.background = t2d_f50_off_u;
			sty_ButtonF100.active.background = t2d_f100_off_d;
			sty_ButtonF100.normal.background = t2d_f100_off_u;
			
			sty_SF0.normal.background = sty_SF0_u;
			sty_SF25.normal.background = sty_SF25_u;
			sty_SF50.normal.background = sty_SF50_u;
			sty_SF100.normal.background = sty_SF100_u;
		}
	}
	
	//NC系统启停时的按钮贴图控制
	void PowerDisplay()
	{
		if(!ScreenPower){
			SpindlePower();
		}else{
			//主轴转速控制按钮
			HUNDRED.normal.background = HUNDRED_off_u;
			HUNDRED.active.background = HUNDRED_off_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_u;
			//主轴正反转控制按钮
			sty_ButtonCW.normal.background = t2d_spCW_off_u;
			sty_ButtonCW.active.background = t2d_spCW_off_d;
			sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
			sty_ButtonCCW.active.background = t2d_spCCW_off_d;		
			sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
			sty_ButtonSTOP.active.background = t2d_spStop_off_d;
			sty_SCW.normal.background = sty_SCW_u;
			sty_SCCW.normal.background = sty_SCCW_u;
			sty_SSTOP.normal.background = sty_SSTOP_u;
		}
	}
	
	//主轴控制的按钮贴图控制
	void SpindlePower()
	{
		//主轴转速控制按钮
		if(spindleRate == 1f){
			HUNDRED.normal.background = HUNDRED_on_u;
			HUNDRED.active.background = HUNDRED_on_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_d;
		}else{
			HUNDRED.normal.background = HUNDRED_off_u;
			HUNDRED.active.background = HUNDRED_off_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_u;
		}
		//主轴正反转控制按钮
		if(spindleState == 0){
			sty_ButtonCW.normal.background = t2d_spCW_off_u;
			sty_ButtonCW.active.background = t2d_spCW_off_d;
			
			sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
			sty_ButtonCCW.active.background = t2d_spCCW_off_d;
			
			sty_ButtonSTOP.normal.background = t2d_spStop_on_u;
			sty_ButtonSTOP.active.background = t2d_spStop_on_d;	
			
			sty_SCW.normal.background = sty_SCW_u;
			sty_SCCW.normal.background = sty_SCCW_u;
			sty_SSTOP.normal.background = sty_SSTOP_d;
		}else{
			if(spindleState == 1){
				sty_ButtonCW.normal.background = t2d_spCW_on_u;
				sty_ButtonCW.active.background = t2d_spCW_on_d;
						
				sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
				sty_ButtonCCW.active.background = t2d_spCCW_off_d;
						
				sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
				sty_ButtonSTOP.active.background = t2d_spStop_off_d;
				
				sty_SCW.normal.background = sty_SCW_d;
				sty_SCCW.normal.background = sty_SCCW_u;
				sty_SSTOP.normal.background = sty_SSTOP_u;
			}else{
				sty_ButtonCCW.normal.background = t2d_spCCW_on_u;
				sty_ButtonCCW.active.background = t2d_spCCW_on_d;
						
				sty_ButtonCW.normal.background = t2d_spCW_off_u;
				sty_ButtonCW.active.background = t2d_spCW_off_d;
						
				sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
				sty_ButtonSTOP.active.background = t2d_spStop_off_d;
				
				sty_SCW.normal.background = sty_SCW_u;
				sty_SCCW.normal.background = sty_SCCW_d;
				sty_SSTOP.normal.background = sty_SSTOP_u;
			}
		}
	}
	
	/// <summary>
	/// 连接时spindle区域的贴图控制
	/// </summary>
	[RPC]
	void SpindlePowerRPC()
	{
		if(ScreenPower){
			HUNDRED.normal.background = HUNDRED_on_u;
			HUNDRED.active.background = HUNDRED_on_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_d;
			
			sty_ButtonSTOP.normal.background = t2d_spStop_on_u;
			sty_ButtonSTOP.active.background = t2d_spStop_on_d;	
			sty_SSTOP.normal.background = sty_SSTOP_d;
		}else{
			HUNDRED.normal.background = HUNDRED_off_u;
			HUNDRED.active.background = HUNDRED_off_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_u;
			
			sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
			sty_ButtonSTOP.active.background = t2d_spStop_off_d;
			sty_SSTOP.normal.background = sty_SSTOP_u;
		}
	}

	
	void ManualOperationButton ()
	{
		if((Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) && held_flag && ProgJOG)
		{
			button_status = false;
			held_flag = false;
			networkView.RPC("MoveStop", RPCMode.Server);
		}
		
		if (GUI.Button (new Rect ((Axis_x + left_x) / 1000f * width, (Axis_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonRapid)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (RapidMoveFlag) {
						RapidMoveFlag = false;
						speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
						move_rate_pad = move_rate;
						sty_ButtonRapid.normal.background = t2d_rapid_off_u;
						sty_ButtonRapid.active.background = t2d_rapid_off_d;
						sty_SRAPID.normal.background = sty_SRAPID_u;
						networkView.RPC("RapidMoveSet", RPCMode.Server, "true");
					} else {
						RapidMoveFlag = true;
						speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
						move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，不恒为1，与进给面板数值保持一致，姓名--刘旋，时间--2013-4-8
						sty_ButtonRapid.normal.background = t2d_rapid_on_u;
						sty_ButtonRapid.active.background = t2d_rapid_on_d;
						sty_SRAPID.normal.background = sty_SRAPID_d;
						networkView.RPC("RapidMoveSet", RPCMode.Server, "false");
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
				GUI.BringWindowToBack (0);
			}
		}
		
		if (GUI.Button (new Rect ((Axis_x) / 1000f * width, (Axis_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_Button4P)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					sty_S4P.normal.background = sty_S4P_d;
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else
			sty_S4P.normal.background = sty_S4P_u;
		
		if (GUI.Button (new Rect ((Axis_x) / 1000f * width, (Axis_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_Button4N)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					sty_S4N.normal.background = sty_S4N_d;
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else
			sty_S4N.normal.background = sty_S4N_u;
		
		if (GUI.RepeatButton (new Rect ((Axis_x + left_x) / 1000f * width, (Axis_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonYN)) {
			if (ScreenPower) {
				sty_SYN.normal.background = sty_SYN_d;
				if(!EmergencyCtrl){
					if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
						if (RapidMoveFlag) {
							speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
							move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
							switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
							case 0://模式0（即;F0状态）
								speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
								break;
							case 1://模式0（即;F25状态）
								speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
								break;
							case 2://模式0（即;F50状态）
								speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
								break;
							case 3://模式0（即;F100状态）
								speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
								break;
							}//增加内容到此  2013-4-9
						} else {
							speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8				
							move_rate_pad = move_rate;
						}
	
						if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.y > -500f)
						{
							held_flag = true;
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							button_status = true;
							networkView.RPC("YN_Button", RPCMode.Server, speed_str);
						}
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else {
			sty_SYN.normal.background = sty_SYN_u;
//			MoveControl_script.y_n = false;
		}
		
		if (GUI.RepeatButton (new Rect ((Axis_x + 2 * left_x) / 1000f * width, (Axis_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonXN)) {
			if (ScreenPower) {
				sty_SXN.normal.background = sty_SXN_d;
				if(!EmergencyCtrl){
					if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
						if (RapidMoveFlag) {
							speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
							move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
							switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
							case 0://模式0（即;F0状态）
								speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
								break;
							case 1://模式0（即;F25状态）
								speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
								break;
							case 2://模式0（即;F50状态）
								speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
								break;
							case 3://模式0（即;F100状态）
								speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
								break;	
										
							}//增加内容到此  2013-4-9
						} else {
							speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
							move_rate_pad = move_rate;
						}
						if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.x > -800f)
						{
							held_flag = true;
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							button_status = true;
							networkView.RPC("XN_Button", RPCMode.Server, speed_str);
						}
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else {
//			MoveControl_script.x_n = false;
			sty_SXN.normal.background = sty_SXN_u;
		}
		
		if (GUI.RepeatButton (new Rect ((Axis_x + 2 * left_x) / 1000f * width, (Axis_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonZN)) {
			if (ScreenPower) {
				sty_SZN.normal.background = sty_SZN_d;
				if(!EmergencyCtrl){
					if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
						if (RapidMoveFlag) {
							speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
							move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
							switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
							case 0://模式0（即;F0状态）
								speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
								break;
							case 1://模式0（即;F25状态）
								speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
								break;
							case 2://模式0（即;F50状态）
								speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
								break;
							case 3://模式0（即;F100状态）
								speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
								break;	
										
							}//增加内容到此  2013-4-9
						} else {
							speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
							move_rate_pad = move_rate;
						}
						
						if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.z > -510f)
						{
							held_flag = true;
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							button_status = true;
							networkView.RPC("ZN_Button", RPCMode.Server, speed_str);
						}
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else {
//			MoveControl_script.z_n = false;
			sty_SZN.normal.background = sty_SZN_u;
		}
		
		if (ProgREF) {
			if (GUI.Button (new Rect ((Axis_x + 2 * left_x) / 1000f * width, Axis_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonZP)) {
				if (ScreenPower) {
					if(!EmergencyCtrl){
						move_rate_pad = 1f;//内容--归零模式下，实际进给速率倍率的修改，恒为1,姓名--刘旋，时间--2013-4-11
						speed_to_move = 0.333333F;//内容--归零操作的实际速度为20m/min=0.333333m/s，而实际速度RunningSpeed=speed—to-move*move-rate，因此speed-to-move应设为0.333333姓名--刘旋，时间--2013-4-8
						if (!z_return_zero && !AutoRunning_flag && !MDI_RunningFlag) {
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							networkView.RPC("ZP_Button", RPCMode.Server, speed_str);
	//						MoveControl_script.z_p = true;
							beModifed = true;
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
			
			if (GUI.Button (new Rect (Axis_x / 1000f * width, (Axis_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonXP)) {
				if (ScreenPower) {
					if(!EmergencyCtrl){
						move_rate_pad = 1f;//内容--归零模式下，实际进给速率倍率的修改，恒为1,姓名--刘旋，时间--2013-4-11
						speed_to_move = 0.333333F;//内容--归零操作的实际速度为10m/min=0.1667m/s，而实际速度RunningSpeed=speed—to-move*move-rate，因此speed-to-move应设为0.1667,姓名--刘旋，时间--2013-4-8
						if (!x_return_zero && !AutoRunning_flag && !MDI_RunningFlag) {
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							networkView.RPC("XP_Button", RPCMode.Server, speed_str);
	//						MoveControl_script.x_p = true;
							beModifed = true;
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
			
			if (GUI.Button (new Rect ((Axis_x + left_x) / 1000f * width, (Axis_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonYP)) {
				if (ScreenPower) {
					if(!EmergencyCtrl){
						move_rate_pad = 1f;//内容--归零模式下，实际进给速率倍率的修改，恒为1,姓名--刘旋，时间--2013-4-11
						speed_to_move = 0.333333F;//内容--归零操作的实际速度为10m/min=0.1667m/s，而实际速度RunningSpeed=speed—to-move*move-rate，因此speed-to-move应设为0.1667,姓名--刘旋，时间--2013-4-8
						if (!y_return_zero && !AutoRunning_flag && !MDI_RunningFlag) {
							string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
							networkView.RPC("YP_Button", RPCMode.Server, speed_str);
	//						MoveControl_script.y_p = true;
							beModifed = true;
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		} else {
			if (GUI.RepeatButton (new Rect ((Axis_x + 2 * left_x) / 1000f * width, Axis_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonZP)) {
				if (ScreenPower) {
					sty_SZP.normal.background = sty_SZP_d;
					if(!EmergencyCtrl){
						if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
							if (RapidMoveFlag) {
								speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
								move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
								switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
								case 0://模式0（即;F0状态）
									speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
									break;
								case 1://模式0（即;F25状态）
									speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
									break;
								case 2://模式0（即;F50状态）
									speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
									break;
								case 3://模式0（即;F100状态）
									speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
									break;	
											
								}//增加内容到此  2013-4-9
							} else {
								speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
								move_rate_pad = move_rate;
							}
	
							if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.z < 0)
							{
								held_flag = true;
								string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
								button_status = true;
								networkView.RPC("ZP_Button", RPCMode.Server, speed_str);
							}
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else {
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
				}
			} else {
//				MoveControl_script.z_p = false;
				sty_SZP.normal.background = sty_SZP_u;
			}
			
			if (GUI.RepeatButton (new Rect (Axis_x / 1000f * width, (Axis_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonXP)) {
				if (ScreenPower) {
					sty_SXP.normal.background = sty_SXP_d;
					if(!EmergencyCtrl){
						if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
							if (RapidMoveFlag) {
								speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
								move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
								switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
								case 0://模式0（即;F0状态）
									speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
									break;
								case 1://模式0（即;F25状态）
									speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
									break;
								case 2://模式0（即;F50状态）
									speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
									break;
								case 3://模式0（即;F100状态）
									speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
									break;	
											
								}//增加内容到此  2013-4-9
							} else {
								speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8
								move_rate_pad = move_rate;
							}
							
							if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.x < 0)
							{
								held_flag = true;
								string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
								button_status = true;
								networkView.RPC("XP_Button", RPCMode.Server, speed_str);
							}
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else {
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
				}
			} else {
//				MoveControl_script.x_p = false;
				sty_SXP.normal.background = sty_SXP_u;
			}
			
			if (GUI.RepeatButton (new Rect ((Axis_x + left_x) / 1000f * width, (Axis_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonYP)) {
				if (ScreenPower) {
					sty_SYP.normal.background = sty_SYP_d;
					if(!EmergencyCtrl){
						if (ProgJOG && !AutoRunning_flag && !MDI_RunningFlag) {
							if (RapidMoveFlag) {
								speed_to_move = 0.16667F;//内容--JOG模式下，快常速为10m/min=(10/60)m/s,因此spee-to-move=10/60,姓名--刘旋，时间--2013-4-8
								move_rate_pad = 1f;//内容--JOG模式下，实际进给速率倍率的修改，恒为1，姓名--刘旋，时间--2013-4-11
								switch (RapidSpeedMode) {//内容--快常速四种状态作用于实际速度，姓名--刘旋，时间--2013-4-9
								case 0://模式0（即;F0状态）
									speed_to_move = 0.0005f * speed_to_move;//F0模式下，为停止，即：实际速度为0
									break;
								case 1://模式0（即;F25状态）
									speed_to_move = 0.25f * speed_to_move;//F25模式下，实际速度为快常速的25%
									break;
								case 2://模式0（即;F50状态）
									speed_to_move = 0.5f * speed_to_move;//F50模式下，实际速度为快常速的50%
									break;
								case 3://模式0（即;F100状态）
									speed_to_move = 1f * speed_to_move;//F100模式下，实际速度等于快常速
									break;	
											
								}//增加内容到此  2013-4-9
							} else {
								speed_to_move = 0.08333F;//内容--JOG模式下，慢常速为5m/min=(5/60)m/s,因此spee-to-move=5/60,姓名--刘旋，时间--2013-4-8						
								move_rate_pad = move_rate;
							}
							
							if((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && button_status == false && MachineCoo.y < 0)
							{
								held_flag = true;
								string speed_str = speed_to_move.ToString() + "," + move_rate_pad.ToString();
								button_status = true;
								networkView.RPC("YP_Button", RPCMode.Server, speed_str);
							}
						}
					}else{
						PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
					}
				} else {
					PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
				}
			} else {
//				MoveControl_script.y_p = false;
				sty_SYP.normal.background = sty_SYP_u;
			}
		}
	}
	
	public void SpindleControlFromPC(int info)
	{
		switch(info)
		{
		case 0:
			F0_flag = true;
			F25_flag = false;
			F50_flag = false;
			F100_flag = false;
			sty_SF0.normal.background = sty_SF0_d;
			sty_SF25.normal.background = sty_SF25_u;
			sty_SF50.normal.background = sty_SF50_u;
			sty_SF100.normal.background = sty_SF100_u;
			sty_ButtonF0.active.background = t2d_f0_on_d;
			sty_ButtonF0.normal.background = t2d_f0_on_u; 
			sty_ButtonF25.active.background = t2d_f25_off_d;
			sty_ButtonF25.normal.background = t2d_f25_off_u;
			sty_ButtonF50.active.background = t2d_f50_off_d;
			sty_ButtonF50.normal.background = t2d_f50_off_u;
			sty_ButtonF100.active.background = t2d_f100_off_d;
			sty_ButtonF100.normal.background = t2d_f100_off_u;
			RapidSpeedMode = 0;//快常速模式状态为0
			break;
		case 1:
			F0_flag = false;
			F25_flag = true;
			F50_flag = false;
			F100_flag = false;
			sty_SF0.normal.background = sty_SF0_u;
			sty_SF25.normal.background = sty_SF25_d;
			sty_SF50.normal.background = sty_SF50_u;
			sty_SF100.normal.background = sty_SF100_u;
			sty_ButtonF25.active.background = t2d_f25_on_d;
			sty_ButtonF25.normal.background = t2d_f25_on_u;						    
			sty_ButtonF0.active.background = t2d_f0_off_d;
			sty_ButtonF0.normal.background = t2d_f0_off_u;
			sty_ButtonF50.active.background = t2d_f50_off_d;
			sty_ButtonF50.normal.background = t2d_f50_off_u;
			sty_ButtonF100.active.background = t2d_f100_off_d;
			sty_ButtonF100.normal.background = t2d_f100_off_u;
			RapidSpeedMode = 1;//快常速模式状态为1
			break;
		case 2:
			F0_flag = false;
			F25_flag = false;
			F50_flag = true;
			F100_flag = false;
			sty_SF0.normal.background = sty_SF0_u;
			sty_SF25.normal.background = sty_SF25_u;
			sty_SF50.normal.background = sty_SF50_d;
			sty_SF100.normal.background = sty_SF100_u;
			sty_ButtonF50.active.background = t2d_f50_on_d;
			sty_ButtonF50.normal.background = t2d_f50_on_u;
			sty_ButtonF0.active.background = t2d_f0_off_d;
			sty_ButtonF0.normal.background = t2d_f0_off_u;
			sty_ButtonF25.active.background = t2d_f25_off_d;
			sty_ButtonF25.normal.background = t2d_f25_off_u;
			sty_ButtonF100.active.background = t2d_f100_off_d;
			sty_ButtonF100.normal.background = t2d_f100_off_u;
			RapidSpeedMode = 2;//快常速模式状态为2
			break;
		case 3:
			F0_flag = false;
			F25_flag = false;
			F50_flag = false;
			F100_flag = true;
			sty_SF0.normal.background = sty_SF0_u;
			sty_SF25.normal.background = sty_SF25_u;
			sty_SF50.normal.background = sty_SF50_u;
			sty_SF100.normal.background = sty_SF100_d;
			sty_ButtonF100.active.background = t2d_f100_on_d;
			sty_ButtonF100.normal.background = t2d_f100_on_u;						    
			sty_ButtonF0.active.background = t2d_f0_off_d;
			sty_ButtonF0.normal.background = t2d_f0_off_u;
			sty_ButtonF25.active.background = t2d_f25_off_d;
			sty_ButtonF25.normal.background = t2d_f25_off_u;
			sty_ButtonF50.active.background = t2d_f50_off_d;
			sty_ButtonF50.normal.background = t2d_f50_off_u;	
			RapidSpeedMode = 3;//快常速模式状态为3
			break;
		}

	}
	
	void SpindleControl ()
	{
		if (GUI.Button (new Rect (Rapid_x / 1000f * width, Rapid_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonF0)) {//内容--修改F0按钮的图片显示，姓名--刘旋，时间2013-4-8
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (ProgJOG) {//内容--JOG模式下，实现F0按钮的功能，姓名--刘旋，时间--2013-4-9
						if (RapidMoveFlag) {//内容，在快速模式下，F0的功能，姓名--刘旋，时间--2013-4-11
							F0_flag = true;
							F25_flag = false;
							F50_flag = false;
							F100_flag = false;
							sty_SF0.normal.background = sty_SF0_d;
							sty_SF25.normal.background = sty_SF25_u;
							sty_SF50.normal.background = sty_SF50_u;
							sty_SF100.normal.background = sty_SF100_u;
							sty_ButtonF0.active.background = t2d_f0_on_d;
							sty_ButtonF0.normal.background = t2d_f0_on_u; 
							sty_ButtonF25.active.background = t2d_f25_off_d;
							sty_ButtonF25.normal.background = t2d_f25_off_u;
							sty_ButtonF50.active.background = t2d_f50_off_d;
							sty_ButtonF50.normal.background = t2d_f50_off_u;
							sty_ButtonF100.active.background = t2d_f100_off_d;
							sty_ButtonF100.normal.background = t2d_f100_off_u;
							RapidSpeedMode = 0;//快常速模式状态为0  
							Client_Script.F_operationButtonClient(0);
						} else {//内容--慢速模式下，F0按钮的功能。姓名--刘旋，时间--2013-4-9
							
						}
					}//增加内容到此  2013-4-9
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + left_x) / 1000f * width, Rapid_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonF25)) {//内容--修改25%按钮的图片显示，姓名--刘旋，时间2013-4-8
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (ProgJOG) {//内容--JOG模式下，实现F25按钮的功能，姓名--刘旋，时间--2013-4-9
						if (RapidMoveFlag) {//内容，在快速模式下，F25的功能，姓名--刘旋，时间--2013-4-11
							F0_flag = false;
							F25_flag = true;
							F50_flag = false;
							F100_flag = false;
							sty_SF0.normal.background = sty_SF0_u;
							sty_SF25.normal.background = sty_SF25_d;
							sty_SF50.normal.background = sty_SF50_u;
							sty_SF100.normal.background = sty_SF100_u;
							sty_ButtonF25.active.background = t2d_f25_on_d;
							sty_ButtonF25.normal.background = t2d_f25_on_u;						    
							sty_ButtonF0.active.background = t2d_f0_off_d;
							sty_ButtonF0.normal.background = t2d_f0_off_u;
							sty_ButtonF50.active.background = t2d_f50_off_d;
							sty_ButtonF50.normal.background = t2d_f50_off_u;
							sty_ButtonF100.active.background = t2d_f100_off_d;
							sty_ButtonF100.normal.background = t2d_f100_off_u;
							RapidSpeedMode = 1;//快常速模式状态为1
							Client_Script.F_operationButtonClient(1);
						
						} else {//内容--慢速模式下，F25按钮的功能。姓名--刘旋，时间--2013-4-9
							
						}
					}//增加内容到此  2013-4-9
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 2 * left_x) / 1000f * width, Rapid_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonF50)) {//内容--修改50%按钮的图片显示，姓名--刘旋，时间2013-4-8
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (ProgJOG) {//内容--JOG模式下，实现F50按钮的功能，姓名--刘旋，时间--2013-4-9
						if (RapidMoveFlag) {//内容，在快速模式下，F50的功能，姓名--刘旋，时间--2013-4-11
							F0_flag = false;
							F25_flag = false;
							F50_flag = true;
							F100_flag = false;
							sty_SF0.normal.background = sty_SF0_u;
							sty_SF25.normal.background = sty_SF25_u;
							sty_SF50.normal.background = sty_SF50_d;
							sty_SF100.normal.background = sty_SF100_u;
							sty_ButtonF50.active.background = t2d_f50_on_d;
							sty_ButtonF50.normal.background = t2d_f50_on_u;
							sty_ButtonF0.active.background = t2d_f0_off_d;
							sty_ButtonF0.normal.background = t2d_f0_off_u;
							sty_ButtonF25.active.background = t2d_f25_off_d;
							sty_ButtonF25.normal.background = t2d_f25_off_u;
							sty_ButtonF100.active.background = t2d_f100_off_d;
							sty_ButtonF100.normal.background = t2d_f100_off_u;
							RapidSpeedMode = 2;//快常速模式状态为2
							Client_Script.F_operationButtonClient(2);	
						} else {//内容--慢速模式下，F50按钮的功能。姓名--刘旋，时间--2013-4-9
						}
					}//增加内容到此  2013-4-9
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 3 * left_x) / 1000f * width, Rapid_y / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonF100)) {//内容--修改100%按钮的图片显示，姓名--刘旋，时间2013-4-8
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (ProgJOG) {//内容--JOG模式下，实现F100按钮的功能，姓名--刘旋，时间--2013-4-9
						if (RapidMoveFlag) {//内容，在快速模式下，F100的功能，姓名--刘旋，时间--2013-4-11
							F0_flag = false;
							F25_flag = false;
							F50_flag = false;
							F100_flag = true;
							sty_SF0.normal.background = sty_SF0_u;
							sty_SF25.normal.background = sty_SF25_u;
							sty_SF50.normal.background = sty_SF50_u;
							sty_SF100.normal.background = sty_SF100_d;
							sty_ButtonF100.active.background = t2d_f100_on_d;
							sty_ButtonF100.normal.background = t2d_f100_on_u;						    
							sty_ButtonF0.active.background = t2d_f0_off_d;
							sty_ButtonF0.normal.background = t2d_f0_off_u;
							sty_ButtonF25.active.background = t2d_f25_off_d;
							sty_ButtonF25.normal.background = t2d_f25_off_u;
							sty_ButtonF50.active.background = t2d_f50_off_d;
							sty_ButtonF50.normal.background = t2d_f50_off_u;	
							RapidSpeedMode = 3;//快常速模式状态为3
							Client_Script.F_operationButtonClient(3);
							
						} else {//内容--慢速模式下，F100按钮的功能。姓名--刘旋，时间--2013-4-9
						}
					}//增加内容到此  2013-4-9
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x) / 1000f * width, (Rapid_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", EMPTY)) {
			if (ScreenPower) {
				
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + left_x) / 1000f * width, (Rapid_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", Axis_DOWN)) {
			if (ScreenPower) {
				if (!EmergencyCtrl) {
					if (spindleState != 0){
						networkView.RPC("SpindleUpDown", RPCMode.All, 0);
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 2 * left_x) / 1000f * width, (Rapid_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", HUNDRED)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					networkView.RPC("SpindleUpDown", RPCMode.All, 1);
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 3 * left_x) / 1000f * width, (Rapid_y + left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", Axis_UP)) {
			if (ScreenPower) {
				if (!EmergencyCtrl) {
					if (spindleState != 0) {
						networkView.RPC("SpindleUpDown", RPCMode.All, 2);
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
			
		if (GUI.Button (new Rect ((Rapid_x) / 1000f * width, (Rapid_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", ORIENT)) {
			if (ScreenPower) {
				if (!EmergencyCtrl) {
					networkView.RPC("SpindleOrient", RPCMode.All, true);
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + left_x) / 1000f * width, (Rapid_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonCW)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (RotateSpeed != 0 && !AutoRunning_flag && !MDI_RunningFlag) {
						SpindleCW ((int)RotateSpeed);
						networkView.RPC("SpindleCWRPC", RPCMode.Server, SpindleSpeed);
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 2 * left_x) / 1000f * width, (Rapid_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonSTOP)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if(!AutoRunning_flag && !MDI_RunningFlag){
						SpindleStop ();
						networkView.RPC("SpindleStopRPC", RPCMode.Server);
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		}
		
		if (GUI.Button (new Rect ((Rapid_x + 3 * left_x) / 1000f * width, (Rapid_y + 2 * left_y) / 1000f * height, btn_width / 1000f * width, btn_height / 1000f * height), "", sty_ButtonCCW)) {
			if (ScreenPower) {
				if(!EmergencyCtrl){
					if (RotateSpeed != 0 && !AutoRunning_flag && !MDI_RunningFlag) {
						SpindleCCW ((int)RotateSpeed);
						networkView.RPC("SpindleCCWRPC", RPCMode.Server, SpindleSpeed);
					}
				}else{
					PopupMessage_Script.Popup("请先旋松紧急停止按钮！");
				}
			} else {
				PopupMessage_Script.Popup("NC系统处于关闭状态，请先打开NC系统电源开关！");
			}
		}
	}
	
	public void SpindleCW (int speed)
	{
		if(!manual_tool_change && (ProgJOG || ProgHAN)){
			SpindleSpeed = speed;
			main_axis_on = true;
			spindleState = 1;		
			networkView.RPC("SpindleOrient", RPCMode.All, false);
			sty_ButtonCW.normal.background = t2d_spCW_on_u;
			sty_ButtonCW.active.background = t2d_spCW_on_d;
					
			sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
			sty_ButtonCCW.active.background = t2d_spCCW_off_d;
					
			sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
			sty_ButtonSTOP.active.background = t2d_spStop_off_d;
			
			sty_SCW.normal.background = sty_SCW_d;
			sty_SCCW.normal.background = sty_SCCW_u;
			sty_SSTOP.normal.background = sty_SSTOP_u;
		}
	}
	
	public void SpindleStop ()
	{
		SpindleSpeed = 0;
		main_axis_on = false;
		spindleState = 0;	
		sty_ButtonCW.normal.background = t2d_spCW_off_u;
		sty_ButtonCW.active.background = t2d_spCW_off_d;
		
		sty_ButtonCCW.normal.background = t2d_spCCW_off_u;
		sty_ButtonCCW.active.background = t2d_spCCW_off_d;
				
		sty_ButtonSTOP.normal.background = t2d_spStop_on_u;
		sty_ButtonSTOP.active.background = t2d_spStop_on_d;
		
		sty_SCW.normal.background = sty_SCW_u;
		sty_SCCW.normal.background = sty_SCCW_u;
		sty_SSTOP.normal.background = sty_SSTOP_d;
	}
	
	public void SpindleCCW (int speed)
	{
		if(!manual_tool_change && (ProgJOG || ProgHAN)){
			SpindleSpeed = speed;
			main_axis_on = true;
			spindleState = 2;	
			networkView.RPC("SpindleOrient", RPCMode.All, false);
			sty_ButtonCCW.normal.background = t2d_spCCW_on_u;
			sty_ButtonCCW.active.background = t2d_spCCW_on_d;
					
			sty_ButtonCW.normal.background = t2d_spCW_off_u;
			sty_ButtonCW.active.background = t2d_spCW_off_d;
					
			sty_ButtonSTOP.normal.background = t2d_spStop_off_u;
			sty_ButtonSTOP.active.background = t2d_spStop_off_d;
			
			sty_SCW.normal.background = sty_SCW_u;
			sty_SCCW.normal.background = sty_SCCW_d;
			sty_SSTOP.normal.background = sty_SSTOP_u;
		}
	}
	
	[RPC]
	void SpindleCWRPC(int speed)
	{
		SpindleCW(speed);
	}
	
	[RPC]
	void SpindleStopRPC()
	{
		SpindleStop();
		networkView.RPC("SpindleUpDown", RPCMode.All, 1);
	}
	
	[RPC]
	void SpindleCCWRPC(int speed)
	{
		SpindleCCW(speed);
	}
	
	[RPC]
	void SpindleUpDown(int type)
	{
		switch(type)
		{
		case 0:
			if(spindleRate > 0.5f)
				spindleRate -= 0.1f;
			if(spindleRate == 1){
				HUNDRED.normal.background = HUNDRED_on_u;
				HUNDRED.active.background = HUNDRED_on_d;
				sty_SHUNDRED.normal.background = sty_SHUNDRED_d;
			}else{
				HUNDRED.normal.background = HUNDRED_off_u;
				HUNDRED.active.background = HUNDRED_off_d;
				sty_SHUNDRED.normal.background = sty_SHUNDRED_u;
			}
			break;
		case 1:
			spindleRate = 1;
			HUNDRED.normal.background = HUNDRED_on_u;
			HUNDRED.active.background = HUNDRED_on_d;
			sty_SHUNDRED.normal.background = sty_SHUNDRED_d;
			break;
		case 2:
			if(spindleRate < 1.5f)
				spindleRate += 0.1f;
			if(spindleRate == 1){
				HUNDRED.normal.background = HUNDRED_on_u;
				HUNDRED.active.background = HUNDRED_on_d;
				sty_SHUNDRED.normal.background = sty_SHUNDRED_d;
			}else{
				HUNDRED.normal.background = HUNDRED_off_u;
				HUNDRED.active.background = HUNDRED_off_d;
				sty_SHUNDRED.normal.background = sty_SHUNDRED_u;
			}
			break;
		default:
			break;
		}
	}
	
	public void OrientControl(bool state)
	{
		networkView.RPC("SpindleOrient", RPCMode.All, state);
	}
	[RPC]
	void SpindleOrient(bool state)
	{
		if(state){
			if(spindleState != 0){
			}else{
				ORIENT.normal.background = ORIENT_on_u;
				ORIENT.active.background = ORIENT_on_d;
				sty_SORIENT.normal.background = sty_SORIENT_d;
			}
		}else{
			ORIENT.normal.background = ORIENT_off_u;
			ORIENT.active.background = ORIENT_off_d;
			sty_SORIENT.normal.background = sty_SORIENT_u;
		}
	}

	
	[RPC]
	void ManualRPC(bool flag)
	{
		manual_tool_change = flag;
	}
	
	//格式化显示数字
	public string CooStringFormat (float StrValue)
	{
		StrValue = (float)Math.Round(StrValue,3);
		int dot_pos = -1;
		int intNum = 0;	
		string DisplayStr = "";
		intNum = (int)StrValue;
		if (intNum < 0) {
			if (intNum > -100 && intNum <= -10)
				DisplayStr = "    ";
			else if (intNum > -10)
				DisplayStr = "     ";
			else if (intNum <= -100 && intNum > -1000)
				DisplayStr = "   ";
			else if (intNum <= -1000 && intNum > -10000)
				DisplayStr = "  ";
			else if (intNum <= -10000 && intNum > -100000)
				DisplayStr = " ";
			else
				DisplayStr = "";
		} else if (intNum == 0) {
			if (StrValue < 0)
				DisplayStr = "     ";
			else		
				DisplayStr = "      ";
		} else {
			if (intNum < 100 && intNum >= 10)
				DisplayStr = "     ";
			else if (intNum < 10)
				DisplayStr = "      ";
			else if (intNum < 1000 && intNum >= 100)	
				DisplayStr = "    ";
			else if (intNum < 10000 && intNum >= 1000)
				DisplayStr = "   ";
			else if (intNum < 100000 && intNum >= 10000)
				DisplayStr = "  ";
			else if (intNum < 1000000 && intNum >= 100000)
				DisplayStr = " ";
			else
				DisplayStr = "";
		}
		DisplayStr +=StrValue.ToString();
		dot_pos = DisplayStr.IndexOf (".");
		if(dot_pos == -1)
			DisplayStr +=".000";
		else if((DisplayStr.Length - dot_pos) <= 3)
		{
			if((DisplayStr.Length - dot_pos) == 2)
				DisplayStr += "00";
			if((DisplayStr.Length - dot_pos) == 3)
				DisplayStr +="0";
		}
		return DisplayStr;
	}
	
	//整数格式化显示
	public string NumberFormat (int C_Num)
	{
		string C_Str = "";
		if (C_Num >= 100000)
			C_Str = "" + C_Num;
		else if (C_Num < 100000 && C_Num >= 10000)
			C_Str = " " + C_Num;
		else if (C_Num < 10000 && C_Num >= 1000)
			C_Str = "  " + C_Num;
		else if (C_Num < 1000 && C_Num >= 100)
			C_Str = "   " + C_Num;
		else if (C_Num < 100 && C_Num >= 10)	
			C_Str = "    " + C_Num;
		else	
			C_Str = "     " + C_Num;	
		return C_Str;	
	}
	
	//刀具号格式化显示
	public string ToolNumFormat (int T_Num)
	{
		string T_Str = "";
		if (T_Num >= 1000)
			T_Str = "" + T_Num;
		else if (T_Num < 1000 && T_Num >= 100)	
			T_Str = "0" + T_Num;
		else if (T_Num < 100 && T_Num >= 10)
			T_Str = "00" + T_Num;
		else	
			T_Str = "000" + T_Num;
		return T_Str;	
	}
	
	//行号格式化显示
	string LineNumFormat (int T_Num)
	{
		string T_Str = "";
		if (T_Num >= 10000)	
			T_Str = "" + T_Num;
		else if (T_Num < 10000 && T_Num >= 1000)	
			T_Str = "0" + T_Num;
		else if (T_Num < 1000 && T_Num >= 100)	
			T_Str = "00" + T_Num;
		else if (T_Num < 100 && T_Num >= 10)
			T_Str = "000" + T_Num;
		else
			T_Str = "0000" + T_Num;	
		return T_Str;	
	}
	
	//系统启动白屏画面控制
	IEnumerator ScreenCoverSet ()
	{
		yield return new WaitForSeconds(0.3f);
		ScreenCover = false;	
	}
	
	//设定界面修改---陈振华---03.11
	//使设定输入右对齐，顺序号停止参数
	public string ArguStringGet (string StrValue)
	{
		string DisplayStr = "";
		if (StrValue.Length == 1)
			DisplayStr = "       " + StrValue;
		else if (StrValue.Length == 2)
			DisplayStr = "      " + StrValue;
		else if (StrValue.Length == 3)
			DisplayStr = "     " + StrValue;
		else if (StrValue.Length == 4)
			DisplayStr = "    " + StrValue;
		else if (StrValue.Length == 5)
			DisplayStr = "   " + StrValue;
		else if (StrValue.Length == 6)
			DisplayStr = "  " + StrValue;
		else if (StrValue.Length == 7)
			DisplayStr = " " + StrValue;
		return DisplayStr;	
	}
	
	//使设定输入右对齐，IO参数
	public string ArguStringGet_IO (string StrValue)
	{
		string DisplayStr = "";
		if (StrValue.Length == 1)
			DisplayStr = " " + StrValue;
		else if (StrValue.Length == 2)
			DisplayStr = StrValue;
		return DisplayStr;	
	}
	
	//刀偏界面加入---陈振华---03.30
	//格式化显示数字,刀偏界面
	public string ToolStringGet (float StrValue)
	{
		int intNum = 0;	
		string DisplayStr = "";
		intNum = (int)StrValue;
		
		if (intNum < 0) {
			if (intNum > -100 && intNum <= -10)
				DisplayStr = "  " + intNum + ".";
			else if (intNum > -10)
				DisplayStr = "   " + intNum + ".";
			else if (intNum <= -100 && intNum > -1000)
				DisplayStr = " " + intNum + ".";
			else
				DisplayStr = "" + intNum + ".";
		} else if (intNum == 0) {
			if (StrValue < 0)
				DisplayStr = "   -0.";
			else		
				DisplayStr = "    0" + ".";
		} else {
			if (intNum < 100 && intNum >= 10)
				DisplayStr = "   " + intNum + ".";
			else if (intNum < 10)
				DisplayStr = "    " + intNum + ".";
			else if (intNum < 1000 && intNum >= 100)	
				DisplayStr = "  " + intNum + ".";
			else	
				DisplayStr = " " + intNum + ".";
		}
		
		intNum = (int)(Math.Abs (StrValue * 10) % 10);
		DisplayStr += intNum;
		intNum = (int)(Math.Abs (StrValue * 100) % 10);
		DisplayStr += intNum;
		intNum = (int)(Math.Abs (StrValue * 1000) % 10);
		DisplayStr += intNum;
		return DisplayStr;	
	}
	
	//刀偏界面加入---陈振华---03.30
	//使刀偏界面的序号为3位
	public string Tool_numberGet (int StrValue)
	{
		string StringValue = StrValue.ToString ();
		string DisplayStr = "";
		if (StringValue.Length == 1)
			DisplayStr = "00" + StringValue;
		if (StringValue.Length == 2)
			DisplayStr = "0" + StringValue;
		if (StringValue.Length == 3)
			DisplayStr = StringValue;
		return DisplayStr;
	}
	
	//警告信息创建
	public void WarnningMessageCreate (string warnning)
	{
		warnning_string = warnning;
	}
	
	//警告信息清空
	public void WarnningClear ()
	{
		warnning_string = "";
	}
	
	//警告信息RPC
	[RPC]
	void WarnningRPC(string message)
	{
		
	}
	
	//手轮转动停止控制
	[RPC]
	void HandStopRPC (string axis_str)
	{
		string[] axisArray = axis_str.Split(',');
		switch(axisArray[0]){
		case "xn":
			if(axisArray[1] == "True")
				MillingData.cxn = true;
			else
				MillingData.cxn = false;
			break;
		case "xp":
			if(axisArray[1] == "True")
				MillingData.cxp = true;
			else
				MillingData.cxp = false;
			break;
		case "yn":
			if(axisArray[1] == "True")
				MillingData.cyn = true;
			else
				MillingData.cyn = false;
			break;
		case "yp":
			if(axisArray[1] == "True")
				MillingData.cyp = true;
			else
				MillingData.cyp = false;
			break;
		case "zn":
			if(axisArray[1] == "True")
				MillingData.czn = true;
			else
				MillingData.czn = false;
			break;
		case "zp":
			if(axisArray[1] == "True")
				MillingData.czp = true;
			else
				MillingData.czp = false;
			break;
		default:
			break;
		}
	}
	
	//弹出警告窗口
	[RPC]
	void PopupMessage(string messageStr){
		PopupMessage_Script.Popup(messageStr);
	}
}
