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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    //移動
    private void Move()
    {
        //プレイヤーの方向を決めるためにスケールの切り出し
        Vector3 scale = transform.localScale;
        if (move == MOVE_TYPE.STOP)
        { speed = 0; }
        else if (move == MOVE_TYPE.RIGHT)
        {
            scale.x = 1;//右向き
            speed = 0.5f;
        }
        else if (move == MOVE_TYPE.LEFT)
        {
            scale.x = -1;
            speed = -0.5f;
        }
        transform.localScale = scale;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
