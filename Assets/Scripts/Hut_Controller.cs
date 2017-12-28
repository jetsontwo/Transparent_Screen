using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hut_Controller : MonoBehaviour {

    private int stage = 0;
    private int max_stage = 3;
    public Sprite[] stage_sprites;

    public int GetStage()
    {
        return stage;
    }

    public void addStage()
    {
        if((stage + 1) <= max_stage)
            GetComponent<SpriteRenderer>().sprite = stage_sprites[++stage];
    }

}
