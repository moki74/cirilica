using UnityEngine;
using System.Collections;

public class menuManager : MonoBehaviour {

	public static int muzika = 0;
	public static int efekti = 1;
	public static int naracija = 0;


	// Use this for initialization
	void Start () {

		ucitaj ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ucitaj(){
		if (PlayerPrefs.HasKey ("muzika")){
		
			muzika = PlayerPrefs.GetInt ("muzika");
			efekti = PlayerPrefs.GetInt ("efekti");
			naracija = PlayerPrefs.GetInt ("naracija");
		}


	}


	public static void setuj(int muz,int efe, int nar){
		muzika = muz;
		efekti = efe;
		naracija = nar;
	 
	}

	public static void snimi(){
	//	PlayerPrefs.SetInt ("muzika",muzika) ;
	//	PlayerPrefs.SetInt ("efekti",efekti) ;
	//	PlayerPrefs.SetInt ("naracija",naracija) ;

		UISlider [] slideri = GameObject.FindObjectsOfType<UISlider> ();
		foreach (UISlider slider in slideri) {
			
			PlayerPrefs.SetInt(slider.name,(int)slider.value);
			
		}

		
	}

}
