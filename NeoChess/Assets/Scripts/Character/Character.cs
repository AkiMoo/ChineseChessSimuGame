using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Chess/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public string pieceType;
    public int startHp;
    // public string skillName;
    // public int skillCooldown;
}
