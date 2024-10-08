using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TMP_Text PopUp;
    public TMP_Text ErrorPop;
    public TMP_Text Gold;
    public TMP_Text Ammo;
    public GameManager gm;
    public GameObject keyUI;
    public GameObject loseScreen;
    public TMP_Text UpdateText;
    public TMP_Text Gears;
    public TMP_Text PHealth;
    public Player player;
    public GameObject DeathScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisplayplayerHealth();
    }

    public void SetKeyActive()
    {
        keyUI.SetActive(true);
        //set key false when used
    }
    public void SetKeyOff()
    {
        keyUI.SetActive(false);
    }

    public void SetLoseScreen()
    {
        loseScreen.SetActive(true);
    }
    public void InteractPopUp(string popUpMessage)
    {

        PopUp.text = popUpMessage; ;
    }
    public void InteractPopDown()
    {
        PopUp.text = "";
        //PopUp.SetActive (false);
    }

    public void ShowMessage(string message)
    {
        //StartCoroutine(QuickPopup(message));
        ErrorPop.text = message;
    }
    public void DropMessage()
    {
        ErrorPop.text = "";
    }

    public void DisplayGold()
    {
        Gold.text = "Gold: " + gm.TotalGold;
    }
    public void DisplayAmmo()
    {
        Ammo.text = "Ammo: " + player.playerAmmo;
    }
    public void DisplayGears()
    {
        Gears.text = "x" + player.Gear;
    }
   
    public void DisplayDeath()
    {
        DeathScreen.SetActive(true);
    }
    public void DisplayDisableDeath()
    {
        DeathScreen.SetActive(false);
    }
    public void DisplayplayerHealth()
    {
        PHealth.text = "Health: " + player.playerHealth;
    }
    IEnumerator QuickPopup(string message)
    {
        ShowMessage(message);
        yield return new WaitForSeconds(3f);
        DropMessage();
    }
}
