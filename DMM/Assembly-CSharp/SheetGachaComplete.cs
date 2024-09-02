// Decompiled with JetBrains decompiler
// Type: SheetGachaComplete
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SheetGachaComplete : MonoBehaviour
{
  [SerializeField]
  private SheetGachaAnim anim;

  public void Init(System.Action endAction)
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if ((UnityEngine.Object) instance != (UnityEngine.Object) null)
      instance.playSE("SE_0554");
    this.anim.Init(endAction);
  }
}
