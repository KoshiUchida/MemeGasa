using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderContollor : MonoBehaviour
{
    public Transform teleportTarget; // 上に飛ぶ先（エンプティ）

    private bool canClimb = false;

    void Update()
    {
        // 上に登るキー（例：↑キー or W）を押したら
        if (canClimb && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        // プレイヤーの位置をターゲットに変更
        Transform player = GameObject.FindWithTag("Player").transform;
        player.position = teleportTarget.position;

        // オプション：演出やSE、ちょっと暗くする等ここに入れる
    }

    // プレイヤーがはしごの判定に入ったとき
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb = false;
        }
    }
}
