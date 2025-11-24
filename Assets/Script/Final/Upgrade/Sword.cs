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

        // โชว์ครั้งแรกตอนเริ่มเกม
        UpdateWeaponUI();
    }

    protected override void Upgrade()
    {
        int oldDamage = damage;
        float oldRange = range;
        float oldSpeed = attackSpeed;

        currentLevel++;

        switch (currentLevel)
        {
            case 2:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;

            case 3:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;

            case 4:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;
        }

        // อัปเดต UI สถานะอาวุธตลอดเวลา
        UpdateWeaponUI();

        // สร้างข้อความแสดงว่ามีการอัปเกรดอะไรบ้าง
        string upgradeMessage =
            $"Upgrade {Name} → Lv.{currentLevel}\n" +
            $"+{damage - oldDamage} DMG\n" +
            $"+{range - oldRange} RNG\n" +
            $"SPD = {attackSpeed}";

        ShowUpgradeText(upgradeMessage);

        Debug.Log(upgradeMessage);
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

        // อัปเดต UI ตอนเก็บอาวุธครั้งแรก
        UpdateWeaponUI();
    }
}
