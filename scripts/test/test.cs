using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public UITexture tex;
	public UILabel lbl;
	public int i =0;
	public  static string [] words= new string[] {"Bicikl 800 72","Bicikl 800 264","Bicikl 1024 72","Bicikl 1024 264",
		"Gavran 800 72","Gavran 800 264","Gavran 1024 264","Gavran 1924 72",
		"Violina 800 72","violina 800 264","Violina 1024 72","Violina 1024 264"};

	// Use this for initialization
	void Start () {
		tex.mainTexture = Resources.Load ("azbuka_pics/test/" + words[i]) as Texture2D;
		lbl.text = words [i];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void leftClick()
	{
		if (i == 0)
						return;

		i --;
		tex.mainTexture = Resources.Load ("azbuka_pics/test/" + words[i]) as Texture2D;
		lbl.text = words [i];


	}

	public void rightClick()
	{	
		if (i == words.Length)
		return;
		
		i ++;
		tex.mainTexture = Resources.Load ("azbuka_pics/test/" + words[i]) as Texture2D;
		lbl.text = words [i];
		
				
	}

	public void returnMenu()
	{	
		Application.LoadLevel ("mainmenu");
		
	}

}
