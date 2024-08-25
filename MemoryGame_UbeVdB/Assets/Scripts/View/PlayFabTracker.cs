using Memory.Utilities;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabTracker : Singleton<PlayFabTracker>
{
    public LoginResult LoginResult;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
