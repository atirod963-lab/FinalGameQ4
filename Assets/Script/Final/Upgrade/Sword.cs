using UnityEngine;

public class Sword : Weapon
{
  

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

        Vector3 swordUp = new Vector3(0, 0, 90);
        itemcollider.enabled = false;
        transform.parent = player.RightHand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(swordUp);
        player.Damage += Damage;
        player.SetAttackSpeed(attackSpeed);
        UpdateWeaponUI();
    }
    
}
