using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource audioSource; // ΉΉ
    public Transform player; // vC[ΜTransform
    public float maxDistance = 10f; // Εε£
    public float minVolume = 0f; // Ε¬ΉΚ
    public float maxVolume = 1f; // ΕεΉΚ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySound();
    }

    //TEh
    private void EnemySound()
    {
        if (player != null && audioSource != null)
        {
            //GΖvC[Μ£πvZ
            float distance = Vector3.Distance(transform.position, player.position);

            //ΉΚπvZ
            float volume = Mathf.Clamp01(1 - (distance / maxDistance));
            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, volume);
        }
    }
}
