// Decompiled with JetBrains decompiler
// Type: Bugu0552Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Bugu0552Scene : Bugu0052Scene
{
  public static void changeSceneOverViewEarth(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu055_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.OVERVIEW);
  }

  public static void changeSceneSellEarth(bool stack)
  {
    Bugu0052Scene.isResetParam = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("bugu055_2", (stack ? 1 : 0) != 0, (object) Bugu0052Scene.MODE.SELL);
  }

  public override void onStartScene(Bugu0052Scene.MODE mode)
  {
    Singleton<PopupManager>.GetInstance().closeAll();
  }
}
