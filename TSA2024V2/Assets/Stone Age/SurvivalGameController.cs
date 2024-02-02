using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalGameController : MonoBehaviour
{
    private float timeLeft = 40;
    [SerializeField] GameObject stalagmite;
    private int numRocks = 5;
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
                InvokeRepeating("ManageRocks", 0, 2.8f);
                difficulty += 5;
                level1 = false;
            }
            if(timeLeft < 20 && level2)
            {
                CancelInvoke("ManageRocks");
                InvokeRepeating("ManageRocks", 0, 2.6f);
                difficulty += 5;
                level2 = false;
            }
            if(timeLeft < 10 && level3)
            {
                CancelInvoke("ManageRocks");
                InvokeRepeating("ManageRocks", 0, 2.4f);
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
        InvokeRepeating("ManageRocks", 0, 3);
    }

    private void ManageRocks()
    {
        if(rocks.Count > 0)
        {
            Invoke("DestroyAll", 5);
        }
        rocks = InstantiateRocks();

    }

    private void DestroyAll()
    {
        for(int i = 0; i < rocks.Count; i++)
        {
            Destroy(rocks[i].gameObject);
        }
    }

    private List<Transform> InstantiateRocks()
    {
        int totalRocks = numRocks + difficulty;

        List<float> xValues = new List<float>();
        List<float> yValues = new List<float>();
        List<float> zValues = new List<float>();
        
        for(int i = 0; i < totalRocks; i++)
        {
            xValues.Add(Random.Range(-30, 0));
        }
        for(int i = 0; i < totalRocks; i++)
        {
            yValues.Add(Random.Range(15, 20));
        }

        foreach(int y in yValues)
        {
            float random = Random.Range(0, 1);
            if(y >= 15 && y < 16.5)
            {
                if(random >= 0.5)
                {
                    zValues.Add(Random.Range(-6.5f, -3f));
                }
                else
                {
                    zValues.Add(Random.Range(11, 15.5f));
                }
            }
            else if(y >= 16.5 && y < 18)
            {
                if(random >= 0.5)
                {
                    zValues.Add(Random.Range(-3, 1));
                }
                else
                {
                    zValues.Add(Random.Range(9, 11));
                }
            }
            else
            {
                zValues.Add(Random.Range(1, 9));
            }
        }
        
        List<Transform> rocks = new List<Transform>();
        for(int i = 0; i < totalRocks; i++)
        {
            rocks.Add(Instantiate(stalagmite, new Vector3(xValues[i], yValues[i], zValues[i]), Quaternion.identity).transform);
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
    }
}
