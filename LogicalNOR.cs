using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalNOR : LogicalDoor
{
    public LogicalNOR(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        maxSources = 2;
        InitSources();
    }

    protected override void Calculate()
    {
        // Code here the calculate method of the Logical Component
        exit = entries[1] == 0 && entries[0] == 0 ? 1 : 0;


        // Keep this line at the end to call the base method
        base.Calculate();
    }
}
