using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


public class SocketClientSource  {
    private Socket _socket;
    private static byte[] _buffer = new byte[1024008];
    private int _socketPort = 8889;
    
    private int _maxListen = 10;
    private string ipText = "127.0.0.1";
    private static Socket _acceptSocket;
    private int _index;

   public  SpliceByte message = new SpliceByte();
   private  static SocketClientSource  _Instance;
    public static SocketClientSource  GetInstance()
    {
        if (_Instance == null)
        {
            _Instance = new SocketClientSource();
        }

        return _Instance;
    }

     public int  GetSocketPort()
     {
         return _socketPort;
     }


     public void SetSocketPort(int port)
     {
         _socketPort = port;
     }
     public string GetIP()
     {
         return ipText;
     }

     public void  SetIp(string ipText)
     {
         this.ipText = ipText;
     }


     public void StartDataSource()
     {

         //GameManager.data.StartDataService();
         StartLocalClient();
     }

     public void Destroy()
    {
        if(_socket != null)
        {
            _socket.Close();
            // Debug.Log("close socket");
            _socket = null;
        }
    }

     public void Update()
     {
        
     }


     public void StartLocalClient()
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        ipText = "127.0.0.1";
        _socketPort = 8889;

        IPAddress ip = IPAddress.Parse(ipText);
   

        IPEndPoint endPoint = new IPEndPoint(ip,_socketPort);
        
        Debug.Log("ip = " + ip.ToString() + " port:" + _socketPort);

        try
        {
   
            _socket.Connect(endPoint);
        }
        catch (SocketException e)
        {
            Debug.LogError("Socket error: " + e.Message);
            return;
        }
        catch (Exception e)
        {
            Debug.LogError("Socket general error: "+e.Message);
            return;
        }

        _index = 0;
        StartReceive(_socket);
        Debug.Log("Server add Listener: ip = " + ip.ToString() + " port:" + _socketPort);
      
    }

     

    //接收客户端消息
    private void StartReceive(Socket socket)
    {
        // Debug.Log("Server start receive message from client");
        socket.BeginReceive(message.Data, message.UsedCount, message.RemainSize, SocketFlags.None, ReceiveCallback, socket);
    }

    private byte[] _originByte;
    private void ReceiveCallback(IAsyncResult iar)
    {
        // Debug.Log("Server receive message from client");

        _index++;
        Socket socket = iar.AsyncState as Socket;
        if (socket == null)
        { 
            Debug.LogError("no socket");
            return;
        }

        int msgLen = socket.EndReceive(iar);
        if (msgLen == 0)
        {
            Debug.LogError("msgLen =0");
            return;
        }
       // Debug.Log("第"+_index+"次接收到的数据长度为：" + msgLen);

        message.ReadData(msgLen);        //
    
        
        
        socket.BeginReceive(message.Data, message.UsedCount, message.RemainSize, SocketFlags.None, ReceiveCallback, socket);
        
        
    }


    public void ResumeReceiveData()
    {
        if (_socket != null)
        {
            _socket.BeginReceive(message.Data, message.UsedCount, message.RemainSize, SocketFlags.None, ReceiveCallback,_socket);
        }
        else
        {
            Debug.LogError("socket is null");
        }
       
    }
    
    
}
