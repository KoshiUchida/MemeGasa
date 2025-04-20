using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFeller : MonoBehaviour�@, IResettable
{
    public GameObject standingVisual;   // �؂̌����ڂ���
    public GameObject treeCollider;     // �����蔻��i�R���C�_�[�����̃I�u�W�F�N�g�j
    public GameObject stump;
    public GameObject fallenTree;

    public bool isFelled = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {

        RespawnManager.Instance.RegisterResettable(this);

        // �����ʒu�Ɖ�]��ۑ��i�����Ă�؂̈ʒu����Ɂj
        initialPosition = fallenTree.transform.position;
        initialRotation = fallenTree.transform.rotation;

        // �ŏ��͗����Ă�؂����\��
        stump.SetActive(false);
        fallenTree.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isFelled && other.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            FellTree();
        }
    }

    void FellTree()
    {
        isFelled = true;

        // �؂̌����ڂƃR���C�_�[�𖳌����i���ʂ��悤�ɂȂ�j
        standingVisual.SetActive(false);
        treeCollider.SetActive(false);

        // �؂芔�Ɠ|�؂�\��
        stump.SetActive(true);
        fallenTree.SetActive(true);
    }

    public void ResetState()
    {
        isFelled = false;

        treeCollider.SetActive(true);
        standingVisual.SetActive(true);
        stump.SetActive(false);
        fallenTree.SetActive(false);

        // �����ʒu�Ɖ�]�ɖ߂�
        fallenTree.transform.position = initialPosition;
        fallenTree.transform.rotation = initialRotation;

        // Rigidbody2D ��Ԃ����Z�b�g
        Rigidbody2D rb = fallenTree.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
