using UnityEngine;

public class BoxPushController : MonoBehaviour
{
    public LayerMask boxLayer;
    public float checkRadius = 0.1f;
    public Transform leftCheck;
    public Transform rightCheck;

    void Update()
    {
        bool pressingUp = Input.GetKey(KeyCode.UpArrow);

        // 左・右に木箱があるか判定
        Collider2D leftBox = Physics2D.OverlapCircle(leftCheck.position, checkRadius, boxLayer);
        Collider2D rightBox = Physics2D.OverlapCircle(rightCheck.position, checkRadius, boxLayer);

        // 木箱との衝突を切り替え
        if (leftBox != null && rightBox == null)
        {
            //左側にあるときの処理
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), leftBox, !pressingUp);
        }

        if (rightBox != null && leftBox == null)
        {
            //右側にあるときの処理
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), rightBox, !pressingUp);
        }

        if(rightBox == null && leftBox == null)
        {
            // 木箱が近くにない場合 → すべての木箱との衝突をONに戻す
            GameObject[] allBoxes = GameObject.FindGameObjectsWithTag("Box");
            foreach (GameObject box in allBoxes)
            {
                Collider2D boxCol = box.GetComponent<Collider2D>();
                if (boxCol != null)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), boxCol, false);
                }
            }
        }
    }

    public void BoxPotionSet()
    {
        //// 左・右に木箱があるか判定
        //Collider2D leftBox = Physics2D.OverlapCircle(leftCheck.position, checkRadius, boxLayer);
        //Collider2D rightBox = Physics2D.OverlapCircle(rightCheck.position, checkRadius, boxLayer);

        //// 木箱との衝突を切り替え
        //if (leftBox != null)
        //{
        //    Vector2 leftBoxPosition = leftBox.transform.position;
        //    leftBoxPosition.x -= 3f;

        //    leftBox.transform.position = leftBoxPosition;
        //}

        //if (rightBox != null)
        //{
        //    Vector2 rightBoxPosition = rightBox.transform.position;
        //    rightBoxPosition.x += 3f;

        //    rightBox.transform.position = rightBoxPosition;
        //}
    }
}
