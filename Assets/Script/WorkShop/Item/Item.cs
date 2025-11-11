using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Item : Identity
{
    private Collider _collider;
    public AudioClip SoundUsedItem;
    protected Collider itemcollider {
        get {
            if (_collider == null) {
                _collider = GetComponent<Collider>();
                _collider.isTrigger = true;
            }
            return _collider;
        }
    }

    public override void SetUP() {
        base.SetUP();
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }
    public Item() { 
    }
    public Item(Item item)
    {
        this.Name = item.Name;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            OnCollect(player);
            SoundManager.instance.PlaySFX(SoundUsedItem);
        }
    }
    public virtual void OnCollect(Player player) { 
        Debug.Log($"Collected {Name}");
    }
    public virtual void Use(Player player)
    {
        Debug.Log($"Using {Name}");
    }

}
