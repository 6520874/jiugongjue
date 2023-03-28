using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

enum CardType
{
    front = 0,
    back = 1,
}
public class Card : MonoBehaviour
{
  
    [SerializeField] Image[] myDi;

    [SerializeField] private Image front;
    [SerializeField] private Image back;

    private float initPosy;

    private bool isChoose = false;


    private  CardType cardType;

 
    public  void setBack()
    {
        this.cardType = CardType.back;
        this.front.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);
       // this.GetComponent<Image>.s
    }

    public void setFront(uint value)
    {
       this.cardType  = CardType.front;
        this.front.gameObject.SetActive(true);
        this.back.gameObject.SetActive(false);
    }
    private void Awake()
    {
        //Debug.Log("Awake");
        // 

        this.initPosy = this.gameObject.transform.position.y;

        this.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClick);

    }

    void OnClick()
    {
        Debug.Log("Button clicked!");
        Vector3 pos = this.gameObject.transform.position;

        //Debug.Log("y"+ pos.y);
       

        if (!isChoose )
        { 
             
            pos.y += 20f;

            isChoose = true;    
        }
        else
        {
            pos.y -= 20f;
            isChoose = false;

        }
        this.gameObject.transform.position = pos;

    }


    void Start()
    {

    }

    // Update is called once per frame
   
}
