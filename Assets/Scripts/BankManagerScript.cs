using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankManagerScript : MonoBehaviour
{
    public Text SavingsAmountText;
    public Text IntrestText;
    public InputField AmoutInputField;
    public float SavingInput;
    public float CurrentSavings;
    public float Intrest;
    private PlayerInfoManagerScript _playerInfoManager;

    private float _tempSaving;

    void Start()
    {
        _playerInfoManager = GetComponent<PlayerInfoManagerScript>();
        IntrestText.text = "Intrest a Week: " + Intrest.ToString("F2") +"%";
        SavingsAmountText.text = "Savings: " + CurrentSavings.ToString("F0");
    }

    public void DepositMoney()
    {
        if (SavingInput <= _playerInfoManager.Cash)
        {
            _playerInfoManager.Cash -= SavingInput;
            CurrentSavings += SavingInput;
            SavingsAmountText.text = "Savings: " + CurrentSavings.ToString("F0");
            SavingInput = 0;
            AmoutInputField.text = "0";
        }
    }

    public void WithdrawMoney()
    {
        if (SavingInput <= CurrentSavings)
        {
            _playerInfoManager.Cash += SavingInput;
            CurrentSavings -= SavingInput;
            SavingsAmountText.text = "Savings: " + CurrentSavings.ToString("F0");
            SavingInput = 0;
            AmoutInputField.text = "0";
        }
    }

    public void NewWeek()
    {
        _tempSaving = CurrentSavings;
        CurrentSavings = CurrentSavings * (Intrest / 100) + _tempSaving;
        SavingsAmountText.text = "Savings: " + CurrentSavings.ToString("F0");
    }

    public void ConvInput()
    {
        if (AmoutInputField.text == "") //To remove an error when field is empty.
        {
            AmoutInputField.text = "0";
        }
        SavingInput = int.Parse(AmoutInputField.text);
        /*if (SavingInput > _playerInfoManager.Cash)
        {
            SavingInput = _playerInfoManager.Cash;
            AmoutInputField.text = SavingInput.ToString("F0");
        }*/
    }
}
