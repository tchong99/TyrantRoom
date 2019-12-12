/**
 * Author:  Andrew Rudasics
 * Created: 7.7.2019
 * 
 * Abstract class for selectable objects. All selectables should inherit from this
 * class and implement OnSelect
 * 
 **/

using UnityEngine;

public class PointerClick : MonoBehaviour
{
    [SerializeField]
    private float castDistance = Mathf.Infinity;
    private GameObject selected, hover;
    private bool targeting;
    public DebugUI dbui;
    //shows a trace in the scene window
    public bool showDebugTrace;

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
            GameObject temp = hit.collider.gameObject;

            // Selection Behavior
            if (mouseDown)
            {
                if (showDebugTrace)
                {
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);
                }

                //Set Location of the pointer
                Camera.main.GetComponent<GlobalVariables>().setClickedLocation(hit.point);
                //print(Camera.main.GetComponent<GlobalVariables>().getClickedLocation());

                // Deselect Currently Selected
                //print("clicked");
                if (selected != null && temp != selected)
                    selected.GetComponent<Selectable>().OnDeselect();
                // Select hovered object
                selected = temp.GetComponent<Selectable>().OnSelect();
                hover = selected;
                print(selected.ToString());
                //dbui.SetSelected(selected);
            }
            else
            {
                
            }
        }
        else
        {
            if (mouseDown)
            {
                if (selected != null)
                {
                    selected.GetComponent<Selectable>().OnDeselect();
                    selected = null;
                }
            }

            if (hover != null && hover != selected)
            {
                hover.GetComponent<Selectable>().OnDeselect();
                hover = null;
            }
        }
    }

}
