using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : TriggerZone
{
    public string nextLevel;
    public SpriteRenderer me;
    public bool active = false;
    public GameObject doortip;
    public string CurrentScene;
    public string LastScene;
    public string NextScene;

    public void setActive(){
        active = true;
        me.enabled = true;
    }

    public void nextScene()
    {
        CurrentScene = SceneManager.GetActiveScene().name;

        if (CurrentScene == "Store")
        {
            LastScene = LevelManager.getLastLevel();
            if (LastScene == "Level 1")
            {
                NextScene = "Level 2";
                LevelManager.setProgress(2);
            }
            else if (LastScene == "Level 2")
            {
                NextScene = "Level 3";
                LevelManager.setProgress(3);
            }
            else if (LastScene == "Level 3"){
                NextScene = "Level 4";
                LevelManager.setProgress(4);
            }
            PlayerController.health = 100;
            PlayerController.mana = 100;
        }
        else if (CurrentScene == "Level 4")
        {
            NextScene = "EndScreen";
        }
        else
        {
            NextScene = "Store";
            LevelManager.setLastLevel(CurrentScene);
        }
        SceneManager.LoadScene(NextScene);


    }
    

    protected override void TriggerAction(){
        if (active == true)
        {
            nextScene();
        }
    }
    protected override void EnableTip()
    {
        if (active == true){
            doortip.gameObject.SetActive(true);
        }
    }
    protected override void DisableTip()
    {
        if (active == true){
            doortip.gameObject.SetActive(false);
        }
    }
}
public static class LevelManager
    {
        private static string lastLevel;
        private static int progress = 1;

        public static void setLastLevel(string level)
        {
            lastLevel = level;
        }

        public static string getLastLevel()
        {
            return lastLevel;
        }

        public static void setProgress(int i){
            progress = i;
        }
        public static int getProgress(){
            return progress;
        }
    }
