using UnityEngine;
using System.Collections;

public class colorPickeronoff : MonoBehaviour {
	public static bool enabled = false;
	public GameObject target;

	// Use this for initialization
	void OnClick () {
		//if (!enabled)
		if (!target.activeSelf)
		{

			target.SetActive (true);
			enabled =true;
		}
		else 
		{
			target.SetActive (false);
			enabled =false;
		}
	
	}
	
	// Update is called once per frame

}
