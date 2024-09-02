// Decompiled with JetBrains decompiler
// Type: Story00911Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new Story00911Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator553()
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
    return (IEnumerator) new Story00911Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator554()
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
    return (IEnumerator) new Story00911Menu.\u003CCreateEpisodes\u003Ec__Iterator555()
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
    return (IEnumerator) new Story00911Menu.\u003CInit\u003Ec__Iterator556()
    {
      id = id,
      id2 = id2,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u003Ef__this = this
    };
  }
}
