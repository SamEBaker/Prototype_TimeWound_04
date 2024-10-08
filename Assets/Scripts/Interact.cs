using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//https://www.youtube.com/watch?v=cLzG1HDcM4s

public class Interact : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;

    public UnityEvent interactAction;
    public HUDManager hudManager;
    public string popUpMessage;
    PlayerControls pC;

    private void Awake()
    {
        pC = new PlayerControls();
    }
    void Update()
    {
        if (isInRange)
        {

            if (Input.GetKeyDown(interactKey) || (Input.GetButton("Fire1")))
           {
               interactAction.Invoke();
               hudManager.InteractPopDown();
           }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            hudManager.InteractPopUp(popUpMessage);
            Debug.Log("Press E to Interact");
        }
    }
    void OnTriggerExit(Collider collision)
    {
        isInRange = false;
        hudManager.InteractPopDown();

    }
}
