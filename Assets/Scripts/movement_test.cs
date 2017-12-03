using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_test : MonoBehaviour {

	bool sw = false;
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 5 || transform.position.x < -5)
            sw = !sw;
        if (sw)
        {
            transform.Translate(Vector3.right * -0.5f);
        }
        else
            transform.Translate(Vector3.right * 0.5f);
    }
}
