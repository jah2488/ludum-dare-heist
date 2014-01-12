using UnityEngine;
using System.Collections;
using UnityEditor;


public class TrapsDoorEditor : Editor
{
	
	public override void OnInspectorGUI()
	{
		TrapsDoor myTarget = (TrapsDoor)target;
		
		myTarget.ResetTrapTimer 				= EditorGUILayout.Toggle("Reset Trap Timer", myTarget.ResetTrapTimer);
		myTarget.ResetTrapTime 					= EditorGUILayout.FloatField("Reset Trap Time", myTarget.ResetTrapTime);
		myTarget.RiseTime 						= EditorGUILayout.FloatField("Rise Time", myTarget.RiseTime);
		myTarget.OpenNormallyWithoutTrapping 	= EditorGUILayout.Toggle("Open Normally Without Trapping", myTarget.OpenNormallyWithoutTrapping);
		myTarget.WarningTime 					= EditorGUILayout.FloatField("Warning Time", myTarget.WarningTime);
		myTarget.FallTime 						= EditorGUILayout.FloatField("Fall Time", myTarget.FallTime);
		//myTarget.DamageAmount 					= EditorGUILayout.FloatField("Damage Amount", myTarget.DamageAmount);
		
	}
}

