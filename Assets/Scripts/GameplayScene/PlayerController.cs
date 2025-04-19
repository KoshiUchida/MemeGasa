using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContoroller : MonoBehaviour
{
    //����
    private Rigidbody2D rb;
    
    //�ړ��֌W
    private float RunSpeed = 1.5f;

    public enum MOVE_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    public MOVE_TYPE move = MOVE_TYPE.STOP;//������Ԃ͒�~������

    //�P
    public GameObject umbrella;
    int umbrellaDurability = 0;

    //�T�E���h
    public AudioSource audioSource;
    public AudioClip walk;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Rigidbody2D�̎擾
        rb = GetComponent<Rigidbody2D>();

        umbrella = GameObject.Find("Umbrella(1)_0");

        //�ϋv�̏�����
        umbrellaDurability = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        umbrellaDurability = umbrella.GetComponent<UmbrellaController>().GetDurability();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//��]���Œ�

        //�_�b�V������
        DashPreparation();

        if (umbrellaDurability > 0)
        {
            //�h��
            Guard();
        }
        else
        {
            this.tag = "Player";
        }
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
            audioSource.Stop();
        }
        else if (move == MOVE_TYPE.RIGHT)
        {
            scale.x = 1; // �E����
            RunSpeed = 1.5f;
            audioSource.Play();

        }
        else if (move == MOVE_TYPE.LEFT)
        {
            scale.x = -1; // ������
            RunSpeed = -1.5f;
            audioSource.Play();

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
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.tag = "Player";
            rb.constraints = RigidbodyConstraints2D.None;//X���Œ������
        }
    }
}
