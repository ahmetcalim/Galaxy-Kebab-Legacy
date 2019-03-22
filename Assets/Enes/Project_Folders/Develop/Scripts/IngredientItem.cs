using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientItem : MonoBehaviour
{
    public bool isActive;
    public int ID;
    public Text text;
    public GameLogic gLogic;

    private void OnEnable()
    {
        this.GetComponent<Button>().onClick.AddListener(() => Action());
    }

    public void Action()
    {
        gLogic.AddIngredient(this.ID);
    }
}
