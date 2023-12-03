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
  
    [SerializeField] private Image[] cards;

    [SerializeField] private Image front;
    [SerializeField] private Image back;
    [HideInInspector]
    public bool isMine = false;
    public int num = 0;

    private bool isChoose = false;


    private  CardType cardType;

 
    public  void SetBack()
    {
        this.cardType = CardType.back;
        this.front.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);

    }

    public void SetFront()
    {
       this.cardType  = CardType.front;
        this.front.gameObject.SetActive(true);
        this.back.gameObject.SetActive(false);
    }

    private void Awake()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClick);
        
        

    }

    void OnClick()
    {
        if (isMine)
        {
          //  Debug.Log("Button clicked!");
            Vector3 pos = this.gameObject.transform.position;
            EventManager.dispatchEvent(EventType.ClickBlock, "���Բ���");
            if (!isChoose)
            {
                
                Game.Instance.SetBtnsActive(true);
                pos.y += 20f;

                isChoose = true;
            }
            else
            {
                Game.Instance.SetBtnsActive(false);
                pos.y -= 20f;
                isChoose = false;

            }
            this.gameObject.transform.position = pos;

        }

    }


    void Start()
    {
        Sprite sp = (Sprite)ResourcesLoader.Instance.LoadTexture("res/" + num);

        if (sp)
        {
            this.front.gameObject.GetComponent<Image>().sprite = sp;
        }

    }



}
