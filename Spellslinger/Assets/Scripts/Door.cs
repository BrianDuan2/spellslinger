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
            }
            else if (LastScene == "Level 2")
            {
                NextScene = "Level 3";
            }
            PlayerController.health = 100;
            PlayerController.mana = 100;
        }
        else
        {
            NextScene = "Store";
            LevelManager.setLastLevel(CurrentScene);
        }
        SceneManager.LoadScene(NextScene);


    }
    public static class LevelManager
    {
        private static string lastLevel;

        public static void setLastLevel(string level)
        {
            lastLevel = level;
        }

        public static string getLastLevel()
        {
            return lastLevel;
        }
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
