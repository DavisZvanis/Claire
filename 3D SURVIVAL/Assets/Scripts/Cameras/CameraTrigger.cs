using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public Transform myCamera;
    private CameraManager myCameraManager;

	// Use this for initialization
	void Start () {
        myCameraManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CameraManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myCameraManager.startCamera.transform.rotation = myCamera.transform.rotation;
            myCameraManager.startCamera.transform.position = myCamera.transform.position;
          
        }
    }
}
