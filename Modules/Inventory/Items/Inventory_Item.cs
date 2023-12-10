using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class Inventory_Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private SO_Items itemID;
    [SerializeField] private int quantity;
    
    public void Use(){
        itemID.Use();
    }

    public string getItemName(){
        return itemName;
    }

    public void setItemName(string name){
        itemName = name;
    }

    public int GetQuantity(){
        return quantity;
    }
    public void SetQuantity(int ammount){
        quantity = ammount;
    }

    public void AddQuantity(int ammount){
        quantity += ammount;
    }

    public void RemoveQuantity(int ammount){
        quantity -= ammount;
    }

}
