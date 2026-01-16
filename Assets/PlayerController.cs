using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float movementDistanceX = movementX * speed * Time.deltaTime;
        float movementDistanceY = movementY * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movementDistanceX, transform.position.y + movementDistanceY);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
        Debug.Log("Movement X = " + movementX);
        Debug.Log("Movement Y = " + movementY);
    }
}
