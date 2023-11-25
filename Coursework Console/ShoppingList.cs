class ShoppingList
{
    private List<Item> listOfItems;

    string path = "ShoppingList.txt";
    public void AddShopping(string item, string amount,string measurement)
    {

        foreach (Item listedItem in listOfItems)
        {
            if (listedItem.GetName() == item)
            {
                listedItem.IncreaseAmount(Convert.ToInt32(amount));
                return;
            }
            else
            {
                Item item1 = new Item(item,amount,measurement);
                listOfItems.Add(item1);
                return;
            }
        }
        Item item2 = new Item(item,amount,measurement);
        listOfItems.Add(item2);
    }
    public void RemoveShopping(string item)
    {
        foreach (Item listedItem in listOfItems)
        {
            if (listedItem.GetName() == item)
            {
                listOfItems.Remove(listedItem);
                return;
            }
        }
    }
    public void CheckOff(string item)
    {

        for (int i = 0; i < listOfItems.Count; i++)
        {
            if (listOfItems[i].GetName() == item)
            {
                listOfItems[i].ItemGot();
            };

        };
    }
    public List<string> GetFormattedList()
    {
        List<string> formattedItems = new List<string>();
        foreach (Item listedItem in listOfItems)
        {
            if (listedItem.IsGot() == true)
            {
                formattedItems.Add($"[X] {listedItem.GetName()} {listedItem.GetMeasurement()} {listedItem.GetAmount()}");
            }
            else
            {
                formattedItems.Add($"[ ] {listedItem.GetName()} {listedItem.GetMeasurement()} {listedItem.GetAmount()}");
            }
        }
        return formattedItems;
    }
    public void initialiseList()
    {
        listOfItems = new();
    }
    public void SaveList()
    {
        for (int i = 0; i < listOfItems.Count; i++)
        {
            File.AppendAllText(path, $"{listOfItems[i].GetDataForSaveFile()}");
        }
    }
    public void OpenList()
    {
        string contents = File.ReadAllText(path).Trim();
        List<string> itemDetails = contents.Split(",").ToList();
        itemDetails.RemoveAt(itemDetails.Count - 1);//needed as the formatting adds an empty index at last index
        for(int i = 0;i < itemDetails.Count; i= i+ 4)
        {
            Item itemTemp = new Item(itemDetails[i], itemDetails[i + 1], itemDetails[i+3]);
            if (itemDetails[i + 2].ToLower() == "true")
            {
                itemTemp.ItemGot();
            }
            listOfItems.Add(itemTemp);
        }
    }
    public void ClearList()
    {
        listOfItems.Clear();
        //File.WriteAllText(path,"");
    }
    public List<Item> GetItems()
    {
        List<Item> CopyOfList =new List<Item>();
        foreach(Item test in listOfItems)
        {
            CopyOfList.Add(test);
        }
        return CopyOfList;
    }
    public  void AddRecipeIngriedients(Item ingriedient)
    {
        listOfItems.Add(ingriedient);
    }
}
