using UnityEngine;
using System.Collections;

public class BlankInstall : MonoBehaviour {
	
	bool mouse_enter = false;
	ModelInitialize ModelInitialize_Script;
	// Use this for initialization
	void Start () {
		ModelInitialize_Script = GameObject.Find("MainScript").GetComponent<ModelInitialize>();
	}
	
	// Update is called once per frame
	void Update () {
		if(mouse_enter)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(ModelInitialize_Script.blankOn)
				{
					ModelInitialize_Script.BlankOff();
				}
				else
				{
					ModelInitialize_Script.BlankOn();
				}
			}
		}
	}
	
	void OnMouseEnter()
	{
		mouse_enter = true;
	}
	
	void OnMouseExit()
	{
		mouse_enter = false;
	}
}
