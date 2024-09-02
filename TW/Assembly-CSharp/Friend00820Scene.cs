// Decompiled with JetBrains decompiler
// Type: Friend00820Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Friend00820Scene : NGSceneBase
{
  [SerializeField]
  private Friend00820Menu menu;
  [SerializeField]
  private GameObject smsButton;
  [SerializeField]
  private GameObject lineButton;

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Friend00820Scene.\u003ConStartSceneAsync\u003Ec__Iterator525()
    {
      \u003C\u003Ef__this = this
    };
  }
}
