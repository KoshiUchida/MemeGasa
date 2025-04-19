using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFeller : MonoBehaviour
{
    public GameObject standingVisual;   // �؂̌����ڂ���
    public GameObject treeCollider;     // �����蔻��i�R���C�_�[�����̃I�u�W�F�N�g�j
    public GameObject stump;
    public GameObject fallenTree;

    public bool isFelled = false;

    void Start()
    {
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
}
