using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{

    public Animator m_animator;

    public int maxHealth = 5;
    int currentHealth;

    public HeartSystem heart;
    public HeroKnight player;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        m_animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        m_animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = true;
        this.enabled = false;
        Destroy(gameObject, 1.0f);
    }
}
