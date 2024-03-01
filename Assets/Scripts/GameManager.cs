using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GameManager : MonoBehaviour
{
    private int health = 3;
    private int coins = 0;

    private Subject<int> healthSubject = new Subject<int>();
    private Subject<int> coinsSubject = new Subject<int>();
    private Subject<Unit> gameOverSubject = new Subject<Unit>();

    public IObservable<int> healthEvent => healthSubject;
    public IObservable<int> coinsEvent => coinsSubject;
    public IObservable<Unit> gameOverEvent => gameOverSubject;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int value)
    {
        coins += value;
        coinsSubject.OnNext(coins);
    }

    public int GetHealth()
    {
        return health;
    }

    // HealPlayer and DamagePlayer can be combined into one function
    // and only change the value to either positive or negative
    // however separating them makes the function names straight to the point
    // and easier to keep track of
    public void HealPlayer(int value)
    {
        health = health < 3 ? health + value : health;
        healthSubject.OnNext(health);
    }

    public void DamagePlayer(int value)
    {
        health = health > 0 ? health - value : health;

        if(health == 0)
        {
            health = 3;
            coins = 0;
            gameOverSubject.OnNext(Unit.Default);
            return;
        }

        healthSubject.OnNext(health);
    }

    private void OnDestroy()
    {
        healthSubject.Dispose();
        coinsSubject.Dispose();
        gameOverSubject.Dispose();
    }
}
