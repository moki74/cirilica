using UnityEngine;
using System.Collections;

public class slovoPathovi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PathNodes pn = (PathNodes)Camera.main.GetComponent<PathNodes> ();
		pn.novoSlovo (this.gameObject.name);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
