using UnityEngine;
using System.Collections;

public class G41_G03G01 {
	

	public void main (ref MotionInfo motion_data1, ref MotionInfo motion_data2) {//圆弧直线G03G01内角
		float k2;
		float b2;
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
		
		float R = Vector3.Distance (motion_data1.DisplayTarget , motion_data1.Center_Point);
		
		if(motion_data2.DisplayTarget.x == motion_data1.DisplayTarget.x && motion_data2.DisplayTarget.y != motion_data1.DisplayTarget.y)
		{//第二段直线所在k2不存在			
			if(motion_data2.DisplayTarget.y > motion_data1.DisplayTarget.y)
			{	
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
				float a = (R - Radius1)*(R - Radius1);
				float b = Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2);
				if((a - b) < 0.000001f)
					a = b;
				motion_data1.DisplayTarget.y = motion_data1.Center_Point.y - Mathf.Sqrt (a - b);		
				//Debug.Log ("调试");
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;
				float a = (R - Radius1)*(R - Radius1);
				float b = Mathf.Pow (motion_data1.DisplayTarget.x - motion_data1.Center_Point.x,2);
				if((a - b) < 0.000001f)
					a = b;
				motion_data1.DisplayTarget.y = motion_data1.Center_Point.y + Mathf.Sqrt (a - b);
				//Debug.Log ("调试");
			}
		}
		else
		{
			{//k2存在
				k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
				b2 = Radius2*Mathf.Sqrt(1 + k2*k2);
				
				if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
				{
					float a = 1 + k2*k2;
					float b = - 2*motion_data1.Center_Point.x + 2*k2*(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y);
					float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y + b2 - motion_data1.Center_Point.y,2) - (R - Radius1)*(R - Radius1);
					float d = b*b - 4*a*c;
					if(d < 0.000001f)
						d = 0;
					motion_data1.DisplayTarget.x = (- Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y + b2;
					//Debug.Log ("调试");
				}	
				else
				{
					float a = 1 + k2*k2;
					float b = - 2*motion_data1.Center_Point.x + 2*k2*(- k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y);
					float c = Mathf.Pow (motion_data1.Center_Point.x,2) + Mathf.Pow( - k2*motion_data1.DisplayTarget.x + motion_data1.DisplayTarget.y - b2 - motion_data1.Center_Point.y,2) - (R - Radius1)*(R - Radius1);
					float d = b*b - 4*a*c;
					if(d < 0.000001f)
						d = 0;
					motion_data1.DisplayTarget.x = ( Mathf.Sqrt (d) - b)/(2*a);
					motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data1.DisplayTarget.y - b2;
					//Debug.Log ("调试");
				}
			}
		}
	}
}
