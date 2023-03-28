using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        //int screenWidth = Screen.width;
        //int screenHeight = Screen.height;
        //Debug.Log("Screen size: " + screenWidth + " x " + screenHeight);
    }



    private void Update()
    { 
    
        if (handCard.Count > 0 && isMy)
        {

            for(int i=0;i < handCard.Count;i++)
            {   
                //排序卡牌位置
                 
                if(i == 2)
                {

                }
                else if(i == 3)
                {

                }   
                else if(i==4) { 

                }
                    
                 float width = handCard[i].GetComponentInChildren<Image>().rectTransform.rect.width;
                    
                Debug.Log("Width"+width);
                Vector3 pos = handCard[i].transform.position; 
                handCard[i].transform.position  =  new Vector2(800+i*width*2/3 , pos.y);
            }
        }   
    }
}
