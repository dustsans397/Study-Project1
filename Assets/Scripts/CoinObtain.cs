using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinObtain : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<PlayerAttribute>().coinNum++;
            Destroy(gameObject);
        }
    }
}
