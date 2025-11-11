using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    [Serializable]
    public class LevelData
    {
        public int Damage;
        public float Range;

        public LevelData(int damage, float range)
        {
            Damage = damage;
            Range = range;
        }
    }

    public string Name;

    // เลเวลปัจจุบัน
    public int CurrentLevel = 1;

    // รายการเลเวลทั้งหมด
    public List<LevelData> Levels = new List<LevelData>();

    public Weapon(string name, int baseDamage, float baseRange)
    {
        Name = name;

        // ✅ Level 1
        Levels.Add(new LevelData(baseDamage, baseRange));

        // ✅ Level 2 (เพิ่มเป็นเท่าตัว)
        Levels.Add(new LevelData(baseDamage * 2, baseRange * 2f));

        // คุณสามารถเพิ่ม Level 3, 4, 5 แบบนี้ได้
        // Levels.Add(new LevelData(baseDamage * 4, baseRange * 4f));
    }

    public int Damage => Levels[CurrentLevel - 1].Damage;
    public float Range => Levels[CurrentLevel - 1].Range;

    public bool CanUpgrade => CurrentLevel < Levels.Count;

    public void Upgrade()
    {
        if (!CanUpgrade)
        {
            Debug.Log($"[Weapon] {Name} cannot upgrade further.");
            return;
        }

        CurrentLevel++;
        Debug.Log($"[Weapon] {Name} upgraded to Level {CurrentLevel}. Stats: Damage={Damage}, Range={Range}");
    }

    public override string ToString()
    {
        return $"Weapon {Name} - Level {CurrentLevel} (Damage: {Damage}, Range: {Range})";
    }
}
