using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code By: Adam Mitchell
//    On:11/06/2020

public class MenuManager : MonoBehaviour
{
    //Go to 
   public void playGame() { SceneManager.LoadScene("Level1"); }
    public void instruct() { SceneManager.LoadScene("InstructScene"); }
    //Go to Title
    public void backTitle() { SceneManager.LoadScene("TitleScene"); }
    //Go to Options 
    public void options() { SceneManager.LoadScene("OptionsScene"); }
    //Quit game
    public void exitGame(){ Application.Quit(); }



}
