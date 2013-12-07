using UnityEngine;
using System.Collections;

public class LightNumber : MonoBehaviour {
	ControlPanel Main;
	
	static bool[] lights=new bool[]{false,false,false,false,false,false,false};
	enum Lights{
		MACHINE,
		MAG,
		AIRorLUB,
		X,
		Y,
		Z,
		FourTH
	};
	
	public Texture2D green;
	public Texture2D red;
	
	public Texture2D[] tex=new Texture2D[10];
	
	public float width = 10;
	public float height = 10;
	public float l_x=320f;
	public float l_y=540f;
	public float r_x=540f;
	public float r_y=540f;
	public float left_x=72f;
	public float right_x=71;
	
	public float number_x=866.4f;
	public float number_y=532;
	public float number_width=16;
	public float number_height=22;
	public float number_left_x=21;
	
	int a = 0;
	int b = 0;
	
	
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		
		green=(Texture2D)Resources.Load("DigitalControlPanel/GreenLight");
		red=(Texture2D)Resources.Load("DigitalControlPanel/RedLight");
		
		tex[0]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/0");
		tex[1]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/1");
		tex[2]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/2");
		tex[3]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/3");
		tex[4]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/4");
		tex[5]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/5");
		tex[6]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/6");
		tex[7]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/7");
		tex[8]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/8");
		tex[9]=(Texture2D)Resources.Load("DigitalControlPanel/ShowNumber/9");
		
	}
	
	public void LightControl(){
		if(lights[(int)Lights.MACHINE]){
			GUI.DrawTexture(new Rect(l_x/1000f*Main.width,l_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),red);
		}else{
			
		}
		if(lights[(int)Lights.MAG]){
			GUI.DrawTexture(new Rect((l_x+left_x)/1000f*Main.width,l_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),red);
		}else{
			
		}
		if(lights[(int)Lights.AIRorLUB]){
			GUI.DrawTexture(new Rect((l_x+2*left_x)/1000f*Main.width,l_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),red);
		}else{
			
		}
		
		if(lights[(int)Lights.X]){
			GUI.DrawTexture(new Rect(r_x/1000f*Main.width,r_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),green);
		}else{
			
		}
		if(lights[(int)Lights.Y]){
			GUI.DrawTexture(new Rect((r_x+right_x)/1000f*Main.width,r_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),green);
		}else{
			
		}
		if(lights[(int)Lights.Z]){
			GUI.DrawTexture(new Rect((r_x+2*right_x)/1000f*Main.width,r_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),green);
		}else{
			
		}
		if(lights[(int)Lights.FourTH]){
			GUI.DrawTexture(new Rect((r_x+3*right_x)/1000f*Main.width,r_y/1000f*Main.height,width/1000f*Main.width,height/1000f*Main.height),green);
		}else{
			
		}
	}
	
	public void setLight(int light,bool bo){
		lights[light]=bo;
	}
	
	public bool checkNumber(int number){
		if(number>=0&&number<=99){
			return true;
		}
		return false;
	}
	public void showNumber(){
		GUI.DrawTexture(new Rect(number_x/1000f*Main.width,number_y/1000f*Main.height,number_width/1000f*Main.width,number_height/1000f*Main.height),tex[a]);
		GUI.DrawTexture(new Rect((number_x+number_left_x)/1000f*Main.width,number_y/1000f*Main.height,number_width/1000f*Main.width,number_height/1000f*Main.height),tex[b]);
	}
	
	public void SetNumber(int num)
	{
		a = num / 10;
		b = num % 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
