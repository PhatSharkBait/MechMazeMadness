using UnityEngine;
using System.Collections;
using System;


public class Timer: MonoBehaviour 
{
  float currentTime;
  bool started = false;
  bool finished = false;
  //To be used for output on GUI label(string type)
  public string currentTimeText;
  private string currMin;
  private string currSec;
  private string currMill;


  void Start(){
    currentTime = 0; 
    currMin = "00";
    currSec = "00";
    currMill = "00";   
  }

  void isFinished() {
      if(transform.position.x > 23 && transform.position.z > 23){
          finished = true;
      }
  }

  void isStarted(){
      if(transform.position.x > -23 | transform.position.z > -23){
          started = true;
      }
     
  }




  void Update () {
      isStarted();
      isFinished();
      if(started && !finished){
        currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if(time.Minutes < 10) {
            currMin = "0" + time.Minutes.ToString();
        }
        else {
            currMin = time.Minutes.ToString();
        }
        if(time.Seconds < 10) {
            currSec = "0" + Mathf.RoundToInt(time.Seconds).ToString();
        }
        else {
            currSec = time.Seconds.ToString();
        }
        if(time.Milliseconds < 10){
            currMill = "0" + Mathf.RoundToInt(time.Milliseconds).ToString();
        }
        else {
            currMill = time.Milliseconds.ToString();
        }
        
        currentTimeText = currMin + ":" + currSec + ":" + currMill;
      }
      else {
          currentTimeText = currMin + ":" + currSec + ":" + currMill;
      }
    
  }


  void OnGUI(){
    GUI.Label(new Rect(Screen.width - 60, Screen.height-20, 200, 80), currentTimeText);
  }
}
