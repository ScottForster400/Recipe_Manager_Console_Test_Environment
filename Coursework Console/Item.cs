class Item
{
    private string name;
    private int amount=1;
    private bool itemBeenGot = false;
    private string measurement = "NULL";

    public Item(string selectedName, string selectedAmount,string selectedMeasurement)  
    {
        name = selectedName;
        bool isInt = Int32.TryParse(selectedAmount, out amount);
        if (isInt == true)
        {
            amount = Convert.ToInt32(selectedAmount);
        }
        measurement = selectedMeasurement;
    }
    public string GetName()
    {
        return name;
    }
    public int GetAmount() 
    { 
        return amount; 
    }
    public string GetMeasurement()
    {
        return measurement;
    }
    public void ItemGot()
    {
        itemBeenGot = true;
    }
    public void IncreaseAmount(int increaseBy)
    {
        amount = amount + increaseBy;
    }
    public bool IsGot()
    {
        return itemBeenGot;
    }
    public string GetDataForSaveFile()
    {
        return $"{name},{amount},{itemBeenGot},{measurement},";
    }
    

}