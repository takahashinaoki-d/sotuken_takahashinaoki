using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone6 : MonoBehaviour
{
  public Vector3 pos;
  public Vector3 pos1;
  public Vector3 pos2;
  public Vector3 pos3;
  public Vector3 pos4;
  public Vector3 pos5;
  public Drone1 drone1;
  public Drone2 drone2;
  public Drone3 drone3;
  public Drone7 drone7;
  public Headoffice headoffice;
  public float distance;
  public float distance_;
  public float distance1;
  public float distance2;
  public float distance3;
  public float distance_x;
  public int select = 0;
  public float delaytime;
  public int flag = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      pos = transform.position;
      pos4 = headoffice.transform.position;
      pos1 = drone1.transform.position;
      distance1 = Vector3.Distance(pos4, pos1);
      pos2 = drone2.transform.position;
      distance2 = Vector3.Distance(pos4, pos2);
      pos3 = drone3.transform.position;
      distance3 = Vector3.Distance(pos4, pos3);

      if(distance1 >= distance2){
        if(distance2 >= distance3){
          distance = distance3;
          pos5 = pos3;
          // distance_x = (pos3.x - pos.x) / 2;
        }
        if(distance3 >= distance2){
          distance = distance2;
          pos5 = pos2;
          // distance_x = (pos2.x - pos.x) / 2;
        }
      }
      else if(distance2 >= distance1){
        if(distance1 >= distance3){
          distance = distance3;
          pos5 = pos3;
          // distance_x = (pos3.x - pos.x) / 2;
        }
        if(distance3 >= distance1){
          distance = distance1;
          pos5 = pos1;
          // distance_x = (pos1.x - pos.x) / 2;
        }
      }
      distance_x = (pos4.x + pos5.x) / 2;
      if(distance >= 29.9){
        select = 1;
      }
      if(select == 1){
        this.gameObject.transform.Translate (0.1f, 0, 0);
        if(pos.x >= distance_x){
          select = 2;
        }
      }
      if(select == 2){
        pos.x = distance_x;
        transform.position = pos;
        distance_ = Vector3.Distance(pos, pos5);
        if(distance_ >= 29.9){
          drone7.dmode = 11;
          select = 3;
        }
      }
      if(select == 3){

        pos.x = (drone7.transform.position.x + pos5.x) / 2;
        transform.position = pos;
      }
    }
}
