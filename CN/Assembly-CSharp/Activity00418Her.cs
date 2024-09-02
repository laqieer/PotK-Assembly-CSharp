// Decompiled with JetBrains decompiler
// Type: Activity00418Her
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Activity00418Her : MonoBehaviour
{
  [SerializeField]
  private UISprite typePic;
  [SerializeField]
  private UI2DSprite unitPic;
  [SerializeField]
  private UI2DSprite weaponPic;
  [SerializeField]
  private GameObject unitBasePic;
  [SerializeField]
  private GameObject star;
  public Sprite[] raritySprite;
  [SerializeField]
  private UILabel unitName;
  private string path = ".png__GUI__004-18_sozai__004-18_sozai_prefab";
  private string typePatht = "_kind";
  private string her = "_her";

  [DebuggerHidden]
  public IEnumerator setHer(string conditionId, int UiType)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Activity00418Her.\u003CsetHer\u003Ec__Iterator296()
    {
      conditionId = conditionId,
      UiType = UiType,
      \u003C\u0024\u003EconditionId = conditionId,
      \u003C\u0024\u003EUiType = UiType,
      \u003C\u003Ef__this = this
    };
  }
}
