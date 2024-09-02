// Decompiled with JetBrains decompiler
// Type: Mypage0017Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage0017Scroll : MonoBehaviour
{
  [SerializeField]
  public GameObject[] PresentObject;
  [SerializeField]
  public UILabel[] PresentExplanation;
  [SerializeField]
  public UILabel[] PresentDate;
  [SerializeField]
  public UILabel[] PresentTime;
  [SerializeField]
  public UIButton[] PresentReceive;
  [SerializeField]
  public UIButton[] PresentHaveReceive;
  [SerializeField]
  public UISprite[] PresentNew;
  [SerializeField]
  public UISprite[] PresentLock;
  [SerializeField]
  public UILabel PresentName;
  [SerializeField]
  public UISprite Present;
  public Mypage0017Scroll.Mode mode;

  public UIButton GetReceive() => this.PresentReceive[(int) this.mode];

  public UIButton GetHaveReceive() => this.PresentHaveReceive[(int) this.mode];

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent present)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Scroll.\u003CInit\u003Ec__Iterator169()
    {
      present = present,
      \u003C\u0024\u003Epresent = present,
      \u003C\u003Ef__this = this
    };
  }

  public enum Mode
  {
    Present,
    WithOutPresent,
  }
}
