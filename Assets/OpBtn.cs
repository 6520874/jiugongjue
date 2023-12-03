using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpBtn : MonoBehaviour
{
    [SerializeField] private Sprite img1; //����
    [SerializeField] private Sprite img2; //����
    [SerializeField] private Sprite img3; //����
    [SerializeField] private Sprite img4; //����
    [SerializeField] private Sprite img5; //����
    [SerializeField] private Sprite img6; //��Ѫ
    [SerializeField] private Sprite img7; //����
    [SerializeField] private Sprite img8; //��Ѫ
    // [SerializeField] private Sprite img9;
    
    // Start is called before the first frame update
    void Start()
    {
        //Resources.Load<Sprite>("img1");

        GetComponent<Image>().sprite = img1;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame

    

    private void OnClick()
    {
        
        Debug.Log("Button clicked!");
    }
}
