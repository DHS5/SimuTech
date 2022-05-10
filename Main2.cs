using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main2 : MonoBehaviour
{
    public static Main2 Instance;

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
        LogicalTrue tr1 = new LogicalTrue("true1", 0, 0);
        LogicalButton bt1 = new LogicalButton("button1", 0, 0, canvas);

        // Création des gates
        BasculeD bd1 = new BasculeD("BD1", 0, 0);
        BasculeD bd2 = new BasculeD("BD2", 0, 0);
        LogicalAND and1 = new LogicalAND("and1", 0, 0);
        LogicalNOT not1 = new LogicalNOT("not1", 0, 0);
        LogicalNOT not2 = new LogicalNOT("not2", 0, 0);

        // Création de l'output
        LogicalLED led1 = new LogicalLED("led1", 0, 100, led, canvas);

        // Association des gates
        and1.AddSource(tr1, 0);
        and1.AddSource(not1, 1);
        not1.AddSource(bd2);
        not2.AddSource(bt1);
        bd2.AddSource(not2, 0);
        bd2.AddSource(bd1, 1);
        bd1.AddSource(bt1, 0);
        bd1.AddSource(not1, 1);
        led1.AddSource(bd1);
    }
}
