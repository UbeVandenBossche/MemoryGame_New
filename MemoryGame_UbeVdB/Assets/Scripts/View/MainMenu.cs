using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameInputField;
    [SerializeField] private TextMeshProUGUI passwordInputField;
    [SerializeField] private TextMeshProUGUI emailInputField;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private GameObject playButton;
    private bool loginSuccesful = false;

    string username
    {
        get
        {
            return usernameInputField.text.Remove(usernameInputField.text.Length-1);
        }
    }
    string password
    {
        get
        {
            return passwordInputField.text.Trim();
        }
    }

    string email
    {
        get
        {
            return emailInputField.text.Trim();
        }
    }


        private LoginResult loginResult;

        public void Login()
        {
            var request = new LoginWithPlayFabRequest
            {
                Username = username,
                Password = password
            };

            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
        }

        private void OnLoginFailure(PlayFabError error)
        {
            errorText.text = ("Login Failed. " + error.ToString());
        errorText.color = Color.red;
        }

        private void OnLoginSuccess(LoginResult result)
        {
            loginSuccesful = true;
            loginResult = result;
            PlayFabTracker.Instance.LoginResult = result;
            errorText.text = "Login Successful";
        errorText.color = Color.green;
        }


        public void Register()
        {
            var request = new RegisterPlayFabUserRequest
            {
                Username = username,
                Password = password,
                Email = email
            };

            PlayFabClientAPI.RegisterPlayFabUser(request, OnAccountCreated, OnAccountFailed);
        errorText.color = Color.red;
        }

        void OnAccountCreated(RegisterPlayFabUserResult result)
        {
            errorText.text = "Account Created\nProceed to Login";
        errorText.color = Color.green;
    }

    void OnAccountFailed(PlayFabError error)
    {
        errorText.text = "Account Creation Failed. " + error.ToString();
        Debug.Log(error);
    }

    private void Update()
    {
        playButton.SetActive(loginSuccesful);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}