using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public string level;
    public LevelManager levelManager;
    public Button myButton;
	// Use this for initialization
	void Start () {

        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		
	}

    void TaskOnClick()
    {
        levelManager.LoadLevel(level);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
