using UnityEngine;
using System.Collections;

public class G41_G02G03O  {


	public void main (ref MotionInfo motion_data1,ref MotionInfo motion_data_circle, ref MotionInfo motion_data2) {
	
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
		
		
		if(motion_data1.DisplayTarget.y == motion_data1.Center_Point.y)
		{
			if(motion_data2.DisplayStart.x > motion_data1.Center_Point.x)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;
//				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayTarget.y - Radius2;
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						//Debug.Log ("调试");
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						//Debug.Log ("调试");
					}
				}
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
//				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayTarget.y + Radius2;
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					if(motion_data2.Center_Point.x > motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					}
					else
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
					}
				}
			}
		}
		else//motion_data1.DisplayTarget.y 与 motion_data1.Center_Point.y 不相等
		{
			if(motion_data1.DisplayTarget.y > motion_data1.Center_Point.y)//第一段圆弧的终点和圆心所在的直线方向向上
				Up_Down = 1;
			else//第一段圆弧的终点和圆心所在的直线方向向下
				Up_Down = -1;
			//Debug.Log ( "调试");
			if(motion_data1.Center_Point.x == motion_data2.DisplayStart.x)//第一段圆弧的终点和圆心所在的直线的斜率不存在
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y + Radius1*Up_Down;
				
				if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x && motion_data2.Center_Point.y > motion_data2.DisplayStart.y )//圆心连心直线的斜率不存在
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
				}
				else if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x && motion_data2.Center_Point.y < motion_data2.DisplayStart.y)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
				}
				else
				{
					k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Up_Down/Mathf.Sqrt (1 + k2*k2);
					motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2*Up_Down/Mathf.Sqrt (1 + k2*k2);
				}
			}
			else
			{
				k1 = (motion_data2.DisplayStart.y - motion_data1.Center_Point.y)/(motion_data2.DisplayStart.x - motion_data1.Center_Point.x);
				if(motion_data2.DisplayStart.x > motion_data1.Center_Point.x)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y + Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2;
					}
					else 
					{
						k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
					}
				}
				else
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1/Mathf.Sqrt (1 + k1*k1);
					motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y - Radius1*k1/Mathf.Sqrt (1 + k1*k1);
					if(motion_data2.Center_Point.x == motion_data2.DisplayStart.x)
					{
						motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x;
						motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2;
					}
					else 
					{
						k2 = (motion_data2.Center_Point.y - motion_data2.DisplayStart.y )/(motion_data2.Center_Point.x - motion_data2.DisplayStart.x);
						if(motion_data2.Center_Point.x < motion_data2.DisplayStart.x)
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
						else
						{
							motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2/Mathf.Sqrt (1 + k2*k2);
							motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*k2/Mathf.Sqrt (1 + k2*k2);
						}
					}
				}
			}	
	}
}
}