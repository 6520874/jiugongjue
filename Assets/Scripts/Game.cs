using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;
    [SerializeField] private GameObject bg;

    private Player m_player = null;
    private Player m_enemy = null;

    private float curTime = 0;

    private int m_sendPk = 0;

    private int id;

    private  List<GameObject> m_cards = new List<GameObject>();

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }




    private void Awake()
    {

        //dotwen插件

        CreatePorker();
        m_player =  this.gameObject.AddComponent<Player>();

        m_enemy = this.gameObject.AddComponent<Player>();

        m_player.isMy = true;
        //Debug.Log("awake");
        ////DOLocalMove
        //myHpObj.transform.DOLocalMove(new Vector2(10, 20), 3f);
        //myHpObj.transform.DOMove(new Vector2(100, 200),5f);





    }

 
    void CreatePorker()
    {

        for(int i= 0; i < 106; i++)
        {
            //加载资源
            ResourcesLoader.Instance.LoadAsync("Prefeab/Card", (obj) =>
            {
                if (obj != null)
                {
                    GameObject tt = (GameObject)Instantiate(obj, bg.transform);

                      
                    tt.transform.localPosition = Vector3.zero;
                    this.m_cards.Add(tt);

                   
        
                    //tt.transform.parent = bg.transform.parent;
                }
                else
                {
                    Debug.Log("<color=red>no obj</color>");
                }
            });


        }
    }

    void Start()
    {
         
        



    }



    // Update is called once per frame
    void Update()
    {   

         if(m_cards.Count > 0)
        {
            this.curTime += Time.deltaTime;

            if(this.curTime> 3)
            {
                if (m_sendPk < 8)
                {
                    //向自己发牌
                    m_cards[m_sendPk]?.GetComponent<Card>().setFront(1);
                    //m_cards[m_sendPk]?.GetComponent<Card>().type = CardType.front;
                    m_player.handCard.Add(m_cards[m_sendPk]);

                   m_cards[m_sendPk++].transform.DOLocalMove(new Vector2(0, -500), 0.1f);

                   
                    //向电脑发牌
                    m_cards[m_sendPk++].transform.DOLocalMove(new Vector2(0, 500), 0.1f);

                }
                this.curTime = 0;
            }

          
           
             
        }
    }
}
