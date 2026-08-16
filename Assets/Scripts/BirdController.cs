using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;
    public AudioClip flapSound;
    public AudioClip hitSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * flapForce;
            audioSource.PlayOneShot(flapSound);
        }

        float angle = Mathf.Clamp(rb.linearVelocity.y * 5f, -60f, 30f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            isDead = true;
            audioSource.PlayOneShot(hitSound);
            GameManager.Instance.GameOver();
        }
    }
}