using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SodaManager : MonoBehaviour
{
    [Header("Data Hookups")]
    [SerializeField] private string m_sodaDatesFolderName;

    private List<SodaDate> m_listAllSodas;
    private Dictionary<SodaType, SodaDate> m_dictAllSodas;

    // Load all of the sodas and put them into handy collections
    private void Awake()
    {
        // Unsorted list of all sodas, loaded from Resources folder
        m_listAllSodas = Resources.LoadAll<SodaDate>(m_sodaDatesFolderName).ToList();
        Debug.Log("Loaded " + m_listAllSodas.Count + " sodas");

        // Dictionary to access sodas by type
        m_dictAllSodas = new Dictionary<SodaType, SodaDate>();
        foreach (SodaDate soda in m_listAllSodas)
        {
            m_dictAllSodas.Add(soda.Type, soda);
        }
    }

    public SodaDate GetSodaByType(SodaType a_typeToGet)
    {
        return m_dictAllSodas[a_typeToGet];
    }

    public List<SodaDate> GetAllSodas()
    {
        return new List<SodaDate>(m_listAllSodas);
    }
}
