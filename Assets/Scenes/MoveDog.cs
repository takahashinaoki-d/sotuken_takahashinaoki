using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MonoBehaviour {

    //スタートと終わりの目印
    public Transform endMarker;
    private Vector3 pos;

    // スピード
    public float speed = 1.0F;
    //二点間の距離を入れる
    private float distance_two;

    void Start()
    {
        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(transform.position, pos);
        pos = transform.position;
    }

    void Update()
    {

        // 現在の位置
        float present_Location = (Time.time * speed) / distance_two;

        pos.x += 0.01f;

        // オブジェクトの移動
        transform.position = Vector3.Lerp(transform.position, pos, present_Location);
    }
}
