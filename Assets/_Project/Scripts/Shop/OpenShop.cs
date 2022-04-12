using UnityEngine;
using UnityEngine.UI;

namespace Relanima.Shop
{
    public class OpenShop : MonoBehaviour 
    {
        public GameObject shopPanel;
        public Text buttonText;

        public void ToggleShopOpen()
        {
            if (shopPanel == null) return;
        
            var isOpen = shopPanel.activeSelf;
            shopPanel.SetActive(!isOpen);
            // buttonText.text = !isOpen ? "CLOSE SHOP" : "SHOP";
        }

        public bool IsShopOpen()
        {
            return shopPanel.activeSelf;
        }
    }
}
