using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour {
	//どれだけ回転するか
	private float y;
	//動ける範囲の制御
	private int left;
	private int right;
	private int top;
	private int bottom;
	private int center;

	//捜索時間
	private float seconds = 0.0f;
	//捜索や移動の場合分け
	private float mode = 1;
	//どの位置を捜索しているか
	private float place = 1;
	//捜索の制限時間
	public float t = 20;
	//捜索スピード
	public float v = 0.01f;
	//次の捜索スタート場所
  private Vector3 end = new Vector3(5.0f,0.05f,10.0f);

	//捜索範囲の決定
	void Start () {
		left = -5;
		right = 5;
		top = 15;
		bottom = 5;
		center = 10;


	}

	// Update is called once per frame
	void Update () {

		//角度をランダムに変えながらx軸方向に進める
		if(seconds < t){
			seconds += Time.deltaTime;
			this.gameObject.transform.Translate (v, 0, 0);
			y = Random.Range(-15f,15f);
			transform.Rotate(new Vector3(0,y,0));
			transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,bottom,top)));
		}

		//次の捜索始点への移動
		if(seconds > t){
			if(place < 5){
				if (mode == 1) {
					//次の捜索始点の角度を求める
					transform.rotation = Quaternion.identity;
					float dx = end.x - transform.position.x;
					float dz = end.z - transform.position.z;
					float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
					transform.Rotate(new Vector3(0,-rad,0));
					//真ん中より上か下かで場合分け
					if(transform.position.z >= center){
						mode = 2;
					}
					if(transform.position.z < center){
						mode = 3;
					}
				}

				//真ん中より上の場合
				if (mode == 2) {
					this.gameObject.transform.Translate (v, 0, 0);
					transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,center,top)));
					if(transform.position == end){
						reset1 ();
					}
				}

				//真ん中より下の場合
				if (mode == 3){
					this.gameObject.transform.Translate (v, 0, 0);
					transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,bottom,center)));
					if(transform.position == end){
						reset1 ();
					}
				}
			}

			//捜索折り返し地点
			else if(place == 5){
				if (mode == 1) {
					end.z += 20.0f;
					center += 20;

					//次の捜索始点の角度を求める
					transform.rotation = Quaternion.identity;
					float dx = end.x - transform.position.x;
					float dz = end.z - transform.position.z;
					float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
					transform.Rotate(new Vector3(0,-rad,0));
					mode = 2;
				}

				if(mode == 2){
					this.gameObject.transform.Translate (v, 0, 0);
					transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,bottom,center)));
					if(transform.position == end){
						reset2 ();
					}
				}
			}

			//捜索折り返し後
			else if(place > 5 && place < 10){
				if (mode == 1) {
					//次の捜索始点の角度を求める
					transform.rotation = Quaternion.identity;
					float dx = transform.position.x - end.x;
					float dz = transform.position.z - end.z;
					float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
					transform.Rotate(new Vector3(0,-rad,0));
					//真ん中より上か下かで場合分け
					if(transform.position.z >= center){
						mode = 2;
					}
					if(transform.position.z < center){
						mode = 3;
					}
				}

				//真ん中より上の場合
				if (mode == 2) {
					this.gameObject.transform.Translate (v, 0, 0);
					transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,center,top)));
					if(transform.position == end){
						reset3 ();
					}
				}

				//真ん中より下の場合
				if (mode == 3){
					this.gameObject.transform.Translate (v, 0, 0);
					transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,bottom,center)));
					if(transform.position == end){
						reset3 ();
					}
				}
			}
			//捜索終了
			else if(place == 10){

			}
		}
	}

	//捜索制限時間のリセットや捜索範囲の更新
	void reset1 (){
		transform.rotation = Quaternion.identity;
		left += 10;
		right += 10;
		end.x += 10.0f;
		mode = 1;
		place += 1;
		seconds = 0;
	}
	void reset2 (){
		transform.rotation = Quaternion.identity;
		bottom += 20;
		top += 20;
		v = -0.1f;
		end.x -= 10.0f;
		mode = 1;
		place += 1;
		seconds = 0;
	}
	void reset3 (){
		transform.rotation = Quaternion.identity;
		left -= 10;
		right -= 10;
		end.x -= 10.0f;
		mode = 1;
		place += 1;
		seconds = 0;
	}
}
