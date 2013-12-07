using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//直线
public class LineInfo
{
	public List<int> index;
	public List<int> sub_index;
	public List<Vector3> start_point;
	private List<Vector3> backup_start_point;
	public List<Vector3> end_point;
	public List<Color> line_color;
	
	public LineInfo()
	{
		index = new List<int>(); 
		sub_index = new List<int>();
		start_point = new List<Vector3>();
		backup_start_point = new List<Vector3>();
		end_point = new List<Vector3>();
		line_color = new List<Color>();
	}
	
	public void Add(int IndexNum, int subIndexNum, Vector3 StartPoint, Vector3 EndPoint, Color LineColor)
	{
		index.Add(IndexNum);
		sub_index.Add(subIndexNum);
		Vector3 temp_vec = StartPoint;
		temp_vec.z = -StartPoint.z;
		start_point.Add(temp_vec);
		backup_start_point.Add(temp_vec);
		temp_vec = EndPoint;
		temp_vec.z = -EndPoint.z;
		end_point.Add(temp_vec);
		line_color.Add(LineColor);
	}
	
	public void UpdateStartPoint(int indexNum, float current_rate)
	{
		int listIndex = index.IndexOf(indexNum);
		if(listIndex == -1)
			return;
		else
		{
			start_point[listIndex] = backup_start_point[listIndex] + (end_point[listIndex] - backup_start_point[listIndex]) * current_rate;
		}
	}
	
	public int Count()
	{
		return start_point.Count;
	}
	
	public void Clear()
	{
		index.Clear();
		start_point.Clear();
		backup_start_point.Clear();
		end_point.Clear();
		line_color.Clear();
	}
	
	public void RemoveAt(int indexNum)
	{
		index.RemoveAt(indexNum);
		sub_index.RemoveAt(indexNum);
		start_point.RemoveAt(indexNum);
		backup_start_point.RemoveAt(indexNum);
		end_point.RemoveAt(indexNum);
		line_color.RemoveAt(indexNum);
	}
	
	/// <summary>
	/// 删除指定的线条
	/// </summary>
	/// <param name='indexNum'>
	/// 该线条对应数据的序号
	/// </param>
	/// <param name='is_circle'>
	/// 判断该线条是否属于圆弧
	/// </param>
	/// <param name='segmentIndex'>
	/// 如属于圆弧，则圆弧中序号为何
	/// </param>
	public void RemoveCertainIndex(int indexNum, bool is_circle, int current_slice)
	{
		int listIndex = index.IndexOf(indexNum);
		if(listIndex == -1)
			return;
		else
		{
			if(is_circle)
			{
				if(sub_index.Count > listIndex)
				{
					index.RemoveAt(listIndex);
					sub_index.RemoveAt(listIndex);
					start_point.RemoveAt(listIndex);
					backup_start_point.RemoveAt(listIndex);
					end_point.RemoveAt(listIndex);
					line_color.RemoveAt(listIndex);
				}
//				if(sub_index[listIndex] == current_slice)
//				{
//					index.RemoveAt(listIndex);
//					sub_index.RemoveAt(listIndex);
//					start_point.RemoveAt(listIndex);
//					backup_start_point.RemoveAt(listIndex);
//					end_point.RemoveAt(listIndex);
//					line_color.RemoveAt(listIndex);
//					Debug.Log("OK");
//				}
//				else
//				{
//					Debug.Log("Oh, NO!");
//					return;
//				}
			}
			else
			{
				index.RemoveAt(listIndex);
				sub_index.RemoveAt(listIndex);
				start_point.RemoveAt(listIndex);
				backup_start_point.RemoveAt(listIndex);
				end_point.RemoveAt(listIndex);
				line_color.RemoveAt(listIndex);
			}
		}
	}
	
	//删除线段中所有相同index的线段
	public void RemoveAllIndex(int indexNum)
	{
		int listIndex = index.IndexOf(indexNum);
		if(listIndex == -1)
			return;
		else
		{
			for(int i = listIndex; i < index.Count; i++)
			{
				if(index[i] == indexNum)
				{
					index.RemoveAt(i);
					sub_index.RemoveAt(i);
					start_point.RemoveAt(i);
					backup_start_point.RemoveAt(i);
					end_point.RemoveAt(i);
					line_color.RemoveAt(i);
					i--;
				}
				else
					break;
			}
		}
		
	}
	
	public string CurrentString(int k)
	{
		return index[k]+": "+start_point[k].x+","+start_point[k].y+","+start_point[k].z+"; "+end_point[k].x+","+end_point[k].y+","+end_point[k].z;
	}
}

//圆弧
public class ArcInfo
{
	public List<Vector3> start_point;
	public List<Vector3> end_point;
	public List<Vector3> centre_point;
	public List<float> angle;
	public List<float> radius;
	public List<Color> line_color;
	
	public ArcInfo()
	{
		start_point = new List<Vector3>();
		end_point = new List<Vector3>();
		centre_point = new List<Vector3>();
		angle = new List<float>();
		radius = new List<float>();
		line_color = new List<Color>();
	}
	
	public int Count()
	{
		return start_point.Count;
	}
	
	public void Clear()
	{
		start_point.Clear();
		end_point.Clear();
		centre_point.Clear();
		angle.Clear();
		radius.Clear();
		line_color.Clear();
	}
	
	public void RemoveAt(int index)
	{
		start_point.RemoveAt(index);
		end_point.RemoveAt(index);
		centre_point.RemoveAt(index);
		angle.RemoveAt(index);
		radius.RemoveAt(index);
		line_color.RemoveAt(index);
	}
	
}