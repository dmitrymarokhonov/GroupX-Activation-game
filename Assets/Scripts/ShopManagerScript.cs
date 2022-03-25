using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float stars;
    public Text starCount;
    public Button notEnough;
    public Button ok;

    void Start()
    {
        starCount.text = "Your starcount is: " + stars.ToString();

        //ids
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
      

        //price
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 5;
        shopItems[2, 3] = 10;
        shopItems[2, 4] = 15;
        
        //quantity
        shopItems[3, 1] = 1;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (stars >= shopItems[2, ButtonRef.GetComponent<Buttoninfo>().ItemID])
        {
            if (shopItems[3, ButtonRef.GetComponent<Buttoninfo>().ItemID] < 1)
            {
                stars -= shopItems[2, ButtonRef.GetComponent<Buttoninfo>().ItemID];

                shopItems[3, ButtonRef.GetComponent<Buttoninfo>().ItemID]++;                

                starCount.text = "Your starcount is: " + stars.ToString();


            }

        }
        else
        {
            if(shopItems[3, ButtonRef.GetComponent<Buttoninfo>().ItemID] < 1)
            {
                notEnough.gameObject.SetActive(true);
                ok.gameObject.SetActive(true);
            }
            
        }




    }


}