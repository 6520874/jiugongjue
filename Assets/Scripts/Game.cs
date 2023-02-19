using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text myHp;

    [SerializeField] private Text enemyHp;

    [SerializeField] private GameObject myHpObj;
    [SerializeField] private GameObject enemyHpObj;

    void Start()
    {
        myHp.text = "0";
        enemyHp.text = "0";
    }

    public void SetMyHp(int hp)
    {
        myHp.text = hp.ToString();
    }


    public void SetEnemyHp(int hp)
    {
        enemyHp.text = hp.ToString();
    }



    // Update is called once per frame
    void Update()
    {

    }
}
