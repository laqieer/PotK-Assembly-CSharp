// Decompiled with JetBrains decompiler
// Type: EmptyScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class EmptyScene : NGSceneBase
{
  public static bool IsActive;

  public void onStartScene() => EmptyScene.IsActive = true;

  public override void onEndScene()
  {
    base.onEndScene();
    EmptyScene.IsActive = false;
  }
}
