using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class gameControl : MonoBehaviour
{
    public Light GlobalLight;
    public ZombieCharacterControl character;
    public Image timerSlider;
    public int TotalTime = 60;
    private int RemainTime = 60;

    void TimerCountDown() {
        if (RemainTime == 0) return;
        RemainTime--;
        if ((float)RemainTime / TotalTime > 0.17f)
        {
            timerSlider.fillAmount = (float)RemainTime / TotalTime;
        }
        else {
            timerSlider.fillAmount = 0.17f;
        }
        if (RemainTime == 0) {
            timerSlider.fillAmount = 0;
            character.dead();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RemainTime = TotalTime;
        timerSlider.fillAmount = (float)RemainTime/ TotalTime;
        InvokeRepeating("TimerCountDown", 1f, 1f);
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void replay() {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
