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
  }

  void isFinished() {
      if(transform.position.x > 23 && transform.position.z > 23){
          finished = true;
      }
  }

  void isStarted(){
      if(transform.position.x > -22 | transform.position.z > -22){
          started = true;
      }
      currMin = "00";
      currSec = "00";
      currMill = "00";
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
        
        currentTimeText = currMin + ":" + currSec + ":" + currMill  + " X: " + Mathf.Round((transform.position.x)) + " Y: " + Mathf.Round((transform.position.z));
      }
      else {
          currentTimeText = currMin + ":" + currSec + ":" + currMill  + " X: " + Mathf.Round((transform.position.x)) + " Y: " + Mathf.Round((transform.position.z));
      }
    
  }


  void OnGUI(){
    GUI.Label(new Rect(Screen.width - 180, Screen.height-20, 200, 80), currentTimeText);
  }
}
