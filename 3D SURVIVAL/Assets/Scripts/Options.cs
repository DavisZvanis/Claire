using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Player player;
    public GameObject pauseText;
    public GameObject inventory;
    public Button inv1;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Time.timeScale == 1) {

                Time.timeScale = 0;
                pauseText.SetActive(true);
                inventory.SetActive(true);
                //panel.SetActive(true);
                inv1.Select();
            }
            else
            {
                pauseText.SetActive(false);
                inventory.SetActive(false);
               // panel.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}
