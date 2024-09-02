// Decompiled with JetBrains decompiler
// Type: SocialListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using gu3;
using UnityEngine;

#nullable disable
public class SocialListener : MonoBehaviour, SocialKit.Share.IShareListener
{
  private const string SHARE_TEXT = "ファンキルはプレーした？本格的なシミュレーションRPGが手軽に楽しめてゲーム好きなら絶対オススメだから遊んでみて！招待コード入れてくれたら特典も貰えるよ！";
  private const string SHARE_URL = "https://pk.fg-games.co.jp";

  public void OnSucceeded(SocialKit.Platform platform)
  {
  }

  public void NotInstalled(SocialKit.Platform platform)
  {
  }

  public static void ShareWithTwitter()
  {
  }
}
