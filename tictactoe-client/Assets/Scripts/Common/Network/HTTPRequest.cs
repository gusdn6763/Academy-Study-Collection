using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPRequest
{
    public string GetJSON()
    {
        string json = JsonUtility.ToJson(this);
        return json;
    }
}

public class HTTPRequestSignUp : HTTPRequest
{
    public string username, password, name;
    public HTTPRequestSignUp(string username, string password, string name)
    {
        this.username = username;
        this.password = password;
        this.name = name;
    }
}

public class HTTPRequestSignIn : HTTPRequest
{
    public string username, password;
    public HTTPRequestSignIn(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}

public class HTTPRequestAddScore : HTTPRequest
{
    public int score;
    public HTTPRequestAddScore(int score)
    {
        this.score = score;
    }
}

public class HTTPRequestAddMessage : HTTPRequest
{
    public string message;
    public HTTPRequestAddMessage(string message)
    {
        this.message = message;
    }
}
