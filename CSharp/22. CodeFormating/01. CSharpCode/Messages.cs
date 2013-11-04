namespace SimpleEvents
{
    using System;
    using System.Text;

    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static StringBuilder Output
        {
            get
            {
                return output;
            }
        }

        public static void EventAdded()
        {
            Output.Append("Event added");
            Output.Append(Environment.NewLine);
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted", x);
                Output.Append(Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No events found" + Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}