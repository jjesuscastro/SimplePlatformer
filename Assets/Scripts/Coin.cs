using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject collectedAnimation;

    public void OnInteract()
    {
        // Add logic to pick up the coin
        PickUp();
    }

    private void PickUp()
    {
        collectedAnimation.SetActive(false);
        collectedAnimation.transform.position = transform.position;

        // Add logic to pick up the coin
        GameManager.Instance.AddCoin(1);
        Destroy(gameObject); // Destroy the coin object
        collectedAnimation.SetActive(true);
    }
}
