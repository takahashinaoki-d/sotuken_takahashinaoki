using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headoffice : MonoBehaviour
{
  public float alltime = 0.0f;
  public int people = 0;
  public int p;
  public int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      alltime += Time.deltaTime;
      if(people == p){
        if(i == 0){
          Debug.Log(alltime);
          i++;
        }
      }
    }
}
