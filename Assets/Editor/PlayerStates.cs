using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;

    public float MaxHealth = 100;

    public static float HealthCurrency;

    public static int rounds;

    public void Start()
    {
        Money = startMoney;

        HealthCurrency = MaxHealth;

        rounds = 0;

    }
    public void TakeDamage(float amount)
    {
        HealthCurrency -= amount;
        if (HealthCurrency <= 0)
        {
            HealthCurrency = 0;
        }
    }

}

