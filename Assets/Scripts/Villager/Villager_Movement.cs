using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager_Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private bool at_position = false;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Begin();
	}


    private void Begin()
    {
        GameObject resource = find_closest_resource();
        if (resource != null)
        {
            resource.GetComponent<Material_Controller>().ClaimResource();
            StartCoroutine(Gather(resource));
        }
        else
            StartCoroutine(Wander());

    }


    //States



    private IEnumerator Gather(GameObject resource)
    {
        StartCoroutine(Go_To_Position(resource.transform.position));
        yield return new WaitUntil(Get_at_position);

        //The wait for the gathering animation
        yield return new WaitForSeconds(1f);
        resource.GetComponent<Material_Controller>().GetResource();
        Begin();

    }

    private IEnumerator Wander()
    {
        StartCoroutine(Go_To_Position(new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f))));
        yield return new WaitUntil(Get_at_position);
        Begin();
    }



    //Helper Functions


    private IEnumerator Go_To_Position(Vector2 pos)
    {
        at_position = false;
        while (true)
        {
            rb.velocity = (-((Vector2)transform.position - pos).normalized * speed * Time.deltaTime);
            if (((Vector2)transform.position - pos).magnitude < 0.2f)
            {
                rb.velocity = Vector3.zero;
                yield return new WaitForSeconds(0.5f);
                at_position = true;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool Get_at_position()
    {
        return at_position;
    }



    private GameObject find_closest_resource()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);
        float min_distance = 50;
        GameObject closest = null;
        foreach (Collider2D c in colliders)
        {
            if ((transform.position - c.transform.position).magnitude < min_distance && c.tag == "Material")
            {
                closest = c.gameObject;
                min_distance = (transform.position - c.transform.position).magnitude;
            }
        }
        return closest;
    }
}
