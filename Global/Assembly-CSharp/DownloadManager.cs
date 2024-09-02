// Decompiled with JetBrains decompiler
// Type: DownloadManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

#nullable disable
public class DownloadManager : MonoBehaviour
{
  private List<BundleData> bundles;
  private List<BundleBuildState> buildStates;
  private BMConfiger bmConfiger;
  private BMUrls bmUrl;
  private string downloadRootUrl;
  private BuildPlatform curPlatform;
  private Dictionary<string, BundleData> bundleDict = new Dictionary<string, BundleData>();
  private Dictionary<string, BundleBuildState> buildStatesDict = new Dictionary<string, BundleBuildState>();
  private Dictionary<string, DownloadManager.WWWRequest> processingRequest = new Dictionary<string, DownloadManager.WWWRequest>();
  private Dictionary<string, DownloadManager.WWWRequest> succeedRequest = new Dictionary<string, DownloadManager.WWWRequest>();
  private Dictionary<string, DownloadManager.WWWRequest> failedRequest = new Dictionary<string, DownloadManager.WWWRequest>();
  private List<DownloadManager.WWWRequest> waitingRequests = new List<DownloadManager.WWWRequest>();
  private List<DownloadManager.WWWRequest> requestedBeforeInit = new List<DownloadManager.WWWRequest>();
  private static DownloadManager instance;
  private static string manualUrl = string.Empty;
  public WWW initDataWWW;

  public string GetError(string url)
  {
    if (!this.ConfigLoaded)
      return (string) null;
    url = this.formatUrl(url);
    return this.failedRequest.ContainsKey(url) ? this.failedRequest[url].www.error : (string) null;
  }

  public bool IsUrlRequested(string url)
  {
    if (!this.ConfigLoaded)
      return this.isInBeforeInitList(url);
    url = this.formatUrl(url);
    return this.isInWaitingList(url) || this.processingRequest.ContainsKey(url) || this.succeedRequest.ContainsKey(url) || this.failedRequest.ContainsKey(url);
  }

  public WWW GetWWW(string url)
  {
    if (!this.ConfigLoaded)
      return (WWW) null;
    url = this.formatUrl(url);
    if (!this.succeedRequest.ContainsKey(url))
      return (WWW) null;
    DownloadManager.WWWRequest wwwRequest = this.succeedRequest[url];
    this.prepareDependBundles(this.stripBundleSuffix(wwwRequest.requestString));
    return wwwRequest.www;
  }

  [DebuggerHidden]
  public IEnumerator WaitDownload(string url)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadManager.\u003CWaitDownload\u003Ec__Iterator0()
    {
      url = url,
      \u003C\u0024\u003Eurl = url,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator WaitDownload(string url, int priority)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadManager.\u003CWaitDownload\u003Ec__Iterator1()
    {
      url = url,
      priority = priority,
      \u003C\u0024\u003Eurl = url,
      \u003C\u0024\u003Epriority = priority,
      \u003C\u003Ef__this = this
    };
  }

  public void StartDownload(string url) => this.StartDownload(url, -1);

  public void StartDownload(string url, int priority)
  {
    DownloadManager.WWWRequest request = new DownloadManager.WWWRequest();
    request.requestString = url;
    request.url = url;
    request.priority = priority;
    if (!this.ConfigLoaded)
    {
      if (this.isInBeforeInitList(url))
        return;
      this.requestedBeforeInit.Add(request);
    }
    else
      this.download(request);
  }

  public void StopDownload(string url)
  {
    if (!this.ConfigLoaded)
    {
      this.requestedBeforeInit.RemoveAll((Predicate<DownloadManager.WWWRequest>) (x => x.url == url));
    }
    else
    {
      url = this.formatUrl(url);
      this.waitingRequests.RemoveAll((Predicate<DownloadManager.WWWRequest>) (x => x.url == url));
      if (!this.processingRequest.ContainsKey(url))
        return;
      this.processingRequest[url].www.Dispose();
      this.processingRequest.Remove(url);
    }
  }

  public void DisposeWWW(string url)
  {
    url = this.formatUrl(url);
    this.StopDownload(url);
    if (this.succeedRequest.ContainsKey(url))
    {
      this.succeedRequest[url].www.Dispose();
      this.succeedRequest.Remove(url);
    }
    if (!this.failedRequest.ContainsKey(url))
      return;
    this.failedRequest[url].www.Dispose();
    this.failedRequest.Remove(url);
  }

