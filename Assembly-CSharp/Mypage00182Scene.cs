﻿// Decompiled with JetBrains decompiler
// Type: Mypage00182Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

public class Mypage00182Scene : Startup00012Scene
{
  public static void ChangeSceneDirect(OfficialInformationArticle info) => Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) info, (object) true);
}
