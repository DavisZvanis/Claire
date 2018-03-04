using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunController))] //force to add script 

public class Player : LivingEntity {

    Animator animator;

    public Hud hud;
    public Inventory inventory;
    GunController gunController;
    public Gun chosenGun;
    private Interactable interactable = null;

    public float rotationSpeed = 100.0f;
    public float Speed = 100f;
    private bool isEquiped = true;
    private Item itemToPickUp = null;


    // Use this for initialization
    protected override void Start () {
        base.Start();                 //Calls base class in Living Entity start()
        gunController = GetComponent<GunController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //movement input
        float translation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        animator.SetFloat("Move", translation);
        animator.SetFloat("Rotate", rotation);

        playerMove(translation, rotation, isEquiped);

        if (isEquiped == true && Input.GetKeyDown("space"))
        {
            gunController.Shoot();
        }
        if (isEquiped == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            gunController.UnequipGun();
            isEquiped = false;
        }
        if (Input.GetKeyDown(KeyCode.C) && itemToPickUp != null)
        {
            inventory.AddItem(itemToPickUp);
            itemToPickUp = null;
            interactable.OnPickUp();
            hud.CloseMessagePanel();
        }
        

    }
    public void playerMove(float trans, float rot, bool equipped)
    {
        if(equipped == false)
        {
            transform.Translate(0, 0, trans);
            transform.Rotate(0, rot, 0);
        }
        else
        {
            transform.Rotate(0, rot, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponent<Interactable>();
        if (interactable!= null)
        {
            hud.OpenMessagePanel();
            itemToPickUp = interactable.GetItem();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Interactable item = other.GetComponent<Interactable>();
        if (item != null)
        {
            hud.CloseMessagePanel();
            itemToPickUp = null;
        }
    }
    public void UsingItem(Item item)
    {
        this.UpdatePlayerStatus(item.health,item.hunger,item.water);
    }
}

