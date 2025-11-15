using UnityEngine;

public abstract class Weapon : Item
{
    [Header("Weapon Base Stats")]
    [SerializeField] protected int damage;
    [SerializeField] protected float range;
    [SerializeField] protected float attackSpeed;

    [Header("Level Info")]
    [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel = 4;

    public int Damage => damage;
    public float Range => range;
    public float AttackSpeed => attackSpeed;
    public int CurrentLevel => currentLevel;

    // ⭐ เพิ่มเมธอดนี้เพื่อให้สามารถ override ใน Sword ได้
    protected virtual void Awake()
    {
        // อาวุธอื่น ๆ ที่ไม่ override จะใช้ค่าเดิมที่ตั้งใน Inspector
    }

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        Debug.Log($"<color=cyan>ติดตั้งอาวุธ:</color> {Name} - Level {currentLevel} | DMG:{damage}, RNG:{range}, SPD:{attackSpeed}");

        UpgradeManager.instance.SetActiveWeapon(this);
    }

    public void TryUpgrade()
    {
        if (currentLevel >= maxLevel)
        {
            Debug.Log($"<color=red>{Name} อยู่ระดับสูงสุดแล้ว (LV {maxLevel})!</color>");
            return;
        }

        Upgrade();
    }

    protected abstract void Upgrade();
}
