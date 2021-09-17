using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball locking parameters")]
    [SerializeField] Vector2 offset;
    [SerializeField] Paddle paddle;
    [SerializeField] float yPush;

    [Header("Random xPush parameters")]
    [SerializeField] float xLeft;
    [SerializeField] float xRight;
    [SerializeField] bool isRandom;

    [Header("Prevent ball loops by adding random offset to transform")]
    [SerializeField] float min;
    [SerializeField] float max;

    Vector2 paddlePos;
    float xPush;
    Rigidbody2D rb;
    float randomBounceOffsetX;
    float randomBounceOffsetY;

    bool launched = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isRandom)
        {
            xPush = Random.Range(-12f, 12f);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
        }

        LaunchOnMouseClick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb != null)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(min, max), Random.Range(min, max));
            rb.velocity += velocityTweak;
        }
    }

    void LaunchOnMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && launched is false)
        {
            rb.velocity = new Vector2(xPush, yPush);
            launched = true;
        }
    }

    void LockBallToPaddle()
    {
        paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + offset;
    }
}
