using UnityEngine;
using System.Collections;

public class ButtonShowOff : MonoBehaviour {
	ControlPanel Main;
	MDIFunctionModule MDIFunction_Script;
	MDIInputModule MDIInput_Script;
	MDIEditModule MDIEdit_Script;
	AuxiliaryFunctionModule AuxiliaryFunction_Script;
	MachineFunctionModule MachineFunction_Script;
	
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		MDIFunction_Script = gameObject.GetComponent<MDIFunctionModule>();
		MDIInput_Script = gameObject.GetComponent<MDIInputModule>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		AuxiliaryFunction_Script = gameObject.GetComponent<AuxiliaryFunctionModule>();
		MachineFunction_Script = gameObject.GetComponent<MachineFunctionModule>();
	}
	
	
	/// <summary>
	/// 数控面板按钮放大.
	/// </summary>
	public void ButtonEnlarge()
	{
		Event e = Event.current;
		
		//MDIInput Region
		if(MDIInput_Rect(0, 0).Contains(e.mousePosition)){  //pO
			GUI.Label(MDIInput_Button(0, 0), "", Main.sty_pO);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(1, 0).Contains(e.mousePosition)){  //qN
			GUI.Label(MDIInput_Button(1, 0), "", Main.sty_qN);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(2, 0).Contains(e.mousePosition)){  //rG
			GUI.Label(MDIInput_Button(2, 0), "", Main.sty_rG);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(3, 0).Contains(e.mousePosition)){  //a7
			GUI.Label(MDIInput_Button(3, 0), "", Main.sty_a7);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(4, 0).Contains(e.mousePosition)){  //b8
			GUI.Label(MDIInput_Button(4, 0), "", Main.sty_b8);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(5, 0).Contains(e.mousePosition)){  //c9
			GUI.Label(MDIInput_Button(5, 0), "", Main.sty_c9);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(0, 1).Contains(e.mousePosition)){  //uX
			GUI.Label(MDIInput_Button(0, 1), "", Main.sty_uX);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(1, 1).Contains(e.mousePosition)){  //vY
			GUI.Label(MDIInput_Button(1, 1), "", Main.sty_vY);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(2, 1).Contains(e.mousePosition)){  //wZ
			GUI.Label(MDIInput_Button(2, 1), "", Main.sty_wZ);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(3, 1).Contains(e.mousePosition)){  //four
			GUI.Label(MDIInput_Button(3, 1), "", Main.sty_four);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(4, 1).Contains(e.mousePosition)){  //five
			GUI.Label(MDIInput_Button(4, 1), "", Main.sty_five);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(5, 1).Contains(e.mousePosition)) { //six
			GUI.Label(MDIInput_Button(5, 1), "", Main.sty_six);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(0, 2).Contains(e.mousePosition)){  //iM
			GUI.Label(MDIInput_Button(0, 2), "", Main.sty_iM);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(1, 2).Contains(e.mousePosition)){  //jS
			GUI.Label(MDIInput_Button(1, 2), "", Main.sty_jS);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(2, 2).Contains(e.mousePosition)){  //kT
			GUI.Label(MDIInput_Button(2, 2), "", Main.sty_kT);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(3, 2).Contains(e.mousePosition)){  //one
			GUI.Label(MDIInput_Button(3, 2), "", Main.sty_one);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(4, 2).Contains(e.mousePosition)){  //two
			GUI.Label(MDIInput_Button(4, 2), "", Main.sty_two);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(5, 2).Contains(e.mousePosition)) { //three
			GUI.Label(MDIInput_Button(5, 2), "", Main.sty_three);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(0, 3).Contains(e.mousePosition)){  //lF
			GUI.Label(MDIInput_Button(0, 3), "", Main.sty_lF);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(1, 3).Contains(e.mousePosition)){  //dH
			GUI.Label(MDIInput_Button(1, 3), "", Main.sty_dH);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(2, 3).Contains(e.mousePosition)) { //eEOB
			GUI.Label(MDIInput_Button(2, 3), "", Main.sty_eEOB);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(3, 3).Contains(e.mousePosition)){  //ap
			GUI.Label(MDIInput_Button(3, 3), "", Main.sty_ap);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(4, 3).Contains(e.mousePosition)){  //zero
			GUI.Label(MDIInput_Button(4, 3), "", Main.sty_zero);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(5, 3).Contains(e.mousePosition)){  //po
			GUI.Label(MDIInput_Button(5, 3), "", Main.sty_po);
			Main.mainWindowDrag = false;
		}
		
		if(MDIInput_Rect(3, 4).Contains(e.mousePosition)){  //sh
			GUI.Label(MDIInput_Button(3, 4), "", Main.sty_sh);
			Main.mainWindowDrag = false;
		}
		
		//MDIFunction Region
		if(MDIFunction_Rect(0, 4).Contains(e.mousePosition)){  //POS
			GUI.Label(MDIFunction_Button(0, 4), "", Main.sty_Pos);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(1, 4).Contains(e.mousePosition)){  //PROG
			GUI.Label(MDIFunction_Button(1, 4), "", Main.sty_PROG);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(2, 4).Contains(e.mousePosition)){  //SET
			GUI.Label(MDIFunction_Button(2, 4), "", Main.sty_SET);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(5, 4).Contains(e.mousePosition)){  //INPUT
			GUI.Label(MDIFunction_Button(5, 4), "", Main.sty_INPUT);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(0, 5).Contains(e.mousePosition)) { //SYSTEM
			GUI.Label(MDIFunction_Button(0, 5), "", Main.sty_SYSTEM);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(1, 5).Contains(e.mousePosition)){  //MESSAGE
			GUI.Label(MDIFunction_Button(1, 5), "", Main.sty_MESSAGE);
			Main.mainWindowDrag = false;
		}

		if(MDIFunction_Rect(2, 5).Contains(e.mousePosition)){  //GRPH
			GUI.Label(MDIFunction_Button(2, 5), "", Main.sty_GRPH);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(5, 6).Contains(e.mousePosition)){  //HELP
			GUI.Label(MDIFunction_Button(5, 6), "", Main.sty_HELP);
			Main.mainWindowDrag = false;
		}
		
		if(MDIFunction_Rect(5, 7).Contains(e.mousePosition)){  //RESET
			GUI.Label(MDIFunction_Button(5, 7), "", Main.sty_RESET);
			Main.mainWindowDrag = false;
		}
		
		//MDIEdit Region
		if(MDIEdit_Rect(4, 4).Contains(e.mousePosition)){  //CAN
			GUI.Label(MDIEdit_Button(4, 4), "", Main.sty_CAN);
			Main.mainWindowDrag = false;
		}
		
		if(MDIEdit_Rect(3, 5).Contains(e.mousePosition)){  //ALTER
			GUI.Label(MDIEdit_Button(3, 5), "", Main.sty_ALTER);
			Main.mainWindowDrag = false;
		}
		
		if(MDIEdit_Rect(4, 5).Contains(e.mousePosition)){  //INSERT
			GUI.Label(MDIEdit_Button(4, 5), "", Main.sty_INSERT);
			Main.mainWindowDrag = false;
		}
		
		if(MDIEdit_Rect(5, 5).Contains(e.mousePosition)){  //DELETE
			GUI.Label(MDIEdit_Button(5, 5), "", Main.sty_DELETE);
			Main.mainWindowDrag = false;
		}
		
		if(MDIEdit_Rect(0, 6).Contains(e.mousePosition)){  //PAGEu
			GUI.Label(MDIEdit_Button(0, 6), "", Main.sty_PAGEu);
			Main.mainWindowDrag = false;
		}
		
		if(MDIEdit_Rect(0, 7).Contains(e.mousePosition)){  //PAGEd
			GUI.Label(MDIEdit_Button(0, 7), "", Main.sty_PAGEd);
			Main.mainWindowDrag = false;
		}
		
		//AuxiliaryFunction Region
		if(AuxiliaryFunction_Rect(0, 0).Contains(e.mousePosition)){  //COOL
			GUI.Label(AuxiliaryFunction_Button(0, 0), "", Main.sty_COOL);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(2, 0).Contains(e.mousePosition)){  //MHS
			GUI.Label(AuxiliaryFunction_Button(2, 0), "", Main.sty_MHS);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(0, 1).Contains(e.mousePosition)) { //ATCW
			GUI.Label(AuxiliaryFunction_Button(0, 1), "", Main.sty_ATCW);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(1, 1).Contains(e.mousePosition)){  //ATCCW
			GUI.Label(AuxiliaryFunction_Button(1, 1), "", Main.sty_ATCCW);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(2, 1).Contains(e.mousePosition)){  //MHRN
			GUI.Label(AuxiliaryFunction_Button(2, 1), "", Main.sty_MHRN);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(0, 2).Contains(e.mousePosition)) { //FOR
			GUI.Label(AuxiliaryFunction_Button(0, 2), "", Main.sty_FOR);
			Main.mainWindowDrag = false;
		}
		
		if(AuxiliaryFunction_Rect(1, 2).Contains(e.mousePosition)) { //BACK
			GUI.Label(AuxiliaryFunction_Button(1, 2), "", Main.sty_BACK);
			Main.mainWindowDrag = false;
		}
		
		//MachineFunction Region
		if(MachineFunction_Rect(0, 0).Contains(e.mousePosition)){  //MLK
			GUI.Label(MachineFunction_Button(0, 0), "", Main.sty_MLK);
			Main.mainWindowDrag = false;
		}
		
		if(MachineFunction_Rect(1, 0).Contains(e.mousePosition)) { //DRN
			GUI.Label(MachineFunction_Button(1, 0), "", Main.sty_DRN);
			Main.mainWindowDrag = false;
		}
		
		if(MachineFunction_Rect(2, 0).Contains(e.mousePosition)){  //BDT
			GUI.Label(MachineFunction_Button(2, 0), "", Main.sty_BDT);
			Main.mainWindowDrag = false;
		}
		
		if(MachineFunction_Rect(3, 0).Contains(e.mousePosition)) { //SBK
			GUI.Label(MachineFunction_Button(3, 0), "", Main.sty_SBK);
			Main.mainWindowDrag = false;
		}
		
		if(MachineFunction_Rect(0, 1).Contains(e.mousePosition)){  //OSP
			GUI.Label(MachineFunction_Button(0, 1), "", Main.sty_OSP);
			Main.mainWindowDrag = false;
		}
		
		if(MachineFunction_Rect(1, 1).Contains(e.mousePosition)) { //ZLOCK
			GUI.Label(MachineFunction_Button(1, 1), "", Main.sty_ZLOCK);
			Main.mainWindowDrag = false;
		}
		
		//Manual Region
		if(Manual_Rect(0, 0).Contains(e.mousePosition)){  //S4P
			GUI.Label(Manual_Button(0, 0), "", Main.sty_S4P);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(1, 0).Contains(e.mousePosition)){  //SYN
			GUI.Label(Manual_Button(1, 0), "", Main.sty_SYN);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(2, 0).Contains(e.mousePosition)){  //SZP
			GUI.Label(Manual_Button(2, 0), "", Main.sty_SZP);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(0, 1).Contains(e.mousePosition)){  //SXP
			GUI.Label(Manual_Button(0, 1), "", Main.sty_SXP);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(1, 1).Contains(e.mousePosition)) { //SRAPID
			GUI.Label(Manual_Button(1, 1), "", Main.sty_SRAPID);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(2, 1).Contains(e.mousePosition)){  //SXN
			GUI.Label(Manual_Button(2, 1), "", Main.sty_SXN);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(0, 2).Contains(e.mousePosition)) { //S4N
			GUI.Label(Manual_Button(0, 2), "", Main.sty_S4N);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(1, 2).Contains(e.mousePosition)){  //SYP
			GUI.Label(Manual_Button(1, 2), "", Main.sty_SYP);
			Main.mainWindowDrag = false;
		}
		
		if(Manual_Rect(2, 2).Contains(e.mousePosition)) { //SZN
			GUI.Label(Manual_Button(2, 2), "", Main.sty_SZN);
			Main.mainWindowDrag = false;
		}
		
		//Spindle Region
		if(Spindle_Rect(0, 0).Contains(e.mousePosition)){  //SF0
			GUI.Label(Spindle_Button(0, 0), "", Main.sty_SF0);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(1, 0).Contains(e.mousePosition)){  //SF25
			GUI.Label(Spindle_Button(1, 0), "", Main.sty_SF25);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(2, 0).Contains(e.mousePosition)){  //SF50
			GUI.Label(Spindle_Button(2, 0), "", Main.sty_SF50);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(3, 0).Contains(e.mousePosition)){  //SF100
			GUI.Label(Spindle_Button(3, 0), "", Main.sty_SF100);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(1, 1).Contains(e.mousePosition)){  //SDOWN
			GUI.Label(Spindle_Button(1, 1), "", Main.sty_SDOWN);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(2, 1).Contains(e.mousePosition)){  //SHUNDRED
			GUI.Label(Spindle_Button(2, 1), "", Main.sty_SHUNDRED);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(3, 1).Contains(e.mousePosition)) { //SUP
			GUI.Label(Spindle_Button(3, 1), "", Main.sty_SUP);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(0, 2).Contains(e.mousePosition)){  //SORIENT
			GUI.Label(Spindle_Button(0, 2), "", Main.sty_SORIENT);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(1, 2).Contains(e.mousePosition)) { //SCW
			GUI.Label(Spindle_Button(1, 2), "", Main.sty_SCW);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(2, 2).Contains(e.mousePosition)){  //SSTOP
			GUI.Label(Spindle_Button(2, 2), "", Main.sty_SSTOP);
			Main.mainWindowDrag = false;
		}
		
		if(Spindle_Rect(3, 2).Contains(e.mousePosition)){  //SCCW
			GUI.Label(Spindle_Button(3, 2), "", Main.sty_SCCW);
			Main.mainWindowDrag = false;
		}
	}
	
	//MDIFunction位置区域
	Rect MDIFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIFunction_Script.l_x + column*MDIFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIFunction_Script.l_y+row*MDIFunction_Script.left_y)/1000f*Main.height;
		rect_return.width = (MDIFunction_Script.btn_width)/1000f*Main.width;
		rect_return.height = (MDIFunction_Script.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIFunction显示区域
	Rect MDIFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIFunction_Script.l_x + (column - 2)*MDIFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIFunction_Script.l_y+(row - 1)*MDIFunction_Script.left_y + MDIFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MDIInput位置区域
	Rect MDIInput_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIInput_Script.l_x + column*MDIInput_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIInput_Script.l_y+row*MDIInput_Script.left_y)/1000f*Main.height;
		rect_return.width = (MDIInput_Script.btn_width)/1000f*Main.width;
		rect_return.height = (MDIInput_Script.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIInput显示区域
	Rect MDIInput_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIInput_Script.l_x + (column-2)*MDIInput_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIInput_Script.l_y+(row - 1)*MDIInput_Script.left_y +MDIInput_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIInput_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIInput_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MDIEdit位置区域
	Rect MDIEdit_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIEdit_Script.l_x + column*MDIEdit_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIEdit_Script.l_y+row*MDIEdit_Script.left_y)/1000f*Main.height;
		rect_return.width = (MDIEdit_Script.btn_width)/1000f*Main.width;
		rect_return.height = (MDIEdit_Script.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//MDIEdit显示区域
	Rect MDIEdit_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MDIEdit_Script.l_x + (column - 2)*MDIEdit_Script.left_x)/1000f*Main.width;
		rect_return.y = (MDIEdit_Script.l_y+(row - 1)*MDIEdit_Script.left_y + MDIEdit_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MDIEdit_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MDIEdit_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//AuxiliaryFunction位置区域
	Rect AuxiliaryFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (AuxiliaryFunction_Script.l_x + column*AuxiliaryFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (AuxiliaryFunction_Script.l_y+row*AuxiliaryFunction_Script.left_y)/1000f*Main.height;
		rect_return.width = (AuxiliaryFunction_Script.btn_width)/1000f*Main.width;
		rect_return.height = (AuxiliaryFunction_Script.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//AuxiliaryFunction显示区域
	Rect AuxiliaryFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (AuxiliaryFunction_Script.l_x + (column - 2)*AuxiliaryFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (AuxiliaryFunction_Script.l_y+(row - 1)*AuxiliaryFunction_Script.left_y + AuxiliaryFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*AuxiliaryFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*AuxiliaryFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//MachineFunction位置区域
	Rect MachineFunction_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MachineFunction_Script.l_x + column*MachineFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (MachineFunction_Script.l_y+row*MachineFunction_Script.left_y)/1000f*Main.height;
		rect_return.width = (MachineFunction_Script.btn_width)/1000f*Main.width;
		rect_return.height = (MachineFunction_Script.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//MachineFunction显示区域
	Rect MachineFunction_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (MachineFunction_Script.l_x + (column - 2)*MachineFunction_Script.left_x)/1000f*Main.width;
		rect_return.y = (MachineFunction_Script.l_y+(row - 1)*MachineFunction_Script.left_y + MachineFunction_Script.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*MachineFunction_Script.left_x/1000f*Main.width;
		rect_return.height = 2*MachineFunction_Script.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//Manual位置区域
	Rect Manual_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Axis_x + column*Main.left_x)/1000f*Main.width;
		rect_return.y = (Main.Axis_y+row*Main.left_y)/1000f*Main.height;
		rect_return.width = (Main.btn_width)/1000f*Main.width;
		rect_return.height = (Main.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//Manual显示区域
	Rect Manual_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Axis_x + (column - 2)*Main.left_x)/1000f*Main.width;
		rect_return.y = (Main.Axis_y+(row - 1)*Main.left_y + Main.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*Main.left_x/1000f*Main.width;
		rect_return.height = 2*Main.left_y/1000f*Main.height;
		return rect_return;
	}
	
	//Spindle位置区域
	Rect Spindle_Rect(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Rapid_x + column*Main.left_x)/1000f*Main.width;
		rect_return.y = (Main.Rapid_y+row*Main.left_y )/1000f*Main.height;
		rect_return.width = (Main.btn_width)/1000f*Main.width;
		rect_return.height = (Main.btn_height)/1000f*Main.height;
		return rect_return;
	}
	
	//Spindle显示区域
	Rect Spindle_Button(int column, int row)
	{
		Rect rect_return = new Rect(0,0,0,0);
		rect_return.x = (Main.Rapid_x + (column - 2)*Main.left_x)/1000f*Main.width;
		rect_return.y = (Main.Rapid_y+(row - 1)*Main.left_y + Main.btn_height/2)/1000f*Main.height;
		rect_return.width = 2*Main.left_x/1000f*Main.width;
		rect_return.height = 2*Main.left_y/1000f*Main.height;
		return rect_return;
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// 模式旋钮和倍率旋钮方法.
	/// </summary>
	public void KnobEnlarge()
	{
		Event ev = Event.current;
		
		//模式选择旋钮区域
		Rect Rect_EDIT = new Rect(180,557,30,15);
		Rect Rect_DNC = new Rect(180,535,30,15);
		Rect Rect_AUTO = new Rect (185,511,30,15);
		Rect Rect_MDI = new Rect (200,494,30,15);
		Rect Rect_MPG = new Rect (237,490,30,15);
		Rect Rect_JOG = new Rect (270,505,30,15);
		Rect Rect_ZERO = new Rect (275,521,30,15);
		
		//进给速率旋钮区域
		Rect Rect_FD0 = new Rect(355,557,16,10);
		Rect Rect_FD10 = new Rect(352,547,16,10);
		Rect Rect_FD20 = new Rect (353,537,16,10);
		Rect Rect_FD30 = new Rect (354,522,16,10);
		Rect Rect_FD40 = new Rect (357,510,16,10);
		Rect Rect_FD50 = new Rect (365,498,16,10);
		Rect Rect_FD60 = new Rect (378,492,16,10);
		Rect Rect_FD70 = new Rect (393,485,12,16);
		Rect Rect_FD80 = new Rect (407,485,12,16);
		Rect Rect_FD90 = new Rect (420,490,10,16);
		Rect Rect_FD100 = new Rect (432,496,18,10);
		Rect Rect_FD110 = new Rect (440,510,18,10);
		Rect Rect_FD120 = new Rect (445,523,18,10);
		Rect Rect_FD130 = new Rect (447,535,18,10);
		Rect Rect_FD140 = new Rect (444,547,18,10);
		Rect Rect_FD150 = new Rect (440,560,22,10);
		
		//模式选择旋钮放大
		if (Rect_EDIT.Contains(ev.mousePosition))  //EDIT
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_EDIT;
			GUI.Label(new Rect(90,564,80,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_DNC.Contains(ev.mousePosition))  //DNC
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_DNC;
			GUI.Label(new Rect(95,525,80,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_AUTO.Contains(ev.mousePosition))  //AUTO
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_AUTO;
			GUI.Label(new Rect(100,480,80,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_MDI.Contains(ev.mousePosition))  //MDI
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_MDI;
			GUI.Label(new Rect(126,466,80,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_MPG.Contains(ev.mousePosition))  //MPG
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_MPG;
			GUI.Label(new Rect(280,466,80,36),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_JOG.Contains(ev.mousePosition))  //JOG
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_JOG;
			GUI.Label(new Rect(310,490,80,29),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_ZERO.Contains(ev.mousePosition))  //ZERO
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_ZERO;
			GUI.Label(new Rect(310,505,80,44),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		
		//进给速率旋钮放大
		if (Rect_FD0.Contains(ev.mousePosition))  //0
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate0;
			GUI.Label(new Rect(310,562,17,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD10.Contains(ev.mousePosition))  //10
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate10;
			GUI.Label(new Rect(310,547,26,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD20.Contains(ev.mousePosition))  //20
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate20;
			GUI.Label(new Rect(310,531,30,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD30.Contains(ev.mousePosition))  //30
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate30;
			GUI.Label(new Rect(312,513,25,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD40.Contains(ev.mousePosition))  //40
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate40;
			GUI.Label(new Rect(315,491,27,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD50.Contains(ev.mousePosition))  //50
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate50;
			GUI.Label(new Rect(335,465,27,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD60.Contains(ev.mousePosition))  //60
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate60;
			GUI.Label(new Rect(358,455,26,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD70.Contains(ev.mousePosition))  //70
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate70;
			GUI.Label(new Rect(390,450,27,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD80.Contains(ev.mousePosition))  //80
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate80;
			GUI.Label(new Rect(410,450,27,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD90.Contains(ev.mousePosition))  //90
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate90;
			GUI.Label(new Rect(430,457,25,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD100.Contains(ev.mousePosition))  //100
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate100;
			GUI.Label(new Rect(460,470,40,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD110.Contains(ev.mousePosition))  //110
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate110;
			GUI.Label(new Rect(475,500,39,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD120.Contains(ev.mousePosition))  //120
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate120;
			GUI.Label(new Rect(480,513,40,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD130.Contains(ev.mousePosition))  //130
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate130;
			GUI.Label(new Rect(483,531,38,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD140.Contains(ev.mousePosition))  //140
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate140;
			GUI.Label(new Rect(483,544,42,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		if (Rect_FD150.Contains(ev.mousePosition))  //150
		{
			Main.sty_enlargeknob.normal.background = Main.t2d_Feedrate150;
			GUI.Label(new Rect(475,557,52,30),"",Main.sty_enlargeknob);
			Main.mainWindowDrag = false;
		}
		
	}
}
