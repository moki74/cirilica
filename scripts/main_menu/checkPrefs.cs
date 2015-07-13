using UnityEngine;
using System.Collections;
using System.IO;

public class checkPrefs : MonoBehaviour {
	public static user current_user;



	void Awake(){
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		if (PlayerPrefs.GetString ("users").Length < 1)
						Application.LoadLevel ("login");
				else {
					string[] userString = PlayerPrefs.GetString (PlayerPrefs.GetString ("current_user")).Split(',');
					current_user = new user(userString[0],"",userString[2],int.Parse (userString[3]));
			     }
		//current_user._ruka = "леворук";

	}
	// Use this for initialization
	void Start () {
		Debug.Log (current_user._ime + "," + current_user._prezime +  "," +  current_user._ruka + "," + current_user._godine.ToString());

	//	spremi_txt_file ();
	}

	public void spremi_txt_file(){
		
		StreamWriter sw = new StreamWriter ("RECI.txt");
		Object[] go = Resources.LoadAll ("azbuka_pics/velike");
		
		foreach (Object f in go) {
			//	zivotinje.Add (f.name);
			sw.WriteLine (f.name);
			
			
		}	
		sw.Close ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
