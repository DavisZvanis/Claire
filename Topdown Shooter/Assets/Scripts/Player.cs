using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerController))] //force to add script 
[RequireComponent(typeof(GunController))] //force to add script 

public class Player : LivingEntity {

    Camera viewCamera;
    public float moveSpeed = 5;
    PlayerController controller;
    GunController gunController;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "AmmoPack")
        {
            
            Destroy(col.gameObject);
            gunController.GainAmmo(100);
        }
    }
    // Use this for initialization
    protected override void Start () {
        base.Start();                 //Calls base class in Living Entity start()
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        //movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance)){
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);

        //gun input
        if (Input.GetMouseButton(0))
            {
                gunController.Shoot();
            }
            
        }
        
    }
}
