using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderContollor : MonoBehaviour
{
    public Transform teleportTarget; // ��ɔ�Ԑ�i�G���v�e�B�j

    private bool canClimb = false;

    void Update()
    {
        // ��ɓo��L�[�i��F���L�[ or W�j����������
        if (canClimb && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        // �v���C���[�̈ʒu���^�[�Q�b�g�ɕύX
        Transform player = GameObject.FindWithTag("Player").transform;
        player.position = teleportTarget.position;

        // �I�v�V�����F���o��SE�A������ƈÂ����铙�����ɓ����
    }

    // �v���C���[���͂����̔���ɓ������Ƃ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb = false;
        }
    }
}
