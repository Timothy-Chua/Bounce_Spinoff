using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Login")]
    public GameObject panelLogin;
    public TMP_InputField txtUser;
    public TMP_InputField txtPassword;

    [Header("Sign Up")]
    public GameObject panelSignUp;
    public TMP_InputField txtUserNew;
    public TMP_InputField txtPasswordNew;
    public TMP_InputField txtPasswordCheck;

    [Header("Reaction")]
    public GameObject panelReaction;
    public TextMeshProUGUI txtReaction;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        txtReaction.text = null;
        panelReaction.gameObject.SetActive(false);
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Update()
    {
        if (txtReaction.text != null)
        {
            StartCoroutine(Reaction());
            
        }

        if (panelLogin.activeInHierarchy)
        {
            APIManager.instance.currentUser.userName = txtUser.text;
            APIManager.instance.currentUser.password = txtPassword.text;
        }
        else if (panelSignUp.activeInHierarchy)
        {
            APIManager.instance.currentUser.userName = txtUserNew.text;
            APIManager.instance.currentUser.password = txtPasswordNew.text;
        }
    }

    public IEnumerator Reaction()
    {
        panelReaction.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.75f);

        panelReaction.gameObject.SetActive(false);
        txtReaction.text = null;
    }

    public void SetReaction(string text)
    {
        txtReaction.text = text;
        StartCoroutine(Reaction());
    }

    public void _BtnSignIn()
    {
        APIManager.instance.Login();
    }

    public void _BtnSignUp()
    {
        APIManager.instance.SignUp();
    }
}
