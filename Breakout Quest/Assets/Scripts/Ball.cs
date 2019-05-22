using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.position;
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            Launch();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor),
            Random.Range(0, randomFactor));
        if (hasStarted)
        {
            m_rigidbody.velocity += velocityTweak;
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.position.x, paddle.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void Launch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            m_rigidbody.velocity = new Vector2(xPush, yPush);
        }
    }
}
