using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    MOVE_TYPE move = MOVE_TYPE.RIGHT;//������Ԃ͍��Ɉړ�
    Rigidbody2D rb;//Rigidbody2D���`
    float speed;

    public Transform player; // �v���C���[��Transform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        MovePreparation();
    }

    private void FixedUpdate()
    {
        //�ړ�
        Move();
    }

    //�ړ�����
    private void MovePreparation()
    {
        if (player != null)
        {
            // �G�̌��݂̈ʒu
            float enemyPositionX = transform.position.x;
            // �v���C���[�̈ʒu
            float playerPositionX = player.position.x;

            // �v���C���[����ɍ��E�̈ړ�������
            if (enemyPositionX < playerPositionX)
            {
                // �G���v���C���[�̍����ɂ���ꍇ
                move = MOVE_TYPE.RIGHT; // �E�Ɉړ�
            }
            else if (enemyPositionX > playerPositionX)
            {
                // �G���v���C���[�̉E���ɂ���ꍇ
                move = MOVE_TYPE.LEFT; // ���Ɉړ�
            }
            else
            {
                // �G�ƃv���C���[������X���W�ɂ���ꍇ�͒�~
                move = MOVE_TYPE.STOP;
            }
        }

    }

    //�ړ�
    private void Move()
    {
        if (player != null)
        {
            //�v���C���[��Y���W�ɍ��킹��
            Vector2 targetPosition = new Vector2(transform.position.x, player.position.y);

            // Y���W�Ɍ���������
            float directionY = targetPosition.y - transform.position.y;

            //�v���C���[�̕��������߂邽�߂ɃX�P�[���̐؂�o��
            Vector3 scale = transform.localScale;


            if (move == MOVE_TYPE.STOP)
            { speed = 0; }
            else if (move == MOVE_TYPE.RIGHT)
            {
                scale.x = 0.7f;//�E����
                speed = 1.3f;
            }
            else if (move == MOVE_TYPE.LEFT)
            {
                scale.x = -0.7f;
                speed = -1.3f;
            }
            transform.localScale = scale;
            // Y���̑��x���v�Z
            float speedY = directionY > 0 ? 1f : -1f; // �v���C���[��Y�Ɉړ���������i1�܂���-1�j

            rb.velocity = new Vector2(speed, speedY);
        }
    }

}
