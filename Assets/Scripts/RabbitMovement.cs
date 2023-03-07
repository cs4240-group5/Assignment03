using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    public float rotatevalue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,rotatevalue,0) * Time.deltaTime);
        
    }

 //   private void OnCollisionEnter(Collision collision)
 //   {
 //       gameObject.transform.Rotate(0.0f,180.0f,0.0f, Space.Self);
 //   }
}
