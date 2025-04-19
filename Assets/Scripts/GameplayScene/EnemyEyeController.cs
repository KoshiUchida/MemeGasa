using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeController : MonoBehaviour
{
    public GameObject player;

    private bool isAttackActive = false;
    private float effectDuration = 2f; // 2ïbä‘óLå¯
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackActive)
        {
            OnAttack();
        }
        
    }

    public void StartAttack()
    {
        isAttackActive = true;
    }

    public void FinishAttack()
    {
        isAttackActive = false;
    }

    private void OnAttack()
    {
        if (player.tag == "Player")
        {
            Debug.Log("çUåÇÇ…ìñÇΩÇ¡ÇΩ");
        }
    }
}
