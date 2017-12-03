using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager_Movement : MonoBehaviour {

    private Rigidbody2D rb;

    private Vector2 next_position;
    private bool has_position = false;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Begin();
	}


    private void Begin()
    {
        if (!has_position)
        {
            next_position = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            has_position = true;
        }
        StartCoroutine(Walking());
    }

    private IEnumerator Walking()
    {
        while(true)
        {
            transform.LookAt(next_position);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(((Vector2) transform.position - next_position).magnitude < 1)
            {
                yield return new WaitForSeconds(0.5f);
                has_position = false;
                Begin();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

}
