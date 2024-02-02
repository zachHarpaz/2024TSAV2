using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalGameController : MonoBehaviour
{
    private float timeLeft = 40;
    [SerializeField] GameObject stalagmite;
    [SerializeField] private int numRocks = 5;
    private List<Transform> rocks = new List<Transform>();
    private static int difficulty = 0;
    private bool started = false;
    private bool level1 = true;
    private bool level2 = true;
    private bool level3 = true;
    [SerializeField] TextMeshProUGUI uiTimer;
    [SerializeField] GameObject portal;

    private void Update()
    {
        if(started)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 30 && level1)
            {
                CancelInvoke("ManageRocks");
                InvokeRepeating("ManageRocks", 0, 2.5f);
                difficulty += 5;
                level1 = false;
            }
            if(timeLeft < 20 && level2)
            {
                CancelInvoke("ManageRocks");
                InvokeRepeating("ManageRocks", 0, 2.1f);
                difficulty += 5;
                level2 = false;
            }
            if(timeLeft < 10 && level3)
            {
                CancelInvoke("ManageRocks");
                InvokeRepeating("ManageRocks", 0, 1.8f);
                difficulty += 5;
                level3 = false;
            }
            if(timeLeft < 0)
            {
                CancelInvoke("ManageRocks");
                timeLeft = 0;
                started = false;
                uiTimer.gameObject.SetActive(false);
                GameWon();
            }
        }
        uiTimer.text = "Time Left: " + Mathf.Ceil(timeLeft);
    }

    public void StartGame()
    {
        started = true;
        InvokeRepeating("ManageRocks", 0, 2.8f);
    }

    private void ManageRocks()
    {
        rocks = InstantiateRocks();
    }

    private void DestroyAll()
    {
        for(int i = 0; i < rocks.Count; i++)
        {
            rocks[i].gameObject.SetActive(false);
        }
    }

    private List<Transform> InstantiateRocks()
    {
        int totalRocks = numRocks + difficulty;

        List<float> xValues = new List<float>();
        List<float> yValues = new List<float>();
        List<float> zValues = new List<float>();
        List<Transform> rocks = new List<Transform>();
        
        for(int i = 0; i < totalRocks; i++)
        {
            xValues.Add(Random.Range(-30, 0));
            zValues.Add(Random.Range(-6.5f, 15.5f));
            rocks.Add(Instantiate(stalagmite, new Vector3(xValues[i], 20, zValues[i]), Quaternion.identity).transform);
        }

        return rocks;
    }

    public TextMeshProUGUI GetUITimer()
    {
        return uiTimer;
    }

    private void GameWon()
    {
        portal.SetActive(true);
        Invoke("DestroyAll", 5f);
    }
}
