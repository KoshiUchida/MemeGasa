using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    private bool isDead = false;
    private void Update()
    {
        // テスト用：Kキーで即死
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

       // animator.SetTrigger("Die"); // 死亡アニメーション再生
        StartCoroutine(WaitAndFadeOut());
    }

    private IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(0f); // アニメ長さに応じて調整
        FadeManager.Instance.FadeOutAndRespawn();
    }

    public void Revive()
    {
        isDead = false;
        // HPやステータス初期化したい場合はここで
    }
}
