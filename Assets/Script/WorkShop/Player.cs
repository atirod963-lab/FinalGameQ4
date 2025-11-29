using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Weapon equippedWeapon;

    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;
    public List<Item> inventory = new List<Item>();

    Vector3 _inputDirection;
    bool _isAttacking = false;
    bool _isInteract = false;
    private float TimeToAttack = 1f;
    protected float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;

        StartCoroutine(AutoRegen());
    }
    public void SetAttackSpeed(float speed)
    {
        TimeToAttack = 1f / speed;    // ยิ่ง speed สูง ยิ่งตีถี่
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        Attack(_isAttacking);
        Interact(_isInteract);
    }
    public void Update()
    {
        HandleInput();
    }
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public int GetFinalDamage()
    {
        // ใช้วิธีนี้เมื่อ Character.Damage คือ Base Damage และ equippedWeapon.damage คือ Weapon Damage
        // *** ตรวจสอบให้แน่ใจว่า equippedWeapon ถูกตั้งค่าไว้ใน OnCollect ของ Weapon ***
        int baseDamage = Damage; // มาจาก Character (Base Damage)
        int weaponDamage = equippedWeapon ? equippedWeapon.Damage : 0;

        return baseDamage + weaponDamage;
    }

    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);
        if (Input.GetMouseButtonDown(0))
        {
            _isAttacking = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isInteract = true;
        }

    }
    public void Attack(bool isAttacking)
    {
        if (timer < 0)
        {
            timer = TimeToAttack;
        }
        if (isAttacking == true)
        {
            animator.SetTrigger("Attack");
            var e = InFront as Idestoryable;
            if (e != null)
            {
                // *** แก้ไข: ใช้ GetFinalDamage() เพื่อรวม Base Damage + Weapon Damage ที่อัพเกรดแล้ว ***
                int finalDamage = GetFinalDamage();
                e.TakeDamage(finalDamage);
                Debug.Log($"{gameObject.name} attacks for {finalDamage} damage.");
            }
            _isAttacking = false;

        }
    }
    private void Interact(bool interactable)
    {
        if (interactable)
        {
            IInteractable e = InFront as IInteractable;
            if (e != null)
            {
                e.Interact(this);
            }
            _isInteract = false;

        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        GameManager.instance.UpdateHealthText(health, maxHealth);
        GameManager.instance.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        GameManager.instance.UpdateHealthBar(health, maxHealth);
        GameManager.instance.UpdateHealthText(health, maxHealth);
    }

    private System.Collections.IEnumerator AutoRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);

            if (health < maxHealth)
            {
                Heal(2);
            }
        }
    }


}