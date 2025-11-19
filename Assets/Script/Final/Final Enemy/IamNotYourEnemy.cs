using System.Threading;
using UnityEngine;

public class IamNotYourEnemy : Enemy
{
    private float healTimer = 0f;

    public override void SetUP()
    {
        base.SetUP();
       
    }
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
            healTimer += Time.deltaTime;
            if (healTimer >= 1f)
            {
                Heal(20);
                healTimer = 0f;
            }
            animator.SetBool("Attack", false);
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Move(direction);

            if (GetDistanPlayer() < 1.5)
            {
                Attack(player);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    /*public override void OnDeath()
    {
        base.OnDeath();
        UpgradeManager.instance.RegisterEnemyKill(gameObject);
    }*/

}
