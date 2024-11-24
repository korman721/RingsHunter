using UnityEngine;

public class DetectOfExit : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] boxes = new BoxCollider2D[3];

    void Update()
    {
        DetectExit();
    }

    private void DetectExit()
    {
        if (Mathf.Abs(transform.position.x) <= 4f)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].enabled = true;
            }
        }
        if (Mathf.Abs(transform.position.x) >= 4f)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].enabled = false;
            }
        }
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
