using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 10;
    public LayerMask enemyLayer; // Layer dos inimigos
    public float attackRange = 0.5f;
    public Transform attackPoint;

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isAttacking = false;
        }
    }

    IEnumerator AttackCoroutine()
    {
        while (isAttacking)
        {
            Attack();
            yield return new WaitForSeconds(0.5f); // Intervalo entre cada ataque
        }
    }

    void Attack()
    {
        // Detectar inimigos na área de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Aplicar dano aos inimigos atingidos
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }

    // Método para visualizar o range de ataque no Editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}