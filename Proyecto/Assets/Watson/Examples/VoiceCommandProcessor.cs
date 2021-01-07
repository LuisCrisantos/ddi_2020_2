using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBM.Watsson.Examples{

    public class VoiceCommandProcessor : PanelInteract
    {
        static protected VoiceCommandProcessor s_VoiceInstance;
        static public VoiceCommandProcessor Instance {get{return s_VoiceInstance;}}
        public delegate void OnVoiceCommand(string action);
        public OnVoiceCommand onVoiceCommand;
        public List<string> actions;
        public List<string> specialActions;
        //public GameObject persona;
        public List <GameObject> kanjis;
        public GameObject aux;
        public bool flag;
        public PanelInteract myScript;
        //public GameObject panel;
        
        void Awake()
        {
            s_VoiceInstance = this;
            //myScript = GetComponent<PanelInteract>();

        }

        void Update()
        {
            flag =  myScript.timerRunning;
        }

        public void Create(string transcript)
        {  
            string [] words = transcript.Split(' ');
            foreach(var word in words)
            {
                if(actions.Contains(word))
                {
                    if(onVoiceCommand != null)
                    {
                        onVoiceCommand.Invoke(word);
                    }
                    return;
                }
            }
            foreach(var word in words)
            {
                if(specialActions.Contains(word))
                {
                    if(word == "漢字"　|| word == "感じ"　|| word　== "かんじ")
                    {
                        SpawnObject(words);  
                    }
                }
                break;
            }                
        }

        void SpawnObject(string[] words)
        {      
            foreach(var word in words)
            {
                foreach(var prefab in kanjis)
                {
                    //panel.SetActive(true);
                    if((prefab.name == word) && flag)                       
                        prefab.SetActive(true);
                    break;
                }
            }
        }
    }
}