using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PointToPointMoveManagerScript : MonoBehaviour
{
    public Transform Player;
    public List<Transform> Spaces;
    public float MoveSpeed;
    public int TargetIndex;
    public float MoveCost;
    public bool AllowMove;
    public GameObject ClockUI;
    public GameObject NextTurnUI;
    public bool UIOpen;
    public SpaceManagerScript ActiveSpace;
    public bool LoopCheck;
    public float MovePauseTimer;

    private int _currentSpaceIndex;
    private int _movesDone;
    private int _checksUp;
    private int _checksDown;
    private int _upwards;
    private int _downwards;
    public bool TurnOver;
    private ClockUIScript _clockUiScript;
    private int _spaces;
    private bool _spacePause;

    private int _movesLeft;

    private FoodManagerScript _foodManager;


    void Start () 
	{
        _clockUiScript = GetComponent<ClockUIScript>();
        _foodManager = GetComponent<FoodManagerScript>();
        Player.transform.position = Spaces[0].transform.position;
	    _spaces = Spaces.Count - 1; // transforms the amount of spaces for easy use. And for easy use when making the map bigger.
	}

	void Update () 
	{
        DirectionCheck();
        MovePlayer();
        BackToStart();
	}

    public void DirectionCheck() //calc what the shortes way is. 
    {
        if (LoopCheck)
        {
            if (Spaces[_upwards].GetSiblingIndex() != TargetIndex)
            {
                _upwards++;
                _checksUp++;
                if (_upwards > _spaces)
                {
                    _upwards = 0;
                }
            }
            if (Spaces[_downwards].GetSiblingIndex() != TargetIndex)
            {
                _downwards--;
                _checksDown++;
                if (_downwards < 0)
                {
                    _downwards = _spaces;
                }
            }
            if (Spaces[_upwards].GetSiblingIndex() == TargetIndex && Spaces[_downwards].GetSiblingIndex() == TargetIndex)
            {
                LoopCheck = false;
                AllowMove = true;
                Debug.Log("Checks UP: " + _checksUp);
                Debug.Log("Checks Down: " + _checksDown);
            }
        }
    }

    void MovePlayer()// move the player to the spaces clicked on. The direction found in DirectionChecker function
    {
        if (AllowMove && !TurnOver && !UIOpen && !_spacePause)
        {
            if (ActiveSpace != null) //To remove error on first turn.
            {
                ActiveSpace.CloseUI();
            }
            //Debug.Log("Start Move");
            float moveStep = Time.deltaTime * MoveSpeed;
            if (_checksUp <= _checksDown)
            {
                if (Player.transform.position == Spaces[_currentSpaceIndex].position &&
                    _movesDone < _checksUp)
                {
                    _currentSpaceIndex++;
                    _movesLeft = _checksUp - _movesDone;
                    Debug.Log("Moves Left: " +_movesLeft);
                }
                if (_currentSpaceIndex > _spaces)
                {
                    _currentSpaceIndex = 0;
                }
                if (Player.transform.position != Spaces[_currentSpaceIndex].position)
                {
                    Player.transform.position = Vector3.MoveTowards(Player.transform.position,
                        Spaces[_currentSpaceIndex].position, moveStep);
                    //_clockUiScript.FillAmount += MoveCost * Time.deltaTime;
                }
                if (Player.transform.position == Spaces[_currentSpaceIndex].position &&
                    _movesDone < _checksUp)
                {
                    _spacePause = true;
                    Invoke("MovePaused", MovePauseTimer);
                    _movesDone++;
                }
                if (Player.transform.position != Spaces[TargetIndex].position)
                {
                    _clockUiScript.FillAmount += (MoveCost * _checksUp) * Time.deltaTime;
                }
            }

            if (_checksDown < _checksUp)
            {
                if (Player.transform.position == Spaces[_currentSpaceIndex].position &&
                    _movesDone < _checksDown)
                {
                    _currentSpaceIndex--;
                    _movesLeft = _checksDown -_movesDone;
                    Debug.Log("Moves Left: " + _movesLeft);
                }
                if (_currentSpaceIndex < 0)
                {
                    _currentSpaceIndex = _spaces;
                }
                if (Player.transform.position != Spaces[_currentSpaceIndex].position)
                {
                    Player.transform.position = Vector3.MoveTowards(Player.transform.position,
                        Spaces[_currentSpaceIndex].position, moveStep);
                    //_clockUiScript.FillAmount += MoveCost * Time.deltaTime; //Move cost every tile
                }
                if (Player.transform.position == Spaces[_currentSpaceIndex].position &&
                    _movesDone < _checksDown)
                {
                    _spacePause = true;
                    Invoke("MovePaused", MovePauseTimer);
                    _movesDone++;
                }
                if (Player.transform.position != Spaces[TargetIndex].position)
                {
                    _clockUiScript.FillAmount += (MoveCost * _checksDown) * Time.deltaTime;
                }
            }

            if (_movesDone == _checksDown || _movesDone == _checksUp)
            {
                ResetValues();
                AllowMove = false;
                if (ClockUI.activeInHierarchy) //A safty check so the space ui dont open when time is out.
                {
                    ActiveSpace = Spaces[_currentSpaceIndex].GetComponent<SpaceManagerScript>(); //Makes a easy to use ref for the current spaces UI.
                    ActiveSpace.OpenUI();
                    UIOpen = true;
                }
            }
        }
        if (_clockUiScript.FillAmount >= 1)
        {
            TurnOver = true;
        }
    }

    public void BackToStart() //Moves player back to the start location when time is used up. If there is no space ui open.
    {
        if (TurnOver && !ActiveSpace.UIScreen.activeInHierarchy)
        {
            ActiveSpace.CloseUI();
            ClockUI.SetActive(false);
            float moveStep = Time.deltaTime * (MoveSpeed / 2);
            Player.position = Vector3.MoveTowards(Player.position, Spaces[0].position, moveStep);
            if (Player.position == Spaces[0].position)
            {
                TurnOver = false;
                _currentSpaceIndex = 0;
                _clockUiScript.FillAmount = 0;
                _foodManager.CheckFood();
                ResetValues();
                NextTurnUI.SetActive(true);
            }
        }
    } 

    public void ResetValues() //Resets values between moves.
    {
        _upwards = _currentSpaceIndex;
        _downwards = _currentSpaceIndex;
        _checksUp = 0;
        _checksDown = 0;
        _movesDone = 0;
        _spacePause = false;
    }

    void MovePaused()
    {
        if (Player.transform.position != Spaces[TargetIndex].position)
        {
            _spacePause = false;
        }
    }
}

