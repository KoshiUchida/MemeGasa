using UnityEditor.EditorTools;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�v���C���[�̃^�O��Player��ݒ肵�Ȃ��Ɠ����܂���
        if (other.CompareTag("Player")) // �v���C���[���S�[���n�_�ɓ��B�����ꍇ
        {
            // GoalManager��OnGoal���Ăяo��
            GoalManager goalManager = FindObjectOfType<GoalManager>();
            if (goalManager != null)
            {
                goalManager.OnGoal();
            }
        }
    }
}
