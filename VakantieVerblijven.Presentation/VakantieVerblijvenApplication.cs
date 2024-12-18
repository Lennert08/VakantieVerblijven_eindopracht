using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VakantieVerblijven.Domain;

namespace VakantieVerblijven.Presentation
{
    public class VakantieVerblijvenApplication
    {
        private DomainManager _domainManager;

        public VakantieVerblijvenApplication(DomainManager domainManager)
        {
            _domainManager = domainManager;
            MessageBox.Show("test");
        }
    }
}
