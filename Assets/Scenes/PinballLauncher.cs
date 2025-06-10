
using UnityEngine;

public class PinballLauncher : MonoBehaviour
{
    public Transform ballStartPosition; 
    public float launchForce = 800f;    
    public KeyCode launchKey = KeyCode.DownArrow; 
    private Rigidbody2D ballRb;
    private bool isBallReady = false;

    private void Update()
    {
        if (Input.GetKeyDown(launchKey) && isBallReady)
        {
            LaunchBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ballRb = collision.GetComponent<Rigidbody2D>();
            ballRb.linearVelocity = Vector2.zero;
            ballRb.transform.position = ballStartPosition.position;
            isBallReady = true;
        }
    }

    void LaunchBall()
    {
        if (ballRb != null)
        {
            ballRb.AddForce(Vector2.up * launchForce);
            isBallReady = false;
        }
    }
}



