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

    private GameObject collidingObject; 
    private GameObject objectInHand;
    public AudioClip grabAudio;
    public AudioClip shootAudio;
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
        collidingObject = null;
        var joint = AddFixedJoint();
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
