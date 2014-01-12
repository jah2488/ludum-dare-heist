using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	
	protected static Vector3 _point;
	protected static bool _isSet;
	
	public static Vector3 Point {
		get { return _point; }
		set {
			_point = value;
			_isSet = true;
			Debug.Log("Respawn set to " + value);
		}
	}
	public static bool IsSet { get { return _isSet; } }
	
	// Use this for initialization
	void Start () {
		_isSet = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

