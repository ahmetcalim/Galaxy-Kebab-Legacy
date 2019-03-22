using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCreator : MonoBehaviour
{
    public List<Ingredient> ingredients;
    public GameLogic gLogic;
    public IngredientItem ingredientAction;
    public Transform actionViewport;
    public void CreateIngredient()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredientAction.ID = ingredients[i].ID;
            ingredientAction.gLogic = this.gLogic;
            ingredientAction.gameObject.name = ingredients[i].ingredientName;
            ingredientAction.text.text = ingredients[i].ingredientName;
            Instantiate(ingredientAction.gameObject,actionViewport);
            gLogic.ingredients.Add(ingredients[i]);
        }
    }


}
