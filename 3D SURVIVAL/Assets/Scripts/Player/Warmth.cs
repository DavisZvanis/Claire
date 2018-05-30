using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warmth : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
       Player player = other.GetComponent <Player> ();
        if (player != null)
        {
            player.CancelInvoke("Freeze");
            player.InvokeRepeating("GetWarm", 1f, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CancelInvoke("GetWarm");
            player.InvokeRepeating("Freeze", 1f, 3f);
        }
    }
}
