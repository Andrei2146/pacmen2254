using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    
    public Ghost[] ghosts;
    public Pacma pacman;
    public Transform[] pellets;

    
    public TextMeshProUGUI scoreText;

    // score visar playerns score
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    
    private void Start()
    {
        // G�r en ny spel
        NewGame();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Kollar om playern har liv kvar och kollar om man trycker 
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            
            NewGame();
        }
    }

    // G�r en ny spel
    private void NewGame()
    {
        // S�tter allt p� 0, f�rutom liv men man har bara en liv
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    // Ny runda
    private void NewRound()
    {
        // Aktivera alla pellets
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        // Reseta game state
        ResetState();
    }

    // Visa game over 
    private void GameOver()
    {
        
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

   
    private void ResetState()
    {
        
        ResetGhostMultiplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }
    }

    // anv�nds inte
    private void SetScore(int score)
    {
        // anv�nds inte
        this.score = score;
    }

    // Bara en liv, anv�nds inte (too much trouble to take it away)
    private void SetLives(int lives)
    {
        
        this.lives = lives;
    }

    // Anv�nds inte
    public void GhostEaten(Ghost ghost)
    {
        
        int points = ghost.points * this.ghostMultiplier;
        
        SetScore(this.score + points);
        
        this.ghostMultiplier++;
    }

    // Anv�nds inte
    public void PacmanEaten()
    {
        
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        
        if (this.lives > 0)
        {
            
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            
            GameOver();
        }
    }

    // Aktiveras d� en pellet �r eaten
    public void PelletEaten(pellets pellet)
    {
        // Pellet blir deactivated
        pellet.gameObject.SetActive(false);
        // G�r scoren st�rre
        SetScore(this.score + pellet.points);

        // G�r scoren st�rre bara d� en pellet �r eaten
        UpdateScoreText();

        // Kolla om pellets �r kvar
        if (!HasRemainingPellets())
        {
            // anv�nds inte
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
    }

    // Tar plats d� man �ter en power pellet
    public void PowerPelletEaten(powerpellet pellet)
    {
       
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        
        CancelInvoke();
        
        PelletEaten(pellet);
    }

    // Kollar om det finns pellets
    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    // Anv�nds inte
    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }

    // Updatera scoren
    private void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            // Updaters scoren som man kan se
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

