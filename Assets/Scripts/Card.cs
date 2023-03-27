using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text myHp;

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
