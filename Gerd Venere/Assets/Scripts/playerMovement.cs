using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 5;
    private float jumpSpeed = 16;

    bool isGrounded;

    Rigidbody2D rb;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2 (hor * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            
            rb.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
            isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
