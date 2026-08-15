using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * flapForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}