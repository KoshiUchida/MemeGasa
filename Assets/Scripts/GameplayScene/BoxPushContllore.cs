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

        // ���E�E�ɖؔ������邩����
        Collider2D leftBox = Physics2D.OverlapCircle(leftCheck.position, checkRadius, boxLayer);
        Collider2D rightBox = Physics2D.OverlapCircle(rightCheck.position, checkRadius, boxLayer);

        // �ؔ��Ƃ̏Փ˂�؂�ւ�
        if (leftBox != null && rightBox == null)
        {
            //�����ɂ���Ƃ��̏���
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), leftBox, !pressingUp);
        }

        if (rightBox != null && leftBox == null)
        {
            //�E���ɂ���Ƃ��̏���
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), rightBox, !pressingUp);
        }

        if(rightBox == null && leftBox == null)
        {
            // �ؔ����߂��ɂȂ��ꍇ �� ���ׂĂ̖ؔ��Ƃ̏Փ˂�ON�ɖ߂�
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
        //// ���E�E�ɖؔ������邩����
        //Collider2D leftBox = Physics2D.OverlapCircle(leftCheck.position, checkRadius, boxLayer);
        //Collider2D rightBox = Physics2D.OverlapCircle(rightCheck.position, checkRadius, boxLayer);

        //// �ؔ��Ƃ̏Փ˂�؂�ւ�
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
