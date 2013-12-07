using UnityEngine;
using UnityEditor;
using System; 


public class PositionAndRotationPrint : EditorWindow {
	string PositionString1st = "1st Position of Selection";
	
	Vector3 Position1st = new Vector3(0,0,0);
	
	string PositionString2nd = "2nd Position of Selection";
	
	Vector3 Position2nd = new Vector3(0,0,0);
	
	string PosDiff = "Position Diff From 2nd To 1st";
	
	Vector3 PosDiffValue = new Vector3(0,0,0);
	
	string RotationString1st = "1st Rotation of Selection";
	
	Vector3 Rotation1st = new Vector3(0,0,0);
	
	string RotationString2nd = "2nd Rotation of Selection";
	
	Vector3 Rotation2nd = new Vector3(0,0,0);
	
	string RotDiff = "Rotation Diff From 2nd To 1st";
	
	Vector3 RotDiffValue = new Vector3(0,0,0);
	
	Transform SelectedTransform;
	

	// Add menu named "My Window" to the Window menu
	[MenuItem ("Window/Position And Rotation Print")]
	
	//static bool ValidateSelection () {
		//return Selection.activeTransform != null;
	//}

	static void Init () {
		// Get existing open window or if none, make a new one:
		PositionAndRotationPrint window = (PositionAndRotationPrint)EditorWindow.GetWindow (typeof (PositionAndRotationPrint));
		
		window.Show();
	}
	
	
	Vector3 GetPosition () {
				
		SelectedTransform = Selection.activeTransform;
		
		return SelectedTransform.localPosition;

	}
	
	Vector3 GetRotation () {
				
		SelectedTransform = Selection.activeTransform;
		
		return SelectedTransform.localEulerAngles;

	}
	
	Vector3 GetPosDiff () {
		
		return Position2nd - Position1st;
	}
	
	Vector3 GetRotDiff () {
		
		return Rotation2nd - Rotation1st;
	}
	
	void OnGUI () {
		
		GUILayout.Label ("Position:", EditorStyles.boldLabel);
		
		PositionString1st = EditorGUILayout.TextField ("Position 1st:", PositionString1st);
		
		if(GUILayout.Button("Get 1st Pos"))
		{
			Position1st = GetPosition();
			
			if(Position1st.x > -0.000001F && Position1st.x < 0.000001F)
				Position1st.x = 0;
			
			if(Position1st.y > -0.000001F && Position1st.y < 0.000001F)
				Position1st.y = 0;
			
			if(Position1st.z > -0.000001F && Position1st.z < 0.000001F)
				Position1st.z = 0;
			
		    PositionString1st = (string)Convert.ToString(Position1st);
		    this.Repaint();
			Debug.Log(Position1st.x+","+Position1st.y+","+Position1st.z + "  1st Pos");
		}
		
		PositionString2nd = EditorGUILayout.TextField ("Position 2st:", PositionString2nd);
		
		if(GUILayout.Button("Get 2st Pos"))
		{
			Position2nd = GetPosition();
			
			if(Position2nd.x > -0.000001F && Position2nd.x < 0.000001F)
				Position2nd.x = 0;
			
			if(Position2nd.y > -0.000001F && Position2nd.y < 0.000001F)
				Position2nd.y = 0;
			
			if(Position2nd.z > -0.000001F && Position2nd.z < 0.000001F)
				Position2nd.z = 0;
			
			PositionString2nd = (string)Convert.ToString(Position2nd);
			this.Repaint();
			Debug.Log(Position2nd.x+","+Position2nd.y+","+Position2nd.z + "  2nd Pos");
		}
		
		PosDiff = EditorGUILayout.TextField ("Pos Diff:", PosDiff);
		
		if(GUILayout.Button("Get Pos Diff"))
		{
		    PosDiffValue = GetPosDiff();
			
			if(PosDiffValue.x > -0.000001F && PosDiffValue.x < 0.000001F)
				PosDiffValue.x = 0;
			
			if(PosDiffValue.y > -0.000001F && PosDiffValue.y < 0.000001F)
				PosDiffValue.y = 0;
			
			if(PosDiffValue.z > -0.000001F && PosDiffValue.z < 0.000001F)
				PosDiffValue.z = 0;
			
			PosDiff = (string)Convert.ToString(PosDiffValue);
			this.Repaint();
			Debug.Log(PosDiffValue.x+","+PosDiffValue.y+","+PosDiffValue.z + "  Pos Diff");
			
		}
		
		GUILayout.Label ("Rotation:", EditorStyles.boldLabel);
		
		RotationString1st = EditorGUILayout.TextField ("Position 1st:", RotationString1st);
		
		if(GUILayout.Button("Get 1st Rot"))
		{
			Rotation1st = GetRotation();
			
			if(Rotation1st.x > -0.000001F && Rotation1st.x < 0.000001F)
				Rotation1st.x = 0;
			
			if(Rotation1st.y > -0.000001F && Rotation1st.y < 0.000001F)
				Rotation1st.y = 0;
			
			if(Rotation1st.z > -0.000001F && Rotation1st.z < 0.000001F)
				Rotation1st.z = 0;
			
			RotationString1st = (string)Convert.ToString(Rotation1st);
		    this.Repaint();
     		Debug.Log(Rotation1st.x+","+Rotation1st.y+","+Rotation1st.z+ "  1st Rot");
		}
		
		RotationString2nd = EditorGUILayout.TextField ("Position 2st:", RotationString2nd);
		
		if(GUILayout.Button("Get 2st Rot"))
		{
			Rotation2nd = GetRotation();
			
			if(Rotation2nd.x > -0.000001F && Rotation2nd.x < 0.000001F)
				Rotation2nd.x = 0;
			
			if(Rotation2nd.y > -0.000001F && Rotation2nd.y < 0.000001F)
				Rotation2nd.y = 0;
			
			if(Rotation2nd.z > -0.000001F && Rotation2nd.z < 0.000001F)
				Rotation2nd.z = 0;
			
			RotationString2nd = (string)Convert.ToString(Rotation2nd);
			this.Repaint();
			Debug.Log(Rotation2nd.x+","+Rotation2nd.y+","+Rotation2nd.z + "  2nd Rot");
		}
		
		RotDiff = EditorGUILayout.TextField ("Rot Diff:", RotDiff);
		
		if(GUILayout.Button("Get Rot Diff"))
		{
			RotDiffValue = GetRotDiff();
			RotDiff = (string)Convert.ToString(RotDiffValue);
			this.Repaint();
			Debug.Log(RotDiffValue.x+","+RotDiffValue.y+","+RotDiffValue.z + "  Rot Diff");
		}
		
		GUILayout.Label ("Reset Position or Rotation:", EditorStyles.boldLabel);
		if(GUILayout.Button("Reset Position"))
		{
			SelectedTransform.localPosition = Vector3.zero;
		}
		
		if(GUILayout.Button("Reset Rotation"))
		{
			SelectedTransform.localEulerAngles = Vector3.zero;
		}
		
		GUILayout.Label ("Get Absolute Position or Rotation:", EditorStyles.boldLabel);
		if(GUILayout.Button("Get Abs Position"))
		{
			Debug.Log(Selection.activeTransform.position.x + "," + Selection.activeTransform.position.y + "," + Selection.activeTransform.position.z);
		}
		
		if(GUILayout.Button("Get Abs Rotation"))
		{
			Debug.Log(Selection.activeTransform.eulerAngles.x + "," + Selection.activeTransform.eulerAngles.y + "," + Selection.activeTransform.eulerAngles.z);
		}
		
	}
}