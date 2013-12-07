using UnityEngine;
using System.Collections;

public class PathLineDraw : MonoBehaviour {
	
	ControlPanel Main;
	public LineInfo lineDrawer;
	public LineInfo lineOriginalDrawer;
	public ArcInfo arcDrawer;
	Material lineMaterial;
	
	public Transform lineRef;
	public bool pathLineDisplay = true;
	public bool originalPathDisplay = true;
	public string pathLineState = "隐藏切削轨迹线";
	public string pathOriginalLineState = "隐藏原始轨迹线";
	
	public bool display_menu = false;
	Rect menu_rect = new Rect(0,0,0,0);
	
	// Use this for initialization
	void Start () {
		menu_rect.x = 100f;
		menu_rect.y = 300f;
		menu_rect.width = 300f;
		menu_rect.height = 180f;
		
		lineDrawer = new LineInfo();
		arcDrawer = new ArcInfo();
		lineOriginalDrawer = new LineInfo();
		try
		{
			lineRef = GameObject.Find("GameObject").transform;
		}
		catch
		{
			Debug.LogError("请手动添加一个空物体GameObject.");
			return;
		}
		lineRef.name  = "Line Reference";
		lineRef.parent = GameObject.Find("main axle_4").transform;
		lineRef.localPosition = new Vector3(0, -0.731137f, 0.0003082752f);
		lineRef.localEulerAngles = new Vector3(90, 270, 0);
		lineRef.parent = GameObject.Find("workbench_1").transform;
		try
		{
			lineMaterial = (Material)Resources.Load("Materials/LineMaterial");
		}
		catch
		{
			Debug.LogError(Application.dataPath +  "/Materials/中不存在LineMaterial, 请添加相应的Material.");
			return;
		}
//		lineDrawer.Add(0, new Vector3(-0.8f, -0.5f, -0.51f), new Vector3(0, -0.5f, -0.51f), Color.red);
//		lineDrawer.Add(0, new Vector3(-0.8f, -0.5f, -0.51f), new Vector3(-0.8f, 0, -0.51f), Color.green);
//		lineDrawer.Add(0, new Vector3(-0.8f, -0.5f, -0.51f), new Vector3(-0.8f, -0.5f, 0), Color.blue);
		
		Main = GameObject.Find("MainScript").GetComponent<ControlPanel>();
	}
	
	/// <summary>
	/// 画线段函数
	/// </summary>
	/// <param name='"tart_point">
	/// 线段起始点
	/// </param>
	/// <param name="end_point">
	/// 线段终止点
	/// </param>
	/// <param name="line_color">
	/// 线段颜色
	/// </param>
	void DrawStraightLine(Vector3 start_point, Vector3 end_point, Color line_color)
	{
		lineMaterial.SetPass(0);
		GL.Color(line_color);
        	GL.PushMatrix();
		GL.MultMatrix(lineRef.localToWorldMatrix);
        	GL.Begin(GL.LINES);
		GL.Vertex3(start_point.x, start_point.y, start_point.z + Main.toolLength);
		GL.Vertex3(end_point.x, end_point.y, end_point.z + Main.toolLength);
//        	GL.Vertex(start_point);
//        	GL.Vertex(end_point);
        	GL.End();
        	GL.PopMatrix();
	}
	
