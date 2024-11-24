using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private int _currentScore = 0;
    private IDataProvider _dataProvider;
    private Score _score;

    public void Initialize(Score score, IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;

        _score = score;
    }

    public void UpdateView()
    {
        _currentScore++;

        _value.text = _currentScore.ToString();
    }
    public void UpdateBestScore()
    {
        if (_score.GetBestScore() < _currentScore)
        {
            _score.SaveBestScore(_currentScore);

            _dataProvider.Save();
        }
    }
    public int SetBestScoreOnUI() => _score.GetBestScore();
}
