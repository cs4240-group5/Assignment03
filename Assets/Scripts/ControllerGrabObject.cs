using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public float bulletSpeed;

    public Vector3 breadOriginalPosition;
    public Vector3 chickenOriginalPosition;
    public Vector3 carrotOriginalPosition;
    public Vector3 fishOriginalPosition;
    public GameObject collidingObject; 
    public GameObject objectInHand;
    public GameObject objectThrown;
    public AudioClip grabAudio;
    public AudioClip shootAudio;
    private bool shot;

    float timer = 0f;
    int waitingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        breadOriginalPosition = GameObject.FindGameObjectsWithTag("bread")[0].transform.position;
        chickenOriginalPosition = GameObject.FindGameObjectsWithTag("chicken")[0].transform.position;
        carrotOriginalPosition = GameObject.FindGameObjectsWithTag("carrot")[0].transform.position;
        fishOriginalPosition = GameObject.FindGameObjectsWithTag("fish")[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            if (grabAction.GetLastStateDown(handType))
            {   
                print("grab");
                if (collidingObject)
                {
                GrabObject();
                }
            }

        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ShootObject();
                shot = true;
            }
        }
        if (shot)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                if (objectThrown.CompareTag("bread"))
                {
                    objectThrown.transform.position = breadOriginalPosition;
                }
                if (objectThrown.CompareTag("chicken"))
                {
                    objectThrown.transform.position = chickenOriginalPosition;
                }
                if (objectThrown.CompareTag("carrot"))
                {
                    objectThrown.transform.position = carrotOriginalPosition;
                }
                if (objectThrown.CompareTag("fish"))
                {
                    objectThrown.transform.position = fishOriginalPosition;
                }
                timer = 0;
                shot = false;
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                       
    }
    

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    private void GrabObject()
    {
        AudioSource.PlayClipAtPoint(grabAudio, transform.position);
        objectInHand = collidingObject;
        objectThrown = objectInHand;
        collidingObject = null;
        var joint = AddFixedJoint();
        //objOriginalPosition = objectInHand.transform.position;
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ShootObject()
    {
        if (GetComponent<FixedJoint>())
        {
            AudioSource.PlayClipAtPoint(shootAudio, transform.position);
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            Rigidbody objToShoot = objectInHand.GetComponent<Rigidbody>();
            objToShoot.AddForce(controllerPose.transform.forward * bulletSpeed,ForceMode.Impulse);
        }
        objectInHand = null;
    }

}
