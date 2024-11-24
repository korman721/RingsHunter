using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private IDataProvider _dataProvider;

    private Wallet _wallet;

    public void Initialize(Wallet wallet, IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;

        _wallet = wallet;

        UpdateValue(_wallet.GetCurrentCoins());

        _wallet.CoinsChanged += UpdateValue;
    }

    private void OnDestroy() => _wallet.CoinsChanged -= UpdateValue;
    private void UpdateValue(int value) => _value.text = value.ToString();

    public void AddCoin(int value)
    {
        _wallet.AddCoins(value);

        UpdateValue(_wallet.GetCurrentCoins());

        _dataProvider.Save();
    }
}
