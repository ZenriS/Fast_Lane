using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesRefManagerScript : MonoBehaviour
{
    public GameObject GameManager;
    public float OpenSpaceCost;
    private PointToPointMoveManagerScript _p2pMoveManager;

    void Start()
    {
        _p2pMoveManager = GameManager.GetComponent<PointToPointMoveManagerScript>();
    }

    public void CloseSpaceUI()
    {
       _p2pMoveManager.ActiveSpace.CloseUI();
    }
}
