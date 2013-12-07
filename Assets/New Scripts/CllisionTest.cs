using UnityEngine;
using System.Collections;

public class CllisionTest : MonoBehaviour {
	MoveControl MoveControl_Script;
	// Use this for initialization
	void Start () {
//		gameObject.AddComponent("MeshCollider");
//		gameObject.AddComponent("Rigidbody");
//		gameObject.rigidbody.useGravity = false;
//		gameObject.rigidbody.isKinematic = false;
		MoveControl_Script = GameObject.Find("move_control").GetComponent<MoveControl>();
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate(new Vector3(0,0,1)*Time.deltaTime, Space.Self);
	}
	
	void OnCollisionEnter(Collision collisionInfo)
	{
//		Debug.Log("碰撞到的物体的名字是(collision)：" + collisionInfo.gameObject.name);
//		MoveControl_Script.collision_flag = true;
//		Debug.Log(MoveControl_Script.x_n + "," +MoveControl_Script.x_p+","+MoveControl_Script.y_n+","+MoveControl_Script.y_p+","+MoveControl_Script.z_n+","+MoveControl_Script.z_p);
		if(MoveControl_Script.x_n)
			MoveControl_Script.collision_xn = true;
		if(MoveControl_Script.y_n)
			MoveControl_Script.collision_yn = true;
		if(MoveControl_Script.z_n)
			MoveControl_Script.collision_zn = true;
		if(MoveControl_Script.x_p)
			MoveControl_Script.collision_xp = true;
		if(MoveControl_Script.y_p)
			MoveControl_Script.collision_yp = true;
		if(MoveControl_Script.z_p)
			MoveControl_Script.collision_zp = true;
		MoveControl_Script.x_n = false;
		MoveControl_Script.x_p = false;
		MoveControl_Script.y_n = false;
		MoveControl_Script.y_p = false;
		MoveControl_Script.z_n = false;
		MoveControl_Script.z_p = false;
	}
	
//	void OnCollisionStay(Collision collisionInfo)
//	{
//		MoveControl_Script.collision_flag = false;
//		MoveControl_Script.x_n = false;
//		MoveControl_Script.x_p = false;
//		MoveControl_Script.y_n = false;
//		MoveControl_Script.y_p = false;
//		MoveControl_Script.z_n = false;
//		MoveControl_Script.z_p = false;
//	}
	
	void OnCollisionExit(Collision collisionInfo)
	{
		MoveControl_Script.collision_xn = false;
		MoveControl_Script.collision_yn = false;
		MoveControl_Script.collision_zn = false;
		MoveControl_Script.collision_xp = false;
		MoveControl_Script.collision_yp = false;
		MoveControl_Script.collision_zp = false;
//		Debug.Log(MoveControl_Script.x_n + "," +MoveControl_Script.x_p+","+MoveControl_Script.y_n+","+MoveControl_Script.y_p+","+MoveControl_Script.z_n+","+MoveControl_Script.z_p);
	}
	
//	void OnTriggerEnter(Collider collisionInfo)
//	{
//		Debug.Log("碰撞到的物体的名字是(collider)：" + collisionInfo.gameObject.name);
//	}
}
