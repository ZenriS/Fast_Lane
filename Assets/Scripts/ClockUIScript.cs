using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUIScript : MonoBehaviour
{
    public Image RedOverlay;
    public float FillAmount;

	void Start ()
	{
	    RedOverlay.fillAmount = 0;
	}

    void Update()
    {
        RedOverlay.fillAmount = FillAmount;
        if (FillAmount > 1)
        {
            FillAmount = 1; // to fix that fillamount goes over and causes bugs when calculationg payment.
        }
    }
}