  public void StopAll()
  {
    this.requestedBeforeInit.Clear();
    this.waitingRequests.Clear();
    foreach (DownloadManager.WWWRequest wwwRequest in this.processingRequest.Values)
      wwwRequest.www.Dispose();
    this.processingRequest.Clear();
  }

  public float ProgressOfBundles(string[] bundlefiles)
  {
    if (!this.ConfigLoaded)
      return 0.0f;
    List<string> stringList = new List<string>();
    foreach (string bundlefile in bundlefiles)
    {
      if (!bundlefile.EndsWith("." + this.bmConfiger.bundleSuffix, StringComparison.OrdinalIgnoreCase))
        Debug.LogWarning((object) ("ProgressOfBundles only accept bundle files. " + bundlefile + " is not a bundle file."));
      else
        stringList.Add(Path.GetFileNameWithoutExtension(bundlefile));
    }
    HashSet<string> stringSet = new HashSet<string>();
    foreach (string bundle in stringList)
    {
      foreach (string depend in this.getDependList(bundle))
      {
        if (!stringSet.Contains(depend))
          stringSet.Add(depend);
      }
      if (!stringSet.Contains(bundle))
        stringSet.Add(bundle);
    }
    long num1 = 0;
    long num2 = 0;
    foreach (string key1 in stringSet)
    {
      if (!this.buildStatesDict.ContainsKey(key1))
      {
        Debug.LogError((object) ("Cannot get progress of [" + key1 + "]. The bundle does not exist in the build states list."));
      }
      else
      {
        long size = this.buildStatesDict[key1].size;
        num2 += size;
        string key2 = this.formatUrl(key1 + "." + this.bmConfiger.bundleSuffix);
        if (this.processingRequest.ContainsKey(key2))
          num1 += (long) ((double) this.processingRequest[key2].www.progress * (double) size);
        if (this.succeedRequest.ContainsKey(key2))
          num1 += size;
      }
    }
    return num2 == 0L ? 0.0f : (float) num1 / (float) num2;
  }

  public bool ConfigLoaded
  {
    get => this.bundles != null && this.buildStates != null && this.bmConfiger != null;
  }

  public BundleData[] BuiltBundles
  {
    get => this.bundles == null ? (BundleData[]) null : this.bundles.ToArray();
  }

