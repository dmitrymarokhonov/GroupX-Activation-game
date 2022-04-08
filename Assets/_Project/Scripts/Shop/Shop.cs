using System.Collections.Generic;
using Relanima.Rewards;
using UnityEngine;
using UnityEngine.UI;

namespace Relanima.Shop
{
    public class Shop : MonoBehaviour
    {
        public Text starCount;
        public Button notEnough;
        public Button ok;
    
        public enum Extension
        {
            Cow,
            Deer,
            Panda,
            Giraffe
        }

        private readonly List<Extension> _boughtExtensions = new List<Extension> { Extension.Cow };
        private readonly Dictionary<Extension, int> _extensionPrice = new Dictionary<Extension, int>
        {
            {Extension.Cow, 0},
            {Extension.Deer, 5},
            {Extension.Panda, 10},
            {Extension.Giraffe, 15}
        };

        private void Start()
        {
            UpdateAvailableResourcesText();
        }
    
        public bool IsExtensionBought(Extension extension)
        {
            return _boughtExtensions.Contains(extension);
        }

        public int PriceOf(Extension extension)
        {
            return _extensionPrice[extension];
        }
    
        public bool Buy(Extension extension)
        {
            if (IsExtensionBought(extension)) return false;

            var resources = RewardManager.RewardCount();
            
            if (resources < PriceOf(extension))
            {
                DisplayInsufficientFunds();
                return false;
            }

            _boughtExtensions.Add(extension);
            RewardManager.instance.ReduceRewardsBy(PriceOf(extension));

            UpdateAvailableResourcesText();
            return true;
        }

        private void DisplayInsufficientFunds()
        {
            notEnough.gameObject.SetActive(true);
            ok.gameObject.SetActive(true);
        }

        private void UpdateAvailableResourcesText()
        {
            starCount.text = "You have " + RewardManager.RewardCount() + " stars left.";
        }
    }
}