using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatisfactionController : MonoBehaviour
{
    public float current = 0.0f;
    private float max = 10.0f;
    private float addition;
    private GameObject symbol;
    private bool draining;
    private float drainModifier = 0.5f;
    private float drainHappinessSeconds = 5;

    public ParticleSystem fireworkParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        addition = max / 10;
        symbol = transform.Find("Heart").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!draining) return;
        //
        // if (current <= 0)
        // {
        //     current = 0;
        //     draining = false;
        //     symbol.SetActive(false);
        //     return;
        // }
        //
        // current -= (Time.deltaTime * drainModifier);
    }

    private void OnMouseDown()
    {
        if (draining) return;

        var particlePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z); 
        
        Instantiate(fireworkParticle, particlePosition, fireworkParticle.transform.rotation);
        
        // Should we allow prolonging of happy status?
        // if (current + addition > max)
        // {
        //     current = max;
        //     return;
        // }
        
        current += addition;

        if (current < max) return;

        symbol.SetActive(true);
        draining = true;
        StartCoroutine(DrainHappinessRoutine());
    }

    IEnumerator DrainHappinessRoutine()
    {
        yield return new WaitForSeconds(drainHappinessSeconds);
        draining = false;
        current = 0;
        symbol.SetActive(false);
    }
}
