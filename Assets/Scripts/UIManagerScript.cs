using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    private PlayerInfoManagerScript _playerInfoManager;
    public Text[] UIText;

    void Start ()
	{
	    _playerInfoManager = GetComponent<PlayerInfoManagerScript>();
	}

    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        UIText[0].text = "Name: " +_playerInfoManager.PlayerName;
        UIText[1].text = "Cash: " +_playerInfoManager.Cash.ToString("F0");
        //UIText[2].text = "Savings: " +_playerInfoManager.Savings.ToString("F0"); //Moved to bank manager script
        UIText[3].text = "Job Info: " +_playerInfoManager.JobInfo;
        UIText[4].text = "Week: " +_playerInfoManager.Week.ToString("F0");
    }
}
