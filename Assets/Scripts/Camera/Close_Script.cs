using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Script : MonoBehaviour {

    private Vector2 mouse_pos;

    void Start()
    {
        Time.timeScale = 3f;
        mouse_pos = Input.mousePosition;
    }

	void Update()
    {
        Vector2 new_pos = Input.mousePosition;

        if (new_pos.magnitude - mouse_pos.magnitude > 0.5f || Input.anyKey || Input.GetMouseButton(0))
        {
            Cursor.visible = true;
            Application.Quit();
        }

        mouse_pos = new_pos;

    }
}
