using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : MonoBehaviour
{
  public GameObject obj1; //担当の救助犬
  public Vector3 pos;
  public Vector3 pos2;
  public Vector3 pos3;
  public Quaternion pos4;
  public Move move;       //救助犬の挙動
  public Drone2 drone2;
  public Drone3 drone3;
  public Drone4 drone4;
  public Drone5 drone5;
  public Drone6 drone6;
  public Headoffice headoffice;
  public float seconds = 0.0f; //捜索制限時間
  public float time = 0.0f;    //捜索限界時間
  public float drone_time = 0.0f;
  public int count = 0;

  //捜索の制限時間
  public float t;
  //捜索の限界時間
  public float m;

  //次の捜索スタート場所
  public Vector3 end = new Vector3(10.0f,0.0f,5.0f);
  //捜索場所移動などの制御変数
  public  int flag = 1;
  //動ける範囲の制御
  public int left;
  public int right;
  public int top;
  public int bottom;
  public int center;
  public int searchplace = 1;
  public int waitplace = 1;
  public int dmode = 4;      //ドローンのモード
  public int mmode = 0;
  public int i = 0;
  public int j = 0;
  public int k = 0;
  public int finding = 0;
  public int exchange = 0;

    // Start is called before the first frame update
    void Start()
    {
      move.mode = 0;
      left = 0;
      right = 10;
      top = 10;
      bottom = 0;
      center = 5;
      m = Random.Range(60.0f,90.0f) / 2;

    }

    // Update is called once per frame
    void Update()
    {
      //shpheの現在位置
      pos = obj1.transform.position;
      drone_time += Time.deltaTime;
      //捜索待機中
      if(dmode == 0 || dmode == 1 || dmode == 2 || dmode == 3){
        time += Time.deltaTime;
        if(drone2.move.hit == 5 || drone3.move.hit == 5){
          time -= Time.deltaTime;
          if (finding == 1 && drone4.dmode != 9 && drone5.dmode != 9){
            if(flag == 1){
              pos3 = obj1.transform.position;
              if(drone2.move.hit == 5){
                pos2 = drone2.obj2.transform.position;
              }
              else if(drone3.move.hit == 5){
                pos2 = drone3.obj3.transform.position;
              }
              direction (pos2);
              station (pos2);
            }
            else if(pos.x <= pos2.x && pos.z <= pos2.z && flag == 2){
              find ();
            }
            else if(pos.x <= pos2.x && pos.z >= pos2.z && flag == 3){
              find ();
            }
            else if(pos.x >= pos2.x && pos.z <= pos2.z && flag == 4){
              find ();
            }
            else if(pos.x >= pos2.x && pos.z >= pos2.z && flag == 5){
              find ();
            }
          }
          else if (finding == 2){
            if(flag == 1){
              direction (pos3);
              station (pos3);
            }
          }
        }
        if(finding == 2){
          if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
            finded ();
          }
          else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
            finded ();
          }
          else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
            finded ();
          }
          else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
            finded ();
          }
        }
        if(finding == 0){
          if(time >= (30 - ((waitplace + 1) * 2))) {
            if(i == 0){
              drone5.dmode = 9;
              i++;
            }
          }

          if(time <= 30){
            dmode = 0;
            //捜索場所が移った場合
            searchmove ();
          }
          else if(time > 30){
            if(dmode == 0){
              if(drone2.count == 1 && drone3.count == 1){
                if(drone2.time >= drone3.time){
                  if((drone2.move.mode == 0) || (drone2.move.mode == 3)){
                    // drone5.dmode = 9;
                    dmode = 2;
                  }
                }
                else if (drone2.time < drone3.time){
                  if((drone3.move.mode == 0) || (drone3.move.mode == 3)){
                    // drone5.dmode = 9;
                    dmode = 3;
                  }
                }
              }
              else if(drone2.count == 1){
                if((drone2.move.mode == 0) || (drone2.move.mode == 3)){
                  // drone5.dmode = 9;
                  dmode = 2;
                }
              }
              else if(drone3.count == 1){
                if((drone3.move.mode == 0) || (drone3.move.mode == 3)){
                  // drone5.dmode = 9;
                  dmode = 3;
                }
              }
            }
            if(flag == 1){
              //捜索場所が移った場合
              searchmove ();
            }
            if(move.mode != 2){
              count = 2;
            }
            else if(move.mode == 2){
              count = 0;
            }
            //交代の合図が来たとき
            //どちらのドローンかで場合分け
            if(count == 2){
              if(dmode == 2){
                if((drone2.move.mode == 0) || (drone2.move.mode == 3)){
                  if(drone5.dmode != 9){
                    if(flag == 1){
                      //Sphre（２）の現在位置
                      pos2 = drone2.obj2.transform.position;
                      pos4 = drone2.obj2.transform.rotation;
                      direction (pos2);
                      move.mode = 3;
                      exchange = 2;
                      //pos2の場所によって場合分け
                      station (pos2);
                    }
                  }
                }
                if(pos.x <= pos2.x && pos.z <= pos2.z && flag == 2){
                  renew2 ();
                }
                else if(pos.x <= pos2.x && pos.z >= pos2.z && flag == 3){
                  renew2 ();
                }
                else if(pos.x >= pos2.x && pos.z <= pos2.z && flag == 4){
                  renew2 ();
                }
                else if(pos.x >= pos2.x && pos.z >= pos2.z && flag == 5){
                  renew2 ();
                }
              }
              else if(dmode == 3){
                if((drone3.move.mode == 0) || (drone3.move.mode == 3)){
                  if(drone5.dmode != 9){
                    if(flag == 1){
                      //Sphre(3)の現在位置
                      pos2 = drone3.obj3.transform.position;
                      pos4 = drone3.obj3.transform.rotation;
                      direction (pos2);
                      move.mode = 3;
                      exchange = 3;
                      //pos2の場所によって場合分け
                      station (pos2);
                    }
                  }
                }
                if(pos.x <= pos2.x && pos.z <= pos2.z && flag == 2){
                  renew3 ();
                }
                else if(pos.x <= pos2.x && pos.z >= pos2.z && flag == 3){
                  renew3 ();
                }
                else if(pos.x >= pos2.x && pos.z <= pos2.z && flag == 4){
                  renew3 ();
                }
                else if(pos.x >= pos2.x && pos.z >= pos2.z && flag == 5){
                  renew3 ();
                }
              }
            }
          }
        }
      }
      //捜索中の挙動
      else{
        //犬の捜索制限時間の計算
        time += Time.deltaTime;
        //制限時間内
        if(seconds <= t){
          //捜索終了までの時間の計算
          seconds += Time.deltaTime;
          //活動時間内
          if(time <= m){
            dmode = 4;
            if(move.hit == 0){
              //範囲外に出た場合
              if((pos.x < left) || (pos.x > right) || (pos.z > top) || (pos.z < bottom)){
                seconds -= Time.deltaTime;
                move.mode = 1;
                }
              //範囲内の挙動
              else{
                move.mode = 0;
              }
            }
            else if(move.hit == 1){
              if(j == 0){
                j++;
                mmode = move.mode;
                pos3 = obj1.transform.position;
                pos4 = obj1.transform.rotation;
              }
            }
            if((move.hit >= 1 && move.hit <= 4) && (drone2.move.hit == 5 || drone3.move.hit == 5)){
              seconds -= Time.deltaTime;
              if(flag == 1){
                direction (pos3);
                //現在位置によって場合分け
                station (pos3);
                move.hit = 6;
              }
            }
            if(move.hit == 6){
              seconds -= Time.deltaTime;
              if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
                research ();
              }
              else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
                research ();
              }
              else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
                research ();
              }
              else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
                research ();
              }
            }
            if(move.hit == 5){
              seconds -= Time.deltaTime;
              if(drone2.finding == 0){
                if(drone2.dmode == 0 || drone2.dmode == 1 || drone2.dmode == 2 || drone2.dmode == 3){
                  if(drone2.move.mode != 3){
                    drone2.finding = 1;
                  }
                }
              }
              if(drone3.finding == 0){
                if(drone3.dmode == 0 || drone3.dmode == 1 || drone3.dmode == 2 || drone3.dmode == 3){
                  if(drone3.move.mode != 3){
                    drone3.finding = 1;
                  }
                }
              }
              if(drone2.finding == 2 || drone3.finding == 2){
                if(flag == 1){
                  direction (pos3);
                  //現在位置によって場合分け
                  station (pos3);
                }
                if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
                  research ();
                }
                else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
                  research ();
                }
              }
            }
          }
          //活動時間外
          else if(time > m){
            if(i == 0){
              move.v =  (move.v * 2) / 3;
              i++;
            }
            if(k == 0){
              k++;
              dmode = 6;
            }
            //ドローンに交代要請を送る
            count = 1;
            waitplace = searchplace;
            //交代要請受理
            if(drone2.dmode == 1 || drone3.dmode == 1){
              if(drone2.move.mode != 2 && drone3.move.mode != 2){
                if(drone2.exchange == 1 || drone3.exchange == 1){
                  if(move.mode == 0){
                    dmode = 5;
                    pos4 = obj1.transform.rotation;
                  }
                }
              }
            }
            if(dmode == 5){
              seconds -= Time.deltaTime;
              if(flag == 1){
                //待機中の犬の現在位置
                if(drone2.dmode == 1){
                  pos2 = drone2.obj2.transform.position;
                }
                else if(drone3.dmode == 1){
                  pos2 = drone3.obj3.transform.position;
                }
                direction (pos2);
                move.mode = 3;
                //現在位置によって場合分け
                station (pos2);
              }
              if(pos.x <= pos2.x && pos.z <= pos2.z && flag == 2){
                reset2 ();
              }
              else if(pos.x <= pos2.x && pos.z >= pos2.z && flag == 3){
                reset2 ();
              }
              else if(pos.x >= pos2.x && pos.z <= pos2.z && flag == 4){
                reset2 ();
              }
              else if(pos.x >= pos2.x && pos.z >= pos2.z && flag == 5){
                reset2 ();
              }
            }
            else if(dmode == 6){
              if(move.hit == 0){
                //範囲外に出た場合
                if((pos.x < left) || (pos.x > right) || (pos.z > top) || (pos.z < bottom)){
                  seconds -= Time.deltaTime;
                  move.mode = 1;
                  }
                //範囲内の挙動
                else{
                  seconds -= (Time.deltaTime / 3);
                  move.mode = 0;
                }
              }
              if(move.hit == 1){
                if(j++ == 0){
                  mmode = move.mode;
                  pos3 = obj1.transform.position;
                  pos4 = obj1.transform.rotation;
                }
              }
              if(move.hit >= 1 && move.hit <= 4){
                seconds -= (Time.deltaTime / 3);
              }
              if((move.hit >= 1 && move.hit <= 4) && (drone2.move.hit == 5 || drone3.move.hit == 5)){
                seconds -= Time.deltaTime;
                if(flag == 1){
                  direction (pos3);
                  //現在位置によって場合分け
                  station (pos3);
                  move.hit = 6;
                }
              }
              if(move.hit == 6){
                seconds -= Time.deltaTime;
                if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
                  research ();
                }
                else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
                  research ();
                }
              }
              if(move.hit == 5){
                seconds -= Time.deltaTime;
                if(drone2.finding == 0){
                  if(drone2.dmode == 0 || drone2.dmode == 1 || drone2.dmode == 2 || drone2.dmode == 3){
                    drone2.finding = 1;
                  }
                }
                if(drone3.finding == 0){
                  if(drone3.dmode == 0 || drone3.dmode == 1 || drone3.dmode == 2 || drone3.dmode == 3){
                    drone3.finding = 1;
                  }
                }
                if(drone2.finding == 2 || drone3.finding == 2){
                  if(flag == 1){
                    direction (pos3);
                    //現在位置によって場合分け
                    station (pos3);
                  }
                }
                if(pos.x <= pos3.x && pos.z <= pos3.z && flag == 2){
                  research ();
                }
                else if(pos.x <= pos3.x && pos.z >= pos3.z && flag == 3){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z <= pos3.z && flag == 4){
                  research ();
                }
                else if(pos.x >= pos3.x && pos.z >= pos3.z && flag == 5){
                  research ();
                }
              }
            }
          }
        }
        //制限時間外
        else if(seconds > t){
          dmode = 7;
          if(flag == 1){
            direction (end);
            searchplace += 1;
            waitplace += 1;
            //現在位置によって場合分け
            if(pos.x >= right){
              if(pos.z >= center){
                flag = 2;
              }
              else if(pos.z < center){
                flag = 3;
              }
            }
            else if(pos.x < right){
              if(pos.z >= center){
                flag = 4;
              }
              else if(pos.z < center){
                flag = 5;
              }
            }
          }
          if(pos.x <= right && pos.z <= center && flag == 2){
            reset1 ();
          }
          if(pos.x <= right && pos.z >= center && flag == 3){
            reset1 ();
          }
          if(pos.x >= right && pos.z <= center && flag == 4){
            reset1 ();
          }
          if(pos.x >= right && pos.z >= center && flag == 5){
            reset1 ();
          }
        }
      }
      if(headoffice.people == headoffice.p){
        Application.Quit ();
        move.mode = 4;
      }
    }
    void searchmove (){
      if((waitplace < drone2.searchplace) && (waitplace < drone3.searchplace)){
        if(drone4.dmode != 9 && drone5.dmode != 9){
          time -= Time.deltaTime;
          move.mode = 2;
          if(waitplace == searchplace){
            if(pos.x >= right){
              move.mode = 4;
              //flag = 1;
              waitplace += 1;
            }
          }
          else if(waitplace < searchplace){
            if(pos.x >= left){
              move.mode = 4;
              //flag = 1;
              waitplace += 1;
            }
          }
        }
      }
    }
    void direction (Vector3 die){
      //次の捜索始点の角度を求める
      obj1.transform.rotation = Quaternion.identity;
      float dx = die.x - pos.x;
      float dz = die.z - pos.z;
      float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
      obj1.transform.Rotate(new Vector3(0,-rad,0));
      move.mode = 2;
    }
    void renew2 (){
      searchplace = drone2.searchplace;
      left = drone2.left;
      right = drone2.right;
      top = drone2.top;
      bottom = drone2.bottom;
      center = drone2.center;
      end = drone2.end;
      obj1.transform.rotation = drone2.pos4;
      move.mode = 0;
      dmode = 4;
      flag = 1;
      count = 0;
      seconds = drone2.seconds;
      time = 0;
      exchange = 0;
      i = 0;
    }
    void renew3 (){
      searchplace = drone3.searchplace;
      left = drone3.left;
      right = drone3.right;
      top = drone3.top;
      bottom = drone3.bottom;
      center = drone3.center;
      end = drone3.end;
      obj1.transform.rotation = drone3.pos4;
      move.mode = 0;
      dmode = 4;
      flag = 1;
      count = 0;
      seconds = drone3.seconds;
      time = 0;
      exchange = 0;
      i = 0;
    }
    void reset1 (){
      obj1.transform.rotation = Quaternion.identity;
      left += 10;
      right += 10;
      end.x += 10.0f;
      flag = 1;
      seconds = 0;
      move.mode = 0;
      k = 0;
    }
    void reset2(){
      obj1.transform.rotation = Quaternion.identity;
      dmode = 0;
      move.mode = 4;
      time = 0;
      flag = 1;
      k = 0;
      i = 0;
      if(drone2.waitplace <= drone3.waitplace){
        waitplace = drone2.waitplace;
      }
      else if(drone2.waitplace > drone3.waitplace){
        waitplace = drone3.waitplace;
      }
      m = Random.Range(60.0f,90.0f);
      move.v =  (move.v * 3) / 2;
      drone4.dmode = 9;
    }
    void research(){
      obj1.transform.rotation = pos4;
      j = 0;
      k = 0;
      flag = 1;
      move.hit = 0;
      move.mode = mmode;
    }
    void find (){
      finding = 2;
      flag = 1;
      headoffice.people += 1;
    }
    void finded (){
      obj1.transform.rotation = Quaternion.identity;
      move.mode = 4;
      finding = 0;
      flag = 1;
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