	/// <summary>
	/// 画圆弧函数
	/// </summary>
	/// <param name="startPoint">
	/// 圆弧起点
	/// </param>
	/// <param name="endPoint">
	/// 圆弧终点
	/// </param>
	/// <param name="center">
	/// 圆心
	/// </param>
	/// <param name='"angle">
	/// 圆弧弧度数
	/// </param>
	/// <param name="radius">
	/// 圆弧半径
	/// </param>
	/// <param name="lineColor">
	/// 圆弧颜色
	/// </param>
	public void DrawArcLine(Vector3 startPoint, Vector3 endPoint, Vector3 center, float angle, float radius, Color lineColor)
	{
		Vector3 start_vector = startPoint - center;
		Vector3 end_vector = endPoint - center;
		Vector3 axis_vector = Vector3.Cross(start_vector, end_vector).normalized;
		if(axis_vector == Vector3.zero)
			axis_vector = new Vector3(0,0,1);
		//r旋转theta弧度后的向量
		Vector3 r_rotate = new Vector3(0f, 0f, 0f);
		//圆弧精度计算
		float slices =(int)(20 * (angle * radius) / (0.5f * 2 * Mathf.PI));
//		Debug.Log(slices);
		//每次旋转的弧度数
		float theta = angle / slices;
		float calTheta = 0;
		lineMaterial.SetPass(0);
		GL.PushMatrix();
		GL.MultMatrix(lineRef.localToWorldMatrix);
		GL.Begin(GL.LINES);
		GL.Color(lineColor);
		//运用了旋转矩阵，等价于Rodrigues旋转公式
		Vector3 firstPoint = new Vector3(0, 0, 0);  //折线起始点
		Vector3 secondPoint = new Vector3(0f, 0f, 0f);  //折线终点
		for(int i = 0; i <= slices; ++i)
		{
			if(i != 0)
				calTheta += theta;
			r_rotate = Mathf.Cos(calTheta) * start_vector + Vector3.Cross(axis_vector, start_vector) * Mathf.Sin(calTheta) + Vector3.Dot(axis_vector, start_vector) * axis_vector * (1 - Mathf.Cos(calTheta));
			secondPoint = center + r_rotate;
			if(i != 0)
			{
				GL.Vertex(firstPoint);
				GL.Vertex(secondPoint);
			}
			firstPoint = secondPoint;
		}
		GL.End();
		GL.PopMatrix();
	}
	
	void OnGUI ()
	{
		if(display_menu)
		{
			menu_rect = GUI.Window(53, menu_rect, LineControl, "Line Control");
		}
		
//		if(GUI.Button(new Rect(10, 170, 120, 30), pathLineState))
//		{
//			if(pathLineDisplay)
//			{
//				pathLineState = "显示轨迹线";
//				pathLineDisplay = false;
//			}
//			else
//			{
//				pathLineState = "隐藏轨迹线";
//				pathLineDisplay = true;
//			}
//		}
	}
	
	void LineControl(int WindowID)
	{
		if(GUI.Button(new Rect(90, 30, 120, 30), pathLineState))
		{
			if(pathLineDisplay)
			{
				pathLineState = "显示切削轨迹线";
				pathLineDisplay = false;
			}
			else
			{
				pathLineState = "隐藏切削轨迹线";
				pathLineDisplay = true;
			}
		}
		
		if(GUI.Button(new Rect(90, 70, 120, 30), pathOriginalLineState))
		{
			if(originalPathDisplay)
			{
				pathOriginalLineState = "显示原始轨迹线";
				originalPathDisplay = false;
			}
			else
			{
				pathOriginalLineState = "隐藏原始轨迹线";
				originalPathDisplay = true;
			}
		}
		
		if(GUI.Button(new Rect(110, 140, 80, 30), "关闭"))
		{
			display_menu = false;
		}
		
		GUI.DragWindow();
	}
	
	//快速进行的渲染
	void OnPostRender() 
	{
       	if (!lineMaterial)
		{
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
		
		if(pathLineDisplay)
		{
			for(int i = 0; i < lineDrawer.Count(); i++)
			{
				DrawStraightLine(lineDrawer.start_point[i], lineDrawer.end_point[i], lineDrawer.line_color[i]);
			}
		}
		
		if(originalPathDisplay && !Main.AutoRunning_flag && !Main.MDI_RunningFlag)
		{
			for(int i = 0; i < lineOriginalDrawer.Count(); i++)
			{
				DrawStraightLine(lineOriginalDrawer.start_point[i], lineOriginalDrawer.end_point[i], lineOriginalDrawer.line_color[i]);
			}
		}
//		DrawArcLine(new Vector3(-2f, 0, 0), new Vector3(2f, 0, 0), new Vector3(0, 0, 0), Mathf.PI, 2f, Color.yellow);
    }
}
