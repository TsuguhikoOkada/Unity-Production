using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //　鳥のプレハブ格納配列
    public GameObject[] birdPrefabs;

    //　連鎖判定用の鳥の距離
    const float birdDistance = 1.4f;

    //　クリックされた鳥を格納
    private GameObject firstBird;
    private GameObject lastBird;
    private string currentName;
    List<GameObject> removableBirdList = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        TouchManager. Began += (info) =>
        {
            //if (firstBird != null)
            //{
            //    return;
            //}
            //　クリック地点でヒットしているオブジェクトを取得
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(info.screenPoint),
                                                 Vector2.zero);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                //　ヒットしたオブジェクトのTagがbirdだったら
                if (hitObj.tag == "bird")
                {
                    firstBird = hitObj;
                    lastBird = hitObj;
                    currentName = hitObj.name;
                    removableBirdList = new List<GameObject>();
                    PushToBirdList(hitObj);
                }
            }

        };
        TouchManager.Moved += (info) =>
        {
            if (firstBird == null)
            {
                return;
            }
            //　クリック地点でヒットしているオブジェクトを取得
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(info.screenPoint),
                                                 Vector2.zero);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                //　ヒットしたオブジェクトのTagがbirdなおかつ、名前が一緒
                //　最後にヒットしたオブジェクトと違う、リストには入っていない
                if (hitObj.tag == "bird" && hitObj.name == currentName 
                //&& lastBird != hitObj && 0 > removableBirdList.IndexOf(hitObj)
                 )
                {
                    Debug.Log(hitObj.name);
                    lastBird = hitObj;
                    
                    PushToBirdList(hitObj);
                }
            }
        };
        TouchManager.Ended += (info) =>
        {
            foreach (GameObject obj in removableBirdList)
            {
                changeColor(obj, 1.0f);
            }
            removableBirdList = new List<GameObject>();
            firstBird = null;
            lastBird = null;
     
        };
        
        
        StartCoroutine(DropBird(52));
    }



    private void PushToBirdList(GameObject obj)
    {
        removableBirdList.Add(obj);
        changeColor(obj, 0.5f);
       
    }

    private void changeColor(GameObject obj, float transparency)
    {
        SpriteRenderer birdTexture = obj.GetComponent<SpriteRenderer>();
        birdTexture.color = new Color(birdTexture.color.r,
                                      birdTexture.color.g, 
                                      birdTexture.color.b, 
                                      transparency);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    //　指定された個数分鳥を発生させるコルーチン
    IEnumerator DropBird(int count)
    {
        for (int i = 0; i < count; i++)
        {
            //　ランダムで出現位置を作成
            Vector2 pos = new Vector2(Random.Range(-2.9f, 2.9f), 7.3f);

            //　出現する鳥のIDを作成
            int id = Random.Range(0, birdPrefabs.Length);

            //　鳥を発生させる
            GameObject bird = (GameObject) Instantiate(birdPrefabs[id],
                pos,
                Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward));

            //　作成した鳥の名前をIDを使ってつけなおす
            bird.name = "Bird" + id;

            // 0.05秒待って次の処理へ
            yield return new WaitForSeconds(0.05f);
        }
    }
}
