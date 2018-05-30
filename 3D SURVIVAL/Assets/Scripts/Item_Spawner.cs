using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour {


    public GameObject[] items;
    public Transform[] spawns;


    public void NewDayItems()
    {
        int i = Random.Range(0, spawns.Length);
        
        for (int a = 0; a <= i; a++)
        {
            int b = Random.Range(0, items.Length);
            Instantiate(items[b], spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity);
        }
    }
   
}
