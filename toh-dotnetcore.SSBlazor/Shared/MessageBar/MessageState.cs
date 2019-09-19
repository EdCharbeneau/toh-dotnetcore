using System;
using System.Collections.Generic;

namespace toh_dotnetcore.SSBlazor.Shared
{
    public class MessageState
    {
        // Hide the List behind IEnumerable so the Add/Remove API isn't exposed to the public
        private List<string> messages = new List<string>();

        public IEnumerable<string> Messages { get => messages; }
        public void AddMesage(string message)
        {
            messages.Add($"HeroService: {message}");
            NotifyStateHasChanged?.Invoke(); // Time to redraw
        }
        public void ClearMessages()
        {
            messages.Clear();
            // Since Clear is invoked by a button which causes a redraw
            // there's no need to do the line below
            // Unless we decide to clear state from outside that button somehow
            //NotifyStateHasChanged?.Invoke();
        }

        // Tell the MessageBar that it needs to redraw
        public Action NotifyStateHasChanged { get; set; }

    }
}
