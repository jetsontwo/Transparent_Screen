using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Pausing());
	}

    //This is a pause to make sure everything loads before running to stop any weird physics bugs 
    private IEnumerator Pausing()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }
}
