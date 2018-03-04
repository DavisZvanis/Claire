using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public GameObject myCamera;
    private CameraManager myCameraManager;

	// Use this for initialization
	void Start () {
        myCameraManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CameraManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myCameraManager.DeactivateAllCameras();
            myCamera.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
