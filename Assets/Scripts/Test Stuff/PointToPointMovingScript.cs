using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMovingScript : MonoBehaviour
{
    //NB: Old only for referance. New cleaner script made.
    public Transform PlayerTransform;
    public Transform[] Checkpoints;
    public float MoveSpeed;
    public int _checkpointIndex;
    public int MoveTarget;
    private float _checkpointHalf;
    private ClockUIScript _clockUiScript;
    public float MoveCost;
    private int _tempMoveTarget;
    private bool _loopFor;
    private bool _loopBack;
    public bool AllowMove;
    public int _moveAmount;
    public int _moveDone;
    private int _checkDoneUp;
    private int _checkDoneDown;
    public bool LoopCheck;
    //public int CheckpointTest;
    private bool _runOnce;
    private int _u;
    private int _d;
    private bool _doReset;
    public GameObject ClockUI;
    public GameObject NextTurnButton;
    public bool UIOpen;
    public SpaceManagerScript ActiveUI;

    void Start()
    {
        _clockUiScript = GetComponent<ClockUIScript>();
        _checkpointHalf = (float) Checkpoints.Length / 2;
        PlayerTransform.transform.position = Checkpoints[0].transform.position;
    }

    void Update () 
	{
        /*MoveTest1();
        CheckDir1();
        CheckPos1();*/
        //MoveTest2();
        //CheckDist3();
        DistCheck4();
        MoveTest3();
        BackToStart();
    }

    void MoveTest1()
    {
        float moveStep = Time.deltaTime * MoveSpeed;
        if (PlayerTransform.transform.position != Checkpoints[_checkpointIndex].position)
        {
            PlayerTransform.transform.position = Vector3.MoveTowards(PlayerTransform.transform.position, Checkpoints[_checkpointIndex].position, moveStep);
        }
        if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position)
        {
            _loopFor = false;
            _loopBack = false;
            //Open UI thingy about where you are or something....
        }
    }

    void CheckPos1()
    {
        if (_clockUiScript.RedOverlay.fillAmount < 1)
        {
            //Move backward
            if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position && _checkpointIndex > MoveTarget)
            {
                //Add so it removes times or somting.
                _checkpointIndex--;
                _clockUiScript.RedOverlay.fillAmount += MoveCost;
                if (_loopBack)
                {
                    _checkpointIndex = 9;
                    MoveTarget = _tempMoveTarget;
                }
                if (_checkpointIndex == Checkpoints.Length)
                {
                    _checkpointIndex = 9;
                    MoveTarget = 9;
                }
                //Debug.Log("CP Index: " + _checkpointIndex);
            }
            //Move forward
            if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position && _checkpointIndex < MoveTarget)
            {
                _checkpointIndex++;
                _clockUiScript.RedOverlay.fillAmount += MoveCost;
                if (_loopFor)
                {
                    _checkpointIndex = 0;
                    MoveTarget = _tempMoveTarget;
                }
                if (_checkpointIndex == Checkpoints.Length)
                {
                    _checkpointIndex = 0;
                    MoveTarget = 0;
                }
                //Debug.Log("CP Index: "  +_checkpointIndex);
            }
            /*if (_checkpointIndex == Checkpoints.Length)
            {
                _checkpointIndex = 0;
                MoveTarget = 0;
            }*/
        }
    }

    public void CheckDir1()
    {
        if (_checkpointIndex > _checkpointHalf && MoveTarget == 0)
        {
            MoveTarget = 9;
        }

        if (_checkpointIndex > _checkpointHalf && MoveTarget < _checkpointHalf / 2)
        {
            _tempMoveTarget = MoveTarget;
            MoveTarget = 9;
            _loopFor = true;
        }
        /*if (_checkpointIndex < _checkpointHalf && MoveTarget > _checkpointHalf / 2)
        {
            _tempMoveTarget = MoveTarget;
            MoveTarget = 0;
            _loopBack = true;
        }*/
    }

    void MoveTest2()
    {
        float moveStep = Time.deltaTime * MoveSpeed;
        if (AllowMove)
        {
            if (Mathf.Sign(_moveAmount) >= 1)
            {
                if (PlayerTransform.transform.position != Checkpoints[_checkpointIndex].position)
                {
                    PlayerTransform.transform.position = Vector3.MoveTowards(PlayerTransform.transform.position,
                        Checkpoints[_checkpointIndex].position, moveStep);
                }
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone < _moveAmount)
                {
                    _moveDone++;
                    _checkpointIndex++;
                }
            }
            if (Mathf.Sign(_moveAmount) <= -1)
            {
                if (PlayerTransform.transform.position != Checkpoints[_checkpointIndex].position)
                {
                    PlayerTransform.transform.position = Vector3.MoveTowards(PlayerTransform.transform.position,
                        Checkpoints[_checkpointIndex].position, moveStep);
                }
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone > _moveAmount)
                {
                    _moveDone--;
                    _checkpointIndex--;
                }
            }
            if (_moveDone == _moveAmount)
            {
                _moveAmount = 0;
                _moveDone = 0;
            }
        }
    }

    public void CheckDist2()
    {
        _moveAmount = MoveTarget - _checkpointIndex;
        Debug.Log(_moveAmount);
        AllowMove = true;
    }

    public void CheckDist3()
    {
        if (LoopCheck)
        {
            //check up
            for (int i = _checkpointIndex; i < Checkpoints.Length; i++)
            {
                _checkDoneUp++;
                if (Checkpoints[i].GetSiblingIndex() == MoveTarget)
                {
                    Debug.Log("Found in Up: " + _checkDoneUp);
                }
                if (i == Checkpoints.Length)
                {
                    i = 0;
                }
            }
            //check down
            for (int i = _checkpointIndex; i > Checkpoints.Length; i--)
            {
                _checkDoneDown++;
                if (Checkpoints[i].GetSiblingIndex() == MoveTarget)
                {
                    Debug.Log("Found in Down: " + _checkDoneDown);

                }
                if (i == 0)
                {
                    i = Checkpoints.Length;
                }
            }
            LoopCheck = false;
            _checkDoneUp = 0;
            _checkDoneDown = 0;

        }
    }

    public void DistCheck4()
    {
        if (LoopCheck)
        {
            if (Checkpoints[_u].GetSiblingIndex() != MoveTarget)
            {
                _u++;
                _checkDoneUp++;
                if (_u > 7)
                {
                    _u = 0;
                }
            }
            if (Checkpoints[_d].GetSiblingIndex() != MoveTarget)
            {
                _d--;
                _checkDoneDown++;
                if (_d < 0)
                {
                    _d = 7;
                }
            }
            if (Checkpoints[_u].GetSiblingIndex() == MoveTarget && Checkpoints[_d].GetSiblingIndex() == MoveTarget)
            {
                LoopCheck = false;
                AllowMove = true;
                Debug.Log("Checks UP: " + _checkDoneUp);
                Debug.Log("Checks Down: " + _checkDoneDown);
            }
        }
    }

    public void ResetValues()
    {
        _u = _checkpointIndex;
        _d = _checkpointIndex;
        _checkDoneUp = 0;
        _checkDoneDown = 0;
        _moveDone = 0;
    }

    void MoveTest3()
    {
        if (AllowMove & !_doReset & !UIOpen)
        {
            if (ActiveUI != null)
            {
                ActiveUI.CloseUI();
            }
            Debug.Log("Start Move");
            float moveStep = Time.deltaTime * MoveSpeed;
            if (_checkDoneUp <= _checkDoneDown)
            {
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone < _checkDoneUp)
                {
                    _checkpointIndex++;
                }
                if (_checkpointIndex > 7)
                {
                    _checkpointIndex = 0;
                }
                if (PlayerTransform.transform.position != Checkpoints[_checkpointIndex].position)
                {
                    PlayerTransform.transform.position = Vector3.MoveTowards(PlayerTransform.transform.position,
                        Checkpoints[_checkpointIndex].position, moveStep);
                    _clockUiScript.RedOverlay.fillAmount += MoveCost * Time.deltaTime;
                }
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone < _checkDoneUp)
                {
                    _moveDone++;
                    //_clockUiScript.RedOverlay.fillAmount += MoveCost;
                }
            }

            if (_checkDoneDown < _checkDoneUp)
            {
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone < _checkDoneDown)
                {
                    _checkpointIndex--;
                }
                if (_checkpointIndex < 0)
                {
                    _checkpointIndex = 7;
                }
                if (PlayerTransform.transform.position != Checkpoints[_checkpointIndex].position)
                {
                    PlayerTransform.transform.position = Vector3.MoveTowards(PlayerTransform.transform.position,
                        Checkpoints[_checkpointIndex].position, moveStep);
                    _clockUiScript.RedOverlay.fillAmount += MoveCost * Time.deltaTime;
                }
                if (PlayerTransform.transform.position == Checkpoints[_checkpointIndex].position &&
                    _moveDone < _checkDoneDown)
                {
                    _moveDone++;
                   // _clockUiScript.RedOverlay.fillAmount += MoveCost;
                }
            }

            if (_moveDone == _checkDoneDown || _moveDone == _checkDoneUp)
            {
                ResetValues();
                AllowMove = false;
                if (ClockUI.activeInHierarchy)
                {
                    ActiveUI = Checkpoints[_checkpointIndex].GetComponent<SpaceManagerScript>();
                    ActiveUI.OpenUI();
                    UIOpen = true;
                }
            }
        }
        if (_clockUiScript.RedOverlay.fillAmount >= 1)
        {
            _doReset = true;
        }
    }

    void BackToStart()
    {
        if (_doReset && !ActiveUI.UIScreen.activeInHierarchy)
        {
            ActiveUI.CloseUI();
            ClockUI.SetActive(false);
            float moveStep = Time.deltaTime * (MoveSpeed / 2);
            PlayerTransform.position = Vector3.MoveTowards(PlayerTransform.position, Checkpoints[0].position, moveStep);
            if (PlayerTransform.position == Checkpoints[0].position)
            {
                _doReset = false;
                _checkpointIndex = 0;
                ResetValues();
                NextTurnButton.SetActive(true);
            }
        }
    }
}
