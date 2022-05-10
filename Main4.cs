using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main4 : MonoBehaviour
{
    public static Main4 Instance;

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
        // Création des inputs
        LogicalToggle tg1 = new LogicalToggle("ToggleM1", -100, 0, checkmark, canvas);
        LogicalToggle tg2 = new LogicalToggle("ToggleM2", 100, 0, checkmark, canvas);
        LogicalToggle tg3 = new LogicalToggle("ToggleL1", -50, -100, checkmark, canvas);
        LogicalToggle tg4 = new LogicalToggle("ToggleL2", 50, -100, checkmark, canvas);
        LogicalButton bt1 = new LogicalButton("button1", 50, 50, canvas);

        // Création des gates
        Multiplexer m1 = new Multiplexer("M1", 0, 0, true);
        BasculeD bd1 = new BasculeD("BD1", 0, 0);
        ThreeStateDoor tsd1 = new ThreeStateDoor("TSD1", 0, 0);
        ThreeStateDoor tsd2 = new ThreeStateDoor("TSD2", 0, 0);

        // Création des outputs
        LogicalLED led1 = new LogicalLED("led1", -50, 150, led, canvas);

        // Association des sources
        tsd1.AddSource(tg1, 0);
        tsd1.AddSource(tg3, 1);
        tsd2.AddSource(tg2, 0);
        tsd2.AddSource(tg4, 1);
        m1.AddSource(tsd1, 0);
        m1.AddSource(tsd2, 1);
        bd1.AddSource(bt1, 0);
        bd1.AddSource(m1, 1);
        led1.AddSource(bd1);
    }
}
