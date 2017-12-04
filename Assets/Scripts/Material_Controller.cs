using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Controller : MonoBehaviour {

    public Sprite broken_version, collectable_version;
    public string material;

	public void AddMaterial()
    {
        PlayerPrefs.SetInt(material, PlayerPrefs.GetInt(material) + 1);
    }
}
