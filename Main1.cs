using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main1 : MonoBehaviour
{
    public static Main1 Instance;

    public Canvas canvas;

    public Sprite checkmark;
    public Sprite led;
    public Sprite aff7seg;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Création des interrupteurs
        LogicalToggle tg1 = new LogicalToggle("toggle1", -100, 0, checkmark, canvas);
        LogicalToggle tg2 = new LogicalToggle("toggle2", 100, 0, checkmark, canvas);

        // Création des LEDS
        LogicalLED led1 = new LogicalLED("LED1", -200, 200, led, canvas);
        LogicalLED led2 = new LogicalLED("LED2", -100, 200, led, canvas);
        LogicalLED led3 = new LogicalLED("LED3", 0, 200, led, canvas);
        LogicalLED led4 = new LogicalLED("LED4", 100, 200, led, canvas);
        LogicalLED led5 = new LogicalLED("LED5", 200, 200, led, canvas);

        // Création des gates
        LogicalAND and1 = new LogicalAND("and1", -200, 200);
        LogicalOR or1 = new LogicalOR("or1", -100, 200);
        LogicalNAND nand1 = new LogicalNAND("nand1", -0, 200);
        LogicalNOR nor1 = new LogicalNOR("nor1", 100, 200);
        LogicalXOR xor1 = new LogicalXOR("xor1", 200, 200);

        // Association des éléments
        led1.AddSource(and1);
        led2.AddSource(or1);
        led3.AddSource(nand1);
        led4.AddSource(nor1);
        led5.AddSource(xor1);

        and1.AddSource(tg1, 0);
        and1.AddSource(tg2, 1);
        or1.AddSource(tg1, 0);
        or1.AddSource(tg2, 1);
        nand1.AddSource(tg1, 0);
        nand1.AddSource(tg2, 1);
        nor1.AddSource(tg1, 0);
        nor1.AddSource(tg2, 1);
        xor1.AddSource(tg1, 0);
        xor1.AddSource(tg2, 1);
    }
}
