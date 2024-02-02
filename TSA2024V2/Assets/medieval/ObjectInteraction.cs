using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public ParticleSystem sparkEffect;
    public GameObject correspondingTorch; 
    public float burnDistance = 2.0f; 
    public bool isHeld;
    public ObjectPicker objpick;
    public AudioSource audioSource;
    private void Update()
    {
        if (IsNearTorch() && !isHeld)
        {
            objpick.score += 1;
            Debug.Log(objpick.score);
            sparkEffect.Play();
            audioSource.Play();
            BurnObject();
        }
    }

    private bool IsNearTorch()
    {
        if (!correspondingTorch) return false;
        return Vector3.Distance(transform.position, correspondingTorch.transform.position) <= burnDistance;
    }

    private void BurnObject()
    {

        Destroy(gameObject);
    }
}
