using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    //����
    private Rigidbody2D rb;

    //�ړ��֌W
    private float RunSpeed = 3.0f;

    public enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    public MOVE_TYPE move = MOVE_TYPE.STOP;//������Ԃ͒�~������

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D�̎擾
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//��]���Œ�

        //�_�b�V������
        DashPreparation();

        //�h��
        Guard();
    }

    private void FixedUpdate()
    {
        //�_�b�V��
        Dash();
    }

    //�_�b�V������
    private void DashPreparation()
    {
        //���E�̈ړ����͂��擾(��,���AA,D)
        float horizonKey = Input.GetAxis("Horizontal");

        //�擾�������������̃L�[�����ɕ���
        if (horizonKey == 0)
        {
            //�L�[���͂Ȃ��̏ꍇ�͒�~
            move = MOVE_TYPE.STOP;
        }
        else if (horizonKey > 0)
        {
            //�L�[���͂����̏ꍇ�͉E�ֈړ�����
            move = MOVE_TYPE.RIGHT;
        }
        else if (horizonKey < 0)
        {
            //�L�[���͂����̏ꍇ�͍��ֈړ�����
            move = MOVE_TYPE.LEFT;
        }
    }

    //�_�b�V��
    private void Dash()
    {
        // Player�̕��������߂邽�߂ɃX�P�[���̎��o��
        Vector3 scale = transform.localScale;
        if (move == MOVE_TYPE.STOP)
        {
            RunSpeed = 0;

        }
        else if (move == MOVE_TYPE.RIGHT)
        {
            scale.x = 1; // �E����
            RunSpeed = 3;

        }
        else if (move == MOVE_TYPE.LEFT)
        {
            scale.x = -1; // ������
            RunSpeed = -3;

        }
        transform.localScale = scale; // scale����
                                      // rigidbody2D��velocity(���x)�֎擾����RunSpeed������By�����͓����Ȃ��̂ł��̂܂܂ɂ���

        rb.velocity = new Vector2(RunSpeed, rb.velocity.y);
    }

    //�h��
    private void Guard()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.tag = "Guard";
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;//X�����Œ�
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Player";
            rb.constraints = RigidbodyConstraints2D.None;//X���Œ������
        }
    }

    //�ǉ��_
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("�_���[�W���󂯂�!HP" + health);
    }

}
