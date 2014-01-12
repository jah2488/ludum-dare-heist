using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	public delegate void UseHandler(Vector3 location);
	public static event UseHandler OnUse;

	public delegate void DamageHandler(float damage);
	public static event DamageHandler OnDamagePlayer;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	public static void Use(Vector3 location){
		if (OnUse != null)
			OnUse (location);
	}

	public static void DamagePlayer(float damage){
		if (OnDamagePlayer != null)
			OnDamagePlayer (damage);
	}
}

