// Decompiled with JetBrains decompiler
// Type: GuildTItleScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildTItleScroll : MonoBehaviour
{
  [SerializeField]
  private GameObject objNew;
  [SerializeField]
  private UI2DSprite scrImg;
  [SerializeField]
  private GameObject objUnKnown;
  private int id;
  private int rarity;
  private string description;
  private bool hasEmblem;
  private bool isCur;
  private DateTime? time;
  private System.Action act;
  private Guild0284Menu _baseMenu;

  public int ID => this.id;

  public int Rarity => this.rarity;

  public DateTime? Time => this.time;

  [DebuggerHidden]
  public IEnumerator Init(
    bool hasEmblem,
    int id,
    int rarity,
    string description,
    bool isCur,
    bool isNew,
    DateTime? time,
    System.Action act,
    Guild0284Menu baseMenu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildTItleScroll.\u003CInit\u003Ec__Iterator6EC()
    {
      id = id,
      rarity = rarity,
      description = description,
      isCur = isCur,
      time = time,
      hasEmblem = hasEmblem,
      act = act,
      baseMenu = baseMenu,
      isNew = isNew,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Erarity = rarity,
      \u003C\u0024\u003Edescription = description,
      \u003C\u0024\u003EisCur = isCur,
      \u003C\u0024\u003Etime = time,
      \u003C\u0024\u003EhasEmblem = hasEmblem,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003EbaseMenu = baseMenu,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u003Ef__this = this
    };
  }

  public void TapTitle()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    this.StartCoroutine(this.OpenTitleSetPopup());
  }

  [DebuggerHidden]
  private IEnumerator OpenTitleSetPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildTItleScroll.\u003COpenTitleSetPopup\u003Ec__Iterator6ED()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildTItleScroll.\u003CCreateSprite\u003Ec__Iterator6EE()
    {
      \u003C\u003Ef__this = this
    };
  }
}
