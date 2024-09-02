// Decompiled with JetBrains decompiler
// Type: Bugu0551Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator63B asyncCIterator63B = new Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator63B();
    return (IEnumerator) asyncCIterator63B;
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator63C asyncCIterator63C = new Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator63C();
    return (IEnumerator) asyncCIterator63C;
  }

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051");
  }

  public void onListClick() => Bugu0552Scene.changeSceneOverViewEarth(true);

  public void onSaleClick() => Bugu0552Scene.changeSceneSellEarth(true);
}
