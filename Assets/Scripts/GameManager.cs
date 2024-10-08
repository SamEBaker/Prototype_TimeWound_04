using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int TotalGold = 0;

    public void loseGold(int amount)
    {
        TotalGold -= amount;
    }


    public void AddGold(int gold)
    {
        TotalGold += gold;
    }

}
