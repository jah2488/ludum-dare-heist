using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DoorControl))]
public class DoorControlEditor : Editor
{

	public override void OnInspectorGUI()
	{
		DoorControl myTarget = (DoorControl)target;
		
		myTarget.DistanceToActivate = EditorGUILayout.FloatField("Distance", myTarget.DistanceToActivate);

	}

}

