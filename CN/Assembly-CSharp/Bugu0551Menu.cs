// Decompiled with JetBrains decompiler
// Type: Bugu0551Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator782 asyncCIterator782 = new Bugu0551Menu.\u003CInitSceneAsync\u003Ec__Iterator782();
    return (IEnumerator) asyncCIterator782;
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator783 asyncCIterator783 = new Bugu0551Menu.\u003CStartSceneAsync\u003Ec__Iterator783();
    return (IEnumerator) asyncCIterator783;
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
