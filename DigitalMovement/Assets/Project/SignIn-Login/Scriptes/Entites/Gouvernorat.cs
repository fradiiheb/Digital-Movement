using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gouvernorat
{
    public int id_gouvernorat;
    public string Libelle_gouvernorat;
    public string Libelle_gouvernorat_Fr;
    public List<string> school = new List<string> { };
    public List<Commune> communes = new List<Commune> { };

}