using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //手上的牌
    public List<GameObject>  handCard =  new List<GameObject>();

    private int hp;

    public bool isMy = false;

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per fra

    private void Update()
    { 
       Debug.Log("update");

        if (handCard.Count > 2 && isMy)
        {
            for(int i=0;i < handCard.Count;i++)
            {
                //排序卡牌位置

                handCard[i].transform.position  =   new Vector2(i*200, handCard[i].transform.position.y);
            }
        }
    }
}
