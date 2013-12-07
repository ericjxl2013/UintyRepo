using UnityEngine;
using System.Collections;

public class G42_G01G03O  {//新作

	public void main(ref MotionInfo motion_data1, ref MotionInfo motion_data_circle,ref MotionInfo motion_data2) 
	{
		float k1;
		float k2;
		float Radius1;
		float Radius2;
		float Up_Down;	
		
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
		
		if(motion_data1.DisplayStart.y == motion_data2.DisplayStart.y)
		{
			if(motion_data1.DisplayStart.x < motion_data2.DisplayStart.x)
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y - Radius1;
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
					//Debug.LogError ("调试");
				}
				else
				{
					k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);				
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					//Debug.LogError ("调试");//
				}
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y + Radius1;
				
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
					//Debug.LogError ("调试");

				}
				else
				{
					k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);					
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					//Debug.LogError ("调试");
				}
			}
		}
		else
		{
			if(motion_data1.DisplayStart.y < motion_data2.DisplayStart.y)
				Up_Down = 1;
			else
				Up_Down = -1;
			
			if(motion_data1.DisplayStart.x == motion_data2.DisplayStart.x)
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1*Up_Down;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Up_Down;
					//Debug.LogError ("调试");
				}
				else 
				{
					k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
					if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						//Debug.LogError ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						//Debug.LogError ("调试");
					}
				}
			}
			else
			{
				k1 = (motion_data2.DisplayStart.y - motion_data1.DisplayStart.y)/(motion_data2.DisplayStart.x - motion_data1.DisplayStart.x);
				if(motion_data1.DisplayStart.x < motion_data2.DisplayStart.x)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x +  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y -  Radius1/Mathf.Sqrt (1 + k1*k1);
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Up_Down;
						//Debug.LogError ("调试1");
					}
					else 
					{
						k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.LogError ("调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.LogError ("调试");
						}
					}
				}
				else
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x -  Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y +  Radius1/Mathf.Sqrt (1 + k1*k1);
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Up_Down;
						//Debug.LogError ("调试");
					}
					else 
					{
						k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.LogError ("调试");
						}
						else//不具有镜像特征
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);							
							//Debug.LogError ("调试");
						}
					}
				}
			}
		}
	}
}
