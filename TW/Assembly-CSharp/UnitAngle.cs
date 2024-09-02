// Decompiled with JetBrains decompiler
// Type: UnitAngle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UnitAngle : BattleMonoBehaviour
{
  private Quaternion q;
  private Quaternion saveRot = Quaternion.identity;
  private Transform _parent;
  private Transform _transform;

  private void Awake()
  {
    this._transform = ((Component) this).transform;
    this._parent = this._transform.parent;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitAngle.\u003CStart_Battle\u003Ec__IteratorA6E()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnEnable() => this.calcAngle();

  private void calcAngle()
  {
    this._transform.localRotation = Quaternion.op_Multiply(Quaternion.op_Multiply(Quaternion.Inverse(this._parent.rotation), this.q), this._parent.rotation);
    this.saveRot = this._parent.rotation;
  }

  protected override void LateUpdate_Battle()
  {
    if (!Quaternion.op_Inequality(this.saveRot, this._parent.rotation))
      return;
    this.calcAngle();
  }
}
