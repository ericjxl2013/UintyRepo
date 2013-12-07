using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.GZip;
using System.Security.AccessControl;

//注意：封装前需将playerprefs里的“NotFirstPlay”清空


//<summary>
//程序用于恢复出厂设置
//包含第一次使用时预置代码备份
//添加 BY 王广官
//<summary>


public class ProgramReset : MonoBehaviour {
	
	#region define 
	ControlPanel Main;
	SoftkeyModule Softkey_Script;
//	MDIEditModule MDIEdit_Script;
	
	
	//代码存放和备份文件夹名称
	//位置更改时请更新此处名称
//	public string CodePath="/Resources/Gcode";
	string BackupDir="/Resources/Backup/";
	public string Backup_path;
	int i = 0;
	
	
	public bool display_menu = false;
	bool warn_flag = false;
//	public bool ProgReset_flag = false;
	
	Rect WindowRect;
	#endregion 	
	
	void Awake()	
	{
		Main = gameObject.GetComponent<ControlPanel>();
		Softkey_Script = gameObject.GetComponent<SoftkeyModule>();
//		MDIEdit_Script = gameObject.GetComponent <MDIEditModule>();
	}
	
	void Start () 
	{
		BackupDir = SystemArguments.BackupCodePath;
		Backup_path  = Application.dataPath+BackupDir;
		WindowRect.x = 100f;
		WindowRect.y = 300f;
		WindowRect.width = 300f;
		WindowRect.height = 180f;
		Main.sty_ResetWindow.fontSize=17;
//		BackupGcode();
		GcodeWatcher();
	}
	
	//恢复出厂设置(暂时只支持恢复预置代码)
	void DoReset()
	{
		string[] temp_filenamelist = new string[600];

		temp_filenamelist = Directory.GetFiles(Backup_path);

		foreach(string filename in temp_filenamelist)
		{
			string strLine = "";
			string temp_name = "";
			
			Regex name_Reg = new Regex(@"[NCT]Sys\w{3,5}.ini$");
			temp_name = name_Reg.Match(filename).Value.Trim('.','i','n').ToString();
			temp_name = FilenameDeciphering(temp_name);
			
			FileStream str_origfile = new FileStream (filename, FileMode.Open, FileAccess.Read);
			FileStream str_destfile = new FileStream (Softkey_Script.document_path+temp_name, FileMode.Create, FileAccess.Write);
			GZipInputStream gzip = new GZipInputStream(str_origfile );
			StreamReader sr = new StreamReader (gzip);
			StreamWriter sw = new StreamWriter (str_destfile);
			
			strLine = sr.ReadToEnd ();
			sr.Close ();
			sw.Write(strLine);
			sw.Close ();	
		}
		Main.WarnningClear();
		Main.CodeForAll.Clear();
		Main.ProgEDITAt = false;
		Main.at_position = -1;
		Main.ProgramNum = 0;
		Main.RealListNum = 1;
		Main.Progname_Backup = Main.ProgramNum;
		Main.ProgEDITCusorV=0;
		Main.ProgEDITCusorH=0;
		Main.StartRow=0;
		Main.EndRow=SystemArguments.EditLineNumber;
		Main.SelectStart=0;
		Main.SelectEnd=0;
		Main.TotalCodeNum = Main.CodeForAll.Count;
		Softkey_Script.calcSepo(Main.CodeForAll, SystemArguments.EditLength1);
//		MDIEdit_Script.EditProgRight();
//		Softkey_Script.FileInfoInitialize();
		Main.InputText = "";
		Main.ProgEDITCusorPos = Main.corner_px + 23.5f;
	}
	
	
	
	void ResetWarning(int windowID)
	{
		GUI.Label (new Rect(40,50,200,100),"恢复出厂设置将还原CNC系统,\n        预置的程序将还原！\n             是否继续？",Main.sty_ResetWindow);
		
		if(GUI.Button(new Rect(60, 130, 80, 30),"继续"))
		{
			display_menu = false;
			if(Main.ScreenPower&&Main.ProgEDIT)
				DoReset();
			else if(Main.ScreenPower)
			{
				warn_flag = true;
				return;
			}
			else
				DoReset();
		}
		
			
		if(GUI.Button (new Rect(160, 130, 80, 30),"返回"))
		{
			display_menu = false;
		}
		GUI.DragWindow ();
	}
	
	void ModuleSelectWarning(int windowID)
	{
		GUI.Label (new Rect(70,70,200,100),"请先调整至EDIT模式！",Main.sty_ResetWindow);
		if(GUI.Button (new Rect(110, 130, 80, 30),"返回"))
		{
			warn_flag = false;
		}
		GUI.DragWindow ();
	}
	
