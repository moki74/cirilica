using UnityEngine;
using System.Collections;

public class ios_toggle : MonoBehaviour {
	UISlider uis;
	// Use this for initialization
	void Start () {

		uis = transform.GetComponentInParent<UISlider> ();
		uis.value = (float) PlayerPrefs.GetInt (uis.name);
	
	}
	
	// Update is called once per frame
	void OnClick () {
		if (uis.value == 0f) {
						uis.value = 1f;
						if (uis.name == "muzika"){
								sound.playMusic = true;					

						}
						else if (uis.name == "naracija")
								sound.playSounds  = true;
						else
								sound.playEffects = true;
				} else {
						uis.value = 0f;
						if (uis.name == "muzika"){
							sound.playMusic = false;
							sound.stopMusic = true;
						}
						else if (uis.name == "naracija")
							sound.playSounds = false;
						else
							sound.playEffects = false;

				}
		menuManager.snimi ();
	
	}
}
