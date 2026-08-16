using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject startText;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public AudioClip pointSound;

    private AudioSource audioSource;
    private bool gameStarted = false;
    private bool gameOver = false;
    private int score = 0;

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
        scoreText.gameObject.SetActive(false);   // ← add this
    }

    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            startText.SetActive(false);
            scoreText.gameObject.SetActive(true);   // ← add this
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
        audioSource.PlayOneShot(pointSound);
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}