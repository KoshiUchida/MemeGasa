using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour , IResettable
{
    public static CameraManager Instance;

    int cameraIndex = 0;
    bool isTransitioning = false; // 移動中かどうかのフラグ
    float transitionCooldown = 0.0f; // 連続移動防止用のクールダウン時間

    int saveindex = 0;

    BoxPushController pushController;

    Rigidbody2D rb;
    Transform playertransform;
    void Start()
    {
        RespawnManager.Instance.RegisterResettable(this);

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
            cameraIndex++;
            MoveCamera();
            playerpos.x += 1.2f;
            playertransform.position = playerpos;
        }
        else if (tagName == "Left" && rb.velocity.x < -0.01f)
        {
            cameraIndex--;
            MoveCamera();
            playerpos.x -= 1.2f;
            playertransform.position = playerpos;
        }
    }

    void MoveCamera()
    {
        Camera cam = Camera.main;
        Vector3 pos = cam.transform.position;
        Vector3 newPos = new Vector3(cameraIndex * 18f, pos.y, pos.z);

        cam.transform.position = newPos;

        // クールダウン開始
        isTransitioning = true;
        Invoke("ResetTransition", transitionCooldown);
    }

    void ResetTransition()
    {
        isTransitioning = false;
    }

    public int GetIndex()
    {
        return cameraIndex;
    }

    public void setIndex()
    {
        saveindex = cameraIndex;
    }

    public void ResetState()
    {
        cameraIndex = saveindex;
        MoveCamera();
    }
}
