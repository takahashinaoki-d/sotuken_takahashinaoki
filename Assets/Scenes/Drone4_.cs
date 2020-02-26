using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone4_ : MonoBehaviour
{
  public int dmode = 8;
  public int flag = 1;
  public int i = 0;
  public int j = 0;
  public float drone_time = 0.0f;
  public Vector3 pos;
  public Vector3 pos2;
  public Vector3 pos3;
  public Vector3 pos4;
  public Vector3 pos5;
  public Vector3 pos6;
  public Drone1_ drone1;
  public Drone2_ drone2;
  public Drone3_ drone3;
  public Drone5_ drone5;
  public float distance;
  public float distance1;
  public float distance2;
  public float distance3;
  public float distance_x;
  public int select = 0;
  public float delaytime;
  public float time = 0.0f;
  public int t = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      pos = transform.position;
      pos4 = drone1.transform.position;
      distance1 = Vector3.Distance(pos, pos4);
      pos5 = drone2.transform.position;
      distance2 = Vector3.Distance(pos, pos5);
      pos6 = drone3.transform.position;
      distance3 = Vector3.Distance(pos, pos6);

      if(distance1 >= distance2){
        if(distance2 >= distance3){
          distance = distance3;
        }
        if(distance3 >= distance2){
          distance = distance2;
        }
      }
      else if(distance2 >= distance1){
        if(distance1 >= distance3){
          distance = distance3;
        }
        if(distance3 >= distance1){
          distance = distance1;
        }
      }

      if(distance >= 29.9){
        time += Time.deltaTime;
        if(time < t){
          dmode = 100;
        }
        else{
          dmode = 1;
          pos.x += 30.0f;
          transform.position = pos;
          drone5.dmode = 100;
          time = 0.0f;
        }

      }
    }
    void LateUpdate()
    {
      pos = transform.position;
      if(distance < 30){
        if(drone1.finding == 0 && drone2.finding == 0 && drone3.finding == 0){
          if(dmode == 9){
            if(i == 0){
              i++;
            }
            else if(i == 1){
              if(flag == 1){
                pos3 = transform.position;
                if(drone1.dmode == 0 || drone1.dmode == 1 || drone1.dmode == 2 || drone1.dmode == 3){
                  pos2 = drone1.transform.position;
                  select = 1;
                }
                if(drone2.dmode == 0 || drone2.dmode == 1 || drone2.dmode == 2 || drone2.dmode == 3){
                  pos2 = drone2.transform.position;
                  select = 2;
                }
                if(drone3.dmode == 0 || drone3.dmode == 1 || drone3.dmode == 2 || drone3.dmode == 3){
                  pos2 = drone3.transform.position;
                  select = 3;
                }
                direction (pos2);
                station (pos2);
              }
            }
          }
        }
        if(dmode == 9){
          drone_time += Time.deltaTime;
          this.gameObject.transform.Translate (0.1f, 0, 0);
          if(i == 1){
            if(pos.x <= pos2.x && pos.z <= pos2.z && flag == 2){
              renew9 ();
            }
            else if(pos.x <= pos2.x && pos.z >= pos2.z && flag == 3){
              renew9 ();
            }
            else if(pos.x >= pos2.x && pos.z <= pos2.z && flag == 4){
              renew9 ();
            }
            else if(pos.x >= pos2.x && pos.z >= pos2.z && flag == 5){
              renew9 ();
            }
          }
        }
        if(dmode == 10){
          if(flag == 1){
            direction (pos3);
            station (pos3);
          }
          this.gameObject.transform.Translate (0.1f, 0, 0);
          // pos.x = Mathf.Clamp(pos.x, pos2.x, pos3.x);
          // pos.z = Mathf.Clamp(pos.z, pos2.z, pos3.z);
          if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
            transform.rotation = Quaternion.identity;
            dmode = 8;
            flag = 1;
            select = 0;
          }
          else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
            transform.rotation = Quaternion.identity;
            dmode = 8;
            flag = 1;
            select = 0;
          }
          else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
            transform.rotation = Quaternion.identity;
            dmode = 8;
            flag = 1;
            select = 0;
          }
          else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
            transform.rotation = Quaternion.identity;
            dmode = 8;
            flag = 1;
            select = 0;
          }
        }
     }
     else if(distance >= 30){

     }
     void renew9 (){
       transform.rotation = Quaternion.identity;
       dmode = 10;
       flag = 1;
       i = 0;
       if(select == 1){
         drone1.drone_time = drone_time;
       }
       else if(select == 2){
         drone2.drone_time = drone_time;
       }
       else if(select == 3){
         drone3.drone_time = drone_time;
       }
       drone_time = 0.0f;
     }
     void direction (Vector3 die){
       //次の捜索始点の角度を求める
       float dx = die.x - pos.x;
       float dz = die.z - pos.z;
       float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
       transform.Rotate(new Vector3(0,-rad,0));
     }
     void station (Vector3 sta){
       if(pos.x >= sta.x){
         if(pos.z >= sta.z){
           flag = 2;
         }
         if(pos.z < sta.z){
           flag = 3;
         }
       }
       else if(pos.x < sta.x){
         if(pos.z >= sta.z){
           flag = 4;
         }
         if(pos.z < sta.z){
           flag = 5;
         }
       }
     }
   }
}
