using UnityEngine;

public class IamNotYourEnemy : Enemy
{

    // Update is called once per frame
    private void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
            return;
        }

        Turn(player.transform.position - transform.position);
        timer -= Time.deltaTime;

        if (health < maxHealth)
        {
            animator.SetBool("Attack", false);
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Move(direction); // เดินเข้าหาเสมอเมื่อเลือดลด

            if (GetDistanPlayer() < 1.5)
            {
                Attack(player); // โจมตีเมื่อใกล้
            }
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

}
