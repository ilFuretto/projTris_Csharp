using System.Drawing;

namespace tris
{
    public partial class Form1 : Form
    {
        private string turno;
        private int cont;
        private int tempoRimanente = 3 ;
        public Form1()
        {
            InitializeComponent();
            labelTempo.Text = "Tempo rimasto: " + tempoRimanente + "s";
        }
        private void TimerMossa_Tick(object sender, EventArgs e)
        {
            tempoRimanente--;
            labelTempo.Text = "Tempo rimasto: " + tempoRimanente + "s";
            if (tempoRimanente == 0)
            {
                tempoRimanente = 4; 
                FaiMossaCasuale();
            }
        }
        private bool VerificaVittoria()
        {
            return (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "") ||
                   (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "") ||
                   (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "") ||
                   (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "") ||
                   (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "") ||
                   (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "") ||
                   (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "") ||
                   (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false) return;
            
            Button pulsante = (Button)sender;
            if (pulsante.Text == "")
            {
                pulsante.Text = turno;
                cont++;

                if (VerificaVittoria())
                {
                    timer1.Stop();
                    MessageBox.Show("Ha vinto " + turno + ", complimenti! Molti nemici, molto onore!");
                    fineGioco();
                    return;
                }
                else if (cont == 9)
                {
                    timer1.Stop();
                    MessageBox.Show("Pareggio");
                    fineGioco();
                    return;
                }

                turno = (turno == "X") ? "0" : "X";
                labelTurno.Text = turno;
                tempoRimanente = 4;
            }
        }
        private void FaiMossaCasuale()
        {
            if (timer1.Enabled == false) return;
           

            Random generatore = new Random();
            bool mossaEffettuata = false;

            while (!mossaEffettuata)
            {
                int mossa = generatore.Next(1, 10);
                switch (mossa)
                {
                    case 1: if (button1.Text == "") { button1.Text = turno; mossaEffettuata = true; } break;
                    case 2: if (button2.Text == "") { button2.Text = turno; mossaEffettuata = true; } break;
                    case 3: if (button3.Text == "") { button3.Text = turno; mossaEffettuata = true; } break;
                    case 4: if (button4.Text == "") { button4.Text = turno; mossaEffettuata = true; } break;
                    case 5: if (button5.Text == "") { button5.Text = turno; mossaEffettuata = true; } break;
                    case 6: if (button6.Text == "") { button6.Text = turno; mossaEffettuata = true; } break;
                    case 7: if (button7.Text == "") { button7.Text = turno; mossaEffettuata = true; } break;
                    case 8: if (button8.Text == "") { button8.Text = turno; mossaEffettuata = true; } break;
                    case 9: if (button9.Text == "") { button9.Text = turno; mossaEffettuata = true; } break;
                }
            }

            cont++;  

            if (VerificaVittoria() && cont > 5)
            {
                timer1.Stop();
                MessageBox.Show("Ha vinto " + turno + ", complimenti! Molti nemici, molto onore!");
                fineGioco();
                return;
            }
            else if (cont == 9)
            {
                timer1.Stop();
                MessageBox.Show("Pareggio");
                fineGioco();
                return;
            }
            turno = (turno == "X") ? "0" : "X";
            labelTurno.Text = turno;

            tempoRimanente = 4;
        }
        
        private void Form1_Load(object sender, EventArgs e) 
        {
            
            
            cont = 0;
            Random generatore=new Random();
            if (generatore.Next(2) == 0) turno = "X";
            else turno = "0";
            labelTurno.Text = turno;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }
        private void buttonInizia_Click(object sender, EventArgs e)
        {
            buttonInizia.Visible = false;
            labelTempo.Visible = true;
            timer1.Start();
            Form1_Load(this, EventArgs.Empty); 
        }

        private void fineGioco()
        {
            buttonInizia.Visible = true;
            labelTempo.Visible = false;
            return;
        }
    }
}
