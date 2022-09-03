using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Hat")]
public class Hats : Item
{
    public override void Use()
    {
        Debug.Log("this is a Character " + name);
      
    }
}
