// Decompiled with JetBrains decompiler
// Type: Startup00014Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00014Scene : NGSceneBase
{
  private List<PlayerLoginBonus> skipList = new List<PlayerLoginBonus>();
  [SerializeField]
  private Transform middle;
  [SerializeField]
  private GameObject loginBonusPrefab;

  public Transform Middle
  {
    get => this.middle;
    set => this.middle = value;
  }

  public GameObject LoginBonusPrefab
  {
    get => this.loginBonusPrefab;
    set => this.loginBonusPrefab = value;
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator13B asyncCIterator13B = new Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator13B();
    return (IEnumerator) asyncCIterator13B;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator13C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerLoginBonus[] loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator13D asyncCIterator13D = new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator13D();
    return (IEnumerator) asyncCIterator13D;
  }

  [DebuggerHidden]
  public IEnumerator LoginBonusLoop(PlayerLoginBonus[] loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonusLoop\u003Ec__Iterator13E()
    {
      loginBonusList = loginBonusList,
      \u003C\u0024\u003EloginBonusList = loginBonusList,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoginBonus(GameObject prefab, PlayerLoginBonus loginBonus)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonus\u003Ec__Iterator13F()
    {
      prefab = prefab,
      loginBonus = loginBonus,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003EloginBonus = loginBonus,
      \u003C\u003Ef__this = this
    };
  }

  private void SceneChange()
  {
    Debug.Log((object) "演出シーンを使うログインボーナスがなかった");
    MypageScene.ChangeScene(false);
  }
}
