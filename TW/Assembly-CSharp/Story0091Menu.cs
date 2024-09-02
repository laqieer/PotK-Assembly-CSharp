// Decompiled with JetBrains decompiler
// Type: Story0091Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Story0091Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private NGxScroll ScrollContainer;

  protected virtual void Foreground()
  {
  }

  protected virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  protected virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  [DebuggerHidden]
  public IEnumerator InitPartButton(PlayerStoryQuestS[] quests)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story0091Menu.\u003CInitPartButton\u003Ec__Iterator54C()
    {
      quests = quests,
      \u003C\u0024\u003Equests = quests,
      \u003C\u003Ef__this = this
    };
  }
}
