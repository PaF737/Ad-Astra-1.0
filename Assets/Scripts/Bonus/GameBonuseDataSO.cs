using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(menuName ="Game bonuses")]
public class GameBonuseDataSO :ScriptableObject
{
    public List<BaseBonus> Bonuses = new List<BaseBonus>();
}
