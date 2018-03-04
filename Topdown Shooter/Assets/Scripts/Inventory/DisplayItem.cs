using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour {

    public Item item;


	// Use this for initialization
	void Start () {
        Instantiate(item.itemObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
