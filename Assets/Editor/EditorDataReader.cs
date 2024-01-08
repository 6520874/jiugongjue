using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON_Local;
using UnityEditor;
using UnityEngine;

public class EditorDateArray : ScriptableObject
{
     public EditorDate[] array;

     private void OnValidate()
     {
          EditorDataReader.ClearData();
     }
}

[Serializable]
public class EditorDate
{
     public string key;
     public string value;
}

public static class EditorDataReader
{
     private static string sDataPath = Path.Combine("Assets","dev","_dev","Config","EditorConfig", "EditorConfig.json");

     private static Dictionary<string, JSONNode> sEditorDateDic;

     public static void ClearData()
     {
          if (sEditorDateDic == null)
          {
               return;
          }
          sEditorDateDic.Clear();
          sEditorDateDic = null;
     }
     
     public static void ReadDate()
     {
          TextAsset json = AssetDatabase.LoadAssetAtPath<TextAsset>(sDataPath);
          sEditorDateDic = new Dictionary<string, JSONNode>();
          if(json == null)
          {
               Debug.Log("null");
          }
          else
          {
               JSONNode node = JSON.Parse(json.text.Replace("\\",@"\\"));
               int index = 0;
               foreach (var key in node.Keys)
               {
                    sEditorDateDic.Add(key, node[index++]);
               }
          }
     }

     public static JSONNode GetValue(string key, JSONNode defaultValue = null)
     {
          if (sEditorDateDic == null)
          {
               ReadDate();
          }

          if (string.IsNullOrEmpty(key))
          {
               return defaultValue;
          }

          if (!sEditorDateDic.ContainsKey(key))
          {
               return defaultValue;
          }
          return sEditorDateDic[key];
     }

     public static JSONNode[] GetValue(string[] keys, JSONNode[] defaultValues = null)
     {
          if (sEditorDateDic == null)
          {
               ReadDate();
          }
          JSONNode[] nodes = new JSONNode[keys.Length];
          for (int i = 0; i < keys.Length; i++)
          {
               var key = keys[i];
               bool hasValue = !string.IsNullOrEmpty(key);

               if (hasValue && !sEditorDateDic.ContainsKey(key))
               {
                    hasValue = false;
               }

               if (!hasValue)
               {
                    if (defaultValues != null && defaultValues.Length > i)
                    {
                         nodes[i] = defaultValues[i];
                    }
                    else
                    {
                         nodes[i] = JSONNull.CreateOrGet();
                    }
                    continue;
               }
               nodes[i] = sEditorDateDic[key];
          }
          return nodes;
     }

     public static void SetValue(string key, JSONNode node)
     {
          if (sEditorDateDic == null)
          {
               ReadDate();
          }
          if (sEditorDateDic == null)
          {
               return;
          }
          sEditorDateDic.AddDic(key, node);
          JSONObject jnode = new JSONObject();

          foreach (var k in sEditorDateDic.Keys)
          {
               jnode.Add(k, sEditorDateDic[k]);
          }
          
          string path = sDataPath;
          if (path.StartsWith("Assets"))
          {
               path = path.Substring("Assets".Length);
          }
          string dataPath = Application.dataPath+path;
          BuildEditor.WritePure(dataPath,  jnode.ToJsonString());
     }
     
     public static void SetValue(Dictionary<string, JSONNode> dic)
     {
          if (dic == null)
          {
               return;
          }
          if (sEditorDateDic == null)
          {
               ReadDate();
          }
          if (sEditorDateDic == null)
          {
               return;
          }
          foreach (var key in dic.Keys)
          {
               if (string.IsNullOrEmpty(key) || dic[key] == null)
               {
                    continue;
               }
               sEditorDateDic.AddDic(key, dic[key]);
          }
          JSONObject jnode = new JSONObject();

          foreach (var k in sEditorDateDic.Keys)
          {
               jnode.Add(k, sEditorDateDic[k]);
          }
          
          string path = sDataPath;
          if (path.StartsWith("Assets"))
          {
               path = path.Substring("Assets".Length);
          }
          string dataPath = Application.dataPath+path;
          BuildEditor.WritePure(dataPath,  jnode.ToJsonString());
     }
}
