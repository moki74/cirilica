using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {

	private static sound instanceRef;
	public static bool playMusic = true;
	public static bool playEffects = true;
	public static bool playSounds = true;
	public static bool stopMusic = false;
	public static AudioSource aso;



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
		 aso = GetComponent<AudioSource>() as AudioSource ;
	
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
		AudioClip ac = Resources.Load ("audio/effetcs/" + fileName) as AudioClip;
		if (ac != null)
			AudioSource.PlayClipAtPoint (ac,Camera.main.transform.position , volume);

			
	}

	public static void playSound(string fileName,float volume=1f){
		if (!playSounds)
			return;
		AudioClip ac = Resources.Load ("audio/sounds/" + fileName) as AudioClip;
		if (ac != null)
			AudioSource.PlayClipAtPoint (ac, Camera.main.transform.position, volume);
		
		
	}
}
