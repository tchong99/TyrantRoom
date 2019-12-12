using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool isTriggered;
    public Material green;
    public Material red;
    public Collider overlap;
    public GameObject follower;

    private int mass;
    private int threshold;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        overlap = GetComponent<BoxCollider>();
        gameObject.GetComponent<MeshRenderer>().material = red;
        mass = 0;
        threshold = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("follower") && isTriggered == false)
        {
            
            mass++;
            if (mass > threshold)
            {
                gameObject.GetComponent<MeshRenderer>().material = green;
                isTriggered = true;
            }
        }
    }

    public bool getTriggered()
    {
        return isTriggered;
    }
}
