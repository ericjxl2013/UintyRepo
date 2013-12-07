using UnityEngine;
using System.Collections;

public class G41_G01G03O  {


	public  void main (ref MotionInfo motion_data1,ref MotionInfo motion_data_circle, ref MotionInfo motion_data2) {
		float k1;
		float k2;
		float Radius1;
		float Radius2;
		
		//获取半径
		if(motion_data1.D_Value == 0)
			Radius1 = 0;
		else
			Radius1 = LoadRadiusValue.D_Value(motion_data1.D_Value);
		
		if(motion_data2.D_Value == 0)
			Radius2 = 0;
		else
			Radius2 = LoadRadiusValue.D_Value(motion_data2.D_Value);
		
		Radius1 = Mathf.Abs (Radius1);//确保都是正值
		Radius2 = Mathf.Abs (Radius2);
		
		
		if(motion_data1.DisplayTarget.x == motion_data1.DisplayStart.x)//第一段直线的k1不存在
		{
			if(motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)//第一段直线的矢量方向向上
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
//		        motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
		        	
				if(motion_data2.DisplayStart.x == motion_data2.Center_Point.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  + Radius2;	
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y)/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt(1 + k2*k2);
				    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt(1 + k2*k2);
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt(1 + k2*k2);
				    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt(1 + k2*k2);
						//Debug.Log ("调试");
					}
				}
			}
			else//第一段直线的矢量方向垂直向下
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x  + Radius1;
//		    	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
		    		
				if(motion_data2.DisplayStart.x == motion_data2.Center_Point.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y)/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt(1 + k2*k2);
				    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt(1 + k2*k2);
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt(1 + k2*k2);
				    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt(1 + k2*k2);
				   	 	//Debug.Log ("调试");
					}
				}
			}
		}
		else//第一段直线k1存在
		{
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);			
					
			if(k1 == 0)
			{				
				int Left_Right_Array;
				if(motion_data1.DisplayTarget.x > motion_data1.DisplayStart.x)
					Left_Right_Array = 1;
				else
					Left_Right_Array = -1;
				
//				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
			    motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1*Left_Right_Array;
				
				if(motion_data2.DisplayStart.x == motion_data2.Center_Point.x)
				{
					if(motion_data2.Center_Point.y > motion_data2.DisplayStart.y)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
				    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  + Radius2;
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
			    		motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  - Radius2;
						//Debug.Log ("调试");
					}
				}
				else 
				{
				    k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y)/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);	
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x  + Radius2*Left_Right_Array/Mathf.Sqrt(1 + k2*k2);
				    motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  + Radius2*Left_Right_Array*k2/Mathf.Sqrt(1 + k2*k2);	
			   		//Debug.Log ("调试1");
				}
			}			
			else if(motion_data2.DisplayStart.x > motion_data1.DisplayStart.x)//右侧象限
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x  - Radius1*k1/Mathf.Sqrt(1 + k1*k1);
				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y  + Radius1/Mathf.Sqrt(1 + k1*k1);
		
				if(motion_data2.DisplayStart.x == motion_data2.Center_Point.x)
				{
					if(motion_data2.Center_Point.y > motion_data2.DisplayStart.y)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;	//不具有镜像特征
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;	//不具有镜像特征
						//Debug.Log ("调试");
					}
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y)/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x  + Radius2/Mathf.Sqrt(1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  + Radius2*k2/Mathf.Sqrt(1 + k2*k2);	
						//Debug.Log ("调试1");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x  - Radius2/Mathf.Sqrt(1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  - Radius2*k2/Mathf.Sqrt(1 + k2*k2);			
						//Debug.Log ("调试");
					}
				}								
			}
			else//左侧象限
			{		
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x  + Radius1*k1/Mathf.Sqrt(1 + k1*k1);
				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y  - Radius1/Mathf.Sqrt(1 + k1*k1);
				
				if(motion_data2.DisplayStart.x == motion_data2.Center_Point.x)
				{
					if(motion_data2.Center_Point.y > motion_data2.DisplayStart.y)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;	//不具有镜像特征
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;	//不具有镜像特征
						//Debug.Log ("调试");
					}
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y)/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x  + Radius2/Mathf.Sqrt(1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  + Radius2*k2/Mathf.Sqrt(1 + k2*k2);
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x  - Radius2/Mathf.Sqrt(1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y  - Radius2*k2/Mathf.Sqrt(1 + k2*k2);
						//Debug.Log ("调试");
					}
				}
			}
		}
	}
}
