using UnityEngine;
using System.Collections;

public class G41_G01G01O  {

	public void main (ref MotionInfo motion_data1, ref MotionInfo motion_data_circle, ref MotionInfo motion_data2) {
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
		
		//k1,k2都不存在的时候，两者的方向矢量方向相反
		if(motion_data1.DisplayStart.x == motion_data1.DisplayTarget.x && motion_data2.DisplayStart.x == motion_data2.DisplayTarget.x)
		{
			if(motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2;
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
			}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2;
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
			}
		}
		else if(motion_data1.DisplayStart.x == motion_data1.DisplayTarget.x && motion_data1.DisplayTarget.x != motion_data2.DisplayTarget.x)
		{//k1不存在,k2存在
			k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
			if(motion_data1.DisplayTarget.y > motion_data1.DisplayStart.y)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1;
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2*k2/Mathf.Sqrt(1 + k2*k2);
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2/Mathf.Sqrt(1 + k2*k2);
				
		    }
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1;	
				motion_data1.DisplayTarget.y = motion_data2.DisplayStart.y;
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*k2/Mathf.Sqrt(1 + k2*k2);
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2/Mathf.Sqrt(1 + k2*k2);	
			}
	    	}
		else if(motion_data1.DisplayStart.x != motion_data1.DisplayTarget.x && motion_data1.DisplayTarget.x == motion_data2.DisplayTarget.x)
		{//k1存在，k2不存在
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);
			
			if(motion_data2.DisplayTarget.y > motion_data2.DisplayStart.y)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x + Radius1*k1/Mathf.Sqrt(1 + k1*k1);
				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y - Radius1/Mathf.Sqrt(1 + k1*k1);				
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2;
			    motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
				
		  	}
			else
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1*k1/Mathf.Sqrt(1 + k1*k1);
				motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1/Mathf.Sqrt(1 + k1*k1);				
				motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2;
				motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y;
			}//修改过
		}
		else 
		{//k1,k2都存在
			k1 = (motion_data1.DisplayTarget.y - motion_data1.DisplayStart.y)/(motion_data1.DisplayTarget.x - motion_data1.DisplayStart.x);
			k2 = (motion_data2.DisplayTarget.y - motion_data2.DisplayStart.y)/(motion_data2.DisplayTarget.x - motion_data2.DisplayStart.x);
			int Left_Right_Array = 0;
			//标志左右象限
			if(motion_data1.DisplayTarget.x > motion_data1.DisplayStart.x)
				Left_Right_Array = 1;
			else
				Left_Right_Array = -1;
			
			if(k1 == 0)
			{
				motion_data1.DisplayTarget.x = motion_data2.DisplayStart.x;
		    	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1*Left_Right_Array;
				//Debug.Log ("调试");
		    	if(k2 > 0)
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
			    	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2);    	
				}
				else
				{
					motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
		    		motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2);
				}
			}
			else if(k1 > 0)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1*Left_Right_Array*k1/Mathf.Sqrt (1 + k1*k1);
			  	motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1*Left_Right_Array/Mathf.Sqrt (1 + k1*k1);
			 	
				if(k1 < k2)
				{
			  	  	motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
			  	  	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2); 
		    		//Debug.Log ("调试");
				}
		    	else 
		    	{
			  	 	motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
			  	 	motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2); 
		    		//Debug.Log ("调试");
				}
			}
			else if(k1 < 0)
			{
				motion_data1.DisplayTarget.x = motion_data1.DisplayTarget.x - Radius1*Left_Right_Array*k1/Mathf.Sqrt (1 + k1*k1);
			    motion_data1.DisplayTarget.y = motion_data1.DisplayTarget.y + Radius1*Left_Right_Array/Mathf.Sqrt (1 + k1*k1);
				
				if(k1 > k2)
				{
			   		motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x - Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
			   		motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y + Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2);
			   		//Debug.Log ("调试");
				}
				else 
		    	{
		    		motion_data_circle.DisplayTarget.x = motion_data2.DisplayStart.x + Radius2*Left_Right_Array*k2/Mathf.Sqrt (1 + k2*k2);
		    		motion_data_circle.DisplayTarget.y = motion_data2.DisplayStart.y - Radius2*Left_Right_Array/Mathf.Sqrt (1 + k2*k2);
		    		//Debug.Log ("调试");
		    	}
			}
		}
	}
}
