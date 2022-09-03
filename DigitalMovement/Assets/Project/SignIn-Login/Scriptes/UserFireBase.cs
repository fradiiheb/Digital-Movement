using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using System;

public class UserFireBase : MonoBehaviour
{
    public int id, TotalGold;
    public string Nom, Prenom, Telephone, Email, Gouvernorat, Ville, school, Niveau, photoName,password;
    public string EmailPart1, EmailPart2;
    public User user;
    public bool endRetrive,foundUser;

    //private const string projectId = "unityproject-d9e96";
    private static readonly string databaseURL =
        "https://digimove-99274-default-rtdb.firebaseio.com/";

    public delegate void RetrieveUserCallback();

    #region ButtonHandler
    public void OnSubmit()
    {

        PostToDatabase();
    }

    public void OnGetEmail()
    {
        RetrieveFromDatabase(() => { });
    }

    public void OnUpdateUser()
    {
        UpdateUserDatabase();
    }

    public void OnDeleteUser()
    {
        DeleteUserDatabase();
    }

    public void GetAllUsers()
    {
        GetUsers();
    }

    

    #endregion

    #region Logic
    private void PostToDatabase()
    {
        Debug.Log("First called");
        RestClient.Get<User>($"{databaseURL}users/{EmailPart1+ EmailPart2}.json").Then(response =>
        {
            user = response;
            if (user != null)
            {
                EditorUtility.DisplayDialog("Error", "there is a user with this Email!", "Ok");
                return;
            }
            Debug.Log("called0");

        }).Catch(res =>
        {
            Debug.Log("called 1");
            user = new User(id, Nom, Prenom, Niveau, Telephone, Email, Gouvernorat, Ville, school, photoName, password, TotalGold);
            Debug.Log("called 2");
            RestClient.Put<User>($"{databaseURL}users/{EmailPart1+ EmailPart2}.json", user).Then(response => {
                EditorUtility.DisplayDialog("Status",
                    "The user was successfully uploaded to the database!", "Ok");
                Debug.Log("The user was successfully uploaded to the database");
            });

        });


        //PostUserCallback callback = null;

    }
    //getUser
    private void RetrieveFromDatabase(RetrieveUserCallback callback)
    {
        user = null;

        foundUser = false;
        
        
        RestClient.Get<User>($"{databaseURL}users/{EmailPart1+ EmailPart2}.json").Then(response => {
            user = response;
            Nom = user.getNom().ToString();
            Prenom= user.getPrenom().ToString();
            Telephone= user.getTelephone().ToString();
            Email= user.getEmail().ToString();
            Gouvernorat= user.getGouvernorat().ToString();
            Ville= user.getVille().ToString();
            school= user.getSchool().ToString();
            Niveau= user.getNiveau().ToString();
            photoName= user.getPhoto().ToString();
            password = user.getPassword().ToString();
            TotalGold = user.getTotalGold();
            endRetrive = true;
            foundUser = true;
            // callback();
        }).Catch(err => {
            
            Debug.Log("there is not a user with this mail!");
            endRetrive = true;
            foundUser = false;
            //EditorUtility.DisplayDialog("Error", err.Message, "Ok");

        });
       


    }
    private void UpdateUserDatabase()
    {

        RetrieveFromDatabase(() => {
            user.setIndex(id);
            user.setNom(Nom);
            user.setPrenom(Prenom);
            user.setTelephone(Telephone);
            user.setEmail(Email);
            user.setGouvernorat(Gouvernorat);
            user.setVille(Ville);
            user.setSchool(school);
            user.setNiveau(Niveau);
            user.setPhoto(photoName);
            user.setPassword(password);
            TotalGold = user.getTotalGold();

            RestClient.Put<User>($"{databaseURL}users/{EmailPart1+ EmailPart2}.json", user).Then(response => {
                EditorUtility.DisplayDialog("Status",
                    "The user was successfully updated!", "Ok");
                Debug.Log("The user was successfully updated");
            });

        });

    }
    private void DeleteUserDatabase()
    {
        RetrieveFromDatabase(() => {
            RestClient.Delete($"{databaseURL}users/{EmailPart1+ EmailPart2}.json").Then(response => {
                EditorUtility.DisplayDialog("Status",
                    "The user was successfully deleted!", "Ok");
                Debug.Log("The user was successfully deleted");

            });
        });


    }

    public static void GetUsers()
    {

        RestClient.Get($"{databaseURL}users.json").Then(allUsers =>
        {
            EditorUtility.DisplayDialog("JSON Array", allUsers.Text, "Ok");
        });
    }

    #endregion
}
