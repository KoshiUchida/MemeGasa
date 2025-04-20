using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeController : MonoBehaviour, IResettable
{
    public GameObject player;
    public GameObject umbrella;

    private bool umbrellaDestroy = false;
    private bool isAttackActive = false;
    private float effectDuration = 2f; // 2ïbä‘óLå¯
    private float timer = 0f;

    AudioSource audioSource;
    public AudioClip attack;

    public DeadManager deadManager;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        umbrellaDestroy = false;
        player = GameObject.Find("Player");
        umbrella = GameObject.Find("Umbrella(1)_0");

        deadManager = FindAnyObjectByType<DeadManager>();

        RespawnManager.Instance.RegisterResettable(this);

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
        if (umbrella.tag == "Guard")
        {
            umbrella.GetComponent<UmbrellaController>().TakeDamage();
        }
        isAttackActive = false;
        umbrellaDestroy = false;
    }

    private void OnAttack()
    {
        if (player.tag == "Player")
        {
            Debug.Log("çUåÇÇ…ìñÇΩÇ¡ÇΩ");
            deadManager.Die();
        }
        //if (umbrella.tag == "Guard")
        //{
        //    if (!umbrellaDestroy)
        //    {
        //        umbrella.GetComponent<UmbrellaController>().TakeDamage();
        //        umbrellaDestroy = true;
        //    }
        //}
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(attack);   
    }

    public void ResetState()
    {
        umbrellaDestroy = false;
        isAttackActive = false;
        timer = 0f;
        umbrella.GetComponent<UmbrellaController>().Reset();

        animator.Play("EnemyEyeAnimation", 0, 0);
    }
}
