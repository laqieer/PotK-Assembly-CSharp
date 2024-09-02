// Decompiled with JetBrains decompiler
// Type: Mypage00113Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class Mypage00113Scene : NGSceneBase
{
  public Mypage00113Menu menu;

  public static void changeScene(bool stack)
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_13", stack);
  }

  public void onStartScene() => this.menu.Initialize();
}
