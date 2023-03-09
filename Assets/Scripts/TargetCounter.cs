using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text countText;
    public GameObject tigerParent;
    public GameObject rabbitParent;
    private int totalanimalcount = 0;

    // Update is called once per frame
    void Update()
    {
        totalanimalcount = 0;
        foreach (Transform child in tigerParent.transform)
        {
            // If the child object is active, increment the active child count
            if (child.gameObject.activeSelf)
            {
                totalanimalcount++;
            }
        }
        foreach (Transform child in rabbitParent.transform)
        {
            // If the child object is active, increment the active child count
            if (child.gameObject.activeSelf)
            {
                totalanimalcount++;
            }
        }

        
        countText.text = "Animals Left: " + totalanimalcount.ToString();
        
    }

    /*

    public void animalHit()
    {
        foreach (Transform child in tigerParent.transform)
        {
            // If the child object is active, increment the active child count
            if (child.gameObject.activeSelf)
            {
                totalanimalcount++;
            }
        }
        foreach (Transform child in rabbitParent.transform)
        {
            // If the child object is active, increment the active child count
            if (child.gameObject.activeSelf)
            {
                totalanimalcount++;
            }
        }

        countText.text = "Animals Left: " + totalanimalcount.ToString();
    }

    */

    
}
