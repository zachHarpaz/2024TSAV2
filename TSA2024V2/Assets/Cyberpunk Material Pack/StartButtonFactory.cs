using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButtonFactory : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] TextMeshProUGUI roundsRemaining;
    [SerializeField] GameObject gController;
    private bool isInside = false;
    private bool gameStarted = false;

    private void Start()
    {
        //uiTimer = gameObject.GetComponentInParent<SurvivalGameController>().GetUITimer();
        text.SetActive(false);
        roundsRemaining.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isInside && Input.GetKeyDown(KeyCode.E) && !gameStarted)
        {
            text.SetActive(false);
            roundsRemaining.gameObject.SetActive(true);
            gController.GetComponent<SimonController>().StartManager();
            gameStarted = true;
            GameObject.FindWithTag("Player").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !gameStarted)
        {
            text.SetActive(true);
            isInside = true;
        }
    }

    private void OnTriggetExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            isInside = false;
        }
    }
}