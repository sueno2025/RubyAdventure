using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4f;
    GameObject dialogBox;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox = transform.GetChild(0).gameObject;
        dialogBox.SetActive(false);
        timerDisplay = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >= 0){
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0){
                dialogBox.SetActive(false);
            }
        }
    }
    public void DisplayDialog(){
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
