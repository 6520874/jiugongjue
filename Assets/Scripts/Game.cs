using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;
    [SerializeField] private GameObject bg;

    private Player m_player = null;
    private Player m_enemy = null;

    private float curTime = 0;

    private int m_sendPk = 0;

    private int id;
    
    [SerializeField] private GameObject m_cardPrefab;
   public  Button m_btnQipai;
   public  Button m_btnAttack;


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


    public void eventClickBlock(EventData data)
    {
        Debug.Log("clickBlock");
    }

    private void Awake()
    {

        //dotwen插件

        CreatePorker();
        xiPai();
        m_player =  this.gameObject.AddComponent<Player>();

        m_enemy = this.gameObject.AddComponent<Player>();

        m_player.isMy = true;

        EventType eventType = EventType.ClickBlock;
       /// DelegateEvent.EventHandler listener = OnClickEventHandler();

        EventManager.addEventListener(eventType, eventClickBlock);
        //Debug.Log("awake");
        ////DOLocalMove




        CanvasScaler canvasScaler = FindObjectOfType<CanvasScaler>();
        if (canvasScaler != null)
        {
            //s
            Vector2 referenceResolution = canvasScaler.referenceResolution;
            Debug.Log("Canvas Reference Resolution: " + referenceResolution);
        }

        //// 获取屏幕分辨率
        //int screenResolutionWidth = Screen.currentResolution.width;
        //int screenResolutionHeight = Screen.currentResolution.height;
        //Debug.Log("Screen resolution: " + screenResolutionWidth + " x " + screenResolutionHeight);      
            
    }

    public static void Shuffle(List<GameObject> list)
    {
        System.Random rand = new System.Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            GameObject temp = list[j];
            list[j] = list[i];
            list[i] = temp;
        }
    }



    void xiPai()
    {
      
       Shuffle(this.m_cards);
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


                    tt.GetComponent<Card>().num = i;
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

            if(this.curTime> Config.FAPAITIME)
            {
                if (m_sendPk < 8)
                {
                    //向自己发牌
                    m_cards[m_sendPk]?.GetComponent<Card>().setFront(1);

                    GameObject obj = m_cards[m_sendPk];

                    //m_cards[m_sendPk]?.GetComponent<Card>().type = CardType.front;
                    m_player.handCard.Add(m_cards[m_sendPk]);
                    m_cards[m_sendPk].GetComponent<Card>().isMine = true;
                    m_cards[m_sendPk++].transform.DOLocalMove(new Vector2(0, -550), 0.1f);
                    m_cards.Remove(obj);

                    //向电脑发牌
                    obj = m_cards[m_sendPk];
                    m_cards[m_sendPk].GetComponent<Card>().isMine = false;
                    m_cards[m_sendPk++].transform.DOLocalMove(new Vector2(0, 550), 0.1f);
                    m_cards.Remove(obj);
                }
                else
                {
                     //剩余卡牌隐藏
                    for(int i=0; i<m_cards.Count;i++)
                    {
                        m_cards[i].SetActive(false);
                    }
                    myHpObj.transform.DOLocalMove(new Vector2(-10, 20), 0.1f);
                    enemyHpObj.transform.DOLocalMove(new Vector2(20, -30), 0.1f);
                }
                this.curTime = 0;
            }

          
           
             
        }
    }
}
