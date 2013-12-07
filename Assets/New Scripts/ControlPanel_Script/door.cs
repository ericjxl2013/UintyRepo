using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	bool enter;
	bool move;
	float speed;

	void Start () {
		speed=0.08F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(enter==true)
			{
				move=true;
			}
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			move=false;
		}

		if(move)
		{
			float h =  Input.GetAxis("Mouse X"); 
			transform.Translate(new Vector3(0,0,1f)*h*speed,Space.Self);
		}
		
//		if(this.name == "door_left")
//		{
//			if(transform.position.z >= 0.01470597f)
//				transform.position = new Vector3(transform.position.x , transform.position.y, 0.01470597f);
//			
//			if(transform.position.z <= -0.5059499f)
//				transform.position = new Vector3(transform.position.x , transform.position.y, -0.5059499f);
//		}
//		
//		if(this.name == "door_right")
//		{
//			if(transform.position.z >= -1.091452f)
//				transform.position = new Vector3(transform.position.x , transform.position.y, -1.091452f);
//			
//			if(transform.position.z <= -1.57f)
//				transform.position = new Vector3(transform.position.x , transform.position.y, -1.57f);
//		}
		
		
		if(this.name == "main protecting crust_11")
		{
			if(transform.localPosition.z <= -0.3147356f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -0.3147356f);
			
			if(transform.localPosition.z >= 0.1851635f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, 0.1851635f);
		}
		
		
		if(this.name == "main protecting crust_12")
		{
			if(transform.localPosition.z <= -1.422714f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -1.422714f);
			
			if(transform.localPosition.z >= -0.9047691f)
				transform.localPosition = new Vector3(transform.localPosition.x , transform.localPosition.y, -0.9047691f);
		}
	}
	
	void OnGUI()
	{
		//GUI.Label(new Rect(100,100,100,100),hideFlags.ToString());
	}
	
	void OnMouseEnter() 
	{
        	enter=true;
    	}
	
	void OnMouseExit() 
	{
        	enter=false;
    	}
}
