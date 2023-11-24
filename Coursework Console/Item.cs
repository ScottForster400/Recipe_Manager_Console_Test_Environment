class Item
{
    private string name;
    private int amount=1;
    private bool itemBeenGot = false;
    private string measurement = "NULL";

    public Item()//Add constructor class
    {
            
    }

    public void SetMeasurement(string selectedMeasurement)
    {
        measurement = selectedMeasurement;
    }
    public void SetItemData(string selectedName, int  selectedAmount) //gnjdfgjkdflgjldf
    {
        name = selectedName.ToLower();
        amount = selectedAmount;
    }
    public string GetName()
    {
        return name;
    }
    public int GetAmount() 
    { 
        return amount; 
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