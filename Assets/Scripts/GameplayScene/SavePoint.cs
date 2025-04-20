using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private bool isPlayerInRange = false;
    [SerializeField] private KeyCode saveKey = KeyCode.E;

    CameraManager cameraManager;

    private void Start()
    {
    
        cameraManager = FindAnyObjectByType<CameraManager>();
        
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(saveKey))
        {
            RespawnManager.Instance.UpdateCheckpoint(transform.position);
            Debug.Log("�Z�[�u���܂����I");
            // �G�t�F�N�g�ESE�EUI�\���Ƃ������ł��
            CameraIndexSet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void CameraIndexSet()
    {
        cameraManager.setIndex();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}