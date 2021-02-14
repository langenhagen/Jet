using UnityEngine;
using System.Collections;

public class HUD : BarnBehaviour {

    public UILabel  Healthpoints;
    public UILabel  Kills;
    public UILabel  GunAmmo;
    public UILabel  RocketAmmo;

    public UIPanel  GameOverPanel;
    public UILabel  TotalKillsLabel;
    public UIButton RestartButton;


    //##################################################################################################
    // METHODS

    // Update is called once per frame
    void Update()
    {
        var gm = GameManager.Instance;
        var Jet = gm.Jet;
        var HUD = GameManager.HUD;

        if (Jet != null)
        {
            // ingame HUD

            var guns = Jet.GetComponents<Gun>();
            int ammo = 0;
            foreach (Gun g in guns)
            {
                ammo += g.Ammo;
            }

            HUD.GunAmmo.text = "AMMO: " + ammo.ToString();

            var rocketLauncher = Jet.GetComponent<WeaponLauncher>();
            HUD.RocketAmmo.text = "ROCKITS: " + rocketLauncher.Ammo.ToString();

            HUD.Healthpoints.text = Jet.GetComponent<PlayerJet>().HealthPoints.ToString();
            HUD.Kills.text = "KILLS: " + gm.Kills.ToString();
        }
        else
        {
            // you lose screen
            if (Screen.showCursor == false)
                Screen.showCursor = true;

            HUD.GunAmmo.enabled = false;
            HUD.RocketAmmo.enabled = false;
            HUD.Healthpoints.enabled = false;
            HUD.Kills.enabled = false;


            GameOverPanel.gameObject.SetActive(true);
            TotalKillsLabel.text = "Total Kills: " + gm.Kills.ToString();
        }
    }

}
