using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
  public float t = 5;
  public Vector3 end = new Vector3(5.0f,0.05f,0.0f);
  public int flag = 1;
  public int left = -5;
  public int right = 5;
  public int top = 5;
  public int bottom = -5;
  public int center = 0;
  public int searchplace = 1;
  public int waitplace = 1;
  public int dmode = 1;
  public int count = 0;
  public float seconds = 0.0f;
  public GameObject obj1;
  public GameObject obj2;
  public GameObject obj3;




    // Start is called before the first frame update
    void Start()
    {
      left = -5;
      right = 5;
      top = 5;
      bottom = -5;
      center = 0;
    }

    // Update is called once per frame
    void Update()
    {
      seconds += Time.deltaTime;

    }
    public void reset0 (){
      //obj1.transform.rotation = obj3.transform.rotation;
      //move.mode = 1;
      //dmode = 1;
      //flag = 1;
      //count = 0;
    }
    public void reset1 (){
      obj1.transform.rotation = Quaternion.identity;
      left += 10;
      right += 10;
      end.x += 10.0f;
      seconds = 0;
      searchplace += 1;
    }
    public void reset2 (){
      obj1.transform.rotation = Quaternion.identity;
      bottom += 20;
      top += 20;
      end.x -= 10.0f;
      seconds = 0;
      searchplace += 1;
    }
    public void reset3 (){
      obj1.transform.rotation = Quaternion.identity;
      left -= 10;
      right -= 10;
      end.x -= 10.0f;
      seconds = 0;
      searchplace += 1;
    }
}
