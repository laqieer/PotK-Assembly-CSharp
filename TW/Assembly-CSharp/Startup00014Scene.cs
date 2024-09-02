// Decompiled with JetBrains decompiler
// Type: Startup00014Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator1A9 asyncCIterator1A9 = new Startup00014Scene.\u003ConInitSceneAsync\u003Ec__Iterator1A9();
    return (IEnumerator) asyncCIterator1A9;
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator1AA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerLoginBonus[] loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator1AB asyncCIterator1Ab = new Startup00014Scene.\u003ConStartSceneAsync\u003Ec__Iterator1AB();
    return (IEnumerator) asyncCIterator1Ab;
  }

  [DebuggerHidden]
  public IEnumerator LoginBonusLoop(IEnumerable<PlayerLoginBonus> loginBonusList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonusLoop\u003Ec__Iterator1AC()
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
    return (IEnumerator) new Startup00014Scene.\u003CLoginBonus\u003Ec__Iterator1AD()
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
