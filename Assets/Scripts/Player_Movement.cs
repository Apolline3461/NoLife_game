using UnityEngine;
using System.Collections;

public enum TimePeriod
{
    Past,
    Present,
    Future
}

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TimePeriod timePeriod;
    
    private Transform respawnPoint;
    private bool isDead = false;
    private int jumpsLeft;
    private Rigidbody2D body;
    private bool grounded;
    private Animator animator;
    private Transform playerTransform;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        Debug.Log("Script démarré. Période actuelle : " + timePeriod);
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        respawnPoint = GameObject.FindGameObjectWithTag("Spawn").transform;

        if (respawnPoint == null) {
            Debug.LogError("RespawnPoint introuvable ! Assure-toi qu'un objet est tagué 'Spawn'.");
        }
        ApplyTimePeriodSettings();
    }

    private void ApplyTimePeriodSettings()
    {
        switch (timePeriod)
        {
            case TimePeriod.Past:
                body.gravityScale = 5f;
                jumpForce = 6f;
                animator.speed = 1.5f;
                break;
            case TimePeriod.Present:
                body.gravityScale = 3.5f;
                jumpForce = 7f;
                animator.speed = 1f;
                break;
            case TimePeriod.Future:
                body.gravityScale = 2f;
                jumpForce = 9f;
                animator.speed = 0.85f;
                jumpsLeft = 2;
                break;
        }
    }

    private IEnumerator DieAndRespawn() {
        isDead = true;
        body.velocity = Vector2.zero;
        animator.SetTrigger("isDead");

        yield return new WaitForSeconds(2f);

        Debug.Log("On est en Die et respawn, is dead = " + isDead);
        // Respawn

        Debug.Log("Teleportation au point de respawn");
        transform.position = respawnPoint.position;
        body.velocity = Vector2.zero;

        isDead = false;
        animator.Play("idleMPast");
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.P) && !isDead) {
            StartCoroutine(DieAndRespawn());
        }

        if (isDead) return;

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput != 0)
        {
            Vector3 scale = playerTransform.localScale;
            scale.x = Mathf.Sign(horizontalInput);
            playerTransform.localScale = scale;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        grounded = IsGrounded();

        if (grounded)
        {
            jumpsLeft = (timePeriod == TimePeriod.Future) ? 2 : 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            Jump();
        }

        animator.SetBool("isJumping", !grounded);

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            // Incrémente l'enum en boucle
            timePeriod = (TimePeriod)(((int)timePeriod + 1) % System.Enum.GetValues(typeof(TimePeriod)).Length);
            ApplyTimePeriodSettings();
            Debug.Log("TimePeriod changed to: " + timePeriod);
        }
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        jumpsLeft--;
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.CapsuleCast(
            capsuleCollider.bounds.center,
            capsuleCollider.bounds.size,
            capsuleCollider.direction,
            0f,
            Vector2.down,
            extraHeight,
            groundLayer
        );
        return raycastHit.collider != null;
    }
}
