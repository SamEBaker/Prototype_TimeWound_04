using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBehavior : MonoBehaviour
{
    public Player player;
    public GameManager gm;
    public Timer time;
    public float timeValue;
    public int goldValue;
    public int BlockKey = 0;
    public int AmmoValue;

    public void PickUpGold()
    {
        Destroy(this.gameObject);
        gm.AddGold(goldValue);
        //hudManager.DisplayGold();
    }

    public void PickUpAmmo()
    {
        Destroy(this.gameObject);
        player.AddAmmo(AmmoValue);
        //hudManager.DisplayGold();
    }

    public void PickUpTime()
    {
        Destroy(this.gameObject);
        player.AddGear();
        //time.AddTime(timeValue);
        //update ui inventory
    }
    public void PickUpKey()
    {
        Destroy(this.gameObject);
        Debug.Log("You Picked this up!");
        player.UnlockDoor();
        //hudManager.SetKeyActive();
    }

}
