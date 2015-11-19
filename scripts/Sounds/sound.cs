using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {

	private static sound instanceRef;
	public static bool playMusic = false;
	public static bool playEffects = false;
	public static bool playSounds = false;
	public static bool stopMusic = false;
	public static AudioSource aso;
	public static AudioSource aso1;
	//public static AudioClip ac;


	void Awake()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}else
		{
			DestroyImmediate(this.gameObject);
		}

		playMusic = (PlayerPrefs.GetInt ("muzika") == 1)? true:false;
		playSounds = (PlayerPrefs.GetInt ("naracija") == 1)? true:false;
	}
	// Use this for initialization
	void Start () {
		 aso = GetComponents<AudioSource>()[0] as AudioSource ;
		 aso1 = GetComponents<AudioSource>()[1] as AudioSource ;
		 
	
	}
	
	// Update is called once per frame
	void Update () {


		if (!playMusic && !stopMusic)
						return;
				else if (aso.isPlaying && stopMusic) {
					aso.Stop ();
					stopMusic = false;
					return;
					
				}
		if (!aso.isPlaying) 
			aso.Play ();
		playMusic = false;
	
	}

	public static void playEffect(string fileName,float volume=1f){
		if (!playEffects)
						return;
		AudioClip ac = Resources.Load ("audio/sounds/onomatopeja/" + fileName) as AudioClip;
		if (ac != null) {
						//AudioSource.PlayClipAtPoint (ac,Camera.main.transform.position , volume);
						if(aso1.isPlaying) aso1.Stop ();
						aso1.clip = ac;
						aso1.Play ();
				}

			
	}

	public static void playSound(string fileName,float volume=1f){
		if (!playSounds)
			return;

		 AudioClip ac = Resources.Load ("audio/sounds/" + fileName) as AudioClip;
		if (ac != null) {
			if(aso1.isPlaying) aso1.Stop ();
			AudioSource.PlayClipAtPoint (ac,Camera.main.transform.position , volume);
			//if(aso1.isPlaying) aso1.Stop ();
			//aso1.volume=volume;
			//aso1.clip = ac;
			//aso1.Play ();
		}
		
	}

}
