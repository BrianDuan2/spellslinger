using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : TriggerZone
{
    

    
    public SpriteRenderer me;
    private bool active = false;

    
    public void setActive(){
        active = true;
        me.enabled = true;
    }
    public void nextScene(){
        SceneManager.LoadScene("Level 2");
    }

    protected override void TriggerAction(){
        nextScene();
    }
}
