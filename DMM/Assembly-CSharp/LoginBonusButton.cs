// Decompiled with JetBrains decompiler
// Type: LoginBonusButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

public class LoginBonusButton : MypageEventButton
{
  public override bool IsActive() => SMManager.Get<Player>().IsLoginBonusMonthly();

  public override bool IsBadge() => Singleton<NGGameDataManager>.GetInstance().hasFillableLoginbonus;
}
