// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using System.Text;
// using UnityEditor;
// using UnityEngine;
// using Object = UnityEngine.Object;
//
// public class BuildEditor : UnityEditor.Editor
// {
//     public static void WritePure(string strFilePath, string content)
//     { 
//         BinaryWriter bw = null;
//         FileStream fs = new FileStream(strFilePath, FileMode.Create);
//         try
//         {
//             bw = new BinaryWriter(fs);
//         }
//         catch (IOException e)
//         {
//             Debug.Log(e.Message);
//         }
//         try
//         {
//             byte[] inputByteArray = Encoding.UTF8.GetBytes(content);
//             bw.Write(inputByteArray);
//             bw.Flush();
//             bw.Close();
//         }
//         catch (IOException e)
//         {
//             Debug.Log(e.Message);
//         }
//     }
//
//     
//     [MenuItem("GameObject/获取节点路径", false, 0)]
//     public static void GetParentPath()
//     {
//         if (!(Selection.activeObject is GameObject))
//         {
//             return;
//         }
//         Transform trans = (Selection.activeObject as GameObject).transform;
//         string path = trans.name;
//         GetParent(trans, ref path);
//         Debug.Log(path);
//     }
//     
//     private static void GetParent(Transform trans, ref string path)
//     {
//         if (trans.parent != null)
//         {
//             path = trans.parent.name + "/" + path;
//             GetParent(trans.parent, ref path);
//         }
//     }
//     
//     [MenuItem("Assets/获取物体路径", false)]
//     public static void GetSelectObject()
//     {
//         string path = AssetDatabase.GetAssetPath(Selection.activeObject);
//         Debug.Log(path);
//         var array = path.Split(Path.AltDirectorySeparatorChar);
//         string cmd = "Path.Combine(";
//         for (int i = 0; i < array.Length; i++)
//         {
//             cmd += "\"" + array[i] + "\"";
//             if (i < array.Length - 1)
//             {
//                 cmd += ",";
//             }
//         }
//         cmd += ")";
//         Debug.Log(cmd);
//     }
//     
//     [MenuItem("Assets/检查引用", false)]
//     public static void CheckReference()
//     {
//         string path = AssetDatabase.GetAssetPath(Selection.activeObject);
//         FindDependence(path);
//         Debug.Log("检查完毕!");
//     }
//     
//     [MenuItem("NIOTools/Refresh _F5")]
//     public static void Refresh()
//     {
//         FindObjectsOfTypeAll<MonoBehaviour, CCEditorClass>();
//         Debug.Log("刷新完毕");
//     }
//     
//     public static void FindDependence(string path)
//     {
//         if (!File.Exists(path))
//         {
//             Debug.Log(path + "\r\n"  + File.Exists(path));
//         }
//         var guids = GetGUIDList(path);
//         for (int i = 0; i < guids.Count; i++)
//         { 
//             string file = AssetDatabase.GUIDToAssetPath(guids[i]);
//             bool exist = File.Exists(file);
//             if (!exist)
//             {
//                 if (file.EndsWith(".png") || file.EndsWith(".mat") || file.EndsWith(".jpg")|| file.EndsWith(".fbx"))
//                 {
//                     Debug.Log("文件：" + path + "\r\n" + " 引用GUID: "+guids[i] +" 没有找到! " + file);
//                 }
//             }
//             else
//             {
//                 if (file.EndsWith(".mat"))
//                 {
//                     FindDependence(file);
//                 }
//             }
//         }
//     }
//     
//     public static List<string> GetGUIDList(string path)
//     {
//         List<string> guids = new List<string>();
//         string str = string.Empty;
//         BuildEditor.ReadFileAction(path, s =>
//         {
//             int index = s.IndexOf("guid:");
//             if (index > -1)
//             {
//                 var id = s.Substring(index + 6, 32);
//                 if (!guids.Contains(id))
//                 {
//                     guids.Add(id);
//                     str += id + "\r\n";
//                 }
//             }
//             return string.Empty;
//         });
//         return guids;
//     }
//     
//     // 读取文本
//     public static string ReadFileAction(string path, Func<string, string> callback)
//     { 
//         string allLine = string.Empty;
//         using (StreamReader reader = new StreamReader(path))
//         {
//             string line;
//             // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
//             while((line = reader.ReadLine()) != null)
//             {
//                 allLine +=callback(line);
//             }
//         }
//         return allLine;
//     }
//     
//     public static List<T> FindObjectsOfTypeAll<T,V>() where V:Attribute{
//         List<T> results = new List<T>();
//         foreach (GameObject go in Object.FindObjectsOfType<GameObject>())
//         {
//             var list = go.GetComponentsInChildren<T>(true);
//             for (int i = 0; i < list.Length; i++)
//             {
//                 if (list[i] == null)
//                 {
//                     continue;
//                 }
//                 var type = list[i].GetType(); // 获取类型对象
//                 var myAttribute = type.GetCustomAttributes<V>();
//                 if (myAttribute.ToArray().Length > 0)
//                 {
//                     MethodInfo[] methods = type.GetMethods();
//                     var methList = methods.ToList()
//                         .FindAll(s => s.GetCustomAttribute(typeof(CCRefreshAttribute)) != null);
//                     for (int j = 0; j < methList.Count; j++)
//                     {
//                         methList[j].Invoke(list[i],null);
//                     }
//                 }
//             }
//             results.AddRange(go.GetComponentsInChildren<T>(true));
//         }
//         return results;
//     }
//
// }
