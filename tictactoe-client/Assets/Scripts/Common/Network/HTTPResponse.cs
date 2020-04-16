using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPResponse
{
    long code;
    string message;
    Dictionary<string, string> headers;

    public long Code { get { return code; } }
    public string Message { get { return message; } }
    public Dictionary<string, string> Headers { get { return headers; } }

    public HTTPResponse(long code, string message, Dictionary<string, string> headers)
    {
        this.code = code;
        this.message = message;
        this.headers = headers;
    }

    public T GetDataFromMessage<T>() where T : class
    {
        T result = null;
        if (this.code == 200 && this.message != null)
        {
            result = JsonUtility.FromJson<T>(this.Message);
        }
        return result;
    }
}

public class HTTPResponseMessage
{
    public string message;
}

public class HTTPResponseInfo
{
    public string name;
    public int score;
}

public class HTTPResponseChat
{
    [System.Serializable]
    public struct Chat
    {
        public string _id;
        public string message;
        public string name;
        public string date;
    }

    public Chat[] objects;
}
