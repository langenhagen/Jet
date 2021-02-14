using UnityEngine;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Superimposing godlike omnipresent GameManagerClass
/// </summary>
public class GameManager : UnitySingleton<GameManager>
{

    public enum UnitType
    {
        // TODO delete me maybe
        EnemyJet
    }

    //##################################################################################################
    // MEMBER VARS

    public int Kills { get; set; }

    public static HashSet<Transform> Enemies { get; set; }

    public static Stack<Transform> InactiveEnemies { get; set; }

    public static HUD HUD { get; set; }

    public GameObject Jet;

    public GameObject GroundPlane;

    public BoxCollider JetBigBoxCollider;

    //##################################################################################################
    // METHODS

    void OnLevelWasLoaded(int level)
    {
       // DontDestroyOnLoad(transform.gameObject);

        Screen.showCursor = false;

        Kills = 0;

        ScrollTexture.GlobalSpeed = 1f;


        HUD = GetComponent<HUD>();

        InactiveEnemies = new Stack<Transform>();
        Enemies = new HashSet<Transform>();
    }

    // Use this for initialization
    void Awake()
    {
        OnLevelWasLoaded(0);
	}

    void Update()
    {
        ScrollTexture.GlobalSpeed = 1 + Kills/10;
        Camera.main.fieldOfView = 60  + Kills/5;


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}