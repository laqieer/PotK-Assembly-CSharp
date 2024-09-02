// Decompiled with JetBrains decompiler
// Type: Startup00014Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator17E asyncCIterator17E = new Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator17E();
    return (IEnumerator) asyncCIterator17E;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator17F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerLoginBonus[] loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator180 asyncCIterator180 = new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator180();
    return (IEnumerator) asyncCIterator180;
  }

  [DebuggerHidden]
  public IEnumerator LoginBonusLoop(IEnumerable<PlayerLoginBonus> loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonusLoop\u003Ec__Iterator181()
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
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonus\u003Ec__Iterator182()
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
    Debug.Log((object) "没有使用动画scene 的登录奖励");
    MypageScene.ChangeScene(false);
  }
}
