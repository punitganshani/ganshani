using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Media;

namespace CustomTextBox
{
    public class FilterTextBox : TextBox
    {
        private List<char> _specialChars;
        private bool _allowAlphabets;
        private bool _allowNumeric;
        private bool _beepOnError;
        private static List<Keys> _keys;

        public FilterTextBox()
        {
            if (_keys == null)
                PopulateKeys();
        }

        private static void PopulateKeys()
        {
            _keys = new List<Keys> {Keys.Back};
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public List<char> SpecialChars
        {
            get { return _specialChars; }
            set { _specialChars = value; }
        }
        [Browsable(true)]
        [DefaultValue(true)]
        public bool AllowAlphabets
        {
            get { return _allowAlphabets; }
            set { _allowAlphabets = value; }
        }
        [Browsable(true)]
        [DefaultValue(false)]
        public bool AllowNumeric
        {
            get { return _allowNumeric; }
            set { _allowNumeric = value; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool BeepOnError
        {
            get { return _beepOnError; }
            set { _beepOnError = value; }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Keys keyPressed = (Keys)e.KeyChar;

            if (_keys.Contains(keyPressed))
            {
                e.Handled = false;
            }
            else
            {
                bool handleAlphabets = true;
                bool handleNumberic = true;
                int ascii = (int)e.KeyChar;

                if (_specialChars != null && (_specialChars.Contains(e.KeyChar)))
                    e.Handled = false;
                else
                {
                    handleAlphabets = (ascii >= 65 && ascii <= 90 || ascii >= 97 && ascii <= 122 || ascii == 32);
                    handleNumberic = ascii >= 48 && ascii <= 57;

                    e.Handled = (handleNumberic && _allowNumeric) || (handleAlphabets && _allowAlphabets);
                    e.Handled = !e.Handled;
                }
            }

            if (e.Handled && BeepOnError)
                new SoundPlayer().Play();

            base.OnKeyPress(e);
        }
    }
}
