using System;
using UnityEngine;

public class MoreIngredient : MonoBehaviour
{public Transform ingredient;
   public GameObject ingredientPrefab;
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.tag == "Ingredient")
      {
         Instantiate(ingredientPrefab, ingredient.position, Quaternion.identity);
         Debug.Log("More!");
      }
   }

   void Start()
   {
      for (int i = 0; i < 10; i++)
      {
         Instantiate(ingredientPrefab, ingredient.position, Quaternion.identity);
      }
   }
}
