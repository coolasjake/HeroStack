using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public Image image;

    [HideInInspector]
    public UnitScriptable data;
    private AbilityHolder _abilityHolder;

    private int _health = 1;
    private bool _isDead = false;

    public void Initialize(AbilityHolder abilityHolder)
    {
        _abilityHolder = abilityHolder;
        _abilityHolder.gameObject.SetActive(false);
        image.sprite = data.image;
    }

    public void ToggleAbilityHolder()
    {
        if (_abilityHolder.gameObject.activeInHierarchy == true)
            _abilityHolder.gameObject.SetActive(false);
        else
            _abilityHolder.gameObject.SetActive(true);
    }

    public void AttackTarget(Unit target, int damage)
    {
        //Do attack animations (could use same system as effects?)
        BeforeAttackEffects(target);

        target.TakeDamageFrom(this, damage);
    }

    public void TakeDamageFrom(Unit attacker, int damage)
    {
        //Do hit/damage animation
        _health -= damage;
        AfterHitEffects(attacker);

        if (_health <= 0)
            GetKilledBy(attacker);
    }

    public void GetKilledBy(Unit killer)
    {
        //Do death animation
        AfterDeathEffects(killer);


    }

    //Effect Triggers:
    private void AfterHitEffects(Unit attacker)
    {

    }

    public delegate void HitEffect(Unit attacker, int damage);
    [HideInInspector]
    public List<HitEffect> hitEffects = new List<HitEffect>();

    private void AfterDeathEffects(Unit attacker)
    {

    }

    public delegate void DeathEffect(Unit attacker);
    [HideInInspector]
    public List<DeathEffect> deathEffects = new List<DeathEffect>();

    private void BeforeAttackEffects(Unit target)
    {

    }

    public delegate void AttackEffect(Unit target);
    [HideInInspector]
    public List<AttackEffect> attackEffects = new List<AttackEffect>();
}
