using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager_Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private bool has_position = false;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Begin();
	}


    private void Begin()
    {
        Vector2 next_position = Vector2.zero;
        if (!has_position)
        {
            next_position = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            //print(next_position);
            has_position = true;
        }
        StartCoroutine(Go_To_Position(next_position));
    }

    private IEnumerator Go_To_Position(Vector2 pos)
    {
        while(true)
        {
            rb.velocity = (-((Vector2) transform.position - pos).normalized * speed * Time.deltaTime);
            if(((Vector2) transform.position - pos).magnitude < 0.2f)
            {
                rb.velocity = Vector3.zero;
                yield return new WaitForSeconds(0.5f);
                has_position = false;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        Begin();
    }


    //private IEnumerator Gather()
    //{

    //}

}
