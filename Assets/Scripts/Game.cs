using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;
    [SerializeField] private GameObject bg;

    private Player m_player = new Player();
    private Player m_enemy = new Player();
    

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
         
        
        //   myHp.text = "0";
        //   enemyHp.text = "0";



    }

    //  public void SetMyHp(int hp)
    //  {
    //      myHp.text = hp.ToString();
    //  }


    //  public void SetEnemyHp(int hp)
    //  {
    //      enemyHp.text = hp.ToString();
    //  }



    // Update is called once per frame
    void Update()
    {

         if(m_cards.Count > 0)
        {
            m_cards[0].transform.DOLocalMove(new Vector2(0, -500), 1);
             
        }
    }
}
