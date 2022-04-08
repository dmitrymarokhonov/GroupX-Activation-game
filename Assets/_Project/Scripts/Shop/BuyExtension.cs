using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Relanima.Shop
{
    public class BuyExtension : MonoBehaviour, IPointerDownHandler
    {
        public Text priceText;
        public Image lockImage;
    
        public Shop.Extension extension;
        public GameObject shopManager;
        private Shop _shopManager;

        private void Start()
        {
            _shopManager = shopManager.GetComponent<Shop>();
            lockImage.gameObject.SetActive(!_shopManager.IsExtensionBought(extension));
            priceText.text = _shopManager.IsExtensionBought(extension) 
                ? "Unlocked" 
                : "Price: " + _shopManager.PriceOf(extension);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_shopManager.Buy(extension)) return;
        
            Unlock();
        }

        private void Unlock()
        {
            priceText.text = "Unlocked";
            lockImage.gameObject.SetActive(false);
        }
    }
}
