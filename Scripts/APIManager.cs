using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class APIManager : MonoBehaviour
{
    public static APIManager instance;

    private readonly string basePath = "https://retoolapi.dev/XW2siq/data";
    public UserData[] users;

    public UserData currentUser;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    public void Start()
    {
        Get();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckUser()
    {
        foreach (UserData user in users)
        {
            if (user.userName == currentUser.userName)
            {
                currentUser.id = user.id;
                return true;
            }
                
        }
        return false;
    }

    public bool CheckUserAndPass()
    {
        foreach (UserData user in users)
        {
            if (user.userName == currentUser.userName && user.password == currentUser.password)
                return true;
        }
        return false;
    }

    public void AddUser()
    {
        currentUser.id = users.Length + 1;
        Post();
        Get();
    }

    public void Login()
    {
        if (CheckUser())
        {
            if (CheckUserAndPass())
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                UIManager.instance.SetReaction("Password incorrect");
        }
        else
        {
            UIManager.instance.SetReaction("User does not exist");
        }
    }

    public void SignUp()
    {
        if (UIManager.instance.txtPasswordNew.text != UIManager.instance.txtPasswordCheck.text)
        {
            UIManager.instance.SetReaction("Passwords do not match");
        }
        else
        {
            if (!CheckUser())
            {
                AddUser();
                UIManager.instance.SetReaction("Return to the Login screen to continue");
            }
            else
            {
                UIManager.instance.SetReaction("User already exists");
            }
        }
    }

    public void Get()
    {
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);

                if (users != null)
                    Debug.Log("Number of users: " + users.Length);
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "User array is null");
            }

        }).Catch(error =>
        {
            Debug.Log(error.Message);
        });
    }

    public void Post()
    {
        RestClient.Post(basePath, currentUser).Then(response =>
        {
            try
            {
                if (response != null)
                    Debug.Log("Successful");
                else
                    Debug.Log("No response");
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting UserData");
            }
        }).Catch(error =>
        {
            Debug.Log(error.Message);
        });
    }
}
