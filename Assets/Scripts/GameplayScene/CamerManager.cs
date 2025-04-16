using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{

    int cameraindex = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera cam = Camera.main;

        // other は「触れた相手のCollider2D」
        string tagName = other.tag;

        if (tagName == "Left")
        {
            cameraindex--; //Cameraのインデックスを一つ下げる
        }
        else if (tagName == "Right")
        {
            cameraindex++; //Cameraのインデックスを一つ上げる
        }

        // 現在の位置を取得
        Vector3 pos = cam.transform.position;

        // x と y の座標に倍率をかけて新しい位置を計算
        Vector3 newPos = new Vector3(cameraindex * 6, pos.y, pos.z); // yとz はそのまま

        // カメラの位置を更新
        cam.transform.position = newPos;
    }
}