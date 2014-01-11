using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

		public enum Dir { LEFT, RIGHT }

		public Dir RotationDirection;
		public  float RotationSpeed = 1.0f;
		private float rotationDelta;

	void Start () {
	}
	
	void Update () {
				rotationDelta = RotationSpeed * Time.deltaTime;

				if(transform.rotation.eulerAngles.y >= 90.0f  && transform.rotation.eulerAngles.y < 270.0f) { RotationDirection = Dir.LEFT; }
				if(transform.rotation.eulerAngles.y <= 275.0f && transform.rotation.eulerAngles.y >  92.0f) { RotationDirection = Dir.RIGHT; }

				if(RotationDirection == Dir.LEFT) {
						transform.Rotate(Vector3.down * RotationSpeed);
				} else {
						transform.Rotate(Vector3.up * RotationSpeed);
				}
	}
}
