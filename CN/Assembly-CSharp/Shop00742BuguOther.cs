// Decompiled with JetBrains decompiler
// Type: Shop00742BuguOther
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742BuguOther : Shop00742Bugu
{
  [SerializeField]
  protected UILabel TxtFlavor;

  [DebuggerHidden]
  public IEnumerator Initialize(GearGear target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742BuguOther.\u003CInitialize\u003Ec__Iterator48F()
    {
      target = target,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  protected override IEnumerator BuguSpriteCreate(Future<Sprite> spriteF)
  {
    return base.BuguSpriteCreate(spriteF);
  }

  protected override IEnumerator RarityCreate(GearGear target) => base.RarityCreate(target);
}
