using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateObject", 5f);
    }

    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
