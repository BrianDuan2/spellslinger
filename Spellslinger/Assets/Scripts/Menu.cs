using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void PlayGame(){
        PlayerController.health = 100;
        PlayerController.mana = 100;

        SceneManager.LoadScene("Level 1");
   }

   public void QuitGame(){
       Application.Quit();
   }

   public void ReturnToMenu(){
       SceneManager.LoadScene("Menu");
   }
}
