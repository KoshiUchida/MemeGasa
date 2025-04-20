using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    private bool isDead = false;
    private void Update()
    {
        // �e�X�g�p�FK�L�[�ő���
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

       // animator.SetTrigger("Die"); // ���S�A�j���[�V�����Đ�
        StartCoroutine(WaitAndFadeOut());
    }

    private IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(0f); // �A�j�������ɉ����Ē���
        FadeManager.Instance.FadeOutAndRespawn();
    }

    public void Revive()
    {
        isDead = false;
        // HP��X�e�[�^�X�������������ꍇ�͂�����
    }
}
