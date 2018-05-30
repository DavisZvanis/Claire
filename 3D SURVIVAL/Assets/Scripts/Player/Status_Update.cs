using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status_Update : MonoBehaviour {


    public Image water;
    public Image food;
    public Text ammo;
    public Image health;
    public Image temperature;

    public Player player;

    private Color green = new Color(0.2f, 1f, 0, 0.6f);
    private Color yellow = new Color(1f, 1f, 0, 0.6f);
    private Color red = new Color(1f, 0, 0, 0.6f);
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateWater();
        UpdateAmmo();
        UpdateFood();
        UpdateTemperature();
        UpdateHealth();
	}

    public void UpdateWater()
    {
        if (player.water >= 70)
        {
            water.color = green;
        }
        else if (player.water < 70 && player.water > 30)
        {
            water.color = yellow;
        }
        else if (player.water < 30)
        {
            water.color = red;
        }
    }
    public void UpdateFood()
    {
        if (player.hunger >= 70)
        {
            food.color = green;
        }
        else if (player.hunger < 70 && player.hunger > 30)
        {
            food.color = yellow;
        }
        else if (player.hunger < 30)
        {
            food.color = red;
        }
    }
    public void UpdateTemperature()
    {
        if (player.temperature >= 70)
        {
            temperature.color = green;
        }
        else if (player.temperature < 70 && player.temperature > 30)
        {
            temperature.color = yellow;
        }
        else if (player.temperature <= 30)
        {
            temperature.color = red;
        }
    }
    public void UpdateHealth()
    {
        if (player.health >= 70)
        {
            health.color = green;
        }
        else if (player.health < 70 && player.health > 30)
        {
            health.color = yellow;
        }
        else if (player.health < 30)
        {
            health.color = red;
        }
    }
    public void UpdateAmmo()
    {
        ammo.text = "Ammo: " + player.ammo;
    }
}
