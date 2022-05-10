using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afficheur7seg : LogicalExit
{
    public List<LogicalLED> led = new List<LogicalLED>();

    public Afficheur7seg(string _name, int _posX, int _posY, Sprite _sprite, Canvas canvas) : base(_name, _posX, _posY)
    {
        for (int i = 0; i < 7; i++)
        {
            led.Add(new LogicalLED(name + "_led_" + i, PosX(i), PosY(i), _sprite, canvas));
            led[i].led.transform.localScale /= 1.5f;
        }

        for (int i = 0; i < 7; i+= 3)
        {
            led[i].led.transform.Rotate(0, 0, 90);
        }
    }

    private int PosX(int i)
    {
        if (i == 1 || i ==2)
        {
            return posX + 100;
        }
        else if (i == 0 || i == 3 || i == 6)
        {
            return posX + 50;
        }
        return posX;
    }

    private int PosY(int i)
    {
        if (i == 0) { return posY + 200; }
        else if (i == 1 || i == 5) { return posY + 150; }
        else if (i == 6) { return posY + 100; }
        else if (i == 2 || i == 4) { return posY + 50; }
        else return posY;
    }
}
