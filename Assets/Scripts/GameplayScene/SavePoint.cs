using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private KeyCode saveKey = KeyCode.E;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(saveKey))
        {
            RespawnManager.Instance.UpdateCheckpoint(transform.position);
            Debug.Log("�Z�[�u���܂����I");
            // �G�t�F�N�g�ESE�EUI�\���Ƃ������ł��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}