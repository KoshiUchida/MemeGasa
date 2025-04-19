using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContoroller : MonoBehaviour
{
    //物理
    private Rigidbody2D rb;
    
    //移動関係
    private float RunSpeed = 1.5f;

    public enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    public MOVE_TYPE move = MOVE_TYPE.STOP;//初期状態は停止させる

    //傘
    public GameObject umbrella;
    int umbrellaDurability = 0;

    //サウンド
    public AudioSource audioSource;
    public AudioClip walk;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Rigidbody2Dの取得
        rb = GetComponent<Rigidbody2D>();

        umbrella = GameObject.Find("Umbrella(1)_0");

        //耐久の初期化
        umbrellaDurability = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        umbrellaDurability = umbrella.GetComponent<UmbrellaController>().GetDurability();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//回転を固定

        //ダッシュ準備
        DashPreparation();

        if (umbrellaDurability > 0)
        {
            //防御
            Guard();
        }
        else
        {
            this.tag = "Player";
        }
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
            audioSource.Stop();
        }
        else if (move == MOVE_TYPE.RIGHT)
        {
            scale.x = 1; // 右向き
            RunSpeed = 1.5f;
            audioSource.Play();

        }
        else if (move == MOVE_TYPE.LEFT)
        {
            scale.x = -1; // 左向き
            RunSpeed = -1.5f;
            audioSource.Play();

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
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Player";
            rb.constraints = RigidbodyConstraints2D.None;//X軸固定を解除
        }
    }
}
