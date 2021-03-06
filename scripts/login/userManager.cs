﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic ;
using System.IO;
//using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class userManager : MonoBehaviour {

	public UIInput ime,godine;
	public UIPopupList ruka;
    public string ruka_s = "desnoruk";
	private string imagePath;
    private int tsti = 0;
//	public GameObject testPlane;
	public UITexture tex;

	user _user;

	// Use this for initialization
	void setujUser(string ime,string prezime,string ruka, int godine){

		if (! PlayerPrefs.HasKey (ime))
						dodaj (ime);
		_user = new user (ime, prezime, ruka, godine);
		_user.slika = imagePath;

		//FileInfo info = new FileInfo(imagePath);
		//if(info == null || info.Exists == false)
		 //	EtceteraBinding.saveImageToPhotoAlbum (imagePath);
		//Debug.Log (PlayerPrefs.GetString ("users"));
		PlayerPrefs.SetString (ime, _user.ToString ());
		PlayerPrefs.SetString ("current_user",ime);
		PlayerPrefs.Save();
		Debug.Log ("CURRENT USER " + PlayerPrefs.GetString ("current_user"));
	//	Debug.Log (_user.ToString ());
	}

	void dodaj(string ime){
				if (PlayerPrefs.HasKey ("users") && PlayerPrefs.GetString ("users").Length > 2) {
						PlayerPrefs.SetString ("users", PlayerPrefs.GetString ("users") + "," + ime);
						Debug.Log ("U set users postoje");

				} 
				else {
				
						PlayerPrefs.SetString ("users", ime );
						Debug.Log ("U set users");
				
				}


	}

	void ukloni(string ime){
					
		if (PlayerPrefs.HasKey (ime)) {
			PlayerPrefs.DeleteKey (ime);
		}
	}

	public void setPath(string path){
		
		imagePath = path;
		
		
	}

//	#if UNITY_IPHONE	

	void Start () {




        #if UNITY_IPHONE
			// Listen to image picker event so we can load the image into a texture later
			EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
        #endif


	//	PlayerPrefs.DeleteAll ();
	//	PlayerPrefs.Flush ();
	//	setujUser ("Pera", "Peric", "leva", 7);
	//	setujUser ("Mika", "Mikic", "desna",8);
	//	setujUser ("Zika", "Zikic", "leva",4);

	//	string [] users = PlayerPrefs.GetString ("users").Split (',');
	//	foreach (string user in users)
	//					Debug.Log (PlayerPrefs.GetString (user));
		//Debug.Log (PlayerPrefs.GetString ("player"));
		//Debug.Log (PlayerPrefs.GetString ("Mika"));
	
	
	}

	void OnDisable()
	{
        #if UNITY_IPHONE
		// Stop listening to the image picker event
		EtceteraManager.imagePickerChoseImageEvent -= imagePickerChoseImage;
        #endif
	}
	
//	
	
	
	void imagePickerChoseImage( string imagePath )
	{
        #if UNITY_IPHONE
		this.imagePath = imagePath;
        StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + imagePath, textureLoaded, textureLoadFailed));
        #endif
	}

	// Texture loading delegates
	public void textureLoaded( Texture2D texture )
	{
		//testPlane.renderer.material.mainTexture = texture;
		tex.mainTexture = texture;
	}
	
	
	public void textureLoadFailed( string error )
	{
        #if UNITY_IPHONE
		var buttons = new string[] { "OK" };
		EtceteraBinding.showAlertWithTitleMessageAndButtons( "Error Loading Texture.  Did you choose a photo first?", error, buttons );
		Debug.Log( "textureLoadFailed: " + error );
        #endif
	}
	
	public void OnClick() {
	//	PlayerPrefs.SetString ("users", "");
	//	PlayerPrefs.SetString ("users", "");
	//	PlayerPrefs.Flush ();
        if (ime.value.Length > 0 && godine.value.Length  > 0) {
            setujUser (ime.value  ,"",ruka_s, int.Parse (godine.value) );
            List();

        }
	//	string [] users = PlayerPrefs.GetString ("users").Split (',');
	//	foreach (string user in users)

	//		Debug.Log (PlayerPrefs.GetString (user));

	//	Debug.Log ("PICTURE");
	//	EtceteraBinding.promptForPhoto (0.5f);

	}



    public void leva_ruka() {

        GameObject.Find ("ruka_highlight").transform.localPosition = new Vector3(-85f,0,0);            
        ruka_s = "levoruk";      
        
    }

    public void desna_ruka() {
        
        GameObject.Find ("ruka_highlight").transform.localPosition = new Vector3(85f,0,0);            
        ruka_s = "desnoruk";      
        
    }


	public void List() {
		Application.LoadLevel ("list_user");
		
	}

	public void Slika() {
		//Debug.Log ("SLIKA");
        #if UNITY_IPHONE
		EtceteraBinding.promptForPhoto (1f,PhotoPromptType.Camera);
        #endif
		
	}




	// Update is called once per frame
}
