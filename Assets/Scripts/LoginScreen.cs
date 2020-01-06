using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    public InputField mailField, passwordField, displayNameField;
    public Toggle teamA, teamB;
    string displayName, emailAddress;
    FirebaseManager fbManager;
    bool wasRegistering;

    public Text errorMessageText;


    void Start()
    {
        fbManager = FirebaseManager.Instance;
        fbManager.InitializeFirebase();
        fbManager.Auth.StateChanged += AuthStateChanged;
    }

    public void OnRegisterButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        string displayName = displayNameField.text;
        wasRegistering = true;
        fbManager.RegisterUser(mail, password, displayName);

        if(mailField.text == "")
        {
            errorMessageText.text = "Please enter an E-Mail address.";
        }
        else if(passwordField.text == "")
        {
            errorMessageText.text = "Please enter a password.";
        }
        else if (displayNameField.text == "")
        {
            errorMessageText.text = "Please enter a username.";
        }
        else
        {
            errorMessageText.text = "";
        }
    }

    void SetUserData()
    {
        CurrentUser.instance = new User(
            displayNameField.text,
            fbManager.User.Email,
            fbManager.User.UserId);
        CurrentUser.instance.team = teamA.isOn ? 0 : 1;
        CurrentUser.instance.gold = 50;

        fbManager.WriteNewUser(CurrentUser.instance);
        SceneManager.LoadScene("Main");
    }

    void GetUserData()
    {
        CurrentUser.instance = new User(
            fbManager.User.DisplayName,
            fbManager.User.Email,
            fbManager.User.UserId);

        fbManager.ReadCurrentUser(CurrentUser.instance);
        SceneManager.LoadScene("Main");
    }

    public void OnLoginButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        fbManager.LoginUser(mail, password);

       
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
                    SetUserData();
                else
                    GetUserData();
                fbManager.SetTeamScore(CurrentUser.instance.team, 0);
                fbManager.SetTeamScore(1, 0);
                fbManager.GetAllUsers();
            }
        }
    }
}
