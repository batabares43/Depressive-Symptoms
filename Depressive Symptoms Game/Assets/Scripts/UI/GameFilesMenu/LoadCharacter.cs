using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] public GameObject master;
    [SerializeField] private TMP_Text namePlayer;
    [SerializeField] private TMP_Text contentTime;
    [SerializeField] private TMP_Text contentVar;
    [SerializeField] private TMP_Text contentControl;
    [SerializeField] private PlayerLooks player;


    public void startWindow(GameObject master)
    {
        this.master = master;
        SaveContainer save = GetComponent<SaveAndLoad>().load(master.GetComponent<DataSaveContainer>().playerData.id);
        player.setPlayerLooks(save.player);
        namePlayer.text = master.GetComponent<DataSaveContainer>().playerData.name;
        contentTime.text = generateContent(save.time);
        contentVar.text = generateContent(save.variables);
        contentControl.text = generateContent(save.control);

    }
    private string generateContent(TimeContainer t)
    {
        return "Dias: " + t.day + "\n" +
            "Horas: " + t.hour + "\n" +
            "Minutos: " + t.minute;
    }
    private string generateContent(VarContainer v)
    { 
        return "Estado de animo: "+v.mood+"\n"+
            "Calorias: "+v.calories+"\n"+
            "Horas dormidas: "+v.sleepHours+"\n"+
            "Estado fisico: "+v.fitness+"\n"+
            "Energía; "+v.energy+"\n"+
            "Autoeficacia: "+v.selfEfficacy+"\n"+
            "Concentración: "+v.concentration+"\n"+
            "Deseo suicida: "+v.deadDesire+"\n"+
            "Deseo sexual: "+v.sexualDesire+"\n"+
            "Conductas de riesgo: "+v.riskBehaviors;
    }
    private string generateContent(ControlContainer c)
    {
        return "Higiene personal: "+c.hygiene+"\n"+
            "Entorno: "+c.environment+"\n"+
            "Desempeño laboral: "+c.jobPerformance+"\n"+
            "Desempeño academico: "+c.academicPerformance+"\n"+
            "Sociabilidad: "+c.sociability+"\n"+
            "Saciedad: "+c.satiety+"\n"+
            "Descanso: "+c.rest+"\n"+
            "Vegiga: "+c.bladder+"\n"+
            "Ocio: "+c.entertainment+"\n"+
            "Consumo de SPA: "+c.useOfSPA+"\n";
    }

    public void startGame()
    {
        master.GetComponent<StartGameButton>().starGame(); 
    }

    public void deleteGame() {

        master.GetComponent<DeleteGameButton>().deleteSave();
        closeWindow();
    }
    public void closeWindow()
    {
        Destroy(gameObject);
    }


}
