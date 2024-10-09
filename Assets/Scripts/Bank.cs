using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayGold;

    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += amount;
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= amount;
        UpdateDisplay();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void UpdateDisplay()
    {
        displayGold.text = "Gold: " + currentBalance;
    }
}
