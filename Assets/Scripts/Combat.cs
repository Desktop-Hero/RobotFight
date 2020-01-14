using System;

class Combat {

    static Random rnd = new Random();
    static public int critHit2;
    
    static public Move SelectMove(Move[] moveset) {
        Move selectedMove = new Move("temp", 1, 1, 1);
        Console.WriteLine("Please select a move");
        Console.WriteLine("");
        Console.WriteLine("Press '1' for " + moveset[0].Name + ": Strength - " + moveset[0].Damage + ", Critical Hit Chance - " + moveset[0].CritChance + "%, Accuracy - " + moveset[0].Accuracy + "%");
        Console.WriteLine("Press '2' for " + moveset[1].Name + ": Strength - " + moveset[1].Damage + ", Critical Hit Chance - " + moveset[1].CritChance + "%, Accuracy - " + moveset[1].Accuracy + "%");
        Console.WriteLine("Press '3' for " + moveset[2].Name + ": Strength - " + moveset[2].Damage + ", Critical Hit Chance - " + moveset[2].CritChance + "%, Accuracy - " + moveset[2].Accuracy + "%");
        Console.WriteLine("Press '4' for " + moveset[3].Name + ": Strength - " + moveset[3].Damage + ", Critical Hit Chance - " + moveset[3].CritChance + "%, Accuracy - " + moveset[3].Accuracy + "%");
        ConsoleKeyInfo moveInput = Console.ReadKey(true);
        bool isTrue = true;
        while (isTrue) {
            switch(moveInput.KeyChar){
                    case '1' :
                        selectedMove = moveset[0];
                        isTrue = false;
                        break;
                    case '2':
                        selectedMove = moveset[1];
                        isTrue = false;
                        break;
                    case '3':
                        selectedMove = moveset[2];
                        isTrue = false;
                        break;
                    case '4':
                        selectedMove = moveset[3];
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response. Please select again.");
                        break;
            }
        }
        return selectedMove;
    }
    static public float Attack(float attackStrength, float health) {
        int critHit = 0;
        critHit = rnd.Next(1001);
        if (critHit <= 200) {
            attackStrength = attackStrength*2;
            Console.WriteLine("Critical Hit!");
        }
        critHit2 = critHit;
        return health - attackStrength;
        
        
    }

    static public int GetCritHit() {
        return critHit2;
    }
}