using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class AddressManager : MonoBehaviour
{
    public List<Gouvernorat> gouvernorats;
    public Dropdown dropdowngouvernorat;
    public Dropdown dropdowncommune;
    public Dropdown dropdownSchool;

    private void Start()
    {
        /*foreach(Gouvernorat gouv in gouvernorats)
        {

            gouv.school = gouv.school.OrderBy(s => s).ToList();
        }*/
       // gouvernorats = gouvernorats.OrderBy(s => s.Libelle_gouvernorat_Fr).ToList();
        //create event listener for dropdownwhen value cahnge
        dropdowngouvernorat.onValueChanged.AddListener(delegate {
            gouvernoratValueChange(dropdowngouvernorat);
        });
        //call function to fill dropdowngouvernorat options 
        dropdowngouvernoratfunc();
    }

    public void dropdowngouvernoratfunc()
    {
        //clear the list
        dropdowngouvernorat.options.Clear();
        //fill it with libelle
        foreach (Gouvernorat gouvernorat in gouvernorats)
        {
            dropdowngouvernorat.options.Add(new Dropdown.OptionData(gouvernorat.Libelle_gouvernorat_Fr));
        }
        //refresh
        dropdowngouvernorat.RefreshShownValue();
        dropdownSchool.RefreshShownValue();
        //call the onvaluechange
        gouvernoratValueChange(dropdowngouvernorat);
    }

    void gouvernoratValueChange(Dropdown change)
    {
        //Debug.Log(change.value);
       //   Debug.Log(change.options[change.value].text);
       //reset dropdownCmmune to the first option each time we change a gouvernart
        dropdowncommune.value = 0;
        dropdownSchool.value = 0;

        //call function dropdowncommunefunc with the current gouvernorat value text
        dropdowncommunefunc(change.options[change.value].text);
        dropdownSchoolfunc(change.options[change.value].text);
    }


    void dropdownSchoolfunc(string gouvernorat)
    {
        dropdownSchool.options.Clear();
        int index = gouvernorats.FindIndex(i => i.Libelle_gouvernorat_Fr == gouvernorat);
        foreach(string schoolname in gouvernorats[index].school)
        {
            dropdownSchool.options.Add(new Dropdown.OptionData(schoolname));
        }
        dropdownSchool.RefreshShownValue();
    }
    public void dropdowncommunefunc(string gouvernorat)
    {
      //clear
        dropdowncommune.options.Clear();
        //find the index in the list gouvernorats where the libble are equal the one passed in parm
        int index = gouvernorats.FindIndex(i => i.Libelle_gouvernorat_Fr == gouvernorat);
        //fill the option for dropdowncommune
        foreach (Commune commune in gouvernorats[index].communes)
        {
            dropdowncommune.options.Add(new Dropdown.OptionData(commune.Libelle_commune_fr));
        }
        //refresh
        dropdowncommune.RefreshShownValue();
    }
}
