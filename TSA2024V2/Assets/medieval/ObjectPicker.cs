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
    public TextMeshProUGUI pickupText; // Assign this in the editor
    private float textHideDelay = 0.5f; // Delay in seconds before hiding the text
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

            // Draw ray in the Scene view for debugging
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * pickupDistance, Color.red);

            // Check for pickup objects
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
            // Hide the pickup text while holding an object
            pickupText.text = "";
        }

        // Pick up or drop the object
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
                        rb.isKinematic = true; // Disable gravity while picking up
                    }
                    currentObject.transform.SetParent(playerCamera.transform);
                    currentObject.transform.localPosition = new Vector3(0, 0, 1); // Adjust as needed
                    ObjectInteraction holder = currentObject.gameObject.GetComponent<ObjectInteraction>();
                    holder.isHeld = true;
                }
            }
            else
            {
                // Drop the object
                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; // Re-enable gravity
                    ObjectInteraction holder = currentObject.gameObject.GetComponent<ObjectInteraction>();
                    holder.isHeld = false;
                }
                currentObject.transform.SetParent(null);
                currentObject = null;
            }
        }
    }
}