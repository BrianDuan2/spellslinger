using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : TriggerZone
{
    public string nextLevel;
    public SpriteRenderer me;
    public bool active = true;
    public GameObject doortip;

    
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
    protected override void EnableTip()
    {
        doortip.gameObject.SetActive(true);
    }
    protected override void DisableTip()
    {
        doortip.gameObject.SetActive(false);
    }
}
