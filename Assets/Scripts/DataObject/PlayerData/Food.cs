using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class Food
{
    public string foodName;
    public string foodDescription;
    public int foodPrice;
    public int foodBarIncrease;

    public Food(string foodName, string foodDescription, int foodPrice, int foodBarIncrease)
    {
        this.foodName = foodName;
        this.foodDescription = foodDescription;
        this.foodPrice = foodPrice;
        this.foodBarIncrease = foodBarIncrease;
    }
}
