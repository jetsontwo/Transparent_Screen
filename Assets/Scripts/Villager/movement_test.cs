using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_test : MonoBehaviour {

    public LayerMask buildalbe_layers;

    // Update is called once per frame
    void Update () {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            print(Physics2D.Raycast(mouse_pos, Vector2.zero, 1f, buildalbe_layers).collider.name);
    }
}
