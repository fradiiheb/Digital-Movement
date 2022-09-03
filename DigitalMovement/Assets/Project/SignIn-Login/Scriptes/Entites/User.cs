using System.Collections.Generic;
[System.Serializable]
public class User
{
    public int index;
    public string Nom;
    public string Prenom;
    public string Niveau;
    public string Telephone;
    public string Email;
    public string Gouvernorat;
    public string Ville;
    public string School;
    public string Photo;
	public string Password;
	public int TotalGold;

    public User(int index, string nom, string prenom, string niveau, string telephone, string email, string gouvernorat, string ville, string school, string photo,string password,int totalGold)
    {
        this.index = index;
        Nom = nom;
        Prenom = prenom;
        Niveau = niveau;
        Telephone = telephone;
        Email = email;
        Gouvernorat = gouvernorat;
        Ville = ville;
        Photo = photo;
        School = school;
		Password = password;
		TotalGold = totalGold;
	}

	public int getTotalGold()
	{
		return this.TotalGold;
	}

	public void setTotalGold(int totalGold)
	{
		this.TotalGold = totalGold;
	}
	public string getPassword()
	{
		return this.Password;
	}

	public void setPassword(string Password)
	{
		this.Password = Password;
	}
	public int getIndex()
	{
		return this.index;
	}

	public void setIndex(int index)
	{
		this.index = index;
	}

	public string getNom()
	{
		return this.Nom;
	}

	public void setNom(string Nom)
	{
		this.Nom = Nom;
	}

	public string getPrenom()
	{
		return this.Prenom;
	}

	public void setPrenom(string Prenom)
	{
		this.Prenom = Prenom;
	}

	public string getNiveau()
	{
		return this.Niveau;
	}

	public void setNiveau(string Niveau)
	{
		this.Niveau = Niveau;
	}

	public string getTelephone()
	{
		return this.Telephone;
	}

	public void setTelephone(string Telephone)
	{
		this.Telephone = Telephone;
	}

	public string getEmail()
	{
		return this.Email;
	}

	public void setEmail(string Email)
	{
		this.Email = Email;
	}

	public string getGouvernorat()
	{
		return this.Gouvernorat;
	}

	public void setGouvernorat(string Gouvernorat)
	{
		this.Gouvernorat = Gouvernorat;
	}

	public string getVille()
	{
		return this.Ville;
	}

	public void setVille(string Ville)
	{
		this.Ville = Ville;
	}

	public string getSchool()
	{
		return this.School;
	}

	public void setSchool(string School)
	{
		this.School = School;
	}

	public string getPhoto()
	{
		return this.Photo;
	}

	public void setPhoto(string Photo)
	{
		this.Photo = Photo;
	}

}
