//using UnityEngine;
//using TMPro;

//public class PlayerScore : MonoBehaviour
//{
//    public int score = 0; // Current score
//    public TextMeshProUGUI scoreText; // Reference to the score UI text

//    private void Start()
//    {
//        UpdateScoreDisplay();
//    }

//    public void AddPoints(int points)
//    {
//        score += points; // Add points to the score
//        UpdateScoreDisplay(); // Refresh the UI
//    }

//    private void UpdateScoreDisplay()
//    {
//        if (scoreText != null)
//        {
//            scoreText.text = "Score: " + score.ToString();
//        }
//    }
//}


//using UnityEngine;
//using TMPro;

//public class PlayerScore : MonoBehaviour
//{
//    public int score = 0;                  // Current score during gameplay
//    public int gameOverScore = 0;          // Current score shown on the game over panel
//    public int highScore = 0;              // High score
//    public TextMeshProUGUI scoreText;      // Reference to the score UI text (Gameplay)
//    public TextMeshProUGUI highScoreText;  // Reference to the high score UI text
//    public TextMeshProUGUI gameOverScoreText;  // Reference to the score UI text (Game Over Panel)

//    private const string HIGH_SCORE_KEY = "HighScore"; // Key for saving high score in PlayerPrefs

//    private void Start()
//    {
//        LoadHighScore();          // Load the high score when the game starts
//        UpdateScoreDisplay();     // Display the initial scores (Gameplay)
//    }

//    /// <summary>
//    /// Adds points to the current score and checks for a new high score.
//    /// </summary>
//    /// <param name="points">Points to add to the current score.</param>
//    public void AddPoints(int points)
//    {
//        score += points;  // Add points to the current score

//        // Check if the new score is higher than the saved high score
//        if (score > highScore)
//        {
//            highScore = score;    // Update high score
//            SaveHighScore();       // Save the new high score
//        }

//        UpdateScoreDisplay();   // Refresh the UI with the updated scores
//    }

//    /// <summary>
//    /// Updates the UI to display the current score and high score.
//    /// </summary>
//    private void UpdateScoreDisplay()
//    {
//        // Gameplay Score Display
//        if (scoreText != null)
//        {
//            scoreText.text = "Score: " + score.ToString(); // Display the current score during gameplay
//        }

//        // High Score Display
//        if (highScoreText != null)
//        {
//            highScoreText.text = "High Score: " + highScore.ToString(); // Display the high score
//        }

//        // Game Over Score Display
//        if (gameOverScoreText != null)
//        {
//            gameOverScoreText.text = "Final Score: " + score.ToString(); // Display the score on the Game Over panel
//        }
//    }

//    /// <summary>
//    /// Saves the high score to PlayerPrefs.
//    /// </summary>
//    private void SaveHighScore()
//    {
//        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
//        PlayerPrefs.Save(); // Ensure the high score is saved
//    }

//    /// <summary>
//    /// Loads the high score from PlayerPrefs.
//    /// </summary>
//    private void LoadHighScore()
//    {
//        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0); // Default to 0 if no high score exists
//    }

//    /// <summary>
//    /// Set the Game Over score (when the game ends).
//    /// </summary>
//    public void SetGameOverScore()
//    {
//        gameOverScore = score;  // Store the gameplay score as the game over score
//        UpdateScoreDisplay();    // Refresh the UI to show the game over score
//    }

//    /// <summary>
//    /// Reset the gameplay score (if needed).
//    /// </summary>
//    public void ResetScore()
//    {
//        score = 0;
//        UpdateScoreDisplay();
//    }
//}





using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;                  // Current score during gameplay
    public int gameOverScore = 0;          // Current score shown on the game over panel
    public int highScore = 0;              // High score
    public int doubleHighScore = 0;        // Double High score (new)
    public TextMeshProUGUI scoreText;      // Reference to the score UI text (Gameplay)
    public TextMeshProUGUI highScoreText;  // Reference to the high score UI text
    public TextMeshProUGUI gameOverScoreText;  // Reference to the score UI text (Game Over Panel)
    public TextMeshProUGUI doubleHighScoreText; // Reference to the double high score UI text (Home Panel)

    private const string HIGH_SCORE_KEY = "HighScore";             // Key for saving high score in PlayerPrefs
    private const string DOUBLE_HIGH_SCORE_KEY = "DoubleHighScore"; // Key for saving double high score in PlayerPrefs

    private void Start()
    {
        LoadHighScores();           // Load both high scores when the game starts
        UpdateScoreDisplay();       // Display the initial scores (Gameplay and Home Panel)
    }

    /// <summary>
    /// Adds points to the current score and checks for new high scores.
    /// </summary>
    /// <param name="points">Points to add to the current score.</param>
    public void AddPoints(int points)
    {
        score += points;  // Add points to the current score

        // Check if the new score is higher than the saved high score
        if (score > highScore)
        {
            highScore = score;    // Update high score
            SaveHighScores();      // Save both high scores
        }

        // Check for the "double" high score condition (e.g., you can define your rule here)
        if (score > doubleHighScore)
        {
            doubleHighScore = score; // Update double high score
            SaveHighScores();        // Save both high scores
        }

        UpdateScoreDisplay();   // Refresh the UI with the updated scores
    }

    /// <summary>
    /// Updates the UI to display the current score, high score, and double high score.
    /// </summary>
    private void UpdateScoreDisplay()
    {
        // Gameplay Score Display
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score.ToString(); // Display the current score during gameplay
        }

        // High Score Display
        if (highScoreText != null)
        {
            highScoreText.text = highScore.ToString(); // Display the high score
        }

        // Game Over Score Display
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text =  score.ToString(); // Display the score on the Game Over panel
        }

        // Double High Score Display (Home Panel)
        if (doubleHighScoreText != null)
        {
            doubleHighScoreText.text = doubleHighScore.ToString(); // Display the double high score on Home Panel
        }
    }

    /// <summary>
    /// Saves both the high score and double high score to PlayerPrefs.
    /// </summary>
    private void SaveHighScores()
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        PlayerPrefs.SetInt(DOUBLE_HIGH_SCORE_KEY, doubleHighScore);
        PlayerPrefs.Save(); // Ensure both high scores are saved
    }

    /// <summary>
    /// Loads both the high score and double high score from PlayerPrefs.
    /// </summary>
    private void LoadHighScores()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);             // Default to 0 if no high score exists
        doubleHighScore = PlayerPrefs.GetInt(DOUBLE_HIGH_SCORE_KEY, 0); // Default to 0 if no double high score exists
    }

    /// <summary>
    /// Set the Game Over score (when the game ends).
    /// </summary>
    public void SetGameOverScore()
    {
        gameOverScore = score;  // Store the gameplay score as the game over score
        UpdateScoreDisplay();    // Refresh the UI to show the game over score
    }

    /// <summary>
    /// Reset the gameplay score (if needed).
    /// </summary>
    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }
}

