using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

    void Start () {
        StartCoroutine (RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay() {
        while (true) {
            SetRandomPosition ();
            // コルーチンを遅延させてから再開させる
            yield return new WaitForSeconds (1);
        }
    }

    void SetRandomPosition() {
        float x = Random.Range (-5.0f, 5.0f);
        float z = Random.Range (-5.0f, 5.0f);
        Debug.Log ("x,z: " + x.ToString ("F2") + ", " + z.ToString ("F2"));
        Vector3 pos = transform.position;
        pos.x += x;
        pos.z += z;
        transform.position = Vector3.Lerp(transform.position, pos, 0.5f);
    }
}
