using System.Collections.Generic;
using UnityEngine;

public class BossSkillBook : MonoBehaviour
{
    public List<Skill> skills = new List<Skill>();

    public GameObject[] skillEffects;

    private Character boss;

    void Start()
    {
        boss = GetComponent<Character>();

        skills.Add(new FireballSkill());
        skills.Add(new HealSkill());
    }

    void Update()
    {
        float time = Time.time;

        for (int i = 0; i < skills.Count; i++)
        {
            Skill skill = skills[i];

            if (skill.timer > 0)
            {
                skill.UpdateSkill(boss);
            }

            if (skill.IsReady(time))
            {
                if (skillEffects != null && i < skillEffects.Length && skillEffects[i] != null)
                {
                    GameObject fx = Instantiate(skillEffects[i], transform.position, Quaternion.identity);
                    Destroy(fx, 2);
                }

                skill.Activate(boss);
                skill.TimeStampSkill(time);
            }
        }
    }
}
