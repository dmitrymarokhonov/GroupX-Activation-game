using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour { 


    public GameObject shop;
    public Text shopStatus;

    public void openShop()
    {
        if(shop != null)
        {
            bool isOpen = shop.activeSelf;

            shop.SetActive(!isOpen);

            if (!isOpen)
            {
                shopStatus.text = "CLOSE SHOP";
            }
            else
            {
                shopStatus.text = "SHOP";
            }
        }
    }
    
}
