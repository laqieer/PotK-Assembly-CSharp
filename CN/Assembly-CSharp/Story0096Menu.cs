// Decompiled with JetBrains decompiler
// Type: Story0096Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0096Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private UI2DSprite DynCharacter;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnEpisode()
  {
  }

  public virtual void IbtnEpisodeBlock()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_5", false, (object) false);
  }

  public void ScrollContainerResolvePosition() => this.ScrollContainer.ResolvePosition();

  [DebuggerHidden]
  private IEnumerator SetCharacterLargeImage(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0096Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator52C()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateEpisodes(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0096Menu.\u003CCreateEpisodes\u003Ec__Iterator52D()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0096Menu.\u003CInit\u003Ec__Iterator52E()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
