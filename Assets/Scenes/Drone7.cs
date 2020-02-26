using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone7 : MonoBehaviour
{
  public Vector3 pos;
  public Vector3 pos4;
  public Vector3 pos5;
  public Drone6 drone6;
  public Headoffice headoffice;
  public float distance_x;
  public int select = 0;
  public int dmode = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(dmode == 11){
        pos = transform.position;
        pos4 = headoffice.transform.position;
        distance_x = ((2 * pos4.x) + drone6.pos5.x) / 3;
        select = 1;
      }
      if(select == 1){
        this.gameObject.transform.Translate (0.1f, 0, 0);
        if(pos.x >= distance_x){
          select = 2;
        }
      }
      if(select == 2){
        pos.x = (drone6.transform.position.x + pos4.x) / 2;
        transform.position = pos;
      }
    }
}
