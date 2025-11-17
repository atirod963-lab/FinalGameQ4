using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [Header("Upgrade Settings")]
    [SerializeField] private int killsForUpgrade = 3;

    [Header("Tracking")]
    [SerializeField] private int currentKillCount = 0;

    private Weapon activeWeapon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (activeWeapon == null) return;

        if (currentKillCount >= killsForUpgrade)
        {
            activeWeapon.TryUpgrade();
            currentKillCount = 0;

            Debug.Log($"<color=yellow>ทำการอัปเกรดหลังฆ่า {killsForUpgrade} ตัว</color>");
        }
    }

    public void RegisterEnemyKill(GameObject enemy)
    {
        if (activeWeapon == null)
        {
            Debug.LogWarning("มีการฆ่าศัตรู แต่ยังไม่มีอาวุธที่ใช้งาน");
            return;
        }

        if (enemy.CompareTag("Enemy"))
        {
            currentKillCount++;
            Debug.Log($"Enemy +1 ( {currentKillCount}/{killsForUpgrade} )");
        }
    }

    public void SetActiveWeapon(Weapon newWeapon)
    {
        activeWeapon = newWeapon;
        currentKillCount = 0;

        Debug.Log($"<color=cyan>ตั้งค่าอาวุธ:</color> {activeWeapon.Name} (LV {activeWeapon.CurrentLevel})");
    }
}
