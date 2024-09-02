// Decompiled with JetBrains decompiler
// Type: GachaPlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GachaPlay : MonoBehaviour
{
  private static GachaPlay Instance;

  public static GachaPlay GetInstance()
  {
    if (Object.op_Equality((Object) GachaPlay.Instance, (Object) null))
    {
      GameObject gameObject = GameObject.Find("Gacha Manager");
      if (Object.op_Equality((Object) gameObject, (Object) null))
      {
        gameObject = new GameObject("Gacha Manager");
        Object.DontDestroyOnLoad((Object) gameObject);
      }
      GachaPlay.Instance = gameObject.GetComponent<GachaPlay>();
      if (Object.op_Equality((Object) GachaPlay.Instance, (Object) null))
        GachaPlay.Instance = gameObject.AddComponent<GachaPlay>();
    }
    return GachaPlay.Instance;
  }

  [DebuggerHidden]
  public IEnumerator ChargeGacha(
    string name,
    int num,
    int gacha_id,
    Consts.GachaType gacha_type,
    int payment_amount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaPlay.\u003CChargeGacha\u003Ec__Iterator38D()
    {
      num = num,
      name = name,
      gacha_id = gacha_id,
      gacha_type = gacha_type,
      payment_amount = payment_amount,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003Egacha_type = gacha_type,
      \u003C\u0024\u003Epayment_amount = payment_amount,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ChargeGachaMulti(
    string name,
    int gacha_id,
    Consts.GachaType gacha_type,
    int payment_amount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaPlay.\u003CChargeGachaMulti\u003Ec__Iterator38E()
    {
      gacha_type = gacha_type,
      name = name,
      gacha_id = gacha_id,
      payment_amount = payment_amount,
      \u003C\u0024\u003Egacha_type = gacha_type,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003Epayment_amount = payment_amount,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator FriendGacha(string name, int num, int gacha_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaPlay.\u003CFriendGacha\u003Ec__Iterator38F()
    {
      name = name,
      num = num,
      gacha_id = gacha_id,
      \u003C\u0024\u003Ename = name,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator TicketGacha(int num, int gacha_id, int payment_amount)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaPlay.\u003CTicketGacha\u003Ec__Iterator390()
    {
      num = num,
      gacha_id = gacha_id,
      payment_amount = payment_amount,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Egacha_id = gacha_id,
      \u003C\u0024\u003Epayment_amount = payment_amount,
      \u003C\u003Ef__this = this
    };
  }
}
