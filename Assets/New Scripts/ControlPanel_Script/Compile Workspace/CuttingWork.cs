using UnityEngine;
using System.Collections;

public class CuttingWork : MonoBehaviour {
	
	Transform MainAxis_Ref;
	Transform Tool_Ref;
	// Use this for initialization
	void Start () {
		try
		{
			MainAxis_Ref = GameObject.Find("GameObject").transform;
		}
		catch
		{
			Debug.LogError("请添加空物体GameObject！");
			return;
		}
		MainAxis_Ref.name = "MainAxis_Ref";
		try
		{
			Tool_Ref = GameObject.Find("GameObject").transform;
		}
		catch
		{
			Debug.LogError("请添加空物体GameObject！");
			return;
		}
		Tool_Ref.name = "Tool_Ref";
		MainAxis_Ref.parent = GameObject.Find("main axle_4").transform;
		MainAxis_Ref.localPosition = new Vector3(0, -0.731137f, 0.0003082752f);
		MainAxis_Ref.localEulerAngles = new Vector3(90, 270, 0);
		Tool_Ref.parent = GameObject.Find("main axle_4").transform;
		Tool_Ref.localPosition = new Vector3(0, -0.731137f, 0.0003082752f);
		Tool_Ref.localEulerAngles = new Vector3(90, 270, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
