using UnityEngine;
using System.Collections;

public class AlarmManager : MonoBehaviour {
	public delegate void Snap(Vector3 position);
	public static event	Snap OnOhSnap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Alert(){
		if (OnOhSnap != null){
			OnOhSnap(new Vector3(0,0,0));
		}
	}
}
