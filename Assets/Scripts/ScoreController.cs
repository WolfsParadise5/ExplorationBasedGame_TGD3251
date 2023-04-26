using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int karma { get; set; }
    public int influence { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        karma = 0;
        influence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
