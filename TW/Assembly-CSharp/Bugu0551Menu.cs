// Decompiled with JetBrains decompiler
// Type: Bugu0551Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Bugu0551Menu : BackButtonMenuBase
{
  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator849 asyncCIterator849 = new Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator849();
    return (IEnumerator) asyncCIterator849;
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator84A asyncCIterator84A = new Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator84A();
    return (IEnumerator) asyncCIterator84A;
  }

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051");
  }

  public void onListClick() => Bugu0552Scene.ChangeScene(true);

  public void onSaleClick() => Bugu055SellScene.ChangeScene(true);
}
