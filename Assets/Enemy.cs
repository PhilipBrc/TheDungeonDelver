using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update

    public Transform attackPoint;
    public float attackRange = 0.33f;
    public LayerMask Player;

    public int attackDamage = 15;
    void Start()
    {
        currentHealth = maxHealth;

    }
    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Player); ;

        foreach (Collider2D Player in hitEnemies)
        {
            Debug.Log("Hit Player");
            Player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("IsHurt");

        if(currentHealth <= 0){
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy is Die");
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}


