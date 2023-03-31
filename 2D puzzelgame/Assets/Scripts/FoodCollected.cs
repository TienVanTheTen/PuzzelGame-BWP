using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodCollected : MonoBehaviour
{
    [SerializeField] private float amountOfFoodOnMap;
    [SerializeField] FoodCollectedDisplay display;
    private int foodCollected = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateProgressFood()
    {
        foodCollected++;
        display.DisplayProgress(foodCollected, amountOfFoodOnMap);
        if(foodCollected == amountOfFoodOnMap)
        {
            SceneManager.LoadScene("Endscreen");
        }

    }

    
    
}
