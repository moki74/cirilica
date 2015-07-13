using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class listUsers : MonoBehaviour {

	public UITable table;
	private UITexture _texture;
	List<UITexture> texs = new List<UITexture>();
	List<string > paths = new List<string>();
	private int j=0;

	// Use this for initialization
	void Start () {
  	listAll ();
	//	deleteAll ();
		//PlayerPrefs.Flush ();

		//PlayerPrefs.DeleteKey ("users");
		//PlayerPrefs.Flush ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void deleteAll(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		PlayerPrefs.Save ();
		Debug.Log ("Posle Del aLL");

	}


	public void listAll()
	{

		Transform [] rows  = table.children.ToArray ();
		if (rows.Length > 0) {
			for (int i = 0;i < rows.Length; i++	)
				if (rows[i] != null )
				DestroyImmediate (rows[i].gameObject);

		}
		if (PlayerPrefs.HasKey ("users") && PlayerPrefs.GetString("users").Length > 1  ) {
						
						string [] users = PlayerPrefs.GetString ("users").Split (',');
						Debug.Log (PlayerPrefs.GetString ("users"));
						foreach (string user in users) {
								
								string [] prefs = PlayerPrefs.GetString (user).Split (',');
								GameObject row  =NGUITools.AddChild(GameObject.Find ("Table"), Resources.Load ("UserRow") as GameObject);
								row.transform.localScale =new Vector3(240f,240f,1f);
								row.name=prefs[0];
								UILabel ime = row.transform.FindChild ("lblIme").GetComponent<UILabel>();
								ime.text = row.name=prefs[0];
							//	UILabel god = row.transform.FindChild ("lblGod").GetComponent<UILabel>();
							//	god.text = row.name=prefs[3];
								if ( prefs.Length > 4 && prefs[4].Length > 2){
									
									_texture = row.transform.FindChild ("Texture").GetComponent<UITexture>();
									texs.Add (_texture);
									paths.Add(prefs[4]);
								//	StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + prefs[4], textureLoaded, textureLoadFailed));
									
								}
						}
			table.Reposition ();
			StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + paths[0], textureLoaded, textureLoadFailed));	


		}


	}


	         
	
		

			// Texture loading delegates
			public void textureLoaded( Texture2D texture )
			{
				//testPlane.renderer.material.mainTexture = texture;
				texs[j].mainTexture = texture;
				j++;
				if (j < texs.Count) 
						StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + paths [j], textureLoaded, textureLoadFailed));
				else
						j = 0;
					
 			}


			public void textureLoadFailed( string error )
			{
				var buttons = new string[] { "OK" };
				EtceteraBinding.showAlertWithTitleMessageAndButtons( "Error Loading Texture.  Did you choose a photo first?", error, buttons );
				Debug.Log( "textureLoadFailed: " + error );
			}



		public void dodajUsera(){

			Application.LoadLevel ("login");


		}

	IEnumerator sacekaj(float time) {
		
		yield return new WaitForSeconds(time);
		Debug.Log ("YIEEEELLLLLD");
	
		
	}
}
