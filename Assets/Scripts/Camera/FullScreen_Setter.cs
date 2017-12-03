using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen_Setter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!Screen.fullScreen)
            Screen.fullScreen = true;
        Cursor.visible = false;
	}
	
}
