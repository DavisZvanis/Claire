using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {
    new public string name;
    public Sprite sprite;
    public GameObject itemObject;
    public float health;
    public float food;
    public float water;
    public int ammo;
    public float temperature;
}
