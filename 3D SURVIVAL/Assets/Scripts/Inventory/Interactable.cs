using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Item item;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public Item GetItem()
    {
        return item;
    }
    public void OnPickUp()
    {    
            gameObject.SetActive(false);   
    }
}
