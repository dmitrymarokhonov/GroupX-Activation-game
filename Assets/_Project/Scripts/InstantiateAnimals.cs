using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Relanima
{
    public static class InstantiateAnimals
    {
        private static Vector3 animalSpawnerLocation;
        private static Vector3 spawnLocation;
        private static Vector3 groundCheckLocation;
        private static Collider[] intersectingOtherElements;
        private static Collider[] intersectingGroundUnder;
        public static GameObject animalSpawner;
        public static GameObject animalContainer;
        private static float scaleLowLimit;
        private static float scaleHighLimit;

        public static void SpawnAnimals(GameObject spawnAnimal, int spawnAmount,
         float scaleLow, float scaleHigh)
        {
            animalContainer = GameObject.Find("AnimalContainer");
            animalSpawner = GameObject.Find("AnimalSpawner");
            animalSpawnerLocation = animalSpawner.transform.position;
            scaleLowLimit = scaleLow;
            scaleHighLimit = scaleHigh;

            int failedSpawnTries = 0;
            for(int i = 0; i < spawnAmount;)
            {
                spawnLocation = GetRandomAnimalSpawnPosition(animalSpawnerLocation);
                intersectingOtherElements = Physics.OverlapSphere(spawnLocation, 0.1f);
                groundCheckLocation = new Vector3(spawnLocation.x, 
                spawnLocation.y-5, spawnLocation.z);
                intersectingGroundUnder = Physics.OverlapSphere(groundCheckLocation, 0.5f);
                if(intersectingOtherElements.Length == 0 &&
                 intersectingGroundUnder.Length != 0)
                {
                    SpawnSingleAnimal(spawnLocation, spawnAnimal);
                    i++;
                }
                else 
                {
                    failedSpawnTries++;
                    if(failedSpawnTries > 50)
                    {
                        i = spawnAmount; // Stop trying to spawn
                    }
                }
            }
        }

        private static Vector3 GetRandomAnimalSpawnPosition(Vector3 spawnRequester)
        {
            var tempPosition = Random.insideUnitCircle * 120;
            var xPos = spawnRequester.x + tempPosition.x;
            var yPos = spawnRequester.y;
            var zPos = spawnRequester.z + tempPosition.y;
            return new Vector3(xPos, yPos, zPos);
        }

        private static void SpawnSingleAnimal(Vector3 spawnLocation, GameObject spawnAnimal)
        {   
            var newAnimal = UnityEngine.Object.Instantiate(spawnAnimal, spawnLocation, Quaternion.Euler(0,0,0));
            var scale = Random.Range(scaleLowLimit, scaleHighLimit);
            newAnimal.transform.localScale = new Vector3(scale, scale, scale);
            newAnimal.transform.parent = animalContainer.transform;
        }
    }
}