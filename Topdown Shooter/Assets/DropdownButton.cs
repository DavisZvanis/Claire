using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButton : MonoBehaviour {

    public Button itemButton;
    public Inventory inventory;
    public GameObject dropdown;
    public Button useButton;
    public int i;

	// Use this for initialization
	void Start () {
        Button btn = itemButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
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

        }
        else
        {
            Debug.Log("Item not available");
        }

    }
}
