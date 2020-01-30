using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;

public class LoginScreen : MonoBehaviour
{
    static FirebaseAuth auth;

    public InputField mailField, passwordField, displayNameField;
    public Toggle teamA, teamB;
    string displayName, emailAddress;
    FirebaseManager fbManager;
    bool wasRegistering;

    public TMP_Text errorMessageText;

    bool dirtyFlag;
    string errorMessage;


    void Start()
    {
        fbManager = FirebaseManager.Instance;
        fbManager.InitializeFirebase();
        fbManager.Auth.StateChanged += AuthStateChanged;
        FirebaseManager.OnErrorHappened += DisplayErrorMessage;
    }

    private void OnDestroy()
    { 
        FirebaseManager.OnErrorHappened -= DisplayErrorMessage;
    }

    private void Update()
    {
        if (dirtyFlag)
        {
            errorMessageText.text = errorMessage;
            //Canvas.ForceUpdateCanvases();
            //errorMessageText.gameObject.SetActive(false);
            //errorMessageText.gameObject.SetActive(true);
            dirtyFlag = false;
        }
    }

    public void OnRegisterButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        string displayName = displayNameField.text;
        wasRegistering = true;
        DisplayErrorMessage("");

        if (displayName == "")
        {
            errorMessage = "Please enter a username.";
            return;
        }

        fbManager.RegisterUser(mail, password, displayName);

    }

    void SetUserData()
    {
        CurrentUser.instance = new User(
            displayNameField.text,
            fbManager.User.Email,
            fbManager.User.UserId);
        if (teamA.isOn) CurrentUser.instance.team = 0;
        else CurrentUser.instance.team = 1;
        CurrentUser.instance.gold = 50;
        CurrentUser.instance.UserScore = 100;

        fbManager.WriteNewUser(CurrentUser.instance);
    }

    void GetUserData()
    {
        CurrentUser.instance = new User(
            fbManager.User.DisplayName,
            fbManager.User.Email,
            fbManager.User.UserId);

        fbManager.ReadCurrentUser(CurrentUser.instance);
    }

    public void OnLoginButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        fbManager.LoginUser(mail, password);
        DisplayErrorMessage("");
    }

    public void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (fbManager.Auth.CurrentUser != fbManager.User)
        {
            bool signedIn = fbManager.User != fbManager.Auth.CurrentUser && fbManager.Auth.CurrentUser != null;
            if (!signedIn && fbManager.User != null)
            {
                Debug.Log("Signed out " + fbManager.User.UserId);
            }
            fbManager.User = fbManager.Auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("Signed in " + fbManager.User.UserId);
                if (wasRegistering)
                {
                    SetUserData();
                }
                else
                    GetUserData();

                //fbManager.GetAllUsers();
                SceneManager.LoadScene("UI");
            }
        }
    }

    public void DisplayErrorMessage(string message)
    {

        //errorMessageText.text = errorMessage;
        errorMessage = message;
        dirtyFlag = true;

        Debug.LogError(errorMessage);

    }    
}
