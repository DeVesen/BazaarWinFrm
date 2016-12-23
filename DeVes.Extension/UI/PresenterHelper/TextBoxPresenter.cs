using DeVes.Extension.UI.WPF;

namespace DeVes.Extension.UI.PresenterHelper
{
    public class TextBoxPresenter : ObservableObject
    {
        private string m_text;
        public string Text
        {
            get { return this.m_text; }
            set
            {
                this.m_text = value;
                this.RaisePropertyChangedEvent();
            }
        }

        private bool m_userShouldEditValueNow;
        public bool UserShouldEditValueNow
        {
            get { return this.m_userShouldEditValueNow; }
            private set
            {
                this.m_userShouldEditValueNow = value;
                this.RaisePropertyChangedEvent();
            }
        }


        public void SetFocus()
        {
            this.UserShouldEditValueNow = false;
            this.UserShouldEditValueNow = true;
        }

        public void ResetText()
        {
            this.Text = null;
        }
    }
}
