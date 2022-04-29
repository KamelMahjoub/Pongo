using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Credits : MonoBehaviour
{

    private string repositoryURL;
    private string githubURL;
    private string linkedInURL;
    private string facebookURL;
    private string twitterUrl;


    private void Awake()
    {
        Init();
    }

    //Initializes the various link variables.
    private void Init()
    {
        repositoryURL = "https://github.com/KamelMahjoub/Pongo";
        githubURL = "https://github.com/KamelMahjoub";
        linkedInURL = "https://www.linkedin.com/in/kamel-mahjoub/";
        facebookURL = "https://www.facebook.com/TheHungryBoo";
        twitterUrl = "https://twitter.com/TheHungryBoo";
    }


    //Opens the project github page
    public void OpenGithubRepository()
    {
        Application.OpenURL(repositoryURL);
    }
    
    //Opens my github profile
    public void OpenGithubProfile()
    {
        Application.OpenURL(githubURL);
    }

    //Opens my LinkedIN profile
    public void OpenLinkedIn()
    {
        Application.OpenURL(linkedInURL);
    }

    //Opens my Facebook profile
    public void OpenFacebook()
    {
        Application.OpenURL(facebookURL);
    }

    //Opens my Twitter profile
    public void OpenTwitter()
    {
        Application.OpenURL(twitterUrl);
    }
    
    
}
