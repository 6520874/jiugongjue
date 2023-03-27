using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    //  [SerializeField] private Text myHp;

    //  [SerializeField] private Text enemyHp;

    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;

    private Player m_player = new Player();
    private Player m_enemy = new Player();



    private int id;

    //  private readonly ArrayList<Card> m_cards;

    private readonly List<int> m_cards = new List<int>();

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




    // public T GetT<T> where T : class
    // {
    //     return t;
    // }


    private void Awake()
    {

        //   this.Id = 14;
        //   Debug.Log("Id = " + Id);

        //   Id = 13;
        //   Debug.Log("Id = " + Id);


        //   id = 12;

        //   for (int i = 0; i < 106; i++)
        //   {
        //       m_cards.Add(i);
        //   }


        Vector3 pos = new Vector3(1, 1, 1);
        Vector3 pos2 = new Vector3(2, 2, 2);

        float a = Vector3.Dot(pos, pos2);

        Debug.Log("a = " + a);



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

    }
}
