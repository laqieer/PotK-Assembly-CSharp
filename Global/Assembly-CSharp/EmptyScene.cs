// Decompiled with JetBrains decompiler
// Type: EmptyScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
