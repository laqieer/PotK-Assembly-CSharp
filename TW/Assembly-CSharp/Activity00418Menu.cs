// Decompiled with JetBrains decompiler
// Type: Activity00418Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Activity00418Menu : MonoBehaviour
{
  private int reward_type;
  private int reward_param;

  public int Reward_Type
  {
    get => this.reward_type;
    set => this.reward_type = value;
  }

  public int Reward_Param
  {
    get => this.reward_param;
    set => this.reward_param = value;
  }

  public void onClick() => this.StartCoroutine(this.DetailPopup());

  [DebuggerHidden]
  private IEnumerator DetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Activity00418Menu.\u003CDetailPopup\u003Ec__Iterator2D2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
