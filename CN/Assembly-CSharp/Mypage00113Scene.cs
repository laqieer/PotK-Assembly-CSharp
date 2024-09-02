// Decompiled with JetBrains decompiler
// Type: Mypage00113Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
