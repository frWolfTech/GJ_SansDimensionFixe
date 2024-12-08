using System.IO;
using UnityEngine;

public class SingletonGlobal : MonoBehaviour
{
    // Instance Singleton
    public static SingletonGlobal Instance { get; private set; }

    // Variables persistantes
    public bool hasChomper = false;
    public bool hasFlameThrower = false;
    public bool hasEraser = false;

    // Chemin du fichier
    private string fileName = "gameData.txt";
    private string filePath;

    void Awake()
    {
        // Assurer que l'instance est unique (singleton)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Empêche l'objet de se détruire lors du changement de scène
        }

        // Définir le chemin complet du fichier
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Créer une chaîne avec les valeurs par défaut
        string defaultData = "hasChomper: false\n" +
                             "hasFlameThrower: false\n" +
                             "hasEraser: false\n";

        try
        {
            // Créer un fichier avec les valeurs par défaut
            File.WriteAllText(filePath, defaultData);
            Debug.Log("Fichier créé avec les valeurs par défaut : " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur lors de la création du fichier : " + e.Message);
        }
    }

    // Méthode pour écrire les trois variables dans un fichier
    public void WriteVariablesToFile()
    {
        string data = "hasChomper: " + hasChomper + "\n" +
                      "hasFlameThrower: " + hasFlameThrower + "\n" +
                      "hasEraser: " + hasEraser + "\n";

        try
        {
            // Si le fichier n'existe pas, crée-le
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();  // Crée et ferme immédiatement le fichier
            }

            // Écrire les données dans le fichier
            File.WriteAllText(filePath, data);
            Debug.Log("Données écrites dans le fichier : " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur lors de l'écriture dans le fichier : " + e.Message);
        }
    }

    // Méthode pour lire les données depuis le fichier
    public string ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                Debug.Log("Données lues du fichier : " + filePath);
                return data;
            }
            else
            {
                Debug.LogError("Le fichier n'existe pas.");
                return null;
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur lors de la lecture du fichier : " + e.Message);
            return null;
        }
    }
}
