using UnityEngine;
using System.Collections;

using System.Collections.Generic ;
using System.IO;
//using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class userManager : MonoBehaviour {

	public UIInput ime,godine;
	public UIPopupList ruka;
	private string imagePath;
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





			// Listen to image picker event so we can load the image into a texture later
			EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;

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
		// Stop listening to the image picker event
		EtceteraManager.imagePickerChoseImageEvent -= imagePickerChoseImage;
	}
	
//	#endif
	
	
	void imagePickerChoseImage( string imagePath )
	{
		this.imagePath = imagePath;


		StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + imagePath, textureLoaded, textureLoadFailed));

	}

	// Texture loading delegates
	public void textureLoaded( Texture2D texture )
	{
		//testPlane.renderer.material.mainTexture = texture;
		tex.mainTexture = texture;
	}
	
	
	public void textureLoadFailed( string error )
	{
		var buttons = new string[] { "OK" };
		EtceteraBinding.showAlertWithTitleMessageAndButtons( "Error Loading Texture.  Did you choose a photo first?", error, buttons );
		Debug.Log( "textureLoadFailed: " + error );
	}
	
	public void OnClick() {
	//	PlayerPrefs.SetString ("users", "");
	//	PlayerPrefs.SetString ("users", "");
	//	PlayerPrefs.Flush ();
        setujUser (ime.value  ,"",ruka.value, int.Parse (godine.value) );
	//	string [] users = PlayerPrefs.GetString ("users").Split (',');
	//	foreach (string user in users)

	//		Debug.Log (PlayerPrefs.GetString (user));

	//	Debug.Log ("PICTURE");
	//	EtceteraBinding.promptForPhoto (0.5f);

	}


	public void List() {
		Application.LoadLevel ("list_user");
		
	}

	public void Slika() {
		//Debug.Log ("SLIKA");
		EtceteraBinding.promptForPhoto (0.5f);
		
	}




	// Update is called once per frame
}
