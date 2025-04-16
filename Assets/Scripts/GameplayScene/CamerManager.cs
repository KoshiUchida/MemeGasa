using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{

    int cameraindex = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Camera cam = Camera.main;

        // other �́u�G�ꂽ�����Collider2D�v
        string tagName = other.tag;

        if (tagName == "Left")
        {
            cameraindex--; //Camera�̃C���f�b�N�X���������
        }
        else if (tagName == "Right")
        {
            cameraindex++; //Camera�̃C���f�b�N�X����グ��
        }

        // ���݂̈ʒu���擾
        Vector3 pos = cam.transform.position;

        // x �� y �̍��W�ɔ{���������ĐV�����ʒu���v�Z
        Vector3 newPos = new Vector3(cameraindex * 6, pos.y, pos.z); // y��z �͂��̂܂�

        // �J�����̈ʒu���X�V
        cam.transform.position = newPos;
    }
}