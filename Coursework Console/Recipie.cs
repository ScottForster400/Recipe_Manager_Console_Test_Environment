using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Recipe
{
    private List<Item> ingriedients;
    private List<string> Steps;
    private string servingSize;

    public Recipe(List<Item> selcetedIngridients, List<string> selectedSteps,string selctedServingSize)
    {
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
        foreach(Item item in ingriedients)
        {
            formatedString = formatedString + $"{item.GetDataForSaveFile()}";
        }
        formatedString = formatedString + ";";
        foreach (string step in Steps)
        {
            formatedString = formatedString + $"{step},";
        }
        formatedString = formatedString + ";";
        formatedString= formatedString + $"{servingSize},;";
        return formatedString;
    }
}