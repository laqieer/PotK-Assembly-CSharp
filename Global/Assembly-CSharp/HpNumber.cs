// Decompiled with JetBrains decompiler
// Type: HpNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class HpNumber : BattleMonoBehaviour
{
  [SerializeField]
  protected GameObject base_root;
  [SerializeField]
  protected GameObject[] base_o;
  [SerializeField]
  protected GameObject[] base_t;
  [SerializeField]
  protected GameObject[] base_h;
  [SerializeField]
  protected GameObject damage_root;
  [SerializeField]
  protected GameObject[] damage_o;
  [SerializeField]
  protected GameObject[] damage_t;
  [SerializeField]
  protected GameObject[] damage_h;
  [SerializeField]
  protected GameObject heal_root;
  [SerializeField]
  protected GameObject[] heal_o;
  [SerializeField]
  protected GameObject[] heal_t;
  [SerializeField]
  protected GameObject[] heal_h;
  [SerializeField]
  protected Animator animator;
  private int startHp;
  private int targetHp;
  private float interval;

  public void setUnit(BL.Unit unit)
  {
    ((Component) this).gameObject.SetActive(false);
    this.base_root.SetActive(false);
    this.damage_root.SetActive(false);
    this.heal_root.SetActive(false);
  }

  public void StartAnime(int prev_hp, int new_hp)
  {
    ((Component) this).gameObject.SetActive(true);
    if (prev_hp != new_hp)
    {
      int num = prev_hp - new_hp;
      this.startHp = prev_hp;
      this.targetHp = new_hp;
      if (num > 0)
      {
        this.base_root.SetActive(true);
        this.damage_root.SetActive(true);
        this.SetNumber(prev_hp, this.base_o, this.base_t, this.base_h);
        this.SetNumber(Mathf.Abs(num), this.damage_o, this.damage_t, this.damage_h);
        this.animator.Play("Damage", -1, 0.0f);
      }
      else
      {
        if (num >= 0)
          return;
        this.base_root.SetActive(true);
        this.heal_root.SetActive(true);
        this.SetNumber(prev_hp, this.base_o, this.base_t, this.base_h);
        this.SetNumber(Mathf.Abs(num), this.heal_o, this.heal_t, this.heal_h);
        this.animator.Play("Heal", -1, 0.0f);
      }
    }
    else
    {
      this.base_root.SetActive(true);
      this.SetNumber(prev_hp, this.base_o, this.base_t, this.base_h);
      this.animator.Play("Stay", -1, 0.0f);
    }
  }

  public void EndAnime()
  {
    this.animator.StopPlayback();
    ((Component) this).gameObject.SetActive(false);
  }

  private void SetNumber(int _number, GameObject[] one, GameObject[] ten, GameObject[] hundred)
  {
    int num = Mathf.Clamp(_number, 0, 999);
    int index1 = num % 10;
    int index2 = num / 10 % 10;
    int index3 = num / 100 % 10;
    ((IEnumerable<GameObject>) one).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    ((IEnumerable<GameObject>) ten).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    ((IEnumerable<GameObject>) hundred).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    one[index1].SetActive(true);
    if (num >= 10)
      ten[index2].SetActive(true);
    if (num < 100)
      return;
    hundred[index3].SetActive(true);
  }

  public void StartCounter(float time)
  {
    int num = this.targetHp - this.startHp;
    this.interval = time / (float) Mathf.Abs(num);
    if (num > 0)
    {
      this.StartCoroutine(this.CountUp());
    }
    else
    {
      if (num >= 0)
        return;
      this.StartCoroutine(this.CountDown());
    }
  }

  [DebuggerHidden]
  private IEnumerator CountUp()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new HpNumber.\u003CCountUp\u003Ec__Iterator822()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CountDown()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new HpNumber.\u003CCountDown\u003Ec__Iterator823()
    {
      \u003C\u003Ef__this = this
    };
  }
}
