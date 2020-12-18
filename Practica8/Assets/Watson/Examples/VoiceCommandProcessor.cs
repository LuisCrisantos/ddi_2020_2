using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBM.Watsson.Examples{

    public class VoiceCommandProcessor : MonoBehaviour
    {
        static protected VoiceCommandProcessor s_VoiceInstance;
        static public VoiceCommandProcessor Instance {get{return s_VoiceInstance;}}
        public delegate void OnVoiceCommand(string action);
        public OnVoiceCommand onVoiceCommand;
        public List<string> actions;
        public List<string> specialActions;
        public GameObject persona;
        public List <GameObject> spawnPrefabs;
        public AudioSource audio;
        public AudioClip triggerSound;
        
        void Awake()
        {
            s_VoiceInstance = this;
            audio.enabled=false;
        }

        public void Create(string transcript)
        {
            string [] words = transcript.Split(' ');
            foreach(var word in words)
            {
                if(actions.Contains(word.ToLower()))
                {
                    if(onVoiceCommand != null)
                    {
                        onVoiceCommand.Invoke(word.ToLower());
                    }
                    return;
                }
            }
            foreach(var word in words)
            {
                if(specialActions.Contains(word.ToLower()))
                {
                    if(word == "invocar")
                    {
                        SpawnObject(words);
                    }
                    else if(word == "cantar")
                    {
                        PlayMusic();
                    }
                }
                break;
            }                 
        }

        void SpawnObject(string[] words)
        {
            foreach(var word in words)
            {
                foreach(var prefab in spawnPrefabs)
                {
                    if(prefab.name == word.ToLower())
                    {
                        if(prefab.name == "sacerdotisa" || prefab.name == "ermitaño")
                        {
                            persona = Instantiate(prefab, new Vector3(0f,0.3f,-0.3f), Quaternion.identity);
                        }
                        else
                        {
                            persona = Instantiate(prefab, new Vector3(0f,0f,0f), Quaternion.identity);
                        }                       
                    }
                    //break;
                }
                Destroy(persona,3);
            }
        }

        void PlayMusic()
        {
            audio.enabled = true;
        
            audio.clip = triggerSound;
            audio.Play();
        }
    }
}