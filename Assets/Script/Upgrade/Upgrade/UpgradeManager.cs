using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [SerializeField] private int killsToUpgrade = 3;

    private int lastEnemyCount = 0;
    private int killCount = 0;

    private Weapon activeWeapon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // สร้างดาบเริ่มต้น
        activeWeapon = new Weapon("Sword", 10, 1f);
        Debug.Log("[UpgradeManager] Init Sword Level 1");
    }

    private void Update()
    {
        CountDeadEnemies();
    }

    private void CountDeadEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int currentCount = enemies.Length;

        // ถ้าจำนวนศัตรูลดลง -> มีศัตรูถูกฆ่า
        if (currentCount < lastEnemyCount)
        {
            int killed = lastEnemyCount - currentCount;
            killCount += killed;

            Debug.Log($"[UpgradeManager] Enemy killed! Total kills: {killCount}/{killsToUpgrade}");

            if (killCount >= killsToUpgrade)
            {
                UpgradeWeapon();
                killCount = 0;
            }
        }

        lastEnemyCount = currentCount;
    }

    private void UpgradeWeapon()
    {
        if (activeWeapon.CanUpgrade)
        {
            activeWeapon.Upgrade();
        }
        else
        {
            Debug.Log("[UpgradeManager] Weapon already max level.");
        }
    }
}
