using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttribute : MonoBehaviour
{
    public int coinNum=0;

    public int level=1;

    public int maxhealth = 5;

    public int currentHealth;

    public float invincibleTime = 3f;
    public float invincibleTimer = 3f;

    public bool isInvincible = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 5;
    }

    // Update is called once per frame
    void Update() 
    {
        if (isInvincible)
        {
            invincibleTimer-= Time.deltaTime;
            if (invincibleTimer< 0)
            {
                isInvincible = false;
                invincibleTimer = 3f;
            }
        }
    }

    public void ChangeHealth(int healnum)
    {
        if (healnum < 0)
        {
            if (isInvincible == true)
            {
                healnum = 0;
            }
            currentHealth += healnum;
            isInvincible = true;
        }
    }
}