  public BundleBuildState[] BuildStates
  {
    get => this.buildStates == null ? (BundleBuildState[]) null : this.buildStates.ToArray();
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadManager.\u003CStart\u003Ec__Iterator2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.ConfigLoaded)
      return;
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    foreach (DownloadManager.WWWRequest request in this.processingRequest.Values)
    {
      if (request.www.error != null)
      {
        Debug.LogError((object) ("============== Error " + request.www.error));
        if (!CheckNetworkConnection.Instance.ShowPopUp("BM Error", "Cannot download bundle", (MonoBehaviour) DownloadManager.instance, new System.Action(this.RetryDownload), request))
          return;
        if (request.triedTimes - 1 < this.bmConfiger.downloadRetryTime)
        {
          Debug.LogWarning((object) ("bmConfiger.downloadRetryTime " + request.url + " | " + (object) request.www));
        }
        else
        {
          stringList2.Add(request.url);
          Debug.LogError((object) ("Download " + request.url + " failed for " + (object) request.triedTimes + " times.\nError: " + request.www.error));
        }
      }
      else if (request.www.isDone)
        stringList1.Add(request.url);
    }
    foreach (string key in stringList1)
    {
      this.succeedRequest.Add(key, this.processingRequest[key]);
      this.processingRequest.Remove(key);
    }
    foreach (string key in stringList2)
    {
      if (!this.failedRequest.ContainsKey(key))
        this.failedRequest.Add(key, this.processingRequest[key]);
      this.processingRequest.Remove(key);
    }
    int num = 0;
    while (this.processingRequest.Count < this.bmConfiger.downloadThreadsCount && num < this.waitingRequests.Count)
    {
      DownloadManager.WWWRequest waitingRequest = this.waitingRequests[num++];
      if (waitingRequest.bundleData == null || this.isBundleDependenciesReady(waitingRequest.bundleData.name))
      {
        this.waitingRequests.Remove(waitingRequest);
        waitingRequest.CreatWWW();
        this.processingRequest.Add(waitingRequest.url, waitingRequest);
      }
    }
  }

  private bool isBundleDependenciesReady(string bundleName)
  {
    foreach (string depend in this.getDependList(bundleName))
    {
      if (!this.succeedRequest.ContainsKey(this.formatUrl(depend + "." + this.bmConfiger.bundleSuffix)))
        return false;
    }
    return true;
  }

  private void prepareDependBundles(string bundleName)
  {
    foreach (string depend in this.getDependList(bundleName))
    {
      string key = this.formatUrl(depend + "." + this.bmConfiger.bundleSuffix);
      if (this.succeedRequest.ContainsKey(key))
      {
        AssetBundle assetBundle = this.succeedRequest[key].www.assetBundle;
      }
    }
  }

  private void download(DownloadManager.WWWRequest request)
  {
    request.url = this.formatUrl(request.url);
    if (this.isDownloadingWWW(request.url) || this.succeedRequest.ContainsKey(request.url))
      return;
    if (this.isBundleUrl(request.url))
    {
      string str = this.stripBundleSuffix(request.requestString);
      if (!this.bundleDict.ContainsKey(str))
      {
        Debug.LogError((object) ("Cannot download bundle [" + str + "]. It's not in the bundle config."));
        CheckNetworkConnection.Instance.ShowPopUp("Cannot download bundle", "[" + str + "]. It's not in the bundle config.", (MonoBehaviour) DownloadManager.instance, new System.Action(this.RetryDownload));
      }
      else
      {
        foreach (string depend in this.getDependList(str))
        {
          string key = this.formatUrl(depend + "." + this.bmConfiger.bundleSuffix);
          if (!this.processingRequest.ContainsKey(key) && !this.succeedRequest.ContainsKey(key))
          {
            DownloadManager.WWWRequest request1 = new DownloadManager.WWWRequest()
            {
              bundleData = this.bundleDict[depend],
              bundleBuildState = this.buildStatesDict[depend],
              url = key
            };
            request1.priority = request1.bundleData.priority;
            this.addRequestToWaitingList(request1);
          }
        }
        request.bundleData = this.bundleDict[str];
        request.bundleBuildState = this.buildStatesDict[str];
        if (request.priority == -1)
          request.priority = request.bundleData.priority;
        this.addRequestToWaitingList(request);
      }
    }
    else
    {
      if (request.priority == -1)
        request.priority = 0;
      this.addRequestToWaitingList(request);
    }
  }

  private bool isInWaitingList(string url)
  {
    foreach (DownloadManager.WWWRequest waitingRequest in this.waitingRequests)
    {
      if (waitingRequest.url == url)
        return true;
    }
    return false;
  }

  private void addRequestToWaitingList(DownloadManager.WWWRequest request)
  {
    if (this.succeedRequest.ContainsKey(request.url) || this.isInWaitingList(request.url))
      return;
    int index = this.waitingRequests.FindIndex((Predicate<DownloadManager.WWWRequest>) (x => x.priority < request.priority));
    this.waitingRequests.Insert(index != -1 ? index : this.waitingRequests.Count, request);
  }

  private bool isDownloadingWWW(string url)
  {
    foreach (DownloadManager.WWWRequest waitingRequest in this.waitingRequests)
    {
      if (waitingRequest.url == url)
        return true;
    }
    return this.processingRequest.ContainsKey(url);
  }

  private bool isInBeforeInitList(string url)
  {
    foreach (DownloadManager.WWWRequest wwwRequest in this.requestedBeforeInit)
    {
      if (wwwRequest.url == url)
        return true;
    }
    return false;
  }

  private List<string> getDependList(string bundle)
  {
    if (!this.ConfigLoaded)
    {
      Debug.LogError((object) "getDependList() should be call after download manger inited");
      return (List<string>) null;
    }
    List<string> dependList = new List<string>();
    if (!this.bundleDict.ContainsKey(bundle))
    {
      Debug.LogError((object) ("Cannot find parent bundle [" + bundle + "], Please check your bundle config."));
      return dependList;
    }
    while (this.bundleDict[bundle].parent != string.Empty)
    {
      bundle = this.bundleDict[bundle].parent;
      if (this.bundleDict.ContainsKey(bundle))
      {
        dependList.Add(bundle);
      }
      else
      {
        Debug.LogError((object) ("Cannot find parent bundle [" + bundle + "], Please check your bundle config."));
        break;
      }
    }
    dependList.Reverse();
    return dependList;
  }

  private BuildPlatform getRuntimePlatform()
  {
    if (Application.platform == 2 || Application.platform == 1)
      return BuildPlatform.Standalones;
    if (Application.platform == 3 || Application.platform == 5)
      return BuildPlatform.WebPlayer;
    if (Application.platform == 8)
      return BuildPlatform.IOS;
    if (Application.platform == 11)
      return BuildPlatform.Android;
    Debug.LogError((object) ("Platform " + (object) Application.platform + " is not supported by BundleManager."));
    return BuildPlatform.Standalones;
  }

  private void initRootUrl()
  {
    this.bmUrl = JsonMapper.ToObject<BMUrls>(((TextAsset) Resources.Load("Urls_prod")).text);
    this.curPlatform = Application.platform == 7 || Application.platform == null ? this.bmUrl.bundleTarget : this.getRuntimePlatform();
    if (DownloadManager.manualUrl == string.Empty)
      this.downloadRootUrl = new Uri(!this.bmUrl.downloadFromOutput ? this.bmUrl.GetInterpretedDownloadUrl(this.curPlatform) : this.bmUrl.GetInterpretedOutputPath(this.curPlatform)).AbsoluteUri;
    else
      this.downloadRootUrl = new Uri(BMUtility.InterpretPath(DownloadManager.manualUrl, this.curPlatform)).AbsoluteUri;
  }

  private string formatUrl(string urlstr)
  {
    return (this.isAbsoluteUrl(urlstr) ? new Uri(urlstr) : new Uri(new Uri(this.downloadRootUrl + (object) '/'), urlstr)).AbsoluteUri;
  }

  private bool isAbsoluteUrl(string url) => Uri.TryCreate(url, UriKind.Absolute, out Uri _);

  private bool isBundleUrl(string url)
  {
    return string.Compare(Path.GetExtension(url), "." + this.bmConfiger.bundleSuffix, StringComparison.OrdinalIgnoreCase) == 0;
  }

  private string stripBundleSuffix(string requestString)
  {
    return requestString.Substring(0, requestString.Length - this.bmConfiger.bundleSuffix.Length - 1);
  }

  public static DownloadManager Instance
  {
    get
    {
      if (Object.op_Equality((Object) DownloadManager.instance, (Object) null))
      {
        DownloadManager.instance = new GameObject("Download Manager").AddComponent<DownloadManager>();
        Object.DontDestroyOnLoad((Object) ((Component) DownloadManager.instance).gameObject);
      }
      return DownloadManager.instance;
    }
  }

  public static void SetManualUrl(string url)
  {
    if (Object.op_Inequality((Object) DownloadManager.instance, (Object) null))
      Debug.LogError((object) "Cannot use SetManualUrl after accessed DownloadManager.Instance. Make sure call SetManualUrl before access to DownloadManager.Instance.");
    else
      DownloadManager.manualUrl = url;
  }

  public void RetryDownload()
  {
    CheckNetworkConnection.Instance.DMRequest.CreatWWW();
    CheckNetworkConnection.Instance.enablePopUp = false;
  }

  public void ReInitialized()
  {
    this.StartCoroutine(this.ReInit());
    CheckNetworkConnection.Instance.enablePopUp = false;
    ((Component) LocalizationPreset.Instance).transform.parent = (Transform) null;
  }

  [DebuggerHidden]
  private IEnumerator ReInit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadManager.\u003CReInit\u003Ec__Iterator3()
    {
      \u003C\u003Ef__this = this
    };
  }

  public class WWWRequest
  {
    public string requestString = string.Empty;
    public string url = string.Empty;
    public int triedTimes;
    public int priority;
    public BundleData bundleData;
    public BundleBuildState bundleBuildState;
    public WWW www;

    public void CreatWWW()
    {
      ++this.triedTimes;
      if (DownloadManager.instance.bmConfiger.useCache && this.bundleBuildState != null)
        this.www = WWW.LoadFromCacheOrDownload(this.url, this.bundleBuildState.version);
      else
        this.www = new WWW(this.url);
    }
  }
}
