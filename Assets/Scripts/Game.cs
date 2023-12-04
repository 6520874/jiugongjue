using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;
using VSCodeEditor;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;
    [SerializeField] private GameObject bg;
    [SerializeField] private GameObject myCard;
    [SerializeField] private GameObject cards;
    [SerializeField] private GameObject btns;
    [SerializeField] private Button socketBtn;
    
    


    private Player m_player = null;
    private Player m_enemy = null;

    private float curTime = 0;

    private int m_sendPk = 0;

    private int id;

    private  List<GameObject> m_cards = new List<GameObject>();

    public  static  Game Instance = null;
    
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


    public void SetBtnsActive(bool isActive)
    {
        btns.SetActive(isActive);
    }
    public void eventClickBlock(EventData data)
    {
        Debug.Log("clickBlock");
    }

    private void Awake()
    {

        //dotwen���
        Instance = this;
        CreatePorker();
        XiPai();
        m_player =  this.gameObject.AddComponent<Player>();

        m_enemy = this.gameObject.AddComponent<Player>();

        m_player.isMy = true;

        EventType eventType = EventType.ClickBlock;
        
        EventManager.addEventListener(eventType, eventClickBlock);
        
        socketBtn.onClick.AddListener(OnClientConnect);
        //Debug.Log("awake");
        ////DOLocalMove



    }

    private void OnClientConnect()
    {
        Debug.Log("OnClientConnect");
         SocketClientSource.GetInstance().StartLocalClient();
        

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



    void XiPai()
    {
        Shuffle(this.m_cards);
    }

    void CreatePorker()
    { 

        for(int i= 0; i < 106; i++)
        {
            //������Դ
            ResourcesLoader.Instance.LoadAsync("Prefeab/Card", (obj) =>
            {
                if (obj != null)
                {
                    GameObject tt = (GameObject)Instantiate(obj, bg.transform);

                    tt.transform.localPosition = Vector3.zero;
                    tt.transform.parent = cards.transform;
                 
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
         
        btns.SetActive(false);
        

    }



    // Update is called once per frame
    void Update()
    {
        
         if(m_cards.Count > 0)
         {
            // Debug.Log("m_cards.Count" + m_cards.Count);
            this.curTime += Time.deltaTime;

            if(this.curTime> Config.FAPAITIME)
            {
                if (m_sendPk < 8)
                {
                    //Debug.Log("m_sendPk" + m_sendPk);
                    //���Լ�����
                    m_cards[m_sendPk].GetComponent<Card>().SetFront();

                    GameObject obj = m_cards[m_sendPk];

                    //m_cards[m_sendPk]?.GetComponent<Card>().type = CardType.front;
                   // m_player.handCard.Add(m_cards[m_sendPk]);
                    obj.GetComponent<Card>().isMine = true;
                    //
                    obj.transform.DOLocalMove(new Vector2(0, -550), 0.1f).OnComplete(() =>{
                        m_cards[m_sendPk].transform.parent = myCard.transform;
                        m_cards.Remove(obj);
                        m_sendPk++;
                        
                        obj = m_cards[m_sendPk];
                        m_cards[m_sendPk].GetComponent<Card>().SetBack();
                        m_cards[m_sendPk].GetComponent<Card>().isMine = false;
                        m_cards[m_sendPk].transform.DOLocalMove(new Vector2(0, 550), 0.1f);
                        m_cards.Remove(obj);
                        m_sendPk++;
                        if (m_sendPk == 8)
                        {
                          // btns.SetActive(true); 
                        }
                    

                    });
                    
                
                }
                else
                {
                     //ʣ�࿨������
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
