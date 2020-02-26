using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Drone5_ : MonoBehaviour
{
  public int dmode = 8;
  public Drone1_ drone1;
  public Drone2_ drone2;
  public Drone3_ drone3;
  public Drone4_ drone4;
  public Vector3 pos;
  public Vector3 pos2;
  public Vector3 pos3;
  public int flag = 1;
  public int i = 0;
  public int j = 0;
  public int select = 0;
  public float drone_time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
      if(dmode == 100){
        pos.x += 30.0f;
        transform.position = pos;
        dmode = 8;

      }
      if(drone4.dmode == 100){
        DelaySample();
      }
      else{
      pos = transform.position;
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
   async void DelaySample(){
    await Task.Delay(drone4.t);
  }
}
