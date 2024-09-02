// Decompiled with JetBrains decompiler
// Type: Language.LanguageText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Language
{
  [AddComponentMenu("Language/LanguageText")]
  [RequireComponent(typeof (UILabel))]
  public class LanguageText : MonoBehaviour
  {
    [HideInInspector]
    public string Language;
    [HideInInspector]
    public string File;
    [HideInInspector]
    public string Key;
    [HideInInspector]
    public string Value;
  }
}
