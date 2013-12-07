using UnityEngine;
using System.Collections;

public class MDIInputModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	//位置界面功能完善---宋荣 ---03.09
	public bool isXSelected;//相对或综合pos下X键是否按下；
	public bool isYSelected;
	public bool isZSelected;
	//位置界面功能完善---宋荣 ---03.09
	
	public float btn_width = 48;
	public float btn_height = 48;
	public float l_x=603;
	public float l_y=34;
	public float left_x=57;
	public float left_y=53;
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
	}
	
	public void MDIInput ()
	{
		//MDI面板输入区		
		if (GUI.Button(new Rect(l_x/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.pO))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "O");
//				LetterInput("O");
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.qN))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "N");
//				LetterInput("N");
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.rG))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "G");
//				LetterInput("G");
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.a7))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "7");
//				LetterInput("7");
			}
		}
		
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.b8))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "8");
//				LetterInput("8");
			}
		}
		
		if (GUI.Button(new Rect((l_x+5*left_x)/1000f*Main.width, l_y/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.c9))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "9");
//				LetterInput("9");
			}
		}
		
		if (GUI.Button(new Rect(l_x/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.uX))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "X");
//				LetterInput("X");
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.vY))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "Y");
//				LetterInput("Y");
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.wZ))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "Z");
//				LetterInput("Z");
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.four))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "4");
//				LetterInput("4");
			}
		}
		
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.five))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "5");
//				LetterInput("5");
			}
		}
		
		if (GUI.Button(new Rect((l_x+5*left_x)/1000f*Main.width, (l_y+left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.six))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "6");
//				LetterInput("6");
			}
		}
		
		if (GUI.Button(new Rect(l_x/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.iM))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "M");
//				LetterInput("M");
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.jS))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "S");
//				LetterInput("S");
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.kT))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "T");
//				LetterInput("T");
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.one))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "1");
//				LetterInput("1");
			}
		}
		
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.two))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "2");
//				LetterInput("2");
			}
		}
		
		if (GUI.Button(new Rect((l_x+5*left_x)/1000f*Main.width, (l_y+2*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.three))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "3");
//				LetterInput("3");
			}
		}
		
		if (GUI.Button(new Rect(l_x/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.lF))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "F");
//				LetterInput("F");
			}
		}
		
		if (GUI.Button(new Rect((l_x+left_x)/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.dH))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "H");
//				LetterInput("H");
			}
		}
		
		if (GUI.Button(new Rect((l_x+2*left_x)/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.eEOB))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, ";");
//				LetterInput(";");
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.ap))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "-");
//				LetterInput("-");
			}
		}
		
		if (GUI.Button(new Rect((l_x+4*left_x)/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.zero))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, "0");
//				LetterInput("0");
			}
		}
		
		if (GUI.Button(new Rect((l_x+5*left_x)/1000f*Main.width, (l_y+3*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.po))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("LetterInput", RPCMode.All, ".");
//				LetterInput(".");
			}
		}
		
		if (GUI.Button(new Rect((l_x+3*left_x)/1000f*Main.width, (l_y+4*left_y)/1000f*Main.height, btn_width/1000f*Main.width, btn_height/1000f*Main.height), "",Main.sh))            
		{
			if(Main.ScreenPower)
			{
				networkView.RPC("ShiftRPC", RPCMode.All);
//				Main.ShiftFlag = true;
			}
		}
	}
	
