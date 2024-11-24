using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private TMP_Text _bestScoreUI;

    [SerializeField] public GameObject _settings;
    [SerializeField] public GameObject _endScreen;

    private void Awake()
    {
        Instance = this;
    }
    public void EndGame()
    { 
        _endScreen.SetActive(true);

        _bestScoreUI.text = $"Best score: {_scoreView.SetBestScoreOnUI()}";

        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ManageBestScore()
    {
        _scoreView.UpdateBestScore();
    }
}
