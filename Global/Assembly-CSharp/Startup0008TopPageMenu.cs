// Decompiled with JetBrains decompiler
// Type: Startup0008TopPageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Startup0008TopPageMenu.\u003CScrollValue\u003Ec__Iterator147()
    {
      \u003C\u003Ef__this = this
    };
  }
}
