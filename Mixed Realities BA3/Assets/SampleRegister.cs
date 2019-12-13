using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleRegister : MonoBehaviour
{
    FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;


    public InputField mailField, passwordField;
    string displayName, emailAddress;

    void Awake()
    {
        InitializeFirebase();
    }

    public void OnRegisterButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        StartCoroutine(RegisterUser(mail, password));
    }

    public void OnLoginButton()
    {
        string mail = mailField.text;
        string password = passwordField.text;
        
        auth = FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync(mail, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        auth = FirebaseAuth.DefaultInstance;
        System.Threading.Tasks.Task registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

        //auth.CurrentUser.UpdateUserProfileAsync
        yield return new WaitUntil(() => registerTask.IsCompleted);
        Debug.Log("Register complete");

        if (!registerTask.IsFaulted)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.DisplayName = mailField.text; //Hier wird der username festgelegt
            registerTask = auth.CurrentUser.UpdateUserProfileAsync(userProfile);
            yield return new WaitUntil(() => registerTask.IsCompleted);
        }


        yield return null;
    }

    private IEnumerator LoginUser(string email, string password)
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
        yield return null;
    }

    //Meldet nur Sign out/sign in
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                displayName = user.DisplayName ?? "";
                emailAddress = user.Email ?? "";
            }
        }
    }
}
