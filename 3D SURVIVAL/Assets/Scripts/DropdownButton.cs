using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButton : MonoBehaviour {

    public Button[] buttons;
    public Button itemButton;
    public Inventory inventory;
    public GameObject dropdown;
    public Button useButton;
    public int i;

	// Use this for initialization
	void Start () {
        itemButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        if(inventory.IsEmpty(i) == false)
        {
            dropdown.SetActive(true);
            Debug.Log("You have used item");
            itemButton.interactable = false;
            useButton.Select();
            DisableButtons();
        }
        else
        {
            Debug.Log("Item not available");
        }

    }

    void DisableButtons()
    {
        for (int a = 0; a < buttons.Length ; a++)
        {
            buttons[a].interactable = false;
        }
    }

}
