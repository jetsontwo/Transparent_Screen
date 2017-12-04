using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Controller : MonoBehaviour {

    public Sprite broken_version, collectable_version;
    public string material;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ClaimResource()
    {
        //Takes things off of list of materials that can be gathered
        tag = "Depleated";
    }

    public void GetResource()
    {
        PlayerPrefs.SetInt(material, PlayerPrefs.GetInt(material) + 1);
        sr.sprite = broken_version;
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(Random.Range(5f, 8f));
        tag = "Material";
        sr.sprite = collectable_version;
    }
}
