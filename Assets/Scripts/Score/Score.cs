public class Score
{
    private IPersistentData _persistentData;
    public Score(IPersistentData persistentData) => _persistentData = persistentData;

    public int GetBestScore() => _persistentData.PlayerData.BestScore;

    public void SaveBestScore(int score) 
    {
        if (GetBestScore() < score)
            _persistentData.PlayerData.BestScore = score;
    }
}
