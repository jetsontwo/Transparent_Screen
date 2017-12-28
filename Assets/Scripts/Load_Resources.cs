using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Resources : MonoBehaviour {


    private GameObject[] villagers = new GameObject[100];
    private int count = 0;
    public GameObject villager;
    public float timer;
    public int num_trees, num_berries, num_stone;
    public GameObject tree, berry, stone, Material_Parent;

    // Use this for initialization
    void Start()
    {
        //For testing only
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("villagers", 100);

        if (!PlayerPrefs.HasKey("stone"))
            PlayerPrefs.SetInt("stone", 0);
        if (!PlayerPrefs.HasKey("wood"))
            PlayerPrefs.SetInt("wood", 0);
        if (!PlayerPrefs.HasKey("food"))
            PlayerPrefs.SetInt("food", 0);
        if (!PlayerPrefs.HasKey("villagers"))
            PlayerPrefs.SetInt("villagers", 10);



        for (int i = 0; i < PlayerPrefs.GetInt("villagers"); ++i)
        {
            villagers[count++] = Instantiate(villager, Vector2.zero, Quaternion.identity, transform);
        }
        for(int i = 0; i  < num_trees; ++i)
            Instantiate_Resource(tree);
        for (int i = 0; i < num_stone; ++i)
            Instantiate_Resource(stone);
        for (int i = 0; i < num_berries; ++i)
            Instantiate_Resource(berry);

        StartCoroutine(Spawn_Villager());
    }

    private IEnumerator Spawn_Villager()
    {
        //Waits to spawn the villagers for aesthetic affects
        yield return new WaitForSeconds(1f);
        for(int i =0; i < count; ++i)
        {
            villagers[i].transform.position = new Vector2(0, 0);
            villagers[i].SetActive(true);
            yield return new WaitForSeconds(timer);
        }
    }

    private void Instantiate_Resource(GameObject resource)
    {
        //Makes the x and y either positive or negative randomly
        int x_mod = Random.Range(1, 3) % 2 == 0 ? 1 : -1;
        int y_mod = Random.Range(1, 3) % 2 == 0 ? 1 : -1;

        //Chooses to make either the x or y full ranges to fill in the outside rim of the map
        int x_or_y = Random.Range(1, 3) % 2 == 0 ? 1 : -1;
        if (x_or_y == 1)
            Instantiate(resource, new Vector2(Random.Range(0, 8.5f) * x_mod, Random.Range(3.5f, 4.5f) * y_mod), Quaternion.identity, Material_Parent.transform);
        else
            Instantiate(resource, new Vector2(Random.Range(7.5f, 8.5f) * x_mod, Random.Range(0, 4.5f) * y_mod), Quaternion.identity, Material_Parent.transform);
    }

    public void Reset_Game()
    {
        PlayerPrefs.DeleteAll();
    }
}
