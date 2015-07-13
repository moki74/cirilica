using UnityEngine;
using System.Collections;

public class explozija : MonoBehaviour {
	public float force;

	// Use this for initialization
	void Start () {

		Invoke ("explodiraj", 0.5f);
	
	}
	
	// Update is called once per frame
	void explodiraj () {
		this.rigidbody.AddExplosionForce (force, this.transform.position, 50);

	
	}
}
