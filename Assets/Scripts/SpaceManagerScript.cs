using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManagerScript : MonoBehaviour
{
    public GameObject UIScreen;
    private SpacesRefManagerScript _spaceRefManagerScript;
    private ClockUIScript _clockUiScript;
    private PointToPointMoveManagerScript _p2pMovingManager;

    void Start()
    {
        _spaceRefManagerScript = transform.parent.GetComponent<SpacesRefManagerScript>();
        _clockUiScript =_spaceRefManagerScript.GameManager.GetComponent<ClockUIScript>();
        _p2pMovingManager = _clockUiScript.GetComponent<PointToPointMoveManagerScript>();
    }

    public void OpenUI()
    {
        UIScreen.SetActive(true);
        _clockUiScript.FillAmount += _spaceRefManagerScript.OpenSpaceCost;
    }

    public void CloseUI()
    {
        UIScreen.SetActive(false);
        _p2pMovingManager.UIOpen = false;
        if (_clockUiScript.FillAmount >= 1)
        {
            _p2pMovingManager.TurnOver = true;
        }
    }
}
