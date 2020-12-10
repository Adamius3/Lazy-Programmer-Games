using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Coded by:
 * Adam Mitchell
 * Timothy Garcia
 * On:11/06/2020
 */

public class MenuManager : MonoBehaviour
{
    

    //Go to Title Menu
    public void backTitle() { SceneManager.LoadScene("TitleScene"); }

    //Go to Instructions Menu
    public void instruct() { SceneManager.LoadScene("InstructScene"); }
    
    //Go to Options Menu
    public void options() { SceneManager.LoadScene("OptionsScene"); }
    
    //Go to Level 1 Scene
    public void playGame() { SceneManager.LoadScene("Level1"); }

    //Level 1 transition scene
    public void level1Tran() { SceneManager.LoadScene("LevelTransition1"); }

    //Options scene for level 1 transition
    public void optionsLvl1() { SceneManager.LoadScene("OptionsLvl1"); }

    //Go to Level 2 Scene
    public void level2() { SceneManager.LoadScene("Level2"); }

    //Level 1 transition scene
    public void level2Tran() { SceneManager.LoadScene("LevelTransition2"); }

    //Options scene for level 1 transition
    public void optionsLvl2() { SceneManager.LoadScene("OptionsLvl2"); }

    //Go to Level 3 Scene
    public void level3() { SceneManager.LoadScene("Level3"); }

    //Quit game
    public void exitGame(){ Application.Quit(); }



}
