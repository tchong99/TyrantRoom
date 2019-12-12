using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHands : MonoBehaviour
{
    public Material mat; // this is the mat you want the hands changed to. 
    private GameObject handLeft;
    private GameObject handRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    // 
    void Update()
    {
        // find and grab the hand objects
        handRight = GameObject.Find("hand_right_renderPart_0");
        handLeft = GameObject.Find("hand_left_renderPart_0");

        if(handRight != null)
        {
            handRight.GetComponent<Renderer>().material = mat;
        }
        if (handLeft != null)
        {
            handLeft.GetComponent<Renderer>().material = mat;
        }

        // if i've found the hands change the texture
        if (handRight != null && handLeft != null)
        {
            Destroy(GetComponent<SwitchHands>()); // remove this script so it stops running.
        }
    }
}
