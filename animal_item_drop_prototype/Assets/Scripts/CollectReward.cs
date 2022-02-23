using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectReward : MonoBehaviour
{
    public ParticleSystem fireworkParticle;
    public Transform parent;
    private void OnMouseDown()
    {
        var particlePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z); 
        Instantiate(fireworkParticle, particlePosition, fireworkParticle.transform.rotation);
        GetComponentInParent<DropReward>().CollectStar();
        Destroy(gameObject);
    }
}