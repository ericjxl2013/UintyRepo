using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class MoveControl : MonoBehaviour {
	
	public AudioClip move_sound;
	ControlPanel Main;
	CooSystem CooSystem_Script;
//	LightNumber LightControl_Script;
	public Transform X_part;
	public Transform Y_part;
	public Transform Z_part;

	public float move_rate = 1f;
	public float speed_to_move = 0.10201F;
	
	//public Vector3 MachineZero = new Vector3(0.0288153f,1.301697f,-0.918393f);
	public Vector3 MachineZero;
	public Vector3 MachineZeroShift = new Vector3(-0.918393f,0.0288153f,1.301697f);
	public Vector3 MachinePoint = new Vector3(800f,500f,510f);
	public Vector3 MachineCoo = new Vector3(800f,500f,510f);
	
	public bool x_p = false;
	public bool x_n = false; 
	public bool y_p = false;
	public bool y_n = false;
	public bool z_p = false;
	public bool z_n = false;
	public float move_flag=0;
	
	bool move_sound_on = false;
	int sound_stop = 3;
	int sound_be4 = 3;
	
	double temp_x =0;
	double temp_y =0;
	double temp_z =0;
	
	public bool collision_xn = false;
	public bool collision_xp = false;
	public bool collision_yn = false;
	public bool collision_yp = false;
	public bool collision_zn = false;
	public bool collision_zp = false;
	
	void Awake () {
		
	}

	// Use this for initialization
	void Start () 
	{
		//MachineZero = new Vector3(-0.3187108f, 1.609089f, -0.4093075f);
		//To be modified
		MachineZero = new Vector3(0.1812892f, 2.119089f, 0.3906925f);
		
		X_part = GameObject.Find("X_axis1").transform;
		Y_part = GameObject.Find("Y_axis1").transform;
		Z_part = GameObject.Find("Z_axis1").transform;
		move_sound = (AudioClip)Resources.Load("Audio/move");
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		CooSystem_Script = GameObject.Find("MainScript").GetComponent<CooSystem>();
//		LightControl_Script = GameObject.Find("MainScript").GetComponent<LightNumber>();
	}
	
	void OnGUI () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sound_stop = 0;

		if(x_p)
			X_part.Translate(0,0,speed_to_move*Time.deltaTime*move_rate, Space.Self);
		
		if(x_n)
			X_part.Translate(0,0,-speed_to_move*Time.deltaTime*move_rate, Space.Self);
		
		if(y_p)
			//Y_part.Translate(speed_to_move*Time.deltaTime*move_rate,0,0, Space.Self);
			Y_part.Translate(-speed_to_move*Time.deltaTime*move_rate,0,0, Space.Self);
		
		if(y_n)
			//Y_part.Translate(-speed_to_move*Time.deltaTime*move_rate,0,0, Space.Self);
			Y_part.Translate(speed_to_move*Time.deltaTime*move_rate, 0, 0, Space.Self);
		
		if(z_p)
			Z_part.Translate(0,speed_to_move*Time.deltaTime*move_rate, 0, Space.Self);
		
		if(z_n)
			Z_part.Translate(0,-speed_to_move*Time.deltaTime*move_rate, 0, Space.Self);
		
		if(MachineZero.z - X_part.localPosition.z < 0)
		{
			X_part.localPosition = new Vector3(X_part.localPosition.x, X_part.localPosition.y, MachineZero.z);
			MachineCoo.x = 0f;
			x_p = false;
			if(Main.ProgREF)
			{
//				Debug.Log("x");
				CooSystem_Script.absolute_pos.x = CooSystem_Script.AbsoluteZero.x + MachineCoo.x;
				CooSystem_Script.relative_pos.x = CooSystem_Script.RelativeZero.x + MachineCoo.x;
				Main.x_return_zero = true;
			}
			else
			{
				CooSystem_Script.absolute_pos.x = CooSystem_Script.AbsoluteZero.x + MachineCoo.x;
				CooSystem_Script.relative_pos.x = CooSystem_Script.RelativeZero.x + MachineCoo.x;
				Main.x_return_zero = true;
			}
		}
		else if(MachineZero.z - X_part.localPosition.z > 0.8f)
		{
			X_part.localPosition = new Vector3(X_part.localPosition.x, X_part.localPosition.y, MachineZero.z-0.8f);
			MachineCoo.x = -800f;
			CooSystem_Script.absolute_pos.x = CooSystem_Script.AbsoluteZero.x + MachineCoo.x;
			CooSystem_Script.relative_pos.x = CooSystem_Script.RelativeZero.x + MachineCoo.x;
			Main.x_return_zero = false;
		}
		else
		{
			temp_x = (MachineZero.z - X_part.localPosition.z)*1000;
			MachineCoo.x = (float)(-Math.Round(temp_x, 3));
			CooSystem_Script.absolute_pos.x = CooSystem_Script.AbsoluteZero.x + MachineCoo.x;
			CooSystem_Script.relative_pos.x = CooSystem_Script.RelativeZero.x + MachineCoo.x;
			if(MachineZero.z - X_part.localPosition.z == 0)
				Main.x_return_zero = true;
			else
				Main.x_return_zero = false;
		}

		if(MachineZero.x - Y_part.localPosition.x < 0)
		{
			Y_part.localPosition = new Vector3(MachineZero.x, Y_part.localPosition.y, Y_part.localPosition.z);
			MachineCoo.y = 0f;
			y_p = false;
			if(Main.ProgREF)
			{
				CooSystem_Script.absolute_pos.y = CooSystem_Script.AbsoluteZero.y + MachineCoo.y;
				CooSystem_Script.relative_pos.y = CooSystem_Script.RelativeZero.y + MachineCoo.y;
				Main.y_return_zero = true;
			}
			else
			{
				CooSystem_Script.absolute_pos.y = CooSystem_Script.AbsoluteZero.y + MachineCoo.y;
				CooSystem_Script.relative_pos.y = CooSystem_Script.RelativeZero.y + MachineCoo.y;
				Main.y_return_zero = false;
			}
		}
		else if(MachineZero.x - Y_part.localPosition.x > 0.5f)
		{
			Y_part.localPosition = new Vector3(MachineZero.x - 0.5f, Y_part.localPosition.y, Y_part.localPosition.z);
			MachineCoo.y = -500f;
			y_n = false;
			CooSystem_Script.absolute_pos.y = CooSystem_Script.AbsoluteZero.y + MachineCoo.y;
			CooSystem_Script.relative_pos.y = CooSystem_Script.RelativeZero.y + MachineCoo.y;
			Main.y_return_zero = false;
		}
		else
		{
			temp_y = (MachineZero.x- Y_part.localPosition.x)*1000;
			MachineCoo.y = (float)(-Math.Round(temp_y, 3));
			CooSystem_Script.absolute_pos.y = CooSystem_Script.AbsoluteZero.y + MachineCoo.y;
			CooSystem_Script.relative_pos.y = CooSystem_Script.RelativeZero.y + MachineCoo.y;
			if(MachineZero.x - Y_part.localPosition.x == 0)
				Main.y_return_zero = true;
			else
				Main.y_return_zero = false;
		}
		
		if(MachineZero.y - Z_part.localPosition.y < 0)
		{
			Z_part.localPosition = new Vector3(Z_part.localPosition.x, MachineZero.y, Z_part.localPosition.z);
			MachineCoo.z = 0f;
			z_p = false;
			if(Main.ProgREF)
			{
				CooSystem_Script.absolute_pos.z = CooSystem_Script.AbsoluteZero.z + MachineCoo.z;
				CooSystem_Script.relative_pos.z = CooSystem_Script.RelativeZero.z + MachineCoo.z;
				Main.z_return_zero = true;
			}
			else
			{
				CooSystem_Script.absolute_pos.z = CooSystem_Script.AbsoluteZero.z + MachineCoo.z;
				CooSystem_Script.relative_pos.z = CooSystem_Script.RelativeZero.z + MachineCoo.z;
				Main.z_return_zero = false;
			}
		}
		else if(MachineZero.y - Z_part.localPosition.y > 0.51f)
		{
			Z_part.localPosition = new Vector3(Z_part.localPosition.x, MachineZero.y - 0.51f, Z_part.localPosition.z);
			MachineCoo.z = -510f;
			CooSystem_Script.absolute_pos.z = CooSystem_Script.AbsoluteZero.z + MachineCoo.z;
			CooSystem_Script.relative_pos.z = CooSystem_Script.RelativeZero.z + MachineCoo.z;
			Main.z_return_zero = false;
		}
		else
		{
			temp_z = (MachineZero.y - Z_part.localPosition.y)*1000;
			MachineCoo.z = (float)(-Math.Round(temp_z, 3));
			CooSystem_Script.absolute_pos.z = CooSystem_Script.AbsoluteZero.z + MachineCoo.z;
			CooSystem_Script.relative_pos.z = CooSystem_Script.RelativeZero.z + MachineCoo.z;
			if(MachineZero.y - Z_part.localPosition.y == 0)
				Main.z_return_zero = true;
			else
				Main.z_return_zero = false;
		}
		
		//移动声音循环启动
		if((x_n||x_p||y_n||y_p||z_n||z_p) && move_sound_on == false)
		{
			move_sound_on = true;
			audio.Play();
		}
		
		if(Mathf.Approximately(MachineCoo.x,-800f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.x,0f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.y,-500f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.y,0f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.z,-510f))
		{
			sound_stop++;
		}
		
		if(Mathf.Approximately(MachineCoo.z,0f))
		{
			sound_stop++;
		}
		
		//声音停止
		if((Input.GetMouseButtonUp(0) && Main.ProgREF == false)||(sound_stop > sound_be4))
		{
			audio.Stop();
			move_sound_on = false;
		}
		
		sound_be4 = sound_stop;
		
		if(x_n||x_p||y_n||y_p||z_n||z_p)
			move_sound_on = true;
		else
			move_sound_on = false;
	}
}
