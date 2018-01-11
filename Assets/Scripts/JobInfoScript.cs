using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JobInfoScript : MonoBehaviour
{
    public string JobLocation;
    public int JobIndex;
    public int JobLevelIndex;
    public int RefIndex;
    public string[] JobTitles;
    public float[] JobExpNeeded;
    public float[] Payment;
    public float[] TimeCost;
    public float[] JobExpGain;
    public Text RespondText;
    public PlayerInfoManagerScript PlayerInfoManager;
    private WorkManagerScript _workManager;
    private ClockUIScript _clockUI;
    private SetJobLocationScript _setJobLocation;
    public EventSystem EventSys;
    public float UseTimeCost;
    

    void Start()
    {
        _workManager = PlayerInfoManager.GetComponent<WorkManagerScript>();
        _clockUI = PlayerInfoManager.GetComponent<ClockUIScript>();
        _setJobLocation = PlayerInfoManager.GetComponent<SetJobLocationScript>();
    }

    public void ApplyJob()
    {
        //Need to add happiness to the happiness system when implemented.
        RespondText.text = "";
        RefIndex = EventSys.currentSelectedGameObject.transform.GetSiblingIndex();
        if (PlayerInfoManager.JobExperiance >= JobExpNeeded[RefIndex])
        {
            if (PlayerInfoManager.JobIndex != JobIndex)
            {
                RespondText.text = "Grats!!";
            }
            if (PlayerInfoManager.JobIndex == JobIndex && PlayerInfoManager.JobLevelIndex < RefIndex)
            {
                RespondText.text = "Grats on your promotion";
            }
            if (PlayerInfoManager.JobIndex == JobIndex && PlayerInfoManager.JobLevelIndex > RefIndex)
            {
                RespondText.text = "Grats on your demotion";
            }
            _workManager.Payment = Payment[RefIndex];
            _workManager.TimeCost = TimeCost[RefIndex];
            _workManager.JobExp = JobExpGain[RefIndex];
            PlayerInfoManager.JobIndex = JobIndex;
            PlayerInfoManager.JobLevelIndex = RefIndex;
            PlayerInfoManager.JobInfo = JobLocation + ": " + JobTitles[RefIndex];

            _setJobLocation.SetJob();
        }
        else
        {
            RespondText.text = "Get more experiance and maybe we talk";
        }
        _clockUI.FillAmount += UseTimeCost;
        Invoke("ResetText",1f);
    }

    void ResetText()
    {
        RespondText.text = "";
    }
}
