using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    private List<GameObject> pairs = new List<GameObject>();
    private List<int> sequence = new List<int>();
    List<GameObject> buttonsPressed = new List<GameObject>();
    private bool submit = false;

    public Camera playerCamera;
    public GameObject portal;

    private void Start()
    {
        pairs.Add(transform.GetChild(0).gameObject);
        pairs.Add(transform.GetChild(1).gameObject);
        pairs.Add(transform.GetChild(2).gameObject);
        pairs.Add(transform.GetChild(3).gameObject);
        pairs.Add(transform.GetChild(4).gameObject);
        pairs.Add(transform.GetChild(5).gameObject);
        pairs.Add(transform.GetChild(6).gameObject);
        pairs.Add(transform.GetChild(7).gameObject);
        pairs.Add(transform.GetChild(8).gameObject);

        Invoke("RunSequence", 2.0f);  
    }

    private void RunSequence()
    {
        int randomCount = (int)Random.Range(2, 4);
        for(int i = 0; i < randomCount; i++)
        {
            int randomSelected = (int)Random.Range(0, pairs.Count);
            if(!sequence.Contains(randomSelected))
            {
                sequence.Add(randomSelected);
            }
            else
            {
                i--;
            }
        }
        for(int i = 0; i < sequence.Count; i++)
        {
            StartCoroutine(LightUp(pairs[sequence[i]], 5.0f));
        }
    }

    private IEnumerator LightUp(GameObject pair, float time)
    {
        pair.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(time);
        pair.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
    }

    private void Manager()
    {
        int correctCount = 0;

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10) &&
                hit.collider.gameObject.tag == "Button")
            {
                GameObject currentObject = hit.collider.gameObject;
                if (buttonsPressed.Contains(currentObject))
                {
                    currentObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    currentObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
                    buttonsPressed.Add(currentObject);
                }
            }
        }
    }
}
