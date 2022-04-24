using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalFalse : LogicalEntry
{
    public LogicalFalse(string _name, int _posX, int _posY) : base(_name, _posX, _posY)
    {
        exit = 0;
    }
}
