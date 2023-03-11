using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject, INameable
{
    [SerializeField] string _name;
    public string Name => _name;
}
