using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {
	

	public bool isEnable = true;
	public Transform initPosObject;
	
	//public Transform targetObject;
	
	public float xSpeed = 350.0f;
	public float ySpeed = 250.0f;
	
	public float yMinLimit = -20.0f;
	public float yMaxLimit = 80.0f;
	
	public float initDis = 4.0f;
	public float minDis = 2.0f;
	public float maxDis = 10.0f;
	
	public float wheelSpeed = 5.0f;
	
	public float yMoveSpeed = 1.0f;
	public float moveSpeed = 1.0f;
	
	public float x = 130.0f;
	
	public float y = 30.0f;
	
	private float distance = 0.0f;
	
	private Camera OrbitCamera;
	
	public float btRotSpeed = 0.1f;
	public float btMoveSpeed = 0.3f;
	public float btDisSpeed = 0.05f;
	
	
	public bool flag_left = false;
	public bool flag_right = false;
	public bool flag_up = false;
	public bool flag_down = false;
	
	public bool flag_forward = false;
	public bool flag_backword = false;
	public bool flag_lMove = false;
	public bool flag_rMove = false;
	
	public bool flag_near = false;
	public bool flag_far = false;
	
	//public Transform centerObj;
	//private Vector3 centerPos;
	
	void Awake(){
		OrbitCamera = this.transform.GetComponentInChildren<Camera>();
	}
	// Use this for initialization
	void Start () {
		InitOrbitCamera(initPosObject);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
		//按钮控制平移-------------------------------
		if(flag_lMove&&isEnable)
			transform.Translate(-1 * btMoveSpeed * distance/5, 0, 0);
		if(flag_rMove&&isEnable)
			transform.Translate(btMoveSpeed * distance/5, 0, 0);
		if(flag_forward&&isEnable)
			transform.Translate(0, 0, btMoveSpeed * distance/5);
		if(flag_backword&&isEnable)
			transform.Translate(0, 0, -1 * btMoveSpeed * distance/5);
		
		//按钮控制旋转-------------------------------
		if(flag_left&&isEnable)
			x += btRotSpeed;
		if(flag_right&&isEnable)
			x -= btRotSpeed;
		if(flag_up&&isEnable)
			y+=btRotSpeed;
		if(flag_down&&isEnable)
			y-=btRotSpeed;
		
		//按钮控制远近------------------------------
		if(flag_near&&isEnable)
			distance-=btDisSpeed;
		else if(flag_far&&isEnable)
			distance+=btDisSpeed;
		
		
		
		else if(GUIUtility.hotControl==0){
			
			distance = Vector3.Distance(Vector3.zero,OrbitCamera.transform.localPosition);
			
			if(moveflag&isEnable){
				if(Input.GetMouseButton(1)){
					
					x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
					y += Input.GetAxis("Mouse Y") * ySpeed * -0.02f;
					
					
				}
				
				
				distance-= Input.GetAxis("Mouse ScrollWheel")*wheelSpeed;
			
			}
			
		}
		
		y = ClampAngle(y,yMinLimit,yMaxLimit);
		
		distance = Mathf.Clamp(distance,minDis,maxDis);
		
		Quaternion localRotation = Quaternion.Euler(y, 0, 0);
		Vector3 localPosition = localRotation * new Vector3(0.0f, 0.0f, -1*distance) + Vector3.zero;
			
		OrbitCamera.transform.localRotation = localRotation;
		OrbitCamera.transform.localPosition = localPosition;
		
		Quaternion rotationP = Quaternion.Euler(0,x, 0);
		transform.rotation = rotationP;
		
		if(moveflag&isEnable){
			if(Mathf.Abs(Input.GetAxis("Horizontal"))>0||Mathf.Abs(Input.GetAxis("Vertical"))>0){
				transform.Translate(new Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0, Input.GetAxis("Vertical")*moveSpeed));
			}
			if(Input.GetMouseButton(2)){
					
				transform.Translate(0,Input.GetAxis("Mouse Y") * yMoveSpeed,0);
			}
		}
		//Debug.Log(Vector3.Distance(transform.parent.position,targetPos));
	
	}
	

	
	public void InitOrbitCamera(Transform cObj){
		
		
		
		
		
		transform.rotation = Quaternion.Euler(0,x, 0);
		OrbitCamera.transform.localRotation = Quaternion.Euler(y,0,0);
		
		OrbitCamera.transform.localPosition = Quaternion.Euler(y,0,0) * new Vector3(0.0f,0.0f,-1*initDis);
		
		if(cObj!=null){
			transform.position = cObj.position;
		}
		else{
			transform.position = Vector3.zero;
		}
	}
	
	float ClampAngle(float angle,float min,float max){
		if (angle < -360.0f)
			angle += 360.0f;
		if (angle > 360.0f)
			angle -= 360.0f;
		return Mathf.Clamp (angle, min, max);
	}
	private Vector3 targetPos;
	private bool moveflag = true;
	
	
	//设置物体目标点----------------------------------------
	public IEnumerator SetCameraTarget(Transform obj){
		/*if(obj)
			transform.parent.position = obj.position;
		else
			transform.parent.position = Vector3.zero;
		*/
		
		bool isMove = true;
		moveflag = false;
		while(isMove){
			transform.position = Vector3.Lerp(transform.position,obj.position,0.05f);
			x  = Mathf.Lerp(x,130.0f,0.05f);
			y = Mathf.Lerp(y,30.0f,0.05f);
			distance = Mathf.Lerp(distance,1.0f,0.05f);
			
			OrbitCamera.transform.localPosition = OrbitCamera.transform.localRotation * new Vector3(0.0f, 0.0f, -1*distance) + Vector3.zero;
			
			
			yield return new WaitForSeconds(0.01f);
			
			if(Mathf.Abs(x-130.0f)<0.01f&&Mathf.Abs(y-30.0f)<0.01f){
				if(Vector3.Distance(transform.position,obj.position)<0.01f){
					x = 130.0f;
					y = 30.0f;
					isMove = false;
					moveflag = true;
					transform.position = obj.position;
					break;
				}
			}
		}
	}
}
