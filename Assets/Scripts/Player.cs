using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // ÷…œµƒ≈∆
    private List<int>  HandCard =  new List<int>();

    private int hp;

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

}
