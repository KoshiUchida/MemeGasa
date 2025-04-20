using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // ƒvƒŒƒCƒ„[‚ª€‚Êˆ—‚ğ‚±‚±‚É’Ç‰Á
            Debug.Log("Player has died!");

            other.gameObject.GetComponent<DeadManager>().Die();
        }
    }
}
