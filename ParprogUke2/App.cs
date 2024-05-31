using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParprogUke2
{
    internal class App
    {
        private List<Task> tasks = new();
        bool isRunning = true;

        internal void Run()
        {
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hva vil du gjøre?");
                Console.WriteLine("1. Vis oppgaveliste");
                Console.WriteLine("2. Slett en oppgave");
                Console.WriteLine("3. Endre en oppgave");
                Console.WriteLine("4. Legg til en oppgave");
                Console.WriteLine("5. Endre plass på en oppgave");
                Console.WriteLine("6. Avslutt program");

                string? input = Console.ReadLine();
                if (input == "1") Show();
                else if (input == "2") Delete();
                else if (input == "3") EditTask();
                else if (input == "4") AddTask();
                else if (input == "5") ChangeOrder();
                else if (input == "6") isRunning = false;
            }
        }

        private void ChangeOrder()
        {
            Console.Clear();
            ListTasksWithId();
            Console.WriteLine();
            Console.WriteLine("Hvilken task vil du flytte?");

            var input = Console.ReadLine();
            int selectedIndex = Convert.ToInt32(input)-1;
            Console.WriteLine();
            Console.WriteLine($"Hva skal den nye plassen til {tasks[selectedIndex].GetName()} være?");

            var selectedItem = tasks[selectedIndex];
            tasks.RemoveAt(selectedIndex);

            var newIndex = Console.ReadLine();
            int newIndexNum = Convert.ToInt32(newIndex)-1;

            tasks.Insert(newIndexNum, selectedItem);

            Console.Clear();

            Console.WriteLine("Du flyttet på oppgaven");
            Console.WriteLine();
            Console.WriteLine("Trykk en tast for å fortsette..");
            Console.ReadKey();
        }
        private void EditTask()
        {
            Console.Clear();
            ListTasksWithId();

            Console.WriteLine("Hva er id'en på oppgaven du vil endre på?");
            var input = Console.ReadLine();
            int inputNum = Convert.ToInt32(input);

            Console.Clear();

            Console.WriteLine("Trykk hva du vil endre på navnet eller trykk nei for å ikke endre");
            var nameInput = Console.ReadLine();

            if (nameInput != "nei") tasks[inputNum].SetName(nameInput);

            Console.WriteLine("Trykk hva du vil endre på beskrivelse eller trykk nei for å ikke endre");
            var descInput = Console.ReadLine();

            if (descInput != "nei") tasks[inputNum].SetDesc(descInput);
        }

        private void ListTasksWithId()
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"Id:{i + 1} Navn: {tasks[i].GetName()} Beskrivelse: {tasks[i].GetDesc()}");
            }
        }

        private void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Hva er oppgaven?");
            string taskName = Console.ReadLine();
            Console.WriteLine("Hva er beskrivelsen til oppgaven?");
            string taskDescription = Console.ReadLine();
            tasks.Add(new Task(taskName, taskDescription));
        }

        private void Show()
        {
            Console.Clear();
            for (var i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"Navn: {tasks[i].GetName()} Beskrivelse: {tasks[i].GetDesc()}");
            }
            Console.WriteLine();
            Console.WriteLine("Trykk en tast for å gå tilbake..");
            Console.ReadKey();
        }

        private void Delete()
        {
            ListTasksWithId();

            Console.WriteLine("Hva er id'en på oppgaven du vil slette?");
            var input = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine($"Du slettet {tasks[input].GetName()}.");
            tasks.RemoveAt(input);
            Console.WriteLine();
            Console.WriteLine("Trykk en tast for å fortsette..");
            Console.ReadKey();
        }
    }
}
