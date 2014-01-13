using UnityEngine;
using System.Collections;

[System.Serializable]
public class ButtonDepresser : MonoBehaviour {

	public bool depressed;
	public float TimeBeforeAntiDepressantsAdministered;
	public Color DepressingColor;
	public Color NotAsDepressedColor;

	ButtonControl activator;

	// Use this for initialization
	void Start () {
		activator = GetComponent<ButtonControl> ();
		activator.OnActivate += DepressButton;
	}
	
	// Update is called once per frame
	void Update () {
		if (depressed)
			renderer.material.SetColor("_Color", DepressingColor);
		else
			renderer.material.SetColor("_Color", NotAsDepressedColor);
	}
	
	void DepressButton(Vector3 location){
		Debug.Log ("profound sadness :cccccccc");//cccccc
		depressed = true;//it's the common cold of buttons
		StartCoroutine (PopPills ());
	}

	IEnumerator PopPills(){
		yield return new WaitForSeconds(TimeBeforeAntiDepressantsAdministered);
		depressed = false;//how's that for confidence?
	}
}
