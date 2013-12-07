using UnityEngine;
using System.Collections;

public class WarnningWindow : MonoBehaviour {
	private Rect win_rect = new Rect(-500f, Screen.height - 290f, 360f, 290f);
	private float left = -500f; 
	private bool come_forth = false;
	private bool motion_start = false;
	private float time_value = 0;
	
	public Vector2 scrollPosition = Vector2.zero;
	string object_description;
	public GUIText s;
	int height;
	int i = 0;
	// Use this for initialization
	void Start () {
		object_description="天之道\n";
	}
	
	void OnGUI () 
	{
		win_rect.x = left;
		win_rect = GUI.Window(11, win_rect, Warnning, "Warnning Window");
		
		if(GUI.Button(new Rect(100f, Screen.height - 290f, 100f, 30f), "触发"))
		{
			motion_start = true;
		}
		
		if(GUI.Button(new Rect(280, 50, 100, 30), "Increase String"))
		{
			i++;
			object_description += "第" + i + "次增加;\n";
		}
		
		if(GUI.Button(new Rect(390, 50, 100, 30), "Decrease String"))
		{
			object_description = object_description.Remove(object_description.Length - 10, 10);
		}
	}
	
	void Warnning(int WindowID)
	{
		scrollPosition = GUI.BeginScrollView (new Rect (20, 20, 320, 200),scrollPosition , new Rect (0, 0, 300, 14*height+14));
		string	s1="";
		int len=object_description.Length;
		
		
	//	object_tips_rect.height=60;
		char[] myChars = object_description.ToCharArray();
		height=1;
		
		for(int i=0;i<len;i++)
		{
			s1+=myChars[i];
			s.text=s1;
			if(s.GetScreenRect().width>260)
			{
				height+=1;
				s1=""+myChars[i];
				s.text=s1;
			}
			if(myChars[i]=='\n')
			{
				height+=1;
				s1=""+myChars[i];
				s.text=s1;
			}
			
		}
	//	object_tips_rect.height=height*22+44;
		
		GUI.Label(new Rect(0, 0, 260,16*height+16), object_description);
		
		GUI.EndScrollView();
	}
	
	void FixedUpdate ()
	{
		if(motion_start)
		{
			//出来
			if(come_forth)
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(0, -500f, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
			}
			//进去
			else
			{
				time_value += Time.fixedDeltaTime;
				left = Mathf.Lerp(-500f, 0, 2*time_value);
				if(2*time_value > 1f)
				{
					time_value = 0; 
					come_forth = !come_forth;
					motion_start = false;
				}
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
