using System.Collections.Generic;
using UnityEngine;

public class BossSkillBook : MonoBehaviour
{
    public List<Skill> skills = new List<Skill>();

    // 👉 ใส่ FX Prefab ตามลำดับสกิล
    public GameObject[] skillEffects;

    private Character boss;

    void Start()
    {
        boss = GetComponent<Character>();

        // เพิ่มสกิล Boss
        skills.Add(new FireballSkill());
        skills.Add(new HealSkill());
        // ถ้ามีเพิ่มก็แค่เพิ่มแบบนี้
    }

    void Update()
    {
        float time = Time.time;

        for (int i = 0; i < skills.Count; i++)
        {
            Skill skill = skills[i];

            // รันสกิลที่มี duration (timer)
            if (skill.timer > 0)
            {
                skill.UpdateSkill(boss);
            }

            // ถ้าถึงเวลาใช้
            if (skill.IsReady(time))
            {
                // 🎇 สร้าง FX ถ้ามี prefab
                if (skillEffects != null && i < skillEffects.Length && skillEffects[i] != null)
                {
                    GameObject fx = Instantiate(skillEffects[i], transform.position, Quaternion.identity);
                    Destroy(fx, 2);
                }

                // รันสกิลจริง
                skill.Activate(boss);
                skill.TimeStampSkill(time);
            }
        }
    }
}
