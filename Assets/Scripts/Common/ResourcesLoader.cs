using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//资源加载类
public class ResourcesLoader : Singleton<ResourcesLoader>
{
    // Start is called before the first frame update
     
    //加载资源
    public  Sprite LoadSprite(string spritePath)
    {
        // 通过Resources.Load加载Sprite
        Sprite sprite = Resources.Load<Sprite>(spritePath);

        if (sprite == null)
        {
            Debug.LogError($"Failed to load sprite from path: {spritePath}");
        }

        return sprite;
    }


    public void LoadAsync(string path, Action<UnityEngine.Object> onLoaded)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("[C#] ResourceLoader.Load key is null");
            return;
        }

        UnityEngine.Object asset = Resources.Load(path);
        if (onLoaded != null)
        {
            if (asset == null)
            {
                Debug.LogError("LoadResource is null. " + path);
                onLoaded(null);
            }
            else
            {
                //Debug.Log("path=" + path + ", typeof asset = " + asset.GetType() + ", constructor=" + asset.GetType().BaseType);
                onLoaded(asset);
            }
        }
    }

   public Sprite LoadTexture(string path)
    {

        Texture2D texture2D = (Texture2D)Load(path);

        if(texture2D)
        {
           return  Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        }
         return null;
    }
    public UnityEngine.Object Load(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("[C#] ResourceLoader.Load key is null");
            return null;
        }

        return Resources.Load(path);
    }



}
