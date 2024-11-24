using UnityEngine;

public class ArrowWinZone : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private ScoreView _scoreView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ArrowWinZone"))
        {
            _walletView.AddCoin(10);
            _scoreView.UpdateView();
        }
    }
}
