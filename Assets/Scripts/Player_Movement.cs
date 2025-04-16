using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    private Animator animator;
    private Transform playerTransform;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(horizontalInput));

        if (horizontalInput != 0)
        {
            Vector3 scale = playerTransform.localScale;
            scale.x = Mathf.Sign(horizontalInput);
            playerTransform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
