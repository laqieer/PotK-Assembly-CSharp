// Decompiled with JetBrains decompiler
// Type: Shop00722Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00722Scene : NGSceneBase
{
  [SerializeField]
  private Shop00722Menu menu;

  public static void changeScene(
    bool stack,
    int shopID,
    PlayerShopArticle article,
    GameObject production)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_22", (stack ? 1 : 0) != 0, (object) shopID, (object) article, (object) production);
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(
    int shopID,
    PlayerShopArticle article,
    GameObject production)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00722Scene.\u003ConStartSceneAsync\u003Ec__Iterator46C()
    {
      shopID = shopID,
      article = article,
      production = production,
      \u003C\u0024\u003EshopID = shopID,
      \u003C\u0024\u003Earticle = article,
      \u003C\u0024\u003Eproduction = production,
      \u003C\u003Ef__this = this
    };
  }
}
