using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject startText;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;

    private bool gameStarted = false;
    private bool gameOver = false;
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0f;
        startText.SetActive(true);
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            startText.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (gameOver && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}