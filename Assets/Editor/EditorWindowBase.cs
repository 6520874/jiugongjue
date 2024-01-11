using UnityEditor;

public class EditorWindowBase<T> : EditorWindow where T : EditorWindow
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GetWindow<T>();
            }
            return _instance;
        }
    }
    /// <summary>
    /// 窗口优先级
    /// </summary>
    public int Priority { get; set; }
    
}
 