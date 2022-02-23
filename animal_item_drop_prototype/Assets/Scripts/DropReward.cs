using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropReward : MonoBehaviour
{
    public GameObject rewardItem;

    public Text starCounter;
    public int rewardLimit = 3;
    public int happinessPersentage = 100;
    public int happinessForRewards = 50;

    private Transform parent;
    private int starsCollected = 0;
    private float spawnedRewardsCount = 0;
    private int randomValue;
    private Vector2 tempPosition;

    void Start()
    {
        starCounter.text = starsCollected.ToString();
        InvokeRepeating("TrySpawnReward", 1.0f, 3.0f); // Runs every 3 seconds
    }

    void SpawnReward()
    {
        tempPosition = Random.insideUnitCircle.normalized * 3;
        var itemPosition = new Vector3(transform.position.x + tempPosition.x,
        transform.position.y + 0.5f, transform.position.z + tempPosition.y);
        GameObject newReward = Instantiate(rewardItem, itemPosition,
         Quaternion.Euler(-90,0,0));
        newReward.transform.SetParent(transform);
        spawnedRewardsCount += 1;
    }

    public void CollectStar(){
        spawnedRewardsCount -= 1;
        starsCollected += 1;
        starCounter.text = starsCollected.ToString();
        
    }

    void TrySpawnReward(){
        randomValue = Random.Range(happinessForRewards,120);

        if(spawnedRewardsCount < rewardLimit && happinessPersentage >= randomValue){
            SpawnReward();
        }
    }
}