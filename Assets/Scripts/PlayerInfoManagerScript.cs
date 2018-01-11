using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoManagerScript : MonoBehaviour
{
    public InputField PlayerNameInput;
    public string PlayerName;
    public Sprite PlayerImage;
    public int Week;
    public float StartCash;
    public float Cash;
    //public float Savings; // Moved to bank manager script
    public string JobInfo;
    public int JobIndex;
    public int JobLevelIndex;
    public float JobExperiance;
    public int EducationValue; //Placeholder until education system is inn.
    //Script to hold div info.

    void Start()
    {
        JobInfo = "Unemployed";
        Cash = StartCash;
        JobIndex = 99; //99 = Unemployed
        JobLevelIndex = 99;
    }

    public void SetName()
    {
        PlayerName = PlayerNameInput.text;
    }
}
