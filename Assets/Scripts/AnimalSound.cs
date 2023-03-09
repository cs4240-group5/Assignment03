using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    public AudioClip animalSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.value < .1)
        {
            GetComponent<AudioSource>().PlayOneShot(animalSound);
        }
    }
}
