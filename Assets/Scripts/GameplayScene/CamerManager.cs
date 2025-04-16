using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    int cameraIndex = 0;
    bool isTransitioning = false; // 移動中かどうかのフラグ
    float transitionCooldown = 0.3f; // 連続移動防止用のクールダウン時間

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTransitioning) return;

        string tagName = other.tag;

        if (tagName == "Right" && rb.velocity.x > 0.01f)
        {
            cameraIndex++;
            MoveCamera();
        }
        else if (tagName == "Left" && rb.velocity.x < -0.01f)
        {
            cameraIndex--;
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        Camera cam = Camera.main;
        Vector3 pos = cam.transform.position;
        Vector3 newPos = new Vector3(cameraIndex * 18, pos.y, pos.z);

        cam.transform.position = newPos;

        // クールダウン開始
        isTransitioning = true;
        Invoke("ResetTransition", transitionCooldown);
    }

    void ResetTransition()
    {
        isTransitioning = false;
    }
}
