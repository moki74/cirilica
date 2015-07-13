using UnityEngine;
using System.Collections;

public class vreme : MonoBehaviour {
    public static float timer =0;


    void Start () {

       
    }

    void Update () {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    void pokreniVreme(){
        //Debug.Log ("pokrenuto demo VREME");
        timer+= Time.deltaTime;
        //Debug.Log (timer);
    
    }


}