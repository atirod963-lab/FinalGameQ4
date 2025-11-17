using UnityEngine;

public class YouMoveIShoot : Enemy
{
    [Header("Settings")]
    public float attackRange = 15f;

    private Vector3 lastPlayerPos;

    private void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }
        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;

        Vector3 playerDelta = player.transform.position - lastPlayerPos;
        bool playerMoved = playerDelta.sqrMagnitude > 0.0001f;

        if (playerMoved && timer <= 0f && GetDistanPlayer() < attackRange)
        {
            Attack(player); 
        }
        else if (!playerMoved)
        {
            animator.SetBool("Attack", false);
        }

        lastPlayerPos = player.transform.position;
    }
}
