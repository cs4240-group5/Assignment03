using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip animalSound;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.value < .01 && !source.isPlaying)
        {
            //source.PlayOneShot(animalSound);
            source.clip = animalSound;
            source.PlayDelayed(Random.Range(10f, 20f));
        }
    }
}
