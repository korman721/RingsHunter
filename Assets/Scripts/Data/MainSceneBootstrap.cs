using UnityEngine;

public class MainSceneBootstrap : MonoBehaviour
{
    [SerializeField] private NewBehaviourScript _arrowControl;
    [SerializeField] private Generator _generator;
    [SerializeField] private GameObject _background;

    [SerializeField] private ArrowFactory _arrowFactory;
    [SerializeField] private BackgroundFactory _backgroundFactory;
    [SerializeField] private RingFactory _ringFactory;

    [SerializeField] private WalletView _walletView;
    [SerializeField] private ScoreView _scoreView;

    private IDataProvider _dataProvider;
    private IPersistentData _persistentPlayerData;

    private Wallet _wallet;
    private Score _score;

    private void Awake()
    {
        InitializeData();

        InitializeScore();

        InitializeWallet();

        DoSwitchSkins();
    }
    private void DoSwitchSkins()
    {
        _arrowControl._arrowPrefab = _arrowFactory.GetPrefab(_persistentPlayerData.PlayerData.SelectedArrowSkin);
        RingSwitch();
        _background.GetComponent<SpriteRenderer>().sprite = _backgroundFactory.GetPrefab(_persistentPlayerData.PlayerData.SelectedBackground).GetComponent<SpriteRenderer>().sprite;
    }
    private void InitializeData()
    {
        _persistentPlayerData = new PersistentData();
        _dataProvider = new DataLocalProvider(_persistentPlayerData);

        LoadDataOrInit();
    }
    private void InitializeScore()
    {
        _score = new Score(_persistentPlayerData);

        _scoreView.Initialize(_score, _dataProvider);
    }
    private void InitializeWallet()
    {
        _wallet = new Wallet(_persistentPlayerData);

        _walletView.Initialize(_wallet, _dataProvider);
    }
    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
            _persistentPlayerData.PlayerData = new PlayerData();
    }
    private void RingSwitch()
    {
        for (int i = 0; i < _ringFactory.GetPrefab(_persistentPlayerData.PlayerData.SelectedRing).Length; i++)
        {
            _generator._rings[i] = _ringFactory.GetPrefab(_persistentPlayerData.PlayerData.SelectedRing)[i];
        }
    }
}
