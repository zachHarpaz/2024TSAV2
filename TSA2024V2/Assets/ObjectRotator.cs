using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectRotator : MonoBehaviour
{
    public float holdDuration = 2.0f; 
    private bool isHolding = false; 
    private float holdTimer = 0f; 
    private GameObject currentButton = null; 
    public bool myBoolean = false;
    public TextMeshProUGUI tm;
    public changeState cs;
    void Update()
    {



        Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit1;
        Debug.DrawRay(ray1.origin, ray1.direction * 100, Color.red, 2f);

        if (Physics.Raycast(ray1, out hit1))
        {

            if (hit1.collider.CompareTag("Button"))
            {
                tm.text = "Left click and hold to turn";
            }
            else
            {
                tm.text = "";
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f); 

            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.CompareTag("Button"))
                {
                    isHolding = true;
                    currentButton = hit.collider.gameObject;
                    cs = currentButton.GetComponent<changeState> ();

                    holdTimer = 0f; 
                }
            }
        }

        if (Input.GetMouseButton(0) && isHolding)
        {
            holdTimer += Time.deltaTime;

            if (currentButton != null)
            {

                currentButton.transform.Rotate(0, 1, 0);

            }

            if (holdTimer >= holdDuration)
            {
                cs.changeVariable();
                isHolding = false; 
 
            }
        }

   
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
            currentButton = null;
            holdTimer = 0f;
        }
    }
}
