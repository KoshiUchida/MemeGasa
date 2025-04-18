using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour, IResettable
{
    private Vector3 checkpointPosition;
    public Transform Reset;

    private List<IResettable> resetObjects = new List<IResettable>();

    private void Start()
    {
        checkpointPosition = Reset.position; // ‰ŠúˆÊ’u‚ğ‹L˜^
    }

    public void ResetState()
    {
        Reset.position = checkpointPosition;
    }

}
