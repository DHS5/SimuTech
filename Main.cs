using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

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
        LogicalButton bt = new LogicalButton("bouton1", 100, 100);
        LogicalToggle tg = new LogicalToggle("toggle1", -100, 100);
        LogicalLED led1 = new LogicalLED("LED1", 0, 200, led);
        LogicalLED led2 = new LogicalLED("LED2", -100, 200, led);
        LogicalNOT not = new LogicalNOT("tg1-NOT-LED1", 0, 0);
        Afficheur7seg a7s = new Afficheur7seg("aff7seg1", 0, -200, aff7seg);
        not.AddSource(tg);
        led1.AddSource(not);
        led2.AddSource(tg);
    }
}
