// Decompiled with JetBrains decompiler
// Type: Quest002171CantOpenQuestPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002171CantOpenQuestPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UI2DSprite keySprite;
  [SerializeField]
  private UILabel txtPossession;

  [DebuggerHidden]
  public IEnumerator Init(string name, int key_id, int key_quantity, int consume_quantity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171CantOpenQuestPopup.\u003CInit\u003Ec__Iterator21C()
    {
      key_id = key_id,
      key_quantity = key_quantity,
      name = name,
      consume_quantity = consume_quantity,
      \u003C\u0024\u003Ekey_id = key_id,
      \u003C\u0024\u003Ekey_quantity = key_quantity,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Econsume_quantity = consume_quantity,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator CreateKeySprite(int keyID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171CantOpenQuestPopup.\u003CCreateKeySprite\u003Ec__Iterator21D()
    {
      keyID = keyID,
      \u003C\u0024\u003EkeyID = keyID,
      \u003C\u003Ef__this = this
    };
  }
}
