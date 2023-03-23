using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectionZoneTrigger : MonoBehaviour
{
    const string FOOD_TAG = "Food";
    FoodCollected FoodCollected;
    private void Start()
    {
        FoodCollected= GetComponent<FoodCollected>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == FOOD_TAG)
        {
            FoodCollected.UpdateProgressFood();
            Destroy(collision.gameObject);
        }
    }
}
