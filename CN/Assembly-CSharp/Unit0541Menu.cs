// Decompiled with JetBrains decompiler
// Type: Unit0541Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Unit0541Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIButton evolutionButton;

  [DebuggerHidden]
  public IEnumerator InitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Unit0541Menu.\u003CInitSceneAsync\u003Ec__Iterator75D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Unit0541Menu.\u003CStartSceneAsync\u003Ec__Iterator75E asyncCIterator75E = new Unit0541Menu.\u003CStartSceneAsync\u003Ec__Iterator75E();
    return (IEnumerator) asyncCIterator75E;
  }

  public override void onBackButton()
  {
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051");
  }

  public void onOrderClick() => Unit05468Scene.ChangeScene(true);

  public void onEvolutionClick() => Unit0549Scene.ChangeScene(true);

  public void onEquipClick() => Unit05412Scene.ChangeScene(true);

  public void onListClick() => Unit05411Scene.ChangeScene(true);
}
