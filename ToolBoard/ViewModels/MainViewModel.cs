using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using ToolBoard.Enums;

namespace ToolBoard.ViewModels
{
    public  class MainViewModel : ObservableObject
    {
        #region FullProps
        private PageId _PageId;
        public PageId PageId
        {
            get { return _PageId; }
            set { SetProperty(ref _PageId, value);}
        }
        #endregion

        #region Commands
        public ICommand CMD_ChangePage => new RelayCommand<PageId>(ChangePage);  
        #endregion

        public MainViewModel()
        {

        }

        #region Methods

        void ChangePage( PageId newPage)
        {
            PageId = newPage;
        }
        #endregion
    }
}
