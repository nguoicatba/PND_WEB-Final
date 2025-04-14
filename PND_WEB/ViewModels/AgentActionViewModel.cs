using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class AgentActionViewModel
    {
        public Agent ?agent { get; set; }
        public List<AgentAction> ?agentActions  { get; set; }
    }
}
