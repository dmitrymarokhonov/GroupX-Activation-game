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
    
        public Extension extension;
        public Shop shopManager;

        private void Start()
        {
            if (!shopManager.IsExtensionBought(extension)) return;
            Unlock();
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!shopManager.Buy(extension)) return;
        
            Unlock();
        }

        public int PriceOf()
        {
            return shopManager.PriceOf(extension);
        }

        private void Unlock()
        {
            lockImage.gameObject.SetActive(false);
            priceText.gameObject.SetActive(false);
            unlockedText.gameObject.SetActive(true);
        }
    }
}
