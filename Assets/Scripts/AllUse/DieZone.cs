using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // プレイヤーが死ぬ処理をここに追加
            Debug.Log("Player has died!");

            other.gameObject.GetComponent<DeadManager>().Die();
        }
    }
}
