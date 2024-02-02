using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SimonController : MonoBehaviour
{
    private List<GameObject> pairs = new List<GameObject>();
    public List<int> sequence = new List<int>();
    public List<int> buttonsPressed = new List<int>();
    private bool submit = false;
    [SerializeField] Transform simonGroup;
    [SerializeField] int numRounds = 5;
    [SerializeField] TextMeshProUGUI roundsRemaining;

    public Camera playerCamera;
    public GameObject portal;
    public TextMeshProUGUI pickupText;
    private void Start()
    {
        pairs.Add(simonGroup.GetChild(0).gameObject);
        pairs.Add(simonGroup.GetChild(1).gameObject);
        pairs.Add(simonGroup.GetChild(2).gameObject);
        pairs.Add(simonGroup.GetChild(3).gameObject);
        pairs.Add(simonGroup.GetChild(4).gameObject);
        pairs.Add(simonGroup.GetChild(5).gameObject);
        pairs.Add(simonGroup.GetChild(6).gameObject);
        pairs.Add(simonGroup.GetChild(7).gameObject);
        pairs.Add(simonGroup.GetChild(8).gameObject); 
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
        transform.position = new Vector3(-7f, 14.5f, -6.6f);
        GetComponent<CharacterController>().enabled = false;
        pair.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(time);
        GetComponent<CharacterController>().enabled = true;
        pair.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
    }

    public void StartManager()
    {
        RunSequence();
        StartCoroutine(CheckSequence());
    }

    private IEnumerator CheckSequence()
    {
        yield return new WaitForSeconds(25);
        if (sequence.Count == buttonsPressed.Count)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if ((sequence[i] + 1) != buttonsPressed[i])
                {
                    //Debug.Log("You lose");
                    roundsRemaining.text = "You lose";
                    yield return new WaitForSeconds(3);
                    Restart();
                }
            }
            //Debug.Log("You win!");
            sequence.Clear();
            buttonsPressed.Clear();
            for(int i = 0; i < pairs.Count; i++)
            {
                pairs[i].transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
            }
            numRounds--;
            roundsRemaining.text = "Rounds remaining: " + numRounds;
            if (numRounds == 0)
            {
                portal.SetActive(true);
            }
            else
            {
                StartManager();
            }
        }
        else
        {
            roundsRemaining.text = "You lose";
            yield return new WaitForSeconds(3);
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void Update()
    {
        RaycastHit hit1;
        bool canPickup = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit1, 5);

        //Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 20, Color.red);

        if (canPickup && hit1.collider.gameObject.tag == "Button")
        {
            pickupText.text = "Press E to select the button.";
        }
        else
        {
            pickupText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5) &&
                hit.collider.gameObject.tag == "Button")
            {
               
                GameObject currentObject = hit.collider.gameObject;
                
                if (buttonsPressed.Contains(int.Parse(currentObject.transform.parent.name)))
                {
                    currentObject.transform.parent.gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.red;
                    if(buttonsPressed.Contains(int.Parse(currentObject.transform.parent.name)))
                    {
                        buttonsPressed.Remove(int.Parse(currentObject.transform.parent.name));
                    }
                }
                else
                {
                    currentObject.transform.parent.gameObject.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.green;
                    if(!buttonsPressed.Contains(int.Parse(currentObject.transform.parent.name)))
                    {
                        buttonsPressed.Add(int.Parse(currentObject.transform.parent.name));
                    }
                }
            }
        }
    }
}
