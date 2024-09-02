// Decompiled with JetBrains decompiler
// Type: Startup0008TopPageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup0008TopPageMenu : MonoBehaviour
{
  [SerializeField]
  private UITextList agreementTextList;
  [SerializeField]
  private UILabel agreementTitle;

  public void Initialize(string title, string hedder, string text)
  {
    this.agreementTitle.SetText(title);
    this.agreementTextList.Clear();
    this.agreementTextList.Add(hedder);
    this.agreementTextList.Add(text);
  }

  [DebuggerHidden]
  public IEnumerator ScrollValue()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup0008TopPageMenu.\u003CScrollValue\u003Ec__Iterator1B5()
    {
      \u003C\u003Ef__this = this
    };
  }
}
