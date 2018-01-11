using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyForJobScript : MonoBehaviour
{

    //This script is ment for having the apply for job at the job tile.
    public PlayerInfoManagerScript PlayerInfoManager;
    public string JobName;
    public int JobIndex;
    public Text RespondText;
    public int EducationNeeded;
    private GameObject _workButton;
    private GameObject _applyButton;
    public float TimeCost;
    public float Payment;
    public float JobExp;
    private WorkManagerScript _workManager;

    void Start()
    {
        _applyButton = transform.GetChild(3).gameObject;
        _workButton = transform.GetChild(4).gameObject;
        _workManager = PlayerInfoManager.GetComponent<WorkManagerScript>();
    }

    public void Apply()
    {
        if (PlayerInfoManager.EducationValue >= EducationNeeded) //placeholder check until education system is in
        {
            RespondText.text = "Grats you got the job, now get to work!";
            PlayerInfoManager.JobInfo = JobName;
            PlayerInfoManager.JobIndex = JobIndex;
            _applyButton.gameObject.SetActive(false);
            _workButton.gameObject.SetActive(true);
            _workManager.JobExp = JobExp;
            _workManager.TimeCost = TimeCost;
            _workManager.Payment = Payment;
        }
        else
        {
            RespondText.text = "Get some more education and maybe we talk";
        }
        Invoke("ResetText",2f);
    }

    void ResetText()
    {
        RespondText.text = "";
    }
}
