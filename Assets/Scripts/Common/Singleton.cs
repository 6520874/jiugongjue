using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Singleton<T>: MonoBehaviour  where T : Singleton<T>, new()
{   //static前缀使得可以通过类名.属性名来访问该属性
    private static T instance = null;
    public static T Instance
    {   //只有get方法没有set方法，意味Instance对其他类为只读
        get
        {   //如果instance为空，则重新初始化instance为指向T类实例的指针
            if (instance == null)
            {
                instance = new T();
            }
            //否则返回唯一的instance属性
            return instance;
        }
    }
}