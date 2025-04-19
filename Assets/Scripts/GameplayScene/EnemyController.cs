using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    MOVE_TYPE move = MOVE_TYPE.RIGHT;//初期状態は左に移動
    Rigidbody2D rb;//Rigidbody2Dを定義
    float speed;

    public Transform player; // プレイヤーのTransform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動準備
        MovePreparation();
    }

    private void FixedUpdate()
    {
        //移動
        Move();
    }

    //移動準備
    private void MovePreparation()
    {
        if (player != null)
        {
            // 敵の現在の位置
            float enemyPositionX = transform.position.x;
            // プレイヤーの位置
            float playerPositionX = player.position.x;

            // プレイヤーを基準に左右の移動を決定
            if (enemyPositionX < playerPositionX)
            {
                // 敵がプレイヤーの左側にいる場合
                move = MOVE_TYPE.RIGHT; // 右に移動
            }
            else if (enemyPositionX > playerPositionX)
            {
                // 敵がプレイヤーの右側にいる場合
                move = MOVE_TYPE.LEFT; // 左に移動
            }
            else
            {
                // 敵とプレイヤーが同じX座標にいる場合は停止
                move = MOVE_TYPE.STOP;
            }
        }

    }

    //移動
    private void Move()
    {
        if (player != null)
        {
            //プレイヤーのY座標に合わせる
            Vector2 targetPosition = new Vector2(transform.position.x, player.position.y);

            // Y座標に向かう方向
            float directionY = targetPosition.y - transform.position.y;

            //プレイヤーの方向を決めるためにスケールの切り出し
            Vector3 scale = transform.localScale;


            if (move == MOVE_TYPE.STOP)
            { speed = 0; }
            else if (move == MOVE_TYPE.RIGHT)
            {
                scale.x = 0.7f;//右向き
                speed = 1.3f;
            }
            else if (move == MOVE_TYPE.LEFT)
            {
                scale.x = -0.7f;
                speed = -1.3f;
            }
            transform.localScale = scale;
            // Y軸の速度を計算
            float speedY = directionY > 0 ? 1f : -1f; // プレイヤーのYに移動する方向（1または-1）

            rb.velocity = new Vector2(speed, speedY);
        }
    }

}
