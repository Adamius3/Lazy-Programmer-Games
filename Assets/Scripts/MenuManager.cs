using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void playGame() 
   {
        SceneManager.LoadScene("MainScene"); 
   }
    
    public void options() { 
    
    
    }
    public void exitGame()
    {

        Application.Quit();
    }



}
