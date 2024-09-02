// Decompiled with JetBrains decompiler
// Type: Mypage0017Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new Mypage0017Scroll.\u003CInit\u003Ec__Iterator1A1()
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
