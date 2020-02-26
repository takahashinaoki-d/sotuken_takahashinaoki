using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxtime : MonoBehaviour
{
  public Drone1 drone1;
  public Drone2 drone2;
  public Drone3 drone3;
  public Drone4 drone4;
  int i = 0;
  public float seconds = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      seconds += Time.deltaTime;
      if(i == 0){
        if(drone1.searchplace == 6 && drone2.searchplace == 6){
          i++;
          Debug.Log(seconds);
        }
        if(drone2.searchplace == 6 && drone2.searchplace == 6){
          i++;
          Debug.Log(seconds);
        }
        if(drone3.searchplace == 6 && drone1.searchplace == 6){
          i++;
          Debug.Log(seconds);
        }
      }
    }
}
