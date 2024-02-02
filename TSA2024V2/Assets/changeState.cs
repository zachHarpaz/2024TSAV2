using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeState : MonoBehaviour
{
    public PipeManager pm;
    public int wheelIndex;
    public Vector3 rotationAxis = Vector3.right;
    // Update is called once per frame



    public void changeVariable()
    {
        pm.ToggleWheel(wheelIndex);
    }
}
