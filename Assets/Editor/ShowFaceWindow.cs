using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Directory = UnityEngine.Windows.Directory;

public class ShowFaceWindow : EditorWindowBase<ShowFaceWindow>
{
    [MenuItem("Tools/动画 _F1", priority = 2)]
    public static void StartUp()
    {
        Instance.Priority = 1;
        Instance.Show();
        Instance.minSize = new Vector2(400, 130);
    }
 
    private void OnGUI()
    {
        string path = @"E:\Nomi\TempFace";
        
        GUILayout.BeginHorizontal("helpbox");
        GUILayout.Label(path,getCurStyleByTypeStr("label",15,Color.white));
        if (GUILayout.Button("打开",getCurStyleByTypeStr("button",15,Color.white)))
        {
        
            
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    
    public GUIStyle getCurStyleByTypeStr(string type,int size = 20, Color? color = null , TextAnchor style = TextAnchor.MiddleLeft)
    {
        var centeredStyle = new GUIStyle(type);
        centeredStyle.fontSize = size;       //字体大小   
        color = color ?? Color.yellow;
        centeredStyle.normal.textColor = color.Value;
        centeredStyle.alignment = style;
        return centeredStyle;
    }
}
