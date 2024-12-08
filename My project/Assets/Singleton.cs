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
            DontDestroyOnLoad(gameObject);  // Emp�che l'objet de se d�truire lors du changement de sc�ne
        }

        // D�finir le chemin complet du fichier
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Cr�er une cha�ne avec les valeurs par d�faut
        string defaultData = "hasChomper: false\n" +
                             "hasFlameThrower: false\n" +
                             "hasEraser: false\n";

        try
        {
            // Cr�er un fichier avec les valeurs par d�faut
            File.WriteAllText(filePath, defaultData);
            Debug.Log("Fichier cr�� avec les valeurs par d�faut : " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur lors de la cr�ation du fichier : " + e.Message);
        }
    }

    // M�thode pour �crire les trois variables dans un fichier
    public void WriteVariablesToFile()
    {
        string data = "hasChomper: " + hasChomper + "\n" +
                      "hasFlameThrower: " + hasFlameThrower + "\n" +
                      "hasEraser: " + hasEraser + "\n";

        try
        {
            // Si le fichier n'existe pas, cr�e-le
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();  // Cr�e et ferme imm�diatement le fichier
            }

            // �crire les donn�es dans le fichier
            File.WriteAllText(filePath, data);
            Debug.Log("Donn�es �crites dans le fichier : " + filePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Erreur lors de l'�criture dans le fichier : " + e.Message);
        }
    }

    // M�thode pour lire les donn�es depuis le fichier
    public string ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string data = File.ReadAllText(filePath);
                Debug.Log("Donn�es lues du fichier : " + filePath);
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
