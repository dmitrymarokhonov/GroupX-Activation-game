using UnityEngine;
using System.Collections;
using Relanima.GameManager;

public static class ExtensionMethods
{

    public static void InstantiateBoughtExtension(this Extension boughtItem,
     GameObject boughtItemPrefab)
    {
        switch (boughtItem)
        {
            case Extension.Panda:
                addAnimals(boughtItemPrefab);
                break;
            default:
                addAnimals(boughtItemPrefab);
                break;
        }
    }
    private static void addAnimals(GameObject boughtItemPrefab)
    {
        int spawnAmount = 15;
        float scaleLowLimit = 0.7f;
        float scaleHighLimit = 1.2f;
        Relanima.InstantiateAnimals.SpawnAnimals(boughtItemPrefab, spawnAmount,
         scaleLowLimit, scaleHighLimit);
    }
}