using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {

	AsyncOperation async;
	//public MovieTexture mt;
	// Use this for initialization
	void Start () {

	//	AudioSource aso = GetComponent<AudioSource>();
	//	aso.clip = movie.audioClip;

	//	aso.Play ();
			StartCoroutine(load());
			StartCoroutine(CoroutinePlayMovie());
	}
		
	protected IEnumerator CoroutinePlayMovie() {
			Handheld.PlayFullScreenMovie ("Comp7.mov", Color.white, FullScreenMovieControlMode.CancelOnInput);
			yield return new WaitForSeconds(7.0f); //Allow time for Unity to pause execution while the movie plays.
			//Application.LoadLevel("mainmenu");
			ActivateScene ();
	}


	IEnumerator load() {
		Debug.LogWarning("ASYNC LOAD STARTED - " +
		                 "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
		async = Application.LoadLevelAsync("mainmenu");
		async.allowSceneActivation = false;
		yield return async;
	}

	public void ActivateScene() {
		async.allowSceneActivation = true;
	}


}
	

