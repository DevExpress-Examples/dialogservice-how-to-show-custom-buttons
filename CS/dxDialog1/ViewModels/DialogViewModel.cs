using DevExpress.Mvvm;

namespace dxDialog1.ViewModels {
    public class DialogViewModel : ViewModelBase {

        public DialogViewModel() { }
        public DialogViewModel(DialogViewModel viewModel) {
            Option1 = viewModel.Option1;
            Option2 = viewModel.Option2;
            Option3 = viewModel.Option3;
        }

        protected bool _Option1;
        public bool Option1
        {
            get { return this._Option1; }
            set { this.SetProperty(ref this._Option1, value, "Option1"); }
        }


        protected bool _Option2;
        public bool Option2
        {
            get { return this._Option2; }
            set { this.SetProperty(ref this._Option2, value, "Option2"); }
        }


        protected bool _Option3;
        public bool Option3
        {
            get { return this._Option3; }
            set { this.SetProperty(ref this._Option3, value, "Option3"); }
        }
        public void RestoreDefaults() {
            this.Option1 = true;
            this.Option2 = false;
            this.Option3 = true;

        }
    }
}
