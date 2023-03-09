using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private ScoreManager scoreManager;
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
            addPoint = 20;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("tiger") && collision.gameObject.CompareTag("chicken")) {
            addPoint = 15;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("rabbit") && collision.gameObject.CompareTag("carrot")) {
            addPoint = 10;
            Destroy(gameObject);
        } else if (gameObject.CompareTag("bear") && collision.gameObject.CompareTag("fish")) {
            addPoint = 5;
            Destroy(gameObject);
        }

        scoreManager.AddPoint(addPoint);
        //ScoreManager.instance.AddPoint(addPoint);
    }
}
