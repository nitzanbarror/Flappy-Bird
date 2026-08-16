using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject startText;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public AudioClip pointSound;

    private AudioSource audioSource;
    private bool gameStarted = false;
    private bool gameOver = false;
    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        startText.SetActive(true);
        gameOverText.SetActive(false);
        scoreText.gameObject.SetActive(false);

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best: " + highScore;
        highScoreText.gameObject.SetActive(false);   // ← add this
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            startText.SetActive(false);
            scoreText.gameObject.SetActive(true);
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
        audioSource.PlayOneShot(pointSound);
    }

    public void GameOver()
    {
        gameOver = true;

        // was there already a record from a previous game?
        bool hadRecord = PlayerPrefs.HasKey("HighScore");

        // save the record (always ensures the key exists after game #1)
        if (score > highScore)
        {
            highScore = score;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();

        // show Best only if a record existed BEFORE this game
        highScoreText.text = "Best: " + highScore;
        highScoreText.gameObject.SetActive(hadRecord);

        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }

}