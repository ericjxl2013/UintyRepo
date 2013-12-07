using UnityEngine;
using System.Collections;

public class  G41_G01G01  {
	
	//
	public void main (ref MotionInfo motion_data1, ref MotionInfo motion_data2) 
	{
		float k1;
		float k2;
		float b1;
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
		
		//K1不存在,k2不存在
		if(motion_data1.DisplayStart.x == motion_data1.DisplayTarget.x && motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
		{//档半径变化时，补偿半径12可能会发生变化
			if(motion_data2.DisplayTarget.y > motion_data2.DisplayStart.y && motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)
			{
				 motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;
				 motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;   
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
			}
		}
		else if(motion_data1.DisplayStart.x == motion_data1.DisplayTarget.x && motion_data2.DisplayStart.x != motion_data2.DisplayTarget.x)//K1不存在,k2存在
		{
			k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
			b2 = Radius2*Mathf.Sqrt(1 + k2*k2);
			
			if(motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)//第一条直线向上
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius1;
				motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b2;
			}
			else//第一条直线向下
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius1;
				motion_data1.DisplayTarget.y = k2*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b2;
			}
		}
		else if(motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x && motion_data2.DisplayStart.x != motion_data1.DisplayStart.x)//K2不存在,k1存在
		{
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);
			b1 = Radius1*Mathf.Sqrt(1 + k1*k1);
			
			if(motion_data2.DisplayTarget.y > motion_data2.DisplayStart.y)//第二条直线方向向上
			{
			   	 motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2;
			   	 motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b1;
		    }
			else //第二条直线向下
			{ 
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2;
			   	motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b1;
			}
		}
		else //K2存在,k1存在
		{
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);
			k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
			b2 = Radius2*Mathf.Sqrt(1 + k2*k2);
			b1 = Radius1*Mathf.Sqrt(1 + k1*k1);
			
			if(motion_data1.DisplayTarget.x > motion_data1.DisplayStart.x)//右侧象限
			{
				if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
				{
					motion_data1.DisplayTarget.x = (b2 - b1)/(k1 - k2) + motion_data2.DisplayStart.x;
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b1;

				}
				else
				{
					motion_data1.DisplayTarget.x = ( - b2 - b1)/(k1 - k2) + motion_data2.DisplayStart.x;
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y + b1;

				}
			}
			else //左侧象限
			{
				if(motion_data2.DisplayTarget.x > motion_data2.DisplayStart.x)
				{
					motion_data1.DisplayTarget.x = ( b2 + b1 )/( k1 - k2 ) + motion_data2.DisplayStart.x;
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b1;

				}
				else
				{
					motion_data1.DisplayTarget.x = (- b2 + b1)/(k1 - k2) + motion_data2.DisplayStart.x;
					motion_data1.DisplayTarget.y = k1*(motion_data1.DisplayTarget.x - motion_data2.DisplayStart.x) + motion_data2.DisplayStart.y - b1;
				}
			}
		}
	}
}	