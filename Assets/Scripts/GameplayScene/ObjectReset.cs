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
        checkpointPosition = Reset.position; // ‰ŠúˆÊ’u‚ğ‹L˜^
        RespawnManager.Instance.RegisterResettable(this);
    }

    public void ResetState()
    {
        Reset.position = checkpointPosition;
    }

}
