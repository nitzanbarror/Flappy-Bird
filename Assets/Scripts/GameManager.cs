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
    private static int highScore = 0;
    private static bool hasPlayedBefore = false;

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

        highScoreText.text = "Best: " + highScore;
        highScoreText.gameObject.SetActive(false);
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

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = "Best: " + highScore;
        highScoreText.gameObject.SetActive(hasPlayedBefore);
        hasPlayedBefore = true;

        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }

}