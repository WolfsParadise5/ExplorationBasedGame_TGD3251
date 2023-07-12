using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class Stock
{
    public string name;
    public string category;
    public float overallProfit;
    public int price;
    public int quantity;

    public Stock(string name, string category, float overallProfit, int price, int quantity)
    {
        this.name = name;
        this.category = category;
        this.overallProfit = overallProfit;
        this.price = price;
        this.quantity = quantity;
    }
}
