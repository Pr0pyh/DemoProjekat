using Godot;
using System;

public class World : Node2D
{
    //Broj kocaka koji se moze staviti
    [Export]
    int broj;
    //Varijabla koja ce nositi instancu scene 
    KockaSmera kockaSmera;
    //Scena na osnovu koje se instancira
    PackedScene kockaSmeraScene;
    KockaSmera.VRSTA_KOCKE vrstaKocke;
    //Poziva se kada se napravi World scena
    public override void _Ready()
    {
        kockaSmeraScene = GD.Load<PackedScene>("res://scenes/KockaSmera.tscn");
    }

    //Poziva se pri svakom inputu
    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("ui_accept") && broj > 0)
        {
            kockaSmera = (KockaSmera)kockaSmeraScene.Instance();
            AddChild(kockaSmera);
            kockaSmera.drugaKocka(vrstaKocke);
            kockaSmera.GlobalPosition = GetGlobalMousePosition();
            broj--;
        }
    }

    public void _on_Button_pressed()
    {
        vrstaKocke = KockaSmera.VRSTA_KOCKE.LEVO;
    }
    public void _on_Button2_pressed()
    {
        vrstaKocke = KockaSmera.VRSTA_KOCKE.DESNO;
    }
    public void _on_Button3_pressed()
    {
        vrstaKocke = KockaSmera.VRSTA_KOCKE.GORE;
    }
    public void _on_Button4_pressed()
    {
        vrstaKocke = KockaSmera.VRSTA_KOCKE.DOLE;
    }
}
