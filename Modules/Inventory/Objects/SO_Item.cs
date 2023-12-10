using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "Base_Item", menuName = "RPGBox/Modules/Inventory/Item", order = 1)]
public class SO_Items : ScriptableObject
{
    [Header("Item Info")]
    public int MaxQuantity;
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool Stackable;
    public bool Consumable;
    public bool Equipable;
    public bool QuestItem;
    public bool Unique;
    public bool Sellable;
    [Space(3)]
    [Header("Events")]
    public UnityEvent OnUse;
    public UnityEvent OnEquip;
    public UnityEvent OnUnEquip;
    public UnityEvent OnSell;


    public virtual void Use()
    {
        Debug.Log("Using " + Name);
        OnUse.Invoke();
    }

    public virtual void Equip()
    {
        Debug.Log("Equipping " + Name);
        OnEquip.Invoke();
    }

    public virtual void UnEquip()
    {
        Debug.Log("UnEquipping " + Name);
        OnUnEquip.Invoke();
    }

    public virtual void Sell()
    {
        Debug.Log("Selling " + Name);
        OnSell.Invoke();
    }
}
