// Decompiled with JetBrains decompiler
// Type: SocialListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
