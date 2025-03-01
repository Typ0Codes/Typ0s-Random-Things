using System;
using System.Collections;
using UnityEngine;

namespace Typ0sRandomThings
{

    public class WalkmanItem : GrabbableObject
    {
        //litterally just the boombox but it says walkman instead. thats it.
        //changed it to keep playing while in pocket but lower pitch and volume

        public AudioSource walkmanAudio;

        public AudioClip[] musicAudios;

        public AudioClip[] stopAudios;

        public System.Random musicRandomizer;

        private StartOfRound playersManager;

        private RoundManager roundManager;

        public bool isPlayingMusic;

        private float noiseInterval;

        private int timesPlayedWithoutTurningOff;

        public override void Start()
        {
            base.Start();
            playersManager = FindObjectOfType<StartOfRound>();
            roundManager = FindObjectOfType<RoundManager>();
            musicRandomizer = new System.Random(playersManager.randomMapSeed - 10);
        }

       

        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            StartMusic(used);
        }

        private void StartMusic(bool startMusic, bool pitchDown = false)
        {
            if (startMusic)
            {
                walkmanAudio.clip = musicAudios[musicRandomizer.Next(0, musicAudios.Length)];
                walkmanAudio.pitch = 1f;
                walkmanAudio.Play();
            }
            else if (isPlayingMusic)
            {
                if (pitchDown)
                {
                    StartCoroutine(musicPitchDown());
                }
                else
                {
                    walkmanAudio.Stop();
                    walkmanAudio.PlayOneShot(stopAudios[UnityEngine.Random.Range(0, stopAudios.Length)]);
                }
                timesPlayedWithoutTurningOff = 0;
            }
            isBeingUsed = startMusic;
            isPlayingMusic = startMusic;
        }

        private IEnumerator musicPitchDown()
        {
            for (int i = 0; i < 30; i++)
            {
                yield return null;
                walkmanAudio.pitch -= 0.033f;
                if (walkmanAudio.pitch <= 0f)
                {
                    break;
                }
            }
            walkmanAudio.Stop();
            walkmanAudio.PlayOneShot(stopAudios[UnityEngine.Random.Range(0, stopAudios.Length)]);
        }

        public override void UseUpBatteries()
        {
            base.UseUpBatteries();
            StartMusic(startMusic: false, pitchDown: true);
        }

        public override void PocketItem()
        {
            base.PocketItem();
            //walkmanAudio.pitch -= 0.05f;
            walkmanAudio.volume = 0.55f;
            //StartMusic(startMusic: false);
        }

        public override void EquipItem()
        {
            //walkmanAudio.pitch += 0.05f;
            walkmanAudio.volume = 1f;
            base.EquipItem();
        }

        public override void Update()
        {
            base.Update();
            if (isPlayingMusic)
            {
                if (noiseInterval <= 0f)
                {
                    noiseInterval = 1f;
                    timesPlayedWithoutTurningOff++;
                    roundManager.PlayAudibleNoise(transform.position, 16f, 0.9f, timesPlayedWithoutTurningOff, noiseIsInsideClosedShip: false, 5);
                }
                else
                {
                    noiseInterval -= Time.deltaTime;
                }
                if (insertedBattery.charge < 0.05f)
                {
                    walkmanAudio.pitch = 1f - (0.05f - insertedBattery.charge) * 4f;
                }
            }
        }
    }
}

