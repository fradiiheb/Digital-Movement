using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Globalization;


using System.Text;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class FormVerification : MonoBehaviour
{
    [Header("Email SignIn")]
    public InputField EmailInput;
    public InputField PasswordInput;
    public InputField RePasswordInput;
    public string  Email, Password, RePassword;
    public Image errorEmail, errorPassword, errorRePassword;
    public GameObject EmailPanel, ProfilPanel;
    public string EmailPart1, EmailPart2;

    [Header("Profile SignIn")]
    public RawImage photo;
    public InputField NomInput, PrenomInput, TelephoneInput;
    public Image errorNom, errorPrenom, errorTelephone;
    public Dropdown dropdowngouvernorat, dropdownVille, dropdownNiveau, dropdownSchool;
    public string Nom, Prenom, Telephone, Gouvernorat, Ville, Niveau, photoName, school;
    public int TotalGold=0;
    public UserFireBase userFireBase;
    public UploadImage uploadImage;
    public User user;
    public UserScriptableObject userScriptableObject;

    [Header("Email Login")]
    public InputField LoginEmailInput;
    public InputField LoginPasswordInput;
    public Image errorLoginEmail, errorLoginPassword;


    public GameObject loginPanel;
    public GameObject SignPanel;
    public bool haveUser;
    
    #region bouttons
    public void LoginClick()
    {
        loginPanel.SetActive(true);
        SignPanel.SetActive(false);
    }
    public void SignInClick()
    {
        loginPanel.SetActive(false);
        SignPanel.SetActive(true);
    }

    #endregion

    #region LogIN


    public bool verifLogin()
    {
        if (Email == "" || Password == "")
        {
            return false;
        }
        else
            return true;
    }

    public void veriffromScriptable()
    {
        RePassword = Decrypt(userScriptableObject.user.Password);
      
           
        if (userScriptableObject.user.Email == Email&&Password == RePassword)
        {

            Debug.LogError("allGood from scriptable");
            SceneManager.LoadScene("Home");
        }
        else
        {
            StartCoroutine(verifpasswordfrombase());
        }
    }
    public void SubmitEmailLgin()
    {

        if (verifLogin())
        {
            
            userFireBase.Email = Email;
            String[] parts = Email.Split(new[] { '.' });
            EmailPart1 = parts[0]; // "hello"
            EmailPart2 = parts[1]; // "example.com"

            userFireBase.EmailPart1 = EmailPart1;
            userFireBase.EmailPart2 = EmailPart2;
            veriffromScriptable();

        }
        else
        {
            userFireBase.Email = "";
            userFireBase.password = "";
            Debug.LogError("nope");
        }
    }
    bool waitToGetUser()
    {
        if (userFireBase.endRetrive == true)
            return true;
        else
            return false;
    }
    IEnumerator verifpasswordfrombase()
    {
        userFireBase.OnGetEmail();
        
        yield return new WaitUntil(waitToGetUser);
        if (userFireBase.foundUser) {
            userFireBase.endRetrive = false;
            RePassword =  Decrypt(userFireBase.user.getPassword());
            if (Password == RePassword)
            {
                Debug.LogError("allGood");
                userScriptableObject.user = new User(1, userFireBase.Nom, userFireBase.Prenom, userFireBase.Niveau, userFireBase.Telephone, userFireBase.Email, userFireBase.Gouvernorat, userFireBase.Ville, userFireBase.school, userFireBase.photoName, userFireBase.password, TotalGold);
                SceneManager.LoadScene("Home");
            }
            else
            {
                Debug.LogError("verifPassword");
            }
        }
        else
        {
            Debug.LogWarning("worngUser");
            userFireBase.endRetrive = false;
        }
    }

    public void OnendEmailLogin()
    {
        Text text = LoginEmailInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (!IsValidEmail(LoginEmailInput.text))
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorLoginEmail.gameObject.SetActive(true);
            Email = "";
        }
        else
        {
            text.color = Color.black;
            errorLoginEmail.gameObject.SetActive(false);
            Email = LoginEmailInput.text;
            //userFireBase.Email = Email;
        }

    }
    public void OnendPasswordLogin()
    {
        Text text = LoginPasswordInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (!passwordValid(LoginPasswordInput.text))
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorLoginPassword.gameObject.SetActive(true);
            Password = "";
        }
        else
        {
            text.color = Color.black;
            errorLoginPassword.gameObject.SetActive(false);
            Password = LoginPasswordInput.text;
            // userFireBase.Nom = Nom;
        }
    }
    #endregion

    #region Profile SignIn



    public void Submit()
    {




        Gouvernorat = dropdowngouvernorat.options[dropdowngouvernorat.value].text;
        school = dropdownSchool.options[dropdownSchool.value].text;
        Ville = dropdownVille.options[dropdownVille.value].text;
        Niveau = dropdownNiveau.options[dropdownNiveau.value].text;


        

        if (VerifProfile())
        {
            Debug.LogError("allGood");
            photoName = Nom + " " + Prenom + ".png";

            userFireBase.Gouvernorat = Gouvernorat;
            userFireBase.Ville = Ville;
            userFireBase.school = school;
            userFireBase.Niveau = Niveau;
            userFireBase.Nom = Nom;
            userFireBase.Prenom = Prenom;
            userFireBase.Telephone = Telephone;
            userFireBase.photoName = photoName;
            userScriptableObject.user = new User(1, Nom, Prenom, Niveau, Telephone, Email, Gouvernorat, Ville, school, photoName, Password, TotalGold);
            //userFireBase.OnSubmit();
            uploadImage.SaveImage(Nom + " " + Prenom);

         
        }
        else
        {
            userFireBase.Gouvernorat = "";
            userFireBase.Ville = "";
            userFireBase.school = "";
            userFireBase.Niveau = "";
            userFireBase.Nom = "";
            userFireBase.Prenom = "";
            userFireBase.Telephone = "";
            userFireBase.photoName = "";
            Debug.LogError("nope");
        }


    }
    public bool VerifProfile()
    {
        if (Nom == "" || Prenom == "" || Telephone == "" || Niveau == "" || photo.texture == null)
        {
            return false;
        }
        else
            return true;
    }
    //Name
    public void OnendName()
    {
       
        Text text = NomInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (NomInput.text.Length < 3)
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorNom.gameObject.SetActive(true);
            Nom = "";
        }
        else
        {
            text.color = Color.black;
            errorNom.gameObject.SetActive(false);
            Nom = NomInput.text;
         //   userFireBase.Nom = Nom;
        }
    }
    //Prenom
    public void OnendPrenom()
    {
        Text text = PrenomInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (PrenomInput.text.Length < 3)
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorPrenom.gameObject.SetActive(true);
            Prenom = "";
        }
        else
        {
            text.color = Color.black;
            errorPrenom.gameObject.SetActive(false);
            Prenom = PrenomInput.text;
            //userFireBase.Prenom = Prenom;
        }
    }
    //telephone
    public void OnendTelephone()
    {
        Text text = TelephoneInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (TelephoneInput.text.Length < 3)
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorTelephone.gameObject.SetActive(true);
            Telephone = "";
        }
        else
        {
            text.color = Color.black;
            errorTelephone.gameObject.SetActive(false);
            Telephone = TelephoneInput.text;
          //  userFireBase.Telephone = Telephone;
        }
    }

    #endregion

    #region Email SignIn
    public void SubmitEmail()
    {

        if (VerifMail())
        {
            
          
           
            userFireBase.Email = Email;
            String[] parts = Email.Split(new[] { '.' });
            EmailPart1 = parts[0]; // "hello"
            EmailPart2 = parts[1]; // "example.com"
            
            userFireBase.EmailPart1 = EmailPart1;
            userFireBase.EmailPart2 = EmailPart2;
            StartCoroutine(verifUser());
            
            
        }
       
    }
   
    bool waittonotgetuser()
    {
        
            if (userFireBase.endRetrive==true)
                return true;
            else
                return false;
        
    }
    IEnumerator verifUser()
    {
        userFireBase.OnGetEmail();
        

        yield return new WaitUntil(waittonotgetuser);

        if (userFireBase.foundUser==false)
        {
            Debug.LogError("allGood");
            Password = Encrypte(Password);
            userFireBase.password = Password;
            EmailPanel.SetActive(false);
            ProfilPanel.SetActive(true);
            
            userFireBase.endRetrive = false;
        }
        else
        {
            userFireBase.user = null;
            Debug.LogError("Notgood");
            userFireBase.endRetrive = false;
        }
        //userFireBase.endRetrive = false;




    }


    public bool VerifMail()
    {
        if ( Email == "" || Password == "" || RePassword == "")
        {
            return false;
        }
        else
            return true;
    }

    public void OnendEmail()
    {
        Text text = EmailInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (!IsValidEmail(EmailInput.text))
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorEmail.gameObject.SetActive(true);
            Email = "";
        }
        else
        {
            text.color = Color.black;
            errorEmail.gameObject.SetActive(false);
            Email = EmailInput.text;
            //userFireBase.Email = Email;
        }

    }
    public void OnendPassword()
    {
        Text text = PasswordInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (!passwordValid(PasswordInput.text))
        {
            Color newColor = new Color(1, 0, 0);
            text.color = newColor;
            errorPassword.gameObject.SetActive(true);
            Password = "";
        }
        else
        {
            text.color = Color.black;
            errorPassword.gameObject.SetActive(false);
            Password = PasswordInput.text;
            // userFireBase.Nom = Nom;
        }
    }
    public void OnendRePassword()
    {
        Text Repasswordtext = RePasswordInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        Text passwordtext = PasswordInput.transform.Find("Text (Legacy)").GetComponent<Text>();
        if (Password != RePasswordInput.text)
        {
            Color newColor = new Color(1, 0, 0);
            Repasswordtext.color = newColor;
            passwordtext.color = newColor;
            errorPassword.gameObject.SetActive(true);
            errorRePassword.gameObject.SetActive(true);
            RePassword = "";
        }
        else
        {
            Repasswordtext.color = Color.black;
            passwordtext.color = Color.black;
            errorPassword.gameObject.SetActive(false);
            errorRePassword.gameObject.SetActive(false);
            RePassword = RePasswordInput.text;
            // userFireBase.Nom = Nom;
        }
    }
    #region passwordValid
    public bool passwordValid(string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");

        if (!hasNumber.IsMatch(password))
        {
            Debug.Log("number dont Match");
        }
        if (!hasUpperChar.IsMatch(password))
        {
            Debug.Log("hasUpperChar  dont Match");
        }
        if (!hasMinimum8Chars.IsMatch(password))
        {
            Debug.Log("hasMinimum8Chars dont Match");
        }

        var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
        return isValidated;
    }
    #endregion

    #region Ecnript Password
    private static string hash = "123987@!abc";
    public string Encrypte(string input)
    {
        byte[] data = UTF8Encoding.UTF8.GetBytes(input);
        using(MD5CryptoServiceProvider md5= new MD5CryptoServiceProvider())
        {
            byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() { Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform tr = trip.CreateEncryptor();
                byte[] results = tr.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(results, 0, results.Length);
            }
        }
    }

    #endregion


    #region Decrypt
    public  string Decrypt(string input)
    {
        byte[] data = Convert.FromBase64String(input);
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() { Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform tr = trip.CreateDecryptor();
                byte[] results = tr.TransformFinalBlock(data, 0, data.Length);
                return UTF8Encoding.UTF8.GetString(results);
            }
        }
    }

    #endregion

    #region EmailValid
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);
               
                return match.Groups[1].Value + domainName;

            }
            
            
        }
        catch (RegexMatchTimeoutException e)
        {
            Debug.Log(e);
            return false;
        }
        catch (ArgumentException e)
        {
            Debug.Log(e);
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    #endregion

    #endregion
}
