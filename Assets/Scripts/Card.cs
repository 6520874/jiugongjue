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

    private bool isChoose = false;


    private  CardType cardType;

 
    public  void setBack()
    {
        this.cardType = CardType.back;
        this.front.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);

    }

    public void setFront(uint value)
    {
       this.cardType  = CardType.front;
        this.front.gameObject.SetActive(true);
        this.back.gameObject.SetActive(false);
    }

    /*
     
    ResLoad_texture2d(fileName: string) {
        let texture2D = Resources.Load(fileName) as Texture2D;
        if (!texture2D) {
            console.error("Not find texture:" + fileName);
            return;
        }
        return texture2D;
    }

    ResLoad_sprite(fileName: string) {
        let texture2D = this.ResLoad_texture2d(fileName);
        if (!texture2D) {
            return;
        }
        return Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5, 0.5));
    }

     */
    private void Awake()
    {


        Sprite sp =  (Sprite)ResourcesLoader.Instance.LoadTexture("res/2");

        if (sp)
        {
         
            this.front.gameObject.GetComponent<Image>().sprite = sp;
        } 

      

        this.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClick);
        

    }

    void OnClick()
    {
        if (isMine)
        {
            Debug.Log("Button clicked!");
            Vector3 pos = this.gameObject.transform.position;
            EventManager.dispatchEvent(EventType.ClickBlock, "≤‚ ‘≤Œ ˝");
            if (!isChoose)
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

    }


    void Start()
    {

    }

    // Update is called once per frame
   
}
