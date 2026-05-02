using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.W)) y += 1f;
        if (Input.GetKey(KeyCode.S)) y -= 1f;
        if (Input.GetKey(KeyCode.A)) x -= 1f;
        if (Input.GetKey(KeyCode.D)) x += 1f;

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;

        if (direction != Vector2.zero)
            animator.Play("Run");
        else
            animator.Play("Idle");

        if (x > 0) transform.localScale = new Vector3(-0.32f, 0.32f, 1);
        if (x < 0) transform.localScale = new Vector3(0.32f, 0.32f, 1);
    }
}