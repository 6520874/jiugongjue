using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    //���ϵ���
    public List<GameObject>  handCard =  new List<GameObject>();

    private int hp;

    public bool isMy = false;

    
    public bool m_isOutPk = false;
    public List<Poker> m_arrPk;
    public int m_jiaoIndex = 1;

    // Assuming Poker is another class you have defined
    public GameObject m_parent;
    public Button m_role; // Assuming you have a Button component
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
        m_arrPk = new List<Poker>();
        //int screenWidth = Screen.width;
        //int screenHeight = Screen.height;
        //Debug.Log("Screen size: " + screenWidth + " x " + screenHeight);
    }



    public HuaSe GetRolePlaceHuase(int index)
    {
        // Enum or constant values for HuaSe need to be defined
        if (index == 1 || index == 8) return HuaSe.SHUI;
        else if (index == 2 || index == 9) return  HuaSe.HUO;
        else if (index == 3 || index == 4) return HuaSe.MU;
        else if (index == 5) return HuaSe.TU;
        else if (index == 6 || index == 7) return HuaSe.JIN;
        else return HuaSe.None;
    }
    
    
    public void SetRolePlace(int index)
    {
        Vector2 size = m_parent.GetComponent<RectTransform>().sizeDelta;

        m_jiaoIndex = index;
        Vector2 t = Vector2.zero;

        switch (index)
        {
            case 1: t = new Vector2(size.x * 0.5f, size.y / 6); break;
            // ... Other cases
        }

        StartCoroutine(MoveToPosition(m_role.transform, t, 0.5f));
        m_role.gameObject.SetActive(false);
    }

    private IEnumerator MoveToPosition(Transform transform, Vector2 position, float timeToMove)
    {
        Vector2 start = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector2.Lerp(start, position, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = position;
    }

    public void Yiwei()
    {
        // Implement the logic
    }

    public void YiweiEvent()
    {
        // Implement the logic for the event
    }

    public void InitPlayerPlace(GameObject parent, int random2)
    {
       // m_role = Instantiate(/* Prefab or asset here */, parent.transform);
        // Setup player
    }

    public void UpdatePkWeiZhi()
    {
        // Vector2 size = new Vector2(Screen.width, Screen.height);
        //
        // if (m_iPlayerClass == 1) return;
        //
        // // 对 m_arrPk 进行排序
        // m_arrPk = m_arrPk.OrderBy(pk => pk.getHuaSe()).ThenBy(pk => pk.getNum()).ToList();
        //
        // float x = size.x / 2 - ((m_arrPk.Count - 1) * pkJianJu + pkWidth) / 2;
        // float y = m_point.y;
        //
        // // 更新位置
        // for (int i = 0; i < m_arrPk.Count; i++)
        // {
        //     Poker pk = m_arrPk[i];
        //     pk.gameObject.SetActive(true);
        //     pk.gameObject.transform.position = new Vector3(x + i * pkJianJu + pkWidth / 2, y, 0);
        // }
    }
    
    private void Update()
    { 
    
        if (handCard.Count > 0 && isMy)
        {

            for(int i=0;i < handCard.Count;i++)
            {   
                //������λ��
                 
                if(i == 2)
                {

                }
                else if(i == 3)
                {

                }   
                else if(i==4) { 

                }
                    
                 float width = handCard[i].GetComponentInChildren<Image>().rectTransform.rect.width;
                    
                //Debug.Log("Width"+width);
                Vector3 pos = handCard[i].transform.position; 
                handCard[i].transform.position  =  new Vector2(780+i*width*0.8f , pos.y);
            }
        }   
    }
}


