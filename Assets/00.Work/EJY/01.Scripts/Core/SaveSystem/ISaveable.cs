using UnityEngine;

public interface ISaveable
{
    public SaveIDSO IdData { get; }
    public string GetSaveData();
    public void RestoreData(string data);
    
}
