// Decompiled with JetBrains decompiler
// Type: Story00912Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story00912Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private GameObject DynCharacter;
  [SerializeField]
  private GameObject DynCharacter2;
  [SerializeField]
  private GameObject DynCharacter3;
  public Texture2D mask_right;
  public Texture2D mask_left;

  public override void onBackButton() => this.IbtnBack();

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_10");
  }

  public void ScrollContainerResolvePosition() => this.ScrollContainer.ResolvePosition();

  [DebuggerHidden]
  private IEnumerator LoadCharacterSprite(
    int id,
    GameObject locationObject,
    Texture2D maskTexture,
    int position_x,
    int position_y,
    float sprite_scale)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Menu.\u003CLoadCharacterSprite\u003Ec__Iterator509()
    {
      locationObject = locationObject,
      id = id,
      maskTexture = maskTexture,
      position_x = position_x,
      position_y = position_y,
      sprite_scale = sprite_scale,
      \u003C\u0024\u003ElocationObject = locationObject,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EmaskTexture = maskTexture,
      \u003C\u0024\u003Eposition_x = position_x,
      \u003C\u0024\u003Eposition_y = position_y,
      \u003C\u0024\u003Esprite_scale = sprite_scale
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadMask()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Menu.\u003CLoadMask\u003Ec__Iterator50A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterLargeImage(int id, int id2, int id3, QuestHarmonyS questS)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Menu.\u003CSetCharacterLargeImage\u003Ec__Iterator50B()
    {
      id = id,
      questS = questS,
      id2 = id2,
      id3 = id3,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EquestS = questS,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u0024\u003Eid3 = id3,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateEpisodes(int id1, int id2, int id3)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Menu.\u003CCreateEpisodes\u003Ec__Iterator50C()
    {
      id1 = id1,
      id2 = id2,
      id3 = id3,
      \u003C\u0024\u003Eid1 = id1,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u0024\u003Eid3 = id3,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(int id, int id2, int id3, int questSId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00912Menu.\u003CInit\u003Ec__Iterator50D()
    {
      id = id,
      id2 = id2,
      id3 = id3,
      questSId = questSId,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eid2 = id2,
      \u003C\u0024\u003Eid3 = id3,
      \u003C\u0024\u003EquestSId = questSId,
      \u003C\u003Ef__this = this
    };
  }
}