	void OnGUI()
	{
		if(display_menu)
		{
			WindowRect = GUI.Window (56,WindowRect,ResetWarning,"Reset Control");
		}
		if(warn_flag)
		{
			WindowRect = GUI.Window(57,WindowRect,ModuleSelectWarning,"Warning");
		}
	}
	
	
//注意：封装前清掉PlayerPrefs里的“NotFirstPlay”
//用于第一次启动程序时备份	
	void BackupGcode()
	{
		if(PlayerPrefs.HasKey("NotFirstPlay"))
		{
//			PlayerPrefs.DeleteKey ("NotFirstPlay");
			return;
		}
		else
		{
			string strLine = "";
			string[] temp_filename_list = new string[600];
			
			if(Directory.Exists(Backup_path)==false)
			{
				Directory.CreateDirectory(Backup_path);
			}
			
			temp_filename_list = Directory.GetFiles (Softkey_Script.document_path);
			foreach(string filename in temp_filename_list)
			{
				string temp_name = "";
				string temp_filename = "";
				
				Regex name_Reg = new Regex(@"O\d{4}.\w{2,3}$");
				temp_name = name_Reg.Match(filename).Value.Trim('O').ToString();
				temp_filename = FilenameEncrypt(temp_name);
				string dest_filename = Backup_path + temp_filename;
				
				FileStream str_orignfile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
				FileStream str_backupfile = new FileStream(dest_filename, FileMode.OpenOrCreate, FileAccess.Write);
				GZipOutputStream gzip = new GZipOutputStream(str_backupfile);
				StreamReader sr = new StreamReader (str_orignfile);
				StreamWriter sw = new StreamWriter(gzip);
				
				strLine = sr.ReadToEnd();
				sw.WriteLine(strLine);
				sr.Close ();
				sw.Close ();
			}
			PlayerPrefs.SetInt ("NotFirstPlay",1);
		}
	}
	
	
	
	
	//用于压缩时文件名加密
	string FilenameEncrypt(string filename)
	{
		int intname=0;
		string Hname = "";
		
		if(filename.IndexOf (".txt")!=-1)
		{
			filename = filename.Trim().Trim ('.','t','x');
			Hname = "TSys";
		}
		
		else if(filename.IndexOf (".cnc")!=-1)
		{
			filename = filename.Trim ().Trim ('.','c','n');
			Hname = "CSys";
		}
		
		else
		{
			filename = filename.Trim().Trim('.','c','n');
			Hname = "NSys";
		}

		intname = Convert.ToInt32(filename);
		intname = intname+256;
		filename = Hname + intname.ToString() + ".ini";
		return(filename);
	}
	
	
	//用于解压缩时文件名解密
	string FilenameDeciphering(string EncName)
	{
		string temp_name = "";
		string DecName = "";
		int NameNum = 0;
		string ext = "";
		
		if(EncName.StartsWith("T"))
		{
			ext = ".txt";
			temp_name = EncName.Trim ().Trim ('T','S','y','s');			
		}
		
		else if(EncName.StartsWith ("C"))
		{
			ext = ".cnc";
			temp_name = EncName.Trim ().Trim ('C','S','y','s');	
		}
		
		else if(EncName.StartsWith ("N"))
		{
			ext = ".nc";
			temp_name = EncName.Trim ().Trim ('N','S','y','s');	
		}

		NameNum = Convert.ToInt32(temp_name);
		NameNum = NameNum - 256;
		temp_name = Main.ToolNumFormat (NameNum);
		temp_name = temp_name.Trim ();
		DecName = "O" + temp_name + ext;
		return (DecName);
	}
	
	//summary
	//Gcode文件夹监视
	//程序运行过程中对Gcode文件夹里的手动操作及时反映到界面中
	//summary
	void GcodeWatcher()
	{
		FileSystemWatcher dir_watcher = new FileSystemWatcher();
		dir_watcher.Path = Softkey_Script.document_path;
		dir_watcher.Filter = "O*.*";
		dir_watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName ;
		dir_watcher.Created += new FileSystemEventHandler(Onchanged);
		dir_watcher.Deleted += new FileSystemEventHandler(Onchanged);
//		dir_watcher.Changed += new FileSystemEventHandler(Onchanged);
		dir_watcher.EnableRaisingEvents = true;
	}
	
	private void Onchanged(object source,FileSystemEventArgs e)
	{
		i+=1;
	}
	
//	void FixedUpdate()
//	{
//		if(i>=1)
//		{
//			Softkey_Script.FileInfoInitialize ();
//			i=0;
//		}
//	}
	// Update is called once per frame
	void Update () 
	{
		if(i>=1)
		{
//			Softkey_Script.FileInfoInitialize ();
			i=0;
		}
	}
}
