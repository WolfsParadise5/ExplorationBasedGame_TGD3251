using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]

public class PlayerData
{
    public int income;
    public int cashBalance;
    public int sanityBalance;
    public int foodBarBalance;
    public Job[] jobs;

    //Inventory
    public Food[] food;
    public Item[] item;
    public FoodCombo[] homemadeFood;
}
