using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {

    new public string name;
    public Sprite sprite;
    public GameObject itemObject;
    public float health;
    public float hunger;
    public float water;
    public bool isBandage;
    public bool isGun;

  

}
