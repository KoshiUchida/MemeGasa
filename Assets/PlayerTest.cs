using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    //物理
    private Rigidbody2D rb;

    //移動関係
    private float RunSpeed = 3.0f;

    public enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    public MOVE_TYPE move = MOVE_TYPE.STOP;//初期状態は停止させる

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dの取得
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//回転を固定

        //ダッシュ準備
        DashPreparation();

        //防御
        Guard();
    }

    private void FixedUpdate()
    {
        //ダッシュ
        Dash();
    }

    //ダッシュ準備
    private void DashPreparation()
    {
        //左右の移動入力を取得(←,→、A,D)
        float horizonKey = Input.GetAxis("Horizontal");

        //取得した水平方向のキーを元に分岐
        if (horizonKey == 0)
        {
            //キー入力なしの場合は停止
            move = MOVE_TYPE.STOP;
        }
        else if (horizonKey > 0)
        {
            //キー入力が正の場合は右へ移動する
            move = MOVE_TYPE.RIGHT;
        }
        else if (horizonKey < 0)
        {
            //キー入力が負の場合は左へ移動する
            move = MOVE_TYPE.LEFT;
        }
    }

    //ダッシュ
    private void Dash()
    {
        // Playerの方向を決めるためにスケールの取り出し
        Vector3 scale = transform.localScale;
        if (move == MOVE_TYPE.STOP)
        {
            RunSpeed = 0;

        }
        else if (move == MOVE_TYPE.RIGHT)
        {
            scale.x = 1; // 右向き
            RunSpeed = 3;

        }
        else if (move == MOVE_TYPE.LEFT)
        {
            scale.x = -1; // 左向き
            RunSpeed = -3;

        }
        transform.localScale = scale; // scaleを代入
                                      // rigidbody2Dのvelocity(速度)へ取得したRunSpeedを入れる。y方向は動かないのでそのままにする

        rb.velocity = new Vector2(RunSpeed, rb.velocity.y);
    }

    //防御
    private void Guard()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.tag = "Guard";
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;//X軸を固定
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Player";
            rb.constraints = RigidbodyConstraints2D.None;//X軸固定を解除
        }
    }

    //追加点
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("ダメージを受けた!HP" + health);
    }

}
