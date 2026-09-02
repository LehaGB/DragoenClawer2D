using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 1;

    public Animator animator;

    public SpriteRenderer spriteRenderer;
    public PlayerHealth playerHealth;

    public int kcnkcbackForce = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerHealth.isAlive)
        {
            PerformAttack();
        }
    }


    private void PerformAttack()
    {
        animator.SetTrigger("Attack");
        Vector2 attackDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Collider2D[] hitCollider = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach(Collider2D collider in hitCollider)
        {
            if (collider.CompareTag("Enemy"))
            {
                Vector2 directionToEnemy = (collider.transform.position - transform.position).normalized;

                if (Vector2.Dot(attackDirection, directionToEnemy) > 0)
                {
                    EnemyAI enemyScript = collider.GetComponent<EnemyAI>();
                    enemyScript.TakeDamage(damage);

                    Vector2 kcnokcbackDirection = (collider.transform.position - transform.position).normalized;
                    enemyScript.rb.AddForce(kcnokcbackDirection * kcnkcbackForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
