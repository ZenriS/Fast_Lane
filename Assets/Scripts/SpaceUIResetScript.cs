using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUIResetScript : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject[] SecondaryScreens;

    void OnEnable()
    {
        foreach (GameObject secScreen in SecondaryScreens)
        {
            secScreen.SetActive(false);
        }
        StartScreen.SetActive(true);
    }
}
