using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] TextMeshProUGUI uiTimer;
    private bool isInside = false;
    private bool gameStarted = false;

    private void Start()
    {
        uiTimer = gameObject.GetComponentInParent<SurvivalGameController>().GetUITimer();
        text.SetActive(false);
        uiTimer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isInside && Input.GetKeyDown(KeyCode.E))
        {
            text.SetActive(false);
            uiTimer.gameObject.SetActive(true);
            gameObject.GetComponentInParent<SurvivalGameController>().StartGame();
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