using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Text wood_text, food_text, stone_text;
	
	// Update is called once per frame
	void Update () {
        wood_text.text = "Wood: " + PlayerPrefs.GetInt("wood");
        stone_text.text = "Stone: " + PlayerPrefs.GetInt("stone");
        food_text.text = "Food: " + PlayerPrefs.GetInt("food");
    }
}
