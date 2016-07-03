using UnityEngine;
using Facebook.Unity;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class FacebookController : MonoBehaviour {

    public string URLContent;
    public string contentTitle;
    private string contentDescription;
    public string URLPhoto;
    private Uri contentURL;
    private Uri photoURL;

    public Button ShareButton;


    
    void Awake()
    {
        FB.Init(InitCallback, OnHideUnity);
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }

    }

    
    
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }
    

    
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    public void FacebookInitiate()
    {
        var perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
        ShareOnFacebook();
    }
    
    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }
    
    
    public void PublicScore()
    {
        var tutParams = new Dictionary<string, object>();
        tutParams[AppEventParameterName.ContentID] = "Test_1";
        tutParams[AppEventParameterName.Description] = "Yoo";
        tutParams[AppEventParameterName.Success] = "1";

        FB.LogAppEvent(
            AppEventName.CompletedTutorial,
            parameters: tutParams
        );
    }
    
    // Use this for initialization
    void Start ()
    {
        contentURL = new Uri(URLContent);
        photoURL = new Uri(URLPhoto);
        contentDescription = "É 37 anos! Consegui " + PlayerPrefsManager.GetIntLocalValue(PlayerPrefsManager.LASTSCORE) + " levantamentos. Duvido fazer mais :D";
        //FB.Init();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    

    public void ShareOnFacebook()
    {
        //var perms = new List<string>() { "public_profile", "email", "user_friends" };
        //FB.LogInWithReadPermissions(perms, AuthCallback);

        FB.ShareLink(
            contentURL,
            contentTitle,
            contentDescription,
            photoURL,
            callback: ShareCallback);
    }

    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            //ShareButton.interactable = false;
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {

            //ShareButton.interactable = false;
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }
}
