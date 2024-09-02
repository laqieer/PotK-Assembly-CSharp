// Decompiled with JetBrains decompiler
// Type: StoryEffectControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class StoryEffectControl : MonoBehaviour
{
  private GameObject prefab_;
  private int id_;
  private StoryEffectBase effect_;
  private bool isStart_;
  private bool isSkip_;
  private bool isChange_;
  private int noPattern_;
  private int noColor_;

  [DebuggerHidden]
  private IEnumerator coInitializeLocal(int id, string namePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryEffectControl.\u003CcoInitializeLocal\u003Ec__Iterator566()
    {
      id = id,
      namePrefab = namePrefab,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EnamePrefab = namePrefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coInitializeEmotion(int id, int noColor)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryEffectControl.\u003CcoInitializeEmotion\u003Ec__Iterator567()
    {
      id = id,
      noColor = noColor,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EnoColor = noColor,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coInitializeEnvironment(int id, int noColor)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryEffectControl.\u003CcoInitializeEnvironment\u003Ec__Iterator568()
    {
      id = id,
      noColor = noColor,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EnoColor = noColor,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator coInitializeEffect(int id, int noColor)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new StoryEffectControl.\u003CcoInitializeEffect\u003Ec__Iterator569()
    {
      id = id,
      noColor = noColor,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003EnoColor = noColor,
      \u003C\u003Ef__this = this
    };
  }

  public void startEffect() => this.isStart_ = true;

  public void skipEffect() => this.isSkip_ = true;

  public void changeEffect(int noPattern, int noColor)
  {
    this.isChange_ = true;
    this.noPattern_ = noPattern;
    this.noColor_ = noColor;
  }

  private void Update()
  {
    if (!Object.op_Inequality((Object) this.effect_, (Object) null))
      return;
    if (this.isChange_)
    {
      this.isChange_ = false;
      StoryEffectMulti effect = this.effect_ as StoryEffectMulti;
      if (Object.op_Inequality((Object) effect, (Object) null))
        effect.setPattern(this.noPattern_, this.noColor_);
    }
    if (this.isStart_)
    {
      this.isStart_ = false;
      this.effect_.startEffect();
    }
    if (!this.isSkip_)
      return;
    this.isSkip_ = false;
    this.effect_.skipEffect();
  }
}
