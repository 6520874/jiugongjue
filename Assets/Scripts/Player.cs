using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // ÷…œµƒ≈∆
    public List<GameObject>  handCard =  new List<GameObject>();

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

    public bool isMy = false;


    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }



    private void Update()
    { 
    
    }
}
