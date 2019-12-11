using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    NavMeshAgent agent;
    Vector3 lastPosition;
    public Animator followerAnim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;

        float followerSpeed = velocity.magnitude;
        //print(velocity.magnitude);

        followerAnim.SetFloat("animspeed", (followerSpeed * 0.2f) + 1.0f);
        //print(followerAnim.GetFloat("animspeed"));
        goal.position = (Camera.main.GetComponent<GlobalVariables>().getClickedLocation());
        agent.destination = goal.position;
    }
}
