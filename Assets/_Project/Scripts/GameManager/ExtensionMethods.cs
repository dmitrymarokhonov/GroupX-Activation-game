using UnityEngine;

namespace Relanima.GameManager
{
    public static class ExtensionMethods
    {
        public static void AddAnimals(GameObject boughtItemPrefab)
        {
            int spawnAmount = 15;
            float scaleLowLimit = 0.7f;
            float scaleHighLimit = 1.2f;
            InstantiateAnimals.SpawnAnimals(boughtItemPrefab, spawnAmount,
                scaleLowLimit, scaleHighLimit);
        }
    }
}