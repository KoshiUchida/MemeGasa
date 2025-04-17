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

        // ¶E‰E‚É–Ø” ‚ª‚ ‚é‚©”»’è
        Collider2D leftBox = Physics2D.OverlapCircle(leftCheck.position, checkRadius, boxLayer);
        Collider2D rightBox = Physics2D.OverlapCircle(rightCheck.position, checkRadius, boxLayer);

        // –Ø” ‚Æ‚ÌÕ“Ë‚ğØ‚è‘Ö‚¦
        if (leftBox != null)
        {
            //¶‘¤‚É‚ ‚é‚Æ‚«‚Ìˆ—
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), leftBox, !pressingUp);
        }

        if (rightBox != null)
        {
            //‰E‘¤‚É‚ ‚é‚Æ‚«‚Ìˆ—
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), rightBox, !pressingUp);
        }

        if(rightBox == null && leftBox == null)
        {
            // –Ø” ‚ª‹ß‚­‚É‚È‚¢ê‡ ¨ ‚·‚×‚Ä‚Ì–Ø” ‚Æ‚ÌÕ“Ë‚ğON‚É–ß‚·
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
}
