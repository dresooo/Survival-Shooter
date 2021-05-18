using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public PlayerHealth PlayerHealth;
    public float SpeedTime;
    private float timer;
    private bool PowerON;
    private float firstspeed;
    public Text TimerText;
    public void HealPlayer()
    {
        if (PlayerHealth.currentHealth < PlayerHealth.startingHealth)
        {
            PlayerHealth.currentHealth += 20;
            PlayerHealth.healthSlider.value = PlayerHealth.currentHealth;
        }
    }
    public void AddSpeed()
    {
        if (PowerON == false)
        {
            PowerON = true;
            PlayerMovement.speed += 6f;
        }
    }
    private void Update()
    {
        if (PowerON == true)
        {
            TimerText.gameObject.SetActive(true);
            timer -= Time.deltaTime;
        }
        if (PowerON == false)
        {
            TimerText.gameObject.SetActive(false);
            PlayerMovement.speed = firstspeed;
            timer = SpeedTime;
        }
        TimerText.text = ((int)timer).ToString();

        if (timer <= 0)
        {
            PowerON = false;
        }
    }

    private void Start()
    {
        firstspeed = PlayerMovement.speed;
    }
}