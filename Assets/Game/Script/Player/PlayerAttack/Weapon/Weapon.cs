using UnityEngine;

public class Weapon : ScriptableObject
{
    [SerializeField] float size;
    [SerializeField] float damage;

    public float GetDamage() {  return damage; }
}
