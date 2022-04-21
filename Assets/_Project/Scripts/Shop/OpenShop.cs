using UnityEngine;

namespace Relanima.Shop
{
    public class OpenShop : MonoBehaviour 
    {
        public GameObject shopPanel;

        public void ToggleShopOpen()
        {
            if (shopPanel == null) return;
        
            var isOpen = shopPanel.activeSelf;
            shopPanel.SetActive(!isOpen);
        }

        public bool IsShopOpen()
        {
            return shopPanel.activeSelf;
        }
    }
}
