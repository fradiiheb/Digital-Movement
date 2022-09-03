using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Pant")]
public class Pants : Item
{
    public override void Use()
    {
        Debug.Log("this is a Character " + name);

    }
}
