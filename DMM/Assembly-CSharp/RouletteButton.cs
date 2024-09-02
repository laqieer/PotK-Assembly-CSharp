// Decompiled with JetBrains decompiler
// Type: RouletteButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class RouletteButton : MypageEventButton
{
  public override bool IsActive() => Singleton<NGGameDataManager>.GetInstance().isOpenRoulette;

  public override bool IsBadge() => Singleton<NGGameDataManager>.GetInstance().isCanRoulette;
}
