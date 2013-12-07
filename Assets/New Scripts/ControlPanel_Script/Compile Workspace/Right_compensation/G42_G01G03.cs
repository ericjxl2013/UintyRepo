using UnityEngine;
using System.Collections;

public class G42_G01G03 {

	public void main (ref MotionInfo motion_data1, ref MotionInfo motion_data2) {//直线圆弧
	float k1;
	float b1;
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
		float R = Vector3.Distance (motion_data1.DisplayTarget,motion_data2.Center_Point);
		
		if(motion_data2.DisplayStart.x == motion_data1.DisplayStart.x)
		{//K1不存在
			 if(motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)
			{
				float a = motion_data2.Center_Point.y - motion_data2.DisplayStart.y;
				if(a < 0.000001f && a > -0.000001f)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1;
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				}
				else
				{
					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;
					float e = (R + Radius2)*(R + Radius2) - Mathf.Pow ((motion_data1.DisplayTarget.x - motion_data2.Center_Point.x),2);
					if(e < 0.000001f)
						e = 0;
					motion_data1.DisplayTarget.y = - Mathf.Sqrt (e) + motion_data2.Center_Point.y;
					//Debug.LogError ("调试");
				}
			}
			else
			{
				float a = motion_data2.Center_Point.y - motion_data2.DisplayStart.y;
				if(a < 0.000001f && a > -0.000001f)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y;
				}
				else
				{
					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
					float e = (R + Radius2)*(R + Radius2) - Mathf.Pow ((motion_data1.DisplayTarget.x - motion_data2.Center_Point.x),2);
					if(e < 0.000001f)
						e = 0;
					motion_data1.DisplayTarget.y = Mathf.Sqrt (e) + motion_data2.Center_Point.y;					
					//Debug.LogError ("调试");
				}		
			}
		}
		else
		{//K1存在
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);
			b1 = Radius1*Mathf.Sqrt(1 + k1*k1);
			if(motion_data1.DisplayTarget.x > motion_data1.DisplayStart.x)
			{//右象限
//				Vector3 Direction = motion_data1.DisplayTarget - motion_data1.DisplayStart;
//				Vector3 Direction2 = motion_data2.DisplayStart - motion_data2.Center_Point;
//				float Angle ;
//				Angle = Vector3.Angle (Direction, Direction2);
//				if(Angle > 89.999f && Angle < 90.001f)
//				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius2*k1/Mathf.Sqrt (1 + k1*k1);
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y - Radius2/Mathf.Sqrt (1 + k1*k1);
//				}
//				else
//				{
					float a = 1 + k1*k1;
					float b = -2.0f*motion_data2.Center_Point.x + 2.0f*k1*(- k1*motion_data2.DisplayStart.x + motion_data2.DisplayStart.y - b1 - motion_data2.Center_Point.y);
					float c = Mathf.Pow (motion_data2.Center_Point.x,2.0f) + Mathf.Pow((- k1*motion_data2.DisplayStart.x + motion_data2.DisplayStart.y - b1 - motion_data2.Center_Point.y),2.0f) - (R +  Radius2)*(R + Radius2);
					float d = b*b - 4*a*c;
					if(d < 0.000001f)
						d = 0;
					motion_data1.DisplayTarget.x = ( - Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b1;
					//Debug.LogError ("调试");//
//				}
				
			}
			else
			{//左象限
//				Vector3 Direction = motion_data1.DisplayTarget - motion_data1.DisplayStart;
//				Vector3 Direction2 = motion_data2.DisplayStart - motion_data2.Center_Point;
//				float Angle ;
//				Angle = Vector3.Angle (Direction, Direction2);
//
//				if(Angle > 89.999f && Angle < 90.001f)
//				{
//					motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius2*k1/Mathf.Sqrt (1 + k1*k1);
//					motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius2/Mathf.Sqrt (1 + k1*k1);
//				}
//				else
//				{
					float a = 1 + k1*k1;
					float b = - 2*motion_data2.Center_Point.x + 2*k1*(- k1*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b1 - motion_data2.Center_Point.y);
					float c = Mathf.Pow (motion_data2.Center_Point.x,2) + Mathf.Pow(- k1*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b1 - motion_data2.Center_Point.y,2) - (R + Radius2)*(R + Radius2);
					float d = b*b - 4*a*c;
					if(d < 0.000001f)
						d = 0;
					motion_data1.DisplayTarget.x = ( Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b1;
					//Debug.LogError ("调试");//
//				}	
			}
		}
	}
}
