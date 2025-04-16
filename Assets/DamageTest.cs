using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    //攻撃否、攻撃の間隔、タイマー
    public bool isAttak = false;
    public float AttakInv = 3;
    private float timer;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        timer = AttakInv;

        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 )
        {
            Attak();
            timer = AttakInv;
        }

    }

    void Attak()
    {
        isAttak = true;


        if (Player != null && Player.tag != "Guaed")
        {
            Damage receiver = Player.GetComponent<Damage>();
            if (receiver != null)
            {
                receiver.TakeDamage(10);
            }
        }

        isAttak = false;

    }

}
