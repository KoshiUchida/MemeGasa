using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    private Vector3 checkpointPosition;
    public Transform player;

    private List<IResettable> resetObjects = new List<IResettable>();
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        checkpointPosition = player.position; // �����ʒu���L�^
    }

    public void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
        Debug.Log("�`�F�b�N�|�C���g�X�V: " + newCheckpoint);
    }

    public void RespawnPlayer()
    {
        player.position = checkpointPosition;
    }

    public void ResetAll()
    {
        foreach (var obj in resetObjects)
        {
            obj.ResetState();
        }
    }
}
