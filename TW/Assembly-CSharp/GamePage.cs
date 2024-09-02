// Decompiled with JetBrains decompiler
// Type: GamePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
