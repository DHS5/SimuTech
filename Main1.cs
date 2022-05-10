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
        LogicalButton bt = new LogicalButton("bouton1", 100, 100, canvas);
        LogicalToggle tg = new LogicalToggle("toggle1", -100, 100, checkmark, canvas);
        LogicalLED led1 = new LogicalLED("LED1", 0, 200, led, canvas);
        LogicalLED led2 = new LogicalLED("LED2", -100, 200, led, canvas);
        LogicalLED led3 = new LogicalLED("LED1", 0, 300, led, canvas);
        LogicalLED led4 = new LogicalLED("LED2", -100, 300, led, canvas);
        LogicalNOT not1 = new LogicalNOT("tg1-NOT-LED1", 0, 0);
        LogicalNOT not2 = new LogicalNOT("tg1-NOT-LED3", 0, 0);
        Afficheur7seg a7s = new Afficheur7seg("aff7seg1", 0, -200, aff7seg, canvas);
        BasculeD BD1 = new BasculeD("BD1", 0, 0);
        BasculeD BD2 = new BasculeD("BD2", 0, 0);
        BD1.AddSource(bt, 0);
        BD1.AddSource(tg, 1);
        BD2.AddSource(bt, 0);
        BD2.AddSource(tg, 1);
        not1.AddSource(BD2);
        led1.AddSource(not1);
        led2.AddSource(BD1);
        not2.AddSource(tg);
        led3.AddSource(not2);
        led4.AddSource(tg);
        LogicalLED led5 = new LogicalLED("LED2", 500, 300, led, canvas);
        LogicalFalse f1 = new LogicalFalse("False1", 0, 0);
        Multiplexer M1 = new Multiplexer("M1", 0, 0, false);
        ThreeStateDoor TSD1 = new ThreeStateDoor("3SD1", 0, 0);
        ThreeStateDoor TSD2 = new ThreeStateDoor("3SD2", 0, 0);
        LogicalButton bt2 = new LogicalButton("bouton2", 500, 100, canvas);
        LogicalNOT not3 = new LogicalNOT("bt2-NOT-TSD2", 0, 0);

        not3.AddSource(bt2);
        TSD1.AddSource(bt2, 0);
        TSD1.AddSource(bt2, 1);
        TSD2.AddSource(not3, 0);
        TSD2.AddSource(f1, 1);
        M1.AddSource(TSD1, 0);
        M1.AddSource(TSD2, 1);
        led5.AddSource(M1);
    }
}
