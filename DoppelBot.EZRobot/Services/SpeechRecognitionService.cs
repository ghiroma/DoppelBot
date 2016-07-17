using DoppelBot.EZRobot.Constants;
using DoppelBot.EZRobot.Entities;
using DoppelBot.EZRobot.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Services
{
    public class SpeechRecognitionService : ISpeechRecognitionService
    {
        private IEyesService _eyesService;
        private IMovementService _movementService;
        private SpeechRecognizer _speechRecognizer;

        public SpeechRecognitionService(IEyesService eyesService, IMovementService movementService)
        {
            this._eyesService = eyesService;
            this._movementService = movementService;
            this._speechRecognizer = new SpeechRecognizer();
        }

        public void StartListening()
        {

            var doppelbotGrammar = new DoppelBotGrammar();
            this._speechRecognizer.LoadGrammar(doppelbotGrammar.CommandsGrammar);
            this._speechRecognizer.SpeechRecognized += _speechRecognizer_SpeechRecognized;
            if (this._speechRecognizer.State != RecognizerState.Listening)
            {
                throw new Exception("Speech recognizer could not be started.");
            }
        }

        private void _speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var text = e.Result.Text;
            text = text.ToLower();
            switch (text)
            {
                case "doppelbot atencion ojos verdes":
                    this._eyesService.ChangeColor(ColorsConstants.Green);
                    break;
                case "doppelbot atencion apagar ojos":
                    this._eyesService.ShutdownEyes();
                    break;
                case "doppelbot atencion ojos rojos":
                    this._eyesService.ChangeColor(ColorsConstants.Red);
                    break;
                case "doppelbot atencion ojos azules":
                    this._eyesService.ChangeColor(ColorsConstants.Blue);
                    break;
                case "doppelbot atencion adelante":
                    this._movementService.MoveForward();
                    break;
                case "doppelbot atencion atras":
                    this._movementService.MoveBackward();
                    break;
            }
        }

        public void StopListening()
        {
            if (this._speechRecognizer.State == RecognizerState.Listening)
            {
                this._speechRecognizer.Enabled = false;
            }
        }
    }
}
