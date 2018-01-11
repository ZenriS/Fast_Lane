using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyFoodSystemScript : MonoBehaviour
{
    public PlayerInfoManagerScript PlayerInfo;
    public EventSystem EventSys;
    public Button[] FoodButtons;
    public string[] FoodName;
    public int[] FoodPrice;
    public int[] FoodAmount;

    private FoodManagerScript _foodManager;

    void Start()
    {
        _foodManager = PlayerInfo.GetComponent<FoodManagerScript>();
        for (int i = 0; i < FoodButtons.Length; i++) //Set the price and name on the buttons.
        {
            FoodButtons[i].transform.GetChild(0).GetComponent<Text>().text = FoodName[i].PadRight(20) + FoodPrice[i]+"$";
        }
    }

    public void BuyFood()
    {
        int refIndex = EventSys.currentSelectedGameObject.transform.GetSiblingIndex();
        if (PlayerInfo.Cash > FoodPrice[refIndex])
        {
            _foodManager.FoodAmount += FoodAmount[refIndex];
            PlayerInfo.Cash -= FoodPrice[refIndex];
        }
    }
}
