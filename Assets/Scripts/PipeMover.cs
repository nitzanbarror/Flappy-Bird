using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}