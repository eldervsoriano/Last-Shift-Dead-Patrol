using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // Current score
    public TextMeshProUGUI scoreText; // Reference to the score UI text

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddPoints(int points)
    {
        score += points; // Add points to the score
        UpdateScoreDisplay(); // Refresh the UI
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
