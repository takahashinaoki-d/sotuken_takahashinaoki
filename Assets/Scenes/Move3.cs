using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
  public Move move;
  int n=0;
    // Start is called before the first frame update
    void Start()
    {
      //move = GameObject.Find("Move");
      n = move.Count;
      Debug.Log(n);

    }

    // Update is called once per frame
    void Update()
    {
      n = move.Count;
      if(n == 0){

      }
      else if(n == 1){
        Debug.Log(n);
      }

    }
}
