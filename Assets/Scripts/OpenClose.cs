using UnityEngine;
using System.Collections;

public class OpenClose : MonoBehaviour {

	public bool OpeningOrClosing;
	public bool Opened;
	public float Distance;
	public float ClosedPositionY;

	DoorControl controller;

	void Start () {
		ClosedPositionY = transform.localPosition.y;
		controller = GetComponent<DoorControl> ();
		if (controller != null) {
			controller.OnActivate += HandleOnActivate;
		}
	}

	void HandleOnActivate (Vector3 location)
	{
		TriggerOpenClose ();//nuthin fancy here. move along
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Mathf.Abs(transform.localPosition.y - ClosedPositionY);
		if(OpeningOrClosing) {
			if(Opened) {
					if(transform.localPosition.y >= ClosedPositionY) { Opened = false; OpeningOrClosing = false;}
					transform.Translate(Vector3.up);
			} else {
					if(Distance > 2 * transform.localScale.y) { Opened = true; OpeningOrClosing = false;}
					transform.Translate(Vector3.down);
			}
		} else {
			if(!Opened) {
				transform.localPosition = new Vector3(transform.localPosition.x, ClosedPositionY, transform.localPosition.z);
//								transform.localPosition.Set(transform.localPosition.x, ClosedPositionY, transform.localPosition.z);
			}
		}
	}

	public void TriggerOpenClose() {
		OpeningOrClosing = true;
	}
}
