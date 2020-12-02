using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void PlayGame(){
        PlayerController.health = 100;
        PlayerController.mana = 100;

        SceneManager.LoadScene("Opening");
   }

   public void QuitGame(){
       Application.Quit();
   }

   public void ReturnToMenu(){
       SceneManager.LoadScene("Menu");
   }

   public void Continue(){
       int i = LevelManager.getProgress();
       switch(i){
            case(1):
                SceneManager.LoadScene("Level 1");
            break;
            case(2):
                SceneManager.LoadScene("Level 2");
            break;
            case(3):
                SceneManager.LoadScene("Level 3");
            break;
            case(4):
                SceneManager.LoadScene("Level 4");
            break;
       }
   }
}
