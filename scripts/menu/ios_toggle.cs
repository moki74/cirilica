using UnityEngine;
using System.Collections;

public class ios_toggle : MonoBehaviour {
    UISprite  uis;
    float value =0;
	// Use this for initialization
	void Start () {

		uis = this.GetComponent<UISprite>();
		value = (float) PlayerPrefs.GetInt (this.name);
        if (value > 0f) uis.spriteName="High Volume-100";
             else uis.spriteName="Mute-100";
	
	}
	
	// Update is called once per frame
	public void OnClick() {
        Debug.Log("KLIIIIK");
		if (value == 0f) {
						value = 1f;
						if (this.name == "muzika"){
								sound.playMusic = true;	
                                 

						}
						else if (this.name == "naracija")
								sound.playSounds  = true;
						else
								sound.playEffects = true;
                         uis.spriteName="High Volume-100";
				} else {
						value = 0f;
						if (this.name == "muzika"){
							sound.playMusic = false;
							sound.stopMusic = true;
						}
						else if (this.name == "naracija")
							sound.playSounds = false;
						else
							sound.playEffects = false;
                         uis.spriteName="Mute-100";

				}
		menuManager.snimi ();
	
	}
}
