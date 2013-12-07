//内容--增加脚本文件AuxiliaryMoveModule用于控制机床辅助部件的移动，姓名--刘旋，时间--2013-4-15
using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AuxiliaryMoveModule : MonoBehaviour {
//	ControlPanel Main;
	MoveControl MoveControl_script;
	ControlPanel Main;
	
	float x_axis_value = 0;
	float y_axis_value = 0;
	float z_axis_vlaue = 0;
	
	Transform X_L_part0;
	Transform X_L_part1;//X轴正向移动的第一个铁片
//	float xl1_s_p = 0;
//	float xl1_x_p = 0;
	float xl1_s_n = 0;
	float xl1_x_n = 0;
	Vector3 xl1_vec = new Vector3(0,0,0);
	Transform X_L_part2;//X轴正向移动的第二个铁片
//	float xl2_s_p = 0;
//	float xl2_x_p = 0;
	float xl2_s_n = 0;
	float xl2_x_n = 0;
	Vector3 xl2_vec = new Vector3(0,0,0);
	Transform X_L_part3;//X轴正向移动的第三个铁片
//	float xl3_s_p = 0;
//	float xl3_x_p = 0;
	float xl3_s_n = 0;
	float xl3_x_n = 0;
	Vector3 xl3_vec = new Vector3(0,0,0);
	Transform X_L_part4;//X轴正向移动的第四个铁片
//	float xl4_s_p = 0;
//	float xl4_x_p = 0;
	float xl4_s_n = 0;
	float xl4_x_n = 0;
	Vector3 xl4_vec = new Vector3(0,0,0);
	
	Transform X_R_part0;
	Transform X_R_part1;//X轴负向移动的的第一个铁片
//	float xr1_s_p = 0;
//	float xr1_x_p = 0;
	float xr1_s_n = 0;
	float xr1_x_n = 0;
	Vector3 xr1_vec = new Vector3(0,0,0);
	Transform X_R_part2;//X轴负向移动的的第二个铁片
//	float xr2_s_p = 0;
//	float xr2_x_p = 0;
	float xr2_s_n = 0;
	float xr2_x_n = 0;
	Vector3 xr2_vec = new Vector3(0,0,0);
	Transform X_R_part3;//X轴负向移动的的第三个铁片
//	float xr3_s_p = 0;
//	float xr3_x_p = 0;
	float xr3_s_n = 0;
	float xr3_x_n = 0;
	Vector3 xr3_vec = new Vector3(0,0,0);
	Transform X_R_part4;//X轴负向移动的的第四个铁片
//	float xr4_s_p = 0;
//	float xr4_x_p = 0;
	float xr4_s_n = 0;
	float xr4_x_n = 0;
	Vector3 xr4_vec = new Vector3(0,0,0);
	
	Transform Y_Part0;
	Transform Y_Part1;
	Vector3 y1_vec = new Vector3(0, 0, 0);
	Transform Y_Part2;
	float y1_s_n = 0;
	float y1_y_n = 0;
//	float y1_s_p = 0;
//	float y1_y_p = 0;
	Vector3 y2_vec = new Vector3(0, 0, 0);
	Transform Y_Part3;
	float y2_s_n = 0;
	float y2_y_n = 0;
//	float y2_s_p = 0;
//	float y2_y_p = 0;
	Vector3 y3_vec = new Vector3(0, 0, 0);
	float y3_s_n = 0;
	float y3_y_n = 0;
//	float y3_s_p = 0;
//	float y3_y_p = 0;
	
	Transform Z_Part0;
	Transform Z_Part1;
	Vector3 z1_vec = new Vector3(0, 0, 0);
	float z1_s_p = 0;
	float z1_z_p = 0;
	Transform Z_Part2;
	Vector3 z2_vec = new Vector3(0, 0, 0);
	float z2_s_p = 0;
	float z2_z_p = 0;
	Transform Z_Part3;
	Vector3 z3_vec = new Vector3(0, 0, 0);
	float z3_s_p = 0;
	float z3_z_p = 0;
	
	float x_target_min = 0;
	float x_target_max = 0;
	
	float xl_1_max = 0;
	float xl_2_max = 0;
	float xl_3_max = 0;
	float xl_4_max = 0;
	
	float xl_1_min = 0;
	float xl_2_min = 0;
	float xl_3_min = 0;
	float xl_4_min = 0;

	float xr_1_max = 0;
	float xr_2_max = 0;
	float xr_3_max = 0;
	float xr_4_max = 0;
	
	float xr_1_min = 0;
	float xr_2_min = 0;
	float xr_3_min = 0;
	float xr_4_min = 0;
	
	float y_target_min = 0;
	float y_target_max = 0;
	float y1_max = 0;
	float y2_max = 0;
	float y3_max = 0;
	float y1_min = 0;
	float y2_min = 0;
	float y3_min = 0;
	
	float z_target_min = 0;
	float z_target_max = 0;
	float z1_max = 0;
	float z2_max = 0;
	float z3_max = 0;
	float z1_min = 0;
	float z2_min = 0;
	float z3_min = 0;

	// Use this for initialization
	void Start () {
//		Main=GameObject.Find("MainScript").GetComponent<ControlPanel>();
		MoveControl_script = GameObject.Find("move_control").GetComponent<MoveControl>();
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
		
		
		
		//X轴防护壳位置初始化
		X_L_part0 = GameObject.Find("XYZ protecting crust_16").transform;
		X_L_part0.localPosition = new Vector3(-0.03949989f, 0.08424979f, 1.067881f);
		X_R_part0 = GameObject.Find("XYZ protecting crust_29").transform;
		X_R_part0.localPosition = new Vector3(-0.03950011f, 0.08425027f, -1.089167f );
		
		X_L_part1=GameObject.Find("XYZ protecting crust_17").transform;
		X_L_part2=GameObject.Find("XYZ protecting crust_18").transform;
		X_L_part3=GameObject.Find("XYZ protecting crust_19").transform;
		X_L_part4=GameObject.Find("XYZ protecting crust_20").transform;
		
		X_R_part1=GameObject.Find("XYZ protecting crust_28").transform;
		X_R_part2=GameObject.Find("XYZ protecting crust_27").transform;
		X_R_part3=GameObject.Find("XYZ protecting crust_26").transform;
		X_R_part4=GameObject.Find("XYZ protecting crust_25").transform;
		
		//X轴左边
		xl1_vec = X_L_part1.localPosition;
		X_L_part1.localPosition = new Vector3(xl1_vec.x, xl1_vec.y, 1.05116f);
//		xl1_s_p = 0.8860297f;
//		xl1_x_p = 0.2339703f;
		xl1_s_n = 1.05116f;
		xl1_x_n = -0.2453703f;
		
		xl2_vec = X_L_part2.localPosition;
		X_L_part2.localPosition = new Vector3(xl2_vec.x, xl2_vec.y, 1.03203f);
//		xl2_s_p = 0.7086622f;
//		xl2_x_p = 0.07467425f;
		xl2_s_n = 1.03203f;
		xl2_x_n = -0.08166254f;
		
		xl3_vec = X_L_part3.localPosition;
		X_L_part3.localPosition = new Vector3(xl3_vec.x, xl3_vec.y, 1.010947f);
//		xl3_s_p = 0.5323325f;
//		xl3_x_p = -0.08166254f;
		xl3_s_n = 1.010947f;
		xl3_x_n = 0.07467425f;
		
		xl4_vec = X_L_part4.localPosition;
		X_L_part4.localPosition = new Vector3(xl4_vec.x, xl4_vec.y, 0.9901921f);
//		xl4_s_p = 0.3501807f;
//		xl4_x_p = -0.2453703f;
		xl4_s_n = 0.9901921f;
		xl4_x_n = 0.2339703f;
		
		
		//用各个防护壳与workbench之间的相对距离来判断各防护壳的位置
		x_target_min = -0.4093075f;
		xl_4_max = Mathf.Abs(0.3501807f - x_target_min);
		xl_3_max = Mathf.Abs(0.5323325f - x_target_min);
		xl_2_max = Mathf.Abs(0.7086622f - x_target_min);
		xl_1_max = Mathf.Abs(0.8860297f - x_target_min);
		
		x_target_max = 0.3906925f;
		xl_1_min = Mathf.Abs(1.05116f - x_target_max);
		xl_2_min = Mathf.Abs(1.03203f - x_target_max);
		xl_3_min = Mathf.Abs(1.010947f - x_target_max);
		xl_4_min = Mathf.Abs(0.9901921f - x_target_max);
		
		xr_1_min = Mathf.Abs(-1.069998f - x_target_min);
		xr_2_min = Mathf.Abs(-1.048079f - x_target_min);
		xr_3_min = Mathf.Abs(-1.027101f - x_target_min);
		xr_4_min = Mathf.Abs(-1.006624f - x_target_min);
		
		xr_1_max = Mathf.Abs(-0.9166175f - x_target_max);
		xr_2_max = Mathf.Abs(-0.7381014f - x_target_max);
		xr_3_max = Mathf.Abs(-0.5537437f - x_target_max);
		xr_4_max = Mathf.Abs(-0.3722782f - x_target_max);
		
		
		//X轴右边
		xr1_vec = X_R_part1.localPosition;
		X_R_part1.localPosition = new Vector3(xr1_vec.x, xr1_vec.y, -1.069998f);
//		xr1_s_p = -1.069998f;
//		xr1_x_p = 0.237312f;
		xr1_s_n = -0.9166175f;
		xr1_x_n = -0.2589108f;
		
		xr2_vec = X_R_part2.localPosition;
		X_R_part2.localPosition = new Vector3(xr2_vec.x, xr2_vec.y, -1.048079f);
//		xr2_s_p = -1.048079f;
//		xr2_x_p = 0.08071482f;
		xr2_s_n = -0.7381014f;
		xr2_x_n = -0.0984808f;
		
		xr3_vec = X_R_part3.localPosition;
		X_R_part3.localPosition = new Vector3(xr3_vec.x, xr3_vec.y, -1.027101f);
//		xr3_s_p = -1.027101f;
//		xr3_x_p = -0.08266485f;
		xr3_s_n = -0.5537437f;
		xr3_x_n = 0.06859339f;
		
		xr4_vec = X_R_part4.localPosition;
		X_R_part4.localPosition = new Vector3(xr4_vec.x, xr4_vec.y, -1.006624f);
//		xr4_s_p = -1.006624f;
//		xr4_x_p = -0.2436533f;
		xr4_s_n = -0.3722782f;
		xr4_x_n = 0.230925f;
		
		//Y轴防护壳位置初始化
		Y_Part0 = GameObject.Find("XYZ protecting crust_8").transform;
		Y_Part0.localPosition = new Vector3(-1.317677f, Y_Part0.localPosition.y, Y_Part0.localPosition.z);
		Y_Part1 = GameObject.Find("XYZ protecting crust_9").transform;
		y1_vec = Y_Part1.localPosition;
		Y_Part1.localPosition = new Vector3(-1.299423f, y1_vec.y, y1_vec.z);
		y1_s_n = -1.299423f;
		y1_y_n = -0.1838782f;
		
		Y_Part2 = GameObject.Find("XYZ protecting crust_10").transform;
		y2_vec = Y_Part2.localPosition;
		Y_Part2.localPosition = new Vector3(-1.265446f, y2_vec.y, y2_vec.z);
		y2_s_n = -1.265446f;
		y2_y_n = -0.06399874f;
		
		Y_Part3 = GameObject.Find("XYZ protecting crust_11").transform;
		y3_vec = Y_Part3.localPosition;
		Y_Part3.localPosition = new Vector3(-1.228281f, y3_vec.y, y3_vec.z);
		y3_s_n = -1.228281f;
		y3_y_n = 0.05633543f;
//		y3_s_p = -0.8532348f;
//		y3_y_p = -0.1838782f;
		
//		//y轴各个防护壳与Y轴之前的距离关系(绝对坐标)
//		y_target_min = -0.1812892f;
//		y_target_max = 0.3187109f;
//		y3_min = Mathf.Abs(-0.5539923f - y_target_min);
//		y2_min = Mathf.Abs(-0.5911572f - y_target_min);
//		y1_min = Mathf.Abs(-0.6251342f - y_target_min);
//		y3_max = Mathf.Abs(-0.178946f - y_target_max);
//		y2_max = Mathf.Abs(-0.3364451f - y_target_max);
//		y1_max = Mathf.Abs(-0.4903016f - y_target_max);
		
		//y轴各个防护壳与Y轴之前的距离关系(绝对坐标)
		y_target_min = 0.1812892f;
		y_target_max = -0.3187109f;
		y3_min = Mathf.Abs(1.228281f - y_target_min);
		y2_min = Mathf.Abs(1.265446f - y_target_min);
		y1_min = Mathf.Abs(1.299423f - y_target_min);
		y3_max = Mathf.Abs(0.8532348f - y_target_max);
		y2_max = Mathf.Abs(1.010734f - y_target_max);
		y1_max = Mathf.Abs(1.16459f - y_target_max);
		
		
		
		//Z轴防护壳位置初始化
		Z_Part0 = GameObject.Find("XYZ protecting crust_7").transform;
		Z_Part0.localPosition = new Vector3(Z_Part0.localPosition.x, -0.01420498f, Z_Part0.localPosition.z);
		Z_Part1 = GameObject.Find("XYZ protecting crust_6").transform;
		z1_vec = Z_Part1.localPosition;
		Z_Part1.localPosition = new Vector3(z1_vec.x, -0.006193399f, z1_vec.z);
		z1_s_p = -0.006193399f;
		z1_z_p = 2.003772f;
		Z_Part2 = GameObject.Find("XYZ protecting crust_5").transform;
		z2_vec = Z_Part2.localPosition;
		Z_Part2.localPosition = new Vector3(z2_vec.x, -0.004696131f, z2_vec.z);
		z2_s_p = -0.004696131f;
		z2_z_p = 1.862766f;
		Z_Part3 = GameObject.Find("XYZ protecting crust_4").transform;
		z3_vec = Z_Part3.localPosition;
		Z_Part3.localPosition = new Vector3(z3_vec.x, -0.0004784465f, z3_vec.z);
		z3_s_p = -0.0004784465f;
		z3_z_p = 1.73276f;
		
		
		//z轴各个防护壳与Z轴之前的距离关系
		z_target_min = 1.609089f;
		z_target_max = 2.119089f;
		z1_min = Mathf.Abs(-0.006193399f - z_target_min);
		z2_min = Mathf.Abs(-0.004696131f - z_target_min);
		z3_min = Mathf.Abs(-0.0004784465f - z_target_min);
		z1_max = Mathf.Abs(0.1091235f - z_target_max);
		z2_max = Mathf.Abs(0.2516267f - z_target_max);
		z3_max = Mathf.Abs(0.3858505f - z_target_max);

		X_Negative_Keeper();
		Y_Negative_Keeper();
		Z_Positive_Keeper();
	}
	
	void FixedUpdate()
	{
		//X轴负向移动
		if(MoveControl_script.X_part.localPosition.z - x_axis_value < 0)
		{
			X_Negative_Move();	
		}
		
		//X轴正向移动
		if(MoveControl_script.X_part.localPosition.z - x_axis_value > 0)
		{
			X_Positive_Move();
		}
		
		//Y轴负向移动
		if(MoveControl_script.Y_part.localPosition.x - y_axis_value < 0)
		{
			Y_Negative_Move();
//			Y_Negative_Keeper();
		}
		
		//Y轴正向移动
		if(MoveControl_script.Y_part.localPosition.x - y_axis_value > 0)
		{
			Y_Positive_Move();
//			Y_Negative_Keeper();
		}
		
		//Z轴负向
		if(MoveControl_script.Z_part.localPosition.y - z_axis_vlaue < 0)
		{
			Z_Negative_Move();
		}
	
		//Z轴正向
		if(MoveControl_script.Z_part.localPosition.y - z_axis_vlaue > 0)
		{
			Z_Positive_Move();
		}
		
		x_axis_value = MoveControl_script.X_part.localPosition.z;
		y_axis_value = MoveControl_script.Y_part.localPosition.x;
		z_axis_vlaue = MoveControl_script.Z_part.localPosition.y;
	}
	
	//X轴防护壳位置初始化
	void X_Negative_Keeper()
	{
		//左边的防护壳
		if(MoveControl_script.X_part.localPosition.z < xl4_x_n)
			X_L_part4.localPosition = new Vector3(xl4_vec.x, xl4_vec.y, (MoveControl_script.X_part.localPosition.z - xl4_x_n) + xl4_s_n);
		else
			X_L_part4.localPosition = new Vector3(xl4_vec.x, xl4_vec.y, xl4_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xl3_x_n)
			X_L_part3.localPosition = new Vector3(xl3_vec.x, xl3_vec.y, (MoveControl_script.X_part.localPosition.z - xl3_x_n) + xl3_s_n);
		else
			X_L_part3.localPosition = new Vector3(xl3_vec.x, xl3_vec.y, xl3_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xl2_x_n)
			X_L_part2.localPosition = new Vector3(xl2_vec.x, xl2_vec.y, (MoveControl_script.X_part.localPosition.z - xl2_x_n) + xl2_s_n);
		else
			X_L_part2.localPosition = new Vector3(xl2_vec.x, xl2_vec.y, xl2_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xl1_x_n)
			X_L_part1.localPosition = new Vector3(xl1_vec.x, xl1_vec.y, (MoveControl_script.X_part.localPosition.z - xl1_x_n) + xl1_s_n);
		else
			X_L_part1.localPosition = new Vector3(xl1_vec.x, xl1_vec.y, xl1_s_n);
		
		//右边的防护壳
		if(MoveControl_script.X_part.localPosition.z < xr4_x_n)
			X_R_part4.localPosition = new Vector3(xr4_vec.x, xr4_vec.y, (MoveControl_script.X_part.localPosition.z - xr4_x_n) + xr4_s_n);
		else
			X_R_part4.localPosition = new Vector3(xr4_vec.x, xr4_vec.y, xr4_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xr3_x_n)
			X_R_part3.localPosition = new Vector3(xr3_vec.x, xr3_vec.y, (MoveControl_script.X_part.localPosition.z - xr3_x_n) + xr3_s_n);
		else
			X_R_part3.localPosition = new Vector3(xr3_vec.x, xr3_vec.y, xr3_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xr2_x_n)
			X_R_part2.localPosition = new Vector3(xr2_vec.x, xr2_vec.y, (MoveControl_script.X_part.localPosition.z - xr2_x_n) + xr2_s_n);
		else
			X_R_part2.localPosition = new Vector3(xr2_vec.x, xr2_vec.y, xr2_s_n);
		
		if(MoveControl_script.X_part.localPosition.z < xr1_x_n)
			X_R_part1.localPosition = new Vector3(xr1_vec.x, xr1_vec.y, (MoveControl_script.X_part.localPosition.z - xr1_x_n) + xr1_s_n);
		else
			X_R_part1.localPosition = new Vector3(xr1_vec.x, xr1_vec.y, xr1_s_n);	
	}
	
	//X轴防护壳负向移动
	void X_Negative_Move()
	{
		//左边的防护壳
		if(X_L_part4.localPosition.z - MoveControl_script.X_part.localPosition.z > xl_4_max)
		{
			X_L_part4.localPosition = new Vector3(xl4_vec.x, xl4_vec.y, MoveControl_script.X_part.localPosition.z + xl_4_max);
			if(X_L_part3.localPosition.z - MoveControl_script.X_part.localPosition.z > xl_3_max)
			{
				X_L_part3.localPosition = new Vector3(xl3_vec.x, xl3_vec.y, MoveControl_script.X_part.localPosition.z + xl_3_max);
				if(X_L_part2.localPosition.z - MoveControl_script.X_part.localPosition.z > xl_2_max)
				{
					X_L_part2.localPosition = new Vector3(xl2_vec.x, xl2_vec.y, MoveControl_script.X_part.localPosition.z + xl_2_max);
					if(X_L_part1.localPosition.z - MoveControl_script.X_part.localPosition.z > xl_1_max)
					{
						X_L_part1.localPosition = new Vector3(xl1_vec.x, xl1_vec.y, MoveControl_script.X_part.localPosition.z + xl_1_max);
					}
				}
			}
		}
			
		//右边的防护壳
		if(Mathf.Abs( X_R_part4.localPosition.z - MoveControl_script.X_part.localPosition.z ) < xr_4_min)
		{
			X_R_part4.localPosition = new Vector3(xr4_vec.x, xr4_vec.y, MoveControl_script.X_part.localPosition.z - xr_4_min);
			if(Mathf.Abs( X_R_part3.localPosition.z - MoveControl_script.X_part.localPosition.z )< xr_3_min)
			{
				X_R_part3.localPosition = new Vector3(xr3_vec.x, xr3_vec.y, MoveControl_script.X_part.localPosition.z - xr_3_min);
				if(Mathf.Abs( X_R_part2.localPosition.z - MoveControl_script.X_part.localPosition.z) < xr_2_min)
				{
					X_R_part2.localPosition = new Vector3(xr2_vec.x, xr2_vec.y, MoveControl_script.X_part.localPosition.z - xr_2_min);
					if(Mathf.Abs( X_R_part1.localPosition.z - MoveControl_script.X_part.localPosition.z) < xr_1_min)
					{
						X_R_part1.localPosition = new Vector3(xr1_vec.x, xr1_vec.y, MoveControl_script.X_part.localPosition.z - xr_1_min);
					}
				}
			}
		}
	}
	
	//X轴正向移动
	void X_Positive_Move()
	{
		//左边的防护壳
		if(X_L_part4.localPosition.z - MoveControl_script.X_part.localPosition.z < xl_4_min)
		{
			X_L_part4.localPosition = new Vector3(xl4_vec.x, xl4_vec.y, MoveControl_script.X_part.localPosition.z + xl_4_min);
			if(X_L_part3.localPosition.z - MoveControl_script.X_part.localPosition.z < xl_3_min)
			{
				X_L_part3.localPosition = new Vector3(xl3_vec.x, xl3_vec.y, MoveControl_script.X_part.localPosition.z + xl_3_min);
				if(X_L_part2.localPosition.z - MoveControl_script.X_part.localPosition.z < xl_2_min)
				{
					X_L_part2.localPosition = new Vector3(xl2_vec.x, xl2_vec.y, MoveControl_script.X_part.localPosition.z + xl_2_min);
					if(X_L_part1.localPosition.z - MoveControl_script.X_part.localPosition.z < xl_1_min)
					{
						X_L_part1.localPosition = new Vector3(xl1_vec.x, xl1_vec.y, MoveControl_script.X_part.localPosition.z + xl_1_min);
					}
				}
			}
		}
		
		//右边的防护壳
		if(Mathf.Abs(X_R_part4.localPosition.z - MoveControl_script.X_part.localPosition.z) > xr_4_max)
		{
			X_R_part4.localPosition = new Vector3(xr4_vec.x, xr4_vec.y, MoveControl_script.X_part.localPosition.z - xr_4_max);
			if(Mathf.Abs(X_R_part3.localPosition.z - MoveControl_script.X_part.localPosition.z) > xr_3_max)
			{
				X_R_part3.localPosition = new Vector3(xr3_vec.x, xr3_vec.y, MoveControl_script.X_part.localPosition.z - xr_3_max);
				if(Mathf.Abs(X_R_part2.localPosition.z - MoveControl_script.X_part.localPosition.z) > xr_2_max)
				{
					X_R_part2.localPosition = new Vector3(xr2_vec.x, xr2_vec.y, MoveControl_script.X_part.localPosition.z - xr_2_max);
					if(Mathf.Abs(X_R_part1.localPosition.z - MoveControl_script.X_part.localPosition.z) > xr_1_max)
					{
						X_R_part1.localPosition = new Vector3(xr1_vec.x, xr1_vec.y, MoveControl_script.X_part.localPosition.z - xr_1_max);
					}
				}
			}
		}
	}
	
	//Y轴防护壳位置初始化
	void Y_Negative_Keeper()
	{
		//外边的防护壳
		if(MoveControl_script.Y_part.localPosition.x < y3_y_n)
			Y_Part3.localPosition = new Vector3(Mathf.Abs(MoveControl_script.Y_part.localPosition.x - y3_y_n) + y3_s_n, y3_vec.y, y3_vec.z);
		else
			Y_Part3.localPosition = new Vector3(y3_s_n, y3_vec.y, y3_vec.z);
		
		if(MoveControl_script.Y_part.localPosition.x < y2_y_n)
			Y_Part2.localPosition = new Vector3(Mathf.Abs(MoveControl_script.Y_part.localPosition.x - y2_y_n) + y2_s_n, y2_vec.y, y2_vec.z);
		else
			Y_Part2.localPosition = new Vector3(y2_s_n, y2_vec.y, y2_vec.z);
		
		if(MoveControl_script.Y_part.localPosition.x < y1_y_n)
			Y_Part1.localPosition = new Vector3(Mathf.Abs(MoveControl_script.Y_part.localPosition.x - y1_y_n) + y1_s_n, y1_vec.y, y1_vec.z);
		else
			Y_Part1.localPosition = new Vector3(y1_s_n, y1_vec.y, y1_vec.z);
	}
	
	//Todo
	//Y轴负向移动
	void Y_Negative_Move()
	{
		if(Mathf.Abs(-Y_Part3.localPosition.x - MoveControl_script.Y_part.localPosition.x) > y3_max)
		{
			Y_Part3.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y3_max,  y3_vec.y,  y3_vec.z);
			if(Mathf.Abs(Y_Part2.localPosition.x + MoveControl_script.Y_part.localPosition.x) > y2_max)
			{
				Y_Part2.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y2_max,  y2_vec.y,  y2_vec.z);
				if(Mathf.Abs(Y_Part1.localPosition.x + MoveControl_script.Y_part.localPosition.x) > y1_max)
				{
					Y_Part1.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y1_max, y1_vec.y, y1_vec.z);
				}
			}
		}
	}
	
	//Todo
	//Y轴正向移动
	void Y_Positive_Move()
	{
		if(Mathf.Abs(-Y_Part3.localPosition.x - MoveControl_script.Y_part.localPosition.x) < y3_min)
		{
			Y_Part3.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y3_min, y3_vec.y, y3_vec.z);
			if(Mathf.Abs(-Y_Part2.localPosition.x - MoveControl_script.Y_part.localPosition.x) < y2_min)
			{
				Y_Part2.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y2_min, y2_vec.y, y2_vec.z);
				if(Mathf.Abs(-Y_Part1.localPosition.x - MoveControl_script.Y_part.localPosition.x) < y1_min)
				{
					Y_Part1.localPosition = new Vector3(-MoveControl_script.Y_part.localPosition.x - y1_min, y1_vec.y, y1_vec.z);
				}
			}
		}
	}
	
	//Z轴防护壳位置初始化
	void Z_Positive_Keeper()
	{
		//下面的防护壳
		if(MoveControl_script.Z_part.localPosition.y > z1_z_p)
			Z_Part1.localPosition = new Vector3(z1_vec.x, Mathf.Abs(MoveControl_script.Z_part.localPosition.y - z1_z_p) + z1_s_p, z1_vec.z);
		else
			Z_Part1.localPosition = new Vector3(z1_vec.x, z1_s_p, z1_vec.z);
		
		if(MoveControl_script.Z_part.localPosition.y > z2_z_p)
			Z_Part2.localPosition = new Vector3(z2_vec.x, Mathf.Abs(MoveControl_script.Z_part.localPosition.y - z2_z_p) + z2_s_p, z2_vec.z);
		else
			Z_Part2.localPosition = new Vector3(z2_vec.x, z2_s_p, z2_vec.z);
		
		if(MoveControl_script.Z_part.localPosition.y > z3_z_p)
			Z_Part3.localPosition = new Vector3(z3_vec.x, Mathf.Abs(MoveControl_script.Z_part.localPosition.y - z3_z_p) + z3_s_p, z3_vec.z);
		else
			Z_Part3.localPosition = new Vector3(z3_vec.x, z3_s_p, z3_vec.z);
	}
	
	//Z轴负向移动
	void Z_Negative_Move()
	{
		if(Mathf.Abs(Z_Part3.localPosition.y - MoveControl_script.Z_part.localPosition.y) < z3_min)
		{
			Z_Part3.localPosition = new Vector3(z3_vec.x, MoveControl_script.Z_part.localPosition.y - z3_min, z3_vec.z);
			if(Mathf.Abs(Z_Part2.localPosition.y - MoveControl_script.Z_part.localPosition.y) < z2_min)
			{
				Z_Part2.localPosition = new Vector3(z2_vec.x, MoveControl_script.Z_part.localPosition.y - z2_min, z2_vec.z);
				if(Mathf.Abs(Z_Part1.localPosition.y - MoveControl_script.Z_part.localPosition.y) < z1_min)
				{
					Z_Part1.localPosition = new Vector3(z1_vec.x, MoveControl_script.Z_part.localPosition.y - z1_min, z1_vec.z);
				}
			}
		}
	}
	
	//Z轴正向移动
	void Z_Positive_Move()
	{
		if(Mathf.Abs(Z_Part3.localPosition.y - MoveControl_script.Z_part.localPosition.y) > z3_max)
		{
			Z_Part3.localPosition = new Vector3(z3_vec.x, MoveControl_script.Z_part.localPosition.y - z3_max, z3_vec.z);
			if(Mathf.Abs(Z_Part2.localPosition.y - MoveControl_script.Z_part.localPosition.y) > z2_max)
			{
				Z_Part2.localPosition = new Vector3(z2_vec.x, MoveControl_script.Z_part.localPosition.y - z2_max, z2_vec.z);
				if(Mathf.Abs(Z_Part1.localPosition.y - MoveControl_script.Z_part.localPosition.y) > z1_max)
				{
					Z_Part1.localPosition = new Vector3(z1_vec.x, MoveControl_script.Z_part.localPosition.y - z1_max, z1_vec.z);
				}
			}
		}
	}
	
}
