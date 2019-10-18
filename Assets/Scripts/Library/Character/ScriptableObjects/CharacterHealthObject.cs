using Library.Base;
using UnityEngine;

[CreateAssetMenu(menuName = "Character / HealthObject")]
public class CharacterHealthObject : BaseScriptableObject
{
    public int currentHealth;
    public int maxHealth;
}
