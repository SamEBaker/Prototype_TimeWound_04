using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#:~:text=Making%20a%20countdown%20timer%20in%20Unity%20involves%20storing%20a%20float#:~:text=Making%20a%20countdown%20timer%20in%20Unity%20involves%20storing%20a%20float
public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public float TimePickupValue;
    public bool IsRunning;
    public TMP_Text timerText;
    public HUDManager hud;
    public Player player;
    public int GearsRecieved;

    void Start()
    {
        IsRunning = true;
    }
    void Update()
    {
        if (IsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Displaytime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                IsRunning = false;
                //gameover
            }
        }
        else
        {
            hud.SetLoseScreen();

        }

        
    }
    void Displaytime(float timeDisplay)
    {
        timeDisplay += 1;
        float min = Mathf.FloorToInt(timeDisplay / 60);
        float sec = Mathf.FloorToInt(timeDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void AddTime()
    {
        //player.Gear -=1;
        //hud.UpdatePopUpText("You added time");
        if(player.Gear != 0)
        {
            timeRemaining += TimePickupValue;
            GearsRecieved += 1;

            player.UseItem();
        }

        //Displaytime(timeRemaining);
    }
}
