using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerendereScript : MonoBehaviour
{

    public Transform[] LinePath;
    private LineRenderer _lineRenderer;


	void Start ()
	{
	    _lineRenderer = GetComponent<LineRenderer>();
	    _lineRenderer.positionCount = LinePath.Length +1;
        for (int i = 0; i < LinePath.Length; i++)
        {
            _lineRenderer.SetPosition(i, LinePath[i].position);
        }
        _lineRenderer.SetPosition(LinePath.Length,LinePath[1].position);
    }

    void Update()
    {
        /*for (int i = 0; i < LinePath.Length; i++) //Only need to set once, so moved to start
        {
            _lineRenderer.SetPosition(i, LinePath[i].position);
        }*/
    }
}
