// Decompiled with JetBrains decompiler
// Type: LevelLoadFade
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class LevelLoadFade : MonoBehaviour
{
  private const float csLogoTime = 0.5f;
  private const float csfadeLength = 1f;
  public Texture2D fadeTexture;
  public float fadeLength;
  private Texture2D m_FadeTexture;
  private Rect m_Rect;
  private Color m_Color;

  public static void FadeAndLoadLevel(string levelName, Texture2D fadeTexture, float fadeLength)
  {
    if (Object.op_Equality((Object) null, (Object) fadeTexture))
      LevelLoadFade.FadeAndLoadLevel(levelName, Color.white, fadeLength);
    fadeLength = 1f;
    GameObject gameObject = new GameObject("Fade");
    gameObject.AddComponent<LevelLoadFade>();
    gameObject.GetComponent<LevelLoadFade>().DoFade(levelName, fadeLength, fadeTexture, Color.white, false);
  }

  public static void FadeAndLoadLevel(string levelName, Color color, float fadeLength)
  {
    color.a = 1f;
    Texture2D fadeTexture = new Texture2D(1, 1);
    fadeTexture.SetPixel(0, 0, color);
    fadeTexture.Apply();
    Object.DontDestroyOnLoad((Object) fadeTexture);
    GameObject gameObject = new GameObject("Fade");
    gameObject.AddComponent<LevelLoadFade>();
    gameObject.GetComponent<LevelLoadFade>().DoFade(levelName, fadeLength, fadeTexture, color, true);
  }

  private void Awake()
  {
    this.m_Rect = new Rect(0.0f, 0.0f, (float) Screen.width, (float) Screen.height);
    this.m_FadeTexture = (Texture2D) null;
  }

  private void OnGUI()
  {
    if (!Object.op_Inequality((Object) this.m_FadeTexture, (Object) null))
      return;
    GUI.depth = -100;
    GUI.color = this.m_Color;
    GUI.DrawTexture(this.m_Rect, (Texture) this.m_FadeTexture);
  }

  private void DoFade(
    string levelName,
    float fadeLength,
    Texture2D fadeTexture,
    Color color,
    bool destroyTexture)
  {
    ((Component) this).transform.position = Vector3.zero;
    Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
    this.m_Color = color;
    this.m_FadeTexture = fadeTexture;
    this.StartCoroutine(this.DoCoroutineFade(levelName, fadeLength, fadeTexture, color, destroyTexture));
  }

  [DebuggerHidden]
  private IEnumerator DoCoroutineFade(
    string levelName,
    float fadeLength,
    Texture2D fadeTexture,
    Color color,
    bool destroyTexture)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LevelLoadFade.\u003CDoCoroutineFade\u003Ec__IteratorC02()
    {
      fadeLength = fadeLength,
      color = color,
      destroyTexture = destroyTexture,
      \u003C\u0024\u003EfadeLength = fadeLength,
      \u003C\u0024\u003Ecolor = color,
      \u003C\u0024\u003EdestroyTexture = destroyTexture,
      \u003C\u003Ef__this = this
    };
  }
}
