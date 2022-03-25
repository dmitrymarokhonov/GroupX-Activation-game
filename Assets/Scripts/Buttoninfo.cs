using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttoninfo : MonoBehaviour
{
    public int ItemID;
    public Text Price;
    public GameObject ShopManager;
    public Image Lock;


    // Update is called once per frame
    void Update()
    {
        if (ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID] < 1)
        {
            Price.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        }
        else
        {
            Price.text = "Unlocked";
            Lock.gameObject.SetActive(false);
        }
            
        

    }
}
