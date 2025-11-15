using UnityEngine;

public class Sword : Weapon
{
    protected override void Awake()
    {
        base.Awake();

        // ค่าสถานะเริ่มต้นของดาบ
        damage = 10;
        range = 1f;
        attackSpeed = 1f;
        currentLevel = 1;
        maxLevel = 4;
    }

    protected override void Upgrade()
    {
        currentLevel++;

        switch (currentLevel)
        {
            case 2:
                damage += 5;       // 10 → 15
                range += 1f;       // 1 → 2
                attackSpeed = 3f;  //  → 3
                break;

            case 3:
                damage += 5;       // 15 → 20
                range += 1f;       // 2 → 3
                attackSpeed = 3f;  // คงเดิม
                break;

            case 4:
                damage += 5;       // 20 → 25
                range += 1f;       // 3 → 4
                attackSpeed = 3f;  // คงเดิม (final)
                break;
        }

        Debug.Log($"<color=lime>อัปเกรด {Name} → Level {currentLevel}</color>");
        Debug.Log($"DMG:{damage}, RNG:{range}, SPD:{attackSpeed}");
    }


    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        Vector3 swordUp = new Vector3(90, 0, 0);
        itemcollider.enabled = false;
        transform.parent = player.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(swordUp);
        player.Damage += Damage;
    }

}
