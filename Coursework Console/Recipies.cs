using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Recipies
{
    public List<Recipe>  listOfRecipies;
    string path = "Recipies.txt";

    public void InitialiseRecipies()
    {
        listOfRecipies = new List<Recipe>();
    }
    public void SaveList()
    {
        // youre doing a lot of file access in one go here, it's usually better to build up the string in memory, and then dump it all into a file at the end
        // OR
        // look at using a file stream, where you open the connection to the file at the start, stream data in over time, then close the connection at the end of the loop
        // if you take option 1, a thing you can look at is String.Join, but it's probably easier to just do if not last on the , and ;


        //for (int i = 0; i < listOfRecipies.Count; i++)
        //{
        //    for (int j = 0; j < listOfRecipies[i].GetIngridients().Count; j++)
        //    {
        //        File.AppendAllText(path, $"{listOfRecipies[i].GetIngridients()[j].GetDataForSaveFile()}");
        //    }
        //    File.AppendAllText(path, ";");
        //    for(int j = 0; j < listOfRecipies[i].GetSteps().Count; j++)
        //    {
        //        File.AppendAllText(path, $"{listOfRecipies[i].GetSteps()[i]},");
        //    }
        //    File.AppendAllText(path, ";");
        //    File.AppendAllText(path, $"{listOfRecipies[i].GetServingSize()},");
        //    File.AppendAllText(path, ";");
        //} 
        string allRecipiesFormatted = FormatAllRecipies();
        File.AppendAllText(path, allRecipiesFormatted);
    }
    public void addRecipe(List<Item> selectedItems, List<string>selecetdSteps,string selecetdServingSize)
    {
        Recipe tempRecipie = new Recipe(selectedItems, selecetdSteps, selecetdServingSize);
        listOfRecipies.Add(tempRecipie);

    }
    public List<Recipe> OpenList()
    {
        List<string> ingriedientsString;
        List<string> stepsList;
        List<string> servingSize;
        string unsortedRecipiesString = File.ReadAllText(path).Trim();
        List<string> unsortedRecipiesList = unsortedRecipiesString.Split(";").ToList();
        unsortedRecipiesList.RemoveAt(unsortedRecipiesList.Count-1);
        
        for (int i = 0; i < unsortedRecipiesList.Count; i=i+3)
        {
            ingriedientsString = unsortedRecipiesList[i].Split(",").ToList();
            stepsList = unsortedRecipiesList[i+1].Split(",").ToList();
            servingSize = unsortedRecipiesList[i+2].Split(",").ToList();
            ingriedientsString.RemoveAt(ingriedientsString.Count - 1);
            stepsList.RemoveAt(stepsList.Count - 1);
            //servingSize.RemoveAt(servingSize.Count - 1);
            List<Item> ingriedientsObj = CreateIngriedientsObjList(ingriedientsString);
            Recipe recipie1 = new Recipe(ingriedientsObj, stepsList, servingSize[0]);
            listOfRecipies.Add(recipie1);
        }
        return listOfRecipies;
 
        int stop = 333;

    }
    public void ClearList()
    {
        listOfRecipies.Clear();
        //File.WriteAllText(path,"");
    }
    private List<Item> CreateIngriedientsObjList(List<string>itemDetails)
    {
        List<Item> createdIngrdients = new List<Item>();
        for (int i = 0; i < itemDetails.Count; i = i + 4)
        {
            Item itemTemp = new Item(itemDetails[i], itemDetails[i + 1], itemDetails[i+3]);
            if (itemDetails[i + 2].ToLower() == "true")
            {
                itemTemp.ItemGot();
            }
            createdIngrdients.Add(itemTemp);
        }
        return createdIngrdients;
    }
    public string FormatAllRecipies()
    {
        string formattedRecipies = "";
        foreach(Recipe recipie in listOfRecipies)
        {
           formattedRecipies=formattedRecipies+recipie.GetFormatedForFile();
        }
        return formattedRecipies;
    }
   
}
