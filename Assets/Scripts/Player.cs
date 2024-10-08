using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    //public float playerSpeed;
    public float rotSpeed = 280.0f;
    public float currSpeed = 5.0f;
    public float sprintSpeed = 5f;

    public Vector2 movement;

    float horiz;
    float vert;

    public HUDManager hud;
    public GameManager gm;
    public StaminaController staminaController;

    public int playerHealth = 100;
    public int playerAmmo = 10;

    //public Transform cam;
    public bool sprint;
    public bool RedKey = false;
    public int Gear = 0;
    public int PadKey;
    public  bool IsDead;
    public GameObject RespawnPoint;
    public GameObject GearObj;
    public GameObject MarkerObj;
    public GameObject spawnPt;
    public GameObject bulletObj;
    public Transform barrel;

    //If player has gears setactive sprite in inventory with child of text displaying amount
    //same for sword
    //equipscript to player and target to object to drop but set drop to invenmtory  button not keybind





    void Start()
    {
        staminaController = GetComponent<StaminaController>();
        rb = GetComponent<Rigidbody>();
       // rb.freezeRotation = true;
    }
    


    public void Drop()
    {
        if (Gear >= 1)
        {
            Instantiate(GearObj, spawnPt.transform.position, Quaternion.identity);
            UseItem();
        }
        else
        {
            Debug.Log("You do not have enough to give");
            //print error
        }

    }
    public void OnPlaceMarker()
    {
            Instantiate(MarkerObj, spawnPt.transform.position, Quaternion.identity);

    }
    public void OnYesButton()
    {
        Respawn();
    }
    public void OnNoButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (IsDead)
        {
            playerHealth = 0;
            rb.isKinematic = true;
            hud.DisplayDeath();
        }

        if (sprint == true)
        {
            if (staminaController.playerStamina > 5f)
            {
                staminaController.isSprinting = true;
                staminaController.Sprinting(); ;
                staminaController.UpdateStamina(1);
                currSpeed = 10f;
            }
            else if (staminaController.playerStamina <= 5f)
            {
                sprint = false;
                staminaController.isSprinting = false;
                staminaController.UpdateStamina(0);
                currSpeed = 5f;
            }
        }
        else
        {
            staminaController.isSprinting = false;
            staminaController.UpdateStamina(0);
            currSpeed = 5f;
        }

        Vector3 moveDir = Vector3.forward * vert + Vector3.right * horiz;

        if (moveDir.magnitude > 0.1f)
        {
            Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
                    Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);



                    moveDir = rotationToCamera * moveDir;
                    Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDir, Vector3.up);

                    // transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToCamera, rotSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection, rotSpeed * Time.deltaTime);

                    transform.position += moveDir * currSpeed * Time.deltaTime;
        }
    }

    public void OnSprint()
    {
        sprint = !sprint;
    }
    public void OnMoveInput(float horiz, float vert)
    {
        this.vert = vert;
        this.horiz = horiz;

    }

    public void OnShoot()
    {
        //RaycastHit hit;
        if(playerAmmo != 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletObj, barrel.position, Quaternion.identity); 
            BulletController bulletController = bullet.GetComponent<BulletController>();
            //GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletController.speed;
            playerAmmo -= 1;
        }

        /*
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = Camera.main.transform.position + Camera.main.transform.forward * 25f;
            bulletController.hit = false;
        }
        */
    }
    public void TakeDamage()
    {
        if(playerHealth <= 0)
        {
            IsDead = true;
        }
        else
        {
            playerHealth -=5;
            hud.DisplayplayerHealth();
        }

    }

    public void Respawn()
    {
        IsDead = false;
        transform.position = RespawnPoint.transform.position;
        playerHealth = 100;
        //rb.isKinematic = false;
        //gm.loseGold(10);
        hud.DisplayDisableDeath();
    }

    public void AddGear()
    {
        Gear += 1;
    }
    public void UnlockDoor()
    {
        RedKey = true;
    }

    public void AddAmmo(int AmmoValue)
    {
        playerAmmo += AmmoValue;
    }

    public void UseItem()
    {
        //update ui for inventory
        if(Gear != 0)
        {
            Gear -= 1;
            hud.DisplayGears();
        }
        else
        {
            //print error message
        }
    }
}
