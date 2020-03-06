using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation
{
    class Script
    {
        public static List<Message> messages = new List<Message>()
        {
            /* original test
            new Message(1, "hello  oooooooooooooo"),
            new Message(2, "yo"),
            new Message(3, "this is a long message", 2000),
            new Message(1, "this is an answer", 3000, new Answer("default", "input", "answer 3")),
            new Message(2, "test"),
            new Message(2, "test"),
            new Message(2, "test")
            */

            new Message(1, "Hoi"),
            new Message(2, "Hallo"),
            new Message(4, "Hoi"),
            new Message(3, "Hey"),
            new Message(1, "Oké, de opdracht is dus....", 2000),
            new Message(1, "We moeten een Persona maken", 800, new Answer("Piet", null, null)),
            new Message(2, "Piet!"),
            new Message(3, "Jaaa Piet lol"),
            new Message(1, "Oké, laten we heel simpel beginnen:", 2000),
            new Message(1, "Wat is Piet zijn baan?", 800, new Answer("input", null, null)),
            new Message(3, "Koffie zetter"),
            new Message(2, "Is dat een baan?"),
            new Message(1, "Wat wil je dan?", 800, new Answer("input", null, null)),
            new Message(2, "Telefonist"),
            new Message(3, "Oké, doe maar telefonist"),
            new Message(1, "Hoe oud is Piet?", 300, new Answer("input", null, null)),
            new Message(3, "69!"),
            new Message(2, "62"),
            new Message(3, "Ik stem voor 69", 1000, new Answer("Ik stem ook voor 69", "Ik stem ook voor 62", null)),
            new Message(1, "Oké, Piet is 69 jaar oud"),
            new Message(2, "[Even later...]", 2000),
            new Message(1, "Piet is dus verslaafd aan koffie, haat zijn baan en probeert 3x per dag zelfmoord te plegen", 800, new Answer("Wat zielig", null, null)),
            new Message(2, "Wat zielig"),
            new Message(1, "Tijd om het over de website te hebben"),
            new Message(3, "Hoe willen jullie dat we dit gedeelte doen?", 1500, new Answer("Manier A lijkt mij handig", "Misschien kunnen we het op manier B doen", null)),
            new Message(2, "We kunnen het op manier C doen", 1500, new Answer("default", "Wacht, die manier is misschien niet handig", null)),
            new Message(3, "Oké, en hoe vinden jullie dit eruit zien?", 2200, new Answer("default", "Misschien kan het zo handiger", "Ik heb een mooier idee")),
            new Message(1, "Ziet er sick uit"),
            new Message(1, "Ik vind alleen dit deel nog onduidelijk", 1000, new Answer("input", null, null)),
            new Message(2, "Dat kunnen we op deze manier oplossen", 1400, new Answer("default", "Heb je wel aan probleem X gedacht in dat geval?", null)),
            new Message(3, "Voor de settings pagina moeten we...", 200),
            new Message(1, "We moeten er voor zorgen dat de font, kleur en background...", 200),
            new Message(2, "Je kan het er uit laten zien zoals...", 200),
            new Message(3, "Ik dacht gewoon simpel een lijst waarbij...", 200),
            new Message(1, "Bedoel je dat je bijvoorbeeld...", 200),
            new Message(2, "En dan kunnen we hier ervoor zorgen dat...", 200),
            new Message(3, "Wat vind jij?", 3000, new Answer("default", "input", null)),
            new Message(1, "", 5000),
            new Message(1, "(je kan het spel afsluiten nu)", 90000),


        };
    };

}
