using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TrapsDoor))]
public class TrapsDoorEditor : Editor
{
	
	public override void OnInspectorGUI()
	{
		TrapsDoor myTarget = (TrapsDoor)target;
		
		myTarget.ResetTrapTimer 				= EditorGUILayout.Toggle("ResetTrapTimer", myTarget.ResetTrapTimer);
		myTarget.ResetTrapTime 					= EditorGUILayout.FloatField("ResetTrapTime", myTarget.ResetTrapTime);
		myTarget.RiseTime 						= EditorGUILayout.FloatField("RiseTime", myTarget.RiseTime);
		myTarget.OpenNormallyWithoutTrapping 	= EditorGUILayout.Toggle("OpenNormallyWithoutTrapping", myTarget.OpenNormallyWithoutTrapping);
		myTarget.WarningTime 					= EditorGUILayout.FloatField("WarningTime", myTarget.WarningTime);
		myTarget.FallTime 						= EditorGUILayout.FloatField("FallTime", myTarget.FallTime);
		myTarget.DamagePercent 					= EditorGUILayout.FloatField("DamagePercent", myTarget.DamagePercent);
		
	}
}

