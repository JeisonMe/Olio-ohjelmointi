using System;

namespace ovi
{
    using System;

    enum DoorState
    {
        Open, Closed, Locked
    }

    class Door
    {
        private DoorState state;

        public Door()
        {
            state = DoorState.Closed;
        }

        public void ProcessCommand(string command)
        {
            switch (command)
            {
                case "lukitse":
                    if (state == DoorState.Closed)
                    {
                        state = DoorState.Locked;
                        Console.WriteLine("Ovi on lukossa");
                    }
                    break;

                case "avaa lukko":
                    if (state == DoorState.Locked)
                    {
                        state = DoorState.Closed;
                        Console.WriteLine("Oven lukko on auki");

                    }
                    break;
                case "avaa":
                    if (state == DoorState.Closed)
                    {
                        state = DoorState.Open;
                        Console.WriteLine("Ovi on auki");

                    }
                    break;
                case "sulje":
                    if (state == DoorState.Open)
                    {
                        state = DoorState.Closed;
                        Console.WriteLine("Ovi on kiinni");
                    }
                    break;


            }
        }

        public DoorState GetState()
        {
            return state;
        }
    }

    class Program
    {
        static void Main()
        {
            Door door = new Door();
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("Valitse avaa, sulje, lukitse tai avaa lukko");
                Console.WriteLine("----------------------------------------------");

                string command = Console.ReadLine();

                switch (command)
                {
                    default:
                        door.ProcessCommand(command);
                        break;
                }
            }
        }
    }
}

