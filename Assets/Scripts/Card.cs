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
         

    }


    void Start()
    {

    }

    // Update is called once per frame
   
}
