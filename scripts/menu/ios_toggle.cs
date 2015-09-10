using UnityEngine;
using System.Collections;

public class ios_toggle : MonoBehaviour {
    UISprite  uis;
    int value =0;
	// Use this for initialization
	void Start () {

		uis = this.GetComponent<UISprite>();
		value = PlayerPrefs.GetInt (this.name);
        if (value > 0) uis.spriteName="High Volume-100";
             else uis.spriteName="Mute-100";
	
	}
	
	// Update is called once per frame
	public void OnClick() {
    //    Debug.Log("KLIIIIK");
		if (value == 0) {
						value = 1;
						if (this.name == "muzika"){
								sound.playMusic = true;	
                                menuManager.muzika=1;
                                
						}
						else if (this.name == "naracija"){
								sound.playSounds  = true;
                                menuManager.naracija =1;
                        }
						else{
								sound.playEffects = true;
                                menuManager.efekti =1;
                        } 
                        uis.spriteName="High Volume-100";
				} else {
						value = 0;
						if (this.name == "muzika"){
							sound.playMusic = false;
							sound.stopMusic = true;
                            menuManager.muzika=0;
						}
						else if (this.name == "naracija"){
							sound.playSounds = false;
                             menuManager.naracija =0;
                        }
						else{
							sound.playEffects = false;
                            menuManager.efekti =0;
                        }
                         uis.spriteName="Mute-100";

				}
		menuManager.snimi ();
	
	}
}
