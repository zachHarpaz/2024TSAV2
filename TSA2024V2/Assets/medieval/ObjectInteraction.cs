using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public ParticleSystem sparkEffect;
    public GameObject correspondingTorch; // Assign in the inspector
    public float burnDistance = 2.0f; // Distance within which the object will burn
    public bool isHeld;
    public ObjectPicker objpick;
    private void Update()
    {
        if (IsNearTorch() && !isHeld)
        {
            objpick.score += 1;
            Debug.Log(objpick.score);
            BurnObject();
            sparkEffect.Play();
        }
    }

    private bool IsNearTorch()
    {
        if (!correspondingTorch) return false;
        return Vector3.Distance(transform.position, correspondingTorch.transform.position) <= burnDistance;
    }

    private void BurnObject()
    {
        // Implement burning effect here (e.g., play a particle system)
        // For now, we'll just destroy the object

        Destroy(gameObject);
    }
}
