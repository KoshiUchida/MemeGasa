using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFeller : MonoBehaviour　, IResettable
{
    public GameObject standingVisual;   // 木の見た目だけ
    public GameObject treeCollider;     // 当たり判定（コライダーだけのオブジェクト）
    public GameObject stump;
    public GameObject fallenTree;

    public bool isFelled = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {

        RespawnManager.Instance.RegisterResettable(this);

        // 初期位置と回転を保存（立ってる木の位置を基準に）
        initialPosition = fallenTree.transform.position;
        initialRotation = fallenTree.transform.rotation;

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

    public void ResetState()
    {
        isFelled = false;

        treeCollider.SetActive(true);
        standingVisual.SetActive(true);
        stump.SetActive(false);
        fallenTree.SetActive(false);

        // 初期位置と回転に戻す
        fallenTree.transform.position = initialPosition;
        fallenTree.transform.rotation = initialRotation;

        // Rigidbody2D 状態もリセット
        Rigidbody2D rb = fallenTree.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
