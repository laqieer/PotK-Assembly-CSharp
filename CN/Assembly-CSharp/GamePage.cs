// Decompiled with JetBrains decompiler
// Type: GamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using DenaLib;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class GamePage : UIWindow
{
  public Button m_Test;
  private ButtonEventDelegate m_Click;

  public override void Reset()
  {
    // ISSUE: method pointer
    this.m_Click = DenaLib.Singleton<GameLogic>.Instance.GetWindowStackManager().BindButtonAction(nameof (GamePage), this.m_Test, new UnityAction((object) this, __methodptr(TestClick)));
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  private void TestClick() => Debuger.Log((object) "C# code click");
}
