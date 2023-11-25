// See https://aka.ms/new-console-template for more information
ShoppingList userList = new ShoppingList();
userList.initialiseList();
userList.AddShopping("eggs", "2","NULL");
userList.AddShopping("bread", "1","NULL");
userList.AddShopping("milk", "4","pints");
userList.AddShopping("eggs", "2","cartons");
userList.AddShopping("lemons", "10","NULL");
userList.CheckOff("lemons");
List<string> formattedList = userList.GetFormattedList();
foreach(string item in formattedList)
{
    Console.WriteLine(item);
}
Console.WriteLine("\nRemoveTest");
userList.RemoveShopping("milk");
formattedList = userList.GetFormattedList();
foreach (string item in formattedList)
{
    Console.WriteLine(item);
}
Console.WriteLine("Save and open test");
userList.SaveList();
userList.ClearList();
userList.OpenList();
formattedList.Clear();
formattedList = userList.GetFormattedList();
foreach (string item in formattedList)
{
    Console.WriteLine(item);
}

Console.WriteLine("Recipie save test");
List<string> testSteps=new List<string>();
for(int i = 0; i < 10; i++)
{
    testSteps.Add($"step {i}");
}
List<Item> testItems=userList.GetItems();
Recipies testRecipies = new();
testRecipies.InitialiseRecipies();
testRecipies.addRecipe(testItems, testSteps, "4");
testRecipies.SaveList();
Console.WriteLine("openTEst");
testRecipies.ClearList();
testRecipies.FormatAllRecipies();
List<Recipe> testOpen = testRecipies.OpenList();
Console.WriteLine(testOpen[0].GetIngridients()[0].GetName());
Console.WriteLine(testOpen[0].GetSteps()[1]);
Console.WriteLine(testOpen[0].GetServingSize());
testOpen[0].GetFormatedForFile();


Console.WriteLine("recipe ingriedients to shopping list");
ShoppingList testList = new ShoppingList();
testList.initialiseList();
testOpen[0].AddToShoppingList(testList);
List<string> uh = testList.GetFormattedList();
foreach (string item in uh)
{
    Console.WriteLine(item);
}

