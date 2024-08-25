using JetBrains.Annotations;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCountTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gamesPlayedText;
    [SerializeField] private int _gamesPlayed = 0;
    private void Start()
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest
        {
            AuthenticationContext = PlayFabTracker.Instance.LoginResult.AuthenticationContext,
            VirtualCurrency = "GP",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddUserVirtualCurrencySuccess, OnAddUserVirtualCurrencyFailure);

        
    }

    public void OnAddUserVirtualCurrencySuccess(PlayFab.ClientModels.ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Added 1 GP to user");    
        _gamesPlayed = result.Balance;
    }

    public void OnAddUserVirtualCurrencyFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    private void Update()
    {
        _gamesPlayedText.text = $"Games Played:\n{_gamesPlayed}";
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
