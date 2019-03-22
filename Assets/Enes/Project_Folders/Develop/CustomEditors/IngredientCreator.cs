using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCreator : MonoBehaviour
{
    public List<Ingredient> ingredients;
    public GameLogic gLogic;
    public IngredientItem ingredientItem;
    public Transform actionViewport;
    public void CreateIngredient()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredientItem.ID = ingredients[i].ID;
            ingredientItem.gLogic = this.gLogic;
            ingredientItem.gameObject.name = ingredients[i].ingredientName;
            GameObject g=Instantiate(ingredientItem.gameObject,actionViewport);
            g.name = ingredientItem.name;
            gLogic.ingredients.Add(ingredients[i]);
        }
    }


}
