using UnityEngine;

// สมมติว่าในคลาส Weapon มีตัวแปร protected Player playerOwner;
// ถ้าไม่มี ให้เพิ่มในคลาส Sword เลย
public class Sword : Weapon
{
    // *** เพิ่มตัวแปรนี้ถ้าคุณไม่ได้เพิ่มในคลาส Weapon ***
    protected Player playerOwner;


    protected override void Awake()
    {
        base.Awake();

        damage = 10;
        range = 1f;
        attackSpeed = 1f;
        currentLevel = 1;
        maxLevel = 6;

        // เซ็ต radius ตอนเริ่มเกม


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
                damage += 10;
                range += 1f;
                attackSpeed = 3f;
                break;
            case 3:
                damage += 20;
                range += 1f;
                attackSpeed = 3f;
                break;
            case 4:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;
            case 5:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;
            case 6:
                damage += 5;
                range += 1f;
                attackSpeed = 3f;
                break;
        }

        // *** การแก้ไข: อัพเดตสถานะของ Player ทันทีที่ดาบเลเวลอัพ ***
        if (playerOwner != null)
        {
            // ไม่ต้องลบค่าเก่าออก เพราะ Player.GetFinalDamage() จะดึงค่า damage ใหม่จากดาบเอง
            // แต่ต้องอัพเดต Attack Speed ให้ Player
            playerOwner.SetAttackSpeed(attackSpeed);

            // ถ้าคุณต้องการให้ค่า Character.Damage อัพเดตโดยตรง:
            //playerOwner.Damage = playerOwner.Damage - oldDamage + damage; 
            // **แนะนำให้ใช้วิธี GetFinalDamage ใน Player แทนการแก้ไข Player.Damage โดยตรงแบบนี้**
        }


        UpdateWeaponUI();

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

        // *** การแก้ไข: เก็บ Reference ของ Player ที่สวมใส่อาวุธนี้ ***
        playerOwner = player;
        player.equippedWeapon = this;
        Vector3 swordUp = new Vector3(0, 0, 90);
        itemcollider.enabled = false;
        transform.parent = player.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(swordUp);

        // ตอน OnCollect ไม่ต้องบวก Damage เข้าไปที่ Player.Damage
        // เพราะ Player.GetFinalDamage() จะรวมค่า damage จากดาบ (equippedWeapon.damage) เอง
        // ถ้าคุณยังต้องการบวก/ลบตรงนี้:
        // player.Damage += damage; 

        player.SetAttackSpeed(attackSpeed);
        UpdateWeaponUI();
    }

}