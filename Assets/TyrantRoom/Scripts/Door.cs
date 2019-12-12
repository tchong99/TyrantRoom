using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public bool access1;
    public bool access2;
    public bool access3;
    public bool doorOpen;

    public Material doorDoneColor;

    public string levelToLoad;


    // Start is called before the first frame update
    void Start()
    {
        access1 = false;
        access2 = false;
        access3 = false;
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        access1 = key1.GetComponent<Key>().getTriggered();
        access2 = key2.GetComponent<Key>().getTriggered();
        access3 = key3.GetComponent<Key>().getTriggered();

        //print("Dooropen!!!");
        if (access1 && access2 && access3)
        {
            //print("Dooropen!!!");
            doorOpen = true;
            gameObject.GetComponent<MeshRenderer>().material = doorDoneColor;

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && doorOpen) 
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
