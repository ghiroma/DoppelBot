using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.EZRobot.Entities
{
    public class DoppelBotGrammar
    {
        public Grammar CommandsGrammar
        {
            get
            {
                return this._commandsGrammar;
            }
        }

        private Grammar _commandsGrammar;

        private Choices _commands = new Choices(new string[] {
            "ojos rojos",
            "ojos verdes",
            "ojos azules",
            "apagar ojos",
            "adelante",
            "atras",

        });

        public DoppelBotGrammar()
        {
            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append("DoppelBot atencion ");
            grammarBuilder.Append(this._commands);
            grammarBuilder.Culture = CultureInfo.CreateSpecificCulture("es-ES");
            this._commandsGrammar = new Grammar(grammarBuilder);
        }
    }
}
