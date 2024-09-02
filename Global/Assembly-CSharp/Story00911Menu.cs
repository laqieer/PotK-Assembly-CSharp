// Decompiled with JetBrains decompiler
// Type: Story00911Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00911Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private UI2DSprite DynCharacter;
  [SerializeField]
  private UI2DSprite DynCharacter2;

  public override void onBackButton() => this.IbtnBack();

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_10");
  }

  public void ScrollContainerResolvePosition() => this.ScrollContainer.ResolvePosition();

  [DebuggerHidden]
  private IEnumerator SetCharacterLargeImage(int id, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator460()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterLargeImage(Transform trans, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator461()
    {
      trans = trans,
      id = id,
      \u003C\u0024\u003Etrans = trans,
      \u003C\u0024\u003Eid = id
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateEpisodes(int id, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Menu.\u003CCreateEpisodes\u003Ec__Iterator462()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(int id, int id2)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00911Menu.\u003CInit\u003Ec__Iterator463()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }
}
