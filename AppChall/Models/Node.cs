using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChall
{
    public class Node
    {
        public Prato Prato { get; set; }
        public Node YesNode { get; set; }
        public Node NoNode { get; set; }

        public Node(Prato prato)
        {
            Prato = prato;
        }
    }

}
