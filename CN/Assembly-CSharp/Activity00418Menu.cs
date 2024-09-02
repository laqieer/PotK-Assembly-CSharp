// Decompiled with JetBrains decompiler
// Type: Activity00418Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Activity00418Menu.\u003CDetailPopup\u003Ec__Iterator297()
    {
      \u003C\u003Ef__this = this
    };
  }
}
