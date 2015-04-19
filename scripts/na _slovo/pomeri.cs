using UnityEngine;
using System.Collections;

public class pomeri : MonoBehaviour {

	void OnClick(){
		//na_slovo_manager man = GameObject.Find ("Manager").GetComponent<na_slovo_manager> () as na_slovo_manager;
		//if (na_slovo_manager.num_correct <= 2)

		 this.collider.enabled = false;
		if (transform.GetComponentInChildren<UILabel> ().text.StartsWith (slova.trenutno_slovo.ToUpper ())) {
						
						this.gameObject.GetComponentInChildren <UISprite > ().spriteName = "check-mark-3-64";
						this.gameObject.GetComponentInChildren <UISprite > ().SetDimensions (100, 100);	
						this.gameObject.GetComponentInChildren <UISprite > ().color=Color.green;	
						na_slovo_manager.slike.Add (this.gameObject.name);
						na_slovo_manager.num_correct ++;
						//na_slovo_manager.reci.Add(transform.GetComponentInChildren<UILabel> ().text.ToLower());
					
				} else {
						this.gameObject.GetComponentInChildren <UISprite > ().spriteName = "no";
						this.gameObject.GetComponentInChildren <UISprite > ().SetDimensions (80, 80);
						this.gameObject.GetComponentInChildren <UISprite > ().color = Color.red ;
				}
	}


}