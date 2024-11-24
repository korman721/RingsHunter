using UnityEngine;

public class ArrowDetectRings : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rings"))
        {
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rings"))
        {
            GameManager.Instance.ManageBestScore();
            GameManager.Instance.EndGame();
        }
    }
}
