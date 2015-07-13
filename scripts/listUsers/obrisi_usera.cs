using UnityEngine;
using System.Collections;


public class obrisi_usera : MonoBehaviour {
	string user;

	// Use this for initialization
	public void OnClick(){


		Debug.Log ("Brisanje");
		user = transform.parent.FindChild ("lblIme").GetComponent <UILabel> ().text;
		PlayerPrefs.DeleteKey (user);


		listUsers li = GameObject.FindObjectOfType <listUsers> () as listUsers;
		string  users = PlayerPrefs.GetString ("users");
		if (users.Contains (user + ","))
			users = users.Replace (user + ",", "");
		else if (users.Contains ("," + user))
		      users = users.Replace ("," + user , "");
		else users = users.Replace (user , "");


		if (PlayerPrefs.GetString ("current_user") == user) {


					PlayerPrefs.SetString ("current_user", users.Split (',')[0]);	
				}
		PlayerPrefs.SetString ("users", users);
		PlayerPrefs.DeleteKey  (user);
		PlayerPrefs.Save();
		Debug.Log ("Current USER " + PlayerPrefs.GetString ("current_user"));
		li.listAll ();
		//DestroyImmediate (GameObject.Find (user));

	}


}
