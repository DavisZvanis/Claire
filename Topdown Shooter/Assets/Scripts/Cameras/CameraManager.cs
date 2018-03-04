using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject[] cameras;
    public GameObject startCamera;

	// Use this for initialization
	void Start () {

        cameras = GameObject.FindGameObjectsWithTag("Camera");
        DeactivateAllCameras();
        startCamera.SetActive(true);

	}
	
    public void DeactivateAllCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
