using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    public float speed = 0;
    private Animator stagAnim;

    // Start is called before the first frame update
    void Start()
    {
        stagAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -120)
        {
            // moveForward = false;
            transform.Rotate(Vector3.up, 180, Space.Self);
        }
        else if (transform.position.z > -100)
        {
            transform.Rotate(Vector3.up, 180, Space.Self);
        }
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void ToggleAnimalMovement()
    {
        if (speed > 0)
        {
            speed = 0;
        }
        else
        {
            speed = 5.0f;
        }
    }
}
