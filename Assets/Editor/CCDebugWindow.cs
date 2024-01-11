// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using DG.DemiEditor;
// using SimpleJSON_Local;
// using UnityEditor;
// using UnityEditor.EditorTools;
// using UnityEditor.Profiling;
// using UnityEditor.UIElements;
// using UnityEngine;
//
// public class CCDebugItem
// {
//     public MethodInfo meth;
//     public MonoBehaviour target;
//     public CCButtonAttribute btnAttribute;
//     public object[] param;
//     public bool sentWhenChange = false;
//     public Dictionary<string, JSONNode> tempStore = new Dictionary<string, JSONNode>();
// }
//
// public class CCDebugWindow : EditorWindowBase<CCDebugWindow>
// {
//     public Vector2 scrollPosition = Vector2.zero;
//     private static Dictionary<string, Dictionary<string, CCDebugItem>> _dic =
//         new Dictionary<string, Dictionary<string, CCDebugItem>>();
//
//     // 用来显示类名
//     private static Dictionary<string, string> _className = new Dictionary<string, string>();
//
//     //private static Dictionary<string, MonoBehaviour> _targetDic = new Dictionary<string, MonoBehaviour>();
//     private GUIContent firstGUIContent;
//     private int firstSelectIndex;
//     private bool foldout;
//     private Color curColor = Color.white;
//     
//     [MenuItem("Tools/调试界面 _F3",priority = 0)]
//     public static void StartUp()
//     {
//         Instance.Priority = 1;
//         Instance.Show();
//         Instance.minSize = new Vector2(400,400);
//         InitData();
//     }
//
//     static void InitData()
//     {
//         _dic.Clear();
//         _className.Clear();
//         MonoBehaviour[] scripts = GameObject.FindObjectsOfType<MonoBehaviour>();
//         for (int k = 0; k < scripts.Length; k++)
//         {
//             Type type = scripts[k].GetType();
//
//             foreach (Attribute s in type.GetCustomAttributes(true))
//             {
//                 if (!(s is CCEditorBtnAttribute))
//                 {
//                     continue;
//                 }
//                 var typeName = type.Name;
//                 ClassContainKey(ref typeName);
//                 _dic.Add(typeName, new Dictionary<string, CCDebugItem>());
//                 _className.AddDic(typeName,((CCEditorBtnAttribute)s).Name +"_"+typeName);
//                 var btnDic = _dic[typeName];
//                 MethodInfo[] mi = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
//                 int index = 0;
//                 List<CCDebugItem> list = new List<CCDebugItem>();
//                 for (var i = 0;i < mi.Length; ++i)
//                 {
//                     MethodInfo methodInfo = mi[i];
//                     foreach (Attribute a in methodInfo.GetCustomAttributes(true))
//                     {
//                         //Debug.Log(mi[i].Name);
//                         if (a is CCButtonAttribute dbi)
//                         {
//                             var count = methodInfo.GetParameters().Length;
//                             CCDebugItem item = new CCDebugItem()
//                             {
//                                 meth = methodInfo,
//                                 target = scripts[k],
//                                 btnAttribute = dbi,
//                                 param = new object[count]
//                             };
//                             if (count > 0)
//                             {
//                                 // bool allNumber = true;
//                                 var parameters = methodInfo.GetParameters();
//                                 for (int j = 0; j < count; j++)
//                                 {
//                                     // 如果特性写了参数,就把特性参数赋给传出参数
//                                     if (dbi.ObjV != null && dbi.ObjV.Length > j)
//                                     {
//                                         // 如果传进来的参数是jsonNode,看特性传进来的参数类型,转成传出去的参数类型
//                                         if (parameters[j].ParameterType == typeof(JSONNode))
//                                         {
//                                             if (dbi.ObjV[j] is string)
//                                             {
//                                                 item.param[j] = dbi.ObjV[j].ToStr();
//                                             }
//                                             else  if (dbi.ObjV[j] is int)
//                                             {
//                                                 item.param[j] = dbi.ObjV[j].ToInt();
//                                             }
//                                             else  if (dbi.ObjV[j] is float)
//                                             {
//                                                 item.param[j] = dbi.ObjV[j].ToFloat();
//                                             }
//                                             else  if (dbi.ObjV[j] is bool)
//                                             {
//                                                 item.param[j] = dbi.ObjV[j].ToBool();
//                                             }
//                                         }
//                                         else
//                                         {
//                                             // 如果传进来的参数不是jsonNode，直接把特性参数作为传出参数
//                                             item.param[j] = dbi.ObjV[j];
//                                         }
//                                     }
//                                     // // 如果有一个参数不是bool或者数值，那么关闭修改值自动发送事件
//                                     // if (allNumber && parameters[j].ParameterType != typeof(Int32)
//                                     //     && parameters[j].ParameterType != typeof(float)
//                                     //     && parameters[j].ParameterType != typeof(bool))
//                                     // {
//                                     //     allNumber = false;
//                                     // }
//                                 }
//                                 item.sentWhenChange = true; 
//                             }
//                             list.Add(item);
//                             //btnDic.Add(methodInfo.Name, item);
//                             break;
//                         }
//                     }
//                 }
//                 list.Sort((item1, item2) =>
//                 {
//                     if (item1.btnAttribute.Priority > item2.btnAttribute.Priority)
//                     {
//                         return -1;
//                     }
//                     if (item1.btnAttribute.Priority < item2.btnAttribute.Priority)
//                     {
//                         return 1;
//                     }
//                     return 0;
//                 });
//                 for (int i = 0; i < list.Count; i++)
//                 {
//                     btnDic.Add(list[i].meth.Name, list[i]);
//                 }
//                 break;
//             }
//         }
//
//         // 最后选择那个项目
//         string select = EditorDataReader.GetValue("CCDebugSelect", string.Empty);
//         if (!string.IsNullOrEmpty(select))
//         {
//             int index = _dic.Keys.ToList().IndexOf(select);
//             if (index > -1)
//             {
//                 Instance.firstSelectIndex = index;
//             }
//         }
//         
//         // 设置的字体颜色
//         string colorStr = EditorDataReader.GetValue(nameof(CCDebugWindow) +"Color", string.Empty);
//         if (!string.IsNullOrEmpty(colorStr))
//         {
//             Instance.curColor = colorStr.StringToColor();
//         }
//     }
//     
//     internal void OnGUI()
//     {
//         GUILayout.Label("调试工具 F3", getCurStyleByTypeStr("button", 15, Color.cyan)); 
//         GUILayoutOption[] one = new[] { GUILayout.Height(32) };
//         GUILayoutOption[] width = new[] { GUILayout.Width(100) };
//         GUILayout.BeginHorizontal(GUI.skin.box, one);
//         foldout = EditorGUILayout.Foldout(foldout, "配置", getCurStyleByTypeStr("foldout", 15, Color.white)); // 定义折叠菜单
//         if (foldout)
//         {
//             curColor = EditorGUILayout.ColorField(curColor, GUILayout.Width(50));
//             if (GUILayout.Button("保存", getCurStyleByTypeStr("button", 15, Color.white)))
//             {
//                 EditorDataReader.SetValue(nameof(CCDebugWindow) +"Color", curColor.ColorToString());
//             }
//             GUILayout.Space(5);
//             // if (GUILayout.Button("显示属性", getCurStyleByTypeStr("button", 15, Color.white)))
//             // {
//             //     CCPropWindow.StartUp();
//             // }
//         }
//         GUILayout.FlexibleSpace();
//         GUILayout.EndHorizontal();
//         if (_dic == null)
//         {
//             InitData();
//         }
//
//         if (_dic.Keys.Count < 1)
//         {
//             return;
//         }
//
//         GUILayout.BeginHorizontal(GUI.skin.box, one);
//         {
//             if (firstGUIContent == null)
//                 firstGUIContent = new GUIContent("Choose One ! ! ! ! !");
//             var r1 = GUILayoutUtility.GetRect(firstGUIContent, EditorStyles.toolbarDropDown, GUILayout.Width(200));
//             if (firstSelectIndex < 0 ||
//                 (EditorGUI.DropdownButton(r1, firstGUIContent, FocusType.Passive, EditorStyles.toolbarDropDown)))
//             {
//                 var menu = new GenericMenu();
//                 int i = -1;
//                 foreach (var key in _dic.Keys)
//                 {
//                     i++;
//                     menu.AddItem(new GUIContent(_className[key]), i == firstSelectIndex,
//                         (index) => { DropBoxSelect((int)index); }, i);
//                 }
//
//                 if (firstSelectIndex > -1)
//                 {
//                     menu.DropDown(r1);
//                 }
//
//                 if (firstSelectIndex < 0 && menu.GetItemCount() > 0)
//                 {
//                     DropBoxSelect(0);
//                 }
//             }
//         }
//         GUILayout.FlexibleSpace();
//         GUILayout.EndHorizontal();
//
//         Dictionary<string, CCDebugItem> btnDic = null;
//         string nkey = _dic.Keys.ToList()[firstSelectIndex];
//         btnDic = _dic[nkey]; 
//
//         if (string.IsNullOrEmpty(nkey))
//         {
//             return;
//         }
//
//         GUILayout.Label(_className[nkey]);
//         scrollPosition = GUILayout.BeginScrollView(scrollPosition, "box");
//         GUILayout.BeginVertical("helpbox");
//
//         // 一个类里所有含有特性的方法
//         foreach (var key in btnDic.Keys)
//         {
//             GUILayout.BeginHorizontal("helpbox");
//             var item = btnDic[key];
//
//             var name = item.btnAttribute.Name;
//             //item.sentWhenChange = EditorGUILayout.Toggle("", item.sentWhenChange,GUILayout.Width(20));
//             GUILayout.Space(2);
//             string tip = item.btnAttribute.Tip;
//             if (string.IsNullOrEmpty(name))
//             {
//                 name = item.meth.Name;
//             }
//             var content = new GUIContent(name, tip);
//             bool click = GUILayout.Button(content, getCurStyleByTypeStr("button", 15, curColor), GUILayout.Width(100));
//             GUILayout.Space(2);
//             // GUILayout.Label(name, getCurStyleByTypeStr("label", 20, Color.yellow), width);
//             int numberCount = 0;
//             // 根据方法绘制界面
//             List<Type> enumlist = new List<Type>();
//             for (int i = 0; i < item.param.Length; i++)
//             {
//                 // 获取传出参数类型
//                 var types = item.meth.GetParameters()[i].ParameterType;
//                 if (types.IsEnum)
//                 {
//                     enumlist.Add(types);
//                 }
//                 if (types == typeof(JSONNode))
//                 {
//                     //如果是jsonNode，并且有传出参数(初始化时特性赋予的),那么类型就是传出参数的类型
//                     if (item.param.Length > i && item.param[i] != null)
//                     {
//                         types = item.param[i].GetType();
//                     }
//                 }
//                 if (types == typeof(bool))
//                 {
//                     var vbool = EditorGUILayout.Toggle("", item.param[i].ToBool(), GUILayout.Width(40));
//                     bool sameValue = vbool == item.param[i].ToBool();
//                     item.param[i] = vbool;
//                     if (item.sentWhenChange && !sameValue)
//                     {
//                         var newParams = GetParams(item);
//                         item.meth.Invoke(item.target, newParams);
//                     }
//                 }
//                 else if (types == typeof(Int32))
//                 {
//                     float max = 100f;
//                     float min = 0.0f;
//                     if (item.btnAttribute is CCFloatAttribute attribute)
//                     {
//                         min = attribute.Ranges[numberCount * 2];
//                         max = attribute.Ranges[numberCount * 2 + 1];
//                     }
//                     var vint = 0;
//                     if (min == 0 && max == 1)
//                     {
//                         // 如果是int值并且是0和1那么就是单选框
//                         bool select = EditorGUILayout.Toggle("", item.param[i].ToInt() == 1, GUILayout.Width(40));
//                         vint = select.ToInt();
//                     }
//                     else
//                     {
//                         // 滑动框
//                         vint = GUILayout.HorizontalSlider(item.param[i].ToInt(), min, max , GUILayout.Width(70)).ToInt();
//                     }
//                     bool sameValue = vint == item.param[i].ToInt();
//                     item.param[i] = vint;
//                     if (item.sentWhenChange && !sameValue)
//                     {
//                         var newParams = GetParams(item);
//                         item.meth.Invoke(item.target, newParams);
//                     }
//                     GUILayout.Label($"{item.param[i].ToFloat():F}",  getCurStyleByTypeStr("label", 15, Color.white), GUILayout.Width(50));
//                     numberCount++;
//                 }
//                 else if (types.IsEnum)
//                 {
//                     int max = 100;
//                     int min = 0;
//                     if (types.IsEnum)
//                     {
//                         max = Enum.GetValues(types).Cast<int>().Max();
//                     }
//                     if (item.btnAttribute is CCFloatAttribute attribute)
//                     {
//                         min = attribute.Ranges[numberCount * 2].ToInt();
//                         max = attribute.Ranges[numberCount * 2 + 1].ToInt();
//                     }
//                     var vint = 0;
//                     if (item.tempStore.TryGetValue("DropIndex", out var get))
//                     {
//                         vint = get.AsInt;
//                     }
//                     string tname = Enum.GetName(types ,vint);
//                     GUIContent gui = new GUIContent(tname);
//                     var r1 = GUILayoutUtility.GetRect(gui, EditorStyles.toolbarDropDown, GUILayout.Width(200));
//                 
//                     if (EditorGUI.DropdownButton(r1, gui, FocusType.Passive,
//                             getCurStyleByTypeStr("DropdownButton", 15, Color.white)))
//                     {
//                         var menu = new GenericMenu();
//                         int ii = -1;
//                         var hehe = i;
//                         foreach (var kk in Enum.GetNames(types))
//                         {
//                             ii++;
//                             menu.AddItem(new GUIContent(kk), ii == vint,
//                                 (index) =>
//                                 {
//                                     bool sameValue =  vint == (int)index;
//                                     vint = (int)index; 
//                                     item.tempStore.AddDic("DropIndex", vint);
//                                     //bool sameValue = vint == item.param[hehe].ToInt();
//                                     item.param[hehe] = vint;
//                                     if (item.sentWhenChange && !sameValue)
//                                     {
//                                         var newParams = GetParams(item);
//                                         item.meth.Invoke(item.target, newParams);
//                                     }
//                                 }, ii);
//                         }
//                         if (vint > -1)
//                         {
//                             menu.DropDown(r1);
//                         }
//                     }
//                 }
//                 else if (types == typeof(float))
//                 {
//                     float max = 100f;
//                     float min = 0.0f;
//                     if (item.btnAttribute is CCFloatAttribute attribute)
//                     {
//                         min = attribute.Ranges[numberCount * 2];
//                         max = attribute.Ranges[numberCount * 2 + 1];
//                     }
//                     var vfloat = GUILayout.HorizontalSlider(item.param[i].ToFloat(), min, max , GUILayout.Width(70));
//                     bool sameValue = vfloat == item.param[i].ToFloat();
//                     item.param[i] = vfloat;
//                     if (item.sentWhenChange && !sameValue)
//                     {
//                         var newParams = GetParams(item);
//                         item.meth.Invoke(item.target, newParams);
//                     }
//                     GUILayout.Label($"{item.param[i].ToFloat():F}",  getCurStyleByTypeStr("label", 15, Color.white), GUILayout.Width(50));
//                     numberCount++;
//                 }
//                 else if (types == typeof(string))
//                 {
//                     if (item.btnAttribute is CCBoolAttribute attribute)
//                     {
//                         bool select = EditorGUILayout.Toggle("", item.param[i].ToBool(), GUILayout.Width(40));
//                         bool sameValue = select == item.param[i].ToBool();
//                         item.param[i] = select.ToStr();
//                         if (item.sentWhenChange && !sameValue)
//                         {
//                             var newParams = GetParams(item);
//                             item.meth.Invoke(item.target, newParams);
//                         }
//                     }
//                     else
//                     {
//                         var vstr = GUILayout.TextArea(item.param[i].ToStr(),  getCurStyleByTypeStr("textarea", 15, curColor),  GUILayout.Width(120));
//                         bool sameValue = vstr == item.param[i].ToString();
//                         item.param[i] = vstr;
//                         if (item.sentWhenChange && !sameValue)
//                         {
//                             var newParams = GetParams(item);
//                             item.meth.Invoke(item.target, newParams);
//                         }
//                     }                
//                 }
//                 GUILayout.Space(2);
//             }
//             GUILayout.FlexibleSpace();
//             //bool click = GUILayout.Button("V", getCurStyleByTypeStr("button", 20, Color.yellow), GUILayout.Width(30));
//             if (click)
//             {
//                 var newParams = GetParams(item);
//                 item.meth.Invoke(item.target, newParams);
//             }
//             if (!string.IsNullOrEmpty(item.btnAttribute.Tip))
//             {
//                 bool show = false;
//                 if (item.tempStore.TryGetValue("Tip", out var get))
//                 {
//                     show = get.AsBool;
//                 }
//                 show = EditorGUILayout.Foldout(show, "提示", getCurStyleByTypeStr("foldout", 15, Color.white)); // 定义折叠菜单
//                 if (show)
//                 {
//                     GUILayout.Label(item.btnAttribute.Tip,  getCurStyleByTypeStr("label", 15, Color.white));
//                 }
//                 item.tempStore.AddDic("Tip", show);
//             }
//             GUILayout.EndHorizontal();
//             // if (enumlist.Count > 0)
//             // {
//             //     GUILayout.BeginVertical();
//             //     for (int i = 0; i < enumlist.Count; i++)
//             //     {
//             //         bool show = false;
//             //         if (item.tempStore.TryGetValue("Enumlist", out var get))
//             //         {
//             //             show = get.AsBool;
//             //         }
//             //         show = EditorGUILayout.Foldout(show, "枚举", getCurStyleByTypeStr("foldout", 15, Color.white)); // 定义折叠菜单
//             //         if (show)
//             //         {
//             //             //枚举类型
//             //             var tt = enumlist[i];
//             //             foreach (var temp in Enum.GetValues(tt))
//             //             {
//             //                // keyList.Add(temp);
//             //                GUILayout.Label((int)temp + ":" + temp, getCurStyleByTypeStr("label", 15, Color.white));
//             //             }
//             //         }
//             //         item.tempStore.AddDic("Enumlist", show); 
//             //     }
//             //     GUILayout.EndHorizontal();
//             // }
//             GUILayout.Space(item.btnAttribute.Space);
//         }
//         GUILayout.FlexibleSpace();
//         GUILayout.EndVertical();
//         GUILayout.EndScrollView();
//     }
//
//     // 获取参数
//     object[] GetParams(CCDebugItem item)
//     {
//         var newParams = new object[item.param.Length];
//         for (var i = 0; i < newParams.Length; i++)
//         {
//             newParams[i] = item.param[i];
//         }
//         var methParams = item.meth.GetParameters();
//         for (var i = 0; i < methParams.Length; i++)
//         {
//             if (newParams.Length < i)
//             {
//                 break;
//             }
//             if (methParams[i].ParameterType != typeof(JSONNode))
//             {
//                 continue;
//             }
//             if (newParams[i].GetType() == typeof(string))
//             {
//                 newParams[i] = new JSONString(newParams[i].ToString());
//             }
//             if (newParams[i].GetType() == typeof(Int32) || newParams[i].GetType() == typeof(float))
//             {
//                 newParams[i] = new JSONNumber(newParams[i].ToFloat());
//             }  
//             if (newParams[i].GetType() == typeof(bool))
//             {
//                 newParams[i] = new JSONBool(newParams[i].ToBool());
//             }
//         }
//         return newParams;
//     }
//
//     private float hSliderValue;
//     
//
//     private void DropBoxSelect(int index)
//     {
//         firstSelectIndex = index;
//         var key = _dic.Keys.ToList()[firstSelectIndex];
//         if (!string.IsNullOrEmpty(key))
//         {
//             EditorDataReader.SetValue("CCDebugSelect", key);
//         }
//     }
//     
//     public GUIStyle getCurStyleByTypeStr(string type,int size = 20, Color? color = null , TextAnchor style = TextAnchor.MiddleLeft)
//     {
//         var centeredStyle = new GUIStyle(type);
//         centeredStyle.fontSize = size;       //字体大小   
//         color = color ?? curColor;
//         centeredStyle.normal.textColor = color.Value;
//         centeredStyle.alignment = style;
//         return centeredStyle;
//     }
//
//     static void ClassContainKey(ref string className)
//     {
//         if (_dic.ContainsKey(className))
//         {
//             className += "_2";
//             ClassContainKey(ref className);
//         }
//     }
// }
//
//   
//  