using UnityEngine;

public class NoMelee : Enemy
{
    [Header("No Melee Settings")]
    public float safeDistance = 5f;   

    private void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }

        float dist = GetDistanPlayer();
        Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;

        Turn(dirToPlayer);

        timer -= Time.deltaTime;

        if (dist > safeDistance)
        {
            animator.SetBool("Attack", true);
            Attack(player);
            return;
        }

        animator.SetBool("Attack", false);
        animator.ResetTrigger("Attack");

        Vector3 fleeDir = (transform.position - player.transform.position).normalized;
        Move(fleeDir);
    }
}
