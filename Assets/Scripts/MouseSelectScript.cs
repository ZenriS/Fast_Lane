using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectScript : MonoBehaviour
{
    private Ray _mouseRay;
    private RaycastHit _raycastHit;
    private PointToPointMoveManagerScript _p2pMoveManager;
    private ClockUIScript _clockUiScript;

    void Start()
    {
        _p2pMoveManager = GetComponent<PointToPointMoveManagerScript>();
        _clockUiScript = GetComponent<ClockUIScript>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") /*&& !_p2pMoveManager.UIOpen*/)
        {
            MouseSelect();
        }
    }

    private void MouseSelect()
    {
        _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_mouseRay, out _raycastHit);
        //Debug.Log("Ray hit: " +_raycastHit.transform.name);
        if (_raycastHit.transform.tag == "Checkpoint" && !_p2pMoveManager.AllowMove &&
            _clockUiScript.FillAmount < 1)
        {
            Debug.Log("TEst");
            if (_p2pMoveManager.ActiveSpace != null)
            {
                _p2pMoveManager.ActiveSpace.CloseUI();
                Debug.Log("Close UI");
            }
            _p2pMoveManager.TargetIndex = _raycastHit.transform.GetSiblingIndex();
            _p2pMoveManager.LoopCheck = true;
        }
        else
        {
            //Debug.Log("Did not click on a move space");
            return;
        }
    }
}
