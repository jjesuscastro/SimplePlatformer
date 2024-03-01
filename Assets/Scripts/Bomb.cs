using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject collectedAnimation;

    public void OnInteract()
    {
        // Add logic to pick up the bomb
        PickUp();
    }

    private void PickUp()
    {
        collectedAnimation.SetActive(false);
        collectedAnimation.transform.position = transform.position;

        // Add logic to pick up the bomb
        GameManager.Instance.DamagePlayer(1);
        Destroy(gameObject); // Destroy the bomb object
        collectedAnimation.SetActive(true);
    }
}
