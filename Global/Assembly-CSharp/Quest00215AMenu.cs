// Decompiled with JetBrains decompiler
// Type: Quest00215AMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00215AMenu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtAp;
  [SerializeField]
  protected UILabel TxtEpisode;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected UILabel TxtVictory;
  public GameObject StageName;
  public UISprite slc_New;
  public UISprite slc_Clear;
  public UI2DSprite dyn_Character;

  public virtual void IbtnBack() => this.backScene();

  public virtual void IbtnEpisodeback() => this.backScene();

  public virtual void IbtnDecide()
  {
  }

  private void SetEpisode(int episode)
  {
    this.StageName.transform.GetChildren().ForEach<Transform>((Action<Transform>) (t =>
    {
      string name = ((Object) ((Component) t).gameObject).name;
      int num = int.Parse(name.Substring(name.Length - 2));
      ((Component) t).gameObject.SetActive(num == episode);
    }));
  }

  private void SetState(Quest00215AMenu.State state)
  {
    ((Component) this.slc_New).gameObject.SetActive(state == Quest00215AMenu.State.NEW);
    ((Component) this.slc_Clear).gameObject.SetActive(state == Quest00215AMenu.State.CLEAR);
  }

  [DebuggerHidden]
  public IEnumerator SetCharacter(int episode, UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00215AMenu.\u003CSetCharacter\u003Ec__Iterator1A0()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public enum State
  {
    NORMAL,
    CLEAR,
    NEW,
  }
}
