using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {
	
	// Use this for initialization
	//var scoreTextX : GUIText;
	
	float accelerometerUpdateInterval  ;
	
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds  = 1.0f;
	
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! <img src="http://www.lucedigitale.com/blog/wp-includes/images/smilies/icon_wink.gif" alt=";)" class="wp-smiley">
	float shakeDetectionThreshold  = 0.8f;
	
	float  lowPassFilterFactor  ;
	Vector3  lowPassValue = Vector3.zero;
	Vector3  acceleration ;
	Vector3  deltaAcceleration ;
	

	void Start()


	{
		accelerometerUpdateInterval  = 1.0f / 60.0f;
		lowPassFilterFactor  = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
	}
	
	
	void Update()
	{
		
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
		//			scoreTextX.text = "Shake event detected at time "+Time.time;
		}
		
	}
	

}
