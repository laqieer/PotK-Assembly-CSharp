// Decompiled with JetBrains decompiler
// Type: Language.LanguageText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
