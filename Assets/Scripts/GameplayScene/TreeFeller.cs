using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFeller : MonoBehaviour
{
    public GameObject standingVisual;   // 木の見た目だけ
    public GameObject treeCollider;     // 当たり判定（コライダーだけのオブジェクト）
    public GameObject stump;
    public GameObject fallenTree;

    public bool isFelled = false;

    void Start()
    {
        // 最初は立ってる木だけ表示
        stump.SetActive(false);
        fallenTree.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isFelled && other.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            FellTree();
        }
    }

    void FellTree()
    {
        isFelled = true;

        // 木の見た目とコライダーを無効化（＝通れるようになる）
        standingVisual.SetActive(false);
        treeCollider.SetActive(false);

        // 切り株と倒木を表示
        stump.SetActive(true);
        fallenTree.SetActive(true);
    }
}
