// Decompiled with JetBrains decompiler
// Type: Quest00215Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00215Menu : NGMenuBase
{
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private UI2DSprite DynCharacter;
  [SerializeField]
  protected UILabel TxtAp;
  [SerializeField]
  protected UILabel TxtEpisodetitle;
  [SerializeField]
  protected UILabel TxtTitle;

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnBack()
  {
    Debug.Log((object) "click default event IbtnBack");
    this.backScene();
  }

  public virtual void IbtnEpisode() => Debug.Log((object) "click default event IbtnEpisode");

  public virtual void IbtnEpisodeBlock()
  {
    Debug.Log((object) "click default event IbtnEpisodeBlock");
  }

  public virtual void IbtnFriendly()
  {
    Debug.Log((object) "click default event IbtnFriendly");
    UnitUnit unitUnit = MasterData.UnitUnit[new List<int>((IEnumerable<int>) MasterData.UnitUnit.Keys)[0]];
    Singleton<NGSceneManager>.GetInstance().changeScene("unit004_2_2", true, (object) unitUnit);
  }

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  public void ScrollContainerResolvePosition() => this.ScrollContainer.ResolvePosition();

  [DebuggerHidden]
  private IEnumerator SetCharacterLargeImage(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator1D3()
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
    return (IEnumerator) new Quest00215Menu.\u003CCreateEpisodes\u003Ec__Iterator1D4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215Menu.\u003CInit\u003Ec__Iterator1D5()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }
}
