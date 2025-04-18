using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource; // 音源
    public Transform player; // プレイヤーのTransform
    public float maxDistance = 10f; // 最大距離
    public float minVolume = 0f; // 最小音量
    public float maxVolume = 1f; // 最大音量

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySound();
    }

    //サウンド
    private void EnemySound()
    {
        if (player != null && audioSource != null)
        {
            //敵とプレイヤーの距離を計算
            float distance = Vector3.Distance(transform.position, player.position);

            //音量を計算
            float volume = Mathf.Clamp01(1 - (distance / maxDistance));
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, volume);
        }
    }
}
