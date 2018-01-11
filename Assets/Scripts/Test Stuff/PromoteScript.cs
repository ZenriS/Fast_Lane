using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromoteScript : MonoBehaviour
{
    public int MaxPromotes;
    public float[] Payments;
    public float[] JobExpNeeded;
    private int _currentProm;
    private int _nextProm = 1;
    private WorkManagerScript _workManager;
    private ApplyForJobScript _applyForJob;
    private PlayerInfoManagerScript _playerInfoManager;


	void Start ()
	{
	    MaxPromotes = Payments.Length;
	    _applyForJob = GetComponent<ApplyForJobScript>();
	    _workManager = _applyForJob.GetComponent<WorkManagerScript>();
	    _playerInfoManager = _workManager.GetComponent<PlayerInfoManagerScript>();
	}

    void CheckForPromotion()
    {
        
    }
}
