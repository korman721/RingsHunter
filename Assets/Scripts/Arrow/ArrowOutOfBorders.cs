using UnityEngine;

public class ArrowOutOfBorders : MonoBehaviour
{
    private void Update()
    {
        DetectOutOfBorders();
    }
    private void DetectOutOfBorders()
    {
        if (transform.position.y >= 10f || transform.position.y <= -7f || transform.position.x >= 5f || transform.position.x <= -5f)
        {
            Destroy(gameObject);
        }
    }
}
