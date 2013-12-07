using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		gameObject.AddComponent("Mesh Collider");
//		gameObject.AddComponent("Rigidbody");
//		gameObject.rigidbody.useGravity = false;
//		gameObject.rigidbody.isKinematic = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collisionInfo)
	{
		Debug.Log("碰撞到的物体的名字是(collision)：" + collisionInfo.gameObject.name);
	}
	
	void OnTriggerEnter(Collider collisionInfo)
	{
		Debug.Log("碰撞到的物体的名字是(collider)：" + collisionInfo.gameObject.name);
	}
}
