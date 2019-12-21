using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.33f;
    public LayerMask enemyLayers;
    private Animator m_animator;

    public int attackDamage = 15;

    public int health = 100;

    //public float attackRate = 0f;
    //float nextAttackTime = 0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {


       // if (Time.time >= nextAttackTime)
        //{
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                //nextAttackTime = Time.time + 1f / attackRate;
            }
        //}
    }
        void Attack()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); ;

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("Hit " + enemy.name);
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

        }

    public void TakeDamage(int damage)
    {
        health -= damage;

        m_animator.SetTrigger("IsHurt");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player is Die");
        m_animator.SetBool("IsDead", true);

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
