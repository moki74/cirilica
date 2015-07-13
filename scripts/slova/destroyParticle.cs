using UnityEngine;
using System.Collections;

public class destroyParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("particleDestroy", 2);
	
	}
	

	void particleDestroy () {
		Destroy (this.gameObject);
	
	}
}
