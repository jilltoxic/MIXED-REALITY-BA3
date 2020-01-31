﻿using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FirebaseManager
{

    public delegate void ErrorHappened(string errorMessage);
    public static event ErrorHappened OnErrorHappened;

    static FirebaseAuth auth;
    public FirebaseAuth Auth
    {
        get { if (auth == null) auth = FirebaseAuth.DefaultInstance; return auth; }
    }

    Firebase.Auth.FirebaseUser user;
    public FirebaseUser User
    {
        get { return user; }
        set { user = value; }
    }

    DatabaseReference databaseReference; 

    private static FirebaseManager instance;
    public static FirebaseManager Instance
    {
        get { if (instance == null) instance = new FirebaseManager(); return instance; }
    }

    /// <summary>
    /// Initializes the Firebase stuff.
    /// Needs to be called at the beginning of the game.
    /// </summary>
    public void InitializeFirebase()
    {
        //Auth.StateChanged += AuthStateChanged; //Example: How to register a function to be called as a Response to the state change. See LoginScreen.cs for a proper implementation
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mixed-realities-ba3.firebaseio.com/");
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("teamscore").ValueChanged += GetTeamScore;
    }

    /// <summary>
    /// Registers a new user on the firebase database.
    /// </summary>
    /// <param name="email">The users' mail</param>
    /// <param name="password">The chosen password</param>
    /// <param name="displayName">The username visible to others</param>
    public void RegisterUser(string email, string password, string displayName)
    {
        Auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {

            if (task.IsCanceled)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                //return;

                Firebase.FirebaseException e =
                task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                HandleError((AuthError)e.ErrorCode);
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                //return;

                Firebase.FirebaseException e =
                task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                HandleError((AuthError)e.ErrorCode);
                return;


            }

            // Firebase user has been created.

            Firebase.Auth.FirebaseUser newUser = task.Result;
            UserProfile profile = new UserProfile();
            profile.DisplayName = displayName;
            newUser.UpdateUserProfileAsync(profile).ContinueWith(task2 =>
            {
                if (task2.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task2.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task2.Exception);
                    return;

                }
            });
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            LoginUser(email, password);
        });
    }

    /// <summary>
    /// Login an existing user
    /// </summary>
    /// <param name="email">the users' email</param>
    /// <param name="password">ther users' password</param>
    public void LoginUser(string email, string password)
    {
        Auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                //return;

                Firebase.FirebaseException e =
                task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);
                HandleError((AuthError)e.ErrorCode);

                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }


    public void LogoutUser()
    {
        if (auth.CurrentUser != null)
        {
            auth.SignOut();
            Debug.LogFormat("User logged out successfully: {0} ({1})",
                 CurrentUser.instance.username, CurrentUser.instance.userID);

        }
    }


    // errors and stuff

    public void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();   
        Debug.Log("Error: " + msg);
    }

   

    public void HandleError(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();

        string errorMessage = "";

        switch (errorCode.ToString())
        {
            case "EmailAlreadyInUse":
                {
                    errorMessage = "This E-Mail is already in use.";
                    break;
                }

            case "InvalidEmail":
                {
                    errorMessage = "<color=red>Please use a valid E-Mail.</color>";
                    break;
                }


            case "WrongPassword":
                {
                    errorMessage = "The password is incorrect";
                    break;
                }

            case "MissingEmail":
             {
                    errorMessage = "Please enter an Email.";
                    break;
             }
             
            case "MissingPassword":
              {
                errorMessage = "Please enter a Password.";
                break;
              }

            case "TooManyRequests":
                {
                    errorMessage = "Too many requests. Please try again.";
                    break;
                }

            case "UserNotFound":
                {
                    errorMessage = "User was not found.";
                    break;
                }

            case "WeakPassword":
                {
                    errorMessage = "Please choose a stronger Password. (min. 6 characters)";
                    break;
                }

            default:
                {
                    errorMessage = "Something is wrong.";
                    break;
                }
        }

        OnErrorHappened(errorMessage);
        
    }


        /// <summary>
        /// Example Event that gets called when the user signs in/out
        /// Could be used to switch the scene after login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (Auth.CurrentUser != user)
        {
            bool signedIn = user != Auth.CurrentUser && Auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = Auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }




    // -------------------------------- DATABASE -----------------------------------------

        /// <summary>
        /// Writes new or updates existing user
        /// </summary>
        /// <param name="user"></param>
    public void WriteNewUser(User user)
    {
        string json = JsonUtility.ToJson(user);
        Debug.Log("Save JSON to Database.\nDATA: \n"+json);
        databaseReference.Child("users").Child(user.userID).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Done");
                UI.dirty = true;

                return;
            }
        });
    }

    //Get current User stats

    public void ReadCurrentUser(User user)
    {
        databaseReference.Child("users").Child(user.userID).GetValueAsync().ContinueWith(task => 
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                //DataSnapshot snapshot = task.Result;
                if (task.Result.GetRawJsonValue() == null)
                {
                    Debug.LogError("ReadCurrentUser(User " + user.userID + ") is null.");
                    return;
                }
                string json = task.Result.GetRawJsonValue();
                Debug.Log(json);
                CurrentUser.instance = JsonUtility.FromJson<User>(json);
                UI.dirty = true;
            }
        });
    }

    //overwrites a user value in databaseq

    public void UpdateUserValue(User user, string key, object value)
    {
        databaseReference.Child("users").Child(user.userID).Child(key).SetValueAsync(value).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Done");
                ReadCurrentUser(CurrentUser.instance);
                return;
            }
        });
    }

    // -------------------------------- SCRUB LORDS TRYIN REAL HARD -----------------------------------------

    /// <summary>
    /// Updates both team scores. Don't use this.
    /// </summary>
    public void SetTeamScore() //no new score yet i have no idea what i am doing 
    {
        Debug.Log("Updating Team Score");

        string json = JsonUtility.ToJson(CurrentTeamScore.instance);
        Debug.Log("Save JSON to Database.\nDATA: \n" + json);
        databaseReference.Child("teamscore").SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Done");
                return;
            }
        });
    }

    public void SetOwnTeamScore(int valueToAdd)
    {
        string key = CurrentUser.instance.team == 0 ? "RubyRiderScore" : "GoldenCircleScore";

        float valueToSet = CurrentUser.instance.team == 0 ? CurrentTeamScore.instance.RubyRiderScore + valueToAdd : CurrentTeamScore.instance.GoldenCircleScore + valueToAdd;
        databaseReference.Child("teamscore").Child(key).SetValueAsync(valueToSet).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Done");
                return;
            }
        });

        /*databaseReference.Child("teamscore").Child(key).RunTransaction(mutableData => {
            int? score = mutableData.Value as int?;

            if (score == null) score = 0;
            score += valueToAdd;

            mutableData.Value = score;
            return TransactionResult.Success(mutableData);            
        });*/
    }

        //databaseReference.Child("GoldenCircleScore").SetValueAsync(50).ContinueWith(task =>
        //{
        //    if (task.IsFaulted)
        //    {
        //        // Handle the error...
        //        Debug.LogError(task.Exception);
        //        return;
        //    }
        //    else if (task.IsCompleted)
        //    {
        //        Debug.Log("Done");
        //        return;
        //    }
        //});


    public void GetTeamScore(object sender, ValueChangedEventArgs args)
    {
        databaseReference.Child("teamscore").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                string json = task.Result.GetRawJsonValue();
                Debug.Log(json);
                CurrentTeamScore.instance = JsonUtility.FromJson<TeamScore>(json);
                Debug.Log("Done");
                UI.dirty = true;
                return;
            }
        });
    }

    public void GetAllUsers()
    {
      
        Debug.Log("Retrieving All Users");
        databaseReference.Child("users").GetValueAsync().ContinueWith(task =>
        { 
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot userIDList = task.Result;
                foreach (var userID in userIDList.Children)
                {
                    
                    GetUserInfo(userID.Key);
                }
                Debug.Log("Done");
                return;
            }
        });
    }

    public void GetTopPlayers()
    {
        databaseReference.Child("users").OrderByChild("/userScore").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.LogError(task.Exception);
                    return;
                }
                else if (task.IsCompleted)
                {
                    /*int rank = 1;
                    DataSnapshot userIDList = task.Result;

                    foreach (DataSnapshot leader in userIDList.Children)
                    //for (int i = 0; i < numberOfPlayers; i++)
                    {
                        Debug.LogWarning(rank + ". " + leader.Child("username").Value + " " + leader.Child("userScore").Value);
                        rank++;
                    }

    */
                    LeaderboardManager.data = task.Result;
                    LeaderboardManager.dirtyFlag = true;
                    Debug.Log("Done");
                    return;
                }
        });


    }

    public User GetUserInfo(string userID)
    {
        User userInfo = new User();        

        Debug.Log("Retrieving User Info");
        databaseReference.Child("users").Child(userID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.LogError(task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Done");
                DataSnapshot dataSnapshot = task.Result;
                string json = dataSnapshot.GetRawJsonValue();
                userInfo = JsonUtility.FromJson<User>(json);
                Debug.Log($"{userID} - Gold: {userInfo.gold}");
                return;
            }
        });

        
        return userInfo;
    }

  
}
