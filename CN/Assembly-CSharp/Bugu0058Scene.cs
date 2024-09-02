// Decompiled with JetBrains decompiler
// Type: Bugu0058Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0058Scene : NGSceneBase
{
  [SerializeField]
  private Bugu0058Menu menu;
  private PlayerItem baseGear;
  private List<PlayerItem> materialGears = new List<PlayerItem>();

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", stack);
  }

  public static void changeScene(bool stack, PlayerItem playerItem)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", (stack ? 1 : 0) != 0, (object) playerItem);
  }

  public static void changeScene(bool stack, List<InventoryItem> selectItemList)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", (stack ? 1 : 0) != 0, (object) selectItemList);
    Singleton<NGSceneManager>.GetInstance().destroyScene("bugu005_8_2");
  }

  public static void changeScene(
    bool stack,
    PlayerItem playerItem,
    List<InventoryItem> selectItemList)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu005_8", (stack ? 1 : 0) != 0, (object) playerItem, (object) selectItemList);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConInitSceneAsync\u003Ec__Iterator3C3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConStartSceneAsync\u003Ec__Iterator3C4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(PlayerItem playerItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConStartSceneAsync\u003Ec__Iterator3C5()
    {
      playerItem = playerItem,
      \u003C\u0024\u003EplayerItem = playerItem,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(List<InventoryItem> selectItemList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Scene.\u003ConStartSceneAsync\u003Ec__Iterator3C6()
    {
      selectItemList = selectItemList,
      \u003C\u0024\u003EselectItemList = selectItemList,
      \u003C\u003Ef__this = this
    };
  }
}
