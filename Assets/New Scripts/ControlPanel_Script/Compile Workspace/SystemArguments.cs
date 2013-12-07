using UnityEngine;
using System.Collections;

public enum WorkpieceCooSys {G00, G54, G55, G56, G57, G58, G59}

public enum Lights{
		MACHINE,
		MAG,
		AIRorLUB,
		X,
		Y,
		Z,
		FourTH
	};

public struct SystemArguments
{
	public const float PanelWindow_Width = 740f;  //完整面板宽度 760
	public const float PanelWindow_Height = 760f;  //完整面板高度 800
//	public const float SmallScreen_Width = 397.1f;
//	public const float SmallScreen_Heght = 312.8f;
	public const float SmallScreen_Width = 426f;  //小面板宽度
	public const float SmallScreen_Heght = 384f;  //小面板高度
	public const float RapidMoveSpeed = 20000f;  //快速移动的速度
//	public const string CoordinatePath = "/Resources/Coordinate/";  
	public const string NCCodePath = "/Resources/NC Code/";  //NC代码路径
	public const string NCCodePathOpen = "\\Resources\\NC Code\\";  //NC代码文件夹打开路径
	public const string BackupCodePath = "/Resources/Backup/";  //代码备份路径
//	public const string ToolParameterPath = "/Resources/ToolParameter/";  
//	public Vector3 G92_temp;	
	public const string ToolsConfigFilePath = "/Resources/ConfigurationFiles/CuttingToolsConfig.ini";  //刀具信息初始化路径
	public const int CirclePrecision = 20;  //圆弧精度控制
	public const float EditLength1 = 345f;  //EDIT部分的单行代码最长长度
	public const float AutoLength1 = 370f;  //AUTO部分的单行代码最长长度
	public const float CursorLength = 340f;  //屏幕下方字符输入区的最大长度
	public const int EditLineNumber = 9;  //EDIT程序显示行数
	public const int AutoLongLineNumber = 9;  //AUTO程序全部显示行数
	public const int AutoPartLineNumber = 4;  //AUTO程序部分显示行数
	public const int ConnectPort = 20138;  //创建服务器的端口号
	
	public const string BlankName = "Blank01";
	
	//WindowID:  0-16, 52-57
}
