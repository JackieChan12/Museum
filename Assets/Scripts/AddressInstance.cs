using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressInstance : MonoBehaviour
{
    public string path = "";
    public TMPro.TextMeshPro text;
    int startdown = 0;
    AsyncOperationHandle<GameObject> handle;
    void Start()
    {
        text.text = Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.A))
        {
            handle = Addressables.InstantiateAsync(path);
            handle.Completed += model =>
            {
                GameObject obj = model.Result;
                obj.transform.position = transform.position;//vecs[id % vecs.Count];
                //text.text = "InitializeAsync Model Done !!!";
                startdown = 2;
            };
            startdown = 1;
        }
        if (startdown == 1)
        {
            text.text = handle.Status.ToString();
        }

    }
}
