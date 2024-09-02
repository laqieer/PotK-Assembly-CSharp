// Decompiled with JetBrains decompiler
// Type: UnitEvolutionResultData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UnitEvolutionResultData : MonoBehaviour
{
  private static UnitEvolutionResultData Instance;
  private UnitEvolutionResultData.ResultData resultData;

  public static UnitEvolutionResultData GetInstance()
  {
    if (Object.op_Equality((Object) UnitEvolutionResultData.Instance, (Object) null))
    {
      GameObject gameObject = GameObject.Find("Evolution Manager");
      if (Object.op_Equality((Object) gameObject, (Object) null))
      {
        gameObject = new GameObject("Evolution Manager");
        Object.DontDestroyOnLoad((Object) gameObject);
      }
      UnitEvolutionResultData.Instance = gameObject.GetComponent<UnitEvolutionResultData>();
      if (Object.op_Equality((Object) UnitEvolutionResultData.Instance, (Object) null))
        UnitEvolutionResultData.Instance = gameObject.AddComponent<UnitEvolutionResultData>();
    }
    return UnitEvolutionResultData.Instance;
  }

  public UnitEvolutionResultData.ResultData GetData() => this.resultData;

  public void SetData(WebAPI.Response.UnitEvolution data)
  {
    this.resultData = (UnitEvolutionResultData.ResultData) null;
    this.resultData = new UnitEvolutionResultData.ResultData();
    this.resultData.unlockQuests = data.unlock_quests;
  }

  [DebuggerHidden]
  public IEnumerator CharacterStoryPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitEvolutionResultData.\u003CCharacterStoryPopup\u003Ec__Iterator3AE()
    {
      \u003C\u003Ef__this = this
    };
  }

  public GameObject OpenPopup(GameObject original)
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(original);
    ((Component) gameObject.transform.parent.Find("Popup Mask")).gameObject.GetComponent<TweenAlpha>().to = 0.75f;
    return gameObject;
  }

  public class ResultData
  {
    public UnlockQuest[] unlockQuests { get; set; }

    public UnlockQuest[] GetUnlockQuestData() => this.unlockQuests;
  }
}
