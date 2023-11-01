using CompalintsSystem.Core.Models;
using System.Collections.Generic;

namespace CompalintsSystem.Core.ViewModels.Data
{
    public class CommunicationVM
    {
        public IEnumerable<UsersCommunication> CommunicationList { get; set; }
        public UsersCommunication usersCommunication { get; set; }

    }
}
