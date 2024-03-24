using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChall
{

    public class JogoGourmet
    {
        private Node raiz;

        public JogoGourmet()
        {
            Prato lasanha = new Prato("Lasanha");
            Prato boloDeChocolate = new Prato("Bolo de Chocolate");
            Prato massa = new Prato("Massa");

            Node nodeLasanha = new Node(lasanha);
            Node nodeBolo = new Node(boloDeChocolate);

            raiz = new Node(massa);
            raiz.YesNode = nodeLasanha;
            raiz.NoNode = nodeBolo;
        }

        public void IniciarJogo()
        {
            MessageBox.Show("Pense em um prato que você gosta");
            AdivinharPrato(raiz);
        }

        private void AdivinharPrato(Node node)
        {
            if (node.YesNode == null && node.NoNode == null)
            {
                DialogResult resposta = MessageBox.Show($"O prato que você pensou é {node.Prato.Nome}?", "Confirmar", MessageBoxButtons.YesNo);

                if (resposta == DialogResult.Yes)
                {
                    MessageBox.Show("Eu acertei!");
                }
                else
                {
                    AdicionarNovoPrato(node);
                }
            }
            else
            {
                DialogResult resposta = MessageBox.Show($"O prato que você pensou é {node.Prato.Nome}?", "Confirmar", MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    if (node.YesNode != null)
                    {
                        AdivinharPrato(node.YesNode);
                    }
                    else
                    {
                        MessageBox.Show("Eu acertei!");
                    }
                }
                else
                {
                    if (node.NoNode != null)
                    {
                        AdivinharPrato(node.NoNode);
                    }
                    else
                    {
                        AdicionarNovoPrato(node);
                    }
                }
            }
        }

        private void AdicionarNovoPrato(Node node)
        {
            string pratoPensado = Microsoft.VisualBasic.Interaction.InputBox("Eu desisto. Qual prato você pensou?", "Novo Prato");
            string caracteristicaExistente = node.Prato.Nome;
            string novaCaracteristica = Microsoft.VisualBasic.Interaction.InputBox($"Complete a frase: {pratoPensado} é _______ mas {caracteristicaExistente} não.", "Nova Característica");

            Prato novoPrato = new Prato(pratoPensado);
            Node novoTipoPrato = new Node(new Prato(novaCaracteristica));
            novoTipoPrato.YesNode = new Node(novoPrato);
            node.NoNode = novoTipoPrato;
        }
    }

  
}
