using System;

public class Robot {
    public string Name;
    public float Health;
    public float Attack;
    public Move[] MoveSet;

    public string getName() {
        return Name;
    }
    public float getHealth() {
        return Health;
    }
    public float getAttack() {
        return Attack;
    }
    public Robot (string name, float health, float attack, Move[] moveset) {
        this.Name = name;
        this.Health = health;
        this.Attack = attack;
        this.MoveSet = moveset;
    }
}

    