using DevExpress.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace dxDialog1.ViewModels {
    public class MainViewModel : ViewModelBase {
        protected IDialogService DialogService { get { return this.GetService<IDialogService>(); } }

        DialogViewModel dialogViewModel = null;

        public MainViewModel() {
            ShowDialogCommand = new DelegateCommand(ShowDialog);
            Result = "Please use the 'Choose Options' button to open a dialog window and choose options.";
        }

        public DelegateCommand ShowDialogCommand { get; private set; } 

        public async void ShowDialog() {

            if(dialogViewModel == null)
                dialogViewModel = new DialogViewModel();
            DialogViewModel viewModel = new DialogViewModel(dialogViewModel);

            UICommand restoreDefaultsCommand = new UICommand() {
                Id = "cmdRestoreDefaults",
                Caption = "Restore Defaults",
                IsCancel = false,
                IsDefault = false,
                Command = new DelegateCommand<CancelEventArgs>(x => {
                    x.Cancel = true;
                    viewModel.RestoreDefaults();
                }),
            };


            UICommand saveCommand = new UICommand() {
                Id = "cmdSave",
                Caption = "Save",
                IsCancel = false,
                IsDefault = true,
            };

            UICommand cancelCommand = new UICommand() {
                Id = "cmdCancel",
                Caption = "Cancel",
                IsCancel = true,
                IsDefault = false,
            };

            var result = await DialogService.ShowDialogAsync(
                new List<UICommand>() { restoreDefaultsCommand, saveCommand, cancelCommand},
                "Check options that you want to enable",
                viewModel);

            StringBuilder builder = new StringBuilder();

            if(result != cancelCommand)
            {
                builder = new StringBuilder("The Dialog was not canceled. The state of the options is the following:\n");
                dialogViewModel = viewModel;
            }
            else
            {
                builder = new StringBuilder("The Dialog was canceled. The state of the options is the following:\n");
            }

            fillOptions(builder, dialogViewModel);
            Result = builder.ToString();
        }

        void fillOptions(StringBuilder builder, DialogViewModel viewModel) {
            builder.Append(string.Format("{0} = {1}\n", nameof(viewModel.Option1), viewModel.Option1));
            builder.Append(string.Format("{0} = {1}\n", nameof(viewModel.Option2), viewModel.Option2));
            builder.Append(string.Format("{0} = {1}\n", nameof(viewModel.Option3), viewModel.Option3));
        }

        protected string _Result;
        public string Result
        {
            get { return this._Result; }
            set { this.SetProperty(ref this._Result, value, "Result"); }
        }
    }
}
