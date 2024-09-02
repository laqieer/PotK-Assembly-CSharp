// Decompiled with JetBrains decompiler
// Type: Shop00742Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00742Menu : MonoBehaviour
{
  [DebuggerHidden]
  public IEnumerator Init(MasterDataTable.CommonRewardType type, PlayerShopArticle article)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Menu.\u003CInit\u003Ec__Iterator3FB()
    {
      article = article,
      type = type,
      \u003C\u0024\u003Earticle = article,
      \u003C\u0024\u003Etype = type,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(ShopContent content)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Menu.\u003CInit\u003Ec__Iterator3FC()
    {
      content = content,
      \u003C\u0024\u003Econtent = content,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(EarthShopContent content)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Menu.\u003CInit\u003Ec__Iterator3FD()
    {
      content = content,
      \u003C\u0024\u003Econtent = content,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(MasterDataTable.CommonRewardType type, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Menu.\u003CInit\u003Ec__Iterator3FE()
    {
      type = type,
      id = id,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator Init(MasterDataTable.CommonRewardType type, int id, System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00742Menu.\u003CInit\u003Ec__Iterator3FF()
    {
      act = act,
      type = type,
      id = id,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
