using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ObjectPicker : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupDistance = 5f;
    public KeyCode pickupKey = KeyCode.E;
    private GameObject currentObject = null;
    public int score = 0;
    public TextMeshProUGUI pickupText; 
    private float textHideDelay = 0.5f; 
    public GameObject portal;
    void Update()
    {
        if (score >= 5){
            portal.SetActive(true);
        }

        if (currentObject == null)
        {
            RaycastHit hit;
            bool canPickup = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance);

            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * pickupDistance, Color.red);

            if (canPickup && hit.collider.gameObject.tag == "PickupObject")
            {
                pickupText.text = "Click E to pick up";
            }
            else
            {
                pickupText.text = "";
            }
        }
        else
        {
            pickupText.text = "Press E to drop item";
        }

        if (Input.GetKeyDown(pickupKey))
        {
            if (currentObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupDistance) &&
                    hit.collider.gameObject.tag == "PickupObject")
                {
                    currentObject = hit.collider.gameObject;
                    Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true; 
                    }
                    currentObject.transform.SetParent(playerCamera.transform);
                    currentObject.transform.localPosition = new Vector3(0, 0, 1); 
                    ObjectInteraction holder = currentObject.gameObject.GetComponent<ObjectInteraction>();
                    holder.isHeld = true;
                }
            }
            else
            {

                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; 
                    ObjectInteraction holder = currentObject.gameObject.GetComponent<ObjectInteraction>();
                    holder.isHeld = false;
                }
                currentObject.transform.SetParent(null);
                currentObject = null;
            }
        }
    }
}