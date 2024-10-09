using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 50;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
        
    }

    public void RewardGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Deposit(goldReward);
    }
    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }

        bank.Withdraw(goldPenalty);
    }


}