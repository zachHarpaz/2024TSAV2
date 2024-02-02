using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMenu : MonoBehaviour
{
    public List<GameObject> turnOff;
    public List<GameObject> turnOn;
    // Start is called before the first frame update

    public void openControlMenu()
    {
        for (int i = 0; i < turnOff.Count; i++)
        {
            turnOff[i].SetActive(false);
        }
        for (int i = 0; i < turnOn.Count; i++)
        {
            turnOn[i].SetActive(true);
        }
    }

    public void closeControlMenus()
    {
        for (int i = 0; i < turnOn.Count; i++)
        {
            turnOn[i].SetActive(false);
        }
        for (int i = 0; i < turnOff.Count; i++)
        {
            turnOff[i].SetActive(true);
        }
    }

}
