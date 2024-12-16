using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    
    public static AdDisplayManager instance; // Singletone
    public string unityAdsID; // IDs Del proyecto
    public int androidID, appleID; //IDs de android y Iphone
    public bool testMode = true;

    public string adType = "Banner_Android";

    public void OnUnityAdsAdLoaded(string placementId) //Cuando haya cargado el anuncio
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) // Cuando el anuncio ha fallado a la hora de cargar
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId) //Cuando clikeas en el anuncio
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) // Cuando el anuncio se ha completado
    {
        GameManager.instance.LoadScene("Menu"); // Cuando se termina el anuncio nos lleva a la escena del menu.
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) // Cuando el anuncio no se ha enseñado por completo
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId) // Cuando el anuncio empieza
    {
        //throw new System.NotImplementedException();
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!Advertisement.isInitialized) //Pool de anuncios
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID
            Advertisement.Initialize(androidID.ToString(), testMode);
            
#elif UNITY_IOS
            Advertisement.Initialize(appleID.ToString(), testMode);
            
#endif
        }
    }

    public void ShowAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(adType);
            Advertisement.Show(adType);
        }
    }

    void Update()
    {
        
    }
}
