using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour, IResettable
{
    private Vector3 checkpointPosition;
    private Transform Reset;

    private void Start()
    {
        Reset = this.transform;
        checkpointPosition = Reset.position; // 初期位置を記録
        RespawnManager.Instance.RegisterResettable(this);
    }

    public void ResetState()
    {
        Reset.position = checkpointPosition;
    }

}
