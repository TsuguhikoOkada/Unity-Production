using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //�@���̃v���n�u�i�[�z��
    public GameObject[] birdPrefabs;

    //�@�A������p�̒��̋���
    const float birdDistance = 1.4f;

    //�@�N���b�N���ꂽ�����i�[
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
            //�@�N���b�N�n�_�Ńq�b�g���Ă���I�u�W�F�N�g���擾
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(info.screenPoint),
                                                 Vector2.zero);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                //�@�q�b�g�����I�u�W�F�N�g��Tag��bird��������
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
            //�@�N���b�N�n�_�Ńq�b�g���Ă���I�u�W�F�N�g���擾
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(info.screenPoint),
                                                 Vector2.zero);
            if (hit.collider != null)
            {
                GameObject hitObj = hit.collider.gameObject;
                //�@�q�b�g�����I�u�W�F�N�g��Tag��bird�Ȃ����A���O���ꏏ
                //�@�Ō�Ƀq�b�g�����I�u�W�F�N�g�ƈႤ�A���X�g�ɂ͓����Ă��Ȃ�
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

    //�@�w�肳�ꂽ�������𔭐�������R���[�`��
    IEnumerator DropBird(int count)
    {
        for (int i = 0; i < count; i++)
        {
            //�@�����_���ŏo���ʒu���쐬
            Vector2 pos = new Vector2(Random.Range(-2.9f, 2.9f), 7.3f);

            //�@�o�����钹��ID���쐬
            int id = Random.Range(0, birdPrefabs.Length);

            //�@���𔭐�������
            GameObject bird = (GameObject) Instantiate(birdPrefabs[id],
                pos,
                Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward));

            //�@�쐬�������̖��O��ID���g���Ă��Ȃ���
            bird.name = "Bird" + id;

            // 0.05�b�҂��Ď��̏�����
            yield return new WaitForSeconds(0.05f);
        }
    }
}
