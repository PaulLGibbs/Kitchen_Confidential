using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Character Properties")]
    public int maxHP = 1;

    protected int hp = 1;

    public abstract void OnReceiveDamage(Character source, int damage);

    public abstract void OnDealDamage(Character target, int damage);

    public abstract void OnDeath(Character enemy, int damage);

    public void Damage(Character source, int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDeath(source, damage);
        }
        else
        {
            OnReceiveDamage(source, damage);
        }
    }

}
