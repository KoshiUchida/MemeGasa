using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{

    public void OnGoal()
    {
        //�S�[���������̏����������ɋL�q
        Debug.Log($"�S�[�����܂���");

        SceneManager.LoadScene("SelectScene");
 

    }

}

