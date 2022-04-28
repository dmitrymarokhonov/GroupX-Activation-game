using UnityEngine;
using UnityEngine.AI;

namespace Relanima
{
    public static class InstantiateAnimals
    {
        private static GameObject _animalContainer;
        private static float _scaleLowLimit;
        private static float _scaleHighLimit;

        public static void SpawnAnimals(GameObject spawnAnimal, int spawnAmount, float scaleLow, float scaleHigh)
        {
            _animalContainer = GameObject.Find("AnimalContainer");
            var animalSpawnerLocation = GameObject.Find("AnimalSpawner").transform.position;
            _scaleLowLimit = scaleLow;
            _scaleHighLimit = scaleHigh;

            var failedSpawnTries = 0;
            for (var i = 0; i < spawnAmount;)
            {
                var spawnLocation = GetRandomAnimalSpawnPosition(animalSpawnerLocation);
                const int areaMask = NavMesh.AllAreas;

                var spawnLocationOnNavMesh = NavMesh.SamplePosition(spawnLocation, out var hit, 1f, areaMask);

                if (spawnLocationOnNavMesh)
                {
                    SpawnSingleAnimal(hit.position, spawnAnimal);
                    i++;
                }
                else
                {
                    failedSpawnTries++;
                    if (failedSpawnTries > 50)
                    {
                        return; // Stop trying to spawn
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
            var newAnimal = Object.Instantiate(spawnAnimal, spawnLocation, Quaternion.Euler(0,0,0));
            var scale = Random.Range(_scaleLowLimit, _scaleHighLimit);
            newAnimal.transform.localScale = new Vector3(scale, scale, scale);
            newAnimal.transform.parent = _animalContainer.transform;
        }
    }
}