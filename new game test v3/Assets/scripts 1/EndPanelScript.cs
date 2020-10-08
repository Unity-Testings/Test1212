using UnityEngine;
using UnityEngine.UI;

public class EndPanelScript : MonoBehaviour
{
    public int highScore;
    public int currentScore;
    public Text highscoreTxt;
    public Text currentScoreTxt;

    public drawingHolder player;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        currentScore = player.score;
        currentScoreTxt.text = currentScore.ToString();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");

            if (currentScore > highScore)
            {
                highScore = currentScore;
                highscoreTxt.text = highScore.ToString();
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            else
            {
                highScore = PlayerPrefs.GetInt("HighScore");
                highscoreTxt.text = highScore.ToString();
            }

        }
        else
        {
            highScore = currentScore;
            highscoreTxt.text = highScore.ToString();

            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void Update()
    {

    }
}
