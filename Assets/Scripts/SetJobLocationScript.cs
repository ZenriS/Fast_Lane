using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJobLocationScript : MonoBehaviour
{
    public GameObject[] JobTiles;
    private PlayerInfoManagerScript _playerInfoManager;

    void Start()
    {
        _playerInfoManager = GetComponent<PlayerInfoManagerScript>();
    }

    public void SetJob()
    {
        JobTiles[_playerInfoManager.JobIndex].transform.GetChild(3).gameObject.SetActive(true);
    }
}
