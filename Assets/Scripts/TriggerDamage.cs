using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{

    public Animator m_animator;
    public Transform groundCheck;

    public float moveSpeed;
    public bool ground = true;

    public int maxHealth = 5;
    int currentHealth;

    public bool facingRight = true;
    public LayerMask groundLayer;
    public HeartSystem heart;
    public HeroKnight player;

    private void Start()
    {
        m_animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);

        if (ground == false )
        {
            moveSpeed *= -1;
        }

        if (moveSpeed > 0 && !facingRight)
        {
            Flip();
        }
        
        if (moveSpeed < 0 && facingRight)
        {
            Flip();
        }

        if (moveSpeed != 0)
        {
            m_animator.SetBool("IsRunning", true);
        }
    }

    private void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        m_animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            StopCoroutine("Attack");
            Die();
        }
    }

    void Die()
    {
        m_animator.SetBool("IsDead", true);
        moveSpeed = 0;
        GetComponent<Collider2D>().enabled = true;
        this.enabled = false;
        Destroy(gameObject, 1.0f);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
