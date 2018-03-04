using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Player player;

    public GameObject pauseText;
    public GameObject inventory;
    public GameObject panel;

    public Text health;
    public Text hunger;
    public Text water;
    public Text temperature;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Time.timeScale == 1) {

                Time.timeScale = 0;
                UpdateUI();
                pauseText.SetActive(true);
                inventory.SetActive(true);
                panel.SetActive(true);
            }
            else
            {
                pauseText.SetActive(false);
                inventory.SetActive(false);
                panel.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
    public void UpdateUI()
    {
        health.text = "Health: " + player.health;
        hunger.text = "Hunger: " + player.hunger;
        water.text = "Water: " + player.water;
    }
}
