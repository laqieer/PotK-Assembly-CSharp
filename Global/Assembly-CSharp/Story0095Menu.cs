// Decompiled with JetBrains decompiler
// Type: Story0095Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0095Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  public virtual void Foreground()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator InitScene(bool connect)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0095Menu.\u003CInitScene\u003Ec__Iterator483()
    {
      connect = connect,
      \u003C\u0024\u003Econnect = connect,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitCharacterQuestButton(PlayerUnit[] characterQuests)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0095Menu.\u003CInitCharacterQuestButton\u003Ec__Iterator484()
    {
      characterQuests = characterQuests,
      \u003C\u0024\u003EcharacterQuests = characterQuests,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitCharacterQuestButton(PlayerCharacterQuestS[] characterQuests)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0095Menu.\u003CInitCharacterQuestButton\u003Ec__Iterator485()
    {
      characterQuests = characterQuests,
      \u003C\u0024\u003EcharacterQuests = characterQuests,
      \u003C\u003Ef__this = this
    };
  }

  private void Select(UnitIconBase unitIcon)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_6", true, (object) unitIcon.Unit.ID);
  }
}
