﻿using System;
using System.Windows.Forms;
using DeVes.Bazaar.Data;

namespace DeVes.Bazaar.Server.SubForms
{
    public partial class RemoveSoldFromPosition : Form
    {
        public enum FrmTypes
        {
            RemoveSuplPos,
            RemoveSold,
            RemoveReturned
        }


        public FrmTypes FrmType { get; private set; }


        public RemoveSoldFromPosition(FrmTypes frmType)
        {
            InitializeComponent();

            this.FrmType = frmType;
            switch (frmType)
            {
                case FrmTypes.RemoveSuplPos:
                    this.titelBarCtrl1.TitelText = "Verkäufer zurücksetzten:";
                    this.label2.Text = @"Verkäufernummer:";
                    break;

                case FrmTypes.RemoveSold:
                    this.titelBarCtrl1.TitelText = "Verkauf zurücksetzten:";
                    this.label2.Text = @"Positionsnummer:";
                    break;
                case FrmTypes.RemoveReturned:
                    this.titelBarCtrl1.TitelText = "Rückgabe zurücksetzten:";
                    this.label2.Text = @"Positionsnummer:";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dvTextBox2.IntValue.HasValue)
            {
                switch (this.FrmType)
                {
                    case FrmTypes.RemoveSuplPos:
                        GParams.Instance.Position.RemovePositionsOfSupplier(dvTextBox2.IntValue.Value);
                        Console.Beep(1000, 500);
                        break;

                    case FrmTypes.RemoveSold:
                        GParams.Instance.Position.RemoveSoldFromPosition(dvTextBox2.IntValue.Value);
                        Console.Beep(1000, 500);
                        break;
                    case FrmTypes.RemoveReturned:
                        GParams.Instance.Position.RemoveReturnedFromPosition(dvTextBox2.IntValue.Value);
                        Console.Beep(1000, 500);
                        break;
                }
            }

            this.dvTextBox2.Focus();
            this.dvTextBox2.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public static void AskForNumber(IWin32Window owner, FrmTypes frmType)
        {
            var _frm = new RemoveSoldFromPosition(frmType);

            _frm.ShowDialog(owner);
            _frm.Dispose();
        }

        private void dvTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
            }
        }
        private void dvTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.button1_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}