//	[RPC]
//	void LetterInputPad(string letter)
//	{
//		Main.InputText = letter;
//		Main.CursorText.text = Main.InputText;
//		Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
//		Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//	}
	[RPC]
	void ShiftRPC()
	{
		Main.ShiftFlag = !Main.ShiftFlag;
		if(Main.ShiftFlag){
			Main.sh.normal.background = Main.sh_d;
		}else{
			Main.sh.normal.background = Main.sh_u;
		}
	}
	
	[RPC]
	void LetterInput (string letter) 
	{
		string with_shift = "";
		string without_shift = "";
		switch(letter)
		{
		case "O":
			with_shift = "P";
			without_shift = "O";
			break;	
		case "N":
			with_shift = "Q";
			without_shift = "N";
			break;
		case "G":
			with_shift = "R";
			without_shift = "G";
			break;
		case "X":
			with_shift = "U";
			without_shift = "X";
			break;
		case "Y":
			with_shift = "V";
			without_shift = "Y";
			break;
		case "Z":
			with_shift = "W";
			without_shift = "Z";
			break;
		case "M":
			with_shift = "I";
			without_shift = "M";
			break;
		case "S":
			with_shift = "J";
			without_shift = "S";
			break;
		case "T":
			with_shift = "K";
			without_shift = "T";
			break;
		case "F":
			with_shift = "I";
			without_shift = "F";
			break;
		case "H":
			with_shift = "D";
			without_shift = "H";
			break;
		case ";":
			with_shift = "E";
			without_shift = ";";
			break;
		case "7":
			with_shift = "A";
			without_shift = "7";
			break;
		case "8":
			with_shift = "B";
			without_shift = "8";
			break;
		case "9":
			with_shift = "C";
			without_shift = "9";
			break;
		case "4":
			with_shift = "[";
			without_shift = "4";
			break;	
		case "5":
			with_shift = "]";
			without_shift = "5";
			break;		
		case "6":
			with_shift = " ";
			without_shift = "6";
			break;
		case "1":
			with_shift = ",";
			without_shift = "1";
			break;
		case "2":
			with_shift = "#";
			without_shift = "2";
			break;
		case "3":
			with_shift = "=";
			without_shift = "3";
			break;
		case "-":
			with_shift = "+";
			without_shift = "-";
			break;
		case "0":
			with_shift = "*";
			without_shift = "0";
			break;
		case ".":
			with_shift = "/";
			without_shift = ".";
			break;
		}
		
		if(Main.ProgMenu || Main.SettingMenu)
		{
			if(Main.ProgEDIT && Main.ProgEDITFlip == 0)
			{
				Main.ProgEDITFlip = 1;
			}
			if(Main.SettingMenu && Main.OffSetOne)
			{
				Main.OffSetOne = false;
				Main.OffSetTwo = true;
			}
			if(Main.ProgEDITCusorPos < SystemArguments.CursorLength)
			{
				if(Main.ProgEDITList)
				{
					Main.ProgEDITFlip = 1;
				}
				if(Main.ShiftFlag)
				{
					Main.InputText += with_shift;
//					Main.ShiftFlag = false;
				}
				else
				{
					Main.InputText += without_shift;
//					Main.ShiftFlag = false;
				}
				Main.CursorText.text = Main.InputText;
				Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
				Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//				networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
			}
			return;
		}	
		
		//位置界面功能完善---宋荣 ---03.09
		if(Main.PosMenu)
		{
			if(Main.InputText == "")
			{
				//X闪烁
				if(!Main.ShiftFlag && without_shift == "X")
				{
					isXSelected=true;
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isYSelected=false;
					isZSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText += without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
				//Y闪烁
				else if(!Main.ShiftFlag && without_shift == "Y")
				{
					isYSelected=true;	
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isXSelected=false;
					isZSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText += without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
				//Z闪烁
				else if(!Main.ShiftFlag && without_shift == "Z")
				{
					isZSelected=true;	
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isXSelected=false;
					isYSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText += without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
			}
			else
			{
				//X闪烁
				if(!Main.ShiftFlag && without_shift == "X")
				{
					isXSelected=true;
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isYSelected=false;
					isZSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText = without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
				//Y闪烁
				else if(!Main.ShiftFlag && without_shift == "Y")
				{
					isYSelected=true;	
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isXSelected=false;
					isZSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText = without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
				//Z闪烁
				else if(!Main.ShiftFlag && without_shift == "Z")
				{
					isZSelected=true;	
					if(Main.RelativeCoo)
						Main.statusBeforeOperation=2;
					if(Main.AbsoluteCoo)
						Main.statusBeforeOperation=1;
					if(Main.GeneralCoo)
						Main.statusBeforeOperation=3;
					Main.RelativeCoo=false;
					Main.AbsoluteCoo=false;
					Main.GeneralCoo=false;
					isXSelected=false;
					isYSelected=false;
					if(!Main.operationBottomScrInitial && !Main.operationBottomScrExecute)
					{
						Main.operationBottomScrInitial=true;
						Main.operationBottomScrExecute=false;
					}
					Main.posOperationMode=true;
					Main.InputText = without_shift;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
				//输入各轴预置变量值
				else if(Main.statusBeforeOperation != 1 && Main.ProgEDITCusorPos < SystemArguments.CursorLength)
				{
					string float_str = Main.InputText.Remove(0, 1);
					string add_str = "";
					float abc = 0;
					if(Main.ShiftFlag)
						add_str = with_shift;
					else
						add_str = without_shift;
					float_str += add_str;
					try
					{
						abc = float.Parse(float_str);
					}
					catch
					{
//						Debug.Log("wrong string");
						return;
					}
					Main.InputText += add_str;
					Main.CursorText.text = Main.InputText;
					Main.InputTextSize = Main.sty_InputTextField.CalcSize(new GUIContent(Main.CursorText.text));
					Main.ProgEDITCusorPos = Main.corner_px + 23.5f + Main.InputTextSize.x;
//					networkView.RPC("LetterInputPad", RPCMode.Others, Main.InputText);
				}
			}
		}
	    //位置界面功能完善---宋荣 ---03.09
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
