// Decompiled with JetBrains decompiler
// Type: Startup000121ScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

#nullable disable
public class Startup000121ScrollParts : MonoBehaviour
{
  [SerializeField]
  public UILabel title;
  [SerializeField]
  protected UILabel date;
  [SerializeField]
  protected UILabel time;
  [SerializeField]
  protected UILabel badge;
  protected OfficialInformationArticle article;
  [SerializeField]
  protected GameObject newSprite;
  [SerializeField]
  private string nextSceneName;

  public string NextSceneName
  {
    get => this.nextSceneName;
    set => this.nextSceneName = value;
  }

  public void IbtnNewslist()
  {
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    Singleton<NGSceneManager>.GetInstance().changeScene(this.NextSceneName, true, (object) this.article);
  }

  public virtual void Set(OfficialInformationArticle info, string listSceneName)
  {
    this.NextSceneName = listSceneName;
    this.article = info;
    if (Object.op_Inequality((Object) this.title, (Object) null))
      this.title.SetText(info.title);
    this.badge.SetTextLocalize(info.badge_display);
  }

  public virtual void SetData(OfficialInformationArticle info, NGMenuBase menu)
  {
  }

  public virtual bool SetNewSprite()
  {
    bool flag = this.CheckPastArticle(this.article.published_at);
    if (Persist.infoUnRead.Data.GetUnRead(this.article.id) || flag)
    {
      this.newSprite.SetActive(false);
      return false;
    }
    this.newSprite.SetActive(true);
    return true;
  }

  private bool CheckPastArticle(DateTime pubTime)
  {
    DateTime dateTime = ServerTime.NowAppTime();
    TimeSpan timeSpan = TimeSpan.FromDays(3.0);
    return (dateTime - pubTime).TotalDays > timeSpan.TotalDays;
  }
}
