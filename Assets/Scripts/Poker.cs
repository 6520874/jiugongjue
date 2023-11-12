
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum  HuaSe
{
    None = 0,
    SHUI ,
    HUO,
    MU,
    TU,
    JIN
}

public class Poker : MonoBehaviour, IPointerClickHandler
{
    public bool m_isSelect = false;
    public bool m_isDianJi = false;
    public bool m_bEnable = true;
    public GameMain m_gameMain; // Assuming GameMain is a class you have

    // Use this for initialization
    void Start()
    {
        // 初始化代码
    }

    // 实现 IPointerClickHandler 接口以处理点击事件
    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_isDianJi)
        {
            if (!m_isSelect)
            {
                SelectPkLuTou();
            }
            else
            {
                SelectPkSuoTou(true);
            }
        }
    }

    public void ShowFront(string imageName)
    {
        // 在 Unity 中，你可能会更改 Sprite Renderer 或者 Image 组件来显示不同的图像
        var renderer = GetComponent<SpriteRenderer>();
        // 加载并设置 Sprite
        renderer.sprite = Resources.Load<Sprite>(imageName);
    }

    public void ShowLast()
    {
        ShowFront("cardbg"); // 假设 cardbg 是扑克牌背面的资源名称
    }

    public void PkSuoTou()
    {
        // 更新游戏 UI 或者状态
        // 此处需要根据您的 GameMain 类的具体实现来编写代码
        m_isSelect = false;

        // 其他游戏逻辑
    }

    public void SelectPkLuTou()
    {
        // 实现选择逻辑
        m_gameMain.m_btnQipai.gameObject.SetActive(true);
        // 根据您的 GameMain 类具体实现来编写更多的代码
        m_isSelect = true;
        this.transform.position += new Vector3(0, 10, 0); // 提升扑克牌位置
    }

    public void SelectPkSuoTou(bool b)
    {
        // 实现解除选择逻辑
        m_gameMain.m_btnAttack.gameObject.SetActive(false);
        m_isSelect = false;

        if (b)
        {
            this.transform.position -= new Vector3(0, 10, 0); // 降低扑克牌位置
        }
    }
}

