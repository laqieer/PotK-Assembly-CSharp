// Decompiled with JetBrains decompiler
// Type: Bugu0058Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0058Scene : NGSceneBase
{
  [SerializeField]
  private Bugu0058Menu menu;
  private ItemInfo baseGear;

  public static void changeScene(bool stack, ItemInfo baseItem)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", (stack ? 1 : 0) != 0, (object) baseItem);
  }

  public static void changeScene(bool stack, List<ItemInfo> selectItemList)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", (stack ? 1 : 0) != 0, (object) selectItemList);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConInitSceneAsync\u003Ec__Iterator3E8()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(ItemInfo playerItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConStartSceneAsync\u003Ec__Iterator3E9()
    {
      playerItem = playerItem,
      \u003C\u0024\u003EplayerItem = playerItem,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<ItemInfo> selectItemList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConStartSceneAsync\u003Ec__Iterator3EA()
    {
      selectItemList = selectItemList,
      \u003C\u0024\u003EselectItemList = selectItemList,
      \u003C\u003Ef__this = this
    };
  }
}
