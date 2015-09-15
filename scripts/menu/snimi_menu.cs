using UnityEngine;
using System.Collections;

public class snimi_menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){

		snimi ();


	}

	public void snimi(){
		UISlider [] slideri = GameObject.FindObjectsOfType<UISlider> ();
		foreach (UISlider slider in slideri) {
			
			PlayerPrefs.SetInt(slider.name,(int)slider.value);
		
		}
	
	}
}
