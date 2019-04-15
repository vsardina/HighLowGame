using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Variables
    Text TextDisplayGamePlay;
    Text TextName;
    Text TextBet;
    Text TextBank;
    InputField TextDisplayBank;
    Text TextDisplayPRoll;
    Text TextDisplayCRoll;
    public int bank = 100;
    int bet = 0;
    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate Objects
        //USER INPUT
        TextName = GameObject.Find("Canvas/InputFieldName/Text").GetComponent<Text>();
        TextBet = GameObject.Find("Canvas/InputFieldBet/Text").GetComponent<Text>();
        TextBank = GameObject.Find("Canvas/InputFieldBank/Text").GetComponent<Text>();

        //TEXT DISPLAY
        TextDisplayGamePlay = GameObject.Find("Canvas/TextDisplayGamePlay").GetComponent<Text>();
        TextDisplayBank = GameObject.Find("Canvas/InputFieldBank").GetComponent<InputField>();
        TextDisplayPRoll = GameObject.Find("Canvas/TextDisplayPRoll").GetComponent<Text>();
        TextDisplayCRoll = GameObject.Find("Canvas/TextDisplayCRoll").GetComponent<Text>();

        TextDisplayGamePlay.text = "Hello, ...";
        //TextDisplayBank.text = " $" + bank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to handle button click
    public void handleButtonRollClicked()
    {
        Debug.Log("handleButtonRollClicked() started");
        //Variables
        int pDie = Random.Range(1, 7);
        int cDie = Random.Range(1, 7);
        string result = "lose";
        bool goodBet = false;
        bet = System.Convert.ToInt32(TextBet.text);
        bank = System.Convert.ToInt32(TextBank.text);
        if (bet <= bank)    //catch if they bet more than their bank
        {
            goodBet = true;
        }
        string greeting = "Hello, " + TextName.text + ".\n"
                        + "---------------------------------------\n\n";
        if (bank > 0) //catch if they have altered the bank amount
        {
            playing = true;
        }
        if (playing)
        {
            GameObject.Find("Canvas/InputFieldName").GetComponent<InputField>().readOnly = true;
            GameObject.Find("Canvas/InputFieldBank").GetComponent<InputField>().readOnly = true;

            TextDisplayGamePlay.text = greeting;
            if (goodBet)
            {
                TextDisplayPRoll.text = pDie.ToString();
                TextDisplayCRoll.text = cDie.ToString();
                if (pDie >= cDie) //WIN
                {
                    result = "win";
                    bank += bet;
                }
                else //LOSE
                {
                    bank -= bet;
                    if (bank <= 0)
                    {
                        GameObject.Find("Canvas/InputFieldName").GetComponent<InputField>().readOnly = false;
                        GameObject.Find("Canvas/InputFieldBank").GetComponent<InputField>().readOnly = false;
                        result += ". Please add more money to the bank";
                        playing = false;
                    }
                }

                TextDisplayGamePlay.text = greeting + "You " + result + ".\n"
                                         + "Your bank is $" + bank + ".\n"
                    + "---------------------------------------\n";

                TextDisplayBank.text = bank.ToString();
            }
            else
            {
                TextDisplayGamePlay.text = greeting + "Your bet is greater than your bank."
                                         + "\nPlease enter a smaller amount.\n"
                                         + "Your bank is $" + bank + ".\n"
                    + "---------------------------------------\n";
            }
        }


        /* SAMPLE RUN
         * 
            + "Your bank is $" + bank + ".\n"
            + "You bet $" + bet + ".\n"
            + "I rolled a 5.\n"
            + "You rolled a 3.\n"
            + "You lose.\n"
            + "Your bank is $" + bank + ".\n"
            + "------------------------------------------------\n";
        */

    }
}
