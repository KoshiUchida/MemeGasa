using UnityEditor.EditorTools;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーのタグにPlayerを設定しないと動きません
        if (other.CompareTag("Player")) // プレイヤーがゴール地点に到達した場合
        {
            // GoalManagerのOnGoalを呼び出す
            GoalManager goalManager = FindObjectOfType<GoalManager>();
            if (goalManager != null)
            {
                goalManager.OnGoal();
            }
        }
    }
}
