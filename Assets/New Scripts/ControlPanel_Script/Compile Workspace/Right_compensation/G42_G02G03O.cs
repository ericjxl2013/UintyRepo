using UnityEngine;
using System.Collections;

public class G42_G02G03O  {

	public void main(ref MotionInfo motion_data1,ref MotionInfo motion_data_circle, ref MotionInfo motion_data2) 
	{
		float k1;
		float k2;
		float Up_Down = 0;
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
		//保证圆弧连接型的圆心坐标为发生改变
	//	motion_data_circle.Center_Point = motion_data1.DisplayTarget;
		
		if(motion_data1.DisplayTarget.y == motion_data1.Center_Point.y)
		{
			if(motion_data2.DisplayStart.x > motion_data1.Center_Point.x)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
//				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				float e = motion_data2.DisplayStart.y - motion_data2.Center_Point.y;
				if(e < 0.00001f && e > -0.00001f)
				{
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
						//Debug.LogError ("调试");
					}
				}
				else
				{
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
						//Debug.LogError ("调试");
					}
					else
					{
						k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
						if(k2 > 0)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ( "调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
					}
				}
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;
//				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				float e = motion_data2.DisplayStart.y - motion_data2.Center_Point.y;
				if(e < 0.00001f && e > -0.00001f)
				{
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
						//Debug.LogError ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
					}
				}
				else
				{
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
						//Debug.LogError ("调试");
					}
					else
					{
						k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
						if(k2 > 0)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ( "调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
					}
				}
			}
		}
		else
		{
			if(motion_data1.DisplayTarget.y > motion_data1.Center_Point.y)//读一段圆弧终点和圆心所在的圆弧的直线方向向上
				Up_Down = 1;
			else
				Up_Down = -1;
			
			if(motion_data1.DisplayTarget.x == motion_data1.Center_Point.x)//读一段圆弧终点和圆心所在的圆弧的直线的斜率不存在
			{
//				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x;
				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y - Radius1*Up_Down;
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x && motion_data2.Center_Point.y > motion_data2.DisplayStart.y)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayTarget.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayTarget.y - Radius2;
				}
				else if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x && motion_data2.Center_Point.y <= motion_data2.DisplayStart.y)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
					//Debug.Log ( "调试");
				}
				else
				{
					Debug.Log (Up_Down);
					k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Up_Down/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Up_Down*k2/Mathf.Sqrt (1 + k2*k2);
					//Debug.Log ( "调试");//待检测//已检测
				}
			}
			else
			{
				k1 = (motion_data1.DisplayTarget.y - motion_data1.Center_Point.y)/(motion_data1.DisplayTarget.x - motion_data1.Center_Point.x);
				if(motion_data2.DisplayStart.x > motion_data1.Center_Point.x)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y - Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
						//Debug.Log ( "调试");
					}
					else 
					{
						k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);	
							// "调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
							//Debug.Log ( "调试");
						}
					}
				}
				else
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y + Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
					}
					else 
					{
						k2 = (motion_data2.DisplayStart.y - motion_data2.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data2.Center_Point.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);	
							// "调试");
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
					}
				}
			}
		}
	}
}
