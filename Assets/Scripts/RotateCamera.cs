using UnityEngine;


public class RotateWithCamera : MonoBehaviour {

		public Dir RotationDirection;
		public float RotationSpeed = 2.0f;

		public enum Dir { LEFT, RIGHT }

		private float rotationDelta;

		void Start () {
				RotationDirection = Dir.LEFT;
		}

		void Update () {
				if(transform.rotation.y >=  90.0) { RotationDirection = Dir.LEFT;  }
				if(transform.rotation.y <= -90.0) { RotationDirection = Dir.RIGHT; }

				if(RotationDirection == Dir.LEFT) {
						rotationDelta = transform.rotation.y - RotationSpeed * Time.deltaTime;
						transform.Rotate(0, rotationDelta, 0);
				}
				if(RotationDirection == Dir.RIGHT) {
						rotationDelta = transform.rotation.y + RotationSpeed * Time.deltaTime;
						transform.Rotate(0, rotationDelta, 0);
				}
		}
}
