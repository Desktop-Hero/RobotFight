using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotFight : MonoBehaviour
{
    int critHit;
    int roundCount = 1;
    int i;
    int exclusion = 0;
    float p1MaxHealth;
    float cpuMaxHealth;
    int PlayerNum = 0;
    Robot p1;
    Robot cpu;
    Robot Megatron;
    Robot Zagreb;
    Robot[] contenders;
    Move[] MegatronMoves;
    string[] Test;

    public SimpleHealthBar p1HealthBar;
    public SimpleHealthBar cpuHealthBar;

    string[] soundEffects = {"Bam! ", "Pow! ", "Biff! ", "Whack! ", "Crash! ", "Crunch! ", "Blammo! "};
    string[] critSounds = {"Super ", "Mega ", "Ultra ", "Incredi-",};


    /*Move Drill = new Move("Drill", 12, 15, 100);
    Move Crunch = new Move("Crunch", 15, 20, 90);
    Move PowerToss = new Move("Power Toss", 20, 10, 80);
    Move Bulldoze = new Move("Bulldoze", 15, 10, 100);*/

    //This method runs when the Play button is pressed, it initializes the Robot objects and the arrays
    public void Startup(){
        SceneManager.LoadScene("CharacterSelect");
        MegatronMoves = new Move[4] {new Move("Drill", 12, 15, 100), new Move("Crunch", 15, 20, 90), new Move("Power Toss", 20, 10, 80), new Move("Bulldoze", 15, 10, 100)};

        Megatron = new Robot("Megatron", Mathf.Round(Random.Range(0.0f, 50.0f)) + 50, Mathf.Round(Random.Range(0.0f, 9.0f)) + 6, MegatronMoves);
        Zagreb = new Robot("Zagreb", Mathf.Round(Random.Range(0.0f, 50.0f)) + 60, Mathf.Round(Random.Range(0.0f, 9.0f)) + 5, MegatronMoves);

        //This array contains the Robot objects which the player will be able to choose from. It is referenced fine on line 50, but not on line 61
        contenders = new Robot[2] {Megatron, Zagreb};

        //This array isn't able to be referenced in the PickChar() method either
        Test = new string[3] {"one", "two", "three"};

        Debug.Log(contenders[0].Name);
        Debug.Log(Test[0]);

        Debug.Log("TestStart");
    }

    //This method runs when a button is pressed in the CharacterSelect scene, it sets a local variable to 0 or 1 depending on which button is pressed
    public void PickChar(int selectedNum) {
        PlayerNum = selectedNum;
        //This line should display the name of the chosen fighter as soon as it is clicked ingame, but it doesn't.
        //Right here it gives the error: "NullReferenceException: Object reference not set to an instance of an object"
        Debug.Log(contenders[PlayerNum].Name);
        //This line should display the first member of the Test array, but doesn't
        Debug.Log(Test[0]);
        StartGame();
    }

    //This method sets the p1 and cpu objects, which will be the main variables in the battle loop
    void StartGame() {
        p1 = contenders[0];
        exclusion = PlayerNum;

        cpu = contenders[random_except_list(contenders.Length, new int[]{exclusion})];
        Debug.Log("Your opponent will be: " + cpu.Name);
        Debug.Log("");

        p1MaxHealth = p1.Health;
        cpuMaxHealth = cpu.Health;

        SceneManager.LoadScene("BattleScene");
    }

    //This method isn't finished yet, but it will contain the main battle loop
    void RunBattle() {

        Debug.Log("");

        while(p1.getHealth() > 0 && cpu.getHealth() > 0) {
            Debug.Log("Round " + roundCount + ": FIGHT!");      
            Debug.Log("---------------");
            Debug.Log("");
            cpu.Health = Combat.Attack(p1.getAttack(), cpu.getHealth());
            cpuHealthBar.UpdateBar(cpu.getHealth(), cpuMaxHealth);
            critHit = Combat.GetCritHit();
            if (critHit <= 200) {
                Debug.Log(p1.Name + " did " + (p1.Attack*2) + " damage to " + cpu.Name);
                Debug.Log("");
            }
            else {
                Debug.Log(p1.Name + " did " + (p1.Attack) + " damage to " + cpu.Name);
                Debug.Log("");
            }
            Thread.Sleep(1000);
            p1.Health = Combat.Attack(cpu.getAttack(), p1.getHealth());
            p1HealthBar.UpdateBar(p1.getHealth(), p1MaxHealth);
            critHit = Combat.GetCritHit();
            if (critHit <= 200) {
                Debug.Log(cpu.Name + " did " + (cpu.Attack*2) + " damage to " + p1.Name);
                Debug.Log("");
            }
            else {
                Debug.Log(cpu.Name + " did " + (cpu.Attack) + " damage to " + p1.Name);
                Debug.Log("");
            }
            Thread.Sleep(2000);
            Debug.Log(p1.Name + "'s remaining health: " +p1.Health);
            Debug.Log("");
            Debug.Log(cpu.Name + "'s remaining health: " + cpu.Health);
            Debug.Log("");
            roundCount++;
            Thread.Sleep(2500);
        }
        if ((p1.Health <= 0) && (cpu.Health > 0)) {
            Debug.Log(cpu.Name + " wins!");
            Debug.Log("Better luck next time.");
        }
        else if ((p1.Health > 0) && (cpu.Health <= 0)) {
            Debug.Log(p1.Name + " has defeated " + cpu.Name + "!");
        }
        else {
            Debug.Log("The two combatants have annihilated each other...");
        }
    }

    public static int random_except_list(int n, int[] x){
    
        System.Random r = new System.Random();
        int result = r.Next(n - x.Length);

        for (int i = 0; i < x.Length; i++) 
        {
            if (result < x[i])
                return result;
            result++;
        }
        return result;
    }
}
