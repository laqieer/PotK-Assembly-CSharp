// Decompiled with JetBrains decompiler
// Type: SwitchUnitComponentAnimator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class SwitchUnitComponentAnimator : SwitchUnitComponentBase
{
  [SerializeField]
  private RuntimeAnimatorController[] bottomBaseController;
  private Animator animator;

  protected override void Init()
  {
    if ((bool) (Object) this.animator || !((Object) this.gameObject.GetComponent<Animator>() != (Object) null))
      return;
    this.materialType = SwitchUnitComponentBase.MATERIALTYPE.Effect;
    this.animator = this.gameObject.GetComponent<Animator>();
  }

  public override void SwitchMaterial(int UnitID)
  {
    base.SwitchMaterial(UnitID);
    if (this.currUnitType == SwitchUnitComponentBase.UnitType.DefaultUnit)
    {
      if (!(bool) (Object) this.bottomBaseController[0])
        return;
      this.animator.runtimeAnimatorController = this.bottomBaseController[0];
    }
    else
    {
      if (!(bool) (Object) this.bottomBaseController[1])
        return;
      this.animator.runtimeAnimatorController = this.bottomBaseController[1];
    }
  }

  private IEnumerator GetAnimator(string path)
  {
    Future<RuntimeAnimatorController> unit_runtime_ = Singleton<ResourceManager>.GetInstance().Load<RuntimeAnimatorController>(path);
    IEnumerator e = unit_runtime_.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.animator.runtimeAnimatorController = unit_runtime_.Result;
  }
}
