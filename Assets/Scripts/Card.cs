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
    // Start is called before the first frame update

    [SerializeField] private Text myHp;

    //[SerializeField] Image myDi;

    [SerializeField] private Image front;
    [SerializeField] private Image back;

    private CardType type; 
 

    public  void setBack()
    {
        this.type = CardType.back;
        this.front.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);
       // this.GetComponent<Image>.s
    }

    public void setFront(uint value)
    {
       this.type  = CardType.front;
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
    void Update()
    {

    }
}
