// Decompiled with JetBrains decompiler
// Type: Startup00010Enemy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00010Enemy : MonoBehaviour
{
  public int life_point = 1;
  public int toughness_point = 1;
  public int now_life_point = 1;
  public int now_toughness_point = 1;
  public bool death;
  public bool target;
  public bool target_move;
  public bool wait_move;
  public Startup00010MiniGame main;
  public GameObject gomi_bako;
  public Animator animator;
  public TweenColor tween_color;
  public Transform loc_effect;
  public Transform shadow_;
  public Transform shadowParent_;

  private void Update()
  {
    if (Object.op_Inequality((Object) this.shadow_, (Object) null))
    {
      this.shadow_.eulerAngles = new Vector3(90f, 0.0f, 0.0f);
      this.shadow_.position = Vector3.op_Addition(this.shadowParent_.position, new Vector3(0.0f, 20f, 0.0f));
    }
    if (this.death)
      return;
    ((Component) this).transform.LookAt(((Component) this.main.player).transform);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.main.player.attackFlag || ((Object) other).name != "Weapon" || this.now_life_point <= 0)
      return;
    this.main.player.attackFlag = false;
    this.main.player.state = 0;
    this.TweenFunc((Action<TweenColor>) (x => x.ResetToBeginning()));
    this.TweenFunc((Action<TweenColor>) (x => x.PlayForward()));
    --this.now_life_point;
    --this.now_toughness_point;
    GameObject gameObject = this.main.SetDamageEffect();
    gameObject.transform.position = this.loc_effect.position;
    this.StartCoroutine(this.Effect(gameObject));
    if (this.now_toughness_point < 0)
    {
      this.animator.SetTrigger("isDamage");
      this.now_toughness_point = this.toughness_point;
    }
    else
    {
      if (this.now_life_point > 0)
        return;
      if (((Object) this).name == "Boss")
        this.main.BossLost();
      ((Component) this).transform.parent = this.gomi_bako.transform;
      this.Blow();
      this.StartCoroutine(this.Death());
    }
  }

  public void Blow()
  {
    iTween.Stop(((Component) this).gameObject);
    Rigidbody component = ((Component) ((Component) this).transform).GetComponent<Rigidbody>();
    component.constraints = (RigidbodyConstraints) 0;
    float num1 = Random.Range(-5f, 5f) * 3f;
    float num2 = Random.Range(5f, 10f) * 2f;
    float num3 = Random.Range(-2.5f, 2.5f) * 10f;
    component.velocity = new Vector3(num1, num2, num3);
  }

  public bool WaitCheck() => !this.target_move && !this.wait_move && !this.target && !this.death;

  public void TargetMoveEnd() => this.target_move = false;

  public void WaitMoveEnd() => this.wait_move = false;

  public void TweenFunc(Action<TweenColor> callback)
  {
    if (!Object.op_Inequality((Object) this.tween_color, (Object) null))
      return;
    callback(this.tween_color);
  }

  public void Init()
  {
    this.now_toughness_point = this.toughness_point;
    this.now_life_point = this.life_point;
    ((Component) this).GetComponent<Rigidbody>().constraints = (RigidbodyConstraints) 126;
    ((Component) this).transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
    ((Component) this).GetComponent<Rigidbody>().velocity = Vector3.zero;
    this.death = false;
    this.target_move = false;
    this.wait_move = false;
    this.target = false;
  }

  [DebuggerHidden]
  private IEnumerator Death()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010Enemy.\u003CDeath\u003Ec__Iterator18B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator Effect(GameObject obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010Enemy.\u003CEffect\u003Ec__Iterator18C()
    {
      obj = obj,
      \u003C\u0024\u003Eobj = obj
    };
  }

  public void SecretSet()
  {
    float num1 = 100f;
    float num2 = 0.0f;
    if (StartupDownLoad.progress != null)
    {
      num1 = (float) StartupDownLoad.progress.Denominator;
      num2 = (float) StartupDownLoad.progress.Numerator;
    }
    float num3 = this.main.time / num2;
    int num4 = (int) ((double) ((float) this.main.score / this.main.time) * (double) ((float) ((double) num1 - (double) num2 - 10.0) * num3)) - (this.life_point + 77);
    if (num4 < this.life_point)
      num4 = this.life_point;
    if (num4 > 200)
      num4 = 200;
    this.now_life_point = num4;
    this.main.secretMonster = false;
  }
}
