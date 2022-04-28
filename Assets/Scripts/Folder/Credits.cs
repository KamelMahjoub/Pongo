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

    private void Init()
    {
        repositoryURL = "https://github.com/KamelMahjoub/Pongo";
        githubURL = "https://github.com/KamelMahjoub";
        linkedInURL = "https://www.linkedin.com/in/kamel-mahjoub/";
        facebookURL = "https://www.facebook.com/TheHungryBoo";
        twitterUrl = "https://twitter.com/TheHungryBoo";
    }


    public void OpenGithubRepository()
    {
        Application.OpenURL(repositoryURL);
    }

    public void OpenGithubProfile()
    {
        Application.OpenURL(githubURL);
    }

    public void OpenLinkedIn()
    {
        Application.OpenURL(linkedInURL);
    }

    public void OpenFacebook()
    {
        Application.OpenURL(facebookURL);
    }

    public void OpenTwitter()
    {
        Application.OpenURL(twitterUrl);
    }
    
    
}
