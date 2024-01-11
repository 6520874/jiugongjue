// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System.IO;
// using System;
// using UnityEngine.UI;
//
// public class BuildNOMIthings
// {
//     //[MenuItem("NIOTools/CheckPath")]
//     //public static void CheckPath()
//     //{
//     //    Debug.Log(sourcePath);
//
//     //    Debug.Log(fullSavePath);
//     //}
//     [MenuItem("NIOTools/BuildNOMIPanel_Instance")]
//     public static void BuildNOMI_PanelAndInstance()
//     {
//         foreach (var item in Enum.GetValues(typeof(NOMI_GlobalData.PanelLevel)))
//         {
//             BuildOnePanel(NOMI_GlobalData.ToEnum<NOMI_GlobalData.PanelLevel>(item.ToString()));
//         }
//         InstantiatePrefabToScene();
//     }
//     [MenuItem("NIOTools/Step/BuildNOMIPanel")]
//     public static void BuildNOMI_Panel()
//     {
//         foreach (var item in Enum.GetValues(typeof(NOMI_GlobalData.PanelLevel)))
//         {
//             BuildOnePanel(NOMI_GlobalData.ToEnum<NOMI_GlobalData.PanelLevel>(item.ToString()));
//         }
//     }
//
//     #region paths
//
//     static string basePath = Path.Combine(@"Assets", "dev", "_dev");
//
//     static string prefabName = "NOMI_basePanel.prefab";
//
//     static string basePanelPrefabPath = Path.Combine(@"Prefab", prefabName);
//
//     static string savePath = @"ResourcesPrefab" + Path.DirectorySeparatorChar;
//
//     static string sourcePath = Path.Combine(basePath, basePanelPrefabPath);
//
//     static string fullSavePath = Path.Combine(basePath, savePath);
//
//     #endregion
//
//     public static void BuildOnePanel(NOMI_GlobalData.PanelLevel panelLevel)
//     {
//
//         var this_prefab = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(sourcePath)) as GameObject;
//
//         this_prefab.name = "NOMI_" + "PANEL_" + panelLevel.ToString().ToUpper();
//
//         if (!Directory.Exists(fullSavePath))
//         {
//             Debug.Log("��ǰ·��������,���� : " + fullSavePath);
//             Directory.CreateDirectory(fullSavePath);
//         }
//
//         string prefabFile = this_prefab.name + ".prefab";
//
//         PrefabUtility.SaveAsPrefabAssetAndConnect(this_prefab, fullSavePath + prefabFile, InteractionMode.AutomatedAction);
//
//         UnityEngine.Object.DestroyImmediate(this_prefab);
//
//         AssetDatabase.Refresh();
//
//     }
//     [MenuItem("NIOTools/Step/InstantiatePrefab")]
//     public static void InstantiatePrefab()
//     {
//         InstantiatePrefabToScene();
//     }
//     public static void InstantiatePrefabToScene()
//     {
//         string rootName = "Root_Canvas";
//
//         Transform rootTrans = GameObject.Find(rootName).transform.Find("NOMI_PANEL_SPLIT");
//
//         NOMI_LevelItemController n = GameObject.FindObjectOfType<NOMI_LevelItemController>();
//
//         n.readyToRmByLevel.Clear();
//
//         n.InitReadyToRmByLevel();
//
//         #region ����
//
//         var t = GameObject.FindObjectOfType<NOMI_MenuController>();
//
//         t.nomi_PanelRuntimes.Clear();
//
//         #endregion
//
//         int count = rootTrans.childCount;
//         for (int i = count - 1; i > -1; --i)
//         {
//             GameObject.DestroyImmediate(rootTrans.GetChild(i).gameObject);
//         }
//
//         foreach (var item in Enum.GetValues(typeof(NOMI_GlobalData.PanelLevel)))
//         {
//
//             //ToEnum<NOMI_GlobalData.PanelLevel>(item.ToString())
//
//             string tempName = "NOMI_" + "PANEL_" + item.ToString().ToUpper() + ".prefab";
//
//             Debug.Log(fullSavePath + tempName);
//
//             var this_prefab = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(fullSavePath + tempName)) as GameObject;
//
//             this_prefab.transform.SetParent(rootTrans);
//
//             this_prefab.transform.localPosition = Vector3.zero;
//
//             NOMI_PanelRuntime nomi_PanelProp = null;//= this_prefab.AddComponent<NOMI_PanelRuntime>();
//
//             switch (item)
//             {
//                 case NOMI_GlobalData.PanelLevel.Skins:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_BackgroundRuntime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Environments:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_EnvironmentsRuntime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Extension_1:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_Extension1Runtime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Gesture:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_GensturesRuntime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Background:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_Extension2Runtime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Eyes:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_FaceExpressionRuntime>();
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Accessories:
//                     nomi_PanelProp = this_prefab.AddComponent<NOMI_AccessoriesRuntime>();
//                     break;
//                 default:
//                     break;
//             }
//
//             var enumTemp = NOMI_GlobalData.ToEnum<NOMI_GlobalData.PanelLevel>(item.ToString());
//
//             //nomi_PanelProp.nomi_PanelProp.nomi_GlobalData = enumTemp;
//
//             //nomi_PanelProp.nomi_PanelProp.panelName = item.ToString().ToUpper();
//
//             string panelName = item.ToString().ToUpper();
//
//             int panelRenderIndex = ((int)enumTemp);
//
//             NOMI_GlobalData.PanelStatus panelStatus = NOMI_GlobalData.PanelStatus.open;
//
//             GameObject panelObj = this_prefab;
//
//             Image panelImg = this_prefab.transform.Find("SequenceFrame").GetComponent<Image>();
//
//             Text panelLabel = this_prefab.transform.Find("TestLable").GetComponent<Text>();
//
//             panelLabel.text = panelName;
//
//             CanvasGroup panelCanvasGroup = this_prefab.GetComponent<CanvasGroup>();
//
//             NOMI_GlobalData.PanelLevel nomi_GlobalData = enumTemp;
//
//             nomi_PanelProp.nomi_PanelProp = new NOMI_PanelProp(panelName, panelRenderIndex, panelStatus, panelObj, panelImg, panelLabel, panelCanvasGroup, nomi_GlobalData);
//
//             var sceneAnim = GameObject.FindObjectOfType<NOMI_AnimatorController>();
//
//             //GameObject tempg = new GameObject();
//
//             //sceneAnim.CurrentActiveObjsByLevel.Clear();
//
//             //sceneAnim.CurrentActiveObjsByLevel.Add((NOMI_GlobalData.PanelLevel)item, tempg);
//
//             //DestroyImmediate(tempg);
//
//             switch (item)
//             {
//                 case NOMI_GlobalData.PanelLevel.Skins:
//
//                     sceneAnim.backgroundRuntime = this_prefab.GetComponent<NOMI_BackgroundRuntime>();
//
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Environments:
//
//                     sceneAnim.environmentsRuntime = this_prefab.GetComponent<NOMI_EnvironmentsRuntime>();
//                 
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Eyes:
//                     
//                     InitFaceExpression(this_prefab);
//
//                     sceneAnim.faceExpressionRuntime =  this_prefab.GetComponent<NOMI_FaceExpressionRuntime>();
//
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Extension_1:
//
//                     sceneAnim.extension1Runtime = this_prefab.GetComponent<NOMI_Extension1Runtime>();
//                 
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Gesture:
//
//                     sceneAnim.gensturesRuntime = this_prefab.GetComponent<NOMI_GensturesRuntime>();
//
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Accessories:
//                     InitAccessories(this_prefab);
//
//                     sceneAnim.accessoriesRuntime = this_prefab.GetComponent<NOMI_AccessoriesRuntime>();
//
//                     break;
//                 case NOMI_GlobalData.PanelLevel.Background:
//
//                     sceneAnim.extension2Runtime = this_prefab.GetComponent<NOMI_Extension2Runtime>();
//
//                     break;
//                 default:
//                     break;
//             }
//
//             #region ����
//
//             t.nomi_PanelRuntimes.Add((NOMI_GlobalData.PanelLevel)item,nomi_PanelProp);
//
//             #endregion
//
//
//         }
//
//         var frameAnimationController = NHelper.GetOrAddComponent<NOMI_FrameAnimationController>(rootTrans);
//         frameAnimationController.EditorInit();
//     }
//     [MenuItem("NIOTools/RM_ALL!!")]
//     public static void RemoveAll()
//     {
//         var t = GameObject.FindObjectOfType<NOMI_MenuController>();
//
//         if (t.nomi_PanelRuntimes.Count > 0)
//         {
//             foreach (var item in t.nomi_PanelRuntimes.Values)
//             {
//                 UnityEngine.Object.DestroyImmediate(item.gameObject);
//             }
//
//         }
//     }
//
//     static string prefabBasePath = @"Assets\ArtAssets\A_NOMI\Nomi_UI_Resources\";
//
//     static string prefabFaceExpressionPath = @"Nomi_Lyr_3_Eyes\NEyes_Prefabs\NPrefab_Comp_Root.prefab";
//     /// <summary>
//     /// eye
//     /// </summary>
//     /// <param name="parent"></param>
//     public static void InitFaceExpression(GameObject parent)
//     {
//
//         GameObject g = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(prefabBasePath + prefabFaceExpressionPath)) as GameObject;
//
//         g.transform.SetParent(parent.transform);
//
//         var face = parent.GetComponent<NOMI_FaceExpressionRuntime>();
//
//         face.NPrefab_Postion_Root = TransformTool.FindChild(g.transform, "NPrefab_Postion_Root").GetComponent<Animator>(); 
//
//         face.NPrefab_Animation_Root = TransformTool.FindChild(g.transform, "UI_NOMI_Root").GetComponent<Animator>();
//
//     }
//     static string prefabGudgePath = "Nomi_Lyr_4_Gudget/";
//     public static void InitAccessories(GameObject parent)
//     {
//         var l= TransformTool.Readlist(prefabBasePath + prefabGudgePath, "prefab");
//
//         foreach (var item in l)
//         {
//             Debug.Log(item + "-------");
//
//             int sIndex = item.IndexOf("Assets");
//
//             var sp = item.Substring(sIndex, item.Length - sIndex);
//
//             GameObject g = AssetDatabase.LoadAssetAtPath<GameObject>(sp);
//
//             NOMI_AccessoriesProp p = null;
//
//             var tempP = g.GetComponent<NOMI_AccessoriesProp>();
//             if (tempP == null)
//                 p = g.AddComponent<NOMI_AccessoriesProp>();
//             else p = tempP;
//
//             foreach (var ani in p.GetComponentsInChildren<Animator>())
//             {
//                 p.thisAnim=ani;
//             }
//
//             var gudget = parent.GetComponent<NOMI_AccessoriesRuntime>();
//
//             var strs = g.name.Split('_');
//
//             string strName = "0";
//
//             if (strs.Length>1) 
//             {
//                 strName = strs[1];
//             }
//
//             gudget.NPrefab_Gudget_Roots.Add(strName, g);
//
//             Debug.Log(sp + "-------");
//         }
//
//         Debug.Log(l.Count + "-------");
//     }
//     [MenuItem("NIOTools/Value2AnimDIC!!")]
//     public static void Value2AnimDIC()
//     {
//         var g = GameObject.FindObjectOfType<NOMI_AnimatorController>();
//
//         g.Value2StrDIC();
//     }
//
//
//     static string itemsprefabBasePath = @"Assets/ArtAssets/A_NOMI/Nomi_UI_Resources/";
//
//     static string dirStartStr = "Nomi_Lyr_";
//
//     [MenuItem("NIOTools/SerializableItemsExceptEye")]
//     public static void SerializableItemsExceptEye() 
//     {
//         var ds = Directory.GetDirectories(itemsprefabBasePath);
//
//         int _i = 0;
//
//         foreach (var item in ds)
//         {
//             _i++;
//
//             var tempI = item.IndexOf(dirStartStr);
//
//             Debug.Log(_i);
//
//             if(tempI<0) continue;
//
//             string tempStr = item.Substring(tempI, item.Length - tempI);
//
//             string path =  itemsprefabBasePath + tempStr + @"/";
//
//             Debug.Log(path);
//
//             foreach (var p in TransformTool.Readlist(path, "prefab"))
//             {
//                 //Debug.Log(Path.Combine(itemsprefabBasePath, dirStartStr));
//
//                 int sIndex = p.IndexOf("Assets");
//
//                 var sp = p.Substring(sIndex, p.Length - sIndex);
//
//                 GameObject g = AssetDatabase.LoadAssetAtPath<GameObject>(sp);
//
//                 Debug.Log(g.name + "added");
//
//                 if (g.name.Contains("NBkg")) 
//                 {
//                     AddComponentProp(g, new NOMI_BackgroundProp());
//                 }
//                 else if (g.name.Contains("NAcr"))
//                 {
//                     AddComponentProp(g, new NOMI_AccessoriesProp());
//                 }
//                 else if (g.name.Contains("NEnv"))
//                 {
//                     AddComponentProp(g, new NOMI_EnvironmentsProp());
//                 }
//                 else if (g.name.Contains("NEx1"))
//                 {
//                     AddComponentProp(g, new NOMI_Extension1Prop());
//                 }
//                 else if (g.name.Contains("NSkn"))
//                 {
//                     AddComponentProp(g, new NOMI_SkinsProp());
//                 }
//                 else if (g.name.Contains("NGes"))
//                 {
//                     AddComponentProp(g, new NOMI_GesturesProp());
//                 }
//             }
//         }
//         void AddComponentProp<T>(GameObject g, T animatorBaseProp) where T : NOMI_AnimatorBaseProp
//         {
//             T t = null;
//
//             if (g.GetComponent<T>() == null)
//                 t = g.AddComponent<T>();
//             else t = g.GetComponent<T>();
//
//             foreach (var item in g.GetComponentsInChildren<Animator>())
//             {
//                 t.thisAnim = item;
//             }
//             
//         
//         }
//
//     }
// }
