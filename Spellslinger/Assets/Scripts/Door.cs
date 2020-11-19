using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : TriggerZone
{
    public string nextLevel;
    public SpriteRenderer me;
    public bool active = true;

    
    public void setActive(){
        active = true;
        me.enabled = true;
    }
    public void nextScene(){
        SceneManager.LoadScene(nextLevel);
    }

    protected override void TriggerAction(){
        if (active == true){
            nextScene();
        }
    }
}
