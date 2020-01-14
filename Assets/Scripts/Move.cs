using System;

public class Move {
    public string Name;
    public int Damage;
    public int CritChance;
    public int Accuracy;

    public Move (string name, int damage, int critChance, int accuracy) {
        this.Name = name;
        this.Damage = damage;
        this.CritChance = critChance;
        this.Accuracy = accuracy;
    }
}