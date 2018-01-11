using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurnScript : MonoBehaviour
{
    private ClockUIScript _clockUIScript;
    private PointToPointMoveManagerScript _p2pMovingManager;
    private PlayerInfoManagerScript _playerInfoManager;
    private BankManagerScript _bankManager;
    private FoodManagerScript _foodManager;

	
	void Start ()
	{
	    _clockUIScript = GetComponent<ClockUIScript>();
	    _p2pMovingManager = GetComponent<PointToPointMoveManagerScript>();
	    _playerInfoManager = GetComponent<PlayerInfoManagerScript>();
	    _bankManager = GetComponent<BankManagerScript>();
        _foodManager = GetComponent<FoodManagerScript>();
	}

    public void NextTurn()
    {
        _playerInfoManager.Week++;
        _p2pMovingManager.ResetValues();
        _p2pMovingManager.ClockUI.SetActive(true);
        _p2pMovingManager.NextTurnUI.SetActive(false);
        _bankManager.NewWeek();
    }
}
