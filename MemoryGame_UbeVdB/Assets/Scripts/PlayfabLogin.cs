using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Playfab : MonoBehaviour
{
    LoginResult _loginResult;
    string _email;
    string _password;

    void OnloginClick()
    {
        Debug.Log("Trying to log in");
        var request = new RegisterPlayFabUserRequest
        {
            
        };

        
    }
}
