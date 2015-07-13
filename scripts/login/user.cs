using UnityEngine;
using System.Collections;

public class user {

	public string _ime = "";
	public string _prezime = "";
	public string _ruka = "desna";
	public string slika = "";
	public int _godine;

	
	// Use this for initialization
	public user(string ime,string prezime, string ruka , int godine){
		_ime = ime;
		_prezime = prezime;
		_ruka = ruka;
		_godine = godine;
	}

	public override string ToString()
	{
	
		return (_ime + "," + _prezime + "," + _ruka + "," + _godine.ToString ()+ "," +slika);
	}



//	public static bool postoji (string userName)
//	{
//		return (PlayerPrefs.HasKey ("userName"));
//	}
}
