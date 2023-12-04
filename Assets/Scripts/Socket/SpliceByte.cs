using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class SpliceByte
{
    private byte[] data = new byte[1024008];
    private int usedCount = 0;
    

    public byte[] Data { get { return data; } }
    public int UsedCount { get { return usedCount; } }
    public int RemainSize { get { return data.Length - usedCount; } }

    public void ReadData(int length)
    {
        usedCount += length;

        while (true)
        {
            
            if (usedCount <= 4) return;
            
            //真正长度
            int count = BitConverter.ToInt32(data, 0);
            
            if ((usedCount - 4) >= count)
            {
                byte[] byteArray = data.Skip(4).Take(count).ToArray();

                Debug.Log("byte"+byteArray.ToString());
                

                // GameManager.data.ParseProtobufData(byteArray);
                Array.Copy(data, count + 4, data, 0, usedCount - 4 - count);
                usedCount -= count + 4;
            }
            else
                return;
        }
    }
}