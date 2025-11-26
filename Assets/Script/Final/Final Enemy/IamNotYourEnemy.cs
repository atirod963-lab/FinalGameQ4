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
            animator.SetBool("Attack", false);
            Debug.Log("got damage");
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Move(direction);

            if (GetDistanPlayer() < 1.5)
            {
                Attack(player);
                animator.SetFloat("Speed", 0);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetFloat("Speed", 0);
        }
        healTimer += Time.deltaTime;
        if (healTimer >= 1f)
        {
            Heal(20);
            healTimer = 0f;
        }
    }

    /*public override void OnDeath()
    {
        base.OnDeath();
        UpgradeManager.instance.RegisterEnemyKill(gameObject);
    }*/

}
