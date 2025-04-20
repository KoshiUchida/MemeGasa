using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{

    public void OnGoal()
    {
        //ゴールした時の処理をここに記述
        Debug.Log($"ゴールしました");

        SceneManager.LoadScene("SelectScene");
 

    }

}

