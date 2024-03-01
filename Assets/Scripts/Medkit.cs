using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject collectedAnimation;

    public void OnInteract()
    {
        // Add logic to pick up the medkit
        PickUp();
    }

    private void PickUp()
    {
        collectedAnimation.SetActive(false);
        collectedAnimation.transform.position = transform.position;

        // Add logic to pick up the medkit
        GameManager.Instance.HealPlayer(1);
        Destroy(gameObject); // Destroy the medkit object
        collectedAnimation.SetActive(true);
    }
}
