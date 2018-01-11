using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkManagerScript : MonoBehaviour 
{
    public float TimeCost;
    public float Payment;
    public float JobExp;
    private ApplyForJobScript _applyForJob;
    private ClockUIScript _clockUiScript;
    private PlayerInfoManagerScript _playerInfoManager;
    private PointToPointMoveManagerScript _pointMoveManager;
    private float _tempTime;
	
	void Start ()
	{
	    _playerInfoManager = GetComponent<PlayerInfoManagerScript>();
        _clockUiScript = GetComponent<ClockUIScript>();
	    _pointMoveManager = GetComponent<PointToPointMoveManagerScript>();
	}

    public void DoWork()
    {
        _tempTime = _clockUiScript.FillAmount + TimeCost;
        if (_tempTime <= 1)
        {
            _clockUiScript.FillAmount += TimeCost;
            _playerInfoManager.Cash += Payment;
            _playerInfoManager.JobExperiance += JobExp;
        }
        if (_tempTime > 1)
        {
            _tempTime -= 1;
            _tempTime = TimeCost - _tempTime;
            _clockUiScript.FillAmount += _tempTime;
            _playerInfoManager.Cash += _tempTime * Payment;
            //Debug.Log(_tempTime);
            _playerInfoManager.JobExperiance += _tempTime * JobExp;
        }

        if (_clockUiScript.FillAmount >= 1) //If you try to work and you are out of time it runs and the week thingy.
        {
            _pointMoveManager.ActiveSpace.UIScreen.SetActive(false);
            _pointMoveManager.BackToStart();
        }

    }
}
