using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource; // ����
    public Transform player; // �v���C���[��Transform
    public float maxDistance = 10f; // �ő勗��
    public float minVolume = 0f; // �ŏ�����
    public float maxVolume = 1f; // �ő剹��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySound();
    }

    //�T�E���h
    private void EnemySound()
    {
        if (player != null && audioSource != null)
        {
            //�G�ƃv���C���[�̋������v�Z
            float distance = Vector3.Distance(transform.position, player.position);

            //���ʂ��v�Z
            float volume = Mathf.Clamp01(1 - (distance / maxDistance));
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, volume);
        }
    }
}
