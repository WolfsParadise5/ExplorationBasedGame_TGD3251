using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PropertyButtonScript : MonoBehaviour
{
    private string ID;
    public void setID(string ID)
    {
        this.ID = ID;
    }

    public bool isID(string ID)
    {
        return this.ID.Equals(ID);
    }
}
