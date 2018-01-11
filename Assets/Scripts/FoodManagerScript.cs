using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManagerScript : MonoBehaviour
{
    public int FoodAmount;
    public bool StoreFood; // Get info from item script to check if the player has a fridge to allow the storage of food.
    public float NoFoodCost;
    private ClockUIScript _clockUi;
    public Text InfoText;
    

	void Start ()
	{
	    _clockUi = GetComponent<ClockUIScript>();
	}

    public void CheckFood()
    {
        if (FoodAmount <= 0) //No food at the start of the week.
        {
            _clockUi.FillAmount += NoFoodCost;
            InfoText.text = "You didn't eat last week and lose time.";
        }
        else
        {
            FoodAmount--;
            InfoText.text = "";
        }
        if (!StoreFood && FoodAmount > 0) //if the player has no fridge the left over food get spoiled.
        {
            InfoText.text = InfoText.text+ "\n" +FoodAmount + " Food wasted away.\nYou should get a fridge." ;
            FoodAmount = 0;
        }
    }
}
