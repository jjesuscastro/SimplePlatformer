using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Image health;
    [SerializeField]
    private Sprite[] healthSprites;
    [SerializeField]
    private TextMeshProUGUI coins;
    [SerializeField]
    private GameObject gameOverScreen;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.healthEvent.Subscribe(UpdateHealthUI).AddTo(this);
        gameManager.coinsEvent.Subscribe(UpdateCoinsUI).AddTo(this);
        gameManager.gameOverEvent.Subscribe(EnableGameOver).AddTo(this);
    }

    private void UpdateHealthUI(int value)
    {
        health.sprite = healthSprites[value-1];
    }

    private void UpdateCoinsUI(int value)
    {
        coins.text = $"x{value}";
    }

    private void EnableGameOver(Unit _)
    {
        gameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
