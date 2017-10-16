using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace CBA_Test
    {
    public partial class Form1 : Form
        {
        void setSerialConfig( string Port )
            {
            try
                {
                obSerial.PortName = Port;
                obSerial.BaudRate = 115200;
                obSerial.Parity = Parity.None;
                obSerial.DataBits = 8;
                obSerial.StopBits = StopBits.One;
                obSerial.Handshake = Handshake.None;

                obSerial.DataReceived += new SerialDataReceivedEventHandler( serialReadHandler );

                obSerial.Open();
                }
            catch
                {
                /* TODO: Implement exception catch */
                }

            }



        void UpdateComboBox()
            {
            int index;
            string[] portString = SerialPort.GetPortNames();
            /* Writing the COM ports in the COM_ComboBox (Serial Ports COM) */
            for( index = 0 ; index < (portString.Length) ; index++ )
                {
                COM_ComboBox.Items.Add( portString[index] );
                }
            }



        delegate void SetTextCallback( string text );
        public void Terminal_textbox_updateText( string Text )
            {
            if( this.Terminal_textbox.InvokeRequired )
                {
                SetTextCallback d = new SetTextCallback(Terminal_textbox_updateText);
                this.Invoke( d , new object[] { Text } );
                }
            else
                {
                Terminal_textbox.AppendText( Text.Replace( "\r\n" , "\n" ).Replace( "\n" , Environment.NewLine ) );
                }
            }
        }
    }