using System.Collections.Generic;
using Relanima.Rewards;
using UnityEngine;
using UnityEngine.UI;
using Relanima.GameManager;

namespace Relanima.Shop
{
    public class Shop : MonoBehaviour
    {
        public Button notEnough;
        public Button ok;
        
        private readonly Dictionary<Extension, int> _extensionPrice = new Dictionary<Extension, int>
        {
            {Extension.Cow, 0},
            {Extension.Deer, 5},
            {Extension.Panda, 10},
            {Extension.Giraffe, 15}
        };

        public bool IsExtensionBought(Extension extension)
        {
            return GameManagerElement.instance.GetBoughtExtensionsList().Contains(extension);
        }

        public int PriceOf(Extension extension)
        {
            return _extensionPrice[extension];
        }
    
        public bool Buy(Extension extension)
        {
            if (IsExtensionBought(extension)) return false;

            var resources = GameManagerElement.instance.GetScore();
            
            if (resources < PriceOf(extension))
            {
                DisplayInsufficientFunds();
                return false;
            }
            
            GameManagerElement.instance.AddBoughtExtension(extension);
            GameManagerElement.instance.AddBoughtAnimalToTheGame(extension);
            RewardManager.instance.ReduceRewardsBy(PriceOf(extension));
            
            return true;
        }

        private void DisplayInsufficientFunds()
        {
            notEnough.gameObject.SetActive(true);
            ok.gameObject.SetActive(true);
        }
    }
}