using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Recipe
{
    private string recipieName;
    private List<Item> ingriedients;
    private List<string> Steps;
    private string servingSize;

    public Recipe(string selectedName, List<Item> selcetedIngridients, List<string> selectedSteps, string selctedServingSize)
    {
        recipieName = selectedName;
        ingriedients = selcetedIngridients;
        Steps = selectedSteps;
        servingSize = selctedServingSize;
    }
    public List<Item> GetIngridients()
    {
        return ingriedients;
    }
    public List<string> GetSteps()
    {
        return Steps;
    }
    public string GetServingSize()
    {
        return servingSize;
    }
    public string GetFormatedForFile()
    {
        string formatedString = "";
        formatedString = formatedString + $"{recipieName};";
        foreach (Item item in ingriedients)
        {
            formatedString = formatedString + $"{item.GetDataForSaveFile()}";
        }
        formatedString = formatedString + ";";
        foreach (string step in Steps)
        {
            formatedString = formatedString + $"{step},";
        }
        formatedString = formatedString + ";";
        formatedString = formatedString + $"{servingSize};";
        return formatedString;
    }
    public void AddToShoppingList(ShoppingList shoppingList)
    {
        foreach (Item item in ingriedients)
        {
            shoppingList.AddShopping(item.GetName(), Convert.ToString(item.GetAmount()), item.GetMeasurement());
        }
    }
    public string GetRecipieName()
    {
        return recipieName;
    }
}