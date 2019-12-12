/**
 * Author:  Andrew Rudasics
 * Modified by Timothy Chong
 * Created: 7.7.2019
 * 
 * Class for pointing and clicking on certain things using the mouse or the VRPointer
 * 
 **/

using UnityEngine;

public class PointerSelector : MonoBehaviour
{
    [SerializeField]
    private float castDistance = Mathf.Infinity;
    private bool targeting;
    public DebugUI dbui;
    //shows a trace in the scene window
    public bool showDebugTrace;
    public ParticleSystem hitEffect;
    public RaycastHit raycast;

    public Transform debugObject;
    public GameObject globalVars;
    private int castMask;

    public GameObject rightHand;


    public bool doOnceLock = false;
    // Start is called before the first frame update
    void Start()
    {
        //castMask = 1 << 10;

        //Change this for masking a layer
        castMask = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool mouseDown = Input.GetMouseButtonDown(0);
        mouseDown = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0;
        print(mouseDown);


        //Camera.main.ScreenPointToRay(Input.mousePosition)
        if (Physics.Raycast(rightHand.transform.position, rightHand.transform.forward, out hit, castDistance))
        {
            //GameObject temp = hit.collider.gameObject;
            Vector3 RaycastDirection = (hit.point - rightHand.transform.position).normalized;
            Quaternion raycastangle = Quaternion.LookRotation(RaycastDirection);
            raycast = hit;

            // Selection Behavior
            if (mouseDown)
            {
                if (showDebugTrace)
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);
                }

                if(!doOnceLock){
                    doOnceLock = true;
                    //Set Location of the pointer
                    globalVars.GetComponent<GlobalVariables>().setClickedLocation(hit.point);
                    print(globalVars.GetComponent<GlobalVariables>().getClickedLocation());


                    //Create particle effect aligned towards wherever clicked
                    Instantiate(hitEffect, rightHand.transform.position, raycastangle);
                    debugObject.rotation = Quaternion.Euler(-90 + raycastangle.eulerAngles.x, raycastangle.eulerAngles.y, raycastangle.eulerAngles.z);
                }
                
            }
            else
            {
                doOnceLock = false;
            }
        }
        else
        {

        }
        
    }
    public RaycastHit getRaycastHit()
    {
        return raycast;
    }


}
