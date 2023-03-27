using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text myHp;

    //[SerializeField] Image myDi;

    [SerializeField] private Image front;
    [SerializeField] private Image back;

    uint type = 0; //0 ÅÆÃæ  1ÅÆµ×


    private int hp;
    // private ArrayList<Card> m_cards = new ArrayList<Card>();

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

    public  void setBack()
    { 
        this.front.gameObject.SetActive(false);
        this.back.gameObject.SetActive(true);
       // this.GetComponent<Image>.s
    }

    public void setFront(uint value)
    {
        this.front.gameObject.SetActive(true);
        this.back.gameObject.SetActive(false);
    }
    private void Awake()
    {
        this.Hp = 0;
        Debug.Log("Hp = " + Hp);

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
