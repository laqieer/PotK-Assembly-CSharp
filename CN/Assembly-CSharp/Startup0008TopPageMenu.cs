// Decompiled with JetBrains decompiler
// Type: Startup0008TopPageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Startup0008TopPageMenu.\u003CScrollValue\u003Ec__Iterator189()
    {
      \u003C\u003Ef__this = this
    };
  }
}
