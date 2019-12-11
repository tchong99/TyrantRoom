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

    private int castMask;

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

        

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, castDistance))
        {
            //GameObject temp = hit.collider.gameObject;
            Vector3 RaycastDirection = (hit.point - Camera.main.transform.position).normalized;
            Quaternion raycastangle = Quaternion.LookRotation(RaycastDirection);
            raycast = hit;

            // Selection Behavior
            if (mouseDown)
            {
                if (showDebugTrace)
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);
                }

                //Set Location of the pointer
                Camera.main.GetComponent<GlobalVariables>().setClickedLocation(hit.point);
                print(Camera.main.GetComponent<GlobalVariables>().getClickedLocation());


                //Create particle effect aligned towards wherever clicked
                Instantiate(hitEffect, Camera.main.transform.position, raycastangle);
                debugObject.rotation = Quaternion.Euler(-90 + raycastangle.eulerAngles.x, raycastangle.eulerAngles.y, raycastangle.eulerAngles.z);
            }
            else
            {

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
