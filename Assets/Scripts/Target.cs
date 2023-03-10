using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioClip successAudio;
    public AudioClip failureAudio;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy the target on contact with a bullet
    private void OnCollisionEnter(Collision collision)
    {
        //Update Score
        int addPoint = 0;

        if (gameObject.CompareTag("lb_bird") && collision.gameObject.CompareTag("bread")){
            AudioSource.PlayClipAtPoint(successAudio, transform.position);
            addPoint = 20;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("tiger") && collision.gameObject.CompareTag("chicken")) {
            AudioSource.PlayClipAtPoint(successAudio, transform.position);
            addPoint = 15;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("rabbit") && collision.gameObject.CompareTag("carrot")) {
            AudioSource.PlayClipAtPoint(successAudio, transform.position);
            addPoint = 10;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("bear") && collision.gameObject.CompareTag("fish")) {
            AudioSource.PlayClipAtPoint(successAudio, transform.position);
            addPoint = 5;
            Destroy(gameObject);
        } else
        {
            AudioSource.PlayClipAtPoint(failureAudio, transform.position);
        }

        //scoreManager.AddPoint(addPoint);
        ScoreManager.instance.AddPoint(addPoint);
    }
}
