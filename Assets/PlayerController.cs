using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 5.0f;
    Rigidbody2D rb;
    bool isGrounded;
    int score = 0;

    bool isDashing;
    float dashHorizontalDirection;
    float dashVerticalDirection;
    float dashSpeed = 15.0f;
    float dashDuration = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        /*
        float movementDistanceX = movementX * speed * Time.deltaTime;
        float movementDistanceY = movementY * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movementDistanceX, transform.position.y + movementDistanceY);
        */
        if (isDashing && dashDuration > 0)
        {
            rb.linearVelocity = new Vector2(dashHorizontalDirection * dashSpeed, dashVerticalDirection * dashSpeed);
            dashDuration -= Time.deltaTime;
            return;
        }
        else
        {
            dashDuration = 0.3f;
            isDashing = false;
        }
        rb.linearVelocity = new Vector2(movementX * speed, rb.linearVelocity.y);
        if (movementY > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0, 100));
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
        Debug.Log("Movement X = " + movementX);
        Debug.Log("Movement Y = " + movementY);
    }

    void OnDash(InputValue value)
    {
        isDashing = true;
        dashHorizontalDirection = movementX;
        dashVerticalDirection = movementY;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score += 1;
            collision.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }
    }
}
