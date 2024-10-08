using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Pad : MonoBehaviour
{
    public int Mykey;
    public bool PressedDown;
    public PressurePlateManager pm;
    public MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr.material.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().PadKey == Mykey)
            {
                Debug.Log("I am pressed");
                PressedDown = true;
                mr.material.color = Color.blue;
                pm.Addpressed();
            }

        }
        else if(other.gameObject.tag == "Block")
        {
            if(other.gameObject.GetComponent<ItemBehavior>().BlockKey == Mykey)
            {
                Debug.Log("I am pressed");
                PressedDown = true;
                mr.material.color = Color.blue;
                pm.Addpressed();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(PressedDown == false)
        {
            Debug.Log("I am not pushed");
        }
        else{
            Debug.Log("I am Upressed");
            PressedDown = false;
            mr.material.color = Color.green;
            pm.Removepressed();
        }

    }
}
