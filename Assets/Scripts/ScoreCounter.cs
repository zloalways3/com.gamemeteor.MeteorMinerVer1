using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI winScoreText;
    [SerializeField] private TextMeshProUGUI failScoreText;

    public int TargetScore { private get; set; }

    private int _currentScore;

    private void Start()
    {
        winScoreText.text = failScoreText.text = scoreText.text = _currentScore + "/" + TargetScore;
    }

    public void AddScore()
    {
        _currentScore += 1;
        winScoreText.text = failScoreText.text = scoreText.text = _currentScore + "/" + TargetScore;

        if (_currentScore == TargetScore)
        {
            gameController.Win();
        }
    }
}
