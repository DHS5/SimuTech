using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalTrue : LogicalEntry
{
    public LogicalTrue(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        exit = 1;
    }
}
