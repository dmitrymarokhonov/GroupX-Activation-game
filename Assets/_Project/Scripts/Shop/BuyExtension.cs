using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Relanima.Shop
{
    public class BuyExtension : MonoBehaviour, IPointerDownHandler
    {
        public Text priceText;
        public Text unlockedText;
        public Image lockImage;
    
        public Shop.Extension extension;
        public GameObject shopManager;
        private Shop _shopManager;

        private void Start()
        {
            _shopManager = shopManager.GetComponent<Shop>();

            if (!_shopManager.IsExtensionBought(extension)) return;
            lockImage.gameObject.SetActive(false);
            priceText.gameObject.SetActive(false);
            unlockedText.gameObject.SetActive(true);
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_shopManager.Buy(extension)) return;
        
            Unlock();
        }

        public int PriceOf()
        {
            return _shopManager.PriceOf(extension);
        }

        private void Unlock()
        {
            // priceText.text = "Unlocked";
            lockImage.gameObject.SetActive(false);
            priceText.gameObject.SetActive(false);
            unlockedText.gameObject.SetActive(true);
        }
    }
}
