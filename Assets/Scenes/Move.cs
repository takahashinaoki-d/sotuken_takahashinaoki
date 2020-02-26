using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Move : MonoBehaviour {
	public Drone1 drone;

	//public GameObject obj1;
	//public GameObject obj2;
	//public GameObject obj3;
  private int count = 0;
	public int Count{
		get{ return this.count; }
		private set{ this.count = value; }
	}
	//どれだけ回転するか
	public float y;
	//動ける範囲の制御
	private int left;
	private int right;
	private int top;
	private int bottom;
	private int center;

	//捜索時間
	private float seconds = 0.0f;
	private float limittime;
	//捜索や移動の場合分け
	public int mode = 0;
	//どの位置を捜索しているか
	private float place = 1;
	//捜索の制限時間
	public int t = 5;
	//捜索スピード
	public float v = 0.0075f;
	//次の捜索スタート場所
  private Vector3 end = new Vector3(5.0f,0.05f,0.0f);
	private float rot = -20.0f;
	public int hit = 0;
	public int i;
	public int j = 0;
	public GameObject[] array = new GameObject[4];
	public string rescue = "rescue";
  public string g;
  public string smell1 = "smell1";
  public string smell2 = "smell2";
  public string smell3 = "smell3";
	public Vector3 pos2;
	public Vector3 pos3;
	public Quaternion pos4;
	public float ran;
	public GameObject a;
	public int select = 1;

	//捜索範囲の設定
	void Start () {
		//obj1 = GameObject.Find("Sphere");
		//obj2 = GameObject.Find("Sphere (2)");
		//obj3 = GameObject.Find("Sphere (3)");
		left = -5;
		right = 5;
		top = 5;
		bottom = -5;
		center = 0;
		i = 20;
		j = 0;


	}

	// Update is called once per frame
	void Update () {
		if(select == 2){
			DelaySample();
		}
		else{
		if(hit == 1){
			mode = 5;
			if(i < 50){
				i += 1;
			}
			else{
				ran = 120f;
				moving (ran);
			}
		}
		else if(hit == 2){
			mode = 6;
			if(i < 50){
				i += 1;
			}
			else{
				ran = 90f;
				moving (ran);
			}
		}
		else if(hit == 3){
			mode = 7;
			if(i < 50){
				i += 1;
			}
			else{
				ran = 60f;
				moving (ran);
			}
		}
		else if (hit == 4){
			mode = 8;
		}
		else if (hit == 6){
			for(; j >= 0; j--){
				Destroy(array[j]);
				array[j] = null;
			}
			j++;
		}
		if(limittime >=0){
			//角度をランダムに変えながらx軸方向に進める
			if(mode == 0){
				seconds += Time.deltaTime;
				limittime = seconds;
				this.gameObject.transform.Translate (v, 0, 0);
				y = Random.Range(-15f,15f);
				transform.Rotate(new Vector3(0,y,0));
				rot = -20.0f;
				//transform.position = (new Vector3 (Mathf.Clamp (transform.position.x,left,right),transform.position.y,Mathf.Clamp (transform.position.z,bottom,top)));
			}

			//次の捜索範囲に戻る
			else if(mode == 1){
				this.gameObject.transform.Translate(v, 0, 0);
				transform.Rotate(new Vector3(0,rot,0));
				rot += 0.5f;
			}
			else if(mode == 2){
				this.gameObject.transform.Translate(v, 0, 0);

			}
			else if(mode == 3){
				this.gameObject.transform.Translate(v, 0, 0);

			}
			else if(mode == 4){

			}
			else if(mode == 5){
				this.gameObject.transform.Translate (v/2, 0, 0);
				y = Random.Range(-15f,15f);
				transform.Rotate(new Vector3(0,y,0));
			}
			else if(mode == 6){
				this.gameObject.transform.Translate (v/3, 0, 0);
				y = Random.Range(-10f,10f);
				transform.Rotate(new Vector3(0,y,0));
			}
			else if(mode == 7){
				this.gameObject.transform.Translate (v/4, 0, 0);
				y = Random.Range(-5f,5f);
				transform.Rotate(new Vector3(0,y,0));
			}
			else if(mode == 8){
				hit = 5;

			}
		}
	}
	}
	 async void DelaySample(){
		await Task.Delay(t);
		select = 1;
	}

		void moving (float ran){
			//次の捜索始点の角度を求める
			transform.rotation = Quaternion.identity;
			float dx = pos2.x - transform.position.x;
			float dz = pos2.z - transform.position.z;
			float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
			float y = Random.Range(-ran,ran);
			transform.Rotate(new Vector3(0,-rad,0));
			transform.Rotate(new Vector3(0,y,0));

			i = 0;
		}
		void OnTriggerEnter(Collider collision)
    {
			if(mode != 3){
				if(g == collision.gameObject.name){

				}
				else{
		      g = collision.gameObject.name;
					if(g == "dog1" || g == "dog2" || g == "dog3"){

					}
					else{
						array[j] = GameObject.Find(collision.gameObject.name);
			      pos2 = array[j].transform.position;
						j++;
			      if(g == rescue){
							Debug.Log(collision.gameObject.name); // ログを表示する
			        hit = 4;
						 for(j = 3; j >= 0; j--){
							 Destroy(array[j]);
							 array[j] = null;
						 }
						 j++;
			      }
			      else if(g == smell1){
							pos3 = transform.position;
							pos4 = transform.rotation;
			        hit = 1;
			      }
			      else if(g == smell2){
			        hit = 2;
			      }
			      else if(g == smell3){
			        hit = 3;
			      }
					}
				}
			}
    }
	}
