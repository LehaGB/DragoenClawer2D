using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rigidbody2D;
    public Animator animator;

    public SpriteRenderer spriteRenderer;
    private Vector2 _movement;

    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth.isAlive)
        {
            Move();
        }  
    }


    private void FixedUpdate()
    {
        PhisicsPlayer();
    }

    private void Move()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _movement = _movement.normalized;

        animator.SetFloat("Speed", _movement.sqrMagnitude);

        if(_movement.x != 0)
        {
            spriteRenderer.flipX = _movement.x < 0;
        }
    }


    private void PhisicsPlayer()
    {
        rigidbody2D.linearVelocity = _movement * moveSpeed;
    }
}
