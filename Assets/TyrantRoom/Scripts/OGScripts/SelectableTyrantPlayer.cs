using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTyrantPlayer : Selectable
{
    [SerializeField]
    private Material def, hover, selected;
    private bool isSelected = false;
    public Animator anim;
    public int poseNum;
    public AudioSource sound;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = def;
    }

    // This method should set the pose parameter in the animator to poseNum 
    public override GameObject OnSelect()
    {
        isSelected = true;
        // TODO:
        // Set the animator pose value here:
        anim.SetInteger("pose", poseNum);

        // Set the object's mesh renderer to the selected material
        gameObject.GetComponent<MeshRenderer>().material = selected;
        // Play the Tyrant's sound clip
        sound.Play();
        return this.gameObject;
    }

    public override GameObject OnHover()
    {
        // TODO:
        // Copy the code from Selectable Tile OnHover Here
        if (gameObject.GetComponent<MeshRenderer>().material != hover && !isSelected)
        {
            gameObject.GetComponent<MeshRenderer>().material = hover;
        }

        return this.gameObject;
    }

    public override void OnDeselect()
    {
        isSelected = false;
        // TODO:
        // Set the animator's pose value to 0
        anim.SetInteger("pose", 0);
        // Set the object's mesh renderer to the def material
        gameObject.GetComponent<MeshRenderer>().material = def;


    }
}
