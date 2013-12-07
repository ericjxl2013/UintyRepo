using UnityEngine;
using System.Collections;

public class G42_G03G01  {

	public void main(ref MotionInfo motion_data1, ref MotionInfo motion_data2) 
	{
//		float k1;
		float k2;
//		float b1;
		float b2;
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
		float R = Vector3.Distance (motion_data1.Center_Point, motion_data1.DisplayStart);
		
		float e = motion_data1.Center_Point.y - motion_data2.DisplayStart.y;
		if(e < 0.0001f && e > -0.0001f)//精度可能要重新考虑
		{
			if(motion_data1.Center_Point.x < motion_data2.DisplayStart.x)
			{   
				if(motion_data2.DisplayTarget.x == motion_data2.DisplayStart.x)
				{
					if(motion_data2.DisplayStart.y < motion_data2.DisplayTarget.y)
					{
						motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1;//补偿半径不同时
						motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
						//Debug.Log ("调试");
					}
					else
					{
						motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;//补偿半径不同时
						float f = (R + Radius1)*(R + Radius1)- Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2);
						if(f < 0.000001f)
							f = 0;
						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - Mathf.Sqrt (f);
						//Debug.Log ("调试1");
					}
				}
				else
				{
					k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
					b2 = Radius2*Mathf.Sqrt (1 + k2*k2);		
					float a = 1 + k2*k2;
					float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y);
					float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
					float d = b*b - 4*a*c;
					if(d < 0.000001f)
						d = 0;					
					motion_data1.DisplayTarget.x = ( Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y - b2;
					//Debug.Log ("调试1");
				}
			}
			else
			{
				if(motion_data2.DisplayTarget.x == motion_data2.DisplayStart.x)
				{
					if(motion_data2.DisplayStart.y > motion_data2.DisplayTarget.y)
					{
						motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;//补偿半径不同时
						motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
						//Debug.Log ("调试");
					}
					else
					{
						motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1;//补偿半径不同时
						float f = (R + Radius1)*(R + Radius1)- Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2);
						if(f < 0.000001f)
							f = 0;
						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + Mathf.Sqrt (f);
						//Debug.Log ("调试");//待测试
					}
				}
				else
				{
					k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
					b2 = Radius2*Mathf.Sqrt (1 + k2*k2);
					float a = 1 + k2*k2;
					float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y);
					float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
					float d = b*b - 4*a*c;
					if( d < 0.000001f)
						d = 0;					
					motion_data1.DisplayTarget.x = (- Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y + b2;
					//Debug.Log ("调试1");
				}
			}
		}
		else
		{
			if(motion_data1.Center_Point.y < motion_data2.DisplayStart.y)
				Up_Down = 1;
			else
				Up_Down = -1;
			
			if(motion_data1.Center_Point.x == motion_data2.DisplayStart.x)
			{
				if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
				{
					motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Up_Down;
					motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + Up_Down*Mathf.Sqrt ((R + Radius1)*(R + Radius1) - Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2));
					//Debug.Log ("测试12");
				}
				else
				{
//					if(motion_data2.DisplayStart.y == motion_data2.DisplayTarget.y)
//					{
//						motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x;
//						motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Up_Down;
//						Debug.LogError ("调试");
//					}
//					else
//					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						b2 = Radius2*Mathf.Sqrt (1 + k2*k2);
						if(motion_data2.DisplayStart.x < motion_data2.DisplayTarget.x)
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							if(d < 0.000001f)
								d = 0;
							motion_data1.DisplayTarget.x = ( Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y - b2;
							//Debug.LogError ("调试");
						}
						else
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							if(d < 0.000001f)
								d = 0;							
							motion_data1.DisplayTarget.x = (- Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y + b2;
							//Debug.LogError ("调试");
						}
//					}
				}
			}
			else
			{
//				k1 = (motion_data2.DisplayStart.y - motion_data1.DisplayStart.y)/(motion_data2.DisplayStart.x - motion_data1.DisplayStart.x);
//				b1 = Radius1*Mathf.Sqrt (1 + k1*k1);			
				if(motion_data1.Center_Point.x < motion_data2.DisplayStart.x)
				{
					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
					{
//						if(motion_data2.DisplayStart.y < motion_data1.Center_Point.y)
//						{
//							motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius2;
//							motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - Mathf.Sqrt ((R + Radius1)*(R + Radius1) - Mathf.Pow (motion_data1.DisplayStart.x - motion_data1.Center_Point.x,2));
//							//Debug.Log ("调试");
//						}
//						else
//						{
							motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius2*Up_Down;
							motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + Up_Down*Mathf.Sqrt ((R + Radius1)*(R + Radius1) - Mathf.Pow (motion_data1.DisplayStart.x - motion_data1.Center_Point.x,2));
							//Debug.Log ("测试1");
//						}
					}
					else 
					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						b2 = Radius2*Mathf.Sqrt (1 + k2*k2);
						if(motion_data2.DisplayStart.x < motion_data2.DisplayTarget.x)
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*(- k2*motion_data2.DisplayTarget.x + motion_data2.DisplayTarget.y - b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data2.DisplayTarget.x + motion_data2.DisplayTarget.y - b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							if(d < 0.000001f)
								d = 0;
							motion_data1.DisplayTarget.x = (Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b2;
							//Debug.Log ("调试1");
						}
						else
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							if( d < 0.000001f)
								d = 0;							
							motion_data1.DisplayTarget.x = (- Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b2;
							//Debug.Log ("调试1");
						}
					}
				}
				else
				{//Debug.Log ("测试123");
					if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
					{
						motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius2*Up_Down;
						motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + Up_Down*Mathf.Sqrt ((R + Radius1)*(R + Radius1) - Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2));
						//Debug.Log ("测试");
					}
					else 
					{
						k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
						b2 = Radius2*Mathf.Sqrt (1 + k2*k2);
						if(motion_data2.DisplayStart.x < motion_data2.DisplayTarget.x)
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							//Debug.Log (d);
							if( d < 0.000001f)
								d = 0;						
							motion_data1.DisplayTarget.x = (Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b2;
							//Debug.Log ("调试");
						}
						else
						{
							float a = 1 + k2*k2;
							float b = -2*motion_data1.Center_Point.x + 2*k2*( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y);
							float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y,2) - (R + Radius1)*(R + Radius1);
							float d = b*b - 4*a*c;
							//Debug.Log (d);
							if(d < 0.000001f)
								d = 0;
							motion_data1.DisplayTarget.x = (- Mathf.Sqrt (d) - b)/(2*a);
							motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b2;
							//Debug.Log ("调试");
						}
					}
				}
			}
		}
	}
}


