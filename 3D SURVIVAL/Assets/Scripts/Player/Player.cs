using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(GunController))] //force to add script 

public class Player : LivingEntity {

    Animator animator;

    public LevelManager levelManager;
    public Transform weaponHold;
    public Hud hud;
    public Inventory inventory;
  //  GunController gunController;
 //   public Gun chosenGun;
    public Interactable interactable = null;
    public Warmth warmSpace = null;
    

    public float rotationSpeed = 100.0f;
    public float Speed = 100f;
  //  private bool isEquiped = true;
    public Item itemToPickUp = null;
    private bool allowMove = true;
    private bool isAiming = false;
    private bool gameOver = false;

    float timeBetweenAttacks = 1;
   // float damage = 1;
    float nextAttackTime;

    public GameObject gun;
    private FieldOfView sight;

    // Use this for initialization
    protected override void Start () {
        base.Start();                 //Calls base class in Living Entity start()
      //  gunController = GetComponent<GunController>();
        animator = GetComponent<Animator>();
        sight = GetComponent<FieldOfView>();

        GameObject myNewItem = Instantiate(gun, weaponHold.position, weaponHold.rotation);
        myNewItem.transform.parent = weaponHold;

        InvokeRepeating("Freeze", 1.0f, 2.0f);
        InvokeRepeating("Hunger", 0f, 3.0f);
        InvokeRepeating("Thirst", 0f, 3.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isAiming == false)
            {
                animator.SetBool("Aiming", true);
                isAiming = true;
                return;
            }
            else if (isAiming == true)
            {
                animator.SetBool("Aiming", false);
                isAiming = false;
            }
        }
        if (isAiming == true && Input.GetKeyDown(KeyCode.C))
        {
            if (Time.time > nextAttackTime && this.HasAmmo())
            { 
                        nextAttackTime = Time.time + timeBetweenAttacks;
                        animator.SetBool("Shooting", true);
                        this.Shoot();
                        sight.Shoot();
            }
 
        }
        if (Input.GetKeyDown(KeyCode.C) && itemToPickUp != null)
        {
            allowMove = false;
            animator.SetBool("PickUp", true);

        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (!dead)
        {
            if (allowMove)
            {
                //movement input
                float translation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
                float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

                PlayerMove(translation, rotation);

                animator.SetFloat("Move", translation);
                animator.SetFloat("Rotate", rotation);
            } 
        }
        else if(dead && gameOver == false)
        {
            DieNow();
        }
    }
    public void PlayerMove(float trans, float rot)
    {
        if (isAiming)
        {
            transform.Rotate(0, rot, 0);
        }
        else
        {
            transform.Translate(0, 0, trans);
            transform.Rotate(0, rot, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponent<Interactable>();
       // Warmth warmSpace = other.GetComponent<Warmth>();
        if (interactable!= null)
        {
            hud.OpenMessagePanel();
            itemToPickUp = interactable.GetItem();
        }
       /* else if (warmSpace != null)
        {
            CancelInvoke("Freeze");
            InvokeRepeating("GetWarm", 1.0f, 1.0f);
        }
        */
    }
    private void OnTriggerExit(Collider other)
    {
       // Interactable item = other.GetComponent<Interactable>();
       // Warmth warmSpace = other.GetComponent<Warmth>();
        
            hud.CloseMessagePanel();
            itemToPickUp = null;
             interactable = null;
        
        /*
        else if (warmSpace != null)
        {
            CancelInvoke("GetWarm");
            InvokeRepeating("Feeze", 1.0f, 3.0f);
        }
        */
    }

    public void GetWarm()
    {
        this.UpdatePlayerStatus(0, 0, 0, 0, 1);
    }
   
    public void UsingItem(Item item)
    {
      /*  if (item.isGun)
        {
            foreach (Transform child in weaponHold.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            GameObject myNewItem = Instantiate(item.itemObject, weaponHold.position, weaponHold.rotation);
            myNewItem.transform.parent = weaponHold;
        }
        else
        {
        */
            this.UpdatePlayerStatus(item.health, item.food, item.water, item.ammo, item.temperature);
        
    }
    public void AllowMove()
    {
        animator.SetBool("PickUp", false);
        allowMove = true;
    }
    public void PickUpAnim()
    {
        inventory.AddItem(itemToPickUp);
        interactable.OnPickUp();
        itemToPickUp = null;
        interactable = null;
        hud.CloseMessagePanel();
    }
    public void Freeze()
    {
        if (this.temperature > 0)
        {
            this.UpdatePlayerStatus(0, 0, 0, 0, -1);
        }
        else
        {
            this.UpdatePlayerStatus(-1, 0, 0, 0, 0);
        }
        
    }
    public void Hunger()
    {
        if(this.hunger > 0)
        {
            this.UpdatePlayerStatus(0, -5, 0, 0, 0);
        }
        else
        {
            this.UpdatePlayerStatus(-1, 0, 0, 0, 0);
        }
       
    }
    public void Thirst()
    {
        if(this.water > 0)
        {
            this.UpdatePlayerStatus(0, 0, -5, 0, 0);
        }
        else
        {
            this.UpdatePlayerStatus(-1, 0, 0, 0, 0);
        }
        
    }
    public void ShootAnim()
    {
        animator.SetBool("Shooting", false);
    }
    public void DieNow()
    {
        gameOver = true;
        animator.SetBool("Dead", true);
    }
    public void GameOver()
    {
        levelManager.LoadLevel("GameOver");
    }
    
}

