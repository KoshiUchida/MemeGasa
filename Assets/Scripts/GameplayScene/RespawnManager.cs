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
        checkpointPosition = player.position; // 初期位置を記録
    }

    public void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
        Debug.Log("チェックポイント更新: " + newCheckpoint);
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
