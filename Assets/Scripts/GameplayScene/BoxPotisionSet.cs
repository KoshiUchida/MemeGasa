using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPotisionSet : MonoBehaviour
{
    int cameraIndex = 0;
    bool isTransitioning = false; // 移動中かどうかのフラグ
    float transitionCooldown = 0.0f; // 連続移動防止用のクールダウン時間

    BoxPushController pushController;

    Rigidbody2D rb;
    Transform playertransform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playertransform = this.transform;
        pushController = GetComponent<BoxPushController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTransitioning) return;

        string tagName = other.tag;

        Vector3 playerpos = playertransform.position;

        if (tagName == "Right" && rb.velocity.x > 0.01f)
        {
            playerpos.x += 0.3f;
            rb.AddForceX(140.0f);
            playertransform.position = playerpos;
        }
        else if (tagName == "Left" && rb.velocity.x < -0.01f)
        {
            rb.AddForceX(-140.0f);
            playerpos.x -= 0.3f;
            playertransform.position = playerpos;
        }
    }

    void ResetTransition()
    {
        isTransitioning = false;
    }
}
