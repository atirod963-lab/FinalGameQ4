using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FireballSkill", menuName = "Skills/FireballSkill")]
public class FireballSkill : Skill
{
    public int damage = 25;
    public float searchRadius = 5f; 

    public FireballSkill()
    {
        skillName = "Fireball";
        cooldownTime = 5f;
    }

    public override void Activate(Character caster)
    {
        Player target = UnityEngine.Object.FindAnyObjectByType<Player>();

        if (target != null)
        {
            float distance = Vector3.Distance(caster.transform.position, target.transform.position);

            if (distance <= searchRadius)
            {
                target.TakeDamage(damage);
                Debug.Log($"{caster.Name} casts {skillName} on {target.Name}, dealing {damage} damage!");
            }
            else
            {
                Debug.Log($"{caster.Name} missed! Player is out of range ({distance:F1}m > {searchRadius}m).");
            }
        }
        else
        {
            Debug.Log("No Player found inside the scene.");
        }
    }

    public override void Deactivate(Character character)
    {
    }

    public override void UpdateSkill(Character character)
    {
    }
}