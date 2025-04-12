using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class AgentViewModel
    {
        public Agent ?agent { get; set; }
        public List<AgentAction> ?agentActions  { get; set; }
    }
}
