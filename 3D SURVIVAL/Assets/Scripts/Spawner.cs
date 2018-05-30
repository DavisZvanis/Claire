using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawns;

    public void NewDay()
    {
        int i = Random.Range(0, spawns.Length);
        for(int a = 0; a<=i; a++)
        {
            Instantiate(enemy,spawns[Random.Range(0, spawns.Length)].transform.position,Quaternion.identity);
        }
    }


}
