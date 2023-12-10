using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventorySupportSetTMPText : MonoBehaviour
{
    public TMP_Text tmp_Text;
    public Inventory_Item inventory_Item;
    public int getItemQuantity(Inventory_Item inventory_Item){
        return inventory_Item.GetQuantity();
    }
    public string getItemName(Inventory_Item inventory_Item){
        return inventory_Item.getItemName();
    }



    public void SetTMPTextToQuantity(){
        tmp_Text.text = getItemQuantity(inventory_Item).ToString();
    }
    public void SetTMPTextToName(){
        tmp_Text.text = getItemName(inventory_Item).ToString();
    }
}
