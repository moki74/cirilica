using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public UISlider uis;


	void Start () {

		//uis.value = 0.2f;
	}
	// Use this for initialization
	void OnMouseDown() {
		if (uis.value > 0.2)
						uis.value = 0f;
				else
						uis.value = 1f;
	
	}
	
	// Update is called once per frame

}
